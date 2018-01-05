namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>�I������</summary>
	[Table("tanaoroshi_meisai")]
	public partial class TanaoroshiMeisai
	{ 
		/// <summary>�I��ID</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("tanaoroshi_id")]
		public int? TanaoroshiId { get; set; }

		/// <summary>��ǃR�[�h</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>PDS�R�[�h</summary>
		[Key]
		[Column("pds_code", Order = 0)]
		public string PdsCode { get; set; }

		/// <summary>�g�p����</summary>
		[Key]
		[Column("shiyou_kigen", Order = 1)]
		public string ShiyouKigen { get; set; }

		/// <summary>���b�g�ԍ�</summary>
		[Key]
		[Column("lot_no", Order = 2)]
		public string LotNo { get; set; }

		/// <summary>GTIN�R�[�h</summary>
		[Column("gtin_code")]
		public string GtinCode { get; set; }

		/// <summary>�I�ԃR�[�h</summary>
		[Column("tanaban_code")]
		public string TanabanCode { get; set; }

		/// <summary>����</summary>
		[Column("hako_qty")]
		public decimal? HakoQty { get; set; }

		/// <summary>���</summary>
		[Column("housou_qty")]
		public decimal? HousouQty { get; set; }

		/// <summary>�o����</summary>
		[Column("bara_qty")]
		public decimal? BaraQty { get; set; }

		/// <summary>�[����</summary>
		[Column("tanmatsu_mei")]
		public string TanmatsuMei { get; set; }

		/// <summary>�o�^���@</summary>
		[Column("touroku_houhou")]
		public string TourokuHouhou { get; set; }

		/// <summary>�o�^��ID</summary>
		[Column("insert_user_id")]
		public int? InsertUserId { get; set; }

		/// <summary>�o�^����</summary>
		[Key]
		[Column("insert_nitiji", Order = 3)]
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

		/// <summary>�o�^�X�^�b�t��</summary>
		[Column("insert_staff_name")]
		public string InsertStaffName { get; set; }

		/// <summary>�o�^�X�^�b�t��</summary>
		[Column("update_staff_name")]
		public string UpdateStaffName { get; set; }

		/// <summary>���J���t���O</summary>
		[Column("mikaifu_flag")]
		public bool? MikaifuFlag { get; set; }

		/// <summary>�s���t���O</summary>
		[Column("fudo_flag")]
		public bool? FudoFlag { get; set; }

		/// <summary> �R���X�g���N�^</summary>
		public TanaoroshiMeisai()
		{

			TanaoroshiId = 0;
			YakkyokuCode = "";
			PdsCode = "";
			ShiyouKigen = "";
			LotNo = "";
			GtinCode = "";
			TanabanCode = "";
			HakoQty = 0;
			HousouQty = 0;
			BaraQty = 0;
			TanmatsuMei = "";
			TourokuHouhou = "";
			InsertUserId = 0;
			InsertNitiji = null;
			UpdateUserId = 0;
			UpdateNitiji = null;
			UpdateProgramId = "";
			InsertStaffName = "";
			UpdateStaffName = "";
			MikaifuFlag = false;
			FudoFlag = false;

		}
	} 
} 
