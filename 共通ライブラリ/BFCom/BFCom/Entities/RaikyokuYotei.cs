namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>来局予定</summary>
	[Table("raikyoku_yotei")]
	public partial class RaikyokuYotei
	{ 
		/// <summary>来局予定ID</summary>
		[Key]
		[Column("raikyoku_yotei_id")]
		public int? RaikyokuYoteiId { get; set; }

		/// <summary>薬局コード</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>患者ID</summary>
		[Column("kanjya_id")]
		public string KanjyaId { get; set; }

		/// <summary>YJコード</summary>
		[Column("yj_code")]
		public string YjCode { get; set; }

		/// <summary>GTINコード</summary>
		[Column("gtin_code")]
		public string GtinCode { get; set; }

		/// <summary>JANコード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("jan_code", Order = 0)]
		public string JanCode { get; set; }

		/// <summary>薬品数量</summary>
		[Column("YakuhinSuryo")]
		public decimal? YakuhinSuryo { get; set; }

		/// <summary>実績日時</summary>
		[Column("jisseki_nitiji")]
		public DateTime? JissekiNitiji { get; set; }

		/// <summary>予定日時</summary>
		[Column("yotei_nitiji")]
		public DateTime? YoteiNitiji { get; set; }

		/// <summary>予定分類</summary>
		[Column("yotei_bunrui")]
		public int? YoteiBunrui { get; set; }

		/// <summary>更新日時</summary>
		[Column("update_nitiji")]
		public DateTime? UpdateNitiji { get; set; }

		/// <summary> コンストラクタ</summary>
		public RaikyokuYotei()
		{

			RaikyokuYoteiId = 0;
			YakkyokuCode = "";
			KanjyaId = "";
			YjCode = "";
			GtinCode = "";
			JanCode = "";
			YakuhinSuryo = 0;
			JissekiNitiji = null;
			YoteiNitiji = null;
			YoteiBunrui = 0;
			UpdateNitiji = null;

		}
	} 
} 
