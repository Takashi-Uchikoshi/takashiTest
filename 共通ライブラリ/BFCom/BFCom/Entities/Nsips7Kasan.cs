namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>NSIPS加算情報部テーブル</summary>
	[Table("nsips7_kasan")]
	public partial class Nsips7Kasan
	{ 
		/// <summary>Nsips7加算情報ID</summary>
		[Key]
		[Column("nsips7_kasan_id")]
		public int? Nsips7KasanId { get; set; }

		/// <summary>Nsips0ヘッダID</summary>
		[Column("nsips0_header_id")]
		public int? Nsips0HeaderId { get; set; }

		/// <summary>識別子</summary>
		[Column("stype")]
		public int? Stype { get; set; }

		/// <summary>加算番号</summary>
		[Column("kasan_bango")]
		public int? KasanBango { get; set; }

		/// <summary>算定コード</summary>
		[Column("sante_code")]
		public string SanteCode { get; set; }

		/// <summary>算定名称</summary>
		[Column("sante_meisho")]
		public string SanteMeisho { get; set; }

		/// <summary>回数</summary>
		[Column("kaisu")]
		public decimal? Kaisu { get; set; }

		/// <summary>点数</summary>
		[Column("tensu")]
		public decimal? Tensu { get; set; }

		/// <summary>ファイル更新区分</summary>
		[Column("fupdkbn")]
		public string Fupdkbn { get; set; }

		/// <summary>有効区分</summary>
		[Column("yuko_flag")]
		public int? YukoFlag { get; set; }

		/// <summary> コンストラクタ</summary>
		public Nsips7Kasan()
		{

			Nsips7KasanId = 0;
			Nsips0HeaderId = 0;
			Stype = 0;
			KasanBango = 0;
			SanteCode = "";
			SanteMeisho = "";
			Kaisu = 0;
			Tensu = 0;
			Fupdkbn = "";
			YukoFlag = 0;

		}
	} 
} 
