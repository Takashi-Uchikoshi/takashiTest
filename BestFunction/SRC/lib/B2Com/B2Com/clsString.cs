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
    /// 指定された文字数分の文字列型 (String) を返します。
    /// </summary>
    public class Str
    {

        #region　Spaces メソッド
        /// -----------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したバイト数分のスペース文字列を返します。</summary>
        /// <param name="iByteSize">
        ///     スペースを埋めるバイト数。</param>
        /// <returns>
        ///     指定されたバイト数分のスペース文字列。</returns>
        /// -----------------------------------------------------------------------------------------
        public static string Spaces(int iByteSize)
        {
            string stString = "";
            return stString.PadRight(iByteSize);
        }
        #endregion

        #region　FileStrings メソッド
        /// -----------------------------------------------------------------------------------------
        /// <summary>
        ///     指定したファイルを行単位の配列にします。</summary>
        /// <param name="stFilename">
        ///     読み込むファイル</param>
        /// <returns>
        ///     行単位の配列を返します。</returns>
        /// -----------------------------------------------------------------------------------------
        public static string[] FileStrings(string stFilename)
        {
            System.IO.FileStream fs = new System.IO.FileStream(stFilename, System.IO.FileMode.Open);
            System.IO.StreamReader sr = new System.IO.StreamReader(fs, System.Text.Encoding.GetEncoding(932));
            string strTextAll = sr.ReadToEnd();
            sr.Close();

            //string.Splitで分割する
            return strTextAll.Replace("\r\n", "\n").Split('\n');
        }
        #endregion

        #region　StringBukatuB メソッド
        /// -----------------------------------------------------------------------------------------
        /// <summary>
        ///     指定した文字列を指定バイト数にて分割します。</summary>
        /// <param name="pstrMoji">
        ///     指定文字列(半角混在可)</param>
        /// <param name="pintLengthB">
        ///     指定バイト文字数</param> 
        /// <param name="pblnDelNewLine">
        ///     改行コード分割フラグ(TRUE:分割あり、False：分割しない)</param> 
        /// <returns>
        ///     分割配列にて戻します。分解できなかった場合は配列数1で空白文字を返します。</returns>
        /// -----------------------------------------------------------------------------------------
        public static string[] StringBukatuB(string pstrMoji, int pintLengthB, bool pblnDelNewLine)
        {
            List<string> lstrRet = new List<string>();              // 戻値用   

            string[] lstrBunkatuWK;                                 // 改行分割文字列WK
            string lstrEditText;
            int lintCutByteLen;                                     // 切り取り文字バイト数


            //---------------------------------------------------------------------------------------
            // ■ 戻値文字列クリア
            //---------------------------------------------------------------------------------------
            lstrRet.Clear();

            //---------------------------------------------------------------------------------------
            // ■ 該当文字を代入
            //---------------------------------------------------------------------------------------
            lstrEditText = pstrMoji;

            //---------------------------------------------------------------------------------------
            // ■ 文字長が0の場合、１文字空白を戻します
            //---------------------------------------------------------------------------------------
            if (lstrEditText.Length == 0)
            {
                return (new string[1] { " " });
            }

            //---------------------------------------------------------------------------------------
            // ■ 改行コードがある場合、一旦改行コードにて分割します        ※引数に分割指定がある場合のみ
            //---------------------------------------------------------------------------------------
            if (pblnDelNewLine == true)
            {
                lstrBunkatuWK = lstrEditText.Replace("\r\n", "\n").Split('\n');     // 改行ｺｰﾄﾞは[\n]で統一
            }
            else
            {
                lstrBunkatuWK = new string[1];
                lstrBunkatuWK[0] = lstrEditText;
            }

            //---------------------------------------------------------------------------------------
            // ■ 改行分割後文字列を、指定文字列で分割します
            //---------------------------------------------------------------------------------------
            for (int lintIndex = lstrBunkatuWK.GetLowerBound(0); lintIndex <= lstrBunkatuWK.GetUpperBound(0); lintIndex++)
            {
                while (lstrBunkatuWK[lintIndex].Length > 0)
                {
                    // 文字列追加：指定バイトで分割
                    lstrRet.Add(Ans.AnsLeftC(lstrBunkatuWK[lintIndex], pintLengthB, out lintCutByteLen));

                    // 文字列再設定
                    if (Ans.AnsLenB(lstrBunkatuWK[lintIndex]) <= lintCutByteLen)
                    {
                        lstrBunkatuWK[lintIndex] = "";
                    }
                    else
                    {
                        lstrBunkatuWK[lintIndex] = Ans.AnsMidB(lstrBunkatuWK[lintIndex], lintCutByteLen);
                    }
                }
            }

            return lstrRet.ToArray();
        }
        #endregion

        #region　DelNewLine メソッド
        /// -----------------------------------------------------------------------------------------
        /// <summary>
        ///     指定した文字列の改行コードを削除します。</summary>
        /// <param name="pstrMoji">
        ///     指定文字列(半角混在可)</param>
        /// <returns>
        ///     指定文字列から改行コードを削除した文字列を戻します。</returns>
        /// -----------------------------------------------------------------------------------------
        public static string DelNewLine(string pstrMoji)
        {
            string lstrEditText;


            //---------------------------------------------------------------------------------------
            // ■ 該当文字を代入
            //---------------------------------------------------------------------------------------
            lstrEditText = pstrMoji;

            //---------------------------------------------------------------------------------------
            // ■ 改行を削除
            //---------------------------------------------------------------------------------------
            lstrEditText = lstrEditText.Replace("\r\n", "\n");          // 一旦[\n]へ
            lstrEditText = lstrEditText.Replace("\n", "");              // [\n]を全て削除


            return lstrEditText;
        }
        #endregion
    }

    /// <summary>
    /// 指定された文字数分の文字列型 (String) を返します。
    /// </summary>
    public class Ans
    {
        /// <summary>
        /// バイト数をカウントするために使用するShift_JISエンコード</summary>
        private static Encoding enc = System.Text.Encoding.GetEncoding("Shift_JIS");

        #region　AnsLenB メソッド
        /// -----------------------------------------------------------------------------------------
        /// <summary>
        ///     文字列のバイト長を返します。</summary>
        /// <param name="str">
        ///     バイト長を取り出す元になる文字列。</param>
        /// <returns>
        ///     文字列のバイト長。</returns>
        /// -----------------------------------------------------------------------------------------
        public static int AnsLenB(string str)
        {
            //Shift JISに変換したときに必要なバイト数を返す
            return enc.GetByteCount(str.Replace((char)0x301C, '～'));
        }
        #endregion


        #region　AnsLeftB メソッド
        /// -----------------------------------------------------------------------------------
        /// <summary>
        ///     文字列の左端から指定された文字数分の文字列を返します。</summary>
        /// <param name="stTarget">
        ///     取り出す元になる文字列。</param>
        /// <param name="iByteSize">
        ///     取り出す文字数。</param>
        /// <returns>
        ///     左端から指定された文字数分の文字列。
        ///     文字数を超えた場合は、文字列全体が返されます。</returns>
        /// -----------------------------------------------------------------------------------
        public static string AnsLeftB(string stTarget, int iByteSize)
        {
            return AnsMidB(stTarget, 0, iByteSize);
        }
        #endregion


        #region　AnsMidB メソッド
        /// -----------------------------------------------------------------------------------
        /// <summary>
        ///     文字列の指定された位置以降のすべての文字列を返します。</summary>
        /// <param name="stTarget">
        ///     取り出す元になる文字列。</param>
        /// <param name="iStart">
        ///     取り出しを開始する位置。</param>
        /// <returns>
        ///     指定された位置以降のすべての文字列。</returns>
        /// -----------------------------------------------------------------------------------
        public static string AnsMidB(string stTarget, int iStart)
        {
            byte[] bBytes = enc.GetBytes(stTarget.Replace((char)0x301C, '～'));
            if (iStart < bBytes.Length)
            {
                return enc.GetString(bBytes, iStart, bBytes.Length - iStart);
            }
            else
            {
                return string.Empty;
            }
        }

        /// -----------------------------------------------------------------------------------
        /// <summary>
        ///     文字列の指定された位置から、指定された文字数分の文字列を返します。</summary>
        /// <param name="stTarget">
        ///     取り出す元になる文字列。</param>
        /// <param name="iStart">
        ///     取り出しを開始する位置。</param>
        /// <param name="iByteSize">
        ///     取り出す文字数。</param>
        /// <returns>
        ///     指定された位置から指定された文字数分の文字列。
        ///     文字数を超えた場合は、指定された位置からすべての文字列が返されます。</returns>
        /// -----------------------------------------------------------------------------------
        public static string AnsMidB(string stTarget, int iStart, int iByteSize)
        {
            byte[] bBytes = enc.GetBytes(stTarget.Replace((char)0x301C, '～'));
            if (iStart < bBytes.Length)
            {
                if (iByteSize > bBytes.Length - iStart)
                {
                    return enc.GetString(bBytes, iStart, bBytes.Length - iStart);
                }
                else
                {
                    return enc.GetString(bBytes, iStart, iByteSize);
                }
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion


        #region　AnsRightB メソッド
        /// -----------------------------------------------------------------------------------
        /// <summary>
        ///     文字列の右端から指定された文字数分の文字列を返します。</summary>
        /// <param name="stTarget">
        ///     取り出す元になる文字列。</param>
        /// <param name="iByteSize">
        ///     取り出す文字数。</param>
        /// <returns>
        ///     右端から指定された文字数分の文字列。
        ///     文字数を超えた場合は、文字列全体が返されます。</returns>
        /// -----------------------------------------------------------------------------------
        public static string AnsRightB(string stTarget, int iByteSize)
        {
            byte[] bBytes = enc.GetBytes(stTarget.Replace((char)0x301C, '～'));
            if (iByteSize <= bBytes.Length)
            {
                return enc.GetString(bBytes, bBytes.Length - iByteSize, iByteSize);
            }
            else
            {
                return enc.GetString(bBytes, 0, bBytes.Length);
            }
        }
        #endregion


        #region　AnsLeftC メソッド
        /// -----------------------------------------------------------------------------------
        /// <summary>
        ///     文字列の左端から指定された文字数分の文字列を返します。</summary>
        /// <param name="stTarget">
        ///     取り出す元になる文字列。</param>
        /// <param name="iByteSize">
        ///     取り出す文字数。</param>
        /// <returns>
        ///     左端から指定された文字数分の文字列。
        ///     文字数を超えた場合は、文字列全体が返されます。</returns>
        /// -----------------------------------------------------------------------------------
        public static string AnsLeftC(string stTarget, int iByteSize)
        {
            return AnsMidC(stTarget, 0, iByteSize);
        }

        /// -----------------------------------------------------------------------------------
        /// <summary>
        ///     文字列の左端から指定された文字数分の文字列を返します。</summary>
        /// <param name="stTarget">
        ///     取り出す元になる文字列。</param>
        /// <param name="iByteSize">
        ///     取り出す文字数。</param>
        /// <param name="oByteSize">
        ///     取り出した文字のバイト数。</param>
        /// <returns>
        ///     左端から指定された文字数分の文字列。
        ///     文字数を超えた場合は、文字列全体が返されます。</returns>
        /// -----------------------------------------------------------------------------------
        public static string AnsLeftC(string stTarget, int iByteSize, out int oByteSize)
        {
            return AnsMidC(stTarget, 0, iByteSize, out oByteSize);
        }
        #endregion


        #region　AnsMidC メソッド
        /// -----------------------------------------------------------------------------------
        /// <summary>
        ///     文字列の指定された位置から、指定された文字数分の文字列を返します。
        ///     ※日本語文字を分断された場合は手前の文字列まで返します。</summary>
        /// <param name="stTarget">
        ///     取り出す元になる文字列。</param>
        /// <param name="iStart">
        ///     取り出しを開始する位置。</param>
        /// <param name="iByteSize">
        ///     取り出す文字数。</param>
        /// <returns>
        ///     指定された位置から指定された文字数分の文字列。
        ///     文字数を超えた場合は、指定された位置からすべての文字列が返されます。</returns>
        /// -----------------------------------------------------------------------------------
        public static string AnsMidC(string stTarget, int iStart, int iByteSize)
        {
            stTarget = stTarget.Replace((char)0x301C, '～');
            byte[] bBytes = enc.GetBytes(stTarget);
            bool bolMinusPos;

            if ((iStart < bBytes.Length) && (iByteSize > 0))
            {
                // if (AnsCheck(AnsMidB(stTarget, iStart, 1)) == true)                                  // 削除080829
                if (AnsCheck2(ref bBytes, iStart) == true)                                              // 追加080829
                {
                    if (iStart > 0)
                    {
                        // if (AnsCheck(AnsMidB(stTarget, iStart - 1, 1)) == true)                      // 削除080829
                        if (AnsCheck2(ref bBytes, iStart - 1) == true)                                  // 追加080829
                        {
                            bolMinusPos = false;
                        }
                        else
                        {
                            bolMinusPos = true;
                        }
                    }
                    else
                    {
                        bolMinusPos = false;
                    }
                }
                else
                {
                    bolMinusPos = false;
                }

                if (bolMinusPos == true)
                {
                    // if (iByteSize > bBytes.Length - iStart - 1)                                      // 削除080829
                    if (iByteSize > bBytes.Length - iStart + 1)                                         // 追加080829
                    {
                        // return enc.GetString(bBytes, iStart - 1, bBytes.Length - iStart);            // 削除080829
                        return enc.GetString(bBytes, iStart - 1, bBytes.Length - iStart + 1);           // 追加080829
                    }
                    else
                    {
                        // if (AnsCheck(AnsMidB(stTarget, iStart - 1 + iByteSize - 1, 1)) == true)      // 削除080829
                        if (AnsCheck2(ref bBytes, iStart - 1 + iByteSize - 1) == true)                  // 追加080829
                        {
                            return enc.GetString(bBytes, iStart - 1, iByteSize);
                        }
                        else
                        {
                            return enc.GetString(bBytes, iStart - 1, iByteSize - 1);
                        }
                    }
                }
                else
                {
                    if (iByteSize > bBytes.Length - iStart)
                    {
                        return enc.GetString(bBytes, iStart, bBytes.Length - iStart);
                    }
                    else
                    {
                        // if (AnsCheck(AnsMidB(stTarget, iStart + iByteSize - 1, 1)) == true)          // 削除080829
                        if (AnsCheck2(ref bBytes, iStart + iByteSize - 1) == true)                      // 追加080829
                        {
                            return enc.GetString(bBytes, iStart, iByteSize);
                        }
                        else
                        {
                            return enc.GetString(bBytes, iStart, iByteSize - 1);
                        }
                    }
                }
            }
            else
            {
                return string.Empty;
            }
        }

        /// -----------------------------------------------------------------------------------
        /// <summary>
        ///     文字列の指定された位置から、指定された文字数分の文字列を返します。
        ///     ※日本語文字を分断された場合は手前の文字列まで返します。</summary>
        /// <param name="stTarget">
        ///     取り出す元になる文字列。</param>
        /// <param name="iStart">
        ///     取り出しを開始する位置。</param>
        /// <param name="iByteSize">
        ///     取り出す文字数。</param>
        /// <param name="oByteSize">
        ///     取り出した文字のバイト数。</param>
        /// <returns>
        ///     指定された位置から指定された文字数分の文字列。
        ///     文字数を超えた場合は、指定された位置からすべての文字列が返されます。</returns>
        /// -----------------------------------------------------------------------------------
        public static string AnsMidC(string stTarget, int iStart, int iByteSize, out int oByteSize)
        {
            stTarget = stTarget.Replace((char)0x301C, '～');
            byte[] bBytes = enc.GetBytes(stTarget);
            string strBuff;
            bool bolMinusPos;

            if ((iStart < bBytes.Length) && (iByteSize > 0))
            {
                // if (AnsCheck(AnsMidB(stTarget, iStart, 1)) == true)                                  // 削除080829
                if (AnsCheck2(ref bBytes, iStart) == true)                                              // 追加080829
                {
                    if (iStart > 0)
                    {
                        // if (AnsCheck(AnsMidB(stTarget, iStart - 1, 1)) == true)                      // 削除080829
                        if (AnsCheck2(ref bBytes, iStart - 1) == true)                                  // 追加080829
                        {
                            bolMinusPos = false;
                        }
                        else
                        {
                            bolMinusPos = true;
                        }
                    }
                    else
                    {
                        bolMinusPos = false;
                    }
                }
                else
                {
                    bolMinusPos = false;
                }

                if (bolMinusPos == true)
                {
                    if (iByteSize > bBytes.Length - iStart + 1)
                    {
                        // strBuff = enc.GetString(bBytes, iStart - 1, bBytes.Length - iStart           // 削除080829
                        strBuff = enc.GetString(bBytes, iStart - 1, bBytes.Length - iStart + 1);        // 追加080829
                        // 取り出した文字のバイト数
                        oByteSize = enc.GetByteCount(strBuff);
                        return strBuff;
                    }
                    else
                    {
                        // if (AnsCheck(AnsMidB(stTarget, iStart - 1 + iByteSize - 1, 1)) == true)      // 削除080829
                        if (AnsCheck2(ref bBytes, iStart - 1 + iByteSize - 1) == true)                  // 追加080829
                        {
                            //半角文字と判定した場合
                            strBuff = enc.GetString(bBytes, iStart - 1, iByteSize);
                        }
                        else
                        {
                            //全角文字と判定した場合
                            strBuff = enc.GetString(bBytes, iStart - 1, iByteSize - 1);
                        }
                        // 取り出した文字のバイト数
                        oByteSize = enc.GetByteCount(strBuff);
                        return strBuff;
                    }
                }
                else
                {
                    if (iByteSize > bBytes.Length - iStart)
                    {
                        strBuff = enc.GetString(bBytes, iStart, bBytes.Length - iStart);
                        // 取り出した文字のバイト数
                        oByteSize = enc.GetByteCount(strBuff);
                        return strBuff;
                    }
                    else
                    {
                        // if (AnsCheck(AnsMidB(stTarget, iStart + iByteSize - 1, 1)) == true)          // 削除080829
                        if (AnsCheck2(ref bBytes, iStart + iByteSize - 1) == true)                      // 追加080829
                        {
                            //半角文字と判定した場合
                            strBuff = enc.GetString(bBytes, iStart, iByteSize);
                        }
                        else
                        {
                            //全角文字と判定した場合
                            strBuff = enc.GetString(bBytes, iStart, iByteSize - 1);
                        }
                        // 取り出した文字のバイト数
                        oByteSize = enc.GetByteCount(strBuff);
                        return strBuff;
                    }
                }
            }
            else
            {
                oByteSize = 0;
                return string.Empty;
            }
        }

        /// -----------------------------------------------------------------------------------
        /// <summary>
        ///     Shift JISにエンコードされたバイト配列の指定された位置のコードが日本語文字１バイト目であるかどうかチェックします
        ///     追加080829（AnsMidCメソッド専用）</summary>
        /// <param name="bShiftJis">
        ///     Shift JISにエンコードされたバイト配列。</param>
        /// <param name="iPos">
        ///     チェックするバイト配列の位置。</param>
        /// <returns>
        ///     true : 日本語文字でないか、日本語文字２バイト目である  false : 日本語文字１バイト目である</returns>
        /// -----------------------------------------------------------------------------------
        private static bool AnsCheck2(ref byte[] bShiftJis, int iPos)
        {
            int iLenB = bShiftJis.Length;

            if ((iLenB == 0) || (iPos > iLenB) || (iPos < 0))
            {
                return true;
            }

            bool bolCheck = true;
            int i = 0;
            do
            {
                byte bCode = bShiftJis[i];
                if (((bCode >= 0x81) && (bCode <= 0x9f)) || ((bCode >= 0xe0) && (bCode <= 0xfc)))
                {
                    if (i + 1 == iPos)
                    {
                        break;
                    }
                    if (i >= iPos)
                    {
                        bolCheck = false;
                        break;
                    }
                    i += 2;
                }
                else
                {
                    if (i >= iPos)
                    {
                        break;
                    }
                    i++;
                }
            }
            while (i < iLenB);

            return bolCheck;
        }
        #endregion


        #region　AnsCheck メソッド
        /// -----------------------------------------------------------------------------------
        /// <summary>
        ///     文字列中に日本語文字が混在しているかチェックします</summary>
        /// <param name="stTarget">
        ///     対象文字列。</param>
        /// <returns>
        ///     true : 混在していない  false : 混在している</returns>
        /// -----------------------------------------------------------------------------------
        public static bool AnsCheck(string stTarget)
        {
            stTarget = stTarget.Replace((char)0x301C, '～');
            byte[] bBytes = enc.GetBytes(stTarget);
            if (bBytes.Length == stTarget.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region　AnsLeft メソッド
        /// -----------------------------------------------------------------------------------
        /// <summary>
        ///     文字列の左端から指定された文字数分の文字列を返します。</summary>
        /// <param name="stTarget">
        ///     取り出す元になる文字列。</param>
        /// <param name="iMojiSize">
        ///     取り出す文字数。</param>
        /// <returns>
        ///     左端から指定された文字数分の文字列。
        ///     文字数を超えた場合は、文字列全体が返されます。</returns>
        /// -----------------------------------------------------------------------------------
        public static string AnsLeft(string stTarget, int iMojiSize)
        {
            // 文字長0
            if (stTarget.Length == 0)
            {
                return string.Empty;
            }
            // 切り取りサイズ > 文字長
            if (iMojiSize > stTarget.Length)
            {
                return stTarget;
            }
            else
            {
                return stTarget.Substring(0, iMojiSize);
            }
        }
        #endregion

        #region　AnsMid メソッド
        /// -----------------------------------------------------------------------------------
        /// <summary>
        ///     文字列の指定された位置から、指定された文字数分の文字列を返します。</summary>
        /// <param name="stTarget">
        ///     取り出す元になる文字列。</param>
        /// <param name="iStart">
        ///     取り出しを開始する位置。</param>
        /// <param name="iMojiSize">
        ///     取り出す文字数。</param>
        /// <returns>
        ///     指定された位置から指定された文字数分の文字列。
        ///     文字数を超えた場合は、指定された位置からすべての文字列が返されます。</returns>
        /// -----------------------------------------------------------------------------------
        public static string AnsMid(string stTarget, int iStart, int iMojiSize)
        {
            // 文字長0
            if (stTarget.Length == 0)
            {
                return string.Empty;
            }
            // 開始位置 <= 文字長
            if (iStart < stTarget.Length)
            {
                // 切り取りｻｲｽﾞ＞文字長－開始位置
                if (iMojiSize > stTarget.Length - iStart)
                {
                    return stTarget.Substring(iStart, (stTarget.Length - iStart));
                }
                else
                {
                    return stTarget.Substring(iStart, iMojiSize);
                }

            }
            else
            {
                return string.Empty;
            }
        }
        #endregion
    }

    /// <summary>
    /// 指定に従って変換された文字列型 (String) の値を返します。
    /// </summary>
    public class StrConv
    {
        /// <summary>
        /// LCMapStringA ある文字列を別の文字列にマップする。</summary>        
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        private static extern int LCMapStringA(int Locale, int dwMapFlags,
            string lpSrcStr, int cchSrc, StringBuilder lpDestStr, int cchDest);

        /// <summary>
        /// GetSystemDefaultLCID ロケール識別子を取得</summary>        
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern int GetSystemDefaultLCID();

        /// <summary>
        /// マッピング定数</summary>        
        private const int LCMAP_LOWERCASE = 0x100;
        private const int LCMAP_UPPERCASE = 0x200;
        private const int LCMAP_HIRAGANA = 0x100000;
        private const int LCMAP_KATAKANA = 0x200000;
        private const int LCMAP_HALFWIDTH = 0x400000;
        private const int LCMAP_FULLWIDTH = 0x800000;

        /// <summary>
        /// バイト数をカウントするために使用するShift_JISエンコード</summary>
        private static Encoding enc = System.Text.Encoding.GetEncoding("Shift_JIS");


        #region　ToNarrow メソッド
        /// -----------------------------------------------------------------------------------------
        /// <summary>
        ///     文字列内の全角文字 (2 バイト) を半角文字 (1 バイト) に変換します。</summary>
        /// <param name="str">
        ///     変換元の文字列</param>
        /// <returns>
        ///     変換後の文字列</returns>
        /// -----------------------------------------------------------------------------------------
        public static string ToNarrow(string str)
        {
            StringBuilder sb = new StringBuilder(enc.GetByteCount(str.Replace((char)0x301C, '～')));
            LCMapStringA(GetSystemDefaultLCID(), LCMAP_HALFWIDTH, str, -1, sb, sb.MaxCapacity);
            return sb.ToString().Replace("\0", "");
        }
        #endregion


        #region　ToWide メソッド
        /// -----------------------------------------------------------------------------------------
        /// <summary>
        ///     文字列内の半角文字 (1 バイト) を全角文字 (2 バイト) に変換します。</summary>
        /// <param name="str">
        ///     変換元の文字列</param>
        /// <returns>
        ///     変換後の文字列</returns>
        /// -----------------------------------------------------------------------------------------
        public static string ToWide(string str)
        {
            StringBuilder sb = new StringBuilder(enc.GetByteCount(str.Replace((char)0x301C, '～')) * 2);
            LCMapStringA(GetSystemDefaultLCID(), LCMAP_FULLWIDTH, str, -1, sb, sb.MaxCapacity);
            return sb.ToString().Replace("\0", "");
        }
        #endregion


        #region　ToUpperCase メソッド
        /// -----------------------------------------------------------------------------------------
        /// <summary>
        ///     文字列を大文字に変換します。</summary>
        /// <param name="str">
        ///     変換元の文字列</param>
        /// <returns>
        ///     変換後の文字列</returns>
        /// -----------------------------------------------------------------------------------------
        public static string ToUpperCase(string str)
        {
            StringBuilder sb = new StringBuilder(enc.GetByteCount(str.Replace((char)0x301C, '～')));
            LCMapStringA(GetSystemDefaultLCID(), LCMAP_UPPERCASE, str, -1, sb, sb.MaxCapacity);
            return sb.ToString().Replace("\0", "");
        }
        #endregion


        #region　ToLowerCase メソッド
        /// -----------------------------------------------------------------------------------------
        /// <summary>
        ///     文字列を小文字に変換します。</summary>
        /// <param name="str">
        ///     変換元の文字列</param>
        /// <returns>
        ///     変換後の文字列</returns>
        /// -----------------------------------------------------------------------------------------
        public static string ToLowerCase(string str)
        {
            StringBuilder sb = new StringBuilder(enc.GetByteCount(str.Replace((char)0x301C, '～')));
            LCMapStringA(GetSystemDefaultLCID(), LCMAP_LOWERCASE, str, -1, sb, sb.MaxCapacity);
            return sb.ToString().Replace("\0", "");
        }
        #endregion


        #region　ToKatakana メソッド
        /// -----------------------------------------------------------------------------------------
        /// <summary>
        ///     文字列内のひらがなをカタカナに変換します。</summary>
        /// <param name="str">
        ///     変換元の文字列</param>
        /// <returns>
        ///     変換後の文字列</returns>
        /// -----------------------------------------------------------------------------------------
        public static string ToKatakana(string str)
        {
            StringBuilder sb = new StringBuilder(str.Length * 2);
            LCMapStringA(GetSystemDefaultLCID(), LCMAP_KATAKANA, str, -1, sb, sb.MaxCapacity);
            return sb.ToString().Replace("\0", "");
        }
        #endregion


        #region　ToHiragana メソッド
        /// -----------------------------------------------------------------------------------------
        /// <summary>
        ///     文字列内のカタカナをひらがなに変換します。</summary>
        /// <param name="str">
        ///     変換元の文字列</param>
        /// <returns>
        ///     変換後の文字列</returns>
        /// -----------------------------------------------------------------------------------------
        public static string ToHiragana(string str)
        {
            StringBuilder sb = new StringBuilder(enc.GetByteCount(str.Replace((char)0x301C, '～')));
            LCMapStringA(GetSystemDefaultLCID(), LCMAP_HIRAGANA, str, -1, sb, sb.MaxCapacity);
            return sb.ToString().Replace("\0", "");
        }
        #endregion
    }
    /// <summary>
    /// 指定された値チェックを行います
    /// </summary>
    public class Chk
    {
        #region　IsIntNumber メソッド
        /// -----------------------------------------------------------------------------------------
        /// <summary>
        ///     指定文字列の整数チェック</summary>
        /// <param name="pstrNumber">
        ///     チェック文字列</param>
        /// <returns>
        ///     指定文字列の整数チェックを行います</returns>
        /// -----------------------------------------------------------------------------------------
        public static bool IsIntNumber(string pstrNumber)
        {
            try
            {
                int lintRetWK;          // 関数戻値WK用

                // 1.数値チェック
                if (int.TryParse(pstrNumber, out lintRetWK) == false)
                {
                    return false;               // FALSE
                }
                // 2.[+]が存在(0～：あり)
                if (pstrNumber.IndexOfAny(new char[] { '+' }) >= 0)
                {
                    return false;               // FALSE
                }
                // 3.[-]が存在(0～：あり)
                if (pstrNumber.IndexOfAny(new char[] { '-' }) >= 0)
                {
                    return false;               // FALSE
                }
                // 4.[/]が存在(0～：あり)
                if (pstrNumber.IndexOfAny(new char[] { '/' }) >= 0)
                {
                    return false;               // FALSE
                }
                // 5.[.]が存在(0～：あり)
                if (pstrNumber.IndexOfAny(new char[] { '.' }) >= 0)
                {
                    return false;               // FALSE
                }
                // 6.[%]が存在(0～：あり)
                if (pstrNumber.IndexOfAny(new char[] { '%' }) >= 0)
                {
                    return false;               // FALSE
                }
                // 7.[,]が存在(0～：あり)
                if (pstrNumber.IndexOfAny(new char[] { ',' }) >= 0)
                {
                    return false;               // FALSE
                }

                // 全角変換
                string lstrUpperWK = pstrNumber.ToUpper();

                // 8.[,]が存在(0～：あり)
                if (lstrUpperWK.IndexOfAny(new char[] { 'D' }) >= 0)
                {
                    return false;               // FALSE
                }
                // 9.[,]が存在(0～：あり)
                if (lstrUpperWK.IndexOfAny(new char[] { 'E' }) >= 0)
                {
                    return false;               // FALSE
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

        #region　IsPostNo メソッド
        /// -----------------------------------------------------------------------------------------
        /// <summary>
        ///     指定文字列の郵便番号(半角)チェック</summary>
        /// <param name="pstrPostNo">
        ///     チェック文字列</param>
        /// <param name="pintMaxLenB">
        ///     全バイト数</param>
        /// <returns>
        ///     指定文字列の郵便番号チェックを行います</returns>
        /// -----------------------------------------------------------------------------------------
        public static bool IsPostNo(string pstrPostNo, int pintMaxLenB)
        {
            int lintPostLenB = 0;                     // 文字長(ﾊﾞｲﾄ)

            try
            {
                int lintPostLen = pstrPostNo.Length;

                // 1.文字長ｵｰﾊﾞ
                if (lintPostLen > pintMaxLenB)
                {
                    MessageBox.Show("入力文字数がオーバしています。", "入力確認",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                // 2.全角混入チェック
                lintPostLenB = Ans.AnsLenB(pstrPostNo);       // ﾊﾞｲﾄ数取得
                if (lintPostLen != lintPostLenB)
                {
                    MessageBox.Show("全角文字が入力されています。", "入力確認",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                // 3.指定文字チェック
                string lstrWK = "";             // 文字取得用
                for (int lintLoop = 0; lintLoop < lintPostLenB; lintLoop++)
                {
                    lstrWK = Ans.AnsMidB(pstrPostNo, lintLoop, 1);     // 1文字取得
                    switch (lstrWK)
                    {
                        case "-":
                        case " ":
                            break;
                        default:
                            // 数値でない場合エラー
                            if (IsIntNumber(lstrWK) == false)
                            {
                                MessageBox.Show("不正な文字が入力されています。", "入力確認",
                                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;           // チェックＮＧ
                            }
                            break;
                    }
                }
                // チェックＯＫ
                return true;
            }
            catch
            {
                // チェックＮＧ
                return false;
            }

        }
        #endregion　IsPostNo メソッド

        #region　IsWideString メソッド
        /// -----------------------------------------------------------------------------------------
        /// <summary>
        ///     指定文字列の全角チェック（文字数チェックあり）</summary>
        /// <param name="pstrTarget">
        ///     チェック文字列</param>
        /// <param name="pintMaxLenB">
        ///     全バイト数</param>
        /// <returns>
        ///     指定文字列の全角チェックを行います</returns>
        /// -----------------------------------------------------------------------------------------
        public static bool IsWideString(string pstrTarget, int pintMaxLenB)
        {
            int lintPostLenB = 0;                         // 文字長(ﾊﾞｲﾄ)

            try
            {
                // 文字数取得
                int lintPostLen = pstrTarget.Length;

                // ﾊﾞｲﾄ数取得
                lintPostLenB = Ans.AnsLenB(pstrTarget);

                // 1.半角混入チェック
                if ((lintPostLen * 2) != lintPostLenB)
                {
                    MessageBox.Show("半角文字が入力されています。", "入力確認",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;                       // 半角ありエラー
                }
                // 2.文字長ｵｰﾊﾞ
                if (lintPostLenB > pintMaxLenB)
                {
                    MessageBox.Show("入力文字数がオーバしています。", "入力確認",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                // チェックＯＫ
                return true;
            }
            catch
            {
                // チェックＮＧ
                return false;
            }
        }
        #endregion　IsWideString メソッド

        #region　IsWideString メソッド
        /// -----------------------------------------------------------------------------------------
        /// <summary>
        ///     指定文字列の全角チェック（文字数チェックなし）</summary>
        /// <param name="pstrTarget">
        ///     チェック文字列</param>
        /// <returns>
        ///     指定文字列の全角チェックを行います</returns>
        /// -----------------------------------------------------------------------------------------
        public static bool IsWideString(string pstrTarget)
        {
            int lintPostLenB = 0;                         // 文字長(ﾊﾞｲﾄ)

            try
            {
                // 文字数取得
                int lintPostLen = pstrTarget.Length;

                // ﾊﾞｲﾄ数取得
                lintPostLenB = Ans.AnsLenB(pstrTarget);

                // 1.半角混入チェック
                if ((lintPostLen * 2) != lintPostLenB)
                {
                    MessageBox.Show("半角文字が入力されています。", "入力確認",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;                       // 半角ありエラー
                }

                // チェックＯＫ
                return true;
            }
            catch
            {
                // チェックＮＧ
                return false;
            }
        }
        #endregion　IsWideString メソッド

        #region　IsLenB メソッド
        /// -----------------------------------------------------------------------------------------
        /// <summary>
        ///     指定文字列のバイトチェック</summary>
        /// <param name="pstrChk">
        ///     チェック文字列</param>
        /// <param name="pintLenB">チェック文字数</param>
        /// <returns>
        ///     指定文字列のバイト数日付チェックを行います</returns>
        /// -----------------------------------------------------------------------------------------
        public static bool IsLenB(string pstrChk, int pintLenB)
        {
            try
            {
                // 文字長(ﾊﾞｲﾄ)＞指定ﾊﾞｲﾄ数の場合、エラー
                if (Ans.AnsLenB(pstrChk) > pintLenB)
                {
                    MessageBox.Show("入力文字数がオーバしています。", "入力確認",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
    }

    /// <summary>
    /// 各変換をnullチェック、""チェック後に実行します
    /// </summary>
    public class Conv
    {
        #region　ToInt メソッド
        /// -----------------------------------------------------------------------------------------
        /// <summary>
        ///     int型変換処理</summary>
        /// <param name="pstrData">
        ///     (I)変換前文字列</param>
        /// <returns>
        ///     チェック後int型変換を行います</returns>
        /// -----------------------------------------------------------------------------------------
        public static int ToInt(string pstrData)
        {
            try
            {
                // 空白/nullの場合、0
                if (pstrData == "" || pstrData == null)
                {
                    return 0;

                    // 通常変換
                }
                else
                {
                    return int.Parse(pstrData);
                }
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region　ToInt メソッド
        /// -----------------------------------------------------------------------------------------
        /// <summary>
        ///     int型変換処理</summary>
        /// <param name="pobjData">
        ///     (I)変換前オブジェクト</param>
        /// <returns>
        ///     チェック後int型変換を行います</returns>
        /// -----------------------------------------------------------------------------------------
        public static int ToInt(object pobjData)
        {
            try
            {
                // nullの場合、0
                if (pobjData == null)
                {
                    return 0;

                    // 通常変換
                }
                else
                {
                    return int.Parse(pobjData.ToString());
                }
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region　ToBool メソッド
        /// -----------------------------------------------------------------------------------------
        /// <summary>
        ///     boolt型変換処理</summary>
        /// <param name="pstrData">
        ///     (I)変換前文字列</param>
        /// <returns>
        ///     チェック後bool型変換を行います</returns>
        /// -----------------------------------------------------------------------------------------
        public static bool ToBool(string pstrData)
        {
            try
            {
                // 空白/nullの場合、false
                if (pstrData == "" || pstrData == null)
                {
                    return false;

                    // 通常変換
                }
                else
                {
                    return bool.Parse(pstrData);
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region　ToString メソッド
        /// -----------------------------------------------------------------------------------------
        /// <summary>
        ///     string型変換処理</summary>
        /// <param name="lobjData">
        ///     (I)変換前オブジェクト</param>
        /// <returns>
        ///     チェック後bool型変換を行います</returns>
        /// -----------------------------------------------------------------------------------------
        public static string ToString(object lobjData)
        {
            try
            {
                // 空白/nullの場合、false
                if (lobjData == null)
                {
                    return "";

                    // 通常変換
                }
                else
                {
                    return (lobjData.ToString());
                }
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region 文字列変換
        public string cnvStrThousandsPrice(string price)
        {
            // データを読み込む
            string str_price = price;
            decimal dec_price = 0m;

            // 値に変換
            if (!decimal.TryParse(str_price, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, null, out dec_price))
            {
                str_price = "0";
            }

            // 再表示
            if (dec_price != 0)
            {
                str_price = dec_price.ToString("#,0.00");
            }

            return str_price;
        }

        public string cnvStrDecimalPrice(string price)
        {
            // データを読み込む
            string str_price = price;
            decimal dec_price = 0m;

            // 値に変換
            if (!decimal.TryParse(str_price, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, null, out dec_price))
            {
                str_price = "0";
            }

            // 再表示
            if (dec_price != 0)
            {
                str_price = dec_price.ToString();
            }

            return str_price;
        }

        public string replaceKinshiChar(string moji)
        {
            string strwk = moji;

            if (strwk.Trim().Length > 0)
            {
                strwk = strwk.Replace("　", " ");   // 全角スペースを半角スペースに変更
                strwk = strwk.Trim();               // 前後のスペースを削除
                strwk = strwk.Replace(",", " ");    // カンマをスペースに変更
                strwk = strwk.Replace(Environment.NewLine, " ");    // 改行をスペースに変更
            }
            else
            {
                strwk = "";
            }
            return strwk;
        }


        #endregion


    }

}
