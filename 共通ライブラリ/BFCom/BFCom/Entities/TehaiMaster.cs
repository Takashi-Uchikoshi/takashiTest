namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>��z�Ǘ��}�X�^</summary>
	[Table("tehai_master")]
	public partial class TehaiMaster
	{ 
		/// <summary>��ǃR�[�h</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>YJ�R�[�h</summary>
		[Column("yj_code")]
		public string YjCode { get; set; }

		/// <summary>GTIN�R�[�h</summary>
		[Column("gtin_code")]
		public string GtinCode { get; set; }

		/// <summary>JAN�R�[�h</summary>
		[Column("jan_code")]
		public string JanCode { get; set; }

		/// <summary>���׃R�[�h</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("meisai_code", Order = 1)]
		public string MeisaiCode { get; set; }

		/// <summary>�d����R�[�h</summary>
		[Column("shiiresaki_code")]
		public string ShiiresakiCode { get; set; }

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
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("start_use_date", Order = 2)]
		public int? StartUseDate { get; set; }

		/// <summary>�g�p�I��</summary>
		[Column("end_use_date")]
		public int? EndUseDate { get; set; }

		/// <summary>�ʒm����</summary>
		[Column("tsuchi_sikibetsu")]
		public int? TsuchiSikibetsu { get; set; }

		/// <summary>�ʒm����</summary>
		[Column("tsuchi_date")]
		public DateTime? TsuchiDate { get; set; }

		/// <summary>�폜�t���O</summary>
		[Column("sakujyo_flag")]
		public int? SakujyoFlag { get; set; }

		/// <summary> �R���X�g���N�^</summary>
		public TehaiMaster()
		{

			YakkyokuCode = "";
			YjCode = "";
			GtinCode = "";
			JanCode = "";
			MeisaiCode = "";
			ShiiresakiCode = "";
			Price = 0;
			InsertDate = null;
			UpdateDate = null;
			StartUseDate = 0;
			EndUseDate = 0;
			TsuchiSikibetsu = 0;
			TsuchiDate = null;
			SakujyoFlag = 0;

		}
	} 
} 
