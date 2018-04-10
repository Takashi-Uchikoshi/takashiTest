using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;
using FarPoint.Win.Spread;

// ****************************************************************************
//     修正履歴　　　 : 
//     
// ****************************************************************************

namespace B2.Com
{
    // ****************************************************************************
    // 
    //     ファイル名　　 : clsContrlColor.cs
    //     説明           : カラーコントロール  クラス
    //                       ＜Public処理＞
    // 　　　　　　　　　　　SetFormStyle()        : フォーム      スタイル 
    //                       SetBtnStyle()         : ボタン        スタイル
    //                       SetLblStyle()         : ラベル        スタイル
    //                       SetPanelStyle()       : パネル        スタイル
    //                       SetSpreadStyle()      : スプレッド　  スタイル
    // 　　　　　　　　　　　SetSpreadNamedStyle() : スプレッドNamedStyle　　　　
    //                       SetCheckFlatStyle()   : チェックボックス(FLAT)
    //                       SetRadioFlatStyle()   : ラジオボタン(FLAT)
    //                       SetNormalTehmaStyle() : 共通コントロール
    //                     　SetNameTextStyle()    : 入力←→表示　テキストスタイル
    //                       
    // 
    //     修正履歴　　　 : 
    // 
    // ****************************************************************************

    /// <summary>
    /// コントロールスタイル設定クラス
    /// </summary>
    class ContrlColor
    {
        // ---------------------------------------------------------------------------------
        // ■ テーマカラー[グリーン]
        // ---------------------------------------------------------------------------------      
        /// <summary>通常</summary>
        public static Color ThemaColorTsujyo
        { get { return Color.FromArgb(49, 162, 58); } }

        /// <summary>濃い濃い</summary>
        public static Color ThemaColorDarkDark
        { get { return Color.FromArgb(31, 87, 34); } }

        /// <summary>濃い</summary>
        public static Color ThemaColorDark
        { get { return Color.FromArgb(43, 121, 47); } }

        /// <summary>薄い</summary>
        public static Color ThemaColorLight
        { get { return Color.FromArgb(157, 219, 160); } }

        /// <summary>薄い薄い</summary>
        public static Color ThemaColorLightLight
        { get { return Color.FromArgb(225, 235, 205); } }

        // ---------------------------------------------------------------------------------
        // ■ コントロールカラー
        // ---------------------------------------------------------------------------------      
        /// <summary>コントロールカラー</summary>
        public static Color ControlColor
        {
            // 白っぽいカラーとする
            // ※ GhostWhite,SeaShell,FloralWhite,Snow,IvoryはEnabled=falseの時字が変化するのでNG
            get { return Color.WhiteSmoke; }
        }

        // ---------------------------------------------------------------------------------
        // ■ ボタンスタイル
        // ---------------------------------------------------------------------------------
        /// <summary>ボタンスタイル</summary>
        public enum ButtonStyle
        {
            /// <summary>通常ボタン </summary>
            TsujoButton,
            /// <summary>カラー設定ボタン </summary>
            ThemaColorButton,
        }

        // ---------------------------------------------------------------------------------
        // ■ ラベルスタイル
        // ---------------------------------------------------------------------------------
        /// <summary>ラベルスタイル</summary>
        public enum LabelStyle
        {
            /// <summary>フォームタイトル               (BK:テーマカラー、字：白)</summary>
            FromTitle,
            /// <summary>強調タイトル                   (BK:テーマカラー、字：白)</summary>    
            KyotyoTitle,
            /// <summary>強調タイトル(薄い              (BK:薄いテーマカラー、字：黒)</summary>  
            KyotyoTitleLight,

            /// <summary>明るい項目カラー(通常カラー)   (BK:白系、字：テーマカラー)</summary>
            LightKomokuColor,
            /// <summary>通常項目カラー(濃いカラー)     (BK:白系、字：濃いテーマカラー)</summary>
            TsujoKomokuColor,
            /// <summary>濃い項目カラー(濃い濃いカラー) (BK:白系、字：濃い×２テーマカラー)</summary>
            DarkKomokuColor,

            /// <summary>入力データ 項目名              (BK:白系、字：濃い×２テーマカラー)</summary>
            NyuryokuKomokumei,
            /// <summary>入力データ 名称                (BK:白系、字：濃いテーマカラー)</summary>
            NyuryokuDataMeisho,
        }

