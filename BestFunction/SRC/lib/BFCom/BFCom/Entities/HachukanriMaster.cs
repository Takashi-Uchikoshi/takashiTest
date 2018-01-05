namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>発注管理情報マスタ</summary>
	[Table("hachukanri_master")]
	public partial class HachukanriMaster
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

		/// <summary>発注候補区分</summary>
		[Column("hachukoho_kubun")]
		public int? HachukohoKubun { get; set; }

		/// <summary>発注点</summary>
		[Column("hachuten_suryo")]
		public decimal? HachutenSuryo { get; set; }

		/// <summary>安全在庫数量</summary>
		[Column("anzenzaiko_suryo")]
		public decimal? AnzenzaikoSuryo { get; set; }

		/// <summary>来局予定分</summary>
		[Column("raikyokubun")]
		public int? Raikyokubun { get; set; }

		/// <summary>リードタイム日数</summary>
		[Column("leadtime")]
		public int? Leadtime { get; set; }

		/// <summary>予測最大調剤数の乗数</summary>
		[Column("yosoku_jyousu")]
		public decimal? YosokuJyousu { get; set; }

		/// <summary>バラとヒートを合算する</summary>
		[Column("barahito_gassan")]
		public int? BarahitoGassan { get; set; }

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
		public HachukanriMaster()
		{

			YakkyokuCode = "";
			YjCode = "";
			GtinCode = "";
			JanCode = "";
			HachukohoKubun = 0;
			HachutenSuryo = 0;
			AnzenzaikoSuryo = 0;
			Raikyokubun = 0;
			Leadtime = 0;
			YosokuJyousu = 0;
			BarahitoGassan = 0;
			StartUseDate = 0;
			EndUseDate = 0;
			TsuuchiSikibetu = 0;
			TsuuchiDate = null;

		}
	} 
} 
