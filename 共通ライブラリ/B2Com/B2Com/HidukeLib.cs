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
    /// <summary>
    /// 日付処理ライブラリ
    /// </summary>
    public class HidukeLib
    {
        /// <summary>
        /// 元号変換情報
        /// </summary>
        private struct GengoHenkanJoho
        {
            /// <summary>元号</summary>
            public string Gengo;
            /// <summary>英字元号(英字1文字)</summary>
            public string EijiGengo;
            /// <summary>省略元号(漢字1文字)</summary>
            public string ShoryakuGengo;
            /// <summary>元号の開始年月日</summary>
            public int KaishiNegappi;
            /// <summary>元号の終了年月日</summary>
            public int ShuryoNengappi;
            /// <summary>年数</summary>
            public int Nensu;
        }
        /// <summary>元号変換情報リスト</summary>
        private GengoHenkanJoho[] gengoHenkanJohoList = new GengoHenkanJoho[11];

        /// <summary>基準年月日</summary>
        public string KijunNengappi { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="iniFileMei">iniファイル名（フルパス）</param>
        /// <remarks>iniファイル名が空のときは明治～平成までの変換になります</remarks>
        public HidukeLib(string iniFileMei)
        {
            int wkIntValue;
            string gengoJoho = string.Empty;

            if (0 < iniFileMei.Length)
            {
                IniFileControler iniFile = new IniFileControler(iniFileMei);
                gengoJoho = iniFile.GetIniString("元号", "情報");
            }
            if (gengoJoho.Length == 0)
            {
                gengoJoho = "04明治M明18680908191207290045大正T大19120730192612240015昭和S昭19261225198901070064平成H平19890108999999990099　　 　99999999999999999999　　 　99999999999999999999　　 　99999999999999999999西暦8西18000101189912310099西暦9西19000101199912310099西暦0西20000101299912310099";
            }

            this.KijunNengappi = string.Empty;

            for(int LoopCount = 0; LoopCount < 10; LoopCount++)
            {
                this.gengoHenkanJohoList[LoopCount].Gengo = Ans.AnsMidB(gengoJoho, LoopCount * 27 + 2, 4);
                this.gengoHenkanJohoList[LoopCount].EijiGengo = Ans.AnsMidB(gengoJoho, LoopCount * 27 + 6, 1);
                this.gengoHenkanJohoList[LoopCount].ShoryakuGengo = Ans.AnsMidB(gengoJoho, LoopCount * 27 + 7, 2);


                if(int.TryParse(Ans.AnsMidB(gengoJoho, LoopCount * 27 + 9, 8), out wkIntValue) == true)
                {
                    this.gengoHenkanJohoList[LoopCount].KaishiNegappi = wkIntValue;
                }

                if(int.TryParse(Ans.AnsMidB(gengoJoho, LoopCount * 27 + 17, 8), out wkIntValue) == true)
                {
                    this.gengoHenkanJohoList[LoopCount].ShuryoNengappi = wkIntValue;
                }

                if(int.TryParse(Ans.AnsMidB(gengoJoho, LoopCount * 27 + 25, 4), out wkIntValue) == true)
                {
                    this.gengoHenkanJohoList[LoopCount].Nensu = wkIntValue;
                }
            }

            this.gengoHenkanJohoList[10].Gengo = "ERR ";
            this.gengoHenkanJohoList[10].EijiGengo = "E";
            this.gengoHenkanJohoList[10].ShoryakuGengo = "ER";
            this.gengoHenkanJohoList[10].KaishiNegappi = 0;
            this.gengoHenkanJohoList[10].ShuryoNengappi = 99999999;
            this.gengoHenkanJohoList[10].Nensu = 9999;
        }

        #region  日付の変換
        /// <summary>日付の変換</summary>
        /// <param name="nyuryokuHiduke">入力日付(有効日付であれば和暦西暦両方可)</param> 
        /// <param name="henkanKubun">変換区分(0:西暦 1:和暦 2:和暦略 3:和暦英略 4:年月日付き和暦)</param> 
        /// <param name="kugiriMoji">区切り文字</param>
        /// <param name="kijunShiteiNengappi">基準指定年月日(ﾌﾞﾗﾝｸの場合、ｼｽﾃﾑ日付)</param>
        public string ConvDate(string nyuryokuHiduke, int henkanKubun, string kugiriMoji, string kijunShiteiNengappi)
        {
            // 変換用
            StringBuilder wkStr = new StringBuilder();
            // 対象年月日
            string taishoNengappi;

            // デフォルト歴No(1～9、0)
            string defaultWarekiNo;
            // 基準年月日
            string kijunNengappi;

            // 対象和暦No
            string taishoWarekiNo;

            // 年WK
            int nenWork;
            // 元号略取得用
            string gengoRyakusho;
            // 元号配列該当NO
            int gengoIndex;
            // 年月日WK
            string workNengappi;
            // 和暦判定フラグ(true:和暦、false:西暦)
            Boolean warekiFlag;

            // 日付チェック用戻値
            DateTime hizukeCheck;

            // 和暦年用
            int warekiNen;
            // 和暦月日用
            int warekiTsukihi;
            // 西暦年用
            int seirekiNen;
            // 和暦開始年(西暦)
            int warekiKaishiNen;
            // 変換後月
            string henkangoTsuki;
            // 変換後日
            string henkangoHi;

            // 数値変換年月日
            int sutiHenkanNengappi;
            // 元号変換情報リストインデックス
            int gengoHenkanJohoListIndex;

            // 戻値設定用
            string henkangoNengappi;

            try
            {
                // 基準年月日を設定し、元号変換情報リストから基準年月日に該当するデフォルト和暦Noを取得
                if (kijunShiteiNengappi.Length == 0)
                {
                    kijunNengappi = DateTime.Today.ToString("yyyyMMdd");
                }
                else
                {
                    kijunNengappi = kijunShiteiNengappi;
                }

                defaultWarekiNo = "0";
                int.TryParse(kijunNengappi, out sutiHenkanNengappi);
                for (int LoopCount = 0; LoopCount < 7; LoopCount++)
                {
                    if (sutiHenkanNengappi >= this.gengoHenkanJohoList[LoopCount].KaishiNegappi &&
                        sutiHenkanNengappi <= this.gengoHenkanJohoList[LoopCount].ShuryoNengappi)
                    {
                        int lintReki = LoopCount + 1;
                        defaultWarekiNo = lintReki.ToString();
                        break;
                    }
                }

                // 入力日付が空の時は基準年月日を変換します
                if (nyuryokuHiduke != "")
                {
                    taishoNengappi = nyuryokuHiduke.ToUpper();
                }
                else
                {
                    taishoNengappi = kijunNengappi;
                }

                // 区切り文字の削除
                taishoNengappi = taishoNengappi.Replace(" ", "");
                taishoNengappi = taishoNengappi.Replace("/", "");
                taishoNengappi = taishoNengappi.Replace("-", "");
                taishoNengappi = taishoNengappi.Replace(".", "");

                if(taishoNengappi.Length == 0)
                {
                    return "";
                }

                // 和暦の元号が数値以外の時は和暦元号を元号Noに変換する
                if(int.TryParse(taishoNengappi, out sutiHenkanNengappi) == false)
                {
                    gengoRyakusho = taishoNengappi.Substring(0, 1);
                    workNengappi = Ans.AnsMidB(taishoNengappi, 1);

                    // 元号はアルファベット以外はエラーとする
                    if(Char.IsLetter(gengoRyakusho, 0) == false)
                    {
                        return "";
                    }

                    // 年月日は6桁数値以外はエラーとする
                    if(workNengappi.Length != 6)
                    {
                        return "";
                    }
                    if(int.TryParse(workNengappi, out sutiHenkanNengappi) == false)
                    {
                        return "";
                    }

                    // 元号Noへ変換出来ないときはエラーとする
                    gengoIndex = GetGengo(gengoRyakusho);
                    if(gengoIndex == 0)
                    {
                        return "";
                    }

                    wkStr.Remove(0, wkStr.Length);
                    wkStr.Append(gengoIndex.ToString("0"));
                    wkStr.Append(workNengappi);
                    taishoNengappi = wkStr.ToString();

                }
                else
                {
                    // 桁数で西暦、和暦を判定し元号、年月日が足りない分は基準年月日から補完する
                    wkStr.Remove(0, wkStr.Length);
                    switch(taishoNengappi.Length)
                    {
                        case 8:
                            // 8桁の時は西暦年月日になるため何もしない
                            break;
                        case 7:
                            // 7桁の時は元号No付き和暦年月日または西暦No付き西暦年下2桁月日になるため何もしない
                            break;
                        case 6:
                        case 5:
                            // 6、5桁の時は西暦年下2桁として頭に0を付けて西暦8桁にする
                            wkStr.Append(taishoNengappi.PadLeft(8, '0'));
                            taishoNengappi = wkStr.ToString();
                            break;
                        case 4:
                        case 3:
                            // 4、3桁の時は月日だけとして基準年月日から年を付けて西暦8桁にする
                            wkStr.Append(kijunNengappi.Substring(0, 4));
                            wkStr.Append(taishoNengappi.PadLeft(4, '0'));

                            taishoNengappi = wkStr.ToString();
                            break;
                        case 2:
                        case 1:
                            // 2、1桁の時は日だけとして基準年月日から年月を付けて西暦8桁にする
                            wkStr.Append(kijunNengappi.Substring(0, 6));
                            wkStr.Append(taishoNengappi.PadLeft(2, '0'));

                            taishoNengappi = wkStr.ToString();
                            break;

                        default:
                            // 上記以外の時はエラー
                            return "";
                    }
                }

                // 7桁入力で西暦No付き西暦年下2桁月日のときは西暦年月日に変換
                // 西暦No [8:1800年代][9:1900年代][0:2000年代]
                if(taishoNengappi.Length == 7)
                {
                    wkStr.Remove(0, wkStr.Length);
                    switch(taishoNengappi.Substring(0, 1))
                    {
                        case "8":
                            wkStr.Append("18");
                            wkStr.Append(taishoNengappi.Substring(1));
                            taishoNengappi = wkStr.ToString();
                            break;
                        case "9":
                            wkStr.Append("19");
                            wkStr.Append(taishoNengappi.Substring(1));
                            taishoNengappi = wkStr.ToString();
                            break;
                        case "0":
                            wkStr.Append("20");
                            wkStr.Append(taishoNengappi.Substring(1));
                            taishoNengappi = wkStr.ToString();
                            break;
                    }
                }

                // 7桁の時は元号No付き和暦年月日を元号Noと和暦年月日(頭0埋め8桁)に分ける
                taishoWarekiNo = "";
                switch(taishoNengappi.Length)
                {
                    case 7:
                        taishoWarekiNo = Ans.AnsLeftB(taishoNengappi, 1);

                        wkStr.Remove(0, wkStr.Length);
                        wkStr.Append("00");
                        wkStr.Append(Ans.AnsMidB(taishoNengappi, 1));
                        taishoNengappi = wkStr.ToString();
                        break;

                    default:
                        // 年が100未満のときは元号なし和暦年月日として基準年月日の和暦Noとする
                        int.TryParse(Ans.AnsMidB(taishoNengappi, 0, 4), out nenWork);
                        if(nenWork < 100)
                        {
                            taishoWarekiNo = defaultWarekiNo;
                        }
                        else
                        {
                            taishoWarekiNo = "";
                        }
                        break;
                }

                // 元号Noが7以下の時は元号Noから元号変換情報リストのインデックスを取得する
                // それ以外の時は西暦年月日から元号変換情報リストのインデックスを取得する
                warekiFlag = false;
                gengoHenkanJohoListIndex = -1;
                switch(taishoWarekiNo)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                        warekiFlag = true;

                        int.TryParse(taishoWarekiNo, out gengoIndex);
                        for(int LoopCount = (gengoIndex - 1); LoopCount < 7; LoopCount++)
                        {
                            warekiNen = int.Parse(taishoNengappi.Substring(0, 4));
                            warekiTsukihi = int.Parse(taishoNengappi.Substring(4));

                            if (warekiNen < this.gengoHenkanJohoList[LoopCount].Nensu && warekiNen > 1)
                            {
                                gengoHenkanJohoListIndex = LoopCount;
                                break;
                            }
                            else if (warekiNen == this.gengoHenkanJohoList[LoopCount].Nensu &&
                                     warekiTsukihi <= this.gengoHenkanJohoList[LoopCount].ShuryoNengappi % 10000)
                            {
                                // 和暦年が同じで終了月日以下のとき
                                gengoHenkanJohoListIndex = LoopCount;
                                break;
                            }
                            else if(warekiNen == 1 &&
                                     warekiTsukihi >= this.gengoHenkanJohoList[LoopCount].KaishiNegappi % 10000)
                            {
                                // 和暦年が1年目で開始月日以上のとき
                                gengoHenkanJohoListIndex = LoopCount;
                                break;
                            }
                            else if(warekiNen == 1 &&
                                     warekiTsukihi < this.gengoHenkanJohoList[LoopCount].KaishiNegappi % 10000)
                            {
                                // 和暦年が1年目で開始月日未満のときは前の元号
                                if (LoopCount > 0)
                                {
                                    gengoHenkanJohoListIndex = LoopCount - 1;
                                    break;
                                }
                            }
                            else
                            {
                                int wkWarekiDiff = warekiNen - this.gengoHenkanJohoList[LoopCount].Nensu + 1;

                                wkStr.Remove(0, wkStr.Length);
                                wkStr.Append(wkWarekiDiff.ToString("0000"));
                                wkStr.Append(warekiTsukihi.ToString("0000"));
                                taishoNengappi = wkStr.ToString();
                            }
                        }
                        break;

                    default:
                        warekiFlag = false;

                        int.TryParse(taishoNengappi, out sutiHenkanNengappi);
                        for(int LoopCount = 0; LoopCount < 7; LoopCount++)
                        {
                            if (sutiHenkanNengappi >= this.gengoHenkanJohoList[LoopCount].KaishiNegappi &&
                                sutiHenkanNengappi <= this.gengoHenkanJohoList[LoopCount].ShuryoNengappi)
                            {
                                gengoHenkanJohoListIndex = LoopCount;
                                break;
                            }
                        }
                        break;
                }

                // 元号変換情報リストに該当情報がない場合、日付以外としてエラーにする
                if(gengoHenkanJohoListIndex == -1)
                {
                    return "";
                }

                // 年月日を西暦年、和暦年、月、日に分割する
                warekiKaishiNen = int.Parse(this.gengoHenkanJohoList[gengoHenkanJohoListIndex].KaishiNegappi.ToString("00000000").Substring(0, 4));
                if(warekiFlag == false)
                {
                    // 西暦の場合
                    seirekiNen = int.Parse(taishoNengappi.Substring(0, 4));
                    warekiNen = seirekiNen - warekiKaishiNen + 1;

                    henkangoTsuki = taishoNengappi.Substring(4, 2);
                    henkangoHi = taishoNengappi.Substring(6, 2);
                }
                else
                {
                    // 和暦の場合
                    warekiNen = int.Parse(taishoNengappi.Substring(0, 4));
                    seirekiNen = warekiKaishiNen + warekiNen - 1;

                    henkangoTsuki = taishoNengappi.Substring(4, 2);
                    henkangoHi = taishoNengappi.Substring(6, 2);
                }

                // 年月日が正しいかどうか日付変換してチェックする
                if(DateTime.TryParse(seirekiNen.ToString() + "/" +
                                        henkangoTsuki.ToString() + "/" +
                                        henkangoHi.ToString(), out hizukeCheck) == false)
                {
                    return "";
                }

                // 引数で指定された変換区分の形式に編集する
                henkangoNengappi = "";
                switch(henkanKubun)
                {
                    case 0:
                        // 西暦
                        wkStr.Remove(0, wkStr.Length);
                        wkStr.Append(seirekiNen.ToString("0000"));
                        if(kugiriMoji != "")
                        {
                            wkStr.Append(kugiriMoji);
                            wkStr.Append(henkangoTsuki);
                            wkStr.Append(kugiriMoji);
                            wkStr.Append(henkangoHi);
                        }
                        else
                        {
                            wkStr.Append(henkangoTsuki);
                            wkStr.Append(henkangoHi);
                        }
                        henkangoNengappi = wkStr.ToString();
                        break;

                    case 1:
                        // 和暦(平成～)
                        wkStr.Remove(0, wkStr.Length);
                        wkStr.Append(this.gengoHenkanJohoList[gengoHenkanJohoListIndex].Gengo);
                        wkStr.Append(warekiNen.ToString("00"));
                        if(kugiriMoji != "")
                        {
                            wkStr.Append(kugiriMoji);
                            wkStr.Append(henkangoTsuki);
                            wkStr.Append(kugiriMoji);
                            wkStr.Append(henkangoHi);
                        }
                        else
                        {
                            wkStr.Append(henkangoTsuki);
                            wkStr.Append(henkangoHi);
                        }
                        henkangoNengappi = wkStr.ToString();
                        break;

                    case 2:
                        // 和暦(平～)
                        wkStr.Remove(0, wkStr.Length);
                        wkStr.Append(this.gengoHenkanJohoList[gengoHenkanJohoListIndex].ShoryakuGengo);
                        wkStr.Append(warekiNen.ToString("00"));
                        if(kugiriMoji != "")
                        {
                            wkStr.Append(kugiriMoji);
                            wkStr.Append(henkangoTsuki);
                            wkStr.Append(kugiriMoji);
                            wkStr.Append(henkangoHi);
                        }
                        else
                        {
                            wkStr.Append(henkangoTsuki);
                            wkStr.Append(henkangoHi);
                        }
                        henkangoNengappi = wkStr.ToString();
                        break;

                    case 3:
                        // 和暦(H～)
                        wkStr.Remove(0, wkStr.Length);
                        wkStr.Append(this.gengoHenkanJohoList[gengoHenkanJohoListIndex].EijiGengo);
                        wkStr.Append(warekiNen.ToString("00"));
                        if(kugiriMoji != "")
                        {
                            wkStr.Append(kugiriMoji);
                            wkStr.Append(henkangoTsuki);
                            wkStr.Append(kugiriMoji);
                            wkStr.Append(henkangoHi);
                        }
                        else
                        {
                            wkStr.Append(henkangoTsuki);
                            wkStr.Append(henkangoHi);
                        }
                        henkangoNengappi = wkStr.ToString();
                        break;

                    case 4:
                        // 和暦(平成YY年MM月DD日)
                        wkStr.Remove(0, wkStr.Length);
                        wkStr.Append(this.gengoHenkanJohoList[gengoHenkanJohoListIndex].Gengo);     // 平成
                        wkStr.Append(warekiNen.ToString("00"));              // YY
                        wkStr.Append("年");
                        wkStr.Append(henkangoTsuki);
                        wkStr.Append("月");
                        wkStr.Append(henkangoHi);
                        wkStr.Append("日");
                        henkangoNengappi = wkStr.ToString();
                        break;

                    default:
                        henkangoNengappi = "";
                        break;
                }

                return henkangoNengappi;
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
            return ConvDate(pstrinDate, 0, "", this.KijunNengappi);
        }

        /// <summary>
        /// 日付変換
        /// </summary>
        /// <param name="pstrinDate">入力日付</param>
        /// <param name="pintretFormatType">変換区分(0:西暦 1:和暦 2:和暦略 3:和暦英略 4:年月日付き和暦)</param>
        /// <returns>日付文字列</returns>
        public string ConvDate(string pstrinDate, int pintretFormatType)
        {
            return ConvDate(pstrinDate, pintretFormatType, "", this.KijunNengappi);
        }

        /// <summary>
        /// 日付変換（西暦変換）
        /// </summary>
        /// <param name="pstrinDate">入力日付</param>
        /// <param name="pstrseparateChar">区切り文字</param>
        /// <returns>日付文字列</returns>
        public string ConvDate(string pstrinDate, string pstrseparateChar)
        {
            return ConvDate(pstrinDate, 0, pstrseparateChar, this.KijunNengappi);
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
            return ConvDate(pstrinDate, pintretFormatType, pstrseparateChar, this.KijunNengappi);
        }
        #endregion

        /// <summary>元号情報該当No取得</summary>
        /// <param name="pstrGengoAlp">英字元号</param>
        /// <returns>1以上:元号情報へのインデックス 0:該当無し</returns>
        public int GetGengo(string pstrGengoAlp)
        {
            // 元号(ｱﾙﾌｧﾍﾞｯﾄ)より該当NOを取得（１～）
            for(int intIndex = 0; intIndex < 10; intIndex++)
            {
                // 元号(ｱﾙﾌｧﾍﾞｯﾄ)と同一の場合
                if (this.gengoHenkanJohoList[intIndex].EijiGengo.Equals(pstrGengoAlp))
                {
                    return (intIndex + 1);
                }
            }
            // 存在しない場合,0
            return 0;
        }

        /// <summary>
        /// 指定文字列(和暦)の日付チェック
        /// </summary>
        /// <param name="pstrDateW">日付文字列</param>
        /// <returns>true:正しい日付 false:不正な日付</returns>
        /// <remark>指定文字列の日付チェックを行います</remark>
        public bool IsDateW(string pstrDateW)
        {
            try
            {
                string lstrYMD_WK;

                if(pstrDateW.Trim().Length == 0)
                {
                    MessageBox.Show("未入力です。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                lstrYMD_WK = ConvDate(pstrDateW, 0);
                if(lstrYMD_WK.Length == 0)
                {
                    MessageBox.Show("日付が正しくありません。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
  
        /// <summary>
        /// 英字元号取得
        /// </summary>
        /// <param name="date">英字元号を取得するDateTime</param>
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