        /// <summary>スプレッドNamedStyleスタイル</summary>
        public enum SpreadNameStyle
        {
            /// <summary>ヘッダカラー               (BK:白系、字：濃い×２テーマカラー))</summary>
            HeaderColor,
            /// <summary>タイトル                   (BK:テーマカラー、字：白)</summary>
            TitleColor,
            /// <summary>タイトル文字黒（明るい）   (BK:薄いテーマカラー，字：黒)</summary>
            TitleLightColor,
            /// <summary>通常ラベル(文字黒)         (BK:白、字:黒)</summary>
            LabelColor,
            /// <summary>入力項目タイトル           (BK:白、字:濃い×２テーマカラー)</summary>
            NyuryokuKomokuTitleColor,
            /// <summary>名称ラベル                 (BK:白、字:濃いテーマカラー)</summary>
            MeishoLabelColor,
        }

        /// <summary>
        /// フォームスタイル設定
        /// </summary>
        /// <param name="pobjForm">スタイル設定するフォームコントロール</param>
        public static void SetFormStyle(Control pobjForm)
        {
            pobjForm.BackColor = ControlColor;

            SetAllControlStyle(pobjForm);
        }

        /// <summary>
        /// 全コントロールスタイル設定
        /// </summary>
        /// <param name="pctrl">スタイル設定するコントロール</param>
        private static void SetAllControlStyle(Control pctrl)
        {
            foreach (Control c in pctrl.Controls)
            {
                if (c.Name != "")
                {
                    if (c is TextBox || c is RichTextBox || c is ListBox
                        || c is ComboBox)
                    {
                        // 上記入力系コントロールは設定なし
                    }
                    else
                    {
                        if (c.BackColor == SystemColors.Control)
                        {
                            c.BackColor = ControlColor;
                        }
                    }

                    // すべてのコントロールのスタイルを設定するため再帰呼び出し
                    SetAllControlStyle(c);
                }
            }
        }

        #region ボタンスタイル設定
        /// <summary>
        /// ボタンスタイル設定
        /// </summary>
        /// <param name="pobjButton">スタイル設定するボタン</param>
        /// <param name="penmMode">設定するスタイル指定</param>
        public static void SetButtonStyle(Button pobjButton, ButtonStyle penmMode)
        {
            switch (penmMode)
            {
                case ButtonStyle.TsujoButton:
                    pobjButton.BackColor = ControlColor;
                    pobjButton.FlatStyle = FlatStyle.Flat;
                    // Enabledイベントでカラー変更できるように設定
                    SetButtonColor(pobjButton, ButtonStyle.TsujoButton);
                    pobjButton.EnabledChanged += new EventHandler(btnNormalColor_EnabledChanged);
                    break;

                case ButtonStyle.ThemaColorButton:
                    pobjButton.FlatStyle = FlatStyle.Flat;
                    // Enabledイベントでカラー変更できるように設定
                    SetButtonColor(pobjButton, ButtonStyle.ThemaColorButton);
                    pobjButton.EnabledChanged += new EventHandler(btnThemaColor_EnabledChanged);
                    break;
            }
        }

        /// <summary>
        /// ボタンスタイル カラー設定（Enabledによる切替）
        /// </summary>
        /// <param name="pobjButton">カラー設定するボタン</param>
        /// <param name="penmMode">設定するカラー指定</param>
        private static void SetButtonColor(Button pobjButton, ButtonStyle penmMode)
        {
            switch (penmMode)
            {
                // -------------------------------------------------------------------------
                // ◆ 通常ボタン
                // -------------------------------------------------------------------------
                case ButtonStyle.TsujoButton:
                    if (pobjButton.Enabled == true)
                    {
                        pobjButton.ForeColor = ThemaColorDarkDark;
                        pobjButton.FlatAppearance.BorderColor = ThemaColorDarkDark;
                    }
                    else
                    {
                        pobjButton.ForeColor = Color.WhiteSmoke;
                        pobjButton.FlatAppearance.BorderColor = ThemaColorDark;
                    }
                    break;

                // -------------------------------------------------------------------------
                // ◆ カラー設定ボタン
                // -------------------------------------------------------------------------
                case ButtonStyle.ThemaColorButton:

                    if (pobjButton.Enabled == true)
                    {
                        pobjButton.BackColor = ThemaColorTsujyo;
                        pobjButton.ForeColor = Color.White;
                        pobjButton.FlatAppearance.BorderColor = ThemaColorDark;
                    }
                    else
                    {
                        pobjButton.BackColor = ThemaColorLightLight;
                        pobjButton.ForeColor = ThemaColorDarkDark;
                        pobjButton.FlatAppearance.BorderColor = ThemaColorDark;
                    }
                    break;
            }
        }

