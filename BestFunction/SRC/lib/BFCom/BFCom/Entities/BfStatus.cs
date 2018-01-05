namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>BF状態管理テーブル</summary>
	[Table("bf_status")]
	public partial class BfStatus
	{ 
		/// <summary>薬局コード</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>コンピュータ名</summary>
		[Key]
		[Column("comp_name", Order = 0)]
		public string CompName { get; set; }

		/// <summary>キー</summary>
		[Key]
		[Column("key1", Order = 1)]
		public string Key1 { get; set; }

		/// <summary>値</summary>
		[Column("data")]
		public string Data { get; set; }

		/// <summary> コンストラクタ</summary>
		public BfStatus()
		{

			YakkyokuCode = "";
			CompName = "";
			Key1 = "";
			Data = "";

		}
	} 
} 
