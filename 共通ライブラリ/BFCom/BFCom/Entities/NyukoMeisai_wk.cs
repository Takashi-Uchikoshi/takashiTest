namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>入庫明細ワーク</summary>
	[Table("nyuko_meisai_wk")]
	public partial class NyukoMeisai_wk
	{ 
		/// <summary>薬局コード</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>一意キー</summary>
		[Key]
		[Column("ichi_bango")]
		public int IchiBango { get; set; }

		/// <summary>伝票区分</summary>
		[Column("denpyo_kubun")]
		public int DenpyoKubun { get; set; }

		/// <summary>取引区分</summary>
		[Column("torihiki_kubun")]
		public int? TorihikiKubun { get; set; }

		/// <summary>処理日</summary>
		[Column("shori_date")]
		public DateTime? ShoriDate { get; set; }

		/// <summary>商品コード区分</summary>
		[Column("shohin_code_kubun")]
		public int? ShohinCodeKubun { get; set; }

		/// <summary>商品コード</summary>
		[Column("shohin_code")]
		public string ShohinCode { get; set; }

		/// <summary>商品名、規格、容量</summary>
		[Column("shohin_name_kikaku_yoryo")]
		public string ShohinNameKikakuYoryo { get; set; }

		/// <summary>箱数</summary>
		[Column("hako_suryo")]
		public decimal? HakoSuryo { get; set; }

		/// <summary>包装数</summary>
		[Column("hoso_suryo")]
		public decimal? HosoSuryo { get; set; }

		/// <summary>バラ数</summary>
		[Column("bara_suryo")]
		public decimal? BaraSuryo { get; set; }

		/// <summary>単価</summary>
		[Column("tanka")]
		public decimal? Tanka { get; set; }

		/// <summary>金額</summary>
		[Column("kingaku")]
		public decimal? Kingaku { get; set; }

		/// <summary>薬価</summary>
		[Column("yakka")]
		public decimal? Yakka { get; set; }

		/// <summary>消費税金額</summary>
		[Column("shohizei_kingaku")]
		public decimal? ShohizeiKingaku { get; set; }

		/// <summary>小計金額</summary>
		[Column("shoke_kingaku")]
		public decimal? ShokeKingaku { get; set; }

		/// <summary>使用期限</summary>
		[Column("shiyo_kigen")]
		public string ShiyoKigen { get; set; }

		/// <summary>ロット番号</summary>
		[Column("lot_bango")]
		public string LotBango { get; set; }

		/// <summary>入庫日</summary>
		[Column("nyuko_date")]
		public DateTime? NyukoDate { get; set; }

		/// <summary>入庫場所</summary>
		[Column("nyuko_basho")]
		public int? NyukoBasho { get; set; }

		/// <summary>発注明細番号</summary>
		[Column("hacchu_meisai_bango")]
		public int? HacchuMeisaiBango { get; set; }

		/// <summary>備考</summary>
		[Column("biko")]
		public string Biko { get; set; }

		/// <summary>登録日時</summary>
		[Column("insert_nitiji")]
		public DateTime? InsertNitiji { get; set; }

		/// <summary> コンストラクタ</summary>
		public NyukoMeisai_wk()
		{

			YakkyokuCode = "";
			IchiBango = 0;
			DenpyoKubun = 0;
			TorihikiKubun = 0;
			ShoriDate = null;
			ShohinCodeKubun = 0;
			ShohinCode = "";
			ShohinNameKikakuYoryo = "";
			HakoSuryo = 0;
			HosoSuryo = 0;
			BaraSuryo = 0;
			Tanka = 0;
			Kingaku = 0;
			Yakka = 0;
			ShohizeiKingaku = 0;
			ShokeKingaku = 0;
			ShiyoKigen = "";
			LotBango = "";
			NyukoDate = null;
			NyukoBasho = 0;
			HacchuMeisaiBango = 0;
			Biko = "";
			InsertNitiji = null;

		}
	} 
} 
