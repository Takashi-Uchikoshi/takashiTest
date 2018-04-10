namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>ユーザアカウント</summary>
	[Table("user_account")]
	public partial class UserAccount
	{ 
		/// <summary>ユーザID</summary>
		[Key]
		[Column("user_id")]
		public int UserId { get; set; }

		/// <summary>パスワード</summary>
		[Column("password")]
		public string Password { get; set; }

		/// <summary>PDS_ID</summary>
		[Column("pds_id")]
		public string PdsId { get; set; }

		/// <summary>Eメールアドレス</summary>
		[Column("mail_address")]
		public string MailAddress { get; set; }

		/// <summary>薬局コード</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>権限</summary>
		[Column("kengen")]
		public string Kengen { get; set; }

		/// <summary>アカウントランク</summary>
		[Column("account_rank")]
		public string AccountRank { get; set; }

		/// <summary>アカウント区分</summary>
		[Column("account_kubun")]
		public string AccountKubun { get; set; }

		/// <summary>アカウント削除フラグ</summary>
		[Column("account_sakujo_flag")]
		public string AccountSakujoFlag { get; set; }

		/// <summary>アカウント停止フラグ</summary>
		[Column("account_teishi_flag")]
		public string AccountTeishiFlag { get; set; }

		/// <summary>運営コメント</summary>
		[Column("unei_comment")]
		public string UneiComment { get; set; }

		/// <summary>契約年月日</summary>
		[Column("keiyaku_ymd")]
		public string KeiyakuYmd { get; set; }

		/// <summary>解除年月日</summary>
		[Column("kaijo_ymd")]
		public string KaijoYmd { get; set; }

		/// <summary>登録者ID</summary>
		[Column("insert_user_id")]
		public int? InsertUserId { get; set; }

		/// <summary>登録日時</summary>
		[Column("insert_nitiji")]
		public DateTime? InsertNitiji { get; set; }

		/// <summary>更新者ID</summary>
		[Column("update_user_id")]
		public int? UpdateUserId { get; set; }

		/// <summary>更新日時</summary>
		[Column("update_nitiji")]
		public DateTime? UpdateNitiji { get; set; }

		/// <summary>更新プログラムID</summary>
		[Column("update_program_id")]
		public string UpdateProgramId { get; set; }

		/// <summary> コンストラクタ</summary>
		public UserAccount()
		{

			UserId = 0;
			Password = "";
			PdsId = "";
			MailAddress = "";
			YakkyokuCode = "";
			Kengen = "";
			AccountRank = "";
			AccountKubun = "";
			AccountSakujoFlag = "";
			AccountTeishiFlag = "";
			UneiComment = "";
			KeiyakuYmd = "";
			KaijoYmd = "";
			InsertUserId = 0;
			InsertNitiji = null;
			UpdateUserId = 0;
			UpdateNitiji = null;
			UpdateProgramId = "";

		}
	} 
} 
