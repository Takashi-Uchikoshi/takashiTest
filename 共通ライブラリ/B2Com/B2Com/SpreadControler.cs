using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.Model;
using System.IO;

namespace B2.Com
{
    /// <summary>
    /// 列属性クラス
    /// </summary>
    public class SpreadColumData
    {
        /// <summary>
        /// 列位置
        /// </summary>
        public int Position;
        /// <summary>
        /// 列幅サイズ
        /// </summary>
        public float? Width;
        /// <summary>
        /// 列のラベル名
        /// </summary>
        public string Label;
        /// <summary>
        /// 列の表示有無(true:表示  false:非表示)
        /// </summary>
        public bool Visible;
        /// <summary>
        /// セルのフォント名
        /// </summary>
        public string FontMei;
        /// <summary>
        /// セルのフォントサイズ
        /// </summary>
        public float? FontSize;
        /// <summary>
        /// セルの垂直表示位置(0:上 1:下　2:中央)
        /// </summary>
        public int? VirticalAlingment;
        /// <summary>
        /// セルの水平表示位置(0:左 1:右　2:中央)
        /// </summary>
        public int? HorizontalAlingment;
        /// <summary>
        /// セルの属性(0:ﾃｷｽﾄ 1:数値 2:通貨 3:ﾊﾟｰｾﾝﾄ 4:ﾘｯﾁﾃｷｽﾄ 5:ﾁｪｯｸﾎﾞｯｸｽ 6:ｺﾝﾎﾞﾎﾞｯｸｽ 7:日付 8:ﾘｽﾄﾎﾞｯｸｽ 9:ﾎﾞﾀﾝ)
        /// </summary>
        public int? CellType;
        /// <summary>
        /// テキストの最大文字数
        /// </summary>
        public int? MaxLength;
        /// <summary>
        /// 数値の小数点以下桁数
        /// </summary>
        public int? DecimalPlaces;
        /// <summary>
        /// 数値の区切り表示(true:3桁区切りあり　false:3桁区切り無し)
        /// </summary>
        public bool ShowSeparator;
        /// <summary>
        /// テキストのワードラップ(true:折り返しあり　false：折り返し無し)
        /// </summary>
        public bool WordWrap;

        /// <summary>
        /// コンストラクタ
        /// 引数なし　初期化します。
        /// </summary>
        public SpreadColumData()
        {
          Position = -1;
          Width = null;
          Label = string.Empty;
          Visible = true;
          FontMei = string.Empty;
          FontSize = null;
          VirticalAlingment = null;
          HorizontalAlingment = null;
          CellType = null;
          MaxLength = null;
          DecimalPlaces = null;
          ShowSeparator = false;
          WordWrap = false;
        }
    }

