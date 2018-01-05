using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
//using Oracle.DataAccess.Client;
using Npgsql;
using FarPoint.Win;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.Model;
using FarPoint.Win.Spread.CellType;
using System.Globalization;
using B2.Com;
using System.Linq;
using System.Reflection;
using Microsoft.VisualBasic;

namespace B2
{
    public partial class FormProject : Form
    {
        #region // ■ ローカル変数  定義  ■
        
        // コンストラクタ 引数 (  PHARMA共通クラス  )
        private clsB2Com PhCom;         //上位からの共通パラメータ　DB接続情報など

        private decimal save_pno = 0m;  //退避用

        #endregion
        
           public FormProject()
        {
            InitializeComponent();
        }


        public FormProject(clsB2Com PHCommon)
        {
            //引数を退避
            PhCom = PHCommon;

            //自動作成・・・初期化
            InitializeComponent();

            //データフィールドの初期化
            txt_pno.Text = "";
            txt_pname.Text = "";
            txt_user_name.Text = "";
            txt_orderno.Text = "";
            txt_maker.Text = "";
            txt_parson.Text = "";
            txt_bikou.Text = "";
        }

        private void FormProject_Load(object sender, EventArgs e)
        {
        }

        private void FormProject_Shown(object sender, EventArgs e)
        {
        }


        private void txt_pno_KeyDown(object sender, KeyEventArgs e)
        {
            //Enterキーが押された時
            switch (e.KeyCode)
            {
                // エンターキー
                case Keys.Enter:
                    e.Handled = true;
                    //数値かチェックする。
                    decimal chk_pno = 0m;
                    if (!decimal.TryParse(txt_pno.Text.ToString(), out chk_pno))
                    {
                        MessageBox.Show("プロジェクト№は数値のみ許可されています。\n\r入力して下さい。", this.Text);
                        txt_pno.Focus();
                        return;
                    }
                    else
                    {
                        //データフィールドの初期化
                        txt_pname.Text = "";
                        txt_user_name.Text = "";
                        txt_orderno.Text = "";
                        txt_maker.Text = "";
                        txt_parson.Text = "";
                        txt_bikou.Text = "";
                        
                        //既に登録済みの場合は情報を取得しセットする
                        getDbProjectInfo(chk_pno);
                    }


                    txt_pname.Focus();
                    break;
            }
        }

        private void getDbProjectInfo(decimal p_no)
        {
            //---------プロジェクト情報　データベースからの読み込み------------------
            PhCom.PostLib.SQLClear();

            PhCom.PostLib.SQL.Append(" select プロジェクト番号, プロジェクト名, 受注管理番号, 顧客名, 発注元名, 発注元担当者, 備考  \r\n");
            PhCom.PostLib.SQL.Append(" from プロジェクト  \r\n");
            PhCom.PostLib.SQL.Append(" where プロジェクト番号 = '" + p_no.ToString() + "'  \r\n");

            using (NpgsqlDataReader lOraDSRead = PhCom.PostLib.SelectSQL_NoCache())
            {
                if (lOraDSRead != null)
                {
                    while (lOraDSRead.Read())
                    {
                        // データセットへ表示データをセット
                        save_pno = p_no;
                        txt_pname.Text = lOraDSRead["プロジェクト名"] is DBNull ? "" : lOraDSRead["プロジェクト名"].ToString();
                        txt_user_name.Text = lOraDSRead["顧客名"] is DBNull ? "" : lOraDSRead["顧客名"].ToString();
                        txt_orderno.Text = lOraDSRead["受注管理番号"] is DBNull ? "" : lOraDSRead["受注管理番号"].ToString();
                        txt_maker.Text = lOraDSRead["発注元名"] is DBNull ? "" : lOraDSRead["発注元名"].ToString();
                        txt_parson.Text = lOraDSRead["発注元担当者"] is DBNull ? "" : lOraDSRead["発注元担当者"].ToString();
                        txt_bikou.Text = lOraDSRead["備考"] is DBNull ? "" : lOraDSRead["備考"].ToString();
                        break;
                    }
                    lOraDSRead.Close();
                }
            }
        }


        private void txt_pname_KeyDown(object sender, KeyEventArgs e)
        {
            //Enterキーが押された時
            switch (e.KeyCode)
            {
                // エンターキー
                case Keys.Enter:
                    e.Handled = true;
                    txt_user_name.Focus();
                    break;
            }
        }

        private void txt_user_name_KeyDown(object sender, KeyEventArgs e)
        {
            //Enterキーが押された時
            switch (e.KeyCode)
            {
                // エンターキー
                case Keys.Enter:
                    e.Handled = true;
                    txt_orderno.Focus();
                    break;
            }
        }

        private void txt_orderno_KeyDown(object sender, KeyEventArgs e)
        {
            //Enterキーが押された時
            switch (e.KeyCode)
            {
                // エンターキー
                case Keys.Enter:
                    e.Handled = true;
                    txt_maker.Focus();
                    break;
            }
        }

        private void txt_maker_KeyDown(object sender, KeyEventArgs e)
        {
            //Enterキーが押された時
            switch (e.KeyCode)
            {
                // エンターキー
                case Keys.Enter:
                    e.Handled = true;
                    txt_parson.Focus();
                    break;
            }
        }

        private void txt_parson_KeyDown(object sender, KeyEventArgs e)
        {
            //Enterキーが押された時
            switch (e.KeyCode)
            {
                // エンターキー
                case Keys.Enter:
                    e.Handled = true;
                    txt_bikou.Focus();
                    break;
            }
        }

