namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>棚番号管理マスタ</summary>
	[Table("tanaban_master")]
	public partial class TanabanMaster
	{ 
		/// <summary>棚番コード</summary>
		[Key]
		[Column("tanaban_code", Order = 0)]
		public string TanabanCode { get; set; }

		/// <summary>薬局コード</summary>
		[Key]
		[Column("yakkyoku_code", Order = 1)]
		public string YakkyokuCode { get; set; }

		/// <summary>棚番名</summary>
		[Column("tanaban_mei")]
		public string TanabanMei { get; set; }

		/// <summary>棚番コメント</summary>
		[Column("tanaban_comment")]
		public string TanabanComment { get; set; }

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

		/// <summary>使用開始</summary>
		[Key]
		[Column("start_use_date", Order = 2)]
		public int? StartUseDate { get; set; }

		/// <summary>使用終了</summary>
		[Key]
		[Column("end_use_date", Order = 3)]
		public int? EndUseDate { get; set; }

		/// <summary> コンストラクタ</summary>
		public TanabanMaster()
		{

			TanabanCode = "";
			YakkyokuCode = "";
			TanabanMei = "";
			TanabanComment = "";
			InsertUserId = 0;
			InsertNitiji = null;
			UpdateUserId = 0;
			UpdateNitiji = null;
			UpdateProgramId = "";
			StartUseDate = 0;
			EndUseDate = 0;

		}
	} 
} 
