namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>�X�܃}�X�^</summary>
	[Table("tenpo_master")]
	public partial class TenpoMaster
	{ 
		/// <summary>��ǃR�[�h</summary>
		[Key]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>�X�X�֔ԍ�</summary>
		[Column("mise_yuubin")]
		public string MiseYuubin { get; set; }

		/// <summary>�X�܏Z���i�P�j</summary>
		[Column("mise_jyu1")]
		public string MiseJyu1 { get; set; }

		/// <summary>�X�܏Z���i�Q�j</summary>
		[Column("mise_jyu2")]
		public string MiseJyu2 { get; set; }

		/// <summary>�X�ܖ�</summary>
		[Column("mise_tenmei")]
		public string MiseTenmei { get; set; }

		/// <summary>�X�ܖ�(����)</summary>
		[Column("mise_tenpomei")]
		public string MiseTenpomei { get; set; }

		/// <summary>�X�ܓd�b�ԍ�</summary>
		[Column("mise_tel")]
		public string MiseTel { get; set; }

		/// <summary>�X�܂e�`�w�ԍ�</summary>
		[Column("mise_fax")]
		public string MiseFax { get; set; }

		/// <summary>�ύX��</summary>
		[Column("henkou_ymd")]
		public DateTime? HenkouYmd { get; set; }

		/// <summary>�T�[�o�[�Ɨ��敪</summary>
		[Column("server_kbn")]
		public int? ServerKbn { get; set; }

		/// <summary>MEDZ�ڑ�������</summary>
		[Column("medz_easyconfig")]
		public string MedzEasyconfig { get; set; }

		/// <summary>PHAR�ڑ�������</summary>
		[Column("phar_easyconfig")]
		public string PharEasyconfig { get; set; }

		/// <summary>�Ǘ�����</summary>
		[Column("kanri_zokusei")]
		public int? KanriZokusei { get; set; }

		/// <summary> �R���X�g���N�^</summary>
		public TenpoMaster()
		{

			YakkyokuCode = "";
			MiseYuubin = "";
			MiseJyu1 = "";
			MiseJyu2 = "";
			MiseTenmei = "";
			MiseTenpomei = "";
			MiseTel = "";
			MiseFax = "";
			HenkouYmd = null;
			ServerKbn = 0;
			MedzEasyconfig = "";
			PharEasyconfig = "";
			KanriZokusei = 0;

		}
	} 
} 
