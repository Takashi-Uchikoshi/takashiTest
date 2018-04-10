namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>���Ǘ\��</summary>
	[Table("raikyoku_yotei")]
	public partial class RaikyokuYotei
	{ 
		/// <summary>���Ǘ\��ID</summary>
		[Key]
		[Column("raikyoku_yotei_id")]
		public int? RaikyokuYoteiId { get; set; }

		/// <summary>��ǃR�[�h</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>����ID</summary>
		[Column("kanjya_id")]
		public string KanjyaId { get; set; }

		/// <summary>YJ�R�[�h</summary>
		[Column("yj_code")]
		public string YjCode { get; set; }

		/// <summary>GTIN�R�[�h</summary>
		[Column("gtin_code")]
		public string GtinCode { get; set; }

		/// <summary>JAN�R�[�h</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("jan_code", Order = 0)]
		public string JanCode { get; set; }

		/// <summary>��i����</summary>
		[Column("YakuhinSuryo")]
		public decimal? YakuhinSuryo { get; set; }

		/// <summary>���ѓ���</summary>
		[Column("jisseki_nitiji")]
		public DateTime? JissekiNitiji { get; set; }

		/// <summary>�\�����</summary>
		[Column("yotei_nitiji")]
		public DateTime? YoteiNitiji { get; set; }

		/// <summary>�\�蕪��</summary>
		[Column("yotei_bunrui")]
		public int? YoteiBunrui { get; set; }

		/// <summary>�X�V����</summary>
		[Column("update_nitiji")]
		public DateTime? UpdateNitiji { get; set; }

		/// <summary> �R���X�g���N�^</summary>
		public RaikyokuYotei()
		{

			RaikyokuYoteiId = 0;
			YakkyokuCode = "";
			KanjyaId = "";
			YjCode = "";
			GtinCode = "";
			JanCode = "";
			YakuhinSuryo = 0;
			JissekiNitiji = null;
			YoteiNitiji = null;
			YoteiBunrui = 0;
			UpdateNitiji = null;

		}
	} 
} 
