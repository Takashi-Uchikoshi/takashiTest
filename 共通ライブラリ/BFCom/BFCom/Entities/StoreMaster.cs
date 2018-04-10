namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>自社店舗情報マスタ</summary>
	[Table("store_master")]
	public partial class StoreMaster
	{ 
		/// <summary>薬局コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>会社名</summary>
		[Column("kaisha_mei")]
		public string KaishaMei { get; set; }

		/// <summary>会社名フリガナ</summary>
		[Column("kaisha_kana")]
		public string KaishaKana { get; set; }

		/// <summary>薬局名</summary>
		[Column("yakkyoku_mei")]
		public string YakkyokuMei { get; set; }

		/// <summary>薬局フリガナ</summary>
		[Column("yakkyoku_kana")]
		public string YakkyokuKana { get; set; }

		/// <summary>薬局略名</summary>
		[Column("yakkyoku_ryaku_mei")]
		public string YakkyokuRyakuMei { get; set; }

		/// <summary>代表者姓</summary>
		[Column("daihyousha_sei")]
		public string DaihyoushaSei { get; set; }

		/// <summary>代表者名</summary>
		[Column("daihyousha_mei")]
		public string DaihyoushaMei { get; set; }

		/// <summary>代表者姓フリガナ</summary>
		[Column("daihyousha_sei_kana")]
		public string DaihyoushaSeiKana { get; set; }

		/// <summary>代表者名フリガナ</summary>
		[Column("daihyousha_mei_kana")]
		public string DaihyoushaMeiKana { get; set; }

		/// <summary>担当者姓</summary>
		[Column("tantousha_sei")]
		public string TantoushaSei { get; set; }

		/// <summary>担当者名</summary>
		[Column("tantousha_mei")]
		public string TantoushaMei { get; set; }

		/// <summary>担当者姓フリガナ</summary>
		[Column("tantousha_sei_kana")]
		public string TantoushaSeiKana { get; set; }

		/// <summary>担当者名フリガナ</summary>
		[Column("tantouusha_mei_kana")]
		public string TantouushaMeiKana { get; set; }

		/// <summary>薬局種別</summary>
		[Column("yakkyoku_type")]
		public string YakkyokuType { get; set; }

		/// <summary>店舗形態</summary>
		[Column("tempo_keitai")]
		public string TempoKeitai { get; set; }

		/// <summary>分業形態</summary>
		[Column("bungyou_keitai")]
		public string BungyouKeitai { get; set; }

		/// <summary>薬局ランク</summary>
		[Column("yakkyoku_rank")]
		public string YakkyokuRank { get; set; }

		/// <summary>郵便番号</summary>
		[Column("zip_code")]
		public string ZipCode { get; set; }

		/// <summary>都道府県</summary>
		[Column("state")]
		public string State { get; set; }

		/// <summary>市町村</summary>
		[Column("city")]
		public string City { get; set; }

		/// <summary>番地</summary>
		[Column("street")]
		public string Street { get; set; }

		/// <summary>建物名１</summary>
		[Column("tatemono_mei_1")]
		public string TatemonoMei1 { get; set; }

		/// <summary>建物名２</summary>
		[Column("tatemono_mei_2")]
		public string TatemonoMei2 { get; set; }

		/// <summary>電話番号</summary>
		[Column("tel_no")]
		public string TelNo { get; set; }

		/// <summary>FAX番号</summary>
		[Column("fax_no")]
		public string FaxNo { get; set; }

		/// <summary>Eメールアドレス</summary>
		[Column("mail_address")]
		public string MailAddress { get; set; }

		/// <summary>ホームページURL</summary>
		[Column("homepage_url")]
		public string HomepageUrl { get; set; }

		/// <summary>銀行口座-銀行コード</summary>
		[Column("bank_code")]
		public string BankCode { get; set; }

		/// <summary>銀行口座-支店コード</summary>
		[Column("shiten_code")]
		public string ShitenCode { get; set; }

		/// <summary>銀行口座-預金種別</summary>
		[Column("bank_yokin_type")]
		public string BankYokinType { get; set; }

		/// <summary>銀行口座-口座番号</summary>
		[Column("bank_account_no")]
		public string BankAccountNo { get; set; }

		/// <summary>銀行口座-口座名義</summary>
		[Column("bank_account_mei")]
		public string BankAccountMei { get; set; }

		/// <summary>画像ファイルパス１</summary>
		[Column("image_path_1")]
		public string ImagePath1 { get; set; }

		/// <summary>画像ファイルパス２</summary>
		[Column("image_path_2")]
		public string ImagePath2 { get; set; }

		/// <summary>画像ファイルパス３</summary>
		[Column("image_path_3")]
		public string ImagePath3 { get; set; }

		/// <summary>画像ファイルパス４</summary>
		[Column("image_path_4")]
		public string ImagePath4 { get; set; }

		/// <summary>画像ファイルパス５</summary>
		[Column("image_path_5")]
		public string ImagePath5 { get; set; }

		/// <summary>API閲覧フラグ</summary>
		[Column("api_teikyou_flag")]
		public string ApiTeikyouFlag { get; set; }

		/// <summary>開局証明書保存パス</summary>
		[Column("kaikyoku_shoumeisho_hozon_path")]
		public string KaikyokuShoumeishoHozonPath { get; set; }

		/// <summary>許可番号</summary>
		[Column("kyoka_no")]
		public string KyokaNo { get; set; }

		/// <summary>有効期限(FROM)</summary>
		[Column("yuko_kigen_from")]
		public string YukoKigenFrom { get; set; }

		/// <summary>有効期限(TO)</summary>
		[Column("yuko_kigen_to")]
		public string YukoKigenTo { get; set; }

		/// <summary>提供サービス１</summary>
		[Column("teikyou_service_1")]
		public string TeikyouService1 { get; set; }

		/// <summary>契約年月日</summary>
		[Column("keiyaku_ymd")]
		public string KeiyakuYmd { get; set; }

		/// <summary>解除年月日</summary>
		[Column("kaijo_ymd")]
		public string KaijoYmd { get; set; }

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

		/// <summary>医療機関コード</summary>
		[Column("iryoukikan_code")]
		public string IryoukikanCode { get; set; }

		/// <summary>使用開始</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("start_use_date", Order = 1)]
		public int? StartUseDate { get; set; }

		/// <summary>使用終了</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("end_use_date", Order = 2)]
		public int? EndUseDate { get; set; }

		/// <summary> コンストラクタ</summary>
		public StoreMaster()
		{

			YakkyokuCode = "";
			KaishaMei = "";
			KaishaKana = "";
			YakkyokuMei = "";
			YakkyokuKana = "";
			YakkyokuRyakuMei = "";
			DaihyoushaSei = "";
			DaihyoushaMei = "";
			DaihyoushaSeiKana = "";
			DaihyoushaMeiKana = "";
			TantoushaSei = "";
			TantoushaMei = "";
			TantoushaSeiKana = "";
			TantouushaMeiKana = "";
			YakkyokuType = "";
			TempoKeitai = "";
			BungyouKeitai = "";
			YakkyokuRank = "";
			ZipCode = "";
			State = "";
			City = "";
			Street = "";
			TatemonoMei1 = "";
			TatemonoMei2 = "";
			TelNo = "";
			FaxNo = "";
			MailAddress = "";
			HomepageUrl = "";
			BankCode = "";
			ShitenCode = "";
			BankYokinType = "";
			BankAccountNo = "";
			BankAccountMei = "";
			ImagePath1 = "";
			ImagePath2 = "";
			ImagePath3 = "";
			ImagePath4 = "";
			ImagePath5 = "";
			ApiTeikyouFlag = "";
			KaikyokuShoumeishoHozonPath = "";
			KyokaNo = "";
			YukoKigenFrom = "";
			YukoKigenTo = "";
			TeikyouService1 = "";
			KeiyakuYmd = "";
			KaijoYmd = "";
			InsertUserId = 0;
			InsertNitiji = null;
			UpdateUserId = 0;
			UpdateNitiji = null;
			UpdateProgramId = "";
			IryoukikanCode = "";
			StartUseDate = 0;
			EndUseDate = 0;

		}
	} 
} 
