using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

#region 修正履歴
/// <summary>  ****************************************************************************
///     修正履歴　　　 : 
///     
/// **************************************************************************** </summary> 
#endregion

namespace B2.Com
{
    #region 機能概要
    /// <summary>  ****************************************************************************
    /// 
    ///     ファイル名　　 : clsContrlColor.cs
    ///     説明           : カラーコントロール  クラス
    ///                       ＜Public処理＞
    /// 　　　　　　　　　　　SetFormStyle()        : フォーム      スタイル 
    ///                       SetBtnStyle()         : ボタン        スタイル
    ///                       SetLblStyle()         : ラベル        スタイル
    ///                       SetPanelStyle()       : パネル        スタイル
    ///                       SetSpreadStyle()      : スプレッド　  スタイル
    /// 　　　　　　　　　　　SetSpreadNamedStyle() : スプレッドNamedStyle　　　　
    ///                       SetCheckFlatStyle()   : チェックボックス(FLAT)
    ///                       SetRadioFlatStyle()   : ラジオボタン(FLAT)
    ///                       SetNormalTehmaStyle() : 共通コントロール
    ///                     　SetNameTextStyle()    : 入力←→表示　テキストスタイル
    ///                       
    /// 
    ///     修正履歴　　　 : 
    /// 
    /// </summary> ****************************************************************************
    #endregion

    class clsContrlColor
    {
        //---------------------------------------------------------------------------------
        // ■ テーマカラー[グリーン]
        //---------------------------------------------------------------------------------      
        /// <summary>通常</summary>
        public static System.Drawing.Color CNST_COLOR_THEMA_NORMAL
        { get { return System.Drawing.Color.FromArgb(49, 162, 58); } }        // ■ 通常

        /// <summary>濃い濃い</summary>
        public static System.Drawing.Color CNST_COLOR_THEMA_DARK_DARK
        { get { return System.Drawing.Color.FromArgb(31, 87, 34); } }           // ■ 濃い濃い

        /// <summary>濃い</summary>
        public static System.Drawing.Color CNST_COLOR_THEMA_DARK
        { get { return System.Drawing.Color.FromArgb(43, 121, 47); } }          // ■ 濃い

        /// <summary>薄い</summary>
        public static System.Drawing.Color CNST_COLOR_THEMA_LIGHT
        { get { return System.Drawing.Color.FromArgb(157, 219, 160); } }        // ■ 薄い

        /// <summary>薄い薄い</summary>
        public static System.Drawing.Color CNST_COLOR_THEMA_LIGHT_LIGHT
        { get { return System.Drawing.Color.FromArgb(225, 235, 205); } }        // ■ 薄い薄い

        //---------------------------------------------------------------------------------
        // ■ コントロールカラー
        //---------------------------------------------------------------------------------      
        /// <summary>コントロールカラー</summary>
        public static System.Drawing.Color CNST_COLOR_CONTROL
        {
            get { return System.Drawing.Color.WhiteSmoke; }            // 白っぽいカラーとする

            // ※ GhostWhite,SeaShell,FloralWhite,Snow,IvoryはEnabled=falseの時字が変化するのでNG
        }

        //---------------------------------------------------------------------------------
        // ■ ボタンスタイル
        //---------------------------------------------------------------------------------
        /// <summary>ボタンスタイル</summary>
        public enum STYLE_BTN
        {
            /// <summary>通常ボタン </summary>
            TYPE_NORMAL,                                // 通常ボタン
            /// <summary>カラー設定ボタン </summary>
            TYPE_TERMA_COLOR,                           // カラー設定ボタン
        }
        //---------------------------------------------------------------------------------
        // ■ ラベルスタイル
        //---------------------------------------------------------------------------------
        /// <summary>ラベルスタイル</summary>
        public enum STYLE_LBL
        {
            /// <summary>フォームタイトル               (BK:テーマカラー、字：白)</summary>
            TYPE_FROM_TITEL,
            /// <summary>強調タイトル                   (BK:テーマカラー、字：白)</summary>    
            TYPE_FRBK_TITEL,
            /// <summary>強調タイトル(薄い              (BK:薄いテーマカラー、字：黒)</summary>  
            TYPE_FRBK_TITEL_LIGHT,


