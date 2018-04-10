namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>BFＩＮＩテーブル</summary>
	[Table("bf_ini")]
	public partial class BfIni
	{ 
		/// <summary>薬局コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>オペレータコード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("opecd", Order = 1)]
		public string Opecd { get; set; }

		/// <summary>プログラム名</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("prognm", Order = 2)]
		public string Prognm { get; set; }

		/// <summary>セクション</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("section", Order = 3)]
		public string Section { get; set; }

		/// <summary>キー</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("key1", Order = 4)]
		public string Key1 { get; set; }

		/// <summary>値</summary>
		[Column("data")]
		public string Data { get; set; }

		/// <summary>備考</summary>
		[Column("biko")]
		public string Biko { get; set; }

		/// <summary> コンストラクタ</summary>
		public BfIni()
		{

			YakkyokuCode = "";
			Opecd = "";
			Prognm = "";
			Section = "";
			Key1 = "";
			Data = "";
			Biko = "";

		}
	} 
} 
