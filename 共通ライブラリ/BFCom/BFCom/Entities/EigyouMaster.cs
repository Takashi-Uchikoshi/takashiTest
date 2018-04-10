namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>営業日情報マスタ</summary>
	[Table("eigyou_master")]
	public partial class EigyouMaster
	{ 
		/// <summary>薬局コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>営業日</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("eigyou_ymd", Order = 1)]
		public DateTime? EigyouYmd { get; set; }

		/// <summary>区分</summary>
		[Column("kubun")]
		public int? Kubun { get; set; }

		/// <summary>通知識別</summary>
		[Column("tsuchi_sikibetsu")]
		public int? TsuchiSikibetsu { get; set; }

		/// <summary>通知日時</summary>
		[Column("tsuchi_date")]
		public DateTime? TsuchiDate { get; set; }

		/// <summary>管理属性</summary>
		[Column("kanri_zokusei")]
		public int? KanriZokusei { get; set; }

		/// <summary> コンストラクタ</summary>
		public EigyouMaster()
		{

			YakkyokuCode = "";
			EigyouYmd = null;
			Kubun = 0;
			TsuchiSikibetsu = 0;
			TsuchiDate = null;
			KanriZokusei = 0;

		}
	} 
} 