            /// <summary>明るい項目カラー(通常カラー)   (BK:白系、字：テーマカラー)</summary>
            TYPE_DAT_LIGHT,
            /// <summary>通常項目カラー(濃いカラー)     (BK:白系、字：濃いテーマカラー)</summary>
            TYPE_DAT_NORMAL,
            /// <summary>濃い項目カラー(濃い濃いカラー) (BK:白系、字：濃い×２テーマカラー)</summary>
            TYPE_DAT_DARK,

            /// <summary>入力データ 項目名              (BK:白系、字：濃い×２テーマカラー)</summary>
            TYPE_INPUT_TITEL,
            /// <summary>入力データ 名称                (BK:白系、字：濃いテーマカラー)</summary>
            TYPE_INPUT_CDNAME,

        }
        /// <summary>スプレッドNamedStyleスタイル</summary>
        public enum SPREAD_NAMESTYLE
        {
            /// <summary>ヘッダカラー               (BK:白系、字：濃い×２テーマカラー))</summary>
            TYPE_NS_HEADER,
            /// <summary>タイトル                   (BK:テーマカラー、字：白)</summary>
            TYPE_NS_TITEL,
            /// <summary>タイトル文字黒（明るい）   (BK:薄いテーマカラー，字：黒)</summary>
            TYPE_NS_FRBK_TITEL_LIGHT,
            /// <summary>通常ラベル(文字黒)         (BK:白、字:黒)</summary>
            TYPE_NS_NORMAL,
            /// <summary>入力項目タイトル           (BK:白、字:濃い×２テーマカラー)</summary>
            TYPE_NS_IN_TITEL,
            /// <summary>名称ラベル                 (BK:白、字:濃いテーマカラー)</summary>
            TYPE_NS_CDNAME,
        }

        #region // フォームスタイル設定
        //
        /// <summary> 機能　　　: フォームスタイル設定　                              </summary>
        /// 
        /// 
        /// <remark>  機能説明　: フォームスタイル変更                                </remark>
        //
        //*********************************************************************************
        public static void SetFormStyle(Control pobjForm)
        {
            //-----------------------------------------------------------------------------
            // ■ フォームコントロール設定
            //-----------------------------------------------------------------------------
            pobjForm.BackColor = CNST_COLOR_CONTROL;                    // バックカラー　：設定白系

            //-----------------------------------------------------------------------------
            // ■ 全コントロールの再設定
            //-----------------------------------------------------------------------------
            mfncGetAllControls(pobjForm);

        }
        #endregion

        #region // 全コントロールリスト取得処理
        //
        /// <summary> 機能　　　: 全コントロールリスト取得処理                      </summary>
        /// 
        /// <param name="pctrl">
        ///           引数      : 親コントロール                                      </param>
        /// 
        /// <returns> 戻値      : コントロールリスト                                </returns>
        /// 
        /// <remark>  機能説明　: 全コントロールリスト取得処理                      </remark>
        //
        //*********************************************************************************
        private static List<Control> mfncGetAllControls(Control pctrl)
        {
            List<Control> llst = new List<Control>();

            //-----------------------------------------------------------------------------
            // ■ 子コントロール分LOOP
            //-----------------------------------------------------------------------------
            foreach (Control c in pctrl.Controls)
            {
                //-------------------------------------------------------------------------
                // ■ コントロール名が設定されている場合
                //-------------------------------------------------------------------------
                if (c.Name != "")
                {

                    //---------------------------------------------------------------------
                    // ■ 設定
                    //---------------------------------------------------------------------
                    if (c is TextBox || c is RichTextBox || c is ListBox
                        || c is ComboBox)
                    {
                        // 上記入力系コントロールは設定なし
                    }
                    else
                    {
                        // バックカラー
                        if (c.BackColor == System.Drawing.SystemColors.Control)
                        {
                            c.BackColor = CNST_COLOR_CONTROL;
                        }
                    }

                    //---------------------------------------------------------------------
                    // ■ 再帰設定
                    //---------------------------------------------------------------------
                    mfncGetAllControls(c);                                  // 再帰
                }
            }

            return llst;
        }
        #endregion

