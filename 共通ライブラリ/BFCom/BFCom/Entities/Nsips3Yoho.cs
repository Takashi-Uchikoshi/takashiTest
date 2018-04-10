namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>NSIPS用法部テーブル</summary>
	[Table("nsips3_yoho")]
	public partial class Nsips3Yoho
	{ 
		/// <summary>Nsips0用法ID</summary>
		[Key]
		[Column("nsips3_yoho_id")]
		public int? Nsips3YohoId { get; set; }

		/// <summary>Nsips0ヘッダID</summary>
		[Column("nsips0_header_id")]
		public int? Nsips0HeaderId { get; set; }

		/// <summary>Nsips2処方箋ID</summary>
		[Column("nsips2_shohosen_id")]
		public int? Nsips2ShohosenId { get; set; }

		/// <summary>識別子</summary>
		[Column("stype")]
		public int? Stype { get; set; }

		/// <summary>RP番号</summary>
		[Column("rp_bango")]
		public int? RpBango { get; set; }

		/// <summary>用法コード1</summary>
		[Column("yoho_code1")]
		public string YohoCode1 { get; set; }

		/// <summary>用法名1</summary>
		[Column("yoho_mei1")]
		public string YohoMei1 { get; set; }

		/// <summary>用法コード2</summary>
		[Column("yoho_code2")]
		public string YohoCode2 { get; set; }

		/// <summary>用法名2</summary>
		[Column("yoho_mei2")]
		public string YohoMei2 { get; set; }

		/// <summary>用法コード3</summary>
		[Column("yoho_code3")]
		public string YohoCode3 { get; set; }

		/// <summary>用法名3</summary>
		[Column("yoho_mei3")]
		public string YohoMei3 { get; set; }

		/// <summary>RP区分</summary>
		[Column("rp_kubun")]
		public string RpKubun { get; set; }

		/// <summary>日回区分</summary>
		[Column("nichikai_kubun")]
		public string NichikaiKubun { get; set; }

		/// <summary>日回数</summary>
		[Column("nitikai_su")]
		public int? NitikaiSu { get; set; }

		/// <summary>服用回数</summary>
		[Column("fukuyo_kaisu")]
		public int? FukuyoKaisu { get; set; }

		/// <summary>服用開始日</summary>
		[Column("fukuyo_kaishibi")]
		public DateTime? FukuyoKaishibi { get; set; }

		/// <summary>薬品明細数</summary>
		[Column("yakuhin_meisaisu")]
		public int? YakuhinMeisaisu { get; set; }

		/// <summary>１包化RP区分</summary>
		[Column("ippoka_rp_kubun")]
		public string IppokaRpKubun { get; set; }

		/// <summary>粉砕RP区分</summary>
		[Column("funsai_rp_kubun")]
		public string FunsaiRpKubun { get; set; }

		/// <summary>用法コメント1</summary>
		[Column("yoho_comment1")]
		public string YohoComment1 { get; set; }

		/// <summary>用法部予備</summary>
		[Column("yohobu_yobi")]
		public string YohobuYobi { get; set; }

		/// <summary>用法コメント2</summary>
		[Column("yoho_comment2")]
		public string YohoComment2 { get; set; }

		/// <summary>用法コメント3</summary>
		[Column("yoho_comment3")]
		public string YohoComment3 { get; set; }

		/// <summary>用法コメント4</summary>
		[Column("yoho_comment4")]
		public string YohoComment4 { get; set; }

		/// <summary>用法コメント5</summary>
		[Column("yoho_comment5")]
		public string YohoComment5 { get; set; }

		/// <summary>ファイル更新区分</summary>
		[Column("fupdkbn")]
		public string Fupdkbn { get; set; }

		/// <summary>有効区分</summary>
		[Column("yuko_flag")]
		public int? YukoFlag { get; set; }

		/// <summary> コンストラクタ</summary>
		public Nsips3Yoho()
		{

			Nsips3YohoId = 0;
			Nsips0HeaderId = 0;
			Nsips2ShohosenId = 0;
			Stype = 0;
			RpBango = 0;
			YohoCode1 = "";
			YohoMei1 = "";
			YohoCode2 = "";
			YohoMei2 = "";
			YohoCode3 = "";
			YohoMei3 = "";
			RpKubun = "";
			NichikaiKubun = "";
			NitikaiSu = 0;
			FukuyoKaisu = 0;
			FukuyoKaishibi = null;
			YakuhinMeisaisu = 0;
			IppokaRpKubun = "";
			FunsaiRpKubun = "";
			YohoComment1 = "";
			YohobuYobi = "";
			YohoComment2 = "";
			YohoComment3 = "";
			YohoComment4 = "";
			YohoComment5 = "";
			Fupdkbn = "";
			YukoFlag = 0;

		}
	} 
} 
