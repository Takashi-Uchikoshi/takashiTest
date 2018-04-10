namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>出庫データ明細</summary>
	[Table("syukko_details")]
	public partial class SyukkoDetails
	{ 
		/// <summary>薬局コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>伝票番号</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("order_no", Order = 1)]
		public int? OrderNo { get; set; }

		/// <summary>明細番号</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("detail_no", Order = 2)]
		public int? DetailNo { get; set; }

		/// <summary>取引区分</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("torihiki_kubun", Order = 3)]
		public int? TorihikiKubun { get; set; }

		/// <summary>処理日</summary>
		[Column("action_date")]
		public DateTime? ActionDate { get; set; }

		/// <summary>得意先ｺｰﾄﾞ</summary>
		[Column("torihikisaki_cd")]
		public string TorihikisakiCd { get; set; }

		/// <summary>商品コード区分</summary>
		[Column("syouhin_code_kubun")]
		public int? SyouhinCodeKubun { get; set; }

		/// <summary>商品コード</summary>
		[Column("syouhin_code")]
		public string SyouhinCode { get; set; }

		/// <summary>品名・規格・容量</summary>
		[Column("syouhin_name")]
		public string SyouhinName { get; set; }

		/// <summary>単位区分</summary>
		[Column("tani_kubun")]
		public int? TaniKubun { get; set; }

		/// <summary>出庫数</summary>
		[Column("suryo")]
		public decimal? Suryo { get; set; }

		/// <summary>単価</summary>
		[Column("tanka")]
		public decimal? Tanka { get; set; }

		/// <summary>金額</summary>
		[Column("kingaku")]
		public decimal? Kingaku { get; set; }

		/// <summary>薬価</summary>
		[Column("yakka")]
		public decimal? Yakka { get; set; }

		/// <summary>消費税額</summary>
		[Column("tax_amount")]
		public decimal? TaxAmount { get; set; }

		/// <summary>小計金額</summary>
		[Column("total_amount")]
		public decimal? TotalAmount { get; set; }

		/// <summary>使用期限</summary>
		[Column("siyou_ymd")]
		public string SiyouYmd { get; set; }

		/// <summary>製造番号</summary>
		[Column("lot")]
		public string Lot { get; set; }

		/// <summary>出庫日</summary>
		[Column("delivery_date")]
		public DateTime? DeliveryDate { get; set; }

		/// <summary>備考</summary>
		[Column("biko")]
		public string Biko { get; set; }

		/// <summary>登録日時</summary>
		[Column("insert_nitiji")]
		public DateTime? InsertNitiji { get; set; }

		/// <summary> コンストラクタ</summary>
		public SyukkoDetails()
		{

			YakkyokuCode = "";
			OrderNo = 0;
			DetailNo = 0;
			TorihikiKubun = 0;
			ActionDate = null;
			TorihikisakiCd = "";
			SyouhinCodeKubun = 0;
			SyouhinCode = "";
			SyouhinName = "";
			TaniKubun = 0;
			Suryo = 0;
			Tanka = 0;
			Kingaku = 0;
			Yakka = 0;
			TaxAmount = 0;
			TotalAmount = 0;
			SiyouYmd = "";
			Lot = "";
			DeliveryDate = null;
			Biko = "";
			InsertNitiji = null;

		}
	} 
} 
