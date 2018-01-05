using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using System.Runtime.InteropServices;

namespace B2.Com
{
    //******************************************************************************
    /// <summary>
    /// ファイル閲覧コントロール
    /// </summary>
    //******************************************************************************
    public partial class ctlWebBrowser : WebBrowser
    {
        #region ローカルAPI定義
        //******************************************************************************
        // ローカルAPI定義
        //******************************************************************************
        [DllImport("ole32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern void CoFreeUnusedLibraries();
        #endregion

        #region パラメータ定義
        //******************************************************************************
        // パラメータ定義
        //******************************************************************************
        //**********************************************************************
        /// <summary>プレビューファイル名</summary>
        public string ViewFileName
        {
            get
            {
                return mstrViewFileName;
            }
        }
        private string mstrViewFileName = "";
        //**********************************************************************
        /// <summary>文字色</summary>
        public Color ForeColor_SM
        {
            get
            {
                return mobjForeColor;
            }
            set
            {
                mobjForeColor = value;
                this.ForeColor = value;
            }
        }
        private Color mobjForeColor = Color.Black;
        //**********************************************************************
        /// <summary>背景色</summary>
        public Color BackColor_SM
        {
            get
            {
                return mobjBackColor;
            }
            set
            {
                mobjBackColor = value;
                this.BackColor = value;
            }
        }
        private Color mobjBackColor = Color.White;
        //**********************************************************************
        #endregion

        #region コンストラクタ
        //******************************************************************************
        // コンストラクタ
        //******************************************************************************
        //**********************************************************************
        /// <summary>
        /// コンストラクタ
        /// </summary>
        //**********************************************************************
        public ctlWebBrowser()
        {
            InitializeComponent();
            ViewFile("");
        }
        #endregion

        #region グローバル関数定義
        //******************************************************************************
        // グローバル関数定義
        //******************************************************************************
        //**********************************************************************
        /// <summary>
        /// ファイルプレビュー表示
        /// </summary>
        /// <param name="pstrFileName">ファイル名</param>
        /// <returns>true:正常 false:異常</returns>
        //**********************************************************************
        public bool ViewFile(string pstrFileName)
        {
            try
            {
                bool lblnBlank = false;
                string lstrBlankMsg = "";
 
                //--------------------------------------
                // ファイル名保存
                //--------------------------------------
                mstrViewFileName = pstrFileName;

                //--------------------------------------
                // 表示ファイル有無確認
                //--------------------------------------
                if (!System.IO.File.Exists(pstrFileName))
                {
                    lblnBlank = true;
                    if (pstrFileName.Trim() != "")
                    {
                        lstrBlankMsg = "ファイルが見つかりません。 \"" + pstrFileName + "\" ";
                    }
                }

                //--------------------------------------
                // WebBrowser 表示可否確認
                //--------------------------------------
                if (!lblnBlank)
                {
                    //--------------------------------------
                    // 拡張子確認
                    //--------------------------------------
                    switch (System.IO.Path.GetExtension(pstrFileName).ToLower())
                    {
                        //--------------------------------------
                        // WebBrowser表示可能(と思われる)ファイル
                        //--------------------------------------
                        case ".htm":
                        case ".html":
                        case ".shtml":
                        case ".mht":
                        case ".xml":
                        case ".xhtml":
                        case ".xht":
                        case ".txt":
                        case ".gif":
                        case ".jpg":
                        case ".jpeg":
                        case ".jpe":
                        case ".jfif":
                        case ".png":
                        case ".bmp":
                        case ".dib":
                        case ".rle":
                        case ".ico":
                        case ".ai":
                        case ".art":
                        case ".cam":
                        case ".cdr":
                        case ".cgm":
                        case ".cmp":
                        case ".dpx":
                        case ".fal":
                        case ".q0":
                        case ".fpx":
                        case ".j6i":
                        case ".mac":
                        case ".mag":
                        case ".maki":
                        case ".mng":
                        case ".pcd":
                        case ".pct":
                        case ".pic":
                        case ".pict":
                        case ".pcx":
                        case ".pmp":
                        case ".pnm":
                        case ".psd":
                        case ".ras":
                        case ".sj1":
                        case ".tiff":
                        case ".nsk":
                        case ".tga":
                        case ".wmf":
                        case ".wpg":
                        case ".xbm":
                        case ".xpm":
                        case ".pdf":
                            break;
                        //--------------------------------------
                        // WebBrowser表示不可ファイル
                        //--------------------------------------
                        case ".tif":
                        //--------------------------------------
                        // Microsoft Office ファイル
                        //--------------------------------------
                        case ".doc":
                        case ".docx":
                        case ".docm":
                        case ".xls":
                        case ".xlsx":
                        case ".xlsm":
                        case ".ppt":
                        case ".pptx":
                        case ".pptm":
                        case ".mdb":
                        case ".accdb":
                        case ".csv":
                        //--------------------------------------
                        // 実行ファイル
                        //--------------------------------------
                        case ".exe":
                        case ".dll":
                        case ".com":
                        case ".ocx":
                        case ".sys":
                        case ".a":
                        case ".so":
                        //--------------------------------------
                        // 圧縮ファイル
                        //--------------------------------------
                        case ".lzh":
                        case ".zip":
                        case ".cab":
                        case ".tar":
                        case ".gz":
                        case ".tgz":
                        case ".hqx":
                        case ".sit":
                        case ".z":
                        case ".uu":
                            // 白紙表示
                            lstrBlankMsg = System.IO.Path.GetFileName(pstrFileName);
                            lblnBlank = true;
                            break;
                        //--------------------------------------
                        // その他
                        //--------------------------------------
                        default:
                            // テキストファイルか確認
                            if (!mfnc_IsTextFile(pstrFileName))
                            {
                                // バイナリファイルならば白紙表示
                                lstrBlankMsg = System.IO.Path.GetFileName(pstrFileName);
                                lblnBlank = true;
                            }
                            break;
                    }
                }

                //--------------------------------------
                // 白紙表示か確認
                //--------------------------------------
                string lstrURL = pstrFileName;
                string lstrHTML = "";
                if (lblnBlank)
                {
                    //--------------------------------------
                    // 白紙表示の場合は以下のHTMLを表示
                    //--------------------------------------
                    lstrURL = "about:blank";
                    lstrHTML = "";
                    lstrHTML += "<html><head><title></title><style type=\"text/css\">body {";
                    lstrHTML += "background-color: " + String.Format("#{0:X2}{1:X2}{2:X2}", mobjBackColor.R, mobjBackColor.G, mobjBackColor.B) + ";";
                    lstrHTML += "color: " + String.Format("#{0:X2}{1:X2}{2:X2}", mobjForeColor.R, mobjForeColor.G, mobjForeColor.B) + ";";
                    lstrHTML += "}</style></head><body><div>";
                    lstrHTML += System.Web.HttpUtility.HtmlEncode(lstrBlankMsg);
                    lstrHTML += "</div></body></html>";
                }

                //--------------------------------------
                // 表示
                //--------------------------------------
                this.Navigate(lstrURL);
                if (lstrHTML != "")
                {
                    this.DocumentText =lstrHTML;
                }

                //--------------------------------------
                // ごみメモリを解放する
                //   ※コレが無いとプログラム起動中に表示したファイル全てがプログラムを終了するまで削除できない
                //--------------------------------------
                Application.DoEvents();
                CoFreeUnusedLibraries();

                return true;
            }
            catch
            {
                return false;
            }
        }

        //**********************************************************************
        /// <summary>
        /// テキストファイル確認
        /// </summary>
        /// <param name="pstrFileName">ファイル名</param>
        /// <returns>true:テキストファイル false:バイナリファイル</returns>
        //**********************************************************************
        private bool mfnc_IsTextFile(string pstrFileName)
	    {
            try
            {
                using (System.IO.FileStream lobjFileStream = new System.IO.FileStream(pstrFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    byte[] lbytData = new byte[1];
                    while (lobjFileStream.Read(lbytData, 0, lbytData.Length) > 0)
                    {
                        if (lbytData[0] == 0)
                        {
                            return false;
                        }
                    }
                }
	            return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
