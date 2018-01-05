namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>BF���܎��ѐ��e�[�u��</summary>
	[Table("bf_chouzai_jisseki")]
	public partial class BfChouzai_jisseki
	{ 
		/// <summary>��ǃR�[�h</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>���i�R�[�h</summary>
		[Column("gtin_cd")]
		public string GtinCd { get; set; }

		/// <summary>���ܓ�</summary>
		[Key]
		[Column("cymd", Order = 0)]
		public DateTime? Cymd { get; set; }

		/// <summary>���܉�</summary>
		[Column("cnt")]
		public int? Cnt { get; set; }

		/// <summary>�����</summary>
		[Column("used_su")]
		public decimal? UsedSu { get; set; }

		/// <summary> �R���X�g���N�^</summary>
		public BfChouzai_jisseki()
		{

			YakkyokuCode = "";
			GtinCd = "";
			Cymd = null;
			Cnt = 0;
			UsedSu = 0;

		}
	} 
} 
