namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>BF移動依頼テーブル</summary>
	[Table("bf_idou")]
	public partial class BfIdou
	{ 
		/// <summary>伝票番号</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("order_no")]
		public int? OrderNo { get; set; }

		/// <summary>伝票区分</summary>
		[Column("denpyou_kbn")]
		public int? DenpyouKbn { get; set; }

		/// <summary>移動元薬局コード</summary>
		[Column("idou_tenpo")]
		public string IdouTenpo { get; set; }

		/// <summary>明細行</summary>
		[Key]
		[Column("gyo", Order = 0)]
		public int? Gyo { get; set; }

		/// <summary>入出庫区分</summary>
		[Column("in_out_kbn")]
		public int? InOutKbn { get; set; }

		/// <summary>問合せ日</summary>
		[Column("idou_ymd")]
		public DateTime? IdouYmd { get; set; }

		/// <summary>問合せ時刻</summary>
		[Column("idou_time")]
		public DateTime? IdouTime { get; set; }

		/// <summary>移動先薬局コード</summary>
		[Column("moto_saki_tenpo")]
		public string MotoSakiTenpo { get; set; }

		/// <summary>商品コード</summary>
		[Column("gtin_cd")]
		public string GtinCd { get; set; }

		/// <summary>移動数</summary>
		[Column("suryo")]
		public decimal? Suryo { get; set; }

		/// <summary>仕入単価</summary>
		[Column("tanka")]
		public decimal? Tanka { get; set; }

		/// <summary>移動金額</summary>
		[Column("kingaku")]
		public decimal? Kingaku { get; set; }

		/// <summary>送信区分</summary>
		[Column("sousin_kbn")]
		public int? SousinKbn { get; set; }

		/// <summary>移動確認ﾘｽﾄ</summary>
		[Column("kakuninhyo_list")]
		public int? KakuninhyoList { get; set; }

		/// <summary>入出庫フラグ</summary>
		[Column("nyuusyukko_flg")]
		public int? NyuusyukkoFlg { get; set; }

		/// <summary>ロットNO</summary>
		[Column("lot")]
		public string Lot { get; set; }

		/// <summary>使用期限</summary>
		[Column("siyou_ymd")]
		public DateTime? SiyouYmd { get; set; }

		/// <summary>コメント</summary>
		[Column("memo")]
		public string Memo { get; set; }

		/// <summary>商品名称</summary>
		[Column("syouhin_nm")]
		public string SyouhinNm { get; set; }

		/// <summary>規格</summary>
		[Column("kikaku")]
		public string Kikaku { get; set; }

		/// <summary>承認否認情報</summary>
		[Column("ans_flag")]
		public string AnsFlag { get; set; }

		/// <summary>回答日</summary>
		[Column("ans_date")]
		public DateTime? AnsDate { get; set; }

		/// <summary>回答時刻</summary>
		[Column("ans_time")]
		public int? AnsTime { get; set; }

		/// <summary>在庫数量</summary>
		[Column("zaiko_suryo")]
		public decimal? ZaikoSuryo { get; set; }

		/// <summary>調剤予測数</summary>
		[Column("yosoku_suryo")]
		public decimal? YosokuSuryo { get; set; }

		/// <summary>承認数</summary>
		[Column("ok_suryo")]
		public decimal? OkSuryo { get; set; }

		/// <summary>既読フラグ</summary>
		[Column("kidoku_flag")]
		public int? KidokuFlag { get; set; }

		/// <summary>既読日</summary>
		[Column("kidoku_date")]
		public DateTime? KidokuDate { get; set; }

		/// <summary>既読時刻</summary>
		[Column("kidoku_time")]
		public DateTime? KidokuTime { get; set; }

		/// <summary>依頼結果</summary>
		[Column("result")]
		public int? Result { get; set; }

		/// <summary>納期日</summary>
		[Column("nouki_ymd")]
		public DateTime? NoukiYmd { get; set; }

		/// <summary>納期日_変更後</summary>
		[Column("nouki_ymd_changed")]
		public DateTime? NoukiYmdChanged { get; set; }

		/// <summary>数量変更</summary>
		[Column("suryo_changed")]
		public decimal? SuryoChanged { get; set; }

		/// <summary> コンストラクタ</summary>
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
