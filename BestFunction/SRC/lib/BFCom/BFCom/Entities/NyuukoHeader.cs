namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>入庫データヘッダー</summary>
	[Table("nyuuko_header")]
	public partial class NyuukoHeader
	{ 
		/// <summary>薬局コード</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>伝票番号</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("order_no")]
		public int? OrderNo { get; set; }

		/// <summary>明細数</summary>
		[Column("details_count")]
		public int? DetailsCount { get; set; }

		/// <summary>伝票区分</summary>
		[Column("order_kubun")]
		public int? OrderKubun { get; set; }

		/// <summary>処理日</summary>
		[Column("action_date")]
		public DateTime? ActionDate { get; set; }

		/// <summary>仕入先ｺｰﾄﾞ</summary>
		[Column("torihikisaki_cd")]
		public string TorihikisakiCd { get; set; }

		/// <summary>卸コード</summary>
		[Column("oroshi_cd")]
		public string OroshiCd { get; set; }

		/// <summary>消費税額算出区分</summary>
		[Column("tax_kubun")]
		public int? TaxKubun { get; set; }

		/// <summary>金額</summary>
		[Column("amount")]
		public decimal? Amount { get; set; }

		/// <summary>消費税額</summary>
		[Column("tax_amount")]
		public decimal? TaxAmount { get; set; }

		/// <summary>合計金額</summary>
		[Column("total_amount")]
		public decimal? TotalAmount { get; set; }

		/// <summary>印刷区分</summary>
		[Column("print_kubun")]
		public int? PrintKubun { get; set; }

		/// <summary>印刷日時</summary>
		[Column("print_nitiji")]
		public DateTime? PrintNitiji { get; set; }

		/// <summary>送信区分</summary>
		[Column("sousin_kubun")]
		public int? SousinKubun { get; set; }

		/// <summary>送信日時</summary>
		[Column("sousin_nitiji")]
		public DateTime? SousinNitiji { get; set; }

		/// <summary>備考</summary>
		[Column("biko")]
		public string Biko { get; set; }

		/// <summary>発注伝票番号</summary>
		[Column("h_order_no")]
		public int? HOrderNo { get; set; }

		/// <summary>登録日時</summary>
		[Column("insert_nitiji")]
		public DateTime? InsertNitiji { get; set; }

		/// <summary>通知識別</summary>
		[Column("tsuuchi_sikibetu")]
		public int? TsuuchiSikibetu { get; set; }

		/// <summary>通知日時</summary>
		[Column("tsuuchi_date")]
		public DateTime? TsuuchiDate { get; set; }

		/// <summary> コンストラクタ</summary>
		public NyuukoHeader()
		{

			YakkyokuCode = "";
			OrderNo = 0;
			DetailsCount = 0;
			OrderKubun = 0;
			ActionDate = null;
			TorihikisakiCd = "";
			OroshiCd = "";
			TaxKubun = 0;
			Amount = 0;
			TaxAmount = 0;
			TotalAmount = 0;
			PrintKubun = 0;
			PrintNitiji = null;
			SousinKubun = 0;
			SousinNitiji = null;
			Biko = "";
			HOrderNo = 0;
			InsertNitiji = null;
			TsuuchiSikibetu = 0;
			TsuuchiDate = null;

		}
	} 
} 
