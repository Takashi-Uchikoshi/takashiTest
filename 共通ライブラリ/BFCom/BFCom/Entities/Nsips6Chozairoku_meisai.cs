namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>NSIPS調剤録明細部テーブル</summary>
	[Table("nsips6_chozairoku_meisai")]
	public partial class Nsips6Chozairoku_meisai
	{ 
		/// <summary>Nsips6調剤録明細ID</summary>
		[Key]
		[Column("nsips6_chozairoku_meisai_id")]
		public int? Nsips6ChozairokuMeisaiId { get; set; }

		/// <summary>Nsips0ヘッダID</summary>
		[Column("nsips0_header_id")]
		public int? Nsips0HeaderId { get; set; }

		/// <summary>識別子</summary>
		[Column("stype")]
		public int? Stype { get; set; }

		/// <summary>RP番号</summary>
		[Column("rp_bango")]
		public int? RpBango { get; set; }

		/// <summary>調剤料</summary>
		[Column("chozairyo")]
		public decimal? Chozairyo { get; set; }

		/// <summary>薬剤料</summary>
		[Column("yakuzairyo")]
		public decimal? Yakuzairyo { get; set; }

		/// <summary>数量</summary>
		[Column("suryo")]
		public decimal? Suryo { get; set; }

		/// <summary>小計</summary>
		[Column("shoke")]
		public decimal? Shoke { get; set; }

		/// <summary>薬剤加算</summary>
		[Column("yakuzaikazan")]
		public decimal? Yakuzaikazan { get; set; }

		/// <summary>合計</summary>
		[Column("goke")]
		public decimal? Goke { get; set; }

		/// <summary>薬剤加算コード01</summary>
		[Column("yakuzaikazan_code01")]
		public string YakuzaikazanCode01 { get; set; }

		/// <summary>薬剤加算の内容01</summary>
		[Column("yakuzaikazan_no_naiyo01")]
		public string YakuzaikazanNoNaiyo01 { get; set; }

		/// <summary>薬剤加算コード02</summary>
		[Column("yakuzaikazan_code02")]
		public string YakuzaikazanCode02 { get; set; }

		/// <summary>薬剤加算の内容02</summary>
		[Column("yakuzaikazan_no_naiyo02")]
		public string YakuzaikazanNoNaiyo02 { get; set; }

		/// <summary>薬剤加算コード03</summary>
		[Column("yakuzaikazan_code03")]
		public string YakuzaikazanCode03 { get; set; }

		/// <summary>薬剤加算の内容03</summary>
		[Column("yakuzaikazan_no_naiyo03")]
		public string YakuzaikazanNoNaiyo03 { get; set; }

		/// <summary>薬剤加算コード04</summary>
		[Column("yakuzaikazan_code04")]
		public string YakuzaikazanCode04 { get; set; }

		/// <summary>薬剤加算の内容04</summary>
		[Column("yakuzaikazan_no_naiyo04")]
		public string YakuzaikazanNoNaiyo04 { get; set; }

		/// <summary>薬剤加算コード05</summary>
		[Column("yakuzaikazan_code05")]
		public string YakuzaikazanCode05 { get; set; }

		/// <summary>薬剤加算の内容05</summary>
		[Column("yakuzaikazan_no_naiyo05")]
		public string YakuzaikazanNoNaiyo05 { get; set; }

		/// <summary>薬剤加算コード06</summary>
		[Column("yakuzaikazan_code06")]
		public string YakuzaikazanCode06 { get; set; }

		/// <summary>薬剤加算の内容06</summary>
		[Column("yakuzaikazan_no_naiyo06")]
		public string YakuzaikazanNoNaiyo06 { get; set; }

		/// <summary>薬剤加算コード07</summary>
		[Column("yakuzaikazan_code07")]
		public string YakuzaikazanCode07 { get; set; }

		/// <summary>薬剤加算の内容07</summary>
		[Column("yakuzaikazan_no_naiyo07")]
		public string YakuzaikazanNoNaiyo07 { get; set; }

		/// <summary>薬剤加算コード08</summary>
		[Column("yakuzaikazan_code08")]
		public string YakuzaikazanCode08 { get; set; }

		/// <summary>薬剤加算の内容08</summary>
		[Column("yakuzaikazan_no_naiyo08")]
		public string YakuzaikazanNoNaiyo08 { get; set; }

		/// <summary>薬剤加算コード09</summary>
		[Column("yakuzaikazan_code09")]
		public string YakuzaikazanCode09 { get; set; }

		/// <summary>薬剤加算の内容09</summary>
		[Column("yakuzaikazan_no_naiyo09")]
		public string YakuzaikazanNoNaiyo09 { get; set; }

		/// <summary>薬剤加算コード10</summary>
		[Column("yakuzaikazan_code10")]
		public string YakuzaikazanCode10 { get; set; }

		/// <summary>薬剤加算の内容10</summary>
		[Column("yakuzaikazan_no_naiyo10")]
		public string YakuzaikazanNoNaiyo10 { get; set; }

		/// <summary>ファイル更新区分</summary>
		[Column("fupdkbn")]
		public string Fupdkbn { get; set; }

		/// <summary>有効区分</summary>
		[Column("yuko_flag")]
		public int? YukoFlag { get; set; }

		/// <summary> コンストラクタ</summary>
		public Nsips6Chozairoku_meisai()
		{

			Nsips6ChozairokuMeisaiId = 0;
			Nsips0HeaderId = 0;
			Stype = 0;
			RpBango = 0;
			Chozairyo = 0;
			Yakuzairyo = 0;
			Suryo = 0;
			Shoke = 0;
			Yakuzaikazan = 0;
			Goke = 0;
			YakuzaikazanCode01 = "";
			YakuzaikazanNoNaiyo01 = "";
			YakuzaikazanCode02 = "";
			YakuzaikazanNoNaiyo02 = "";
			YakuzaikazanCode03 = "";
			YakuzaikazanNoNaiyo03 = "";
			YakuzaikazanCode04 = "";
			YakuzaikazanNoNaiyo04 = "";
			YakuzaikazanCode05 = "";
			YakuzaikazanNoNaiyo05 = "";
			YakuzaikazanCode06 = "";
			YakuzaikazanNoNaiyo06 = "";
			YakuzaikazanCode07 = "";
			YakuzaikazanNoNaiyo07 = "";
			YakuzaikazanCode08 = "";
			YakuzaikazanNoNaiyo08 = "";
			YakuzaikazanCode09 = "";
			YakuzaikazanNoNaiyo09 = "";
			YakuzaikazanCode10 = "";
			YakuzaikazanNoNaiyo10 = "";
			Fupdkbn = "";
			YukoFlag = 0;

		}
	} 
} 
