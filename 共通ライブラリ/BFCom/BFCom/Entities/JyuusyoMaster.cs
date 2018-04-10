namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>�Z���}�X�^</summary>
	[Table("jyuusyo_master")]
	public partial class JyuusyoMaster
	{ 
		/// <summary>��L�[</summary>
		[Key]
		[Column("code_id")]
		public int? CodeId { get; set; }

		/// <summary>�n�������c�̃R�[�h</summary>
		[Column("code")]
		public string Code { get; set; }

		/// <summary>�i���j�X�֔ԍ�</summary>
		[Column("old_post")]
		public string OldPost { get; set; }

		/// <summary>�X�֔ԍ�</summary>
		[Column("post")]
		public string Post { get; set; }

		/// <summary>�s���{�����J�i</summary>
		[Column("address_ken_kana")]
		public string AddressKenKana { get; set; }

		/// <summary>�s�撬�����J�i</summary>
		[Column("address_shi_kana")]
		public string AddressShiKana { get; set; }

		/// <summary>���於�J�i</summary>
		[Column("address_machi_kana")]
		public string AddressMachiKana { get; set; }

		/// <summary>�s���{����</summary>
		[Column("address_ken")]
		public string AddressKen { get; set; }

		/// <summary>�s�撬����</summary>
		[Column("address_shi")]
		public string AddressShi { get; set; }

		/// <summary>���於</summary>
		[Column("address_machi")]
		public string AddressMachi { get; set; }

		/// <summary> �R���X�g���N�^</summary>
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
