namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>棚卸明細</summary>
	[Table("tanaoroshi_meisai")]
	public partial class TanaoroshiMeisai
	{ 
		/// <summary>棚卸明細ID</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("tanaoroshi_id", Order = 0)]
		public int? TanaoroshiId { get; set; }

		/// <summary>棚卸ID</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("tanaoroshi_header_id", Order = 1)]
		public int? TanaoroshiHeaderId { get; set; }

		/// <summary>薬局コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("yakkyoku_code", Order = 2)]
		public string YakkyokuCode { get; set; }

		/// <summary>PDSコード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("pds_code", Order = 3)]
		public string PdsCode { get; set; }

		/// <summary>使用期限</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("shiyou_kigen", Order = 4)]
		public string ShiyouKigen { get; set; }

		/// <summary>ロット番号</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("lot_bango", Order = 5)]
		public string LotBango { get; set; }

		/// <summary>GTINコード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("gtin_code", Order = 6)]
		public string GtinCode { get; set; }

		/// <summary>棚番コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("tanaban_code", Order = 7)]
		public string TanabanCode { get; set; }

		/// <summary>箱数</summary>
		[Column("hako_qty")]
		public decimal? HakoQty { get; set; }

		/// <summary>包装数</summary>
		[Column("housou_qty")]
		public decimal? HousouQty { get; set; }

		/// <summary>バラ数</summary>
		[Column("bara_qty")]
		public decimal? BaraQty { get; set; }

		/// <summary>端末名</summary>
		[Column("tanmatsu_mei")]
		public string TanmatsuMei { get; set; }

		/// <summary>登録方法</summary>
		[Column("touroku_houhou")]
		public string TourokuHouhou { get; set; }

		/// <summary>登録者ID</summary>
		[Column("insert_user_id")]
		public int? InsertUserId { get; set; }

		/// <summary>登録日時</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("insert_nitiji", Order = 8)]
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

		/// <summary>登録スタッフ名</summary>
		[Column("insert_staff_name")]
		public string InsertStaffName { get; set; }

		/// <summary>登録スタッフ名</summary>
		[Column("update_staff_name")]
		public string UpdateStaffName { get; set; }

		/// <summary>未開封フラグ</summary>
		[Column("mikaifu_flag")]
		public bool? MikaifuFlag { get; set; }

		/// <summary>不動フラグ</summary>
		[Column("fudo_flag")]
		public bool? FudoFlag { get; set; }

		/// <summary> コンストラクタ</summary>
		public TanaoroshiMeisai()
		{

			TanaoroshiId = 0;
			TanaoroshiHeaderId = 0;
			YakkyokuCode = "";
			PdsCode = "";
			ShiyouKigen = "";
			LotBango = "";
			GtinCode = "";
			TanabanCode = "";
			HakoQty = 0;
			HousouQty = 0;
			BaraQty = 0;
			TanmatsuMei = "";
			TourokuHouhou = "";
			InsertUserId = 0;
			InsertNitiji = null;
			UpdateUserId = 0;
			UpdateNitiji = null;
			UpdateProgramId = "";
			InsertStaffName = "";
			UpdateStaffName = "";
			MikaifuFlag = false;
			FudoFlag = false;

		}
	} 
} 
