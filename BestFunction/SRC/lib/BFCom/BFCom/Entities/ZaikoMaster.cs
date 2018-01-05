namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>在庫管理マスタ</summary>
	[Table("zaiko_master")]
	public partial class ZaikoMaster
	{ 
		/// <summary>薬局コード</summary>
		[Key]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>YJコード</summary>
		[Key]
		[Column("yj_code", Order = 1)]
		public string YjCode { get; set; }

		/// <summary>GTINコード</summary>
		[Key]
		[Column("gtin_code", Order = 2)]
		public string GtinCode { get; set; }

		/// <summary>JANコード</summary>
		[Key]
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

		/// <summary>登録日</summary>
		[Column("insert_date")]
		public DateTime? InsertDate { get; set; }

		/// <summary>更新日</summary>
		[Column("update_date")]
		public DateTime? UpdateDate { get; set; }

		/// <summary>使用開始</summary>
		[Key]
		[Column("start_use_date", Order = 4)]
		public int? StartUseDate { get; set; }

		/// <summary>使用終了</summary>
		[Key]
		[Column("end_use_date", Order = 5)]
		public int? EndUseDate { get; set; }

		/// <summary>通知識別</summary>
		[Column("tsuuchi_sikibetu")]
		public int? TsuuchiSikibetu { get; set; }

		/// <summary>通知日時</summary>
		[Column("tsuuchi_date")]
		public DateTime? TsuuchiDate { get; set; }

		/// <summary> コンストラクタ</summary>
		public ZaikoMaster()
		{

			YakkyokuCode = "";
			YjCode = "";
			GtinCode = "";
			JanCode = "";
			MeisaiCode = "";
			ZaikoTotal = 0;
			Genka = 0;
			InsertDate = null;
			UpdateDate = null;
			StartUseDate = 0;
			EndUseDate = 0;
			TsuuchiSikibetu = 0;
			TsuuchiDate = null;

		}
	} 
} 
