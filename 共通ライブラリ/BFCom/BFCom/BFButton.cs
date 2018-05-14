using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B2.BestFunction
{
    //******************************************************************************
    /// <summary>
    /// BestFunctionボタンクラス
    /// </summary>
    //******************************************************************************
    public partial class BFButton : Button
    {
        #region グローバル連番定義
        //******************************************************************************
        // グローバル連番定義
        //******************************************************************************
        //**********************************************************************
        /// <summary>
        /// カラー種類連番
        /// </summary>
        //**********************************************************************
        public enum ColorTypeRenban
        {
            /// <summary>前景色：水</summary>
            ForeColorWater = 0,
            /// <summary>前景色：桃</summary>
            ForeColorPink,
            /// <summary>前景色：ピスタチオ緑</summary>
            ForeColorPistachio,
            /// <summary>前景色：暗灰</summary>
            ForeColorDarkGray,
            /// <summary>前景色：灰</summary>
            ForeColorGray,
            /// <summary>前景色：橙</summary>
            ForeColorOrange,
            /// <summary>前景色：赤</summary>
            ForeColorRed,

            /// <summary>背景色：水</summary>
            BackColorWater,
            /// <summary>背景色：桃</summary>
            BackColorPink,
            /// <summary>背景色：ピスタチオ緑</summary>
            BackColorPistachio,
            /// <summary>背景色：暗灰</summary>
            BackColorDarkGray,
            /// <summary>背景色：灰</summary>
            BackColorGray,
            /// <summary>背景色：橙</summary>
            BackColorOrange,
            /// <summary>背景色：赤</summary>
            BackColorRed,
        }
        #endregion

        #region ローカル変数定義
        //******************************************************************************
        // ローカル変数定義
        //******************************************************************************
        //**********************************************************************
        /// <summary>
        /// 前景色
        /// </summary>
        //**********************************************************************
        private Color[] mForeColor = new Color[]
        {
            BFColor.Water
          , BFColor.Pink
          , BFColor.Pistachio
          , BFColor.DarkGray
          , BFColor.Gray
          , BFColor.Orange
          , BFColor.Red

          , BFColor.White
          , BFColor.White
          , BFColor.White
          , BFColor.White
          , BFColor.White
          , BFColor.White
          , BFColor.White
        };

        //**********************************************************************
        /// <summary>
        /// 背景色
        /// </summary>
        //**********************************************************************
        private Color[] mBackColor = new Color[]
        {
            BFColor.White
          , BFColor.White
          , BFColor.White
          , BFColor.White
          , BFColor.White
          , BFColor.White
          , BFColor.White

          , BFColor.Water
          , BFColor.Pink
          , BFColor.Pistachio
          , BFColor.DarkGray
          , BFColor.Gray
          , BFColor.Orange
          , BFColor.Red
        };
        #endregion



        #region パラメータ定義
        //******************************************************************************
        // パラメータ定義
        //******************************************************************************
        //**********************************************************************
        /// <summary>
        /// カラータイプ
        /// </summary>
        //**********************************************************************
        public ColorTypeRenban ColorType
        {
            get { return _ColorType; }
            set
            {
                _ColorType = value;
                base.ForeColor = mForeColor[(int)_ColorType];
                base.BackColor = mBackColor[(int)_ColorType];
            }
        }
        private ColorTypeRenban _ColorType = ColorTypeRenban.ForeColorDarkGray;

        //**********************************************************************
        /// <summary>
        /// コントロール前景色(編集不可となるよう制御)
        /// </summary>
        //**********************************************************************
        new public Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = mForeColor[(int)_ColorType];
            }
        }

        //**********************************************************************
        /// <summary>
        /// コントロール背景色(編集不可となるよう制御)
        /// </summary>
        //**********************************************************************
        new public Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = mBackColor[(int)_ColorType];
            }
        }

        //**********************************************************************
        /// <summary>
        /// コントロール外観(編集不可となるよう制御)
        /// </summary>
        //**********************************************************************
        new public FlatStyle FlatStyle
        {
            get { return base.FlatStyle; }
            set 
            {
                base.FlatStyle = FlatStyle.Flat;
            }
        }
        #endregion


        #region コンストラクタ
        //******************************************************************************
        // コンストラクタ
        //******************************************************************************
        //**********************************************************************
        /// <summary>
        /// BestFunctionボタンクラスコンストラクタ
        /// </summary>
        //**********************************************************************
        public BFButton()
        {
            if (Enum.GetNames(typeof(ColorTypeRenban)).Length != mForeColor.Length) { MessageBox.Show("コーディング異常"); }
            if (Enum.GetNames(typeof(ColorTypeRenban)).Length != mBackColor.Length) { MessageBox.Show("コーディング異常"); }
        }
        #endregion
    }
}
