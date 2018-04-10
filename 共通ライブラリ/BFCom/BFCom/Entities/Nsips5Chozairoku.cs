namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>NSIPS調剤録部テーブル</summary>
	[Table("nsips5_chozairoku")]
	public partial class Nsips5Chozairoku
	{ 
		/// <summary>Nsips5調剤録ID</summary>
		[Key]
		[Column("nsips5_chozairoku_id")]
		public int? Nsips5ChozairokuId { get; set; }

		/// <summary>Nsips0ヘッダID</summary>
		[Column("nsips0_header_id")]
		public int? Nsips0HeaderId { get; set; }

		/// <summary>識別子</summary>
		[Column("stype")]
		public int? Stype { get; set; }

		/// <summary>薬剤料の合計</summary>
		[Column("yakuzairyo_no_goke")]
		public decimal? YakuzairyoNoGoke { get; set; }

		/// <summary>調剤料の合計</summary>
		[Column("chozairyo_no_goke")]
		public decimal? ChozairyoNoGoke { get; set; }

		/// <summary>指導管理料の合計</summary>
		[Column("shidokanriryo_no_goke")]
		public decimal? ShidokanriryoNoGoke { get; set; }

		/// <summary>特定保険医療材料料</summary>
		[Column("tokutei_hokeniryo_zairyo_ryo")]
		public decimal? TokuteiHokeniryoZairyoRyo { get; set; }

		/// <summary>保険請求点数</summary>
		[Column("hokenseikyu_tensu")]
		public decimal? HokenseikyuTensu { get; set; }

		/// <summary>基本加算</summary>
		[Column("kihon_kazan")]
		public decimal? KihonKazan { get; set; }

		/// <summary>調剤基本料</summary>
		[Column("chozai_kihonryo")]
		public decimal? ChozaiKihonryo { get; set; }

		/// <summary>加算の合計</summary>
		[Column("kazan_no_goke")]
		public decimal? KazanNoGoke { get; set; }

		/// <summary>薬歴</summary>
		[Column("yakureki")]
		public decimal? Yakureki { get; set; }

		/// <summary>その他の指導料</summary>
		[Column("sonota_no_shidoryo")]
		public decimal? SonotaNoShidoryo { get; set; }

		/// <summary>加算等</summary>
		[Column("kazanto")]
		public decimal? Kazanto { get; set; }

		/// <summary>合計点数</summary>
		[Column("goke_tensu")]
		public decimal? GokeTensu { get; set; }

		/// <summary>一部負担金</summary>
		[Column("itibu_futankin")]
		public decimal? ItibuFutankin { get; set; }

		/// <summary>容器金額</summary>
		[Column("yoki_kingaku")]
		public decimal? YokiKingaku { get; set; }

		/// <summary>その他の金額</summary>
		[Column("sonota_no_kingaku")]
		public decimal? SonotaNoKingaku { get; set; }

		/// <summary>前回迄未収金</summary>
		[Column("zenkaimade_mishukin")]
		public decimal? ZenkaimadeMishukin { get; set; }

		/// <summary>今回請求額</summary>
		[Column("konkai_seikyugaku")]
		public decimal? KonkaiSeikyugaku { get; set; }

		/// <summary>合計請求額</summary>
		[Column("goke_seikyugaku")]
		public decimal? GokeSeikyugaku { get; set; }

		/// <summary>今回入金額</summary>
		[Column("konkai_nyukingaku")]
		public decimal? KonkaiNyukingaku { get; set; }

		/// <summary>未収金</summary>
		[Column("mishukin")]
		public decimal? Mishukin { get; set; }

		/// <summary>ファイル更新区分</summary>
		[Column("fupdkbn")]
		public string Fupdkbn { get; set; }

		/// <summary>有効区分</summary>
		[Column("yuko_flag")]
		public int? YukoFlag { get; set; }

		/// <summary> コンストラクタ</summary>
		public Nsips5Chozairoku()
		{

			Nsips5ChozairokuId = 0;
			Nsips0HeaderId = 0;
			Stype = 0;
			YakuzairyoNoGoke = 0;
			ChozairyoNoGoke = 0;
			ShidokanriryoNoGoke = 0;
			TokuteiHokeniryoZairyoRyo = 0;
			HokenseikyuTensu = 0;
			KihonKazan = 0;
			ChozaiKihonryo = 0;
			KazanNoGoke = 0;
			Yakureki = 0;
			SonotaNoShidoryo = 0;
			Kazanto = 0;
			GokeTensu = 0;
			ItibuFutankin = 0;
			YokiKingaku = 0;
			SonotaNoKingaku = 0;
			ZenkaimadeMishukin = 0;
			KonkaiSeikyugaku = 0;
			GokeSeikyugaku = 0;
			KonkaiNyukingaku = 0;
			Mishukin = 0;
			Fupdkbn = "";
			YukoFlag = 0;

		}
	} 
} 
