namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>成分マスタ</summary>
	[Table("seibun_master")]
	public partial class SeibunMaster
	{ 
		/// <summary>成分コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("seibun_code", Order = 0)]
		public string SeibunCode { get; set; }

		/// <summary>成分名</summary>
		[Column("seibun_mei")]
		public string SeibunMei { get; set; }

		/// <summary>成分名フリガナ</summary>
		[Column("seibun_kana")]
		public string SeibunKana { get; set; }

		/// <summary>適用開始年月日</summary>
		[Column("apply_start_ymd")]
		public string ApplyStartYmd { get; set; }

		/// <summary>適用終了年月日</summary>
		[Column("apply_end_ymd")]
		public string ApplyEndYmd { get; set; }

		/// <summary>登録者ID</summary>
		[Column("insert_user_id")]
		public int? InsertUserId { get; set; }

		/// <summary>登録日時</summary>
		[Column("insert_nitiji")]
		public DateTime? InsertNitiji { get; set; }

		/// <summary>更新者ID</summary>
		[Column("update_user_id")]
		public int? UpdateUserId { get; set; }

		/// <summary>更新日時</summary>
		[Column("update_nitiji")]
		public DateTime? UpdateNitiji { get; set; }

		/// <summary>更新プログラムID</summary>
		[Column("update_program_id")]
		public string UpdateProgramId { get; set; }

		/// <summary>管理属性</summary>
		[Column("kanri_zokusei")]
		public int? KanriZokusei { get; set; }

		/// <summary> コンストラクタ</summary>
		public SeibunMaster()
		{

			SeibunCode = "";
			SeibunMei = "";
			SeibunKana = "";
			ApplyStartYmd = "";
			ApplyEndYmd = "";
			InsertUserId = 0;
			InsertNitiji = null;
			UpdateUserId = 0;
			UpdateNitiji = null;
			UpdateProgramId = "";
			KanriZokusei = 0;

		}
	} 
} 
