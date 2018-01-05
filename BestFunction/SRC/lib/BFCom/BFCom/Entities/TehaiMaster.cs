namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>��z�Ǘ��}�X�^</summary>
	[Table("tehai_master")]
	public partial class TehaiMaster
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

		/// <summary>���׃R�[�h</summary>
		[Column("meisai_code")]
		public string MeisaiCode { get; set; }

		/// <summary>�d���溰��</summary>
		[Column("shiiresaki_cd")]
		public string ShiiresakiCd { get; set; }

		/// <summary>�w����</summary>
		[Column("price")]
		public decimal? Price { get; set; }

		/// <summary>�o�^��</summary>
		[Column("insert_date")]
		public DateTime? InsertDate { get; set; }

		/// <summary>�X�V��</summary>
		[Column("update_date")]
		public DateTime? UpdateDate { get; set; }

		/// <summary>�g�p�J�n</summary>
		[Key]
		[Column("start_use_date", Order = 4)]
		public int? StartUseDate { get; set; }

		/// <summary>�g�p�I��</summary>
		[Key]
		[Column("end_use_date", Order = 5)]
		public int? EndUseDate { get; set; }

		/// <summary> �R���X�g���N�^</summary>
		public TehaiMaster()
		{

			YakkyokuCode = "";
			YjCode = "";
			GtinCode = "";
			JanCode = "";
			MeisaiCode = "";
			ShiiresakiCd = "";
			Price = 0;
			InsertDate = null;
			UpdateDate = null;
			StartUseDate = 0;
			EndUseDate = 0;

		}
	} 
} 
