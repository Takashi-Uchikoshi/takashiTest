namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>カスタマイズ情報テーブル</summary>
	[Table("ini_master")]
	public partial class IniMaster
	{ 
		/// <summary>薬局コード</summary>
		[Key]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>プログラム名</summary>
		[Key]
		[Column("program", Order = 1)]
		public string Program { get; set; }

		/// <summary>セクション</summary>
		[Key]
		[Column("section", Order = 2)]
		public string Section { get; set; }

		/// <summary>キー</summary>
		[Column("key")]
		public string Key { get; set; }

		/// <summary>値</summary>
		[Column("data")]
		public string Data { get; set; }

		/// <summary>備考</summary>
		[Column("biko")]
		public string Biko { get; set; }

		/// <summary>使用開始</summary>
		[Key]
		[Column("start_use_date", Order = 3)]
		public int? StartUseDate { get; set; }

		/// <summary>使用終了</summary>
		[Key]
		[Column("end_use_date", Order = 4)]
		public int? EndUseDate { get; set; }

		/// <summary> コンストラクタ</summary>
		public IniMaster()
		{

			YakkyokuCode = "";
			Program = "";
			Section = "";
			Key = "";
			Data = "";
			Biko = "";
			StartUseDate = 0;
			EndUseDate = 0;

		}
	} 
} 
