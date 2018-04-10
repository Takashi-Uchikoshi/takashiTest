namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>調剤数</summary>
	[Table("chozai_suryo")]
	public partial class ChozaiSuryo
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

		/// <summary>予測調剤数</summary>
		[Column("yosoku_chozai_suryo")]
		public decimal? YosokuChozaiSuryo { get; set; }

		/// <summary>月平均調剤数</summary>
		[Column("tsuki_heikin_chozai_suryo")]
		public decimal? TsukiHeikinChozaiSuryo { get; set; }

		/// <summary>来局予定の調剤数</summary>
		[Column("raikyokuyotei_chozai_suryo")]
		public decimal? RaikyokuyoteiChozaiSuryo { get; set; }

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
		public ChozaiSuryo()
		{

			YakkyokuCode = "";
			YjCode = "";
			GtinCode = "";
			JanCode = "";
			YosokuChozaiSuryo = 0;
			TsukiHeikinChozaiSuryo = 0;
			RaikyokuyoteiChozaiSuryo = 0;
			InsertDate = null;
			UpdateDate = null;
			TsuchiSikibetsu = 0;
			TsuchiDate = null;

		}
	} 
} 
