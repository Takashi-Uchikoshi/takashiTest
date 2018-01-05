namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>�J�X�^�}�C�Y���e�[�u��</summary>
	[Table("ini_master")]
	public partial class IniMaster
	{ 
		/// <summary>��ǃR�[�h</summary>
		[Key]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>�v���O������</summary>
		[Key]
		[Column("program", Order = 1)]
		public string Program { get; set; }

		/// <summary>�Z�N�V����</summary>
		[Key]
		[Column("section", Order = 2)]
		public string Section { get; set; }

		/// <summary>�L�[</summary>
		[Column("key")]
		public string Key { get; set; }

		/// <summary>�l</summary>
		[Column("data")]
		public string Data { get; set; }

		/// <summary>���l</summary>
		[Column("biko")]
		public string Biko { get; set; }

		/// <summary>�g�p�J�n</summary>
		[Key]
		[Column("start_use_date", Order = 3)]
		public int? StartUseDate { get; set; }

		/// <summary>�g�p�I��</summary>
		[Key]
		[Column("end_use_date", Order = 4)]
		public int? EndUseDate { get; set; }

		/// <summary> �R���X�g���N�^</summary>
		public IniMaster()
		{

			YakkyokuCode = "";
			Program = "";
			Section = "";
			Key = "";
			Data = "";
			Biko = "";
			StartUseDate = 0;
			EndUseDate = 0;

		}
	} 
} 
