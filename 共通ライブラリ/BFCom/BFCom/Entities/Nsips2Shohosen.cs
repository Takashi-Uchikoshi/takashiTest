namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>NSIPS処方箋部テーブル</summary>
	[Table("nsips2_shohosen")]
	public partial class Nsips2Shohosen
	{ 
		/// <summary>Nsips2処方箋ID</summary>
		[Key]
		[Column("nsips2_shohosen_id")]
		public int? Nsips2ShohosenId { get; set; }

		/// <summary>Nsips0ヘッダID</summary>
		[Column("nsips0_header_id")]
		public int? Nsips0HeaderId { get; set; }

		/// <summary>識別子</summary>
		[Column("stype")]
		public int? Stype { get; set; }

		/// <summary>処方箋番号</summary>
		[Column("shohosen_bango")]
		public decimal? ShohosenBango { get; set; }

		/// <summary>受付番号</summary>
		[Column("uketsuke_bango")]
		public int? UketsukeBango { get; set; }

		/// <summary>更新区分</summary>
		[Column("koshin_kubun")]
		public string KoshinKubun { get; set; }

		/// <summary>処方箋交付年月日</summary>
		[Column("shohosen_kofu_nengappi")]
		public DateTime? ShohosenKofuNengappi { get; set; }

		/// <summary>使用期限年月日</summary>
		[Column("shiyokigen_nengappi")]
		public DateTime? ShiyokigenNengappi { get; set; }

		/// <summary>受付年月日</summary>
		[Column("uketsuke_nengappi")]
		public DateTime? UketsukeNengappi { get; set; }

		/// <summary>調剤年月日</summary>
		[Column("chozai_nengappi")]
		public DateTime? ChozaiNengappi { get; set; }

		/// <summary>妊婦授乳区分</summary>
		[Column("ninpujyunu_kubun")]
		public string NinpujyunuKubun { get; set; }

		/// <summary>強制監査指示フラグ</summary>
		[Column("kyoseikansashiji_flag")]
		public string KyoseikansashijiFlag { get; set; }

		/// <summary>医療機関コード種別</summary>
		[Column("iryokikan_code_shubetsu")]
		public string IryokikanCodeShubetsu { get; set; }

		/// <summary>医療機関コード</summary>
		[Column("iryokikan_code")]
		public string IryokikanCode { get; set; }

		/// <summary>医療機関レセプトコード</summary>
		[Column("iryokikan_reseputo_code")]
		public string IryokikanReseputoCode { get; set; }

		/// <summary>医療機関都道府県コード</summary>
		[Column("iryokikan_todofuken_code")]
		public string IryokikanTodofukenCode { get; set; }

		/// <summary>医療機関名</summary>
		[Column("iryokikan_mei")]
		public string IryokikanMei { get; set; }

		/// <summary>医療機関郵便局</summary>
		[Column("iryokikan_yubinbango")]
		public string IryokikanYubinbango { get; set; }

		/// <summary>医療機関所在地</summary>
		[Column("iryokikan_shozaiti")]
		public string IryokikanShozaiti { get; set; }

		/// <summary>医療機関電話番号</summary>
		[Column("iryokikan_denwabango")]
		public string IryokikanDenwabango { get; set; }

		/// <summary>診療科コード</summary>
		[Column("shinryoka_code")]
		public string ShinryokaCode { get; set; }

		/// <summary>診療科名</summary>
		[Column("shinryoka_mei")]
		public string ShinryokaMei { get; set; }

		/// <summary>病棟コード</summary>
		[Column("byoto_code")]
		public string ByotoCode { get; set; }

		/// <summary>病棟名</summary>
		[Column("byoto_mei")]
		public string ByotoMei { get; set; }

		/// <summary>医師コード</summary>
		[Column("ishi_code")]
		public string IshiCode { get; set; }

		/// <summary>医師カナ氏名</summary>
		[Column("ishi_kana_shimei")]
		public string IshiKanaShimei { get; set; }

		/// <summary>医師漢字氏名</summary>
		[Column("ishi_kanji_shimei")]
		public string IshiKanjiShimei { get; set; }

		/// <summary>薬剤師コード</summary>
		[Column("yakuzaishi_code")]
		public string YakuzaishiCode { get; set; }

		/// <summary>薬剤師名</summary>
		[Column("yakuzaishi_mei")]
		public string YakuzaishiMei { get; set; }

		/// <summary>医師同意変更内容</summary>
		[Column("ishi_doihenko_naiyo")]
		public string IshiDoihenkoNaiyo { get; set; }

		/// <summary>医師疑義回答内容</summary>
		[Column("ishi_gigikaito_naiyo")]
		public string IshiGigikaitoNaiyo { get; set; }

		/// <summary>麻薬施用者免許番号</summary>
		[Column("mayakushiyosha_menkyobango")]
		public string MayakushiyoshaMenkyobango { get; set; }

		/// <summary>麻薬施用患者住所</summary>
		[Column("mayakushiyo_kanjya_jyusho")]
		public string MayakushiyoKanjyaJyusho { get; set; }

		/// <summary>麻薬施用患者電話番号</summary>
		[Column("mayakushiyo_kanjya_denwabango")]
		public string MayakushiyoKanjyaDenwabango { get; set; }

		/// <summary>処方箋コメント</summary>
		[Column("shohosen_comment")]
		public string ShohosenComment { get; set; }

		/// <summary>処方箋情報部予備</summary>
		[Column("shohosen_jyohobu_yobi")]
		public string ShohosenJyohobuYobi { get; set; }

		/// <summary>薬袋発行フラグ</summary>
		[Column("yakutai_hakko_flag")]
		public string YakutaiHakkoFlag { get; set; }

		/// <summary>薬情発行フラグ</summary>
		[Column("yakujyo_hakko_flag")]
		public string YakujyoHakkoFlag { get; set; }

		/// <summary>服薬手帳発行フラグ</summary>
		[Column("fukuyakutecho_hakko_flag")]
		public string FukuyakutechoHakkoFlag { get; set; }

		/// <summary>領収書発行フラグ</summary>
		[Column("ryoshusho_hakko_flag")]
		public string RyoshushoHakkoFlag { get; set; }

		/// <summary>帳票A発行フラグ</summary>
		[Column("kicho_a_hakko_flag")]
		public string KichoAHakkoFlag { get; set; }

		/// <summary>帳票B発行フラグ</summary>
		[Column("kicho_b_hakko_flag")]
		public string KichoBHakkoFlag { get; set; }

		/// <summary>帳票C発行フラグ</summary>
		[Column("kicho_c_hakko_flag")]
		public string KichoCHakkoFlag { get; set; }

		/// <summary>明細書発行フラグ</summary>
		[Column("meisaisho_hakko_flag")]
		public string MeisaishoHakkoFlag { get; set; }

		/// <summary>ファイル更新区分</summary>
		[Column("fupdkbn")]
		public string Fupdkbn { get; set; }

		/// <summary>有効区分</summary>
		[Column("yuko_flag")]
		public int? YukoFlag { get; set; }

		/// <summary> コンストラクタ</summary>
		public Nsips2Shohosen()
		{

			Nsips2ShohosenId = 0;
			Nsips0HeaderId = 0;
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
			Fupdkbn = "";
			YukoFlag = 0;

		}
	} 
} 
