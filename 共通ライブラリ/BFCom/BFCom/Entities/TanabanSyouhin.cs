namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>棚番商品管理マスタ</summary>
	[Table("tanaban_syouhin")]
	public partial class TanabanSyouhin
	{ 
		/// <summary>薬局コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>棚番コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("tanaban_code", Order = 1)]
		public string TanabanCode { get; set; }

		/// <summary>GTINコード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("gtin_code", Order = 2)]
		public string GtinCode { get; set; }

		/// <summary>段</summary>
		[Column("dan")]
		public string Dan { get; set; }

		/// <summary>列</summary>
		[Column("retu")]
		public string Retu { get; set; }

		/// <summary>備考</summary>
		[Column("bikou")]
		public string Bikou { get; set; }

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

		/// <summary>通知識別</summary>
		[Column("tsuchi_sikibetsu")]
		public int? TsuchiSikibetsu { get; set; }

		/// <summary>通知日時</summary>
		[Column("tsuchi_date")]
		public DateTime? TsuchiDate { get; set; }

		/// <summary>削除フラグ</summary>
		[Column("sakujyo_flag")]
		public int? SakujyoFlag { get; set; }

		/// <summary> コンストラクタ</summary>
		public TanabanSyouhin()
		{

			YakkyokuCode = "";
			TanabanCode = "";
			GtinCode = "";
			Dan = "";
			Retu = "";
			Bikou = "";
			InsertUserId = 0;
			InsertNitiji = null;
			UpdateUserId = 0;
			UpdateNitiji = null;
			TsuchiSikibetsu = 0;
			TsuchiDate = null;
			SakujyoFlag = 0;

		}
	} 
} 
