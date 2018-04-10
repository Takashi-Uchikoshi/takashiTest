namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>Picked薬品</summary>
	[Table("picked_yakuhin")]
	public partial class PickedYakuhin
	{ 
		/// <summary>PickedID</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("picked_id", Order = 0)]
		public int? PickedId { get; set; }

		/// <summary>処方箋ID</summary>
		[Column("shohosen_id")]
		public int? ShohosenId { get; set; }

		/// <summary>薬局コード</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>PickedYjID</summary>
		[Column("picked_yj_id")]
		public int? PickedYjId { get; set; }

		/// <summary>GTINコード</summary>
		[Column("gtin_code")]
		public string GtinCode { get; set; }

		/// <summary>箱数</summary>
		[Column("hako_qty")]
		public decimal? HakoQty { get; set; }

		/// <summary>包装数</summary>
		[Column("housou_qty")]
		public decimal? HousouQty { get; set; }

		/// <summary>バラ数</summary>
		[Column("bara_qty")]
		public decimal? BaraQty { get; set; }

		/// <summary>Lot番号</summary>
		[Column("lot_bango")]
		public string LotBango { get; set; }

		/// <summary>使用期限</summary>
		[Column("shiyou_kigen")]
		public DateTime? ShiyouKigen { get; set; }

		/// <summary>Picked日時</summary>
		[Column("picked_nitiji")]
		public DateTime? PickedNitiji { get; set; }

		/// <summary>分包機フラグ</summary>
		[Column("bunpoki_flag")]
		public int? BunpokiFlag { get; set; }

		/// <summary>登録日時</summary>
		[Column("insert_nitiji")]
		public DateTime? InsertNitiji { get; set; }

		/// <summary>登録ユーザーID</summary>
		[Column("insert_user_id")]
		public int? InsertUserId { get; set; }

		/// <summary>登録端末ID</summary>
		[Column("insert_tanmatsu_id")]
		public string InsertTanmatsuId { get; set; }

		/// <summary>登録プログラム</summary>
		[Column("insert_program")]
		public string InsertProgram { get; set; }

		/// <summary>更新日時</summary>
		[Column("update_nitiji")]
		public DateTime? UpdateNitiji { get; set; }

		/// <summary>更新ユーザーID</summary>
		[Column("update_user_id")]
		public int? UpdateUserId { get; set; }

		/// <summary>更新端末ID</summary>
		[Column("update_tanmatsu_id")]
		public string UpdateTanmatsuId { get; set; }

		/// <summary>更新プログラム</summary>
		[Column("update_program")]
		public string UpdateProgram { get; set; }

		/// <summary>ファイル名</summary>
		[Column("file_mei")]
		public string FileMei { get; set; }

		/// <summary>引落フラグ</summary>
		[Column("hikiotoshi")]
		public int? Hikiotoshi { get; set; }

		/// <summary> コンストラクタ</summary>
		public PickedYakuhin()
		{

			PickedId = 0;
			ShohosenId = 0;
			YakkyokuCode = "";
			PickedYjId = 0;
			GtinCode = "";
			HakoQty = 0;
			HousouQty = 0;
			BaraQty = 0;
			LotBango = "";
			ShiyouKigen = null;
			PickedNitiji = null;
			BunpokiFlag = 0;
			InsertNitiji = null;
			InsertUserId = 0;
			InsertTanmatsuId = "";
			InsertProgram = "";
			UpdateNitiji = null;
			UpdateUserId = 0;
			UpdateTanmatsuId = "";
			UpdateProgram = "";
			FileMei = "";
			Hikiotoshi = 0;

		}
	} 
} 
