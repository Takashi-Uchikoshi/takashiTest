namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>òi}X^</summary>
	[Table("yakuhin_master")]
	public partial class YakuhinMaster
	{ 
		/// <summary>PDSR[h</summary>
		[Key]
		[Column("pds_code", Order = 0)]
		public string PdsCode { get; set; }

		/// <summary>YJR[h</summary>
		[Column("yj_code")]
		public string YjCode { get; set; }

		/// <summary>JANR[h</summary>
		[Column("jan_code")]
		public string JanCode { get; set; }

		/// <summary>GTINR[h</summary>
		[Column("gtin_code")]
		public string GtinCode { get; set; }

		/// <summary>òi¼</summary>
		[Column("yakuhin_mei")]
		public string YakuhinMei { get; set; }

		/// <summary>òitKi</summary>
		[Column("yakuhin_kana")]
		public string YakuhinKana { get; set; }

		/// <summary>KiPÊ</summary>
		[Column("kikaku_tanni")]
		public string KikakuTanni { get; set; }

		/// <summary>ï`Ô</summary>
		[Column("housou_keitai")]
		public string HousouKeitai { get; set; }

		/// <summary>ïPÊ</summary>
		[Column("housou_tanni_qty")]
		public decimal? HousouTanniQty { get; set; }

		/// <summary>ïPÊPÊ</summary>
		[Column("housou_tanni_tanni")]
		public string HousouTanniTanni { get; set; }

		/// <summary>ïÊ</summary>
		[Column("housou_souryou_qty")]
		public decimal? HousouSouryouQty { get; set; }

		/// <summary>ïÊPÊ</summary>
		[Column("housou_suryou_tanni")]
		public string HousouSuryouTanni { get; set; }

		/// <summary>æª</summary>
		[Column("kubun")]
		public string Kubun { get; set; }

		/// <summary>òøªÞR[h</summary>
		[Column("yakkou_bunrui_code")]
		public string YakkouBunruiCode { get; set; }

		/// <summary>Ü`æªR[h</summary>
		[Column("zaikei_kubun_code")]
		public string ZaikeiKubunCode { get; set; }

		/// <summary>¬ªR[h</summary>
		[Column("seibun_code")]
		public string SeibunCode { get; set; }

		/// <summary>ò¿</summary>
		[Column("yakka")]
		public decimal? Yakka { get; set; }

		/// <summary>ÅòtO</summary>
		[Column("dokuyaku_flag")]
		public string DokuyakuFlag { get; set; }

		/// <summary>òtO</summary>
		[Column("gekiyaku_flag")]
		public string GekiyakuFlag { get; set; }

		/// <summary>òtO</summary>
		[Column("mayaku_flag")]
		public string MayakuFlag { get; set; }

		/// <summary>oÁÜtO</summary>
		[Column("kakuseizai_flag")]
		public string KakuseizaiFlag { get; set; }

		/// <summary>¶¨wI»ÜtO</summary>
		[Column("seibutsugakuteki_seizai_flag")]
		public string SeibutsugakutekiSeizaiFlag { get; set; }

		/// <summary>¢eÜtO</summary>
		[Column("zoueizai_flag")]
		public string ZoueizaiFlag { get; set; }

		/// <summary>ü¸_òtO</summary>
		[Column("kouseishinyaku_flag")]
		public string KouseishinyakuFlag { get; set; }

		/// <summary>»¢ïÐR[h</summary>
		[Column("seizou_kaisha_code")]
		public string SeizouKaishaCode { get; set; }

		/// <summary>ÌïÐR[h</summary>
		[Column("hanbai_kaisha_code")]
		public string HanbaiKaishaCode { get; set; }

		/// <summary>¦ú</summary>
		[Column("kokuji_ymd")]
		public string KokujiYmd { get; set; }

		/// <summary>oß[uú</summary>
		[Column("keika_sochi_ymd")]
		public string KeikaSochiYmd { get; set; }

		/// <summary>Ì~ú</summary>
		[Column("hanbai_chushi_ymd")]
		public string HanbaiChushiYmd { get; set; }

		/// <summary>ÅIbggpúÀ</summary>
		[Column("saishu_lot_shiyou_kigen")]
		public string SaishuLotShiyouKigen { get; set; }

		/// <summary>KpJnNú</summary>
		[Key]
		[Column("apply_start_ymd", Order = 1)]
		public string ApplyStartYmd { get; set; }

		/// <summary>KpI¹Nú</summary>
		[Column("apply_end_ymd")]
		public string ApplyEndYmd { get; set; }

		/// <summary>o^ÒID</summary>
		[Column("insert_user_id")]
		public int? InsertUserId { get; set; }

		/// <summary>o^ú</summary>
		[Column("insert_nitiji")]
		public DateTime? InsertNitiji { get; set; }

		/// <summary>XVÒID</summary>
		[Column("update_user_id")]
		public int? UpdateUserId { get; set; }

		/// <summary>XVú</summary>
		[Column("update_nitiji")]
		public DateTime? UpdateNitiji { get; set; }

		/// <summary>XVvOID</summary>
		[Column("update_program_id")]
		public string UpdateProgramId { get; set; }

		/// <summary>Ç®«</summary>
		[Column("kanri_zokusei")]
		public int? KanriZokusei { get; set; }

		/// <summary> RXgN^</summary>
		public YakuhinMaster()
		{

			PdsCode = "";
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
			KanriZokusei = 0;

		}
	} 
} 
