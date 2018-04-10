namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>NSIPS薬品部テーブル</summary>
	[Table("nsips4_yakuhin")]
	public partial class Nsips4Yakuhin
	{ 
		/// <summary>キー</summary>
		[Key]
		[Column("nsips4_yakuhin_id")]
		public int? Nsips4YakuhinId { get; set; }

		/// <summary>Nsips0ヘッダID</summary>
		[Column("nsips0_header_id")]
		public int? Nsips0HeaderId { get; set; }

		/// <summary>Nsips2処方箋ID</summary>
		[Column("nsips2_shohosen_id")]
		public int? Nsips2ShohosenId { get; set; }

		/// <summary>Nsips0用法ID</summary>
		[Column("nsips3_yoho_id")]
		public int? Nsips3YohoId { get; set; }

		/// <summary>識別子</summary>
		[Column("stype")]
		public int? Stype { get; set; }

		/// <summary>薬品番号</summary>
		[Column("yakuhin_bango")]
		public int? YakuhinBango { get; set; }

		/// <summary>RP番号</summary>
		[Column("rp_bango")]
		public int? RpBango { get; set; }

		/// <summary>情報区分</summary>
		[Column("jyoho_kubun")]
		public string JyohoKubun { get; set; }

		/// <summary>YJコード</summary>
		[Column("yj_code")]
		public string YjCode { get; set; }

		/// <summary>レセ電算コード</summary>
		[Column("resedensan_code")]
		public string ResedensanCode { get; set; }

		/// <summary>HOTコード</summary>
		[Column("hot_code")]
		public string HotCode { get; set; }

		/// <summary>明細コード</summary>
		[Column("meisai_code")]
		public string MeisaiCode { get; set; }

		/// <summary>薬品名</summary>
		[Column("yakuhin_mei")]
		public string YakuhinMei { get; set; }

		/// <summary>薬品一般名</summary>
		[Column("yakuhin_ippanmei")]
		public string YakuhinIppanmei { get; set; }

		/// <summary>不均等分割服用量(起床)</summary>
		[Column("fukintobunkatsu_fukuyo_ryo_kisho")]
		public decimal? FukintobunkatsuFukuyoRyoKisho { get; set; }

		/// <summary>不均等分割服用量(朝)</summary>
		[Column("fukintobunkatsu_fukuyo_ryo_asa")]
		public decimal? FukintobunkatsuFukuyoRyoAsa { get; set; }

		/// <summary>不均等分割服用量(昼)</summary>
		[Column("fukintobunkatsu_fukuyo_ryo_hiru")]
		public decimal? FukintobunkatsuFukuyoRyoHiru { get; set; }

		/// <summary>不均等分割服用量(夕)</summary>
		[Column("fukintobunkatsu_fukuyo_ryo_yu")]
		public decimal? FukintobunkatsuFukuyoRyoYu { get; set; }

		/// <summary>不均等分割服用量(寝る前)</summary>
		[Column("fukintobunkatsu_fukuyo_ryo_nerumae")]
		public decimal? FukintobunkatsuFukuyoRyoNerumae { get; set; }

		/// <summary>不均等分割服用量(予備)</summary>
		[Column("fukintobunkatsu_fukuyo_ryo_yobi")]
		public decimal? FukintobunkatsuFukuyoRyoYobi { get; set; }

		/// <summary>服用量</summary>
		[Column("fukuyo_ryo")]
		public decimal? FukuyoRyo { get; set; }

		/// <summary>力価フラグ</summary>
		[Column("rikika_flag")]
		public string RikikaFlag { get; set; }

		/// <summary>服用単位</summary>
		[Column("fukuyo_tani")]
		public string FukuyoTani { get; set; }

		/// <summary>１包化区分</summary>
		[Column("ippoka_kubun")]
		public string IppokaKubun { get; set; }

		/// <summary>粉砕区分</summary>
		[Column("funsai_kubun")]
		public string FunsaiKubun { get; set; }

		/// <summary>画像区分</summary>
		[Column("gazo_kubun")]
		public string GazoKubun { get; set; }

		/// <summary>別包区分</summary>
		[Column("betsuho_kubun")]
		public string BetsuhoKubun { get; set; }

		/// <summary>表示区分</summary>
		[Column("hyoji_kubun")]
		public string HyojiKubun { get; set; }

		/// <summary>薬価</summary>
		[Column("yakka")]
		public decimal? Yakka { get; set; }

		/// <summary>棚番号</summary>
		[Column("tana_bango")]
		public string TanaBango { get; set; }

		/// <summary>ロット番号</summary>
		[Column("lot_bango")]
		public string LotBango { get; set; }

		/// <summary>薬品コメント1</summary>
		[Column("yakuhin_comment1")]
		public string YakuhinComment1 { get; set; }

		/// <summary>後発品変更前薬品YJコード</summary>
		[Column("kohatuhin_henkomae_yakuhin_yj_code")]
		public string KohatuhinHenkomaeYakuhinYjCode { get; set; }

		/// <summary>後発品変更前薬品レセ電算コード</summary>
		[Column("kohatuhin_henkomae_yakuhin_resedensan_code")]
		public string KohatuhinHenkomaeYakuhinResedensanCode { get; set; }

		/// <summary>後発品変更前薬品HOTコード</summary>
		[Column("kohatuhin_henkomae_yakuhin_hot_code")]
		public string KohatuhinHenkomaeYakuhinHotCode { get; set; }

		/// <summary>後発品変更前薬品名</summary>
		[Column("kohatuhin_henkomae_yakuhin_mei")]
		public string KohatuhinHenkomaeYakuhinMei { get; set; }

		/// <summary>混合区分</summary>
		[Column("kongo_kubun")]
		public string KongoKubun { get; set; }

		/// <summary>後発品変更前薬品服用量</summary>
		[Column("kohatuhin_henkomae_yakuhin_fukuyo_ryo")]
		public decimal? KohatuhinHenkomaeYakuhinFukuyoRyo { get; set; }

		/// <summary>後発品変更前薬品服用単位</summary>
		[Column("kohatuhin_henkomae_yakuhin_fukuyo_tani")]
		public string KohatuhinHenkomaeYakuhinFukuyoTani { get; set; }

		/// <summary>１回服用量</summary>
		[Column("ikkai_fukuyo_ryo")]
		public decimal? IkkaiFukuyoRyo { get; set; }

		/// <summary>薬品コメント2</summary>
		[Column("yakuhin_comment2")]
		public string YakuhinComment2 { get; set; }

		/// <summary>薬品コメント3</summary>
		[Column("yakuhin_comment3")]
		public string YakuhinComment3 { get; set; }

		/// <summary>薬品コメント4</summary>
		[Column("yakuhin_comment4")]
		public string YakuhinComment4 { get; set; }

		/// <summary>薬品コメント5</summary>
		[Column("yakuhin_comment5")]
		public string YakuhinComment5 { get; set; }

		/// <summary>一般名処方フラグ</summary>
		[Column("ippannmei_shoho_flag")]
		public string IppannmeiShohoFlag { get; set; }

		/// <summary>総量</summary>
		[Column("souryo")]
		public decimal? Souryo { get; set; }

		/// <summary>ファイル更新区分</summary>
		[Column("fupdkbn")]
		public string Fupdkbn { get; set; }

		/// <summary>有効区分</summary>
		[Column("yuko_flag")]
		public int? YukoFlag { get; set; }

		/// <summary> コンストラクタ</summary>
		public Nsips4Yakuhin()
		{

			Nsips4YakuhinId = 0;
			Nsips0HeaderId = 0;
			Nsips2ShohosenId = 0;
			Nsips3YohoId = 0;
			Stype = 0;
			YakuhinBango = 0;
			RpBango = 0;
			JyohoKubun = "";
			YjCode = "";
			ResedensanCode = "";
			HotCode = "";
			MeisaiCode = "";
			YakuhinMei = "";
			YakuhinIppanmei = "";
			FukintobunkatsuFukuyoRyoKisho = 0;
			FukintobunkatsuFukuyoRyoAsa = 0;
			FukintobunkatsuFukuyoRyoHiru = 0;
			FukintobunkatsuFukuyoRyoYu = 0;
			FukintobunkatsuFukuyoRyoNerumae = 0;
			FukintobunkatsuFukuyoRyoYobi = 0;
			FukuyoRyo = 0;
			RikikaFlag = "";
			FukuyoTani = "";
			IppokaKubun = "";
			FunsaiKubun = "";
			GazoKubun = "";
			BetsuhoKubun = "";
			HyojiKubun = "";
			Yakka = 0;
			TanaBango = "";
			LotBango = "";
			YakuhinComment1 = "";
			KohatuhinHenkomaeYakuhinYjCode = "";
			KohatuhinHenkomaeYakuhinResedensanCode = "";
			KohatuhinHenkomaeYakuhinHotCode = "";
			KohatuhinHenkomaeYakuhinMei = "";
			KongoKubun = "";
			KohatuhinHenkomaeYakuhinFukuyoRyo = 0;
			KohatuhinHenkomaeYakuhinFukuyoTani = "";
			IkkaiFukuyoRyo = 0;
			YakuhinComment2 = "";
			YakuhinComment3 = "";
			YakuhinComment4 = "";
			YakuhinComment5 = "";
			IppannmeiShohoFlag = "";
			Souryo = 0;
			Fupdkbn = "";
			YukoFlag = 0;

		}
	} 
} 
