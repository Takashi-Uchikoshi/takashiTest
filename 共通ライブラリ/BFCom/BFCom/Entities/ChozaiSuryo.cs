namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>���ܐ�</summary>
	[Table("chozai_suryo")]
	public partial class ChozaiSuryo
	{ 
		/// <summary>��ǃR�[�h</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>YJ�R�[�h</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("yj_code", Order = 1)]
		public string YjCode { get; set; }

		/// <summary>GTIN�R�[�h</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("gtin_code", Order = 2)]
		public string GtinCode { get; set; }

		/// <summary>JAN�R�[�h</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("jan_code", Order = 3)]
		public string JanCode { get; set; }

		/// <summary>�\�����ܐ�</summary>
		[Column("yosoku_chozai_suryo")]
		public decimal? YosokuChozaiSuryo { get; set; }

		/// <summary>�����ϒ��ܐ�</summary>
		[Column("tsuki_heikin_chozai_suryo")]
		public decimal? TsukiHeikinChozaiSuryo { get; set; }

		/// <summary>���Ǘ\��̒��ܐ�</summary>
		[Column("raikyokuyotei_chozai_suryo")]
		public decimal? RaikyokuyoteiChozaiSuryo { get; set; }

		/// <summary>�o�^��</summary>
		[Column("insert_date")]
		public DateTime? InsertDate { get; set; }

		/// <summary>�X�V��</summary>
		[Column("update_date")]
		public DateTime? UpdateDate { get; set; }

		/// <summary>�ʒm����</summary>
		[Column("tsuchi_sikibetsu")]
		public int? TsuchiSikibetsu { get; set; }

		/// <summary>�ʒm����</summary>
		[Column("tsuchi_date")]
		public DateTime? TsuchiDate { get; set; }

		/// <summary> �R���X�g���N�^</summary>
		public ChozaiSuryo()
		{

			YakkyokuCode = "";
			YjCode = "";
			GtinCode = "";
			JanCode = "";
			YosokuChozaiSuryo = 0;
			TsukiHeikinChozaiSuryo = 0;
			RaikyokuyoteiChozaiSuryo = 0;
			InsertDate = null;
			UpdateDate = null;
			TsuchiSikibetsu = 0;
			TsuchiDate = null;

		}
	} 
} 
