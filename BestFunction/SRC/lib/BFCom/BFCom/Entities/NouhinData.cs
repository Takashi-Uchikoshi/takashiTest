namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>�[�i�f�[�^</summary>
	[Table("nouhin_data")]
	public partial class NouhinData
	{ 
		/// <summary>��ǃR�[�h</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>���R�[�h�敪</summary>
		[Column("record_kbn")]
		public string RecordKbn { get; set; }

		/// <summary>�f�[�^����</summary>
		[Column("data_class")]
		public string DataClass { get; set; }

		/// <summary>���M�����R�[�h</summary>
		[Key]
		[Column("oroshi_cd", Order = 0)]
		public string OroshiCd { get; set; }

		/// <summary>���M���Ë@�փR�[�h</summary>
		[Key]
		[Column("iryokikan_cd", Order = 1)]
		public string IryokikanCd { get; set; }

		/// <summary>�����M���Ë@�փR�[�h</summary>
		[Key]
		[Column("sub_iryokikan_cd", Order = 2)]
		public string SubIryokikanCd { get; set; }

		/// <summary>�`�[�敪</summary>
		[Key]
		[Column("slip_kbn", Order = 3)]
		public int? SlipKbn { get; set; }

		/// <summary>�`�[���t</summary>
		[Key]
		[Column("slip_date", Order = 4)]
		public DateTime? SlipDate { get; set; }

		/// <summary>�`�[�ԍ�</summary>
		[Key]
		[Column("slip_number", Order = 5)]
		public string SlipNumber { get; set; }

		/// <summary>�`�[�s�ԍ�</summary>
		[Key]
		[Column("slip_line_number", Order = 6)]
		public int? SlipLineNumber { get; set; }

		/// <summary>���i�R�[�h�敪</summary>
		[Column("medicine_cd_kbn")]
		public int? MedicineCdKbn { get; set; }

		/// <summary>���i�R�[�h</summary>
		[Column("jan_cd")]
		public string JanCd { get; set; }

		/// <summary>GTIN���i�R�[�h</summary>
		[Column("gtin_cd")]
		public string GtinCd { get; set; }

		/// <summary>���i��</summary>
		[Column("name_alpha")]
		public string NameAlpha { get; set; }

		/// <summary>����</summary>
		[Column("suryo")]
		public decimal? Suryo { get; set; }

		/// <summary>�P��</summary>
		[Column("tanka")]
		public decimal? Tanka { get; set; }

		/// <summary>���z</summary>
		[Column("kingaku")]
		public decimal? Kingaku { get; set; }

		/// <summary>��</summary>
		[Column("yakka")]
		public decimal? Yakka { get; set; }

		/// <summary>�L������</summary>
		[Column("siyou_ymd")]
		public DateTime? SiyouYmd { get; set; }

		/// <summary>�����ԍ�</summary>
		[Column("lot")]
		public string Lot { get; set; }

		/// <summary>�Œ荀��</summary>
		[Column("filler1")]
		public string Filler1 { get; set; }

		/// <summary>�o�^����</summary>
		[Column("insert_date")]
		public DateTime? InsertDate { get; set; }

		/// <summary>�t�@�C����</summary>
		[Column("file_name")]
		public string FileName { get; set; }

		/// <summary>���Ƀt���O</summary>
		[Column("nyuuko_flg")]
		public int? NyuukoFlg { get; set; }

		/// <summary> �R���X�g���N�^</summary>
		public NouhinData()
		{

			YakkyokuCode = "";
			RecordKbn = "";
			DataClass = "";
			OroshiCd = "";
			IryokikanCd = "";
			SubIryokikanCd = "";
			SlipKbn = 0;
			SlipDate = null;
			SlipNumber = "";
			SlipLineNumber = 0;
			MedicineCdKbn = 0;
			JanCd = "";
			GtinCd = "";
			NameAlpha = "";
			Suryo = 0;
			Tanka = 0;
			Kingaku = 0;
			Yakka = 0;
			SiyouYmd = null;
			Lot = "";
			Filler1 = "";
			InsertDate = null;
			FileName = "";
			NyuukoFlg = 0;

		}
	} 
} 
