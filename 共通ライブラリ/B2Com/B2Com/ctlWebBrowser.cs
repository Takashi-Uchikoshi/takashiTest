using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace B2.Com
{
    /// <summary>
    /// ファイル閲覧コントロール
    /// </summary>
    public partial class ctlWebBrowser : WebBrowser
    {
        [DllImport("ole32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern void CoFreeUnusedLibraries();

        /// <summary>プレビューファイル名</summary>
        public string PreviewFileMei
        {
            get
            {
                return previewFileMei;
            }
        }
        private string previewFileMei = "";

        /// <summary>文字色</summary>
        public Color HtmlMojiColor
        {
            get
            {
                return htmlMojiColor;
            }
            set
            {
                htmlMojiColor = value;
                this.ForeColor = value;
            }
        }
        private Color htmlMojiColor = Color.Black;
        
        /// <summary>背景色</summary>
        public Color HtmlBackgroundColor
        {
            get
            {
                return htmlBackgroundColor;
            }
            set
            {
                htmlBackgroundColor = value;
                this.BackColor = value;
            }
        }
        private Color htmlBackgroundColor = Color.White;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ctlWebBrowser()
        {
            InitializeComponent();
            this.PreviewFile("");
        }

        /// <summary>
        /// ファイルプレビュー表示
        /// </summary>
        /// <param name="pstrFileName">ファイル名</param>
        /// <returns>true:正常 false:異常</returns>
        public bool PreviewFile(string pstrFileName)
        {
            try
            {
                bool lblnBlank = false;
                string lstrBlankMsg = "";
 
                this.previewFileMei = pstrFileName;

                if (!File.Exists(pstrFileName))
                {
                    lblnBlank = true;
                    if (pstrFileName.Trim() != "")
                    {
                        lstrBlankMsg = "ファイルが見つかりません。 \"" + pstrFileName + "\" ";
                    }
                }

                // WebBrowser 表示可否確認
                if (!lblnBlank)
                {
                    switch (Path.GetExtension(pstrFileName).ToLower())
                    {
                        // WebBrowser表示可能(と思われる)ファイル
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

                        // WebBrowser表示不可ファイル
                        case ".tif":
                        // Microsoft Office ファイル
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
                        // 実行ファイル
                        case ".exe":
                        case ".dll":
                        case ".com":
                        case ".ocx":
                        case ".sys":
                        case ".a":
                        case ".so":
                        // 圧縮ファイル
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
                            lstrBlankMsg = Path.GetFileName(pstrFileName);
                            lblnBlank = true;
                            break;

                        // その他
                        default:
                            // テキストファイルか確認してバイナリファイルならば白紙表示
                            if (!IsTextFile(pstrFileName))
                            {
                                lstrBlankMsg = Path.GetFileName(pstrFileName);
                                lblnBlank = true;
                            }
                            break;
                    }
                }

                // 白紙表示のときは空のHTMLを表示
                string lstrURL = pstrFileName;
                string lstrHTML = "";
                if (lblnBlank)
                {
                    lstrURL = "about:blank";
                    lstrHTML = "";
                    lstrHTML += "<html><head><title></title><style type=\"text/css\">body {";
                    lstrHTML += "background-color: " + String.Format("#{0:X2}{1:X2}{2:X2}", this.htmlBackgroundColor.R, this.htmlBackgroundColor.G, this.htmlBackgroundColor.B) + ";";
                    lstrHTML += "color: " + String.Format("#{0:X2}{1:X2}{2:X2}", this.htmlMojiColor.R, this.htmlMojiColor.G, this.htmlMojiColor.B) + ";";
                    lstrHTML += "}</style></head><body><div>";
                    lstrHTML += System.Web.HttpUtility.HtmlEncode(lstrBlankMsg);
                    lstrHTML += "</div></body></html>";
                }

                this.Navigate(lstrURL);
                if (lstrHTML != "")
                {
                    this.DocumentText = lstrHTML;
                }

                // プログラム起動中に表示したファイルを削除できるようにメモリを解放する
                Application.DoEvents();
                CoFreeUnusedLibraries();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// テキストファイル確認
        /// </summary>
        /// <param name="pstrFileName">ファイル名</param>
        /// <returns>true:テキストファイル false:バイナリファイル</returns>
        private bool IsTextFile(string pstrFileName)
	    {
            try
            {
                using (FileStream lobjFileStream = new FileStream(pstrFileName, FileMode.Open, FileAccess.Read))
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
    }
}
