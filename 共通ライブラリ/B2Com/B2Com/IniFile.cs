using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

/// <summary>
/// ＩＮＩファイル操作用クラス
/// </summary>
class IniFileControler
{
    /// <summary>バッファ長</summary>
    private const int bufferTyo = 1024; // 256文字

    /// <summary>
    /// API宣言
    /// * iniﾌｧｲﾙ読込み関数宣言
    /// </summary>
    [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
    private static extern uint GetPrivateProfileString(
          string lpApplicationName
        , string lpKeyName
        , string lpDefault
        , System.Text.StringBuilder StringBuilder
        , uint nSize
        , string lpFileName);

    /// <summary>
    /// API宣言
    /// * iniﾌｧｲﾙ書込み関数宣言
    /// </summary>
    [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
    private static extern uint WritePrivateProfileString(
          string lpApplicationName
        , string lpEntryName
        , string lpEntryString
        , string lpFileName);

    /// <summary>iniファイル名（フルパス）</summary>
    private string iniFileMei;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="fileMei">iniファイルのフルパス</param>
    public IniFileControler(string fileMei)
    {
        this.iniFileMei = fileMei;
    }

    /// <summary>
    /// リソース開放
    /// </summary>
     public void Close()
    {
        // Finalize();
    }

    /// <summary>
    /// iniファイル情報取得
    /// </summary>
    /// <param name="lpszSection">セクション名</param>
    /// <param name="lpszEntry">キー名</param>
    /// <param name="lpszDefault">デフォルト値</param>
    /// <returns>iniファイル情報</returns>
    public string GetIniString(string lpszSection, string lpszEntry, string lpszDefault)
    {
        StringBuilder sb = new StringBuilder(bufferTyo);
        uint ret = GetPrivateProfileString(lpszSection, lpszEntry, lpszDefault, sb, Convert.ToUInt32(sb.Capacity), this.iniFileMei);
        return sb.ToString();
    }

    /// <summary>
    /// iniファイル情報取得
    /// </summary>
    /// <param name="lpszSection">セクション名</param>
    /// <param name="lpszEntry">キー名</param>
    /// <returns>iniファイル情報</returns>
    public string GetIniString(string lpszSection, string lpszEntry)
    {
        return GetIniString(lpszSection, lpszEntry, null);
    }

    /// <summary>
    /// Set ini String情報 (iniファイル情報書込メソッド)
    /// </summary>
    /// <param name="lpszSection">セクション名</param>
    /// <param name="lpszEntry">キー名</param>
    /// <param name="lpszString">iniファイル情報</param>
    /// <returns>true:正常終了 false:エラー</returns>
    public bool SetIniString(string lpszSection, string lpszEntry, string lpszString)
    {
        uint ret = WritePrivateProfileString(lpszSection, lpszEntry, lpszString, this.iniFileMei);
        if (ret > 0) return true;
        else return false;
    }
}

