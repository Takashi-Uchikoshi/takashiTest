using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

//*******************************************************************************
//* ＩＮＩファイル操作用クラス
//*******************************************************************************
//* 使用例(生成) *
//* cIni m_cIni = new cIni(ファイル名)
//* 取得
//* m_cIni.GetIniString(セクション名, キー名, 取得失敗時の戻り値[省略可])
//* 書込
//* m_cIni.SetIniString(セクション名, キー名, 書き込む値)
//******************************************************************************* 
class clsIniFile
{
    /// <summary>
    /// * DEFINE
    /// </summary>
    private const int BUFF_LEN = 1024; // 256文字

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

    //
    // メンバ変数
    //
    private string m_strIniFileName;

    //
    // メンバ関数
    //

    /// インスタンス作成
    /// * 引数 : iniファイルのフルパス
    public clsIniFile(string strIniFileName)
    {
        // メンバ変数にセット
        m_strIniFileName = strIniFileName;
    }

    /// リソースを手動で開放
    public void Close()
    {
        // Finalize();
    }

    // リソースを解放(必要が無くなったら、自動的に開放される)
    // void Finalize() {}

    // Get ini String情報 (iniファイル情報取得メソッド)
    //   MSDNによると、「C# 言語では、既定の引数はサポートされていません。」との事なので、オーバーライドした方がいい？
    //   ということで、「GetIniString」を第三引数の省略を可能にしています
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lpszSection"></param>
    /// <param name="lpszEntry"></param>
    /// <param name="lpszDefault"></param>
    /// <returns></returns>
    public string GetIniString(string lpszSection, string lpszEntry, string lpszDefault)
    {
        StringBuilder sb = new StringBuilder(BUFF_LEN);
        uint ret = GetPrivateProfileString(lpszSection, lpszEntry, lpszDefault, sb, Convert.ToUInt32(sb.Capacity), m_strIniFileName);
        return sb.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lpszSection"></param>
    /// <param name="lpszEntry"></param>
    /// <returns></returns>
    public string GetIniString(string lpszSection, string lpszEntry)
    {
        return GetIniString(lpszSection,lpszEntry,null);
    }

    /// <summary>
    /// Set ini String情報 (iniファイル情報書込メソッド)
    /// </summary>
    /// <param name="lpszSection"></param>
    /// <param name="lpszEntry"></param>
    /// <param name="lpszString"></param>
    /// <returns></returns>
    public bool SetIniString(string lpszSection, string lpszEntry, string lpszString)
    {
        uint ret = WritePrivateProfileString(lpszSection, lpszEntry, lpszString, m_strIniFileName);
        if (ret > 0) return true;
        else return false;
    }
    
}

