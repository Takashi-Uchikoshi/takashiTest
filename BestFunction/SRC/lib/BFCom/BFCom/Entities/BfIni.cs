namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>BF�h�m�h�e�[�u��</summary>
	[Table("bf_ini")]
	public partial class BfIni
	{ 
		/// <summary>��ǃR�[�h</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>�I�y���[�^�R�[�h</summary>
		[Key]
		[Column("opecd", Order = 0)]
		public string Opecd { get; set; }

		/// <summary>�v���O������</summary>
		[Key]
		[Column("prognm", Order = 1)]
		public string Prognm { get; set; }

		/// <summary>�Z�N�V����</summary>
		[Key]
		[Column("section", Order = 2)]
		public string Section { get; set; }

		/// <summary>�L�[</summary>
		[Key]
		[Column("key1", Order = 3)]
		public string Key1 { get; set; }

		/// <summary>�l</summary>
		[Column("data")]
		public string Data { get; set; }

		/// <summary>���l</summary>
		[Column("biko")]
		public string Biko { get; set; }

		/// <summary> �R���X�g���N�^</summary>
		public BfIni()
		{

			YakkyokuCode = "";
			Opecd = "";
			Prognm = "";
			Section = "";
			Key1 = "";
			Data = "";
			Biko = "";

		}
	} 
} 
