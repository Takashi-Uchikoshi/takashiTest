using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace B2.Com
{
    /// <summary>
    /// レジストリ操作クラス
    /// </summary>
    class RegistryControler
    {
        /// <summary>
        /// レジストリ値取得処理
        /// </summary>
        /// <param name="RegKey">値を取得するレジストリキー名</param> 
        /// <param name="RegValueName">値を取得する値名</param> 
        /// <returns>レジストリ値(値がないときは空を返す)</returns>
        /// <remark>レジストリから値をします</remark>
        public static string GetRegistry(string RegKey, string RegValueName)
        {
            try
            {
                RegistryKey readRegKey = Registry.CurrentUser.OpenSubKey(RegKey);

                string lstrRegVal = (string)readRegKey.GetValue(RegValueName);
                if (lstrRegVal == null)
                    lstrRegVal = "";

                readRegKey.Close();

                return lstrRegVal;
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// レジストリ値設定処理
        /// </summary>
        /// <param name="RegKey">値を設定するレジストリキー名</param> 
        /// <param name="RegValueName">設定する値名</param> 
        /// <param name="SetValue">設定する値</param> 
        /// <returns>true:正常終了 false:エラー</returns>
        /// <remark>レジストリに値を設定します</remark>
        public static bool SetRegistry(string RegKey, string RegValueName, string SetValue)
        {
            try
            {
                RegistryKey editRegKey = Registry.CurrentUser.CreateSubKey(RegKey);

                editRegKey.SetValue(RegValueName, SetValue);

                editRegKey.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// レジストリ値削除
        /// </summary>
        /// <param name="DelRegKey">削除する値があるレジストリキー名</param>
        /// <returns>true：正常終了 false：エラー</returns>
        public static bool DeleteRegistry(string DelRegKey)
        {
            RegistryKey editRegKey = Registry.CurrentUser.OpenSubKey(DelRegKey, true);
            if (editRegKey == null)
                return true;

            string[] valueNames = editRegKey.GetValueNames();
            foreach (string vname in valueNames)
                editRegKey.DeleteValue(vname, false);

            editRegKey.Close();

            return true;
        }
    }
}
