namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>患者情報データ</summary>
	[Table("kanjya_data")]
	public partial class KanjyaData
	{ 
		/// <summary>都道府県番号</summary>
		[Column("todofuken_bango")]
		public string TodofukenBango { get; set; }

		/// <summary>薬局コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>薬局名</summary>
		[Column("yakkyoku_mei")]
		public string YakkyokuMei { get; set; }

		/// <summary>患者コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("kanjya_code", Order = 1)]
		public string KanjyaCode { get; set; }

		/// <summary>患者カナ氏名</summary>
		[Column("kanjya_kana_shimei")]
		public string KanjyaKanaShimei { get; set; }

		/// <summary>患者漢字氏名</summary>
		[Column("kanjya_kanji_shimei")]
		public string KanjyaKanjiShimei { get; set; }

		/// <summary>性別</summary>
		[Column("seibetsu")]
		public string Seibetsu { get; set; }

		/// <summary>生年月日</summary>
		[Column("seinengappi")]
		public DateTime? Seinengappi { get; set; }

		/// <summary>郵便番号</summary>
		[Column("yubinbango")]
		public string Yubinbango { get; set; }

		/// <summary>住所</summary>
		[Column("jusho")]
		public string Jusho { get; set; }

		/// <summary>自宅電話番号</summary>
		[Column("jitaku_denwabango")]
		public string JitakuDenwabango { get; set; }

		/// <summary>勤務先電話番号</summary>
		[Column("kinmusaki_denwabango")]
		public string KinmusakiDenwabango { get; set; }

		/// <summary>緊急連絡先</summary>
		[Column("kinkyu_renrakusaki")]
		public string KinkyuRenrakusaki { get; set; }

		/// <summary>メールアドレス</summary>
		[Column("mail_address")]
		public string MailAddress { get; set; }

		/// <summary>一部負担金区分</summary>
		[Column("itibufutankin_kubun")]
		public string ItibufutankinKubun { get; set; }

		/// <summary>保険種別</summary>
		[Column("hoken_shubtsu")]
		public string HokenShubtsu { get; set; }

		/// <summary>保険者番号</summary>
		[Column("hokensha_bango")]
		public string HokenshaBango { get; set; }

		/// <summary>保険者番号取得日</summary>
		[Column("hokensha_bango_shutokubi")]
		public DateTime? HokenshaBangoShutokubi { get; set; }

		/// <summary>被保険者証記号</summary>
		[Column("hihokenshasho_kigo")]
		public string HihokenshashoKigo { get; set; }

		/// <summary>被保険者証番号</summary>
		[Column("hihokenshasho_bango")]
		public string HihokenshashoBango { get; set; }

		/// <summary>被保険者/被扶養者</summary>
		[Column("hihokensha_hifuyousha")]
		public int? HihokenshaHifuyousha { get; set; }

		/// <summary>患者負担率</summary>
		[Column("kanjyafutanritsu")]
		public decimal? Kanjyafutanritsu { get; set; }

		/// <summary>保険給付率</summary>
		[Column("hokenkyuufuritsu")]
		public decimal? Hokenkyuufuritsu { get; set; }

		/// <summary>職務上の時由</summary>
		[Column("shokumujyo_no_jiyu")]
		public string ShokumujyoNoJiyu { get; set; }

		/// <summary>老人保健市町村番号</summary>
		[Column("rojinhoken_shichosonbango")]
		public string RojinhokenShichosonbango { get; set; }

		/// <summary>老人保健受給者番号</summary>
		[Column("rojinhoken_jyukyushabango")]
		public string RojinhokenJyukyushabango { get; set; }

		/// <summary>老人保健市町村番号取得日</summary>
		[Column("rojinhoken_shichosonbango_shutokubi")]
		public DateTime? RojinhokenShichosonbangoShutokubi { get; set; }

		/// <summary>第一公費負担者番号</summary>
		[Column("daiitikohi_futansha_bango")]
		public string DaiitikohiFutanshaBango { get; set; }

		/// <summary>第一公費受給者番号</summary>
		[Column("daiitikohi_jukyusha_bango")]
		public string DaiitikohiJukyushaBango { get; set; }

		/// <summary>第一公費負担者番号取得日</summary>
		[Column("daiitikohi_futansha_bango_shutokubi")]
		public DateTime? DaiitikohiFutanshaBangoShutokubi { get; set; }

		/// <summary>第二公費負担者番号</summary>
		[Column("dainikohi_futansha_bango")]
		public string DainikohiFutanshaBango { get; set; }

		/// <summary>第二公費受給者番号</summary>
		[Column("dainikohi_jukyusha_bango")]
		public string DainikohiJukyushaBango { get; set; }

		/// <summary>第二公費負担者番号取得日</summary>
		[Column("dainikohi_futansha_bango_shutokubi")]
		public DateTime? DainikohiFutanshaBangoShutokubi { get; set; }

		/// <summary>第三公費負担者番号</summary>
		[Column("daisankohi_futansha_bango")]
		public string DaisankohiFutanshaBango { get; set; }

		/// <summary>第三公費受給者番号</summary>
		[Column("daisankohi_jukyusha_bango")]
		public string DaisankohiJukyushaBango { get; set; }

		/// <summary>第三公費負担者番号取得日</summary>
		[Column("daisankohi_futansha_bango_shutokubi")]
		public DateTime? DaisankohiFutanshaBangoShutokubi { get; set; }

		/// <summary>特殊公費負担者番号</summary>
		[Column("tokushukohi_futansha_bango")]
		public string TokushukohiFutanshaBango { get; set; }

		/// <summary>特殊公費受給者番号</summary>
		[Column("tokushukohi_jukyusha_bango")]
		public string TokushukohiJukyushaBango { get; set; }

		/// <summary>特殊公費負担者番号取得日</summary>
		[Column("tokushukohi_futansha_bango_shutokubi")]
		public DateTime? TokushukohiFutanshaBangoShutokubi { get; set; }

		/// <summary>１包化指示</summary>
		[Column("ippoka_shiji")]
		public string IppokaShiji { get; set; }

		/// <summary>粉砕指示</summary>
		[Column("funsai_shiji")]
		public string FunsaiShiji { get; set; }

		/// <summary>注意薬あり</summary>
		[Column("chuiyaku_ari")]
		public string ChuiyakuAri { get; set; }

		/// <summary>相互作用チェック</summary>
		[Column("sogosayo_check")]
		public string SogosayoCheck { get; set; }

		/// <summary>相互作用チェック(他薬局)</summary>
		[Column("sogosayo_check_tayakkyoku")]
		public string SogosayoCheckTayakkyoku { get; set; }

		/// <summary>投与量オーバー(劇/毒)</summary>
		[Column("toyoryo_over_geki_doku")]
		public string ToyoryoOverGekiDoku { get; set; }

		/// <summary>投与量オーバー(向)</summary>
		[Column("toyoryo_over_ko")]
		public string ToyoryoOverKo { get; set; }

		/// <summary>投与量オーバー(他)</summary>
		[Column("toyoryo_over_hoka")]
		public string ToyoryoOverHoka { get; set; }

		/// <summary>長禁</summary>
		[Column("chokin")]
		public string Chokin { get; set; }

		/// <summary>重複投与</summary>
		[Column("chofuku_toyo")]
		public string ChofukuToyo { get; set; }

		/// <summary>重複投与(他薬局)</summary>
		[Column("chofuku_toyo_tayakkyoku")]
		public string ChofukuToyoTayakkyoku { get; set; }

		/// <summary>保険種別コード</summary>
		[Column("hokenshubetsu_code")]
		public string HokenshubetsuCode { get; set; }

		/// <summary>有効区分</summary>
		[Column("enable")]
		public int? Enable { get; set; }

		/// <summary>登録日</summary>
		[Column("insert_date")]
		public DateTime? InsertDate { get; set; }

		/// <summary>更新日</summary>
		[Column("update_date")]
		public DateTime? UpdateDate { get; set; }

		/// <summary>使用開始</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("start_use_date", Order = 2)]
		public int? StartUseDate { get; set; }

		/// <summary>使用終了</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("end_use_date", Order = 3)]
		public int? EndUseDate { get; set; }

		/// <summary> コンストラクタ</summary>
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
