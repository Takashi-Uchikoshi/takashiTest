using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using Npgsql;

namespace B2.Com
{
    public class clsHidukeLib
    {
        private struct GengoStruct
        {
            public string FullName;                             //元号名
            public string AlphabetName;                         //略称アルファベット１文字
            public string OmissionName;                         //略称漢字一文字
            public int FromDate;                                //開始日付
            public int ToDate;                                  //終了日付
            public int CountYear;                               //年数
        }

        private GengoStruct[] GengoInfo = new GengoStruct[11];

        private string mstrSyoriYMD = "";
        //GENGO.INIの中身
        private string GENGO_GengoString = "04明治M明18680908191207290045大正T大19120730192612240015昭和S昭19261225198901070064平成H平19890108999999990099　　 　99999999999999999999　　 　99999999999999999999　　 　99999999999999999999西暦8西18000101189912310099西暦9西19000101199912310099西暦0西20000101299912310099";

        #region // GENGO.INIの取得
        //*************************************************************************************
        /// <summary> 機能　　　: GENGO.INIの取得</summary>
        /// <remark>  機能説明　: GENGO.INIの取得</remark>
        //*************************************************************************************
        public clsHidukeLib()
        {
            int wkIntValue;

            for(int LoopCount = 0; LoopCount < 10; LoopCount++)
            {
                GengoInfo[LoopCount].FullName = Ans.AnsMidB(GENGO_GengoString, LoopCount * 27 + 2, 4);
                GengoInfo[LoopCount].AlphabetName = Ans.AnsMidB(GENGO_GengoString, LoopCount * 27 + 6, 1);
                GengoInfo[LoopCount].OmissionName = Ans.AnsMidB(GENGO_GengoString, LoopCount * 27 + 7, 2);


                if(int.TryParse(Ans.AnsMidB(GENGO_GengoString, LoopCount * 27 + 9, 8), out wkIntValue) == true)
                {
                    GengoInfo[LoopCount].FromDate = wkIntValue;
                }

                if(int.TryParse(Ans.AnsMidB(GENGO_GengoString, LoopCount * 27 + 17, 8), out wkIntValue) == true)
                {
                    GengoInfo[LoopCount].ToDate = wkIntValue;
                }

                if(int.TryParse(Ans.AnsMidB(GENGO_GengoString, LoopCount * 27 + 25, 4), out wkIntValue) == true)
                {
                    GengoInfo[LoopCount].CountYear = wkIntValue;
                }
            }

            GengoInfo[10].FullName = "ERR ";
            GengoInfo[10].AlphabetName = "E";
            GengoInfo[10].OmissionName = "ER";
            GengoInfo[10].FromDate = 0;
            GengoInfo[10].ToDate = 99999999;
            GengoInfo[10].CountYear = 9999;

        }
        #endregion

