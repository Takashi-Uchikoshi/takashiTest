namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>BF調剤実績数テーブル</summary>
	[Table("bf_chouzai_jisseki")]
	public partial class BfChouzai_jisseki
	{ 
		/// <summary>薬局コード</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>商品コード</summary>
		[Column("gtin_cd")]
		public string GtinCd { get; set; }

		/// <summary>調剤日</summary>
		[Key]
		[Column("cymd", Order = 0)]
		public DateTime? Cymd { get; set; }

		/// <summary>調剤回数</summary>
		[Column("cnt")]
		public int? Cnt { get; set; }

		/// <summary>消費量</summary>
		[Column("used_su")]
		public decimal? UsedSu { get; set; }

		/// <summary> コンストラクタ</summary>
		public BfChouzai_jisseki()
		{

			YakkyokuCode = "";
			GtinCd = "";
			Cymd = null;
			Cnt = 0;
			UsedSu = 0;

		}
	} 
} 
