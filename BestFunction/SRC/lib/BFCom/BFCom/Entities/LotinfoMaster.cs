namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>�k�n�s���Ǘ��}�X�^</summary>
	[Table("lotinfo_master")]
	public partial class LotinfoMaster
	{ 
		/// <summary>��ǃR�[�h</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>YJ�R�[�h</summary>
		[Key]
		[Column("yj_code", Order = 0)]
		public string YjCode { get; set; }

		/// <summary>GTIN�R�[�h</summary>
		[Key]
		[Column("gtin_code", Order = 1)]
		public string GtinCode { get; set; }

		/// <summary>JAN�R�[�h</summary>
		[Key]
		[Column("jan_code", Order = 2)]
		public string JanCode { get; set; }

		/// <summary>���ɓ�</summary>
		[Column("nyuuko_date")]
		public DateTime? NyuukoDate { get; set; }

		/// <summary>�g�p����</summary>
		[Column("siyou_ymd")]
		public DateTime? SiyouYmd { get; set; }

		/// <summary>�����ԍ�</summary>
		[Column("lot")]
		public string Lot { get; set; }

		/// <summary>���ɐ�</summary>
		[Column("in_count")]
		public decimal? InCount { get; set; }

		/// <summary>�o�ɐ�</summary>
		[Column("out_count")]
		public decimal? OutCount { get; set; }

		/// <summary>�o�^��</summary>
		[Column("insert_date")]
		public DateTime? InsertDate { get; set; }

		/// <summary>�X�V��</summary>
		[Column("update_date")]
		public DateTime? UpdateDate { get; set; }

		/// <summary>�ʒm����</summary>
		[Column("tsuuchi_sikibetu")]
		public int? TsuuchiSikibetu { get; set; }

		/// <summary>�ʒm����</summary>
		[Column("tsuuchi_date")]
		public DateTime? TsuuchiDate { get; set; }

		/// <summary> �R���X�g���N�^</summary>
		public LotinfoMaster()
		{

			YakkyokuCode = "";
			YjCode = "";
			GtinCode = "";
			JanCode = "";
			NyuukoDate = null;
			SiyouYmd = null;
			Lot = "";
			InCount = 0;
			OutCount = 0;
			InsertDate = null;
			UpdateDate = null;
			TsuuchiSikibetu = 0;
			TsuuchiDate = null;

		}
	} 
} 
