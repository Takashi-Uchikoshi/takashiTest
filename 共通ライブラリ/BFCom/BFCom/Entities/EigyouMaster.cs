namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>�c�Ɠ����}�X�^</summary>
	[Table("eigyou_master")]
	public partial class EigyouMaster
	{ 
		/// <summary>��ǃR�[�h</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>�c�Ɠ�</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("eigyou_ymd", Order = 1)]
		public DateTime? EigyouYmd { get; set; }

		/// <summary>�敪</summary>
		[Column("kubun")]
		public int? Kubun { get; set; }

		/// <summary>�ʒm����</summary>
		[Column("tsuchi_sikibetsu")]
		public int? TsuchiSikibetsu { get; set; }

		/// <summary>�ʒm����</summary>
		[Column("tsuchi_date")]
		public DateTime? TsuchiDate { get; set; }

		/// <summary>�Ǘ�����</summary>
		[Column("kanri_zokusei")]
		public int? KanriZokusei { get; set; }

		/// <summary> �R���X�g���N�^</summary>
		public EigyouMaster()
		{

			YakkyokuCode = "";
			EigyouYmd = null;
			Kubun = 0;
			TsuchiSikibetsu = 0;
			TsuchiDate = null;
			KanriZokusei = 0;

		}
	} 
} 
