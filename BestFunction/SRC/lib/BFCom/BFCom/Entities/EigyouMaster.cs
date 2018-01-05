namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>営業日情報マスタ</summary>
	[Table("eigyou_master")]
	public partial class EigyouMaster
	{ 
		/// <summary>薬局コード</summary>
		[Key]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>営業日</summary>
		[Key]
		[Column("EIGYOU_YMD", Order = 1)]
		public DateTime? EIGYOUYMD { get; set; }

		/// <summary>区分</summary>
		[Column("KUBUN")]
		public int? KUBUN { get; set; }

		/// <summary> コンストラクタ</summary>
		public EigyouMaster()
		{

			YakkyokuCode = "";
			EIGYOUYMD = null;
			KUBUN = 0;

		}
	} 
} 
