namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>òÇ}X^</summary>
	[Table("yakkyoku_master")]
	public partial class YakkyokuMaster
	{ 
		/// <summary>òÇR[h</summary>
		[Key]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>ïÐ¼</summary>
		[Column("kaisha_mei")]
		public string KaishaMei { get; set; }

		/// <summary>ïÐ¼tKi</summary>
		[Column("kaisha_kana")]
		public string KaishaKana { get; set; }

		/// <summary>òÇ¼</summary>
		[Column("yakkyoku_mei")]
		public string YakkyokuMei { get; set; }

		/// <summary>òÇtKi</summary>
		[Column("yakkyoku_kana")]
		public string YakkyokuKana { get; set; }

		/// <summary>òÇª¼</summary>
		[Column("yakkyoku_ryaku_mei")]
		public string YakkyokuRyakuMei { get; set; }

		/// <summary>ã\Ò©</summary>
		[Column("daihyousha_sei")]
		public string DaihyoushaSei { get; set; }

		/// <summary>ã\Ò¼</summary>
		[Column("daihyousha_mei")]
		public string DaihyoushaMei { get; set; }

		/// <summary>ã\Ò©tKi</summary>
		[Column("daihyousha_sei_kana")]
		public string DaihyoushaSeiKana { get; set; }

		/// <summary>ã\Ò¼tKi</summary>
		[Column("daihyousha_mei_kana")]
		public string DaihyoushaMeiKana { get; set; }

		/// <summary>òÇíÊ</summary>
		[Column("yakkyoku_type")]
		public string YakkyokuType { get; set; }

		/// <summary>XÜ`Ô</summary>
		[Column("tempo_keitai")]
		public string TempoKeitai { get; set; }

		/// <summary>ªÆ`Ô</summary>
		[Column("bungyou_keitai")]
		public string BungyouKeitai { get; set; }

		/// <summary>òÇN</summary>
		[Column("yakkyoku_rank")]
		public string YakkyokuRank { get; set; }

		/// <summary>XÖÔ</summary>
		[Column("zip_code")]
		public string ZipCode { get; set; }

		/// <summary>s¹{§</summary>
		[Column("state")]
		public string State { get; set; }

		/// <summary>s¬º</summary>
		[Column("city")]
		public string City { get; set; }

		/// <summary>Ôn</summary>
		[Column("street")]
		public string Street { get; set; }

		/// <summary>¨¼P</summary>
		[Column("tatemono_mei_1")]
		public string TatemonoMei1 { get; set; }

		/// <summary>¨¼Q</summary>
		[Column("tatemono_mei_2")]
		public string TatemonoMei2 { get; set; }

		/// <summary>dbÔ</summary>
		[Column("tel_no")]
		public string TelNo { get; set; }

		/// <summary>FAXÔ</summary>
		[Column("fax_no")]
		public string FaxNo { get; set; }

		/// <summary>E[AhX</summary>
		[Column("mail_address")]
		public string MailAddress { get; set; }

		/// <summary>z[y[WURL</summary>
		[Column("homepage_url")]
		public string HomepageUrl { get; set; }

		/// <summary>âsûÀ-âsR[h</summary>
		[Column("bank_code")]
		public string BankCode { get; set; }

		/// <summary>âsûÀ-xXR[h</summary>
		[Column("shiten_code")]
		public string ShitenCode { get; set; }

		/// <summary>âsûÀ-aàíÊ</summary>
		[Column("bank_yokin_type")]
		public string BankYokinType { get; set; }

		/// <summary>âsûÀ-ûÀÔ</summary>
		[Column("bank_account_no")]
		public string BankAccountNo { get; set; }

		/// <summary>âsûÀ-ûÀ¼`</summary>
		[Column("bank_account_mei")]
		public string BankAccountMei { get; set; }

		/// <summary>æt@CpXP</summary>
		[Column("image_path_1")]
		public string ImagePath1 { get; set; }

		/// <summary>æt@CpXQ</summary>
		[Column("image_path_2")]
		public string ImagePath2 { get; set; }

		/// <summary>æt@CpXR</summary>
		[Column("image_path_3")]
		public string ImagePath3 { get; set; }

		/// <summary>JÇØ¾Û¶pX</summary>
		[Column("kaikyoku_shoumeisho_hozon_path")]
		public string KaikyokuShoumeishoHozonPath { get; set; }

		/// <summary>ñT[rXP</summary>
		[Column("teikyou_service_1")]
		public string TeikyouService1 { get; set; }

		/// <summary>_ñNú</summary>
		[Column("keiyaku_ymd")]
		public string KeiyakuYmd { get; set; }

		/// <summary>ðNú</summary>
		[Column("kaijo_ymd")]
		public string KaijoYmd { get; set; }

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
		public YakkyokuMaster()
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
			KaikyokuShoumeishoHozonPath = "";
			TeikyouService1 = "";
			KeiyakuYmd = "";
			KaijoYmd = "";
			InsertUserId = 0;
			InsertNitiji = null;
			UpdateUserId = 0;
			UpdateNitiji = null;
			UpdateProgramId = "";
			KanriZokusei = 0;

		}
	} 
} 
