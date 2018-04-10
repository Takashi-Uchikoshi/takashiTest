namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>発注データ明細</summary>
	[Table("hachuu_details")]
	public partial class HachuuDetails
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

		/// <summary>仕入先ｺｰﾄﾞ</summary>
		[Column("torihikisaki_cd")]
		public string TorihikisakiCd { get; set; }

		/// <summary>卸コード</summary>
		[Column("oroshi_cd")]
		public string OroshiCd { get; set; }

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

		/// <summary>発注数</summary>
		[Column("suryo")]
		public int? Suryo { get; set; }

		/// <summary>納品指定日</summary>
		[Column("delivery_date")]
		public DateTime? DeliveryDate { get; set; }

		/// <summary>納品指定場所</summary>
		[Column("delivery_location")]
		public int? DeliveryLocation { get; set; }

		/// <summary>備考</summary>
		[Column("biko")]
		public string Biko { get; set; }

		/// <summary>入庫数</summary>
		[Column("nyuuko_su")]
		public int? NyuukoSu { get; set; }

		/// <summary>残区分</summary>
		[Column("zan_kubun")]
		public int? ZanKubun { get; set; }

		/// <summary>登録日時</summary>
		[Column("insert_nitiji")]
		public DateTime? InsertNitiji { get; set; }

		/// <summary> コンストラクタ</summary>
		public HachuuDetails()
		{

			YakkyokuCode = "";
			OrderNo = 0;
			DetailNo = 0;
			TorihikiKubun = 0;
			ActionDate = null;
			TorihikisakiCd = "";
			OroshiCd = "";
			SyouhinCodeKubun = 0;
			SyouhinCode = "";
			SyouhinName = "";
			TaniKubun = 0;
			Suryo = 0;
			DeliveryDate = null;
			DeliveryLocation = 0;
			Biko = "";
			NyuukoSu = 0;
			ZanKubun = 0;
			InsertNitiji = null;

		}
	} 
} 
