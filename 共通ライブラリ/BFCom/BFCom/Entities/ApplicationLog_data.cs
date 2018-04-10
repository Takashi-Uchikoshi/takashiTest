namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>アプリケーションログテーブル</summary>
	[Table("application_log_data")]
	public partial class ApplicationLog_data
	{ 
		/// <summary>ログID</summary>
		[Key]
		[Column("log_id")]
		public int? LogId { get; set; }

		/// <summary>薬局コード</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>プログラム名</summary>
		[Column("program_filename")]
		public string ProgramFilename { get; set; }

		/// <summary>ログタイプ</summary>
		[Column("log_type")]
		public string LogType { get; set; }

		/// <summary>ログ内容</summary>
		[Column("log_data")]
		public string LogData { get; set; }

		/// <summary>備考</summary>
		[Column("bikou")]
		public string Bikou { get; set; }

		/// <summary>登録日時</summary>
		[Column("insert_nitiji")]
		public DateTime? InsertNitiji { get; set; }

		/// <summary> コンストラクタ</summary>
		public ApplicationLog_data()
		{

			LogId = 0;
			YakkyokuCode = "";
			ProgramFilename = "";
			LogType = "";
			LogData = "";
			Bikou = "";
			InsertNitiji = null;

		}
	} 
} 
