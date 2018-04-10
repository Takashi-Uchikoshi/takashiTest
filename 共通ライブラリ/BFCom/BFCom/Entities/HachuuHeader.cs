namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>発注データヘッダー</summary>
	[Table("hachuu_header")]
	public partial class HachuuHeader
	{ 
		/// <summary>薬局コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>伝票番号</summary>
		[Key]
        [Column("order_no", Order = 1)]
		public int? OrderNo { get; set; }

		/// <summary>明細数</summary>
		[Column("details_count")]
		public int? DetailsCount { get; set; }

		/// <summary>伝票区分</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("order_kubun", Order = 2)]
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
		[Column("tax_sanshutu_kubun")]
		public int? TaxSanshutuKubun { get; set; }

		/// <summary>消費税区分</summary>
		[Column("zei_kubun")]
		public int? ZeiKubun { get; set; }

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
		public HachuuHeader()
		{

			YakkyokuCode = "";
			OrderNo = 0;
			DetailsCount = 0;
			OrderKubun = 0;
			ActionDate = null;
			TorihikisakiCd = "";
			OroshiCd = "";
			TaxSanshutuKubun = 0;
			ZeiKubun = 0;
			Amount = 0;
			TaxAmount = 0;
			TotalAmount = 0;
			PrintKubun = 0;
			PrintNitiji = null;
			SousinKubun = 0;
			SousinNitiji = null;
			Biko = "";
			InsertNitiji = null;
			TsuuchiSikibetu = 0;
			TsuuchiDate = null;

		}
	} 
} 
