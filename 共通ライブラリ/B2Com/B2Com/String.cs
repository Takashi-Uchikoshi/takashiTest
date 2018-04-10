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
        /// <summary>
        /// 指定したバイト数分のスペース文字列を返します。
        /// </summary>
        /// <param name="iByteSize">スペースを埋めるバイト数</param>
        /// <returns>指定されたバイト数分のスペース文字列</returns>
        public static string Spaces(int iByteSize)
        {
            string stString = "";
            return stString.PadRight(iByteSize);
        }

        /// <summary>
        /// 指定したファイルを行単位の配列にします。
        /// </summary>
        /// <param name="stFilename">読み込むファイル</param>
        /// <returns>行単位の配列</returns>
        public static string[] FileStrings(string stFilename)
        {
            FileStream fs = new FileStream(stFilename, FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding(932));
            string strTextAll = sr.ReadToEnd();
            sr.Close();

            return strTextAll.Replace("\r\n", "\n").Split('\n');
        }

        /// <summary>
        /// 指定した文字列を指定バイト数にて分割します。
        /// </summary>
        /// <param name="pstrMoji">指定文字列(半角混在可)</param>
        /// <param name="pintLengthB">指定バイト文字数</param> 
        /// <param name="pblnDelNewLine">改行コード分割フラグ(TRUE:分割あり、False：分割しない)</param> 
        /// <returns>分割配列(分解できなかった場合は配列数1で空白文字)</returns>
        public static string[] StringBukatuB(string pstrMoji, int pintLengthB, bool pblnDelNewLine)
        {
            List<string> lstrRet = new List<string>();
            string[] lstrBunkatuWK;
            string lstrEditText;
            int lintCutByteLen;

            lstrRet.Clear();

            lstrEditText = pstrMoji;

            if (lstrEditText.Length == 0)
            {
                return (new string[1] { " " });
            }

            // 改行コードがある場合、一旦改行コードにて分割(引数に分割指定がある場合のみ)
            // 改行コードは[\n]で統一
            if (pblnDelNewLine == true)
            {
                lstrBunkatuWK = lstrEditText.Replace("\r\n", "\n").Split('\n');
            }
            else
            {
                lstrBunkatuWK = new string[1];
                lstrBunkatuWK[0] = lstrEditText;
            }

            // 改行分割後文字列を、指定文字列で分割します
            for (int lintIndex = lstrBunkatuWK.GetLowerBound(0); lintIndex <= lstrBunkatuWK.GetUpperBound(0); lintIndex++)
            {
                while (lstrBunkatuWK[lintIndex].Length > 0)
                {
                    lstrRet.Add(Ans.AnsLeftC(lstrBunkatuWK[lintIndex], pintLengthB, out lintCutByteLen));

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

        /// <summary>
        /// 指定した文字列の改行コードを削除します。
        /// </summary>
        /// <param name="pstrMoji">指定文字列(半角混在可)</param>
        /// <returns>指定文字列から改行コードを削除した文字列</returns>
        public static string DelNewLine(string pstrMoji)
        {
            string lstrEditText;

            lstrEditText = pstrMoji;

            // 一旦[\n]へ変換してから[\n]を全て削除
            lstrEditText = lstrEditText.Replace("\r\n", "\n");
            lstrEditText = lstrEditText.Replace("\n", "");

            return lstrEditText;
        }
    }

    /// <summary>
    /// 指定された文字数分の文字列型 (String) を返します。
    /// </summary>
    public class Ans
    {
        /// <summary>
        /// バイト数をカウントするために使用するShift_JISエンコード
        /// </summary>
        private static Encoding enc = System.Text.Encoding.GetEncoding("Shift_JIS");

        /// <summary>
        /// 文字列のバイト長を返します。
        /// </summary>
        /// <param name="str">バイト長を取り出す元になる文字列</param>
        /// <returns>文字列のバイト長</returns>
        public static int AnsLenB(string str)
        {
            return enc.GetByteCount(str.Replace((char)0x301C, '～'));
        }

        /// <summary>
        /// 文字列の左端から指定された文字数分の文字列を返します。
        /// </summary>
        /// <param name="stTarget">取り出す元になる文字列</param>
        /// <param name="iByteSize">取り出す文字数</param>
        /// <returns>左端から指定された文字数分の文字列(文字数を超えた場合は文字列全体)</returns>
        public static string AnsLeftB(string stTarget, int iByteSize)
        {
            return AnsMidB(stTarget, 0, iByteSize);
        }

        /// <summary>
        /// 文字列の指定された位置以降のすべての文字列を返します。
        /// </summary>
        /// <param name="stTarget">取り出す元になる文字列</param>
        /// <param name="iStart">取り出しを開始する位置</param>
        /// <returns>指定された位置以降のすべての文字列</returns>
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

        /// <summary>
        /// 文字列の指定された位置から、指定された文字数分の文字列を返します。
        /// </summary>
        /// <param name="stTarget">取り出す元になる文字列</param>
        /// <param name="iStart">取り出しを開始する位置</param>
        /// <param name="iByteSize">取り出す文字数</param>
        /// <returns>
        /// 指定された位置から指定された文字数分の文字列
        /// (文字数を超えた場合は指定された位置からすべての文字列)
        /// </returns>
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

        /// <summary>
        /// 文字列の右端から指定された文字数分の文字列を返します。
        /// </summary>
        /// <param name="stTarget">取り出す元になる文字列</param>
        /// <param name="iByteSize">取り出す文字数</param>
        /// <returns>右端から指定された文字数分の文字列(文字数を超えた場合は文字列全体)</returns>
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

        /// <summary>
        /// 文字列の左端から指定された文字数分の文字列を返します。
        /// </summary>
        /// <param name="stTarget">取り出す元になる文字列</param>
        /// <param name="iByteSize">取り出す文字数</param>
        /// <returns>左端から指定された文字数分の文字列(文字数を超えた場合は文字列全体)</returns>
        public static string AnsLeftC(string stTarget, int iByteSize)
        {
            return AnsMidC(stTarget, 0, iByteSize);
        }

        /// <summary>
        /// 文字列の左端から指定された文字数分の文字列を返します。
        /// </summary>
        /// <param name="stTarget">取り出す元になる文字列</param>
        /// <param name="iByteSize">取り出す文字数</param>
        /// <param name="oByteSize">取り出した文字のバイト数</param>
        /// <returns>左端から指定された文字数分の文字列(文字数を超えた場合は文字列全体)</returns>
        public static string AnsLeftC(string stTarget, int iByteSize, out int oByteSize)
        {
            return AnsMidC(stTarget, 0, iByteSize, out oByteSize);
        }

        /// <summary>
        /// 文字列の指定された位置から、指定された文字数分の文字列を返します。
        /// ※日本語文字を分断された場合は手前の文字列まで返します。
        /// </summary>
        /// <param name="stTarget">取り出す元になる文字列</param>
        /// <param name="iStart">取り出しを開始する位置</param>
        /// <param name="iByteSize">取り出す文字数</param>
        /// <returns>
        /// 指定された位置から指定された文字数分の文字列
        /// 文字数を超えた場合は指定された位置からすべての文字列
        /// </returns>
        public static string AnsMidC(string stTarget, int iStart, int iByteSize)
        {
            stTarget = stTarget.Replace((char)0x301C, '～');
            byte[] bBytes = enc.GetBytes(stTarget);
            bool bolMinusPos;

            if ((iStart < bBytes.Length) && (iByteSize > 0))
            {
                if (AnsCheck2(ref bBytes, iStart) == true)
                {
                    if (iStart > 0)
                    {
                        if (AnsCheck2(ref bBytes, iStart - 1) == true)
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
                        return enc.GetString(bBytes, iStart - 1, bBytes.Length - iStart + 1);
                    }
                    else
                    {
                        if (AnsCheck2(ref bBytes, iStart - 1 + iByteSize - 1) == true)
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
                        if (AnsCheck2(ref bBytes, iStart + iByteSize - 1) == true)
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

        /// <summary>
        /// 文字列の指定された位置から、指定された文字数分の文字列を返します。
        /// ※日本語文字を分断された場合は手前の文字列まで返します。
        /// </summary>
        /// <param name="stTarget">取り出す元になる文字列</param>
        /// <param name="iStart">取り出しを開始する位置</param>
        /// <param name="iByteSize">取り出す文字数</param>
        /// <param name="oByteSize">取り出した文字のバイト数</param>
        /// <returns>
        /// 指定された位置から指定された文字数分の文字列
        /// 文字数を超えた場合は指定された位置からすべての文字列
        /// </returns>
        public static string AnsMidC(string stTarget, int iStart, int iByteSize, out int oByteSize)
        {
            stTarget = stTarget.Replace((char)0x301C, '～');
            byte[] bBytes = enc.GetBytes(stTarget);
            string strBuff;
            bool bolMinusPos;

            if ((iStart < bBytes.Length) && (iByteSize > 0))
            {
                if (AnsCheck2(ref bBytes, iStart) == true)
                {
                    if (iStart > 0)
                    {
                        if (AnsCheck2(ref bBytes, iStart - 1) == true)
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
                        strBuff = enc.GetString(bBytes, iStart - 1, bBytes.Length - iStart + 1);
                        oByteSize = enc.GetByteCount(strBuff);
                        return strBuff;
                    }
                    else
                    {
                        if (AnsCheck2(ref bBytes, iStart - 1 + iByteSize - 1) == true)
                        {
                            // 半角文字と判定した場合
                            strBuff = enc.GetString(bBytes, iStart - 1, iByteSize);
                        }
                        else
                        {
                            // 全角文字と判定した場合
                            strBuff = enc.GetString(bBytes, iStart - 1, iByteSize - 1);
                        }
                        oByteSize = enc.GetByteCount(strBuff);
                        return strBuff;
                    }
                }
                else
                {
                    if (iByteSize > bBytes.Length - iStart)
                    {
                        strBuff = enc.GetString(bBytes, iStart, bBytes.Length - iStart);
                        oByteSize = enc.GetByteCount(strBuff);
                        return strBuff;
                    }
                    else
                    {
                        if (AnsCheck2(ref bBytes, iStart + iByteSize - 1) == true)
                        {
                            // 半角文字と判定した場合
                            strBuff = enc.GetString(bBytes, iStart, iByteSize);
                        }
                        else
                        {
                            // 全角文字と判定した場合
                            strBuff = enc.GetString(bBytes, iStart, iByteSize - 1);
                        }
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

        /// <summary>
        /// Shift JISにエンコードされたバイト配列の指定された位置のコードが日本語文字１バイト目であるかどうかチェックします
        /// </summary>
        /// <param name="bShiftJis">Shift JISにエンコードされたバイト配列</param>
        /// <param name="iPos">チェックするバイト配列の位置</param>
        /// <returns>true:日本語文字でないか、日本語文字２バイト目  false:日本語文字１バイト目</returns>
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

        /// <summary>
        /// 文字列中に日本語文字が混在しているかチェックします
        /// </summary>
        /// <param name="stTarget">対象文字列</param>
        /// <returns>true:混在していない false:混在している</returns>
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

        /// <summary>
        /// 文字列の左端から指定された文字数分の文字列を返します。
        /// </summary>
        /// <param name="stTarget">取り出す元になる文字列</param>
        /// <param name="iMojiSize">取り出す文字数</param>
        /// <returns>
        /// 左端から指定された文字数分の文字列(文字数を超えた場合は文字列全体)</returns>
        public static string AnsLeft(string stTarget, int iMojiSize)
        {
            if (stTarget.Length == 0)
            {
                return string.Empty;
            }
            if (iMojiSize > stTarget.Length)
            {
                return stTarget;
            }
            else
            {
                return stTarget.Substring(0, iMojiSize);
            }
        }

        /// <summary>
        /// 文字列の指定された位置から、指定された文字数分の文字列を返します。
        /// </summary>
        /// <param name="stTarget">取り出す元になる文字列</param>
        /// <param name="iStart">取り出しを開始する位置</param>
        /// <param name="iMojiSize">取り出す文字数</param>
        /// <returns>
        /// 指定された位置から指定された文字数分の文字列
        /// 文字数を超えた場合は指定された位置からすべての文字列</returns>
        public static string AnsMid(string stTarget, int iStart, int iMojiSize)
        {
            if (stTarget.Length == 0)
            {
                return string.Empty;
            }
            if (iStart < stTarget.Length)
            {
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
    }

    /// <summary>
    /// 指定に従って変換された文字列型 (String) の値を返します。
    /// </summary>
    public class StrConv
    {
        /// <summary>
        /// LCMapStringA ある文字列を別の文字列にマップする
        /// </summary>
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        private static extern int LCMapStringA(int Locale, int dwMapFlags,
            string lpSrcStr, int cchSrc, StringBuilder lpDestStr, int cchDest);

        /// <summary>
        /// GetSystemDefaultLCID ロケール識別子を取得
        /// </summary>
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern int GetSystemDefaultLCID();

        /// <summary>小文字変換</summary>
        private const int LcmapLowercase = 0x100;
        /// <summary>大文字変換</summary>
        private const int LcmapUppercase = 0x200;
        /// <summary>ひらがな変換</summary>
        private const int LcmapHiragana = 0x100000;
        /// <summary>カタカナ変換</summary>
        private const int LcmapKatakana = 0x200000;
        /// <summary>半角変換</summary>
        private const int LcmapHalfwidth = 0x400000;
        /// <summary>全角変換</summary>
        private const int LcmapFullwidth = 0x800000;

        /// <summary>
        /// バイト数をカウントするために使用するShift_JISエンコード
        /// </summary>
        private static Encoding enc = System.Text.Encoding.GetEncoding("Shift_JIS");

        /// <summary>
        /// 文字列内の全角文字 (2 バイト) を半角文字 (1 バイト) に変換します。
        /// </summary>
        /// <param name="str">変換元の文字列</param>
        /// <returns>変換後の文字列</returns>
        public static string ToNarrow(string str)
        {
            StringBuilder sb = new StringBuilder(enc.GetByteCount(str.Replace((char)0x301C, '～')));
            LCMapStringA(GetSystemDefaultLCID(), LcmapHalfwidth, str, -1, sb, sb.MaxCapacity);
            return sb.ToString().Replace("\0", "");
        }

        /// <summary>
        /// 文字列内の半角文字 (1 バイト) を全角文字 (2 バイト) に変換します。
        /// </summary>
        /// <param name="str">変換元の文字列</param>
        /// <returns>変換後の文字列</returns>
        public static string ToWide(string str)
        {
            StringBuilder sb = new StringBuilder(enc.GetByteCount(str.Replace((char)0x301C, '～')) * 2);
            LCMapStringA(GetSystemDefaultLCID(), LcmapFullwidth, str, -1, sb, sb.MaxCapacity);
            return sb.ToString().Replace("\0", "");
        }

        /// <summary>
        /// 文字列を大文字に変換します。
        /// </summary>
        /// <param name="str">変換元の文字列</param>
        /// <returns>変換後の文字列</returns>
        public static string ToUpperCase(string str)
        {
            StringBuilder sb = new StringBuilder(enc.GetByteCount(str.Replace((char)0x301C, '～')));
            LCMapStringA(GetSystemDefaultLCID(), LcmapUppercase, str, -1, sb, sb.MaxCapacity);
            return sb.ToString().Replace("\0", "");
        }

        /// <summary>
        /// 文字列を小文字に変換します。
        /// </summary>
        /// <param name="str">変換元の文字列</param>
        /// <returns>変換後の文字列</returns>
        public static string ToLowerCase(string str)
        {
            StringBuilder sb = new StringBuilder(enc.GetByteCount(str.Replace((char)0x301C, '～')));
            LCMapStringA(GetSystemDefaultLCID(), LcmapLowercase, str, -1, sb, sb.MaxCapacity);
            return sb.ToString().Replace("\0", "");
        }

        /// <summary>
        /// 文字列内のひらがなをカタカナに変換します。
        /// </summary>
        /// <param name="str">変換元の文字列</param>
        /// <returns>変換後の文字列</returns>
        public static string ToKatakana(string str)
        {
            StringBuilder sb = new StringBuilder(str.Length * 2);
            LCMapStringA(GetSystemDefaultLCID(), LcmapKatakana, str, -1, sb, sb.MaxCapacity);
            return sb.ToString().Replace("\0", "");
        }

        /// <summary>
        /// 文字列内のカタカナをひらがなに変換します。
        /// </summary>
        /// <param name="str">変換元の文字列</param>
        /// <returns>変換後の文字列</returns>
        public static string ToHiragana(string str)
        {
            StringBuilder sb = new StringBuilder(enc.GetByteCount(str.Replace((char)0x301C, '～')));
            LCMapStringA(GetSystemDefaultLCID(), LcmapHiragana, str, -1, sb, sb.MaxCapacity);
            return sb.ToString().Replace("\0", "");
        }
    }

    /// <summary>
    /// 指定された値チェックを行います
    /// </summary>
    public class Chk
    {
        /// <summary>
        /// 指定文字列の整数チェック
        /// </summary>
        /// <param name="pstrNumber">チェック文字列</param>
        /// <returns>true:文字列が数値 false:それ以外</returns>
        public static bool IsIntNumber(string pstrNumber)
        {
            try
            {
                int lintRetWK;

                // 数値変換できるかチェックして、変換できるときは
                // "+"や"-"、","などの記号がないかチェックする
                if (int.TryParse(pstrNumber, out lintRetWK) == false)
                {
                    return false;
                }
                if (pstrNumber.IndexOfAny(new char[] { '+' }) >= 0)
                {
                    return false;
                }
                if (pstrNumber.IndexOfAny(new char[] { '-' }) >= 0)
                {
                    return false;
                }
                if (pstrNumber.IndexOfAny(new char[] { '/' }) >= 0)
                {
                    return false;
                }
                if (pstrNumber.IndexOfAny(new char[] { '.' }) >= 0)
                {
                    return false;
                }
                if (pstrNumber.IndexOfAny(new char[] { '%' }) >= 0)
                {
                    return false;
                }
                if (pstrNumber.IndexOfAny(new char[] { ',' }) >= 0)
                {
                    return false;
                }

                string lstrUpperWK = pstrNumber.ToUpper();
                if (lstrUpperWK.IndexOfAny(new char[] { 'D' }) >= 0)
                {
                    return false;
                }
                if (lstrUpperWK.IndexOfAny(new char[] { 'E' }) >= 0)
                {
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
        /// 指定文字列の郵便番号(半角)チェック
        /// </summary>
        /// <param name="pstrPostNo">チェック文字列</param>
        /// <param name="pintMaxLenB">全バイト数</param>
        /// <returns>true:文字列が郵便番号 false:それ以外</returns>
        public static bool IsPostNo(string pstrPostNo, int pintMaxLenB)
        {
            int lintPostLenB = 0;

            try
            {
                int lintPostLen = pstrPostNo.Length;

                if (lintPostLen > pintMaxLenB)
                {
                    MessageBox.Show("入力文字数がオーバしています。", "入力確認",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                lintPostLenB = Ans.AnsLenB(pstrPostNo);
                if (lintPostLen != lintPostLenB)
                {
                    MessageBox.Show("全角文字が入力されています。", "入力確認",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                string lstrWK = "";
                for (int lintLoop = 0; lintLoop < lintPostLenB; lintLoop++)
                {
                    lstrWK = Ans.AnsMidB(pstrPostNo, lintLoop, 1);
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
                                return false;
                            }
                            break;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 指定文字列の全角チェック（文字数チェックあり）
        /// </summary>
        /// <param name="pstrTarget">チェック文字列</param>
        /// <param name="pintMaxLenB">全バイト数</param>
        /// <returns>true:文字列が全角文字 false:それ以外</returns>
        public static bool IsWideString(string pstrTarget, int pintMaxLenB)
        {
            int lintPostLenB = 0;

            try
            {
                int lintPostLen = pstrTarget.Length;

                lintPostLenB = Ans.AnsLenB(pstrTarget);
                if ((lintPostLen * 2) != lintPostLenB)
                {
                    MessageBox.Show("半角文字が入力されています。", "入力確認",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if (lintPostLenB > pintMaxLenB)
                {
                    MessageBox.Show("入力文字数がオーバしています。", "入力確認",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        /// 指定文字列の全角チェック（文字数チェックなし）
        /// </summary>
        /// <param name="pstrTarget">チェック文字列</param>
        /// <returns>true:文字列が全角文字 false:それ以外</returns>
        public static bool IsWideString(string pstrTarget)
        {
            int lintPostLenB = 0;

            try
            {
                int lintPostLen = pstrTarget.Length;
                lintPostLenB = Ans.AnsLenB(pstrTarget);

                if ((lintPostLen * 2) != lintPostLenB)
                {
                    MessageBox.Show("半角文字が入力されています。", "入力確認",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        /// 指定文字列のバイトチェック
        /// </summary>
        /// <param name="pstrChk">チェック文字列</param>
        /// <param name="pintLenB">チェック文字数</param>
        /// <returns>true:チェック文字列がチェック文字数以下 false:それ以外</returns>
        public static bool IsLenB(string pstrChk, int pintLenB)
        {
            try
            {
                if (Ans.AnsLenB(pstrChk) > pintLenB)
                {
                    MessageBox.Show("入力文字数がオーバしています。", "入力確認",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 各変換をnullチェック、""チェック後に実行します
    /// </summary>
    public class Conv
    {
        /// <summary>
        /// int型変換処理
        /// </summary>
        /// <param name="pstrData">変換前文字列</param>
        /// <returns>int値(変換できないときは0)</returns>
        public static int ToInt(string pstrData)
        {
            try
            {
                if (pstrData == "" || pstrData == null)
                {
                    return 0;
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

        /// <summary>
        /// int型変換処理
        /// </summary>
        /// <param name="pobjData">変換前オブジェクト</param>
        /// <returns>数値(nullまたは変換できないときは0)</returns>
        public static int ToInt(object pobjData)
        {
            try
            {
                if (pobjData == null)
                {
                    return 0;
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

        /// <summary>
        /// boolt型変換処理
        /// </summary>
        /// <param name="pstrData">変換前文字列</param>
        /// <returns>bool値(変換できないときはfalse)</returns>
        public static bool ToBool(string pstrData)
        {
            try
            {
                if (pstrData == "" || pstrData == null)
                {
                    return false;
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

        /// <summary>
        /// string型変換処理
        /// </summary>
        /// <param name="lobjData">変換前オブジェクト</param>
        /// <returns>string文字列(変換できないときは空文字列)</returns>
        public static string ToString(object lobjData)
        {
            try
            {
                if (lobjData == null)
                {
                    return "";
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

        /// <summary>
        /// カンマ編集（小数部第2位まで）
        /// </summary>
        /// <param name="price">数値文字列</param>
        /// <returns>カンマ編集数値文字列</returns>
        public string cnvStrThousandsPrice(string price)
        {
            string str_price = price;
            decimal dec_price = 0m;

            if (!decimal.TryParse(str_price, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, null, out dec_price))
            {
                str_price = "0";
            }

            if (dec_price != 0)
            {
                str_price = dec_price.ToString("#,0.00");
            }

            return str_price;
        }

        /// <summary>
        /// カンマ除去
        /// </summary>
        /// <param name="price">カンマ編集数値文字列</param>
        /// <returns>数値文字列</returns>
        public string cnvStrDecimalPrice(string price)
        {
            string str_price = price;
            decimal dec_price = 0m;

            if (!decimal.TryParse(str_price, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, null, out dec_price))
            {
                str_price = "0";
            }

            if (dec_price != 0)
            {
                str_price = dec_price.ToString();
            }

            return str_price;
        }

        /// <summary>
        /// 文字列編集（半角スペース変換、スペース削除、カンマスペース変換、改行スペース変換）
        /// </summary>
        /// <param name="moji">編集対象文字列</param>
        /// <returns>編集後文字列</returns>
        public string replaceKinshiChar(string moji)
        {
            string strwk = moji;

            if (strwk.Trim().Length > 0)
            {
                strwk = strwk.Replace("　", " ");
                strwk = strwk.Trim();
                strwk = strwk.Replace(",", " ");
                strwk = strwk.Replace(Environment.NewLine, " ");
            }
            else
            {
                strwk = "";
            }
            return strwk;
        }
    }
}
