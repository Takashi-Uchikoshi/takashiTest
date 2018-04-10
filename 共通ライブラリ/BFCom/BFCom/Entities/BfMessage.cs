namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>メッセージテ－ブル</summary>
	[Table("bf_message")]
	public partial class BfMessage
	{ 
		/// <summary>連番</summary>
		[Key]
		[Column("denpyo_bango")]
		public int? DenpyoBango { get; set; }

		/// <summary>登録日</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("insert_date", Order = 0)]
		public DateTime? InsertDate { get; set; }

		/// <summary>発行元識別</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("hakkoumoto_shikibetu", Order = 1)]
		public int? HakkoumotoShikibetu { get; set; }

		/// <summary>発行元薬局コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("yakkyoku_code_from", Order = 2)]
		public string YakkyokuCodeFrom { get; set; }

		/// <summary>発行元名</summary>
		[Column("hakkoumoto_name")]
		public string HakkoumotoName { get; set; }

		/// <summary>受信先薬局コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("yakkyoku_code_to", Order = 3)]
		public string YakkyokuCodeTo { get; set; }

		/// <summary>既読日</summary>
		[Column("kidoku_date")]
		public DateTime? KidokuDate { get; set; }

		/// <summary>メッセージ</summary>
		[Column("message")]
		public string Message { get; set; }

		/// <summary> コンストラクタ</summary>
		public BfMessage()
		{

			DenpyoBango = 0;
			InsertDate = null;
			HakkoumotoShikibetu = 0;
			YakkyokuCodeFrom = "";
			HakkoumotoName = "";
			YakkyokuCodeTo = "";
			KidokuDate = null;
			Message = "";

		}
	} 
} 
