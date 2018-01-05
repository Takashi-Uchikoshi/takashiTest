using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GrapeCity.Licenses;              
using GrapeCity.ActiveReports;         
using GrapeCity.ActiveReports.Document;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.SectionReportModel;

namespace B2.Com
{
    /// <summary>
    /// ActiveReports設定クラス
    /// INIテーブルからLabel、TextBoxコントロールの位置やフォントなどを設定します
    /// </summary>
    public class clsAReport : IDisposable
    {

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public clsAReport()
        {
        }
        #endregion

        /// <summary>
        /// オブジェクト解放
        /// </summary>
        public void Dispose()
        {
        }


        /// <summary>
        /// フォント設定
        /// フォント、ポイント、水平表示位置、色を設定します
        /// </summary>
        /// <param name="control">ActiveReportsコントロール</param>
        /// <param name="data">iniテーブルデータ</param>
        private void SetFontData(ARControl control, string data)
        {
            if(data.Length == 0)
            {
                return;
            }

            float fontSize;
            bool alignSet = false;
            TextAlignment align = TextAlignment.Left;

            string[] fontData = data.Split(',');
            if(fontData.GetLength(0) < 2)
            {
                return;
            }
            if(!float.TryParse(fontData[1], out fontSize))
            {
                return;
            }
            if(fontData[0].Length == 0 || fontSize < 1f)
            {
                return;
            }
            if(2 < fontData.GetLength(0))
            {
                alignSet = true;
                switch(fontData[3])
                {
                    case "1":
                        align = TextAlignment.Left;
                        break;
                    case "2":
                        align = TextAlignment.Right;
                        break;
                    case "3":
                        align = TextAlignment.Center;
                        break;
                    case "4":
                        align = TextAlignment.Justify;
                        break;
                    default:
                        alignSet = false;
                        break;
                }
            }

            if(control is Label)
            {
                Label lbl = (Label)control;
                lbl.Font = new System.Drawing.Font(fontData[0], fontSize);
                if(alignSet)
                {
                    lbl.Alignment = align;
                }
                if(3 < fontData.GetLength(0))
                {
                    lbl.ForeColor = ColorTranslator.FromHtml(fontData[3]);
                }
            }
            else if(control is TextBox)
            {
                TextBox tbx = (TextBox)control;
                tbx.Font = new System.Drawing.Font(fontData[0], fontSize);
                if(alignSet)
                {
                    tbx.Alignment = align;
                }
                if(3 < fontData.GetLength(0))
                {
                    tbx.ForeColor = ColorTranslator.FromHtml(fontData[3]);
                }
            }
        }

        /// <summary>
        /// 位置設定
        /// 位置、サイズを設定します
        /// </summary>
        /// <param name="control">ActiveReportsコントロール</param>
        /// <param name="data">iniテーブルデータ</param>
        private void SetLocationData(ARControl control, string data)
        {
            if(data.Length == 0)
            {
                return;
            }

            string[] locnData = data.Split(',');
            float[] pos = new float[4];
            if(locnData.GetLength(0) < 4)
            {
                return;
            }
            for(int i = 0; i < 4; i++)
            {
                if(!float.TryParse(locnData[i], out pos[i]))
                {
                    return;
                }
                pos[i] = GrapeCity.ActiveReports.SectionReport.CmToInch(pos[i]);
            }

            if(control is Label)
            {
                Label lbl = (Label)control;
                lbl.Location = new PointF(pos[0], pos[1]);
                lbl.Size = new SizeF(pos[2], pos[3]);
            }
            else if(control is TextBox)
            {
                TextBox tbx = (TextBox)control;
                tbx.Location = new PointF(pos[0], pos[1]);
                tbx.Size = new SizeF(pos[2], pos[3]);
            }
        }
    }

    /// <summary>
    /// 用紙サイズクラス
    /// </summary>
    public class PaperSize
    {
        /// <summary>
        /// 用紙サイズ取得
        /// </summary>
        /// <param name="size">用紙名</param>
        /// <returns>用紙サイズ</returns>
        public static System.Drawing.Printing.PaperKind GetPaperSize(string size)
        {
            switch(size)
            {
                case "A4":
                    return System.Drawing.Printing.PaperKind.A4;
                case "A5":
                    return System.Drawing.Printing.PaperKind.A5;
                case "B4":
                    return System.Drawing.Printing.PaperKind.B4;
                case "B5":
                    return System.Drawing.Printing.PaperKind.B5;
                case "A3":
                    return System.Drawing.Printing.PaperKind.A3;
                case "A6":
                    return System.Drawing.Printing.PaperKind.A6;
                case "ﾊｶﾞｷ":
                    return System.Drawing.Printing.PaperKind.JapanesePostcard;
            }
            return System.Drawing.Printing.PaperKind.A4;
        }
    }

}
