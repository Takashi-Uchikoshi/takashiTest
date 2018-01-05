namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>�I�ԍ��Ǘ��}�X�^</summary>
	[Table("tanaban_master")]
	public partial class TanabanMaster
	{ 
		/// <summary>�I�ԃR�[�h</summary>
		[Key]
		[Column("tanaban_code", Order = 0)]
		public string TanabanCode { get; set; }

		/// <summary>��ǃR�[�h</summary>
		[Key]
		[Column("yakkyoku_code", Order = 1)]
		public string YakkyokuCode { get; set; }

		/// <summary>�I�Ԗ�</summary>
		[Column("tanaban_mei")]
		public string TanabanMei { get; set; }

		/// <summary>�I�ԃR�����g</summary>
		[Column("tanaban_comment")]
		public string TanabanComment { get; set; }

		/// <summary>�o�^��ID</summary>
		[Column("insert_user_id")]
		public int? InsertUserId { get; set; }

		/// <summary>�o�^����</summary>
		[Column("insert_nitiji")]
		public DateTime? InsertNitiji { get; set; }

		/// <summary>�X�V��ID</summary>
		[Column("update_user_id")]
		public int? UpdateUserId { get; set; }

		/// <summary>�X�V����</summary>
		[Column("update_nitiji")]
		public DateTime? UpdateNitiji { get; set; }

		/// <summary>�X�V�v���O����ID</summary>
		[Column("update_program_id")]
		public string UpdateProgramId { get; set; }

		/// <summary>�g�p�J�n</summary>
		[Key]
		[Column("start_use_date", Order = 2)]
		public int? StartUseDate { get; set; }

		/// <summary>�g�p�I��</summary>
		[Key]
		[Column("end_use_date", Order = 3)]
		public int? EndUseDate { get; set; }

		/// <summary> �R���X�g���N�^</summary>
		public TanabanMaster()
		{

			TanabanCode = "";
			YakkyokuCode = "";
			TanabanMei = "";
			TanabanComment = "";
			InsertUserId = 0;
			InsertNitiji = null;
			UpdateUserId = 0;
			UpdateNitiji = null;
			UpdateProgramId = "";
			StartUseDate = 0;
			EndUseDate = 0;

		}
	} 
} 
