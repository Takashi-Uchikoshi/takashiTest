namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>ログイン情報</summary>
	[Table("login_info")]
	public partial class LoginInfo
	{ 
		/// <summary>ログインID</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("login_id")]
		public int LoginId { get; set; }

		/// <summary>ユーザーID</summary>
		[Column("user_id")]
		public int? UserId { get; set; }

		/// <summary>ログイン日時</summary>
		[Column("login_nitiji")]
		public DateTime? LoginNitiji { get; set; }

		/// <summary>ログアウト日時</summary>
		[Column("logout_nitiji")]
		public DateTime? LogoutNitiji { get; set; }

		/// <summary>セッションID</summary>
		[Column("session_id")]
		public string SessionId { get; set; }

		/// <summary>セッション日時</summary>
		[Column("session_nitiji")]
		public DateTime? SessionNitiji { get; set; }

		/// <summary>セッションIP</summary>
		[Column("session_ip")]
		public string SessionIp { get; set; }

		/// <summary>セッションドメイン名</summary>
		[Column("session_dns")]
		public string SessionDns { get; set; }

		/// <summary>ユーザーエージェント</summary>
		[Column("user_agent")]
		public string UserAgent { get; set; }

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

		/// <summary>管理属性</summary>
		[Column("kanri_zokusei")]
		public int? KanriZokusei { get; set; }

		/// <summary> コンストラクタ</summary>
		public LoginInfo()
		{

			LoginId = 0;
			UserId = 0;
			LoginNitiji = null;
			LogoutNitiji = null;
			SessionId = "";
			SessionNitiji = null;
			SessionIp = "";
			SessionDns = "";
			UserAgent = "";
			InsertUserId = 0;
			InsertNitiji = null;
			UpdateUserId = 0;
			UpdateNitiji = null;
			UpdateProgramId = "";
			KanriZokusei = 0;

		}
	} 
} 
