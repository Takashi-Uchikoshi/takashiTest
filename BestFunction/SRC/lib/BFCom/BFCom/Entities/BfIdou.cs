namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>BF�ړ��˗��e�[�u��</summary>
	[Table("bf_idou")]
	public partial class BfIdou
	{ 
		/// <summary>�`�[�ԍ�</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("order_no")]
		public int? OrderNo { get; set; }

		/// <summary>�`�[�敪</summary>
		[Column("denpyou_kbn")]
		public int? DenpyouKbn { get; set; }

		/// <summary>�ړ�����ǃR�[�h</summary>
		[Column("idou_tenpo")]
		public string IdouTenpo { get; set; }

		/// <summary>���׍s</summary>
		[Key]
		[Column("gyo", Order = 0)]
		public int? Gyo { get; set; }

		/// <summary>���o�ɋ敪</summary>
		[Column("in_out_kbn")]
		public int? InOutKbn { get; set; }

		/// <summary>�⍇����</summary>
		[Column("idou_ymd")]
		public DateTime? IdouYmd { get; set; }

		/// <summary>�⍇������</summary>
		[Column("idou_time")]
		public DateTime? IdouTime { get; set; }

		/// <summary>�ړ����ǃR�[�h</summary>
		[Column("moto_saki_tenpo")]
		public string MotoSakiTenpo { get; set; }

		/// <summary>���i�R�[�h</summary>
		[Column("gtin_cd")]
		public string GtinCd { get; set; }

		/// <summary>�ړ���</summary>
		[Column("suryo")]
		public decimal? Suryo { get; set; }

		/// <summary>�d���P��</summary>
		[Column("tanka")]
		public decimal? Tanka { get; set; }

		/// <summary>�ړ����z</summary>
		[Column("kingaku")]
		public decimal? Kingaku { get; set; }

		/// <summary>���M�敪</summary>
		[Column("sousin_kbn")]
		public int? SousinKbn { get; set; }

		/// <summary>�ړ��m�Fؽ�</summary>
		[Column("kakuninhyo_list")]
		public int? KakuninhyoList { get; set; }

		/// <summary>���o�Ƀt���O</summary>
		[Column("nyuusyukko_flg")]
		public int? NyuusyukkoFlg { get; set; }

		/// <summary>���b�gNO</summary>
		[Column("lot")]
		public string Lot { get; set; }

		/// <summary>�g�p����</summary>
		[Column("siyou_ymd")]
		public DateTime? SiyouYmd { get; set; }

		/// <summary>�R�����g</summary>
		[Column("memo")]
		public string Memo { get; set; }

		/// <summary>���i����</summary>
		[Column("syouhin_nm")]
		public string SyouhinNm { get; set; }

		/// <summary>�K�i</summary>
		[Column("kikaku")]
		public string Kikaku { get; set; }

		/// <summary>���F�۔F���</summary>
		[Column("ans_flag")]
		public string AnsFlag { get; set; }

		/// <summary>�񓚓�</summary>
		[Column("ans_date")]
		public DateTime? AnsDate { get; set; }

		/// <summary>�񓚎���</summary>
		[Column("ans_time")]
		public int? AnsTime { get; set; }

		/// <summary>�݌ɐ���</summary>
		[Column("zaiko_suryo")]
		public decimal? ZaikoSuryo { get; set; }

		/// <summary>���ܗ\����</summary>
		[Column("yosoku_suryo")]
		public decimal? YosokuSuryo { get; set; }

		/// <summary>���F��</summary>
		[Column("ok_suryo")]
		public decimal? OkSuryo { get; set; }

		/// <summary>���ǃt���O</summary>
		[Column("kidoku_flag")]
		public int? KidokuFlag { get; set; }

		/// <summary>���Ǔ�</summary>
		[Column("kidoku_date")]
		public DateTime? KidokuDate { get; set; }

		/// <summary>���ǎ���</summary>
		[Column("kidoku_time")]
		public DateTime? KidokuTime { get; set; }

		/// <summary>�˗�����</summary>
		[Column("result")]
		public int? Result { get; set; }

		/// <summary>�[����</summary>
		[Column("nouki_ymd")]
		public DateTime? NoukiYmd { get; set; }

		/// <summary>�[����_�ύX��</summary>
		[Column("nouki_ymd_changed")]
		public DateTime? NoukiYmdChanged { get; set; }

		/// <summary>���ʕύX</summary>
		[Column("suryo_changed")]
		public decimal? SuryoChanged { get; set; }

		/// <summary> �R���X�g���N�^</summary>
		public BfIdou()
		{

			OrderNo = 0;
			DenpyouKbn = 0;
			IdouTenpo = "";
			Gyo = 0;
			InOutKbn = 0;
			IdouYmd = null;
			IdouTime = null;
			MotoSakiTenpo = "";
			GtinCd = "";
			Suryo = 0;
			Tanka = 0;
			Kingaku = 0;
			SousinKbn = 0;
			KakuninhyoList = 0;
			NyuusyukkoFlg = 0;
			Lot = "";
			SiyouYmd = null;
			Memo = "";
			SyouhinNm = "";
			Kikaku = "";
			AnsFlag = "";
			AnsDate = null;
			AnsTime = 0;
			ZaikoSuryo = 0;
			YosokuSuryo = 0;
			OkSuryo = 0;
			KidokuFlag = 0;
			KidokuDate = null;
			KidokuTime = null;
			Result = 0;
			NoukiYmd = null;
			NoukiYmdChanged = null;
			SuryoChanged = 0;

		}
	} 
} 
