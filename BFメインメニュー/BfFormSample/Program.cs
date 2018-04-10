using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using B2.Com;
using Npgsql;

namespace B2.BestFunction
{
    static class Program
    {
        #region 機能概要
        /*
         *  ログイン用ユーザーアカウントのマスタメンテ機能
         */
        #endregion

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //----------------------------------------------------
            // 二重起動をチェックする
            //----------------------------------------------------
            System.Diagnostics.Process[] ps =
                System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            if (1 < ps.Length)
            {
                //すでに起動していると判断して終了
                MessageBox.Show("既に起動しています。");
                return;
            }

            //----------------------------------------------------
            // 初期処理
            //----------------------------------------------------
            //B2共通パラメータの定義
            B2Com b2com = new B2Com();

            // 初期処理　共通パラメータの情報設定
            if (!b2com.Initialize(true))
                return;

            // データベース初期化処理（接続） EntityFrameworkとは別の接続
            if (!b2com.InitDb(true))
                return;

            //----------------------------------------------------
            // 画面の呼び出し
            //----------------------------------------------------
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BfFormSample frm = new BfFormSample(b2com);
            Application.Run(frm);

            //----------------------------------------------------
            // 終了処理
            //----------------------------------------------------
            //DBのクローズ処理
            b2com.CloseDb();
        }
    }
}