        private void txt_bikou_KeyDown(object sender, KeyEventArgs e)
        {
            //Enterキーが押された時
            switch (e.KeyCode)
            {
                // エンターキー
                case Keys.Enter:
                    e.Handled = true;
                    btn_Ok.Focus();
                    break;
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            int mode = 0;   //0:new 1:update

            decimal chk_pno = 0m;
            if (!decimal.TryParse(txt_pno.Text.ToString(), out chk_pno))
            {
                MessageBox.Show("プロジェクト№は数値のみ許可されています。\n\r入力して下さい。", this.Text);
                txt_pno.Focus();
                return;
            }

            if (save_pno == 0) mode = 0;
            else if (save_pno == chk_pno) mode = 1;
            else mode = 0;

            StringBuilder strSql = new StringBuilder();

            if (mode == 0)
            {
                //新規追加
                strSql.Remove(0, strSql.Length);
                strSql.Append(" insert into プロジェクト " + Environment.NewLine);
                strSql.Append(" (プロジェクト番号, プロジェクト名, 受注管理番号, 顧客名, 発注元名, 発注元担当者, 備考) " + Environment.NewLine);
                strSql.Append(" values( " + Environment.NewLine);
                strSql.Append("     '" + (txt_pno.Text != ""?txt_pno.Text.ToString():"") + "'   " + Environment.NewLine);
                strSql.Append("    ,'" + (txt_pname.Text != ""?txt_pname.Text.ToString():"") + "'   " + Environment.NewLine);
                strSql.Append("    ,'" + (txt_orderno.Text != ""?txt_orderno.Text.ToString():"") + "'   " + Environment.NewLine);
                strSql.Append("    ,'" + (txt_user_name.Text != ""?txt_user_name.Text.ToString():"") + "'   " + Environment.NewLine);
                strSql.Append("    ,'" + (txt_maker.Text != ""?txt_maker.Text.ToString():"") + "'   " + Environment.NewLine);
                strSql.Append("    ,'" + (txt_parson.Text != ""?txt_parson.Text.ToString():"") + "'   " + Environment.NewLine);
                strSql.Append("    ,'" + (txt_bikou.Text != "" ? txt_bikou.Text.ToString() : "") + "'   " + Environment.NewLine);
                strSql.Append("      )" + Environment.NewLine);

                if (PhCom.PostLib.ExecuteSQL(strSql.ToString()) < 0)
                {
                    MessageBox.Show(this.Text + "プロジェクト情報の挿入処理でエラーが発生しました。", this.Text);
                    strSql.Remove(0, strSql.Length);
                    strSql.Append(" rollback  " + Environment.NewLine);
                    PhCom.PostLib.ExecuteSQL(strSql.ToString());
                    return ;
                }

                strSql.Remove(0, strSql.Length);
                strSql.Append(" commit  " + Environment.NewLine);
                if (PhCom.PostLib.ExecuteSQL(strSql.ToString()) < 0)
                {
                    MessageBox.Show(this.Text + "プロジェクト情報挿入確定処理でエラーが発生しました。", this.Text);
                    strSql.Remove(0, strSql.Length);
                    strSql.Append(" rollback  " + Environment.NewLine);
                    PhCom.PostLib.ExecuteSQL(strSql.ToString());
                    return ;
                }

                MessageBox.Show("プロジェクト情報を追加しました。", this.Text);
            }
            else
            {
                //更新
                strSql.Remove(0, strSql.Length);
                strSql.Append(" update プロジェクト  " + Environment.NewLine);
                strSql.Append("    set プロジェクト名 = '" + (txt_pname.Text != "" ? txt_pname.Text.ToString() : "") + "'   " + Environment.NewLine);
                strSql.Append("   , 受注管理番号 = '" + (txt_orderno.Text != "" ? txt_orderno.Text.ToString() : "") + "'   " + Environment.NewLine);
                strSql.Append("   , 顧客名 = '" + (txt_user_name.Text != "" ? txt_user_name.Text.ToString() : "") + "'   " + Environment.NewLine);
                strSql.Append("   , 発注元名 = '" + (txt_maker.Text != "" ? txt_maker.Text.ToString() : "") + "'   " + Environment.NewLine);
                strSql.Append("   , 発注元担当者 = '" + (txt_parson.Text != "" ? txt_parson.Text.ToString() : "") + "'   " + Environment.NewLine);
                strSql.Append("   , 備考 = '" + (txt_bikou.Text != "" ? txt_bikou.Text.ToString() : "") + "'   " + Environment.NewLine);
                strSql.Append(" where プロジェクト番号 = '" + txt_pno.Text.ToString() +"'  " + Environment.NewLine);

                // 更新処理の実行
                if (PhCom.PostLib.ExecuteSQL(strSql.ToString()) < 0)
                {
                    MessageBox.Show(this.Text + "プロジェクト情報の更新処理でエラーが発生しました。", this.Text);
                    strSql.Remove(0, strSql.Length);
                    strSql.Append(" rollback  " + Environment.NewLine);
                    PhCom.PostLib.ExecuteSQL(strSql.ToString());
                    return;
                }

                strSql.Remove(0, strSql.Length);
                strSql.Append(" commit  " + Environment.NewLine);
                if (PhCom.PostLib.ExecuteSQL(strSql.ToString()) < 0)
                {
                    MessageBox.Show(this.Text + "プロジェクト情報更新確定処理でエラーが発生しました。", this.Text);
                    strSql.Remove(0, strSql.Length);
                    strSql.Append(" rollback  " + Environment.NewLine);
                    PhCom.PostLib.ExecuteSQL(strSql.ToString());
                    return;
                }
                MessageBox.Show("プロジェクト情報を更新しました。", this.Text);
            }

            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            //Cancel
            this.Close();
        }


    }
}