        #region // ボタンスタイル設定
        /// <summary> 機能　　　: ボタンスタイル設定　                              </summary>
        /// <remark>  機能説明　: ボタンスタイル変更                                </remark>
        public static void SetBtnStyle(System.Windows.Forms.Button pobjButton, STYLE_BTN penmMode)
        {
            //-----------------------------------------------------------------------------
            // ■ スタイル分岐
            //-----------------------------------------------------------------------------
            switch (penmMode)
            {
                //-------------------------------------------------------------------------
                // ◆ 通常ボタン
                //-------------------------------------------------------------------------
                case STYLE_BTN.TYPE_NORMAL:
                    pobjButton.BackColor = CNST_COLOR_CONTROL;                                  // バックカラー：コントロールカラー
                    pobjButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;                 // スタイル     :フラット
                    // Enabled分岐カラー設定
                    msubSetBtnColor(pobjButton, STYLE_BTN.TYPE_NORMAL);                             // 
                    // イベント追加 ※Enable変更時のカラー変更
                    pobjButton.EnabledChanged += new System.EventHandler(btnNormalColor_EnabledChanged);
                    break;

                //-------------------------------------------------------------------------
                // ◆ カラー設定ボタン
                //-------------------------------------------------------------------------
                case STYLE_BTN.TYPE_TERMA_COLOR:
                    pobjButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;                 // スタイル：フラット
                    // Enabled分岐カラー設定    
                    msubSetBtnColor(pobjButton, STYLE_BTN.TYPE_TERMA_COLOR);
                    // イベント追加 ※Enabled変更時のカラー定義
                    pobjButton.EnabledChanged += new System.EventHandler(btnThemaColor_EnabledChanged);
                    break;
            }
        }
        #endregion

        #region // ボタンスタイル カラー設定（Enabledによる切替）
        /// <summary> 機能　　　: ボタンスタイル カラー設定（Enabledによる切替）    </summary>
        /// <remark>  機能説明　: ボタンスタイル カラー設定（Enabledによる切替）    </remark>
        private static void msubSetBtnColor(System.Windows.Forms.Button pobjButton, STYLE_BTN penmMode)
        {
            //-----------------------------------------------------------------------------
            // ■ スタイル分岐
            //-----------------------------------------------------------------------------
            switch (penmMode)
            {
                //-------------------------------------------------------------------------
                // ◆ 通常ボタン
                //-------------------------------------------------------------------------
                case STYLE_BTN.TYPE_NORMAL:
                    if (pobjButton.Enabled == true)
                    {
                        pobjButton.ForeColor = CNST_COLOR_THEMA_DARK_DARK;                          // 文字カラー  ：濃い濃いテーマカラー
                        pobjButton.FlatAppearance.BorderColor = CNST_COLOR_THEMA_DARK_DARK;         // 境界線の色   : 濃い濃いテーマカラー
                    }
                    else
                    {
                        pobjButton.ForeColor = System.Drawing.Color.WhiteSmoke;                     // 文字カラー   ：薄いグレー
                        pobjButton.FlatAppearance.BorderColor = CNST_COLOR_THEMA_DARK;              // 境界線の色   ：テーマカラー
                    }
                    break;

                //-------------------------------------------------------------------------
                // ◆ カラー設定ボタン
                //-------------------------------------------------------------------------
                case STYLE_BTN.TYPE_TERMA_COLOR:

                    if (pobjButton.Enabled == true)
                    {
                        pobjButton.BackColor = CNST_COLOR_THEMA_NORMAL;                             // バックカラー : 通常テーマカラー
                        pobjButton.ForeColor = System.Drawing.Color.White;                          // 文字カラー   ：白
                        pobjButton.FlatAppearance.BorderColor = CNST_COLOR_THEMA_DARK;              // 境界線の色   ：濃いテーマカラー
                    }
                    else
                    {
                        pobjButton.BackColor = CNST_COLOR_THEMA_LIGHT_LIGHT;                        // バックカラー ：薄い薄いテーマカラー
                        pobjButton.ForeColor = CNST_COLOR_THEMA_DARK_DARK;                          // 文字カラー   ：濃い濃いテーマカラー
                        pobjButton.FlatAppearance.BorderColor = CNST_COLOR_THEMA_DARK;              // 境界線の色   ：テーマカラー
                    }
                    break;
            }
        }
        #endregion

        #region // [イベント] 通常ボタン　Enabled変更時処理
        /// <summary> 機能　　　: [イベント] カラーボタン　Enabled変更時処理     </summary>
        /// <remark>  機能説明　: バックカラー変更                               </remark>
        private static void btnNormalColor_EnabledChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.Button lobjButton = (System.Windows.Forms.Button)sender;

