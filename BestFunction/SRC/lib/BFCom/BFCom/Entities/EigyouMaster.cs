namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>�c�Ɠ����}�X�^</summary>
	[Table("eigyou_master")]
	public partial class EigyouMaster
	{ 
		/// <summary>��ǃR�[�h</summary>
		[Key]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>�c�Ɠ�</summary>
		[Key]
		[Column("EIGYOU_YMD", Order = 1)]
		public DateTime? EIGYOUYMD { get; set; }

		/// <summary>�敪</summary>
		[Column("KUBUN")]
		public int? KUBUN { get; set; }

		/// <summary> �R���X�g���N�^</summary>
		public EigyouMaster()
		{

			YakkyokuCode = "";
			EIGYOUYMD = null;
			KUBUN = 0;

		}
	} 
} 