        /// <summary>
        /// 通常ボタンEnabled変更時のカラー設定イベント
        /// </summary>
        /// <param name="sender">イベント引数</param>
        /// <param name="e">イベント引数</param>
        private static void btnNormalColor_EnabledChanged(object sender, EventArgs e)
        {
            Button lobjButton = (Button)sender;

            SetButtonColor(lobjButton, ButtonStyle.TsujoButton);
        }

        /// <summary>
        /// テーマカラーボタンEnabled変更時のカラー設定イベント
        /// </summary>
        /// <param name="sender">イベント引数</param>
        /// <param name="e">イベント引数</param>
        private static void btnThemaColor_EnabledChanged(object sender, EventArgs e)
        {
            Button lobjButton = (Button)sender;

            SetButtonColor(lobjButton, ButtonStyle.ThemaColorButton);
        }
        #endregion

        /// <summary>
        /// ラベルコントロール　スタイル設定
        /// </summary>
        /// <param name="pobjLabel">スタイル設定するラベルコントロール</param>
        /// <param name="penmType">設定するスタイル指定</param>
        public static void SetLabelStyle(Label pobjLabel, LabelStyle penmType)
        {
            pobjLabel.BorderStyle = BorderStyle.None;
            switch (penmType)
            {
                // -------------------------------------------------------------------------
                // ◆ フォームタイトル ラベル
                // -------------------------------------------------------------------------
                case LabelStyle.FromTitle:
                    pobjLabel.BackColor = ThemaColorTsujyo;
                    pobjLabel.ForeColor = Color.White;
                    break;

                // -------------------------------------------------------------------------
                // ◆ 強調タイトル（通常）
                // -------------------------------------------------------------------------
                case LabelStyle.KyotyoTitle:
                    pobjLabel.BackColor = ThemaColorTsujyo;
                    pobjLabel.ForeColor = Color.White;
                    break;

                // -------------------------------------------------------------------------
                // ◆ 強調タイトル（薄い）
                // -------------------------------------------------------------------------
                case LabelStyle.KyotyoTitleLight:
                    pobjLabel.BackColor = ThemaColorLight;
                    pobjLabel.ForeColor = Color.Black;
                    break;

                // -------------------------------------------------------------------------
                // ◆ 明るい項目カラー(通常カラー)
                // -------------------------------------------------------------------------
                case LabelStyle.LightKomokuColor:
                    pobjLabel.BackColor = ControlColor;
                    pobjLabel.ForeColor = ThemaColorTsujyo;
                    break;

                // -------------------------------------------------------------------------
                // ◆ 通常項目カラー(濃いカラー)
                // -------------------------------------------------------------------------
                case LabelStyle.TsujoKomokuColor:
                    pobjLabel.BackColor = ControlColor;
                    pobjLabel.ForeColor = ThemaColorDark;
                    break;

                // -------------------------------------------------------------------------
                // ◆ 濃い項目カラー(濃い濃いカラー)
                // -------------------------------------------------------------------------
                case LabelStyle.DarkKomokuColor:
                    pobjLabel.BackColor = ControlColor;
                    pobjLabel.ForeColor = ThemaColorDarkDark;
                    break;

                // -------------------------------------------------------------------------
                // ◆ 入力項目タイトル
                // -------------------------------------------------------------------------
                case LabelStyle.NyuryokuKomokumei:
                    pobjLabel.BackColor = ControlColor;
                    pobjLabel.ForeColor = ThemaColorDarkDark;
                    break;

                // -------------------------------------------------------------------------
                // ◆ 入力データ名称
                // -------------------------------------------------------------------------
                case LabelStyle.NyuryokuDataMeisho:
                    pobjLabel.BackColor = ControlColor;
                    pobjLabel.ForeColor = ThemaColorDark;
                    pobjLabel.BorderStyle = BorderStyle.Fixed3D;
                    break;
            }
        }

        /// <summary>
        /// パネルコントロール　スタイル設定
        /// </summary>
        /// <param name="pobjPanel">スタイル設定するパネルコントロール</param>
        public static void SetPanelStyle(Panel pobjPanel)
        {
            pobjPanel.BorderStyle = BorderStyle.None;

        }

        #region スプレッドコントロール　スタイル設定
        /// <summary>
        /// スプレッドコントロール　スタイル設定
        /// </summary>
        /// <param name="pobjSpd">スタイル設定するスプレッドコントロール</param>
        public static void SetSpreadStyle(FpSpread pobjSpd)
        {
            SetSpreadStyle(pobjSpd, false);
        }

