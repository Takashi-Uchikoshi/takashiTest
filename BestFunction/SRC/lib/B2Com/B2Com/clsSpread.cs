using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using FarPoint.Win.Spread;

namespace B2.Com
{
    //列属性の構造-->クラスに変更
    public class fspColumdata
    {
        /// <summary>
        /// 列位置
        /// </summary>
        public int colum_position;
        /// <summary>
        /// 列幅サイズ
        /// </summary>
        public float? colum_width_size;
        /// <summary>
        /// 列のラベル名
        /// </summary>
        public string colum_label;
        /// <summary>
        /// 列の表示有無 true:表示  false:非表示
        /// </summary>
        public bool hyouji_umu;
        /// <summary>
        /// セルのフォント名
        /// </summary>
        public string font_name;
        /// <summary>
        /// セルのフォントサイズ
        /// </summary>
        public float? font_size;
        /// <summary>
        /// セルの垂直表示位置　0:上 1:下　2:中央
        /// </summary>
        public int? suicyoku_ichi;
        /// <summary>
        /// セルの水平表示位置　0:左 1:右　2:中央
        /// </summary>
        public int? suihei_ichi;
        /// <summary>
        /// セルの属性　0:ﾃｷｽﾄ 1:数値 2:通貨 3:ﾊﾟｰｾﾝﾄ 4:ﾘｯﾁﾃｷｽﾄ 5:ﾁｪｯｸﾎﾞｯｸｽ 6:ｺﾝﾎﾞﾎﾞｯｸｽ 7:日付 8:ﾘｽﾄﾎﾞｯｸｽ 9:ﾎﾞﾀﾝ
        /// </summary>
        public int? cellType;
        /// <summary>
        /// 桁数(テキストの時は文字数）
        /// </summary>
        public int? ketasu;
        /// <summary>
        /// 小数点以下桁数（数値の時）
        /// </summary>
        public int? syousuu;
        /// <summary>
        /// 数値の時　true:3桁区切りあり　false:3桁区切り無し
        /// </summary>
        public bool ketakugiri;
        /// <summary>
        /// テキストの時　true:折り返しあり　false：折り返し無し
        /// </summary>
        public bool orikaeshi;

      /// <summary>
      /// コンストラクタ
      /// 引数なし　初期化します。
      /// </summary>
        public fspColumdata()
        {
          colum_position = -1;
          colum_width_size = null;
          colum_label = string.Empty;
          hyouji_umu = true;
          font_name = string.Empty;
          font_size = null;
          suicyoku_ichi = null;
          suihei_ichi = null;
          cellType = null;
          ketasu = null;
          syousuu = null;
          ketakugiri = false;
          orikaeshi = false;
        }
    }

    /// <summary>
    /// スプレッド  共通関数
    /// </summary>
    [LicenseProviderAttribute(typeof(LicenseProvider))]
    public class clsSpread
    {

