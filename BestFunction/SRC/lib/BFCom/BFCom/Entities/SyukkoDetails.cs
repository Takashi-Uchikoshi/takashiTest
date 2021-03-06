namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>oΙf[^ΎΧ</summary>
	[Table("syukko_details")]
	public partial class SyukkoDetails
	{ 
		/// <summary>ςΗR[h</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>`[Τ</summary>
		[Key]
		[Column("order_no", Order = 0)]
		public int? OrderNo { get; set; }

		/// <summary>ΎΧΤ</summary>
		[Key]
		[Column("detail_no", Order = 1)]
		public int? DetailNo { get; set; }

		/// <summary>ζψζͺ</summary>
		[Key]
		[Column("torihiki_kubun", Order = 2)]
		public int? TorihikiKubun { get; set; }

		/// <summary>ϊ</summary>
		[Column("action_date")]
		public DateTime? ActionDate { get; set; }

		/// <summary>ΎΣζΊ°Δή</summary>
		[Column("torihikisaki_cd")]
		public string TorihikisakiCd { get; set; }

		/// <summary>€iR[hζͺ</summary>
		[Column("syouhin_code_kubun")]
		public int? SyouhinCodeKubun { get; set; }

		/// <summary>€iR[h</summary>
		[Column("syouhin_code")]
		public string SyouhinCode { get; set; }

		/// <summary>iΌEKiEeΚ</summary>
		[Column("syouhin_name")]
		public string SyouhinName { get; set; }

		/// <summary>PΚζͺ</summary>
		[Column("tani_kubun")]
		public int? TaniKubun { get; set; }

		/// <summary>oΙ</summary>
		[Column("suryo")]
		public decimal? Suryo { get; set; }

		/// <summary>PΏ</summary>
		[Column("tanka")]
		public decimal? Tanka { get; set; }

		/// <summary>ΰz</summary>
		[Column("kingaku")]
		public decimal? Kingaku { get; set; }

		/// <summary>ςΏ</summary>
		[Column("yakka")]
		public decimal? Yakka { get; set; }

		/// <summary>ΑοΕz</summary>
		[Column("tax_amount")]
		public decimal? TaxAmount { get; set; }

		/// <summary>¬vΰz</summary>
		[Column("total_amount")]
		public decimal? TotalAmount { get; set; }

		/// <summary>gpϊΐ</summary>
		[Column("siyou_ymd")]
		public DateTime? SiyouYmd { get; set; }

		/// <summary>»’Τ</summary>
		[Column("lot")]
		public string Lot { get; set; }

		/// <summary>oΙϊ</summary>
		[Column("delivery_date")]
		public DateTime? DeliveryDate { get; set; }

		/// <summary>υl</summary>
		[Column("biko")]
		public string Biko { get; set; }

		/// <summary>o^ϊ</summary>
		[Column("insert_nitiji")]
		public DateTime? InsertNitiji { get; set; }

		/// <summary> RXgN^</summary>
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
			SiyouYmd = null;
			Lot = "";
			DeliveryDate = null;
			Biko = "";
			InsertNitiji = null;

		}
	} 
} 