        /// <summary>
        /// スプレッドコントロール　スタイル設定
        /// </summary>
        /// <param name="pobjSpd">スタイル設定するスプレッドコントロール</param>
        /// <param name="pblnBorderSingle">シングル枠設定（TRUE:シングル、FALSE:枠なし)</param>
        public static void SetSpreadStyle(FpSpread pobjSpd, bool pblnBorderSingle)
        {
            if (pblnBorderSingle == true)
            {
                pobjSpd.BorderStyle = BorderStyle.FixedSingle;
                //pobjSpd.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                pobjSpd.BorderStyle = BorderStyle.None;
            }

            for (int lintSheet = 0; lintSheet < pobjSpd.Sheets.Count; lintSheet++)
            {
                pobjSpd.Sheets[lintSheet].VerticalGridLine = new GridLine(GridLineType.None);

                pobjSpd.Sheets[lintSheet].ColumnHeader.VerticalGridLine = new GridLine(GridLineType.Flat);
                pobjSpd.Sheets[lintSheet].ColumnHeader.DefaultStyle.BackColor = ControlColor;
                pobjSpd.Sheets[lintSheet].ColumnHeader.DefaultStyle.ForeColor = ThemaColorDarkDark;

                pobjSpd.Sheets[lintSheet].RowHeader.HorizontalGridLine = new GridLine(GridLineType.Flat);
                pobjSpd.Sheets[lintSheet].RowHeader.DefaultStyle.BackColor = ControlColor;
                pobjSpd.Sheets[lintSheet].RowHeader.DefaultStyle.ForeColor = ThemaColorDarkDark;

                pobjSpd.Sheets[lintSheet].GrayAreaBackColor = Color.White;
            }
        }

        /// <summary>
        /// スプレッドNamedStyle設定
        /// </summary>
        /// <param name="pNameStyle">カラー設定するスタイルコレクション</param>
        /// <param name="pstrStyleNm">カラー設定するスタイル名</param>
        /// <param name="penmStyle">設定するスタイル指定</param>
        public static void SetSpreadNamedStyle(NamedStyleCollection pNameStyle,
                                               string pstrStyleNm, SpreadNameStyle penmStyle)
        {
            if (pNameStyle.Find(pstrStyleNm) != null)
            {
                switch (penmStyle)
                {
                    case SpreadNameStyle.HeaderColor:
                        pNameStyle.Find(pstrStyleNm).BackColor = ControlColor;
                        pNameStyle.Find(pstrStyleNm).ForeColor = ThemaColorDarkDark;
                        break;
                    case SpreadNameStyle.TitleColor:
                        pNameStyle.Find(pstrStyleNm).BackColor = ThemaColorTsujyo;
                        pNameStyle.Find(pstrStyleNm).ForeColor = Color.White;
                        break;
                    case SpreadNameStyle.TitleLightColor:
                        pNameStyle.Find(pstrStyleNm).BackColor = ThemaColorLight;
                        pNameStyle.Find(pstrStyleNm).ForeColor = Color.Black;
                        break;
                    case SpreadNameStyle.LabelColor:
                        pNameStyle.Find(pstrStyleNm).BackColor = Color.White;
                        pNameStyle.Find(pstrStyleNm).ForeColor = Color.Black;
                        break;
                    case SpreadNameStyle.NyuryokuKomokuTitleColor:
                        pNameStyle.Find(pstrStyleNm).BackColor = Color.White;
                        pNameStyle.Find(pstrStyleNm).ForeColor = ThemaColorDarkDark;
                        break;
                    case SpreadNameStyle.MeishoLabelColor:
                        pNameStyle.Find(pstrStyleNm).BackColor = Color.White;
                        pNameStyle.Find(pstrStyleNm).ForeColor = ThemaColorDark;
                        break;
                }
            }
        }
        #endregion

        #region チェックボックスコントロール　スタイル設定
        /// <summary>
        /// チェックボックス　スタイル設定
        /// </summary>
        /// <param name="pobjCheckBox">スタイル設定するチェックボックス</param>
        public static void SetCheckBoxFlatStyle(CheckBox pobjCheckBox)
        {
            SetCheckBoxColor(pobjCheckBox);

            pobjCheckBox.BackColor = ThemaColorLightLight;
            pobjCheckBox.FlatAppearance.CheckedBackColor = ThemaColorTsujyo;
            pobjCheckBox.CheckedChanged += new EventHandler(CheckFlat_CheckedChanged);
        }

