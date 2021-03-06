namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>NSIPSûâ³e[u</summary>
	[Table("nsips2_shohosen")]
	public partial class Nsips2Shohosen
	{ 
		/// <summary>L[</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("nsips2_shohosen_id")]
		public int? Nsips2ShohosenId { get; set; }

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

		/// <summary>t@Càûâ³AÔ</summary>
		[Column("syoseq")]
		public int? Syoseq { get; set; }

		/// <summary>¯Êq</summary>
		[Column("stype")]
		public int? Stype { get; set; }

		/// <summary>ûâ³Ô</summary>
		[Column("shohosen_bango")]
		public decimal? ShohosenBango { get; set; }

		/// <summary>ótÔ</summary>
		[Column("uketsuke_bango")]
		public int? UketsukeBango { get; set; }

		/// <summary>XVæª</summary>
		[Column("koshin_kubun")]
		public string KoshinKubun { get; set; }

		/// <summary>ûâ³ðtNú</summary>
		[Column("shohosen_kofu_nengappi")]
		public DateTime? ShohosenKofuNengappi { get; set; }

		/// <summary>gpúÀNú</summary>
		[Column("shiyokigen_nengappi")]
		public DateTime? ShiyokigenNengappi { get; set; }

		/// <summary>ótNú</summary>
		[Column("uketsuke_nengappi")]
		public DateTime? UketsukeNengappi { get; set; }

		/// <summary>²ÜNú</summary>
		[Column("chozai_nengappi")]
		public DateTime? ChozaiNengappi { get; set; }

		/// <summary>Dwöûæª</summary>
		[Column("ninpujyunu_kubun")]
		public string NinpujyunuKubun { get; set; }

		/// <summary>­§Ä¸w¦tO</summary>
		[Column("kyoseikansashiji_flag")]
		public string KyoseikansashijiFlag { get; set; }

		/// <summary>ãÃ@ÖR[híÊ</summary>
		[Column("iryokikan_code_shubetsu")]
		public string IryokikanCodeShubetsu { get; set; }

		/// <summary>ãÃ@ÖR[h</summary>
		[Column("iryokikan_code")]
		public string IryokikanCode { get; set; }

		/// <summary>ãÃ@ÖZvgR[h</summary>
		[Column("iryokikan_reseputo_code")]
		public string IryokikanReseputoCode { get; set; }

		/// <summary>ãÃ@Ös¹{§R[h</summary>
		[Column("iryokikan_todofuken_code")]
		public string IryokikanTodofukenCode { get; set; }

		/// <summary>ãÃ@Ö¼</summary>
		[Column("iryokikan_mei")]
		public string IryokikanMei { get; set; }

		/// <summary>ãÃ@ÖXÖÇ</summary>
		[Column("iryokikan_yubinbango")]
		public string IryokikanYubinbango { get; set; }

		/// <summary>ãÃ@ÖÝn</summary>
		[Column("iryokikan_shozaiti")]
		public string IryokikanShozaiti { get; set; }

		/// <summary>ãÃ@ÖdbÔ</summary>
		[Column("iryokikan_denwabango")]
		public string IryokikanDenwabango { get; set; }

		/// <summary>fÃÈR[h</summary>
		[Column("shinryoka_code")]
		public string ShinryokaCode { get; set; }

		/// <summary>fÃÈ¼</summary>
		[Column("shinryoka_mei")]
		public string ShinryokaMei { get; set; }

		/// <summary>aR[h</summary>
		[Column("byoto_code")]
		public string ByotoCode { get; set; }

		/// <summary>a¼</summary>
		[Column("byoto_mei")]
		public string ByotoMei { get; set; }

		/// <summary>ãtR[h</summary>
		[Column("ishi_code")]
		public string IshiCode { get; set; }

		/// <summary>ãtJi¼</summary>
		[Column("ishi_kana_shimei")]
		public string IshiKanaShimei { get; set; }

		/// <summary>ãt¿¼</summary>
		[Column("ishi_kanji_shimei")]
		public string IshiKanjiShimei { get; set; }

		/// <summary>òÜtR[h</summary>
		[Column("yakuzaishi_code")]
		public string YakuzaishiCode { get; set; }

		/// <summary>òÜt¼</summary>
		[Column("yakuzaishi_mei")]
		public string YakuzaishiMei { get; set; }

		/// <summary>ãt¯ÓÏXàe</summary>
		[Column("ishi_doihenko_naiyo")]
		public string IshiDoihenkoNaiyo { get; set; }

		/// <summary>ãt^`ñàe</summary>
		[Column("ishi_gigikaito_naiyo")]
		public string IshiGigikaitoNaiyo { get; set; }

		/// <summary>ò{pÒÆÔ</summary>
		[Column("mayakushiyosha_menkyobango")]
		public string MayakushiyoshaMenkyobango { get; set; }

		/// <summary>ò{p³ÒZ</summary>
		[Column("mayakushiyo_kanjya_jyusho")]
		public string MayakushiyoKanjyaJyusho { get; set; }

		/// <summary>ò{p³ÒdbÔ</summary>
		[Column("mayakushiyo_kanjya_denwabango")]
		public string MayakushiyoKanjyaDenwabango { get; set; }

		/// <summary>ûâ³Rg</summary>
		[Column("shohosen_comment")]
		public string ShohosenComment { get; set; }

		/// <summary>ûâ³îñ\õ</summary>
		[Column("shohosen_jyohobu_yobi")]
		public string ShohosenJyohobuYobi { get; set; }

		/// <summary>òÜ­stO</summary>
		[Column("yakutai_hakko_flag")]
		public string YakutaiHakkoFlag { get; set; }

		/// <summary>òî­stO</summary>
		[Column("yakujyo_hakko_flag")]
		public string YakujyoHakkoFlag { get; set; }

		/// <summary>òè ­stO</summary>
		[Column("fukuyakutecho_hakko_flag")]
		public string FukuyakutechoHakkoFlag { get; set; }

		/// <summary>Ìû­stO</summary>
		[Column("ryoshusho_hakko_flag")]
		public string RyoshushoHakkoFlag { get; set; }

		/// <summary> [A­stO</summary>
		[Column("kicho_a_hakko_flag")]
		public string KichoAHakkoFlag { get; set; }

		/// <summary> [B­stO</summary>
		[Column("kicho_b_hakko_flag")]
		public string KichoBHakkoFlag { get; set; }

		/// <summary> [C­stO</summary>
		[Column("kicho_c_hakko_flag")]
		public string KichoCHakkoFlag { get; set; }

		/// <summary>¾×­stO</summary>
		[Column("meisaisho_hakko_flag")]
		public string MeisaishoHakkoFlag { get; set; }

		/// <summary>Løæª</summary>
		[Column("enable")]
		public int? Enable { get; set; }

		/// <summary> RXgN^</summary>
		public Nsips2Shohosen()
		{

			Nsips2ShohosenId = 0;
			Nsips0HeaderId = 0;
			Indate = 0;
			Inseq = 0;
			Fupdkbn = "";
			Patseq = 0;
			Syoseq = 0;
			Stype = 0;
			ShohosenBango = 0;
			UketsukeBango = 0;
			KoshinKubun = "";
			ShohosenKofuNengappi = null;
			ShiyokigenNengappi = null;
			UketsukeNengappi = null;
			ChozaiNengappi = null;
			NinpujyunuKubun = "";
			KyoseikansashijiFlag = "";
			IryokikanCodeShubetsu = "";
			IryokikanCode = "";
			IryokikanReseputoCode = "";
			IryokikanTodofukenCode = "";
			IryokikanMei = "";
			IryokikanYubinbango = "";
			IryokikanShozaiti = "";
			IryokikanDenwabango = "";
			ShinryokaCode = "";
			ShinryokaMei = "";
			ByotoCode = "";
			ByotoMei = "";
			IshiCode = "";
			IshiKanaShimei = "";
			IshiKanjiShimei = "";
			YakuzaishiCode = "";
			YakuzaishiMei = "";
			IshiDoihenkoNaiyo = "";
			IshiGigikaitoNaiyo = "";
			MayakushiyoshaMenkyobango = "";
			MayakushiyoKanjyaJyusho = "";
			MayakushiyoKanjyaDenwabango = "";
			ShohosenComment = "";
			ShohosenJyohobuYobi = "";
			YakutaiHakkoFlag = "";
			YakujyoHakkoFlag = "";
			FukuyakutechoHakkoFlag = "";
			RyoshushoHakkoFlag = "";
			KichoAHakkoFlag = "";
			KichoBHakkoFlag = "";
			KichoCHakkoFlag = "";
			MeisaishoHakkoFlag = "";
			Enable = 0;

		}
	} 
} 