        #region  日付の変換
        //*************************************************************************************
        /// <summary> 機能　　　: 日付の変換</summary>
        /// <param name="pstrinDate">(I)入力日付(有効日付であれば和暦西暦両方可) </param> 
        /// <param name="pintretFormatType">(I) 返す日付のフォーマット 0:西暦 1:和暦 2:和暦略 3:和暦英略 4:年月日付き和暦</param> 
        /// <param name="pstrseparateChar">(I) 区切り文字</param>
        /// <param name="pstrDefDate">(I) 基準日（ﾌﾞﾗﾝｸの場合、ｼｽﾃﾑ日付）</param>
        /// <remark>  機能説明　: 日付の変換</remark>
        //*************************************************************************************
        public string ConvDate(string pstrinDate, int pintretFormatType, string pstrseparateChar,
                               string pstrDefDate)
        {
            StringBuilder WkStr = new StringBuilder();              // 変換用
            string lstrInDateValue;                                 // 対象日付

            // デフォルト値
            string lstrDEF_Reki;                                    // デフォルト歴No(1～9、0)
            string lstrDefDateValue;                                // 基準日 

            string lstrReki;                                        // 対象和暦No

            // WK変数
            int lintYYYY;                                           // 年WK
            string lstrGengoR;                                      // 元号略取得用
            int lintGengoIndex;                                     // 元号配列該当NO
            string lstrYMDWK;                                       // 年月日WK
            Boolean lblnWarekiFlg;                                  // 和暦判定フラグ(true:和暦、false:西暦)

            DateTime ldteRet;                                       // 日付チェック用戻値

            int lintwkWarekiYear;                                   // 和暦年用
            int lintwkWarekiMD;                                     // 和暦月日用
            int lintwkSeirekiYear;                                  // 西暦年用
            int lintwkAddYear;                                      // 開始年用
            string lstrwkMM;                                        // 月用
            string lstrwkDD;                                        // 日用

            int lintwkIntValue;                                     // int型変換WK
            int lintSelectGengoCount;                               // 元号配列No

            string ReturnValue;                                     // 戻値設定用


            try
            {
                //------------------------------------------------------------------------------
                // ■ 基準日/基準歴No(1～９，０）　セット
                //------------------------------------------------------------------------------
                if(pstrDefDate.Length == 0)
                {
                    lstrDefDateValue = DateTime.Today.ToString("yyyyMMdd");

                }
                else
                {
                    lstrDefDateValue = pstrDefDate;
                }
                lstrDEF_Reki = "0";
                int.TryParse(lstrDefDateValue, out lintwkIntValue);                     // 1.数値変換
                for(int LoopCount = 0; LoopCount < 7; LoopCount++)                     // ０～６までの配列、７以降は年代配列
                {
                    //入力年度に該当する元号を取得
                    if(lintwkIntValue >= GengoInfo[LoopCount].FromDate &&
                        lintwkIntValue <= GengoInfo[LoopCount].ToDate)
                    {
                        int lintReki = LoopCount + 1;
                        lstrDEF_Reki = lintReki.ToString();
                        break;
                    }
                }

                //------------------------------------------------------------------------------
                // ■ 空白であれば基準日設定
                //------------------------------------------------------------------------------
                if(pstrinDate != "")
                {
                    lstrInDateValue = pstrinDate.ToUpper();
                }
                else
                {
                    lstrInDateValue = lstrDefDateValue;
                }

                //------------------------------------------------------------------------------
                // ■ 区切り文字の削除
                //------------------------------------------------------------------------------
                lstrInDateValue = lstrInDateValue.Replace(" ", "");
                lstrInDateValue = lstrInDateValue.Replace("/", "");
                lstrInDateValue = lstrInDateValue.Replace("-", "");
                lstrInDateValue = lstrInDateValue.Replace(".", "");

                //------------------------------------------------------------------------------
                // ■ 文字長0は、EXIT
                //------------------------------------------------------------------------------
                if(lstrInDateValue.Length == 0)
                {
                    return "";
                }

                //------------------------------------------------------------------------------
                // ■  文字の場合、「HYYMMDD」形式のみ許可
                //      [9YYMMDD]形式へ
                //------------------------------------------------------------------------------
                if(int.TryParse(lstrInDateValue, out lintwkIntValue) == false)
                {
                    // 文字分割
                    lstrGengoR = lstrInDateValue.Substring(0, 1);                    // １文字目
                    lstrYMDWK = Ans.AnsMidB(lstrInDateValue, 1);                  // ２文字目以降

                    // 1文字目はアルファベットのみ
                    if(Char.IsLetter(lstrGengoR, 0) == false)
                    {
                        return "";
                    }
                    // 年月日部は6桁
                    if(lstrYMDWK.Length != 6)
                    {
                        return "";
                    }
                    // 年月日部は数値
                    if(int.TryParse(lstrYMDWK, out lintwkIntValue) == false)
                    {
                        return "";
                    }
                    // 元号略→元号NOへ変換、変換できない場合ｴﾗｰ
                    lintGengoIndex = GetGengo(lstrGengoR);
                    if(lintGengoIndex == 0)
                    {
                        return "";
                    }

                    // 元号No＋年月日へ変換 [9YYMMDD]形式へ
                    WkStr.Remove(0, WkStr.Length);
                    WkStr.Append(lintGengoIndex.ToString("0"));
                    WkStr.Append(lstrYMDWK);
                    lstrInDateValue = WkStr.ToString();

                }
                //------------------------------------------------------------------------------
                // ■  数値(和暦)の場合：デフォルト年月日をプラスし(00YYMMDD形式へ)
                //     西暦：YYYYMMDD形式
                //　　 和暦：00YYMMDD形式/9YYMMDD形式へ変換
                //------------------------------------------------------------------------------
                else
                {

                    WkStr.Remove(0, WkStr.Length);
                    //--------------------------------------------------------------------------
                    // 桁数により変換
                    //--------------------------------------------------------------------------
                    switch(lstrInDateValue.Length)
                    {
                        //----------------------------------------------------------------------
                        // ◇　8桁の場合
                        //----------------------------------------------------------------------
                        case 8:
                            // 西暦の為、無処理
                            break;
                        //----------------------------------------------------------------------
                        // ◇　7桁の場合
                        //----------------------------------------------------------------------
                        case 7:
                            // 和暦記号＋年月日の為無処理
                            break;
                        //----------------------------------------------------------------------
                        // ◇　6,5桁の場合
                        //----------------------------------------------------------------------
                        case 6:
                        case 5:
                            // [00YYMMDD]形式
                            WkStr.Append(lstrInDateValue.PadLeft(8, '0'));
                            lstrInDateValue = WkStr.ToString();
                            break;

                        //----------------------------------------------------------------------
                        // ◇　数値3,4桁は月日入力扱い 基準日の年 付加
                        //----------------------------------------------------------------------
                        case 4:
                        case 3:
                            // 基準日[YYYY]+MMDD 形式
                            WkStr.Append(lstrDefDateValue.Substring(0, 4));
                            WkStr.Append(lstrInDateValue.PadLeft(4, '0'));

                            lstrInDateValue = WkStr.ToString();
                            break;

                        //----------------------------------------------------------------------
                        // ◇　数値1,2桁は日入力扱い 基準日の年月 付加
                        //----------------------------------------------------------------------
                        case 2:
                        case 1:
                            // 基準日[YYYYMM]+DD 形式
                            WkStr.Append(lstrDefDateValue.Substring(0, 6));
                            WkStr.Append(lstrInDateValue.PadLeft(2, '0'));

                            lstrInDateValue = WkStr.ToString();
                            break;

                        //----------------------------------------------------------------------
                        // ◇　以外はエラー
                        //----------------------------------------------------------------------
                        default:
                            return "";
                    }
                }

                //-----------------------------------------------------------------------------
                // ■ ７桁入力の場合（和暦記号＋年月日）の場合で西暦年代の場合、変換
                //  　　和暦記号が[8:1800年代][9:1900年代][0:2000年代]
                //-----------------------------------------------------------------------------
                if(lstrInDateValue.Length == 7)
                {
                    WkStr.Remove(0, WkStr.Length);
                    switch(lstrInDateValue.Substring(0, 1))
                    {
                        case "8":                   // [8:1800年代]
                            WkStr.Append("18");
                            WkStr.Append(lstrInDateValue.Substring(1));   // [18YYMMDD]へ
                            lstrInDateValue = WkStr.ToString();
                            break;
                        case "9":                   // [9:1900年代]
                            WkStr.Append("19");
                            WkStr.Append(lstrInDateValue.Substring(1));   // [19YYMMDD]へ
                            lstrInDateValue = WkStr.ToString();
                            break;
                        case "0":                   // [0:2000年代]
                            WkStr.Append("20");
                            WkStr.Append(lstrInDateValue.Substring(1));   // [20YYMMDD]へ
                            lstrInDateValue = WkStr.ToString();
                            break;
                    }
                }

                //-----------------------------------------------------------------------------
                // ■ 元号NOとと年月へ分割
                //-----------------------------------------------------------------------------
                lstrReki = "";                                          // 対象歴クリア
                switch(lstrInDateValue.Length)
                {
                    case 7:
                        // [9YYMMDD]形式→歴＋[00YYMMDD]へ分割
                        lstrReki = Ans.AnsLeftB(lstrInDateValue, 1);           // 対象歴

                        WkStr.Remove(0, WkStr.Length);                          // [00YYMMDD]形式
                        WkStr.Append("00");
                        WkStr.Append(Ans.AnsMidB(lstrInDateValue, 1));
                        lstrInDateValue = WkStr.ToString();
                        break;

                    default:
                        // 以外、8桁の場合
                        int.TryParse(Ans.AnsMidB(lstrInDateValue, 0, 4), out lintYYYY);
                        if(lintYYYY < 100)
                        {   // 和暦入力
                            lstrReki = lstrDEF_Reki;                            // デフォルト歴セット

                        }
                        else
                        {   // 西暦入力
                            lstrReki = "";                                      // ブランク
                        }
                        break;
                }

                //-----------------------------------------------------------------------------
                // ■ 元号NOにより、該当年号配列NOインデックス取得
                //-----------------------------------------------------------------------------
                lblnWarekiFlg = false;                                  // 和暦判定フラグ(false:西暦) 
                lintSelectGengoCount = -1;
                switch(lstrReki)
                {
                    //-------------------------------------------------------------------------
                    // ◇ 和暦の場合
                    //-------------------------------------------------------------------------
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                        lblnWarekiFlg = true;                               // 和暦判定フラグ(和暦)

                        int.TryParse(lstrReki, out lintGengoIndex);       // 数値変換
                        for(int LoopCount = (lintGengoIndex - 1); LoopCount < 7; LoopCount++)
                        {
                            //和暦日付を年と月日に分割
                            lintwkWarekiYear = int.Parse(lstrInDateValue.Substring(0, 4));          // 00YY
                            lintwkWarekiMD = int.Parse(lstrInDateValue.Substring(4));             // MMDD

                            // 和暦年が、範囲（ 和暦年　< 年数　AND 和暦年 > 1）
                            if(lintwkWarekiYear < GengoInfo[LoopCount].CountYear && lintwkWarekiYear > 1)
                            {
                                lintSelectGengoCount = LoopCount;
                                break;
                            }
                            // 最終年であれば日付チェック ( 和暦年=年数 AND 和暦月日<= 終了月日 )
                            else if(lintwkWarekiYear == GengoInfo[LoopCount].CountYear &&
                                     lintwkWarekiMD <= GengoInfo[LoopCount].ToDate % 10000)
                            {
                                lintSelectGengoCount = LoopCount;
                                break;
                            }

                            // 初年であれば日付チェック ( 和暦年=1 AND 和暦月日>= 開始月日 )
                            else if(lintwkWarekiYear == 1 &&
                                     lintwkWarekiMD >= GengoInfo[LoopCount].FromDate % 10000)
                            {
                                lintSelectGengoCount = LoopCount;
                                break;
                            }

                            // 初年かつ開始日付以前なら前の元号を設定 ( 和暦年=1 AND 和暦月日< 開始日付 )
                            else if(lintwkWarekiYear == 1 &&
                                     lintwkWarekiMD < GengoInfo[LoopCount].FromDate % 10000)
                            {
                                //「大正」より処理
                                if(LoopCount > 0)
                                {
                                    lintSelectGengoCount = LoopCount - 1;
                                    break;
                                }
                            }
                            //範囲外であれば次の元号に変換して再処理
                            else
                            {
                                // 和暦年－年数　+ 1
                                int wkWarekiDiff = lintwkWarekiYear - GengoInfo[LoopCount].CountYear + 1;

                                WkStr.Remove(0, WkStr.Length);
                                WkStr.Append(wkWarekiDiff.ToString("0000"));        // 次年[00YY]
                                WkStr.Append(lintwkWarekiMD.ToString("0000"));          // 月日　
                                lstrInDateValue = WkStr.ToString();
                            }
                        }
                        break;

                    //-------------------------------------------------------------------------
                    // ◇ 西暦の場合
                    //-------------------------------------------------------------------------
                    default:
                        lblnWarekiFlg = false;                                          // 和暦判定フラグ(西暦)

                        int.TryParse(lstrInDateValue, out lintwkIntValue);                  // 1.数値変換
                        for(int LoopCount = 0; LoopCount < 7; LoopCount++)             // ０～６までの配列、７以降は年代配列
                        {
                            //入力年度に該当する元号を取得
                            if(lintwkIntValue >= GengoInfo[LoopCount].FromDate &&
                                lintwkIntValue <= GengoInfo[LoopCount].ToDate)
                            {
                                lintSelectGengoCount = LoopCount;
                                break;
                            }
                        }
                        break;
                }

                //-----------------------------------------------------------------------------
                // ■ 元号配列に該当情報がない場合、日付と判断しないエラー
                //-----------------------------------------------------------------------------
                if(lintSelectGengoCount == -1)
                {
                    return "";
                }

                //-----------------------------------------------------------------------------
                // ■ 西暦年/和暦年/月/日　に分割
                //-----------------------------------------------------------------------------
                lintwkAddYear = int.Parse(GengoInfo[lintSelectGengoCount].FromDate.ToString("00000000").Substring(0, 4));

                // 西暦の場合
                if(lblnWarekiFlg == false)
                {
                    lintwkSeirekiYear = int.Parse(lstrInDateValue.Substring(0, 4));
                    lintwkWarekiYear = lintwkSeirekiYear - lintwkAddYear + 1;

                    lstrwkMM = lstrInDateValue.Substring(4, 2);
                    lstrwkDD = lstrInDateValue.Substring(6, 2);

                }
                // 和暦の場合
                else
                {
                    lintwkWarekiYear = int.Parse(lstrInDateValue.Substring(0, 4));
                    lintwkSeirekiYear = lintwkAddYear + lintwkWarekiYear - 1;

                    lstrwkMM = lstrInDateValue.Substring(4, 2);
                    lstrwkDD = lstrInDateValue.Substring(6, 2);
                }

                //-----------------------------------------------------------------------------
                // ■ バリデイトチェック
                //-----------------------------------------------------------------------------
                if(DateTime.TryParse(lintwkSeirekiYear.ToString() + "/" +
                                        lstrwkMM.ToString() + "/" +
                                        lstrwkDD.ToString(), out ldteRet) == false)
                {
                    // 日付エラー
                    return "";
                }

                //-----------------------------------------------------------------------------
                // ■ 指定出力形式にフォーマット
                //-----------------------------------------------------------------------------
                ReturnValue = "";
                switch(pintretFormatType)
                {
                    case 0:
                        //西暦
                        WkStr.Remove(0, WkStr.Length);

                        WkStr.Append(lintwkSeirekiYear.ToString("0000"));

                        //区切りの有無
                        if(pstrseparateChar != "")
                        {
                            WkStr.Append(pstrseparateChar);
                            WkStr.Append(lstrwkMM);
                            WkStr.Append(pstrseparateChar);
                            WkStr.Append(lstrwkDD);
                        }
                        else
                        {
                            WkStr.Append(lstrwkMM);
                            WkStr.Append(lstrwkDD);
                        }

                        ReturnValue = WkStr.ToString();
                        break;

                    case 1:
                        //和暦(平成～)
                        WkStr.Remove(0, WkStr.Length);

                        WkStr.Append(GengoInfo[lintSelectGengoCount].FullName);
                        WkStr.Append(lintwkWarekiYear.ToString("00"));

                        //区切りの有無
                        if(pstrseparateChar != "")
                        {
                            WkStr.Append(pstrseparateChar);
                            WkStr.Append(lstrwkMM);
                            WkStr.Append(pstrseparateChar);
                            WkStr.Append(lstrwkDD);
                        }
                        else
                        {
                            WkStr.Append(lstrwkMM);
                            WkStr.Append(lstrwkDD);
                        }

                        ReturnValue = WkStr.ToString();
                        break;

                    case 2:
                        //和暦(平～)
                        WkStr.Remove(0, WkStr.Length);

                        WkStr.Append(GengoInfo[lintSelectGengoCount].OmissionName);
                        WkStr.Append(lintwkWarekiYear.ToString("00"));

                        //区切りの有無
                        if(pstrseparateChar != "")
                        {
                            WkStr.Append(pstrseparateChar);
                            WkStr.Append(lstrwkMM);
                            WkStr.Append(pstrseparateChar);
                            WkStr.Append(lstrwkDD);
                        }
                        else
                        {
                            WkStr.Append(lstrwkMM);
                            WkStr.Append(lstrwkDD);
                        }

                        ReturnValue = WkStr.ToString();
                        break;

                    case 3:
                        //和暦(H～)
                        WkStr.Remove(0, WkStr.Length);

                        WkStr.Append(GengoInfo[lintSelectGengoCount].AlphabetName);
                        WkStr.Append(lintwkWarekiYear.ToString("00"));

                        //区切りの有無
                        if(pstrseparateChar != "")
                        {
                            WkStr.Append(pstrseparateChar);
                            WkStr.Append(lstrwkMM);
                            WkStr.Append(pstrseparateChar);
                            WkStr.Append(lstrwkDD);
                        }
                        else
                        {
                            WkStr.Append(lstrwkMM);
                            WkStr.Append(lstrwkDD);
                        }

                        ReturnValue = WkStr.ToString();
                        break;

                    case 4:
                        //和暦(平成YY年MM月DD日)
                        WkStr.Remove(0, WkStr.Length);

                        WkStr.Append(GengoInfo[lintSelectGengoCount].FullName);     // 平成
                        WkStr.Append(lintwkWarekiYear.ToString("00"));              // YY
                        WkStr.Append("年");
                        WkStr.Append(lstrwkMM);
                        WkStr.Append("月");
                        WkStr.Append(lstrwkDD);
                        WkStr.Append("日");
                        ReturnValue = WkStr.ToString();
                        break;

                    default:
                        ReturnValue = "";
                        break;
                }

                return ReturnValue;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 日付変換（西暦変換、区切り文字なし）
        /// </summary>
        /// <param name="pstrinDate">入力日付</param>
        /// <returns>日付文字列</returns>
        public string ConvDate(string pstrinDate)
        {
            return ConvDate(pstrinDate, 0, "", mstrSyoriYMD);
        }

        /// <summary>
        /// 日付変換
        /// </summary>
        /// <param name="pstrinDate">入力日付</param>
        /// <param name="pintretFormatType">変換区分(0:西暦 1:和暦 2:和暦略 3:和暦英略 4:年月日付き和暦)</param>
        /// <returns>日付文字列</returns>
        public string ConvDate(string pstrinDate, int pintretFormatType)
        {
            return ConvDate(pstrinDate, pintretFormatType, "", mstrSyoriYMD);
        }

        /// <summary>
        /// 日付変換（西暦変換）
        /// </summary>
        /// <param name="pstrinDate">入力日付</param>
        /// <param name="pstrseparateChar">区切り文字</param>
        /// <returns>日付文字列</returns>
        public string ConvDate(string pstrinDate, string pstrseparateChar)
        {
            return ConvDate(pstrinDate, 0, pstrseparateChar, mstrSyoriYMD);
        }

        /// <summary>
        /// 日付変換
        /// </summary>
        /// <param name="pstrinDate">入力日付</param>
        /// <param name="pintretFormatType">変換区分(0:西暦 1:和暦 2:和暦略 3:和暦英略 4:年月日付き和暦)</param>
        /// <param name="pstrseparateChar">区切り文字(変換区分が4のときは無効)</param>
        /// <returns>日付文字列</returns>
        public string ConvDate(string pstrinDate, int pintretFormatType, string pstrseparateChar)
        {
            return ConvDate(pstrinDate, pintretFormatType, pstrseparateChar, mstrSyoriYMD);
        }
        #endregion

        #region 元号情報該当No　取得処理
        ///
        /// <summary> 機能　　　: 元号情報該当No　取得処理                      </summary>
        /// 
        /// <remark>  機能説明　: 元号情報該当No　取得処理                    </remark>
        //
        //*************************************************************************************
        public int GetGengo(string pstrGengoAlp)
        {
            // 元号(ｱﾙﾌｧﾍﾞｯﾄ)より該当NOを取得（１～）
            for(int intIndex = 0; intIndex < 10; intIndex++)
            {
                // 元号(ｱﾙﾌｧﾍﾞｯﾄ)と同一の場合
                if(GengoInfo[intIndex].AlphabetName.Equals(pstrGengoAlp))
                {
                    return (intIndex + 1);
                }
            }
            // 存在しない場合,0
            return 0;
        }
        #endregion

        #region　IsDate メソッド
        /// -----------------------------------------------------------------------------------------
        /// <summary>
        ///     指定文字列(和暦)の日付チェック</summary>
        /// <param name="pstrDateW">
        ///     チェック文字列</param>
        /// <returns>
        ///     指定文字列の日付チェックを行います</returns>
        /// -----------------------------------------------------------------------------------------
        public bool IsDateW(string pstrDateW)
        {
            try
            {
                string lstrYMD_WK;                  // 文字列変換用

                // 1.ブランクチェック
                if(pstrDateW.Trim().Length == 0)
                {
                    MessageBox.Show("未入力です。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                // 2.変換チェック(0:西暦変換へ)
                lstrYMD_WK = ConvDate(pstrDateW, 0);
                if(lstrYMD_WK.Length == 0)
                {
                    MessageBox.Show("日付が正しくありません。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                // チェックＯＫ
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
  
        /// <summary>
        /// 英字元号取得
        /// </summary>
        /// <param name="date">日付</param>
        /// <returns>英字元号(H：平成etc)</returns>
        public static string GetAlphabetEra(DateTime date)
        {
            System.Globalization.DateTimeFormatInfo formatInfo = null;
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("ja-JP");

            formatInfo = culture.DateTimeFormat;
            formatInfo.Calendar = new System.Globalization.JapaneseCalendar();

            int era = formatInfo.Calendar.GetEra(DateTime.Now);
            string eraText = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < eraText.Length; i++)
            {
                if (formatInfo.GetEra(eraText[i].ToString()) == era)
                    return eraText[i].ToString();
            }

            return "H";
        }
    }
}
