namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>棚卸ヘッダ</summary>
	[Table("tanaoroshi_header")]
	public partial class TanaoroshiHeader
	{ 
		/// <summary>棚卸ID</summary>
		[Key]
		[Column("tanaoroshi_id", Order = 0)]
		public int? TanaoroshiId { get; set; }

		/// <summary>薬局コード</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>棚卸年月日</summary>
		[Column("tanaoroshi_ymd")]
		public string TanaoroshiYmd { get; set; }

		/// <summary>棚卸名</summary>
		[Column("tanaoroshi_mei")]
		public string TanaoroshiMei { get; set; }

		/// <summary>棚卸完了フラグ</summary>
		[Column("tanaoroshi_kanryou_flag")]
		public string TanaoroshiKanryouFlag { get; set; }

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

		/// <summary>通知識別</summary>
		[Column("tsuuchi_sikibetu")]
		public int? TsuuchiSikibetu { get; set; }

		/// <summary>通知日時</summary>
		[Column("tsuuchi_date")]
		public DateTime? TsuuchiDate { get; set; }

		/// <summary> コンストラクタ</summary>
		public TanaoroshiHeader()
		{

			TanaoroshiId = 0;
			YakkyokuCode = "";
			TanaoroshiYmd = "";
			TanaoroshiMei = "";
			TanaoroshiKanryouFlag = "";
			InsertUserId = 0;
			InsertNitiji = null;
			UpdateUserId = 0;
			UpdateNitiji = null;
			UpdateProgramId = "";
			TsuuchiSikibetu = 0;
			TsuuchiDate = null;

		}
	} 
} 
