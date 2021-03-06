namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>���ҏ��f�[�^</summary>
	[Table("kanjya_data")]
	public partial class KanjyaData
	{ 
		/// <summary>�s���{���ԍ�</summary>
		[Column("todofuken_bango")]
		public string TodofukenBango { get; set; }

		/// <summary>��ǃR�[�h</summary>
		[Key]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>��ǖ�</summary>
		[Column("yakkyoku_mei")]
		public string YakkyokuMei { get; set; }

		/// <summary>���҃R�[�h</summary>
		[Key]
		[Column("kanjya_code", Order = 1)]
		public string KanjyaCode { get; set; }

		/// <summary>���҃J�i����</summary>
		[Column("kanjya_kana_shimei")]
		public string KanjyaKanaShimei { get; set; }

		/// <summary>���Ҋ�������</summary>
		[Column("kanjya_kanji_shimei")]
		public string KanjyaKanjiShimei { get; set; }

		/// <summary>����</summary>
		[Column("seibetsu")]
		public string Seibetsu { get; set; }

		/// <summary>���N����</summary>
		[Column("seinengappi")]
		public DateTime? Seinengappi { get; set; }

		/// <summary>�X�֔ԍ�</summary>
		[Column("yubinbango")]
		public string Yubinbango { get; set; }

		/// <summary>�Z��</summary>
		[Column("jusho")]
		public string Jusho { get; set; }

		/// <summary>����d�b�ԍ�</summary>
		[Column("jitaku_denwabango")]
		public string JitakuDenwabango { get; set; }

		/// <summary>�Ζ���d�b�ԍ�</summary>
		[Column("kinmusaki_denwabango")]
		public string KinmusakiDenwabango { get; set; }

		/// <summary>�ً}�A����</summary>
		[Column("kinkyu_renrakusaki")]
		public string KinkyuRenrakusaki { get; set; }

		/// <summary>���[���A�h���X</summary>
		[Column("mail_address")]
		public string MailAddress { get; set; }

		/// <summary>�ꕔ���S���敪</summary>
		[Column("itibufutankin_kubun")]
		public string ItibufutankinKubun { get; set; }

		/// <summary>�ی����</summary>
		[Column("hoken_shubtsu")]
		public string HokenShubtsu { get; set; }

		/// <summary>�ی��Ҕԍ�</summary>
		[Column("hokensha_bango")]
		public string HokenshaBango { get; set; }

		/// <summary>�ی��Ҕԍ��擾��</summary>
		[Column("hokensha_bango_shutokubi")]
		public DateTime? HokenshaBangoShutokubi { get; set; }

		/// <summary>��ی��ҏ؋L��</summary>
		[Column("hihokenshasho_kigo")]
		public string HihokenshashoKigo { get; set; }

		/// <summary>��ی��ҏؔԍ�</summary>
		[Column("hihokenshasho_bango")]
		public string HihokenshashoBango { get; set; }

		/// <summary>��ی���/��}�{��</summary>
		[Column("hihokensha_hifuyousha")]
		public int? HihokenshaHifuyousha { get; set; }

		/// <summary>���ҕ��S��</summary>
		[Column("kanjyafutanritsu")]
		public decimal? Kanjyafutanritsu { get; set; }

		/// <summary>�ی����t��</summary>
		[Column("hokenkyuufuritsu")]
		public decimal? Hokenkyuufuritsu { get; set; }

		/// <summary>�E����̎��R</summary>
		[Column("shokumujyo_no_jiyu")]
		public string ShokumujyoNoJiyu { get; set; }

		/// <summary>�V�l�ی��s�����ԍ�</summary>
		[Column("rojinhoken_shichosonbango")]
		public string RojinhokenShichosonbango { get; set; }

		/// <summary>�V�l�ی��󋋎Ҕԍ�</summary>
		[Column("rojinhoken_jyukyushabango")]
		public string RojinhokenJyukyushabango { get; set; }

		/// <summary>�V�l�ی��s�����ԍ��擾��</summary>
		[Column("rojinhoken_shichosonbango_shutokubi")]
		public DateTime? RojinhokenShichosonbangoShutokubi { get; set; }

		/// <summary>������S�Ҕԍ�</summary>
		[Column("daiitikohi_futansha_bango")]
		public string DaiitikohiFutanshaBango { get; set; }

		/// <summary>������󋋎Ҕԍ�</summary>
		[Column("daiitikohi_jukyusha_bango")]
		public string DaiitikohiJukyushaBango { get; set; }

		/// <summary>������S�Ҕԍ��擾��</summary>
		[Column("daiitikohi_futansha_bango_shutokubi")]
		public DateTime? DaiitikohiFutanshaBangoShutokubi { get; set; }

		/// <summary>������S�Ҕԍ�</summary>
		[Column("dainikohi_futansha_bango")]
		public string DainikohiFutanshaBango { get; set; }

		/// <summary>������󋋎Ҕԍ�</summary>
		[Column("dainikohi_jukyusha_bango")]
		public string DainikohiJukyushaBango { get; set; }

		/// <summary>������S�Ҕԍ��擾��</summary>
		[Column("dainikohi_futansha_bango_shutokubi")]
		public DateTime? DainikohiFutanshaBangoShutokubi { get; set; }

		/// <summary>��O����S�Ҕԍ�</summary>
		[Column("daisankohi_futansha_bango")]
		public string DaisankohiFutanshaBango { get; set; }

		/// <summary>��O����󋋎Ҕԍ�</summary>
		[Column("daisankohi_jukyusha_bango")]
		public string DaisankohiJukyushaBango { get; set; }

		/// <summary>��O����S�Ҕԍ��擾��</summary>
		[Column("daisankohi_futansha_bango_shutokubi")]
		public DateTime? DaisankohiFutanshaBangoShutokubi { get; set; }

		/// <summary>�������S�Ҕԍ�</summary>
		[Column("tokushukohi_futansha_bango")]
		public string TokushukohiFutanshaBango { get; set; }

		/// <summary>�������󋋎Ҕԍ�</summary>
		[Column("tokushukohi_jukyusha_bango")]
		public string TokushukohiJukyushaBango { get; set; }

		/// <summary>�������S�Ҕԍ��擾��</summary>
		[Column("tokushukohi_futansha_bango_shutokubi")]
		public DateTime? TokushukohiFutanshaBangoShutokubi { get; set; }

		/// <summary>�P��w��</summary>
		[Column("ippoka_shiji")]
		public string IppokaShiji { get; set; }

		/// <summary>���ӎw��</summary>
		[Column("funsai_shiji")]
		public string FunsaiShiji { get; set; }

		/// <summary>���Ӗ򂠂�</summary>
		[Column("chuiyaku_ari")]
		public string ChuiyakuAri { get; set; }

		/// <summary>���ݍ�p�`�F�b�N</summary>
		[Column("sogosayo_check")]
		public string SogosayoCheck { get; set; }

		/// <summary>���ݍ�p�`�F�b�N(�����)</summary>
		[Column("sogosayo_check_tayakkyoku")]
		public string SogosayoCheckTayakkyoku { get; set; }

		/// <summary>���^�ʃI�[�o�[(��/��)</summary>
		[Column("toyoryo_over_geki_doku")]
		public string ToyoryoOverGekiDoku { get; set; }

		/// <summary>���^�ʃI�[�o�[(��)</summary>
		[Column("toyoryo_over_ko")]
		public string ToyoryoOverKo { get; set; }

		/// <summary>���^�ʃI�[�o�[(��)</summary>
		[Column("toyoryo_over_hoka")]
		public string ToyoryoOverHoka { get; set; }

		/// <summary>����</summary>
		[Column("chokin")]
		public string Chokin { get; set; }

		/// <summary>�d�����^</summary>
		[Column("chofuku_toyo")]
		public string ChofukuToyo { get; set; }

		/// <summary>�d�����^(�����)</summary>
		[Column("chofuku_toyo_tayakkyoku")]
		public string ChofukuToyoTayakkyoku { get; set; }

		/// <summary>�ی���ʃR�[�h</summary>
		[Column("hokenshubetsu_code")]
		public string HokenshubetsuCode { get; set; }

		/// <summary>�L���敪</summary>
		[Column("enable")]
		public int? Enable { get; set; }

		/// <summary>�o�^��</summary>
		[Column("insert_date")]
		public DateTime? InsertDate { get; set; }

		/// <summary>�X�V��</summary>
		[Column("update_date")]
		public DateTime? UpdateDate { get; set; }

		/// <summary>�g�p�J�n</summary>
		[Key]
		[Column("start_use_date", Order = 2)]
		public int? StartUseDate { get; set; }

		/// <summary>�g�p�I��</summary>
		[Key]
		[Column("end_use_date", Order = 3)]
		public int? EndUseDate { get; set; }

		/// <summary> �R���X�g���N�^</summary>
		public KanjyaData()
		{

			TodofukenBango = "";
			YakkyokuCode = "";
			YakkyokuMei = "";
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
			InsertDate = null;
			UpdateDate = null;
			StartUseDate = 0;
			EndUseDate = 0;

		}
	} 
} 
