namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>OTC商品マスタ</summary>
	[Table("otc_master")]
	public partial class OtcMaster
	{ 
		/// <summary>内部コード</summary>
		[Key]
		[Column("code", Order = 0)]
		public string Code { get; set; }

		/// <summary>YJコード</summary>
		[Column("yj_code")]
		public string YjCode { get; set; }

		/// <summary>JANコード</summary>
		[Column("jan_code")]
		public string JanCode { get; set; }

		/// <summary>GTINコード</summary>
		[Column("gtin_code")]
		public string GtinCode { get; set; }

		/// <summary>薬品名</summary>
		[Column("yakuhin_mei")]
		public string YakuhinMei { get; set; }

		/// <summary>薬品フリガナ</summary>
		[Column("yakuhin_kana")]
		public string YakuhinKana { get; set; }

		/// <summary>規格単位</summary>
		[Column("kikaku_tanni")]
		public string KikakuTanni { get; set; }

		/// <summary>包装形態</summary>
		[Column("housou_keitai")]
		public string HousouKeitai { get; set; }

		/// <summary>包装単位数</summary>
		[Column("housou_tanni_qty")]
		public decimal? HousouTanniQty { get; set; }

		/// <summary>包装単位単位</summary>
		[Column("housou_tanni_tanni")]
		public string HousouTanniTanni { get; set; }

		/// <summary>包装総量数</summary>
		[Column("housou_souryou_qty")]
		public decimal? HousouSouryouQty { get; set; }

		/// <summary>包装数量単位</summary>
		[Column("housou_suryou_tanni")]
		public string HousouSuryouTanni { get; set; }

		/// <summary>区分</summary>
		[Column("kubun")]
		public string Kubun { get; set; }

		/// <summary>薬効分類コード</summary>
		[Column("yakkou_bunrui_code")]
		public string YakkouBunruiCode { get; set; }

		/// <summary>剤形区分コード</summary>
		[Column("zaikei_kubun_code")]
		public string ZaikeiKubunCode { get; set; }

		/// <summary>成分コード</summary>
		[Column("seibun_code")]
		public string SeibunCode { get; set; }

		/// <summary>薬価</summary>
		[Column("yakka")]
		public decimal? Yakka { get; set; }

		/// <summary>毒薬フラグ</summary>
		[Column("dokuyaku_flag")]
		public string DokuyakuFlag { get; set; }

		/// <summary>劇薬フラグ</summary>
		[Column("gekiyaku_flag")]
		public string GekiyakuFlag { get; set; }

		/// <summary>麻薬フラグ</summary>
		[Column("mayaku_flag")]
		public string MayakuFlag { get; set; }

		/// <summary>覚醒剤フラグ</summary>
		[Column("kakuseizai_flag")]
		public string KakuseizaiFlag { get; set; }

		/// <summary>生物学的製剤フラグ</summary>
		[Column("seibutsugakuteki_seizai_flag")]
		public string SeibutsugakutekiSeizaiFlag { get; set; }

		/// <summary>造影剤フラグ</summary>
		[Column("zoueizai_flag")]
		public string ZoueizaiFlag { get; set; }

		/// <summary>向精神薬フラグ</summary>
		[Column("kouseishinyaku_flag")]
		public string KouseishinyakuFlag { get; set; }

		/// <summary>製造会社コード</summary>
		[Column("seizou_kaisha_code")]
		public string SeizouKaishaCode { get; set; }

		/// <summary>販売会社コード</summary>
		[Column("hanbai_kaisha_code")]
		public string HanbaiKaishaCode { get; set; }

		/// <summary>告示日</summary>
		[Column("kokuji_ymd")]
		public string KokujiYmd { get; set; }

		/// <summary>経過措置日</summary>
		[Column("keika_sochi_ymd")]
		public string KeikaSochiYmd { get; set; }

		/// <summary>販売中止日</summary>
		[Column("hanbai_chushi_ymd")]
		public string HanbaiChushiYmd { get; set; }

		/// <summary>最終ロット使用期限</summary>
		[Column("saishu_lot_shiyou_kigen")]
		public string SaishuLotShiyouKigen { get; set; }

		/// <summary>適用開始年月日</summary>
		[Key]
		[Column("apply_start_ymd", Order = 1)]
		public string ApplyStartYmd { get; set; }

		/// <summary>適用終了年月日</summary>
		[Column("apply_end_ymd")]
		public string ApplyEndYmd { get; set; }

		/// <summary>登録者ID</summary>
		[Column("insert_user_id")]
		public int? InsertUserId { get; set; }

		/// <summary>登録日時</summary>
		[Column("insert_nitiji")]
		public DateTime? InsertNitiji { get; set; }

		/// <summary>更新者ID</summary>
		[Column("update_user_id")]
		public int? UpdateUserId { get; set; }

		/// <summary>更新日時</summary>
		[Column("update_nitiji")]
		public DateTime? UpdateNitiji { get; set; }

		/// <summary>更新プログラムID</summary>
		[Column("update_program_id")]
		public string UpdateProgramId { get; set; }

		/// <summary>税区分</summary>
		[Column("tax_code")]
		public int? TaxCode { get; set; }

		/// <summary>分類コード</summary>
		[Column("bunrui_code")]
		public int? BunruiCode { get; set; }

		/// <summary>使用開始</summary>
		[Key]
		[Column("start_use_date", Order = 2)]
		public int? StartUseDate { get; set; }

		/// <summary>使用終了</summary>
		[Key]
		[Column("end_use_date", Order = 3)]
		public int? EndUseDate { get; set; }

		/// <summary>通知識別</summary>
		[Column("tsuuchi_sikibetu")]
		public int? TsuuchiSikibetu { get; set; }

		/// <summary>通知日時</summary>
		[Column("tsuuchi_date")]
		public DateTime? TsuuchiDate { get; set; }

		/// <summary>管理属性</summary>
		[Column("kanri_zokusei")]
		public int? KanriZokusei { get; set; }

		/// <summary> コンストラクタ</summary>
		public OtcMaster()
		{

			Code = "";
			YjCode = "";
			JanCode = "";
			GtinCode = "";
			YakuhinMei = "";
			YakuhinKana = "";
			KikakuTanni = "";
			HousouKeitai = "";
			HousouTanniQty = 0;
			HousouTanniTanni = "";
			HousouSouryouQty = 0;
			HousouSuryouTanni = "";
			Kubun = "";
			YakkouBunruiCode = "";
			ZaikeiKubunCode = "";
			SeibunCode = "";
			Yakka = 0;
			DokuyakuFlag = "";
			GekiyakuFlag = "";
			MayakuFlag = "";
			KakuseizaiFlag = "";
			SeibutsugakutekiSeizaiFlag = "";
			ZoueizaiFlag = "";
			KouseishinyakuFlag = "";
			SeizouKaishaCode = "";
			HanbaiKaishaCode = "";
			KokujiYmd = "";
			KeikaSochiYmd = "";
			HanbaiChushiYmd = "";
			SaishuLotShiyouKigen = "";
			ApplyStartYmd = "";
			ApplyEndYmd = "";
			InsertUserId = 0;
			InsertNitiji = null;
			UpdateUserId = 0;
			UpdateNitiji = null;
			UpdateProgramId = "";
			TaxCode = 0;
			BunruiCode = 0;
			StartUseDate = 0;
			EndUseDate = 0;
			TsuuchiSikibetu = 0;
			TsuuchiDate = null;
			KanriZokusei = 0;

		}
	} 
} 
