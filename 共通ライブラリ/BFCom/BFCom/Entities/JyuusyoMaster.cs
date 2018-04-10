namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>住所マスタ</summary>
	[Table("jyuusyo_master")]
	public partial class JyuusyoMaster
	{ 
		/// <summary>主キー</summary>
		[Key]
		[Column("code_id")]
		public int? CodeId { get; set; }

		/// <summary>地方公共団体コード</summary>
		[Column("code")]
		public string Code { get; set; }

		/// <summary>（旧）郵便番号</summary>
		[Column("old_post")]
		public string OldPost { get; set; }

		/// <summary>郵便番号</summary>
		[Column("post")]
		public string Post { get; set; }

		/// <summary>都道府県名カナ</summary>
		[Column("address_ken_kana")]
		public string AddressKenKana { get; set; }

		/// <summary>市区町村名カナ</summary>
		[Column("address_shi_kana")]
		public string AddressShiKana { get; set; }

		/// <summary>町域名カナ</summary>
		[Column("address_machi_kana")]
		public string AddressMachiKana { get; set; }

		/// <summary>都道府県名</summary>
		[Column("address_ken")]
		public string AddressKen { get; set; }

		/// <summary>市区町村名</summary>
		[Column("address_shi")]
		public string AddressShi { get; set; }

		/// <summary>町域名</summary>
		[Column("address_machi")]
		public string AddressMachi { get; set; }

		/// <summary> コンストラクタ</summary>
		public JyuusyoMaster()
		{

			CodeId = 0;
			Code = "";
			OldPost = "";
			Post = "";
			AddressKenKana = "";
			AddressShiKana = "";
			AddressMachiKana = "";
			AddressKen = "";
			AddressShi = "";
			AddressMachi = "";

		}
	} 
} 