            //-----------------------------------------------------------------------------
            // ■ Enabledの状況によりカラー変更
            //-----------------------------------------------------------------------------
            msubSetBtnColor(lobjButton, STYLE_BTN.TYPE_NORMAL);

        }
        #endregion

        #region // [イベント] カラーボタン　Enabled変更時処理
        /// <summary> 機能　　　: [イベント] カラーボタン　Enabled変更時処理     </summary>
        /// <remark>  機能説明　: バックカラー変更                               </remark>
        private static void btnThemaColor_EnabledChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.Button lobjButton = (System.Windows.Forms.Button)sender;

            //-----------------------------------------------------------------------------
            // ■ Enabledの状況によりカラー変更
            //-----------------------------------------------------------------------------
            msubSetBtnColor(lobjButton, STYLE_BTN.TYPE_TERMA_COLOR);

        }
        #endregion

        #region // ラベルコントロール　スタイル設定
        /// <summary> 機能　　　: ラベルコントロール　スタイル設定              </summary>
        /// <remark>  機能説明　: ラベルコントロール　スタイル変更               </remark>
        public static void SetLblStyle(System.Windows.Forms.Label pobjLabel, STYLE_LBL penmType)
        {

            pobjLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;          // 枠なし
            //-----------------------------------------------------------------------------
            // ■ スタイル分岐
            //-----------------------------------------------------------------------------
            switch (penmType)
            {
                //-------------------------------------------------------------------------
                // ◆ フォームタイトル ラベル
                //-------------------------------------------------------------------------
                case STYLE_LBL.TYPE_FROM_TITEL:
                    pobjLabel.BackColor = CNST_COLOR_THEMA_NORMAL;                  // ■ バックカラー  ：通常テーマカラー
                    pobjLabel.ForeColor = System.Drawing.Color.White;               // ■ 文字カラー    ：白
                    break;

                //-------------------------------------------------------------------------
                // ◆ 強調タイトル（通常）
                //-------------------------------------------------------------------------
                case STYLE_LBL.TYPE_FRBK_TITEL:
                    pobjLabel.BackColor = CNST_COLOR_THEMA_NORMAL;                  // ■ バックカラー  ：通常テーマカラー
                    pobjLabel.ForeColor = System.Drawing.Color.White;               // ■ 文字カラー    ：白
                    break;

                //-------------------------------------------------------------------------
                // ◆ 強調タイトル（薄い）
                //-------------------------------------------------------------------------
                case STYLE_LBL.TYPE_FRBK_TITEL_LIGHT:
                    pobjLabel.BackColor = CNST_COLOR_THEMA_LIGHT;                   // ■ バックカラー  ：薄いテーマカラー
                    pobjLabel.ForeColor = System.Drawing.Color.Black;               // ■ 文字カラー    ：黒
                    break;

                //-------------------------------------------------------------------------
                // ◆ 明るい項目カラー(通常カラー)
                //-------------------------------------------------------------------------
                case STYLE_LBL.TYPE_DAT_LIGHT:
                    pobjLabel.BackColor = CNST_COLOR_CONTROL;                       // ■ バックカラー  ：コントロールカラー
                    pobjLabel.ForeColor = CNST_COLOR_THEMA_NORMAL;                  // ■ 文字カラー    ：テーマカラー
                    break;

                //-------------------------------------------------------------------------
                // ◆ 通常項目カラー(濃いカラー)
                //-------------------------------------------------------------------------
                case STYLE_LBL.TYPE_DAT_NORMAL:
                    pobjLabel.BackColor = CNST_COLOR_CONTROL;                       // ■ バックカラー  ：コントロールカラー
                    pobjLabel.ForeColor = CNST_COLOR_THEMA_DARK;                    // ■ 文字カラー    ：濃いテーマカラー
                    break;

                //-------------------------------------------------------------------------
                // ◆ 濃い項目カラー(濃い濃いカラー)
                //-------------------------------------------------------------------------
                case STYLE_LBL.TYPE_DAT_DARK:
                    pobjLabel.BackColor = CNST_COLOR_CONTROL;                       // ■ バックカラー  ：コントロールカラー
                    pobjLabel.ForeColor = CNST_COLOR_THEMA_DARK_DARK;               // ■ 文字カラー    ：濃い濃いテーマカラー
                    break;

                //-------------------------------------------------------------------------
                // ◆ 入力項目タイトル
                //-------------------------------------------------------------------------
                case STYLE_LBL.TYPE_INPUT_TITEL:
                    pobjLabel.BackColor = CNST_COLOR_CONTROL;                           // ■ バックカラー  ：コントロールカラー
                    pobjLabel.ForeColor = CNST_COLOR_THEMA_DARK_DARK;                   // ■ 文字カラー    ：濃い濃いテーマカラー  
                    break;

                //-------------------------------------------------------------------------
                // ◆ 入力データ名称
                //-------------------------------------------------------------------------
                case STYLE_LBL.TYPE_INPUT_CDNAME:
                    pobjLabel.BackColor = CNST_COLOR_CONTROL;                           // ■ バックカラー  ：コントロールカラー
                    pobjLabel.ForeColor = CNST_COLOR_THEMA_DARK;                        // ■ 文字カラー    ：濃いテーマカラー
                    pobjLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;   // ■ スタイル      ：３Ｄ     
                    break;

            }
        }
        #endregion

        #region // パネルコントロール　スタイル設定
        /// <summary> 機能　　　: パネルコントロール　スタイル設定              </summary>
        /// <remark>  機能説明　: パネルコントロール　スタイル変更               </remark>
        public static void SetPanelStyle(System.Windows.Forms.Panel pobjPanel)
        {
            //-----------------------------------------------------------------------------
            // ■ スタイル設定
            //-----------------------------------------------------------------------------
            pobjPanel.BorderStyle = System.Windows.Forms.BorderStyle.None;

        }
        #endregion

        #region // スプレッドコントロール　スタイル設定
        /// <summary> 機能　　　: スプレッドコントロール　スタイル設定              </summary>
        /// <remark>  機能説明　: スプレッドコントロール　スタイル変更               </remark>
        public static void SetSpreadStyle(FarPoint.Win.Spread.FpSpread pobjSpd)
        {
            SetSpreadStyle(pobjSpd, false);
        }
        #endregion

        #region // スプレッドコントロール　スタイル設定
        /// <summary> 機能　　　: スプレッドコントロール　スタイル設定              </summary>
        /// <param name="pobjSpd">
        ///           引数　　　: (I) スプレットシートコンポーネント
        /// </param>
        /// <param name="pblnBorderSingle">
        ///           引数　　　: (I) シングル枠（TRUE:シングル、FALSE:枠なし)
        /// </param>
        /// <remark>  機能説明　: スプレッドコントロール　スタイル変更               </remark>
        public static void SetSpreadStyle(FarPoint.Win.Spread.FpSpread pobjSpd, bool pblnBorderSingle)
        {
            //-----------------------------------------------------------------------------
            // ■ スタイル設定
            //-----------------------------------------------------------------------------
            if (pblnBorderSingle == true)
            {
                pobjSpd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;         // シングル枠
                pobjSpd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;             // 3D
            }
            else
            {
                pobjSpd.BorderStyle = System.Windows.Forms.BorderStyle.None;                // 枠なし
            }
            //-----------------------------------------------------------------------------
            // ■ スタイル設定(全シート分)
            //-----------------------------------------------------------------------------
            for (int lintSheet = 0; lintSheet < pobjSpd.Sheets.Count; lintSheet++)
            {
                //-------------------------------------------------------------------------
                // ◆ 罫線
                //-------------------------------------------------------------------------
                pobjSpd.Sheets[lintSheet].VerticalGridLine =
                    new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);    // 縦罫線なし

                //-------------------------------------------------------------------------
                // ◆ 列ヘダ
                //-------------------------------------------------------------------------
                pobjSpd.Sheets[lintSheet].ColumnHeader.VerticalGridLine =
                   new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat);     // ヘッダ列縦罫線   ：フラット

                // 列カラー
                pobjSpd.Sheets[lintSheet].ColumnHeader.DefaultStyle.BackColor =
                    CNST_COLOR_CONTROL;                                                         // ヘッダ列バックカラー ：コントロールカラー
                pobjSpd.Sheets[lintSheet].ColumnHeader.DefaultStyle.ForeColor =
                    CNST_COLOR_THEMA_DARK_DARK;                                                 // ヘッダ列文字カラー ：濃い濃いテーマカラー
                //-------------------------------------------------------------------------
                // ◆ 行ヘッダ
                //-------------------------------------------------------------------------
                pobjSpd.Sheets[lintSheet].RowHeader.HorizontalGridLine =
                     new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat);    // ヘッダ列横罫線   ：フラット
                // 行カラー
                pobjSpd.Sheets[lintSheet].RowHeader.DefaultStyle.BackColor =
                    CNST_COLOR_CONTROL;                                                         // ヘッダ列バックカラー ：コントロールカラー
                pobjSpd.Sheets[lintSheet].RowHeader.DefaultStyle.ForeColor =
                    CNST_COLOR_THEMA_DARK_DARK;                                                 // ヘッダ列文字カラー ：濃い濃いテーマカラー
                // 

                //-------------------------------------------------------------------------
                // ◆ 背景色
                //-------------------------------------------------------------------------
                pobjSpd.Sheets[lintSheet].GrayAreaBackColor = System.Drawing.Color.White;       // 背景色      ：コントロールカラー
            }

        }
        #endregion

        #region // スプレッドNamedStyle　スタイル設定
        /// <summary> 機能　　　: スプレッドNamedStyle　スタイル設定              </summary>
        /// <remark>  機能説明　: スプレッドNamedStyle　スタイル変更               </remark>
        public static void SetSpreadNamedStyle(FarPoint.Win.Spread.NamedStyleCollection pNameStyle,
                                               string pstrStyleNm, SPREAD_NAMESTYLE penmStyle)
        {
            //-----------------------------------------------------------------------------
            // ■ スタイル設定
            //-----------------------------------------------------------------------------
            if (pNameStyle.Find(pstrStyleNm) != null)
            {
                switch (penmStyle)
                {
                    case SPREAD_NAMESTYLE.TYPE_NS_HEADER:                     // ヘッダカラー
                        pNameStyle.Find(pstrStyleNm).BackColor = CNST_COLOR_CONTROL;            // バックカラー ：コントロール
                        pNameStyle.Find(pstrStyleNm).ForeColor = CNST_COLOR_THEMA_DARK_DARK;    // 文字カラー   ：濃い濃いテーマカラー
                        break;
                    case SPREAD_NAMESTYLE.TYPE_NS_TITEL:                     // タイトル
                        pNameStyle.Find(pstrStyleNm).BackColor = CNST_COLOR_THEMA_NORMAL;       // バックカラー ：通常テーマカラー
                        pNameStyle.Find(pstrStyleNm).ForeColor = System.Drawing.Color.White;    // 文字カラー   ：白
                        break;
                    case SPREAD_NAMESTYLE.TYPE_NS_FRBK_TITEL_LIGHT:         // 文字黒タイトル(薄い)
                        pNameStyle.Find(pstrStyleNm).BackColor = CNST_COLOR_THEMA_LIGHT;        // バックカラー ：薄いテーマカラー
                        pNameStyle.Find(pstrStyleNm).ForeColor = System.Drawing.Color.Black;    // 文字カラー   ：黒
                        break;
                    case SPREAD_NAMESTYLE.TYPE_NS_NORMAL:                   // [通常ラベル(文字黒)]
                        pNameStyle.Find(pstrStyleNm).BackColor = System.Drawing.Color.White; ;   // バックカラー ：白※スプレッド標準ﾊﾞｯｸｶﾗｰ
                        pNameStyle.Find(pstrStyleNm).ForeColor = System.Drawing.Color.Black;    // 文字カラー   ：黒
                        break;
                    case SPREAD_NAMESTYLE.TYPE_NS_IN_TITEL:                 // [入力項目タイトルラベル]
                        pNameStyle.Find(pstrStyleNm).BackColor = System.Drawing.Color.White; ;   // バックカラー ：白※スプレッド標準ﾊﾞｯｸｶﾗｰ
                        pNameStyle.Find(pstrStyleNm).ForeColor = CNST_COLOR_THEMA_DARK_DARK;    // 文字カラー   ：濃い濃いテーマカラー
                        break;
                    case SPREAD_NAMESTYLE.TYPE_NS_CDNAME:                   // [名称ラベル]
                        pNameStyle.Find(pstrStyleNm).BackColor = System.Drawing.Color.White; ;   // バックカラー ：白※スプレッド標準ﾊﾞｯｸｶﾗｰ
                        pNameStyle.Find(pstrStyleNm).ForeColor = CNST_COLOR_THEMA_DARK;         // 文字カラー   ：濃いテーマカラー
                        break;
                }
            }
        }
        #endregion

        #region // チェックボックスコントロール　カラー設定
        /// <summary> 機能　　　: チェックボックス　スタイル設定              </summary>
        /// <remark>  機能説明　: チェックボックス　スタイル変更               </remark>
        public static void SetCheckFlatStyle(System.Windows.Forms.CheckBox pobjCheckBox)
        {
            //-----------------------------------------------------------------------------
            // ■ Checkedの状況によりカラー変更
            //-----------------------------------------------------------------------------
            msubSetCheckFlatColor(pobjCheckBox);

            pobjCheckBox.BackColor = CNST_COLOR_THEMA_LIGHT_LIGHT;                          // バックカラー：薄い薄いテーマカラー 
            pobjCheckBox.FlatAppearance.CheckedBackColor = CNST_COLOR_THEMA_NORMAL;         // 選択時カラー：通常テーマカラー
            // イベント追加
            pobjCheckBox.CheckedChanged += new EventHandler(CheckFlat_CheckedChanged);
        }
        #endregion

        #region // チェックボックスコントロール　カラー設定(CheckON/OFF切替)
        /// <summary> 機能　　　: チェックボックス　カラー設定(CheckON/OFF切替)   </summary>
        /// <remark>  機能説明　: チェックボックス　カラー設定(CheckON/OFF切替)   </remark>
        private static void msubSetCheckFlatColor(System.Windows.Forms.CheckBox pobjCheckBox)
        {
            //-----------------------------------------------------------------------------
            // ■ Checkedの状況によりカラー変更
            //-----------------------------------------------------------------------------
            if (pobjCheckBox.Checked == true)
            {
                pobjCheckBox.ForeColor = System.Drawing.Color.White;                        // 文字カラー : 白
            }
            else
            {
                pobjCheckBox.ForeColor = CNST_COLOR_THEMA_DARK_DARK;                        // 文字カラー ：濃い濃いテーマカラー
            }
        }
        #endregion

        #region // チェックボックスコントロール　チェック値変更時処理
        /// <summary> 機能　　　: チェックボックス　チェック値変更時処理        </summary>
        /// <remark>  機能説明　: チェックボックス　チェック値変更時処理        </remark>
        private static void CheckFlat_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox lobjChekBox = (System.Windows.Forms.CheckBox)sender;
            //-----------------------------------------------------------------------------
            // ■ Checkedの状況によりカラー変更
            //-----------------------------------------------------------------------------
            msubSetCheckFlatColor(lobjChekBox);
        }
        #endregion

        #region // ラジオボタンコントロール　スタイル設定
        /// <summary> 機能　　　: ラジオボタンコントロー　スタイル設定              </summary>
        /// <remark>  機能説明　: ラジオボタンコントロー　スタイル変更               </remark>
        public static void SetRadioFlatStyle(System.Windows.Forms.RadioButton pobjRadio)
        {
            //-----------------------------------------------------------------------------
            // ■ スタイル設定
            //-----------------------------------------------------------------------------
            pobjRadio.BackColor = CNST_COLOR_THEMA_LIGHT_LIGHT;                         // バックカラー ：薄い薄いテーマカラー
            pobjRadio.FlatAppearance.BorderColor = CNST_COLOR_THEMA_NORMAL;             // 境界線の色   ：通常テーマカラー
            pobjRadio.FlatAppearance.CheckedBackColor = CNST_COLOR_THEMA_NORMAL;        // チェックバックカラー ：通常テーマカラー
            //-----------------------------------------------------------------------------
            // ■ Checkedの状況によりカラー変更
            //-----------------------------------------------------------------------------
            msubSetRadioFlatColor(pobjRadio);
            // イベント追加
            pobjRadio.CheckedChanged += new EventHandler(ComRadio_CheckedChanged);
        }
        #endregion

        #region // ラジオボタンコントロール　カラー設定(CheckON/OFF切替)
        /// <summary> 機能　　　: ラジオボタンコントロー　カラー設定(CheckON/OFF切替)   </summary>
        /// <remark>  機能説明　: ラジオボタンコントロー　カラー設定(CheckON/OFF切替)   </remark>
        private static void msubSetRadioFlatColor(System.Windows.Forms.RadioButton pobjRadio)
        {
            //-----------------------------------------------------------------------------
            // ■ Checkedの状況によりカラー変更
            //-----------------------------------------------------------------------------
            if (pobjRadio.Checked == true)
            {
                pobjRadio.ForeColor = System.Drawing.Color.White;                       // 文字カラー   ：白
            }
            else
            {
                pobjRadio.ForeColor = CNST_COLOR_THEMA_DARK_DARK;   　                  // 文字カラー   ：濃い濃いテーマカラー
            }
        }
        #endregion

        #region // ラジオボタンコントロール　チェック値変更時処理
        /// <summary> 機能　　　: ラジオボタン　チェック値変更時処理        </summary>
        /// <remark>  機能説明　: ラジオボタン　チェック値変更時処理        </remark>
        private static void ComRadio_CheckedChanged(object sender, EventArgs e)
        {
            //-----------------------------------------------------------------------------
            // ■ Checkedの状況によりカラー変更
            //-----------------------------------------------------------------------------
            System.Windows.Forms.RadioButton lobjRadioButton = (System.Windows.Forms.RadioButton)sender;
            msubSetRadioFlatColor(lobjRadioButton);
        }
        #endregion

        #region // 通常強調コントロール　スタイル設定
        /// <summary> 機能　　　: 通常強調コントロール　スタイル設定         </summary>
        /// <remark>  機能説明　: 通常強調コントロール　スタイル変更         </remark>
        public static void SetNormalTehmaStyle(System.Windows.Forms.Control pobjControl)
        {
            //-----------------------------------------------------------------------------
            // ■ スタイル設定
            //-----------------------------------------------------------------------------
            pobjControl.ForeColor = CNST_COLOR_THEMA_DARK;              // 文字カラー ：濃いテーマカラー   
            // ※通常ラベルカラー合わせる
        }
        #endregion

        #region // 入力←→表示　テキストスタイル設定
        /// <summary> 機能　　　: 入力←→表示　テキストスタイル設定　               　</summary>
        /// <remark>  機能説明　: テキストスタイル変更                                </remark>
        public static void SetNameTextStyle(System.Windows.Forms.TextBox pobjTextbox)
        {
            //-----------------------------------------------------------------------------
            // ■ Enabledの状況によりカラー変更
            //-----------------------------------------------------------------------------
            msubSetNameTextColor(pobjTextbox);

            // イベント追加
            pobjTextbox.ReadOnlyChanged += new System.EventHandler(txtName_ReadOnlyChanged);

        }
        #endregion

        #region // 入力←→表示　カラー設定(ReadOnlyによる切替)
        /// <summary> 機能　　　: 入力←→表示　カラー設定(ReadOnlyによる切替)  </summary>
        /// <remark>  機能説明　: カラー設定(ReadOnlyによる切替)                </remark>
        private static void msubSetNameTextColor(System.Windows.Forms.TextBox pobjTextbox)
        {
            //-----------------------------------------------------------------------------
            // ■ Enabledの状況によりカラー変更
            //-----------------------------------------------------------------------------
            if (pobjTextbox.ReadOnly == false)
            {
                // 入力可の場合
                pobjTextbox.BackColor = System.Drawing.Color.White;                 // バックカラー ：白
                pobjTextbox.ForeColor = System.Drawing.SystemColors.WindowText; ;    // 文字カラー   ：通常
            }
            else
            {
                // 入力不可可の場合
                pobjTextbox.BackColor = System.Drawing.SystemColors.Control;       // バックカラー ：コントロール
                pobjTextbox.ForeColor = System.Drawing.SystemColors.WindowText;    // 文字カラー   ：コントロール

            }
        }
        #endregion

        #region // [イベント] テキストスタイル　ReadOnly変更時処理
        /// <summary> 機能　　　: [イベント] テキストスタイル　ReadOnly変更時処理     </summary>
        /// <remark>  機能説明　: カラー変更                               </remark>
        private static void txtName_ReadOnlyChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox lobjTextbox = (System.Windows.Forms.TextBox)sender;

            //-----------------------------------------------------------------------------
            // ■ Enabledの状況によりカラー変更
            //-----------------------------------------------------------------------------
            msubSetNameTextColor(lobjTextbox);

        }
        #endregion
    }
}
