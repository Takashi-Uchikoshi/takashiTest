namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>NSIPS²Ü^e[u</summary>
	[Table("nsips5_chozairoku")]
	public partial class Nsips5Chozairoku
	{ 
		/// <summary>L[</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("nsips5_chozairoku_id")]
		public int? Nsips5ChozairokuId { get; set; }

		/// <summary>wb_[ÌL[</summary>
		[Column("nsips0_header_id")]
		public int? Nsips0HeaderId { get; set; }

		/// <summary>æú</summary>
		[Column("indate")]
		public int? Indate { get; set; }

		/// <summary>æAÔ</summary>
		[Column("inseq")]
		public int? Inseq { get; set; }

		/// <summary>t@CXVæª</summary>
		[Column("fupdkbn")]
		public string Fupdkbn { get; set; }

		/// <summary>t@Cà³ÒAÔ</summary>
		[Column("patseq")]
		public int? Patseq { get; set; }

		/// <summary>¯Êq</summary>
		[Column("stype")]
		public int? Stype { get; set; }

		/// <summary>òÜ¿Ìv</summary>
		[Column("yakuzairyo_no_goke")]
		public decimal? YakuzairyoNoGoke { get; set; }

		/// <summary>²Ü¿Ìv</summary>
		[Column("chozairyo_no_goke")]
		public decimal? ChozairyoNoGoke { get; set; }

		/// <summary>w±Ç¿Ìv</summary>
		[Column("shidokanriryo_no_goke")]
		public decimal? ShidokanriryoNoGoke { get; set; }

		/// <summary>ÁèÛ¯ãÃÞ¿¿</summary>
		[Column("tokutei_hokeniryo_zairyo_ryo")]
		public decimal? TokuteiHokeniryoZairyoRyo { get; set; }

		/// <summary>Û¯¿_</summary>
		[Column("hokenseikyu_tensu")]
		public decimal? HokenseikyuTensu { get; set; }

		/// <summary>î{ÁZ</summary>
		[Column("kihon_kazan")]
		public decimal? KihonKazan { get; set; }

		/// <summary>²Üî{¿</summary>
		[Column("chozai_kihonryo")]
		public decimal? ChozaiKihonryo { get; set; }

		/// <summary>ÁZÌv</summary>
		[Column("kazan_no_goke")]
		public decimal? KazanNoGoke { get; set; }

		/// <summary>òð</summary>
		[Column("yakureki")]
		public decimal? Yakureki { get; set; }

		/// <summary>»Ì¼Ìw±¿</summary>
		[Column("sonota_no_shidoryo")]
		public decimal? SonotaNoShidoryo { get; set; }

		/// <summary>ÁZ</summary>
		[Column("kazanto")]
		public decimal? Kazanto { get; set; }

		/// <summary>v_</summary>
		[Column("goke_tensu")]
		public decimal? GokeTensu { get; set; }

		/// <summary>êSà</summary>
		[Column("itibu_futankin")]
		public decimal? ItibuFutankin { get; set; }

		/// <summary>eíàz</summary>
		[Column("yoki_kingaku")]
		public decimal? YokiKingaku { get; set; }

		/// <summary>»Ì¼Ìàz</summary>
		[Column("sonota_no_kingaku")]
		public decimal? SonotaNoKingaku { get; set; }

		/// <summary>Oñ¢ûà</summary>
		[Column("zenkaimade_mishukin")]
		public decimal? ZenkaimadeMishukin { get; set; }

		/// <summary>¡ñ¿z</summary>
		[Column("konkai_seikyugaku")]
		public decimal? KonkaiSeikyugaku { get; set; }

		/// <summary>v¿z</summary>
		[Column("goke_seikyugaku")]
		public decimal? GokeSeikyugaku { get; set; }

		/// <summary>¡ñüàz</summary>
		[Column("konkai_nyukingaku")]
		public decimal? KonkaiNyukingaku { get; set; }

		/// <summary>¢ûà</summary>
		[Column("mishukin")]
		public decimal? Mishukin { get; set; }

		/// <summary>Løæª</summary>
		[Column("enable")]
		public int? Enable { get; set; }

		/// <summary> RXgN^</summary>
		public Nsips5Chozairoku()
		{

			Nsips5ChozairokuId = 0;
			Nsips0HeaderId = 0;
			Indate = 0;
			Inseq = 0;
			Fupdkbn = "";
			Patseq = 0;
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
			Enable = 0;

		}
	} 
} 
