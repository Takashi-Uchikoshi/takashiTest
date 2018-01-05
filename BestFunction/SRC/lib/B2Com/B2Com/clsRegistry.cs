using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2.Com
{
    class clsRegistry
    {
        /// <summary>
        /// レジストリ値取得処理
        /// </summary>
        /// <param name="RegKey">値を取得するレジストリキー名</param> 
        /// <param name="RegValueName">値を取得する値名</param> 
        /// <remark>レジストリから値をします</remark>
        public static string GetRegistry(string RegKey, string RegValueName)
        {
            try
            {
                //キー（HKEY_CURRENT_USER\Software\test\sub）を開く
                //Microsoft.Win32.RegistryKey regkey =
                //    Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\test\sub");
                Microsoft.Win32.RegistryKey readRegKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(RegKey);

                string lstrRegVal = (string)readRegKey.GetValue(RegValueName);
                if (lstrRegVal == null)
                    lstrRegVal = "";    // 取得できなかったときは空を返す

                readRegKey.Close();

                return lstrRegVal;
            }
            catch (Exception)
            {
                return "";
            }
        }

        ///
        /// <summary>
        /// レジストリ値設定処理
        /// </summary>
        /// <param name="RegKey">値を設定するレジストリキー名</param> 
        /// <param name="RegValueName">設定する値名</param> 
        /// <param name="SetValue">設定する値</param> 
        /// <remark>レジストリに値を設定します</remark>
        public static bool SetRegistry(string RegKey, string RegValueName, string SetValue)
        {
            try
            {
                Microsoft.Win32.RegistryKey editRegKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(RegKey);

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
            //レジストリからの読み取り
            Microsoft.Win32.RegistryKey editRegKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(DelRegKey, true);
            if (editRegKey == null)
                return true;

            //すべてのキー名を取得
            string[] valueNames = editRegKey.GetValueNames();
            //削除する
            foreach (string vname in valueNames)
                editRegKey.DeleteValue(vname, false);

            //閉じる
            editRegKey.Close();

            return true;
        }
    }
}
