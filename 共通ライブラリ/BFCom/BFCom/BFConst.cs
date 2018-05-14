using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2.BestFunction
{
    //**********************************************************************
    /// <summary>
    /// 端数区分
    /// </summary>
    //**********************************************************************
    public enum HasuKubun
    {
        /// <summary>四捨五入</summary>
        ShishaGonyu = 0,
        /// <summary>切り捨て</summary>
        KiriSute,
        /// <summary>切り上げ</summary>
        KiriAge
    }

    //**********************************************************************
    /// <summary>
    /// 端数区分補助クラス
    /// </summary>
    //**********************************************************************
    public static class HasuKubunExt
    {
        //**********************************************************************
        /// <summary>
        /// 端数区分表示名称
        /// </summary>
        /// <param name="pHasuKubun">端数区分</param>
        /// <returns>端数区分表示名称</returns>
        //**********************************************************************
        public static string DisplayName(string pHasuKubun)
        {
            int iHasuKubun;
            if (int.TryParse(pHasuKubun, out iHasuKubun) == false)
            {
                return "";
            }
            return DisplayName(iHasuKubun);
        }

        //**********************************************************************
        /// <summary>
        /// 端数区分表示名称
        /// </summary>
        /// <param name="pHasuKubun">端数区分</param>
        /// <returns>端数区分表示名称</returns>
        //**********************************************************************
        public static string DisplayName(int pHasuKubun)
        {
            try
            {
                return DisplayName((HasuKubun)pHasuKubun);
            }
            catch
            {
                return "";
            }
        }

        //**********************************************************************
        /// <summary>
        /// 端数区分表示名称
        /// </summary>
        /// <param name="pHasuKubun">端数区分</param>
        /// <returns>端数区分表示名称</returns>
        //**********************************************************************
        public static string DisplayName(HasuKubun pHasuKubun)
        {
            string[] Names = {     "四捨五入"
                                 , "切り捨て"
                                 , "切り上げ" 
                             };
            return Names[(int)pHasuKubun];
        }
    }
}
