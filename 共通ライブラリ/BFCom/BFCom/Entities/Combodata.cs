namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>コンボボックステーブル</summary>
	[Table("combodata")]
	public partial class Combodata
	{ 
		/// <summary>ﾌﾟﾛｸﾞﾗﾑID</summary>
		[Column("program_id")]
		public string ProgramId { get; set; }

		/// <summary>主キー</summary>
		[Key]
		[Column("seq_no")]
		public int? SeqNo { get; set; }

		/// <summary>項目名称</summary>
		[Column("field_data")]
		public string FieldData { get; set; }

		/// <summary>備考</summary>
		[Column("biko")]
		public string Biko { get; set; }

		/// <summary> コンストラクタ</summary>
		public Combodata()
		{

			ProgramId = "";
			SeqNo = 0;
			FieldData = "";
			Biko = "";

		}
	} 
} 
