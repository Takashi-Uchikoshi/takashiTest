namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>NSIPS³Òîñe[u</summary>
	[Table("nsips1_kanjya")]
	public partial class Nsips1Kanjya
	{ 
		/// <summary>L[</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("nsips1_kanjya_id")]
		public int? Nsips1KanjyaId { get; set; }

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

		/// <summary>³ÒR[h</summary>
		[Column("kanjya_code")]
		public string KanjyaCode { get; set; }

		/// <summary>³ÒJi¼</summary>
		[Column("kanjya_kana_shimei")]
		public string KanjyaKanaShimei { get; set; }

		/// <summary>³Ò¿¼</summary>
		[Column("kanjya_kanji_shimei")]
		public string KanjyaKanjiShimei { get; set; }

		/// <summary>«Ê</summary>
		[Column("seibetsu")]
		public string Seibetsu { get; set; }

		/// <summary>¶Nú</summary>
		[Column("seinengappi")]
		public DateTime? Seinengappi { get; set; }

		/// <summary>XÖÔ</summary>
		[Column("yubinbango")]
		public string Yubinbango { get; set; }

		/// <summary>Z</summary>
		[Column("jusho")]
		public string Jusho { get; set; }

		/// <summary>©îdbÔ</summary>
		[Column("jitaku_denwabango")]
		public string JitakuDenwabango { get; set; }

		/// <summary>Î±ædbÔ</summary>
		[Column("kinmusaki_denwabango")]
		public string KinmusakiDenwabango { get; set; }

		/// <summary>Ù}Aæ</summary>
		[Column("kinkyu_renrakusaki")]
		public string KinkyuRenrakusaki { get; set; }

		/// <summary>[AhX</summary>
		[Column("mail_address")]
		public string MailAddress { get; set; }

		/// <summary>êSàæª</summary>
		[Column("itibufutankin_kubun")]
		public string ItibufutankinKubun { get; set; }

		/// <summary>Û¯íÊ</summary>
		[Column("hoken_shubtsu")]
		public string HokenShubtsu { get; set; }

		/// <summary>Û¯ÒÔ</summary>
		[Column("hokensha_bango")]
		public string HokenshaBango { get; set; }

		/// <summary>Û¯ÒÔæ¾ú</summary>
		[Column("hokensha_bango_shutokubi")]
		public DateTime? HokenshaBangoShutokubi { get; set; }

		/// <summary>íÛ¯ÒØL</summary>
		[Column("hihokenshasho_kigo")]
		public string HihokenshashoKigo { get; set; }

		/// <summary>íÛ¯ÒØÔ</summary>
		[Column("hihokenshasho_bango")]
		public string HihokenshashoBango { get; set; }

		/// <summary>íÛ¯Ò/í}{Ò</summary>
		[Column("hihokensha_hifuyousha")]
		public int? HihokenshaHifuyousha { get; set; }

		/// <summary>³ÒS¦</summary>
		[Column("kanjyafutanritsu")]
		public decimal? Kanjyafutanritsu { get; set; }

		/// <summary>Û¯t¦</summary>
		[Column("hokenkyuufuritsu")]
		public decimal? Hokenkyuufuritsu { get; set; }

		/// <summary>E±ãÌR</summary>
		[Column("shokumujyo_no_jiyu")]
		public string ShokumujyoNoJiyu { get; set; }

		/// <summary>VlÛs¬ºÔ</summary>
		[Column("rojinhoken_shichosonbango")]
		public string RojinhokenShichosonbango { get; set; }

		/// <summary>VlÛóÒÔ</summary>
		[Column("rojinhoken_jyukyushabango")]
		public string RojinhokenJyukyushabango { get; set; }

		/// <summary>VlÛs¬ºÔæ¾ú</summary>
		[Column("rojinhoken_shichosonbango_shutokubi")]
		public DateTime? RojinhokenShichosonbangoShutokubi { get; set; }

		/// <summary>æêöïSÒÔ</summary>
		[Column("daiitikohi_futansha_bango")]
		public string DaiitikohiFutanshaBango { get; set; }

		/// <summary>æêöïóÒÔ</summary>
		[Column("daiitikohi_jukyusha_bango")]
		public string DaiitikohiJukyushaBango { get; set; }

		/// <summary>æêöïSÒÔæ¾ú</summary>
		[Column("daiitikohi_futansha_bango_shutokubi")]
		public DateTime? DaiitikohiFutanshaBangoShutokubi { get; set; }

		/// <summary>æñöïSÒÔ</summary>
		[Column("dainikohi_futansha_bango")]
		public string DainikohiFutanshaBango { get; set; }

		/// <summary>æñöïóÒÔ</summary>
		[Column("dainikohi_jukyusha_bango")]
		public string DainikohiJukyushaBango { get; set; }

		/// <summary>æñöïSÒÔæ¾ú</summary>
		[Column("dainikohi_futansha_bango_shutokubi")]
		public DateTime? DainikohiFutanshaBangoShutokubi { get; set; }

		/// <summary>æOöïSÒÔ</summary>
		[Column("daisankohi_futansha_bango")]
		public string DaisankohiFutanshaBango { get; set; }

		/// <summary>æOöïóÒÔ</summary>
		[Column("daisankohi_jukyusha_bango")]
		public string DaisankohiJukyushaBango { get; set; }

		/// <summary>æOöïSÒÔæ¾ú</summary>
		[Column("daisankohi_futansha_bango_shutokubi")]
		public DateTime? DaisankohiFutanshaBangoShutokubi { get; set; }

		/// <summary>ÁêöïSÒÔ</summary>
		[Column("tokushukohi_futansha_bango")]
		public string TokushukohiFutanshaBango { get; set; }

		/// <summary>ÁêöïóÒÔ</summary>
		[Column("tokushukohi_jukyusha_bango")]
		public string TokushukohiJukyushaBango { get; set; }

		/// <summary>ÁêöïSÒÔæ¾ú</summary>
		[Column("tokushukohi_futansha_bango_shutokubi")]
		public DateTime? TokushukohiFutanshaBangoShutokubi { get; set; }

		/// <summary>Pï»w¦</summary>
		[Column("ippoka_shiji")]
		public string IppokaShiji { get; set; }

		/// <summary>²Ów¦</summary>
		[Column("funsai_shiji")]
		public string FunsaiShiji { get; set; }

		/// <summary>Óò è</summary>
		[Column("chuiyaku_ari")]
		public string ChuiyakuAri { get; set; }

		/// <summary>Ýìp`FbN</summary>
		[Column("sogosayo_check")]
		public string SogosayoCheck { get; set; }

		/// <summary>Ýìp`FbN(¼òÇ)</summary>
		[Column("sogosayo_check_tayakkyoku")]
		public string SogosayoCheckTayakkyoku { get; set; }

		/// <summary>^ÊI[o[(/Å)</summary>
		[Column("toyoryo_over_geki_doku")]
		public string ToyoryoOverGekiDoku { get; set; }

		/// <summary>^ÊI[o[(ü)</summary>
		[Column("toyoryo_over_ko")]
		public string ToyoryoOverKo { get; set; }

		/// <summary>^ÊI[o[(¼)</summary>
		[Column("toyoryo_over_hoka")]
		public string ToyoryoOverHoka { get; set; }

		/// <summary>·Ö</summary>
		[Column("chokin")]
		public string Chokin { get; set; }

		/// <summary>d¡^</summary>
		[Column("chofuku_toyo")]
		public string ChofukuToyo { get; set; }

		/// <summary>d¡^(¼òÇ)</summary>
		[Column("chofuku_toyo_tayakkyoku")]
		public string ChofukuToyoTayakkyoku { get; set; }

		/// <summary>Û¯íÊR[h</summary>
		[Column("hokenshubetsu_code")]
		public string HokenshubetsuCode { get; set; }

		/// <summary>Løæª</summary>
		[Column("enable")]
		public int? Enable { get; set; }

		/// <summary> RXgN^</summary>
		public Nsips1Kanjya()
		{

			Nsips1KanjyaId = 0;
			Nsips0HeaderId = 0;
			Indate = 0;
			Inseq = 0;
			Fupdkbn = "";
			Patseq = 0;
			Stype = 0;
			KanjyaCode = "";
			KanjyaKanaShimei = "";
			KanjyaKanjiShimei = "";
			Seibetsu = "";
			Seinengappi = null;
			Yubinbango = "";
			Jusho = "";
			JitakuDenwabango = "";
			KinmusakiDenwabango = "";
			KinkyuRenrakusaki = "";
			MailAddress = "";
			ItibufutankinKubun = "";
			HokenShubtsu = "";
			HokenshaBango = "";
			HokenshaBangoShutokubi = null;
			HihokenshashoKigo = "";
			HihokenshashoBango = "";
			HihokenshaHifuyousha = 0;
			Kanjyafutanritsu = 0;
			Hokenkyuufuritsu = 0;
			ShokumujyoNoJiyu = "";
			RojinhokenShichosonbango = "";
			RojinhokenJyukyushabango = "";
			RojinhokenShichosonbangoShutokubi = null;
			DaiitikohiFutanshaBango = "";
			DaiitikohiJukyushaBango = "";
			DaiitikohiFutanshaBangoShutokubi = null;
			DainikohiFutanshaBango = "";
			DainikohiJukyushaBango = "";
			DainikohiFutanshaBangoShutokubi = null;
			DaisankohiFutanshaBango = "";
			DaisankohiJukyushaBango = "";
			DaisankohiFutanshaBangoShutokubi = null;
			TokushukohiFutanshaBango = "";
			TokushukohiJukyushaBango = "";
			TokushukohiFutanshaBangoShutokubi = null;
			IppokaShiji = "";
			FunsaiShiji = "";
			ChuiyakuAri = "";
			SogosayoCheck = "";
			SogosayoCheckTayakkyoku = "";
			ToyoryoOverGekiDoku = "";
			ToyoryoOverKo = "";
			ToyoryoOverHoka = "";
			Chokin = "";
			ChofukuToyo = "";
			ChofukuToyoTayakkyoku = "";
			HokenshubetsuCode = "";
			Enable = 0;

		}
	} 
} 
