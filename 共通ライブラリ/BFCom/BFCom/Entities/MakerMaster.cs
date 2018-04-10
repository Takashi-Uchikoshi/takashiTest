namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>メーカーマスタ</summary>
	[Table("maker_master")]
	public partial class MakerMaster
	{ 
		/// <summary>メーカーコード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("maker_code", Order = 0)]
		public string MakerCode { get; set; }

		/// <summary>メーカー名</summary>
		[Column("maker_name")]
		public string MakerName { get; set; }

		/// <summary>メーカー名（カナ）</summary>
		[Column("maker_kana")]
		public string MakerKana { get; set; }

		/// <summary>統合コード</summary>
		[Column("tougou_code")]
		public string TougouCode { get; set; }

		/// <summary> コンストラクタ</summary>
		public MakerMaster()
		{

			MakerCode = "";
			MakerName = "";
			MakerKana = "";
			TougouCode = "";

		}
	} 
} 
