namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>ＬＯＴ情報管理マスタ</summary>
	[Table("lotinfo_master")]
	public partial class LotinfoMaster
	{ 
		/// <summary>薬局コード</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>YJコード</summary>
		[Key]
		[Column("yj_code", Order = 0)]
		public string YjCode { get; set; }

		/// <summary>GTINコード</summary>
		[Key]
		[Column("gtin_code", Order = 1)]
		public string GtinCode { get; set; }

		/// <summary>JANコード</summary>
		[Key]
		[Column("jan_code", Order = 2)]
		public string JanCode { get; set; }

		/// <summary>入庫日</summary>
		[Column("nyuuko_date")]
		public DateTime? NyuukoDate { get; set; }

		/// <summary>使用期限</summary>
		[Column("siyou_ymd")]
		public DateTime? SiyouYmd { get; set; }

		/// <summary>製造番号</summary>
		[Column("lot")]
		public string Lot { get; set; }

		/// <summary>入庫数</summary>
		[Column("in_count")]
		public decimal? InCount { get; set; }

		/// <summary>出庫数</summary>
		[Column("out_count")]
		public decimal? OutCount { get; set; }

		/// <summary>登録日</summary>
		[Column("insert_date")]
		public DateTime? InsertDate { get; set; }

		/// <summary>更新日</summary>
		[Column("update_date")]
		public DateTime? UpdateDate { get; set; }

		/// <summary>通知識別</summary>
		[Column("tsuuchi_sikibetu")]
		public int? TsuuchiSikibetu { get; set; }

		/// <summary>通知日時</summary>
		[Column("tsuuchi_date")]
		public DateTime? TsuuchiDate { get; set; }

		/// <summary> コンストラクタ</summary>
		public LotinfoMaster()
		{

			YakkyokuCode = "";
			YjCode = "";
			GtinCode = "";
			JanCode = "";
			NyuukoDate = null;
			SiyouYmd = null;
			Lot = "";
			InCount = 0;
			OutCount = 0;
			InsertDate = null;
			UpdateDate = null;
			TsuuchiSikibetu = 0;
			TsuuchiDate = null;

		}
	} 
} 
