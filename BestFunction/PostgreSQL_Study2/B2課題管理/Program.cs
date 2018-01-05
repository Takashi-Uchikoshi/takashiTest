using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using B2.Com;
using Npgsql;

namespace B2
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            clsB2Com phcom = new clsB2Com();

            // 初期処理
            if (!phcom.gfncInitialize(true))
                return;

            // データベース初期化処理（接続） EntityFrameworkとは別の接続
            if (!phcom.gfncInitDb(true))
                return;

            // 処理日にシステム日付を設定
            //phcom.SyoriYMD = DateTime.Now.ToString("yyyyMMdd");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new MainForm());

            FormMain frm = new FormMain(phcom);
            //frm.PhCom = phcom;
            Application.Run(frm);

            //必要なのか！？---> 必要のようです。closeしないとエラーメッセージが出る。
            //Oracleではcloseしていなかったが、本来は必要！
            phcom.gfncCloseDb();
        }
    }
}
