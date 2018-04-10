namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>棚卸開始データ</summary>
	[Table("tanaoroshi_kaishi")]
	public partial class TanaoroshiKaishi
	{ 
		/// <summary>薬局コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>YJコード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("yj_code", Order = 1)]
		public string YjCode { get; set; }

		/// <summary>GTINコード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("gtin_code", Order = 2)]
		public string GtinCode { get; set; }

		/// <summary>JANコード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("jan_code", Order = 3)]
		public string JanCode { get; set; }

		/// <summary>明細コード</summary>
		[Column("meisai_code")]
		public string MeisaiCode { get; set; }

		/// <summary>在庫数</summary>
		[Column("zaiko_total")]
		public decimal? ZaikoTotal { get; set; }

		/// <summary>原価単価</summary>
		[Column("genka")]
		public decimal? Genka { get; set; }

		/// <summary>棚卸数</summary>
		[Column("suryo")]
		public decimal? Suryo { get; set; }

		/// <summary>差異数</summary>
		[Column("sai_suryo")]
		public decimal? SaiSuryo { get; set; }

		/// <summary>棚卸開始日</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("start_use_date", Order = 4)]
		public DateTime? StartUseDate { get; set; }

		/// <summary>棚卸終了日</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("end_use_date", Order = 5)]
		public DateTime? EndUseDate { get; set; }

		/// <summary> コンストラクタ</summary>
		public TanaoroshiKaishi()
		{

			YakkyokuCode = "";
			YjCode = "";
			GtinCode = "";
			JanCode = "";
			MeisaiCode = "";
			ZaikoTotal = 0;
			Genka = 0;
			Suryo = 0;
			SaiSuryo = 0;
			StartUseDate = null;
			EndUseDate = null;

		}
	} 
} 
