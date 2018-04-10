namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>出庫明細</summary>
	[Table("shukko_meisai")]
	public partial class ShukkoMeisai
	{ 
		/// <summary>薬局コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>伝票番号</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("denpyo_bango", Order = 1)]
		public int DenpyoBango { get; set; }

		/// <summary>明細番号</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("meisai_bango", Order = 2)]
		public int MeisaiBango { get; set; }

		/// <summary>取引区分</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("torihiki_kubun", Order = 3)]
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

		/// <summary>出庫日</summary>
		[Column("shukko_date")]
		public DateTime? ShukkoDate { get; set; }

		/// <summary>備考</summary>
		[Column("biko")]
		public string Biko { get; set; }

		/// <summary>登録日時</summary>
		[Column("insert_nitiji")]
		public DateTime? InsertNitiji { get; set; }

		/// <summary> コンストラクタ</summary>
		public ShukkoMeisai()
		{

			YakkyokuCode = "";
			DenpyoBango = 0;
			MeisaiBango = 0;
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
			ShukkoDate = null;
			Biko = "";
			InsertNitiji = null;

		}
	} 
} 