        /// <summary>
        /// 列情報に従い、列の属性をセットする。
        /// </summary>
        /// <param name="pspdObj"></param>
        /// <param name="listp"></param>
        /// <returns></returns>
        public static bool setSpreadColumInfo(SheetView pspdObj,List<fspColumdata> listp)
        {
            try
            {
                foreach (fspColumdata flp in listp)
                {
                    //表示位置がマイナスのものは処理しない。
                    if (flp.colum_position < 0) continue;



                    //列名
                　　if(!string.IsNullOrEmpty(flp.colum_label))
                      pspdObj.ColumnHeader.Columns[flp.colum_position].Label = flp.colum_label;

                    //列の非表示設定
                    if(flp.hyouji_umu == false)
                    {
                        pspdObj.ColumnHeader.Columns[flp.colum_position].Visible = false;
                    }

                    //列幅,他の設定
                    if (flp.colum_width_size != null && flp.colum_width_size > 0)
                        pspdObj.Columns[flp.colum_position].Width = (float)flp.colum_width_size;

                    
                    //セルの属性をセット
                    if (flp.cellType != null && (flp.cellType >= 0 && flp.cellType <=10))
                    {
                        switch (flp.cellType)
                        {
                            case 0:   //テキスト
                                FarPoint.Win.Spread.CellType.TextCellType textZokusei = new FarPoint.Win.Spread.CellType.TextCellType();
                                if (flp.ketasu != null)
                                     textZokusei.MaxLength = (int)flp.ketasu;       //最大入力文字数

                                if (flp.orikaeshi == true)
                                {
                                    textZokusei.Multiline = true;         //改行の入力　Shift+Enterが可能となる。　シフト無しでもOKだった。確定はフォーカスを外すこと。
                                    textZokusei.WordWrap = true;
                                }

                                pspdObj.Columns[flp.colum_position].CellType = textZokusei;
                                break;
                            case 1:     //数値
                                FarPoint.Win.Spread.CellType.NumberCellType suuchiZokusei = new FarPoint.Win.Spread.CellType.NumberCellType();
                                //小数点、桁区切りの設定  
                                if (flp.syousuu != null && flp.syousuu != 0)
                                    suuchiZokusei.DecimalPlaces = (int)flp.syousuu;
                                //3桁区切り
                                if (flp.ketakugiri == true)
                                    suuchiZokusei.ShowSeparator = true;
                                else
                                    suuchiZokusei.ShowSeparator = false;
                                //最大値　デフォルト
                                suuchiZokusei.MaximumValue = 999999999999;

                                pspdObj.Columns[flp.colum_position].CellType = suuchiZokusei;

                                break;
                            case 2:     //通貨
                                break;
                            case 3:     //パーセント
                                break;
                            case 4:     //リッチテキスト
                                break;
                            case 5:     //チェックボックス
                                break;
                            case 6:     //コンボボックス
                                break;
                            case 7:     //日付
                                FarPoint.Win.Spread.CellType.DateTimeCellType dateZokusei = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                                pspdObj.Columns[flp.colum_position].CellType = dateZokusei;
                                break;
                            case 8:     //リストボックス
                                break;
                            case 9:     //ボタン
                                break;
                            default:
                                FarPoint.Win.Spread.CellType.TextCellType defZokusei = new FarPoint.Win.Spread.CellType.TextCellType();
                                defZokusei.MaxLength = 20;       //最大入力文字数
                                pspdObj.Columns[flp.colum_position].CellType = defZokusei;
                                break;
                        }

                        //列のセルのデフォルト表示位置　垂直
                        if (flp.suicyoku_ichi != null)
                        {
                            switch ((int)flp.suicyoku_ichi)
                            {
                                case 0:
                                    pspdObj.ColumnHeader.Columns[flp.colum_position].VerticalAlignment = CellVerticalAlignment.Top;
                                    break;
                                case 1:
                                    pspdObj.ColumnHeader.Columns[flp.colum_position].VerticalAlignment = CellVerticalAlignment.Bottom;
                                    break;
                                case 2:
                                    pspdObj.ColumnHeader.Columns[flp.colum_position].VerticalAlignment = CellVerticalAlignment.Center;
                                    break;
                            }
                        }
                        //列のセルのデフォルト表示位置　水平
                        if (flp.suicyoku_ichi != null)
                        {
                            switch ((int)flp.suicyoku_ichi)
                            {
                                case 0:
                                    pspdObj.ColumnHeader.Columns[flp.colum_position].HorizontalAlignment = CellHorizontalAlignment.Left;
                                    break;
                                case 1:
                                    pspdObj.ColumnHeader.Columns[flp.colum_position].HorizontalAlignment = CellHorizontalAlignment.Right;
                                    break;
                                case 2:
                                    pspdObj.ColumnHeader.Columns[flp.colum_position].HorizontalAlignment = CellHorizontalAlignment.Center;
                                    break;
                            }
                        }

                    }

                }
               
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        
        /// <summary>
        /// 奇数/偶数カラー設定
        /// </summary>
        /// <param name="pspdObj">スプレッドシートインスタンス</param>
        /// <returns>true：正常終了　false：エラー</returns>
        public static bool SetColorAlternating(SheetView pspdObj)
        {
            try
            {
                // スプレッド 偶数/奇数行で行のカラー変更
                pspdObj.AlternatingRows.Count = 2;
                pspdObj.AlternatingRows[0].BackColor = System.Drawing.Color.White;
                pspdObj.AlternatingRows[1].BackColor = System.Drawing.Color.PapayaWhip;

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 行ヘッダーのサイズ、文字の設定　固定値
        /// </summary>
        /// <param name="pspdObj"></param>
        public static void setSpreadRowHeader(SheetView pspdObj)
        {
            //行ヘッダーの列幅　デフォルト
            pspdObj.RowHeader.Columns[0].Width = 25;
            pspdObj.RowHeader.Columns[0].Font = new Font("MS UI Gothic", 8);
            pspdObj.RowHeader.Columns[0].HorizontalAlignment = CellHorizontalAlignment.Right;
            pspdObj.RowHeader.Columns[0].VerticalAlignment = CellVerticalAlignment.Center;
        }

        /// <summary>
        /// 行の高さを揃える
        /// </summary>
        /// <param name="pspdObj"></param>
        /// <returns></returns>
        public static bool SetRowsHeight(SheetView pspdObj)
        {
            try
            {
                //行の高さを設定　引数で指定できるように！
                int rows_count = pspdObj.RowCount;
                int rows_hight = 40;  //最低限度の高さ
                for (int i = 0; i < rows_count; i++)
                {
                    // 最も高さのあるテキストの高さに設定します
                    pspdObj.Rows[i].Height = (rows_hight > pspdObj.GetPreferredRowHeight(i) ? rows_hight : pspdObj.GetPreferredRowHeight(i));
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 列を固定する
        /// </summary>
        /// <param name="pspdObj"></param>
        /// <param name="ColumnCount"></param>
        /// <returns></returns>
        public static bool SetFrozenColumn(SheetView pspdObj, int ColumnCount)
        {
            try
            {
                //固定列数の設定 引数で指定できるように！
                pspdObj.FrozenColumnCount = (int)ColumnCount;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

   
        /// <summary>
        /// フォーカス設定処理
        /// </summary>
        /// <param name="pspdObj">スプレッドシートインスタンス</param>
        /// <param name="pintRow">行位置</param>
        /// <param name="pintCol">列位置</param>
        /// <returns>true：正常終了　false：エラー</returns>
        /// <remark>
        /// フォーカス設定を行います
        /// </remark>
        public static bool SetCellFocus(FpSpread pspdObj, int pintRow, int pintCol)
        {
            try
            {
                pspdObj.Sheets[0].SetActiveCell(pintRow, pintCol);        // アクティブセル

                // 行：セルまたは行の位置を近い方の端
                // 列：セルまたは列の位置を近い方の端
                //  ※ Nearestパラメータは指定したセルが表示されていない場合のみ、表示中のセルを変更または移動します。
                if(pintRow < pspdObj.GetViewportTopRow(0))
                    pspdObj.ShowActiveCell(VerticalPosition.Top, HorizontalPosition.Nearest);
                else if(pspdObj.GetViewportBottomRow(0) < pintRow)
                    pspdObj.ShowActiveCell(VerticalPosition.Bottom, HorizontalPosition.Nearest);

                pspdObj.Focus();

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// スプレッド標準キー 無効処理(表示用)
        /// </summary>
        /// <param name="pspdObj">スプレッドシートインスタンス</param>
        /// <returns>true：正常終了　false：エラー</returns>
        /// <remark>
        /// 各起動時に実行してください。
        /// TAB：フォーカス移動用にします
        /// ESC：通常画面の終了に使用します など
        /// 
        /// ※　スプレッド読み取り専用の場合必要なし(OperationModeの設定だけ)
        /// 　　標準でキーを取得したい場合に使用します
        /// </remark>
        public static bool InitDispInputMap(FpSpread pspdObj)
        {
            try
            {
                // WhenAncestorOfFocused 入力マップ 
                // コントロールまたはその子にフォーカスがある場合（セル編集モード）　
                InputMap linpMap01 = pspdObj.GetInputMap(InputMapMode.WhenAncestorOfFocused);
                linpMap01.Put(new Keystroke(Keys.Escape, Keys.None), SpreadActions.None);   // ESC
                linpMap01.Put(new Keystroke(Keys.Tab, Keys.None), SpreadActions.None);      // TAB
                linpMap01.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.None);    // Enter
                linpMap01.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);       // F2()
                linpMap01.Put(new Keystroke(Keys.F3, Keys.None),SpreadActions.None);        // F3
                linpMap01.Put(new Keystroke(Keys.F4, Keys.None), SpreadActions.None);       // F4
                linpMap01.Put(new Keystroke(Keys.Tab, Keys.Shift, false),SpreadActions.None);

                // WhenFocused 入力マップ 
                // コントロールにフォーカスがある場合（セル非編集モード）
                InputMap linpMap02 = pspdObj.GetInputMap(InputMapMode.WhenFocused);
                linpMap02.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.None);    // Enter

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// スプレッド連続入力設定処理
        /// </summary>
        /// <param name="pspdObj">スプレッドシートインスタンス</param>
        /// <returns>true：正常終了　false：エラー</returns>
        /// <remark>
        /// 連続入力用初期処理を行います
        /// </remark>
        public static bool InitRenzokuInput(FpSpread pspdObj)
        {
            try
            {
                // 連続入力用 初期処理
                // セルがアクティブになったときにそのセルを編集モード
                pspdObj.EditModePermanent = true;

                // 編集中セルの Enterキー押下による動作を無効とします。
                InputMap linpMap = pspdObj.GetInputMap(InputMapMode.WhenAncestorOfFocused);
                linpMap.Put(new Keystroke(Keys.Enter, Keys.None),SpreadActions.None);

                //-----------------------------------------------------------------------------
                // ※ EditModeOn/EditModeOffのイベントは各自記述する必要があります
                //
                // [EditModeOn]の場合
                //  spdXXX.EditingControl.KeyDown += 
                //                new System.Windows.Forms.KeyEventHandler( this.spdXXX_KeyDown );
                // [EditModeOff]の場合
                //  spdXXX.EditingControl.KeyDown -= 
                //                new System.Windows.Forms.KeyEventHandler( this.spdXXX_KeyDown );
                //-----------------------------------------------------------------------------

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// スプレッド通常入力設定処理
        /// </summary>
        /// <param name="pspdObj">スプレッドシートインスタンス</param>
        /// <param name="EnterAction">Enterキー入力時の動作</param>
        /// <returns>true：正常終了　false：エラー</returns>
        /// <remark>
        /// 通常入力用初期処理を行います
        /// </remark>
        public static bool InitNormalInput(FpSpread pspdObj, object EnterAction)
        {
            try
            {
                // 通常入力用 初期処理
                InputMap linpMap = pspdObj.GetInputMap(InputMapMode.WhenAncestorOfFocused);
                linpMap.Put(new Keystroke(Keys.Enter, Keys.None), EnterAction);

                //-----------------------------------------------------------------------------
                // ※ EditModeOn/EditModeOffのイベントは各自記述する必要があります
                //
                // [EditModeOn]の場合
                //  spdXXX.EditingControl.KeyDown += 
                //                new System.Windows.Forms.KeyEventHandler( this.spdXXX_KeyDown );
                // [EditModeOff]の場合
                //  spdXXX.EditingControl.KeyDown -= 
                //                new System.Windows.Forms.KeyEventHandler( this.spdXXX_KeyDown );
                //-----------------------------------------------------------------------------

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// スプレッドクリア処理
        /// </summary>
        /// <param name="pspdObj">スプレッドシートインスタンス</param>
        /// <returns>true：正常終了　false：エラー</returns>
        /// <remark>
        /// 初期化を行います
        /// </remark>
        public static bool clearSpreadSheet(FpSpread pspdObj,SheetView psheet)
        {
            try
            {
                //---------------------------------------------------------------------------------
                // ■ クリア
                //---------------------------------------------------------------------------------
                psheet.ClearRange(0, 0,
                                      psheet.RowCount,
                                      psheet.ColumnCount,
                                      false);
                //---------------------------------------------------------------------------------
                // ■ 先頭をアクティブへ
                //---------------------------------------------------------------------------------
                psheet.SetActiveCell(0, 0);            // アクティブセル

                // 行：セルまたは行の位置を近い方の端
                // 列：セルまたは列の位置を近い方の端
                //  ※ Nearestパラメータは指定したセルが表示されていない場合のみ、表示中のセルを変更または移動します。
                if(pspdObj.GetViewportTopRow(0) <= 0 &&
                    pspdObj.GetViewportBottomRow(0) >= 0)
                {
                }
                else
                {
                    pspdObj.ShowActiveCell(VerticalPosition.Top,
                                          HorizontalPosition.Nearest);
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        //**********************************************************************
        /// <summary>
        /// 対象カラム出力有無確認
        /// </summary>
        /// <param name="pobjColumn">対象カラム情報</param>
        /// <returns>true:出力あり false:出力なし</returns>
        //**********************************************************************
        public static bool CheckSheetViewColumns(FarPoint.Win.Spread.Column pobjColumn)
        {
            try
            {
                // 非表示確認
                if (!pobjColumn.Visible)
                {
                    return false;
                }
                // CellType確認
                if (pobjColumn.CellType is FarPoint.Win.Spread.CellType.CheckBoxCellType)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        //**********************************************************************
        /// <summary>
        /// SheetView→CSV出力文字変換
        /// </summary>
        /// <param name="lobjSheetView">DataTable</param>
        /// <returns>CSV出力文字</returns>
        //**********************************************************************
        public static string SheetViewToCsv(FarPoint.Win.Spread.SheetView lobjSheetView)
        {
            string lstrR = "";
            try
            {
                string lstrCsvRule;
                string lstrField;

                //--------------------------------------
                // 引数確認
                //--------------------------------------
                if (lobjSheetView.ColumnCount < 1)
                {
                    return "";
                }

                //--------------------------------------
                // 区切り線作成
                //--------------------------------------
                lstrCsvRule = "";
                for (int lintC = 0; lintC < lobjSheetView.ColumnCount; lintC++)
                {
                    if (!CheckSheetViewColumns(lobjSheetView.Columns[lintC]))
                    {
                        continue;
                    }
                    // 列幅にあわせて"-"の個数を決める
                    lstrCsvRule += ",";
                    lstrCsvRule += new string('-', (int)Math.Ceiling((decimal)lobjSheetView.Columns[lintC].Width / 5));
                }
                lstrCsvRule = lstrCsvRule.Substring(1).Trim();

                //--------------------------------------
                // ヘッダ
                //--------------------------------------
                if (
                   (lobjSheetView.ColumnHeader.Visible == true)
                && (lobjSheetView.ColumnHeader.RowCount > 0)
                   )
                {
                    lstrField = "";
                    for (int lintC = 0; lintC < lobjSheetView.ColumnCount; lintC++)
                    {
                        if (!CheckSheetViewColumns(lobjSheetView.Columns[lintC]))
                        {
                            continue;
                        }
                        lstrField += ",";
                        lstrField += mfnc_EncloseDoubleQuotesIfNeed(mfnc_ToString(lobjSheetView.ColumnHeader.Cells.Get(0, lintC).Value));
                    }
                    lstrR += lstrField.Substring(1) + Environment.NewLine;
                }

                //--------------------------------------
                // レコード
                //--------------------------------------
                for (int lintR = 0; lintR < lobjSheetView.RowCount; lintR++)
                {
                    lstrField = "";
                    for (int lintC = 0; lintC < lobjSheetView.ColumnCount; lintC++)
                    {
                        if (!CheckSheetViewColumns(lobjSheetView.Columns[lintC]))
                        {
                            continue;
                        }
                        // CellTypeが日付の場合"yyyy/MM/dd"形式に変換
                        string lstrTmp = mfnc_ToString(lobjSheetView.Cells[lintR, lintC].Value);
                        if (lobjSheetView.Columns[lintC].CellType is FarPoint.Win.Spread.CellType.DateTimeCellType)
                        {
                            DateTime ldteTmp;
                            if (DateTime.TryParse(lstrTmp, out ldteTmp))
                            {
                                lstrTmp = ldteTmp.ToString("yyyy/MM/dd");
                            }
                        }
                        //
                        lstrField += ",";
                        lstrField += mfnc_EncloseDoubleQuotesIfNeed(lstrTmp);
                    }
                    lstrR += lstrField.Substring(1) + Environment.NewLine;
                }

                //--------------------------------------
                // 区切り線
                //--------------------------------------
                lstrR += lstrCsvRule + Environment.NewLine;

                //--------------------------------------
                // フッタ
                //--------------------------------------
                if (
                   (lobjSheetView.ColumnFooter.Visible == true)
                && (lobjSheetView.ColumnFooter.RowCount > 0)
                   )
                {
                    lstrField = "";
                    for (int lintC = 0; lintC < lobjSheetView.ColumnCount; lintC++)
                    {
                        if (!CheckSheetViewColumns(lobjSheetView.Columns[lintC]))
                        {
                            continue;
                        }
                        lstrField += ",";
                        lstrField += mfnc_EncloseDoubleQuotesIfNeed(mfnc_ToString(lobjSheetView.ColumnFooter.Cells.Get(0, lintC).Value));
                    }
                    lstrR += lstrField.Substring(1) + Environment.NewLine;
                }

            }
            catch
            {
            }
            return lstrR;
        }

        //**********************************************************************
        /// <summary>
        /// 文字変換
        /// </summary>
        /// <remarks>
        /// null等、変換に例外が発生する場合は""とする
        /// </remarks>
        /// <param name="pobjData">変換前データ</param>
        /// <returns>文字列</returns>
        //**********************************************************************
        private static string mfnc_ToString(object pobjData)
        {
            try
            {
                return pobjData.ToString();
            }
            catch
            {
                return "";
            }
        }

        //**********************************************************************
        /// <summary>
        /// 必要ならば、文字列をダブルクォートで囲む
        /// </summary>
        /// <param name="pstrField">対象文字列</param>
        /// <returns>変換後文字列</returns>
        //**********************************************************************
        private static string mfnc_EncloseDoubleQuotesIfNeed(string pstrField)
        {
            if (mfnc_NeedEncloseDoubleQuotes(pstrField))
            {
                return mfnc_EncloseDoubleQuotes(pstrField);
            }
            return pstrField;
        }

        //**********************************************************************
        /// <summary>
        /// 文字列をダブルクォートで囲む
        /// </summary>
        /// <param name="pstrField">対象文字列</param>
        /// <returns>変換後文字列</returns>
        //**********************************************************************
        private static string mfnc_EncloseDoubleQuotes(string pstrField)
        {
            if (pstrField.IndexOf('"') > -1)
            {
                //"を""とする
                pstrField = pstrField.Replace("\"", "\"\"");
            }
            return "\"" + pstrField + "\"";
        }

        //**********************************************************************
        /// <summary>
        /// 文字列をダブルクォートで囲む必要があるか調べる
        /// </summary>
        /// <param name="pstrField">対象文字列</param>
        /// <returns>true:必要 false:不要</returns>
        //**********************************************************************
        private static bool mfnc_NeedEncloseDoubleQuotes(string pstrField)
        {
            return pstrField.IndexOf('"') > -1 ||
                pstrField.IndexOf(',') > -1 ||
                pstrField.IndexOf('\r') > -1 ||
                pstrField.IndexOf('\n') > -1 ||
                pstrField.StartsWith(" ") ||
                pstrField.StartsWith("\t") ||
                pstrField.EndsWith(" ") ||
                pstrField.EndsWith("\t");
        }



    }
}
