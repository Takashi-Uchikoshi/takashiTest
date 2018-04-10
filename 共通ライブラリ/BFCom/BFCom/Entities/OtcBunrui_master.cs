namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>OTC���ރ}�X�^</summary>
	[Table("otc_bunrui_master")]
	public partial class OtcBunrui_master
	{ 
		/// <summary>���ރR�[�h</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("bunrui_code", Order = 0)]
		public int? BunruiCode { get; set; }

		/// <summary>���ޖ���</summary>
		[Column("name")]
		public string Name { get; set; }

		/// <summary>����</summary>
		[Column("setumei")]
		public string Setumei { get; set; }

		/// <summary> �R���X�g���N�^</summary>
		public OtcBunrui_master()
		{

			BunruiCode = 0;
			Name = "";
			Setumei = "";

		}
	} 
} 
