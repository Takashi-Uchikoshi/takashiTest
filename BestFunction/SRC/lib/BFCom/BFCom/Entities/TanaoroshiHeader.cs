namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>Iµwb_</summary>
	[Table("tanaoroshi_header")]
	public partial class TanaoroshiHeader
	{ 
		/// <summary>IµID</summary>
		[Key]
		[Column("tanaoroshi_id", Order = 0)]
		public int? TanaoroshiId { get; set; }

		/// <summary>òÇR[h</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>IµNú</summary>
		[Column("tanaoroshi_ymd")]
		public string TanaoroshiYmd { get; set; }

		/// <summary>Iµ¼</summary>
		[Column("tanaoroshi_mei")]
		public string TanaoroshiMei { get; set; }

		/// <summary>Iµ®¹tO</summary>
		[Column("tanaoroshi_kanryou_flag")]
		public string TanaoroshiKanryouFlag { get; set; }

		/// <summary>o^ÒID</summary>
		[Column("insert_user_id")]
		public int? InsertUserId { get; set; }

		/// <summary>o^ú</summary>
		[Column("insert_nitiji")]
		public DateTime? InsertNitiji { get; set; }

		/// <summary>XVÒID</summary>
		[Column("update_user_id")]
		public int? UpdateUserId { get; set; }

		/// <summary>XVú</summary>
		[Column("update_nitiji")]
		public DateTime? UpdateNitiji { get; set; }

		/// <summary>XVvOID</summary>
		[Column("update_program_id")]
		public string UpdateProgramId { get; set; }

		/// <summary>Êm¯Ê</summary>
		[Column("tsuuchi_sikibetu")]
		public int? TsuuchiSikibetu { get; set; }

		/// <summary>Êmú</summary>
		[Column("tsuuchi_date")]
		public DateTime? TsuuchiDate { get; set; }

		/// <summary> RXgN^</summary>
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
