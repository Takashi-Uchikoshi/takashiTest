namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>“üŒÉƒf[ƒ^ƒwƒbƒ_[</summary>
	[Table("nyuuko_header")]
	public partial class NyuukoHeader
	{ 
		/// <summary>–ò‹ÇƒR[ƒh</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>“`•[”Ô†</summary>
		[Key]
		[Column("order_no", Order = 1)]
		public int? OrderNo { get; set; }

		/// <summary>–¾×”</summary>
		[Column("details_count")]
		public int? DetailsCount { get; set; }

		/// <summary>“`•[‹æ•ª</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("order_kubun", Order = 2)]
		public int? OrderKubun { get; set; }

		/// <summary>ˆ—“ú</summary>
		[Column("action_date")]
		public DateTime? ActionDate { get; set; }

		/// <summary>d“üæº°ÄŞ</summary>
		[Column("torihikisaki_cd")]
		public string TorihikisakiCd { get; set; }

		/// <summary>‰µƒR[ƒh</summary>
		[Column("oroshi_cd")]
		public string OroshiCd { get; set; }

		/// <summary>Á”ïÅŠzZo‹æ•ª</summary>
		[Column("tax_sanshutu_kubun")]
		public int? TaxSanshutuKubun { get; set; }

		/// <summary>Á”ïÅ‹æ•ª</summary>
		[Column("zei_kubun")]
		public int? ZeiKubun { get; set; }

		/// <summary>‹àŠz</summary>
		[Column("amount")]
		public decimal? Amount { get; set; }

		/// <summary>Á”ïÅŠz</summary>
		[Column("tax_amount")]
		public decimal? TaxAmount { get; set; }

		/// <summary>‡Œv‹àŠz</summary>
		[Column("total_amount")]
		public decimal? TotalAmount { get; set; }

		/// <summary>ˆóü‹æ•ª</summary>
		[Column("print_kubun")]
		public int? PrintKubun { get; set; }

		/// <summary>ˆóü“ú</summary>
		[Column("print_nitiji")]
		public DateTime? PrintNitiji { get; set; }

		/// <summary>‘—M‹æ•ª</summary>
		[Column("sousin_kubun")]
		public int? SousinKubun { get; set; }

		/// <summary>‘—M“ú</summary>
		[Column("sousin_nitiji")]
		public DateTime? SousinNitiji { get; set; }

		/// <summary>”õl</summary>
		[Column("biko")]
		public string Biko { get; set; }

		/// <summary>”­’“`•[”Ô†</summary>
		[Column("h_order_no")]
		public int? HOrderNo { get; set; }

		/// <summary>“o˜^“ú</summary>
		[Column("insert_nitiji")]
		public DateTime? InsertNitiji { get; set; }

		/// <summary>’Ê’m¯•Ê</summary>
		[Column("tsuuchi_sikibetu")]
		public int? TsuuchiSikibetu { get; set; }

		/// <summary>’Ê’m“ú</summary>
		[Column("tsuuchi_date")]
		public DateTime? TsuuchiDate { get; set; }

		/// <summary> ƒRƒ“ƒXƒgƒ‰ƒNƒ^</summary>
		public NyuukoHeader()
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
			HOrderNo = 0;
			InsertNitiji = null;
			TsuuchiSikibetu = 0;
			TsuuchiDate = null;

		}
	} 
} 
