namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>NSIPS���Z��񕔃e�[�u��</summary>
	[Table("nsips7_kasan")]
	public partial class Nsips7Kasan
	{ 
		/// <summary>�L�[</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("nsips7_kasan_id")]
		public int? Nsips7KasanId { get; set; }

		/// <summary>�w�b�_�[�̃L�[</summary>
		[Column("nsips0_header_id")]
		public int? Nsips0HeaderId { get; set; }

		/// <summary>�捞����</summary>
		[Column("indate")]
		public int? Indate { get; set; }

		/// <summary>�捞�A��</summary>
		[Column("inseq")]
		public int? Inseq { get; set; }

		/// <summary>�t�@�C���X�V�敪</summary>
		[Column("fupdkbn")]
		public string Fupdkbn { get; set; }

		/// <summary>�t�@�C�������ҘA��</summary>
		[Column("patseq")]
		public int? Patseq { get; set; }

		/// <summary>���ʎq</summary>
		[Column("stype")]
		public int? Stype { get; set; }

		/// <summary>���Z�ԍ�</summary>
		[Column("kasan_bango")]
		public int? KasanBango { get; set; }

		/// <summary>�Z��R�[�h</summary>
		[Column("sante_code")]
		public string SanteCode { get; set; }

		/// <summary>�Z�薼��</summary>
		[Column("sante_meisho")]
		public string SanteMeisho { get; set; }

		/// <summary>��</summary>
		[Column("kaisu")]
		public decimal? Kaisu { get; set; }

		/// <summary>�_��</summary>
		[Column("tensu")]
		public decimal? Tensu { get; set; }

		/// <summary>�L���敪</summary>
		[Column("enable")]
		public int? Enable { get; set; }

		/// <summary> �R���X�g���N�^</summary>
		public Nsips7Kasan()
		{

			Nsips7KasanId = 0;
			Nsips0HeaderId = 0;
			Indate = 0;
			Inseq = 0;
			Fupdkbn = "";
			Patseq = 0;
			Stype = 0;
			KasanBango = 0;
			SanteCode = "";
			SanteMeisho = "";
			Kaisu = 0;
			Tensu = 0;
			Enable = 0;

		}
	} 
} 
