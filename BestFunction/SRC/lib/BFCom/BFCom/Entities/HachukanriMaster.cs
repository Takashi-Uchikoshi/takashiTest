namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>�����Ǘ����}�X�^</summary>
	[Table("hachukanri_master")]
	public partial class HachukanriMaster
	{ 
		/// <summary>��ǃR�[�h</summary>
		[Key]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>YJ�R�[�h</summary>
		[Key]
		[Column("yj_code", Order = 1)]
		public string YjCode { get; set; }

		/// <summary>GTIN�R�[�h</summary>
		[Key]
		[Column("gtin_code", Order = 2)]
		public string GtinCode { get; set; }

		/// <summary>JAN�R�[�h</summary>
		[Key]
		[Column("jan_code", Order = 3)]
		public string JanCode { get; set; }

		/// <summary>�������敪</summary>
		[Column("hachukoho_kubun")]
		public int? HachukohoKubun { get; set; }

		/// <summary>�����_</summary>
		[Column("hachuten_suryo")]
		public decimal? HachutenSuryo { get; set; }

		/// <summary>���S�݌ɐ���</summary>
		[Column("anzenzaiko_suryo")]
		public decimal? AnzenzaikoSuryo { get; set; }

		/// <summary>���Ǘ\�蕪</summary>
		[Column("raikyokubun")]
		public int? Raikyokubun { get; set; }

		/// <summary>���[�h�^�C������</summary>
		[Column("leadtime")]
		public int? Leadtime { get; set; }

		/// <summary>�\���ő咲�ܐ��̏搔</summary>
		[Column("yosoku_jyousu")]
		public decimal? YosokuJyousu { get; set; }

		/// <summary>�o���ƃq�[�g�����Z����</summary>
		[Column("barahito_gassan")]
		public int? BarahitoGassan { get; set; }

		/// <summary>�g�p�J�n</summary>
		[Key]
		[Column("start_use_date", Order = 4)]
		public int? StartUseDate { get; set; }

		/// <summary>�g�p�I��</summary>
		[Key]
		[Column("end_use_date", Order = 5)]
		public int? EndUseDate { get; set; }

		/// <summary>�ʒm����</summary>
		[Column("tsuuchi_sikibetu")]
		public int? TsuuchiSikibetu { get; set; }

		/// <summary>�ʒm����</summary>
		[Column("tsuuchi_date")]
		public DateTime? TsuuchiDate { get; set; }

		/// <summary> �R���X�g���N�^</summary>
		public HachukanriMaster()
		{

			YakkyokuCode = "";
			YjCode = "";
			GtinCode = "";
			JanCode = "";
			HachukohoKubun = 0;
			HachutenSuryo = 0;
			AnzenzaikoSuryo = 0;
			Raikyokubun = 0;
			Leadtime = 0;
			YosokuJyousu = 0;
			BarahitoGassan = 0;
			StartUseDate = 0;
			EndUseDate = 0;
			TsuuchiSikibetu = 0;
			TsuuchiDate = null;

		}
	} 
} 
