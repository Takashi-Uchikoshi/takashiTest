namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>OTC分類マスタ</summary>
	[Table("otc_bunrui_master")]
	public partial class OtcBunrui_master
	{ 
		/// <summary>分類コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("bunrui_code", Order = 0)]
		public int? BunruiCode { get; set; }

		/// <summary>分類名称</summary>
		[Column("name")]
		public string Name { get; set; }

		/// <summary>説明</summary>
		[Column("setumei")]
		public string Setumei { get; set; }

		/// <summary> コンストラクタ</summary>
		public OtcBunrui_master()
		{

			BunruiCode = 0;
			Name = "";
			Setumei = "";

		}
	} 
} 