        /// <summary>
        /// チェックボックス　カラー設定(CheckON/OFF切替)
        /// </summary>
        /// <param name="pobjCheckBox">カラー設定するチェックボックス</param>
        private static void SetCheckBoxColor(CheckBox pobjCheckBox)
        {
            if (pobjCheckBox.Checked == true)
            {
                pobjCheckBox.ForeColor = Color.White;
            }
            else
            {
                pobjCheckBox.ForeColor = ThemaColorDarkDark;
            }
        }

        /// <summary>
        /// チェックボックスCheck変更時のカラー設定イベント
        /// </summary>
        /// <param name="sender">イベント引数</param>
        /// <param name="e">イベント引数</param>
        private static void CheckFlat_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox lobjChekBox = (CheckBox)sender;
            SetCheckBoxColor(lobjChekBox);
        }
        #endregion

        #region ラジオボタンコントロール　スタイル設定
        /// <summary>
        /// ラジオボタンコントロール　スタイル設定
        /// </summary>
        /// <param name="pobjRadio">スタイル設定するラジオボタンコントロール</param>
        public static void SetRadioButtonStyle(RadioButton pobjRadio)
        {
            pobjRadio.BackColor = ThemaColorLightLight;
            pobjRadio.FlatAppearance.BorderColor = ThemaColorTsujyo;
            pobjRadio.FlatAppearance.CheckedBackColor = ThemaColorTsujyo;
            
            SetRadioButtonColor(pobjRadio);

            pobjRadio.CheckedChanged += new EventHandler(ComRadio_CheckedChanged);
        }

        /// <summary>
        /// ラジオボタンコントロール　カラー設定(CheckON/OFF切替)
        /// </summary>
        /// <param name="pobjRadio">カラー設定するラジオボタンコントロール</param>
        private static void SetRadioButtonColor(RadioButton pobjRadio)
        {
            if (pobjRadio.Checked == true)
            {
                pobjRadio.ForeColor = Color.White;
            }
            else
            {
                pobjRadio.ForeColor = ThemaColorDarkDark;
            }
        }

        /// <summary>
        /// ラジオボタンCheck変更時のカラー設定イベント
        /// </summary>
        /// <param name="sender">イベント引数</param>
        /// <param name="e">イベント引数</param>
        private static void ComRadio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton lobjRadioButton = (RadioButton)sender;
            SetRadioButtonColor(lobjRadioButton);
        }
        #endregion

        /// <summary>
        /// 通常強調コントロール　スタイル設定
        /// </summary>
        /// <param name="pobjControl">スタイル設定するコントロール</param>
        public static void SetNormalThemaStyle(Control pobjControl)
        {
            // ※通常ラベルカラー合わせる
            pobjControl.ForeColor = ThemaColorDark;
        }

        #region テキストボックス　スタイル設定
        /// <summary>
        /// 入力←→表示　テキストスボックスタイル設定
        /// </summary>
        /// <param name="pobjTextbox">スタイル設定するテキストボックス</param>
        public static void SetTextBoxStyle(TextBox pobjTextbox)
        {
            SetTextBoxColor(pobjTextbox);
            pobjTextbox.ReadOnlyChanged += new EventHandler(txtName_ReadOnlyChanged);
        }

        /// <summary>
        /// 入力←→表示　テキストボックスカラー設定(ReadOnlyによる切替)
        /// </summary>
        /// <param name="pobjTextbox">カラー設定するテキストボックス</param>
        private static void SetTextBoxColor(TextBox pobjTextbox)
        {
            if (pobjTextbox.ReadOnly == false)
            {
                // 入力可の場合
                pobjTextbox.BackColor = Color.White;
                pobjTextbox.ForeColor = SystemColors.WindowText;
            }
            else
            {
                // 入力不可可の場合
                pobjTextbox.BackColor = SystemColors.Control;
                pobjTextbox.ForeColor = SystemColors.WindowText;

            }
        }

        /// <summary>
        /// (テキストボックスReadOnly変更時のカラー設定イベント
        /// </summary>
        /// <param name="sender">イベント引数</param>
        /// <param name="e">イベント引数</param>
        private static void txtName_ReadOnlyChanged(object sender, EventArgs e)
        {
            TextBox lobjTextbox = (TextBox)sender;
            SetTextBoxColor(lobjTextbox);
        }
        #endregion
    }
}
