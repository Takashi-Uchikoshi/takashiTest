namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>ＬＯＴ情報管理マスタ</summary>
	[Table("lotinfo_master")]
	public partial class LotinfoMaster
	{ 
		/// <summary>薬局コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>YJコード</summary>
		[Column("yj_code")]
		public string YjCode { get; set; }

		/// <summary>GTINコード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("gtin_code", Order = 1)]
		public string GtinCode { get; set; }

		/// <summary>JANコード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("jan_code", Order = 2)]
		public string JanCode { get; set; }

		/// <summary>使用期限</summary>
		[Column("shiyo_kigen")]
		public string ShiyoKigen { get; set; }

		/// <summary>ロット</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("lot_bango", Order = 3)]
		public string LotBango { get; set; }

		/// <summary>入庫数</summary>
		[Column("in_count")]
		public decimal? InCount { get; set; }

		/// <summary>出庫数</summary>
		[Column("out_count")]
		public decimal? OutCount { get; set; }

		/// <summary>箱数</summary>
		[Column("hako_suryo")]
		public decimal? HakoSuryo { get; set; }

		/// <summary>包装数</summary>
		[Column("hoso_suryo")]
		public decimal? HosoSuryo { get; set; }

		/// <summary>バラ数</summary>
		[Column("bara_suryo")]
		public decimal? BaraSuryo { get; set; }

		/// <summary>登録日</summary>
		[Column("insert_date")]
		public DateTime? InsertDate { get; set; }

		/// <summary>更新日</summary>
		[Column("update_date")]
		public DateTime? UpdateDate { get; set; }

		/// <summary>通知識別</summary>
		[Column("tsuchi_sikibetsu")]
		public int? TsuchiSikibetsu { get; set; }

		/// <summary>通知日時</summary>
		[Column("tsuchi_date")]
		public DateTime? TsuchiDate { get; set; }

		/// <summary> コンストラクタ</summary>
		public LotinfoMaster()
		{

			YakkyokuCode = "";
			YjCode = "";
			GtinCode = "";
			JanCode = "";
			ShiyoKigen = "";
			LotBango = "";
			InCount = 0;
			OutCount = 0;
			HakoSuryo = 0;
			HosoSuryo = 0;
			BaraSuryo = 0;
			InsertDate = null;
			UpdateDate = null;
			TsuchiSikibetsu = 0;
			TsuchiDate = null;

		}
	} 
} 
