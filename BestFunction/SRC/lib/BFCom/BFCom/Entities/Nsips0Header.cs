namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>NSIPS�w�b�_���e�[�u��</summary>
	[Table("nsips0_header")]
	public partial class Nsips0Header
	{ 
		/// <summary>�L�[</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
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

		/// <summary>�o�[�W�������</summary>
		[Column("version")]
		public string Version { get; set; }

		/// <summary>���M����</summary>
		[Column("soshin_nitiji")]
		public DateTime? SoshinNitiji { get; set; }

		/// <summary>���l</summary>
		[Column("biko")]
		public string Biko { get; set; }

		/// <summary>���M�[�����ʏ��</summary>
		[Column("soshin_tanmatsu_shikibetsujyoho")]
		public string SoshinTanmatsuShikibetsujyoho { get; set; }

		/// <summary>�s���{���ԍ�</summary>
		[Column("todofuken_bango")]
		public string TodofukenBango { get; set; }

		/// <summary>�_���\</summary>
		[Column("tensuhyo")]
		public int? Tensuhyo { get; set; }

		/// <summary>��ǃR�[�h</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>��ǖ�</summary>
		[Column("yakkyoku_mei")]
		public string YakkyokuMei { get; set; }

		/// <summary>�X�֔ԍ�</summary>
		[Column("yubinbango")]
		public string Yubinbango { get; set; }

		/// <summary>��Ǐ��ݒn</summary>
		[Column("yakkyoku_shozaiti")]
		public string YakkyokuShozaiti { get; set; }

		/// <summary>��Ǔd�b�ԍ�</summary>
		[Column("yakkyoku_denwabango")]
		public string YakkyokuDenwabango { get; set; }

		/// <summary>���t�@�C����</summary>
		[Column("kyu_file_mei")]
		public string KyuFileMei { get; set; }

		/// <summary>�t�@�C����</summary>
		[Column("file_mei")]
		public string FileMei { get; set; }

		/// <summary>PDS�L���R�[�h</summary>
		[Column("yakkyoku_code_pds")]
		public string YakkyokuCodePds { get; set; }

		/// <summary>�L���敪</summary>
		[Column("yuko_flag")]
		public string YukoFlag { get; set; }

		/// <summary>�o�^����</summary>
		[Column("insert_nitiji")]
		public DateTime? InsertNitiji { get; set; }

		/// <summary>�o�^��</summary>
		[Column("insert_user_id")]
		public string InsertUserId { get; set; }

		/// <summary>�o�^�[����</summary>
		[Column("insert_tanmatsu_id")]
		public string InsertTanmatsuId { get; set; }

		/// <summary>�o�^�v���O����</summary>
		[Column("insert_program")]
		public string InsertProgram { get; set; }

		/// <summary>�X�V����</summary>
		[Column("update_nitiji")]
		public DateTime? UpdateNitiji { get; set; }

		/// <summary>�X�V��</summary>
		[Column("update_user_id")]
		public string UpdateUserId { get; set; }

		/// <summary>�X�V�[����</summary>
		[Column("update_tanmatsu_id")]
		public string UpdateTanmatsuId { get; set; }

		/// <summary>�X�V�v���O����</summary>
		[Column("update_program")]
		public string UpdateProgram { get; set; }

		/// <summary>�ʒm����</summary>
		[Column("tsuuchi_sikibetu")]
		public int? TsuuchiSikibetu { get; set; }

		/// <summary>�ʒm����</summary>
		[Column("tsuuchi_date")]
		public DateTime? TsuuchiDate { get; set; }

		/// <summary>PickedID</summary>
		[Column("picked_id")]
		public int? PickedId { get; set; }

		/// <summary>�`�[�ԍ�</summary>
		[Column("order_no")]
		public int? OrderNo { get; set; }

		/// <summary> �R���X�g���N�^</summary>
		public Nsips0Header()
		{

			Nsips0HeaderId = 0;
			Indate = 0;
			Inseq = 0;
			Fupdkbn = "";
			Version = "";
			SoshinNitiji = null;
			Biko = "";
			SoshinTanmatsuShikibetsujyoho = "";
			TodofukenBango = "";
			Tensuhyo = 0;
			YakkyokuCode = "";
			YakkyokuMei = "";
			Yubinbango = "";
			YakkyokuShozaiti = "";
			YakkyokuDenwabango = "";
			KyuFileMei = "";
			FileMei = "";
			YakkyokuCodePds = "";
			YukoFlag = "";
			InsertNitiji = null;
			InsertUserId = "";
			InsertTanmatsuId = "";
			InsertProgram = "";
			UpdateNitiji = null;
			UpdateUserId = "";
			UpdateTanmatsuId = "";
			UpdateProgram = "";
			TsuuchiSikibetu = 0;
			TsuuchiDate = null;
			PickedId = 0;
			OrderNo = 0;

		}
	} 
} 
