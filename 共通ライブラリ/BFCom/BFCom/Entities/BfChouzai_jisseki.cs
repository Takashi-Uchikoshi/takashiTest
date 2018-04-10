namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>BF調剤実績数テーブル</summary>
	[Table("bf_chouzai_jisseki")]
	public partial class BfChouzai_jisseki
	{ 
		/// <summary>薬局コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>商品コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("gtin_code", Order = 1)]
		public string GtinCode { get; set; }

		/// <summary>調剤日</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("cymd", Order = 2)]
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
			GtinCode = "";
			Cymd = null;
			Cnt = 0;
			UsedSu = 0;

		}
	} 
} 