    /// <summary>
    /// スプレッド操作クラス
    /// </summary>
    [LicenseProviderAttribute(typeof(LicenseProvider))]
    public class SpreadControler
    {
        /// <summary>
        /// 列情報に従い、列の属性をセットする。
        /// </summary>
        /// <param name="pspdObj">列属性を設定するSheetView</param>
        /// <param name="listp">列属性クラスの配列</param>
        /// <returns>true:正常終了 false:エラー</returns>
        public static bool setSpreadColumInfo(SheetView pspdObj,List<SpreadColumData> listp)
        {
            try
            {
                foreach (SpreadColumData flp in listp)
                {
                    if (flp.Position < 0)
                    {
                        continue;
                    }

                    if (!string.IsNullOrEmpty(flp.Label))
                    {
                        pspdObj.ColumnHeader.Columns[flp.Position].Label = flp.Label;
                    }
                    if(flp.Visible == false)
                    {
                        pspdObj.ColumnHeader.Columns[flp.Position].Visible = false;
                    }
                    if (flp.Width != null && 0 < flp.Width)
                    {
                        pspdObj.Columns[flp.Position].Width = (float)flp.Width;
                    }
                    
                    if (flp.CellType != null && (0 <= flp.CellType && flp.CellType <= 10))
                    {
                        switch (flp.CellType)
                        {
                            case 0:
                                // テキスト
                                FarPoint.Win.Spread.CellType.TextCellType textZokusei = new FarPoint.Win.Spread.CellType.TextCellType();
                                if (flp.MaxLength != null)
                                {
                                    textZokusei.MaxLength = (int)flp.MaxLength;
                                }
                                if (flp.WordWrap == true)
                                {
                                    textZokusei.Multiline = true;
                                    textZokusei.WordWrap = true;
                                }
                                pspdObj.Columns[flp.Position].CellType = textZokusei;
                                break;

                            case 1:
                                // 数値
                                FarPoint.Win.Spread.CellType.NumberCellType suuchiZokusei = new FarPoint.Win.Spread.CellType.NumberCellType();
                                if (flp.DecimalPlaces != null && flp.DecimalPlaces != 0)
                                {
                                    suuchiZokusei.DecimalPlaces = (int)flp.DecimalPlaces;
                                }
                                if (flp.ShowSeparator == true)
                                {
                                    suuchiZokusei.ShowSeparator = true;
                                }
                                else
                                {
                                    suuchiZokusei.ShowSeparator = false;
                                }
                                suuchiZokusei.MaximumValue = 999999999999;
                                pspdObj.Columns[flp.Position].CellType = suuchiZokusei;
                                break;

                            case 2:
                                // 通貨
                                // TODO : 未実装
                                break;

                            case 3:
                                // パーセント
                                // TODO : 未実装
                                break;

                            case 4:
                                // リッチテキスト
                                // TODO : 未実装
                                break;

                            case 5:
                                // チェックボックス
                                // TODO : 未実装
                                break;

                            case 6:
                                // コンボボックス
                                // TODO : 未実装
                                break;

                            case 7:
                                // 日付
                                FarPoint.Win.Spread.CellType.DateTimeCellType dateZokusei = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                                pspdObj.Columns[flp.Position].CellType = dateZokusei;
                                break;

                            case 8:
                                // リストボックス
                                // TODO : 未実装
                                break;

                            case 9:
                                // ボタン
                                // TODO : 未実装
                                break;

                            default:
                                // 上記以外はテキストにする
                                FarPoint.Win.Spread.CellType.TextCellType defZokusei = new FarPoint.Win.Spread.CellType.TextCellType();
                                defZokusei.MaxLength = 20;
                                pspdObj.Columns[flp.Position].CellType = defZokusei;
                                break;
                        }

                        if (flp.VirticalAlingment != null)
                        {
                            switch ((int)flp.VirticalAlingment)
                            {
                                case 0:
                                    pspdObj.ColumnHeader.Columns[flp.Position].VerticalAlignment = CellVerticalAlignment.Top;
                                    break;
                                case 1:
                                    pspdObj.ColumnHeader.Columns[flp.Position].VerticalAlignment = CellVerticalAlignment.Bottom;
                                    break;
                                case 2:
                                    pspdObj.ColumnHeader.Columns[flp.Position].VerticalAlignment = CellVerticalAlignment.Center;
                                    break;
                            }
                        }
                        if (flp.HorizontalAlingment != null)
                        {
                            switch ((int)flp.HorizontalAlingment)
                            {
                                case 0:
                                    pspdObj.ColumnHeader.Columns[flp.Position].HorizontalAlignment = CellHorizontalAlignment.Left;
                                    break;
                                case 1:
                                    pspdObj.ColumnHeader.Columns[flp.Position].HorizontalAlignment = CellHorizontalAlignment.Right;
                                    break;
                                case 2:
                                    pspdObj.ColumnHeader.Columns[flp.Position].HorizontalAlignment = CellHorizontalAlignment.Center;
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
        /// <param name="pspdObj">カラー設定するSheetView</param>
        /// <returns>true：正常終了 false：エラー</returns>
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
        /// <param name="pspdObj">行ヘッダーを設定するSheetView</param>
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
        /// <param name="pspdObj">行の高さを設定するSheetView</param>
        /// <returns>true:正常終了 false:エラー</returns>
        public static bool SetRowsHeight(SheetView pspdObj)
        {
            try
            {
                int rows_count = pspdObj.RowCount;
                int rows_hight = 40;
                for (int i = 0; i < rows_count; i++)
                {
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
        /// <param name="pspdObj">列を固定するSheetView</param>
        /// <param name="ColumnCount">固定する列数</param>
        /// <returns>true:正常終了 false:エラー</returns>
        public static bool SetFrozenColumn(SheetView pspdObj, int ColumnCount)
        {
            try
            {
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
        /// <param name="pspdObj">フォーカス設定をするFpSpread</param>
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
                pspdObj.Sheets[0].SetActiveCell(pintRow, pintCol);

                // 行：セルまたは行の位置を近い方の端
                // 列：セルまたは列の位置を近い方の端
                //  ※ Nearestパラメータは指定したセルが表示されていない場合のみ、表示中のセルを変更または移動します。
                if (pintRow < pspdObj.GetViewportTopRow(0))
                {
                    pspdObj.ShowActiveCell(VerticalPosition.Top, HorizontalPosition.Nearest);
                }
                else if (pspdObj.GetViewportBottomRow(0) < pintRow)
                {
                    pspdObj.ShowActiveCell(VerticalPosition.Bottom, HorizontalPosition.Nearest);
                }

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
        /// <param name="pspdObj">標準キー処理を無効化するFpSpread</param>
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
                linpMap01.Put(new Keystroke(Keys.Escape, Keys.None), SpreadActions.None);
                linpMap01.Put(new Keystroke(Keys.Tab, Keys.None), SpreadActions.None);
                linpMap01.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.None);
                linpMap01.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);
                linpMap01.Put(new Keystroke(Keys.F3, Keys.None),SpreadActions.None);
                linpMap01.Put(new Keystroke(Keys.F4, Keys.None), SpreadActions.None);
                linpMap01.Put(new Keystroke(Keys.Tab, Keys.Shift, false),SpreadActions.None);

                // WhenFocused 入力マップ 
                // コントロールにフォーカスがある場合（セル非編集モード）
                InputMap linpMap02 = pspdObj.GetInputMap(InputMapMode.WhenFocused);
                linpMap02.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.None);

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
        /// <param name="pspdObj">連続入力の初期設定をするFpSpread</param>
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
        /// <param name="pspdObj">通常入力処理の設定をするFpSpread</param>
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
        /// <param name="pspdObj">クリア処理をするFpSpread</param>
        /// <param name="psheet">クリア処理をするSheetView</param>
        /// <returns>true：正常終了　false：エラー</returns>
        /// <remark>
        /// 初期化を行います
        /// </remark>
        public static bool clearSpreadSheet(FpSpread pspdObj,SheetView psheet)
        {
            try
            {
                psheet.ClearRange(0, 0,
                                      psheet.RowCount,
                                      psheet.ColumnCount,
                                      false);
                psheet.SetActiveCell(0, 0);

                // 行：セルまたは行の位置を近い方の端
                // 列：セルまたは列の位置を近い方の端
                //  ※ Nearestパラメータは指定したセルが表示されていない場合のみ、表示中のセルを変更または移動します。
                if(pspdObj.GetViewportTopRow(0) <= 0 && 0 <= pspdObj.GetViewportBottomRow(0))
                {
                }
                else
                {
                    pspdObj.ShowActiveCell(VerticalPosition.Top, HorizontalPosition.Nearest);
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 対象カラム出力有無確認
        /// </summary>
        /// <param name="pobjColumn">対象カラム情報</param>
        /// <returns>true:出力あり false:出力なし</returns>
        public static bool CheckSheetViewColumns(FarPoint.Win.Spread.Column pobjColumn)
        {
            try
            {
                if (!pobjColumn.Visible)
                {
                    return false;
                }
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

        /// <summary>
        /// SheetView→CSV出力文字変換
        /// </summary>
        /// <param name="lobjSheetView">DataTable</param>
        /// <returns>CSV出力文字</returns>
        public static string SheetViewToCsv(FarPoint.Win.Spread.SheetView lobjSheetView)
        {
            string lstrR = "";
            try
            {
                string lstrCsvRule;
                string lstrField;

                if (lobjSheetView.ColumnCount < 1)
                {
                    return "";
                }

                // 区切り線
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

                // ヘッダ作成
                if (lobjSheetView.ColumnHeader.Visible == true && 0 < lobjSheetView.ColumnHeader.RowCount)
                {
                    lstrField = "";
                    for (int lintC = 0; lintC < lobjSheetView.ColumnCount; lintC++)
                    {
                        if (!CheckSheetViewColumns(lobjSheetView.Columns[lintC]))
                        {
                            continue;
                        }
                        lstrField += ",";
                        lstrField += SpreadControler.EncloseDoubleQuotesIfNeed(SpreadControler.ToString(lobjSheetView.ColumnHeader.Cells.Get(0, lintC).Value));
                    }
                    lstrR += lstrField.Substring(1) + Environment.NewLine;
                }

                // データ出力
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
                        string lstrTmp = SpreadControler.ToString(lobjSheetView.Cells[lintR, lintC].Value);
                        if (lobjSheetView.Columns[lintC].CellType is FarPoint.Win.Spread.CellType.DateTimeCellType)
                        {
                            DateTime ldteTmp;
                            if (DateTime.TryParse(lstrTmp, out ldteTmp))
                            {
                                lstrTmp = ldteTmp.ToString("yyyy/MM/dd");
                            }
                        }
                        lstrField += ",";
                        lstrField += SpreadControler.EncloseDoubleQuotesIfNeed(lstrTmp);
                    }
                    lstrR += lstrField.Substring(1) + Environment.NewLine;
                }

                // 区切り線
                lstrR += lstrCsvRule + Environment.NewLine;

                // フッタ作成
                if (lobjSheetView.ColumnFooter.Visible == true && 0 < lobjSheetView.ColumnFooter.RowCount)
                {
                    lstrField = "";
                    for (int lintC = 0; lintC < lobjSheetView.ColumnCount; lintC++)
                    {
                        if (!CheckSheetViewColumns(lobjSheetView.Columns[lintC]))
                        {
                            continue;
                        }
                        lstrField += ",";
                        lstrField += SpreadControler.EncloseDoubleQuotesIfNeed(SpreadControler.ToString(lobjSheetView.ColumnFooter.Cells.Get(0, lintC).Value));
                    }
                    lstrR += lstrField.Substring(1) + Environment.NewLine;
                }
            }
            catch
            {
            }
            return lstrR;
        }

        /// <summary>
        /// SheetView→CSV出力文字変換
        /// </summary>
        /// <param name="Sheet1">CSV出力をするSheetView</param>
        /// <param name="st_row">出力開始行</param>
        /// <param name="st_colum">出力開始列</param>
        /// <param name="end_row">出力終了行</param>
        /// <param name="end_colum">出力終了列</param>
        /// <returns>CSV出力文字</returns>
        public static string SheetViewToCsv(FarPoint.Win.Spread.SheetView Sheet1, int st_row, int st_colum, int end_row, int end_colum)
        {
            try
            {
                // 明細を連結
                MemoryStream st = new MemoryStream();
                Sheet1.SaveTextFileRange(st_row, st_colum, end_row, end_colum, st, TextFileFlags.None, IncludeHeaders.ColumnHeadersCustomOnly, Environment.NewLine, ",", "");
                string detailData = Encoding.GetEncoding("shift_jis").GetString(st.ToArray());

                return detailData;
            }
            catch (Exception /*ex*/)
            {
                return string.Empty;                
            }
        }

        /// <summary>
        /// 文字変換
        /// </summary>
        /// <remarks>
        /// null等、変換に例外が発生する場合は""とする
        /// </remarks>
        /// <param name="pobjData">変換前データ</param>
        /// <returns>文字列</returns>
        private static string ToString(object pobjData)
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

        /// <summary>
        /// 必要ならば、文字列をダブルクォートで囲む
        /// </summary>
        /// <param name="pstrField">対象文字列</param>
        /// <returns>変換後文字列</returns>
        private static string EncloseDoubleQuotesIfNeed(string pstrField)
        {
            if (SpreadControler.NeedEncloseDoubleQuotes(pstrField))
            {
                return SpreadControler.EncloseDoubleQuotes(pstrField);
            }
            return pstrField;
        }

        /// <summary>
        /// 文字列をダブルクォートで囲む
        /// </summary>
        /// <param name="pstrField">対象文字列</param>
        /// <returns>変換後文字列</returns>
        private static string EncloseDoubleQuotes(string pstrField)
        {
            if (pstrField.IndexOf('"') > -1)
            {
                pstrField = pstrField.Replace("\"", "\"\"");
            }
            return "\"" + pstrField + "\"";
        }

        /// <summary>
        /// 文字列をダブルクォートで囲む必要があるか調べる
        /// </summary>
        /// <param name="pstrField">対象文字列</param>
        /// <returns>true:必要 false:不要</returns>
        private static bool NeedEncloseDoubleQuotes(string pstrField)
        {
            return pstrField.IndexOf('"') > -1
                    || pstrField.IndexOf(',') > -1
                    || pstrField.IndexOf('\r') > -1
                    || pstrField.IndexOf('\n') > -1
                    || pstrField.StartsWith(" ")
                    || pstrField.StartsWith("\t")
                    || pstrField.EndsWith(" ")
                    || pstrField.EndsWith("\t");
        }
    }
}
