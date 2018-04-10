namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>メッセージログテーブル</summary>
	[Table("log_data")]
	public partial class LogData
	{ 
		/// <summary>薬局コード</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>ログNo@ログファイルのSEQ</summary>
		[Key]
		[Column("logno")]
		public int? Logno { get; set; }

		/// <summary>日付</summary>
		[Column("logdate")]
		public DateTime? Logdate { get; set; }

		/// <summary>ﾌﾟﾛｸﾞﾗﾑID</summary>
		[Column("program_code")]
		public string ProgramCode { get; set; }

		/// <summary>分類コード</summary>
		[Column("bunrui")]
		public string Bunrui { get; set; }

		/// <summary>コンピュータ名</summary>
		[Column("client")]
		public string Client { get; set; }

		/// <summary>ログインID</summary>
		[Column("login_code")]
		public string LoginCode { get; set; }

		/// <summary>キーコード</summary>
		[Column("key_code")]
		public string KeyCode { get; set; }

		/// <summary>備考</summary>
		[Column("bikou")]
		public string Bikou { get; set; }

		/// <summary>EXEファイル名</summary>
		[Column("filename")]
		public string Filename { get; set; }

		/// <summary>実行時引数</summary>
		[Column("param")]
		public string Param { get; set; }

		/// <summary>有効フラグ</summary>
		[Column("enable")]
		public int? Enable { get; set; }

		/// <summary> コンストラクタ</summary>
		public LogData()
		{

			YakkyokuCode = "";
			Logno = 0;
			Logdate = null;
			ProgramCode = "";
			Bunrui = "";
			Client = "";
			LoginCode = "";
			KeyCode = "";
			Bikou = "";
			Filename = "";
			Param = "";
			Enable = 0;

		}
	} 
} 
