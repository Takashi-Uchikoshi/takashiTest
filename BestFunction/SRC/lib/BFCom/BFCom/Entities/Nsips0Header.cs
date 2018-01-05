namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>NSIPSヘッダ部テーブル</summary>
	[Table("nsips0_header")]
	public partial class Nsips0Header
	{ 
		/// <summary>キー</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("nsips0_header_id")]
		public int? Nsips0HeaderId { get; set; }

		/// <summary>取込日時</summary>
		[Column("indate")]
		public int? Indate { get; set; }

		/// <summary>取込連番</summary>
		[Column("inseq")]
		public int? Inseq { get; set; }

		/// <summary>ファイル更新区分</summary>
		[Column("fupdkbn")]
		public string Fupdkbn { get; set; }

		/// <summary>バージョン情報</summary>
		[Column("version")]
		public string Version { get; set; }

		/// <summary>送信日時</summary>
		[Column("soshin_nitiji")]
		public DateTime? SoshinNitiji { get; set; }

		/// <summary>備考</summary>
		[Column("biko")]
		public string Biko { get; set; }

		/// <summary>送信端末識別情報</summary>
		[Column("soshin_tanmatsu_shikibetsujyoho")]
		public string SoshinTanmatsuShikibetsujyoho { get; set; }

		/// <summary>都道府県番号</summary>
		[Column("todofuken_bango")]
		public string TodofukenBango { get; set; }

		/// <summary>点数表</summary>
		[Column("tensuhyo")]
		public int? Tensuhyo { get; set; }

		/// <summary>薬局コード</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>薬局名</summary>
		[Column("yakkyoku_mei")]
		public string YakkyokuMei { get; set; }

		/// <summary>郵便番号</summary>
		[Column("yubinbango")]
		public string Yubinbango { get; set; }

		/// <summary>薬局所在地</summary>
		[Column("yakkyoku_shozaiti")]
		public string YakkyokuShozaiti { get; set; }

		/// <summary>薬局電話番号</summary>
		[Column("yakkyoku_denwabango")]
		public string YakkyokuDenwabango { get; set; }

		/// <summary>旧ファイル名</summary>
		[Column("kyu_file_mei")]
		public string KyuFileMei { get; set; }

		/// <summary>ファイル名</summary>
		[Column("file_mei")]
		public string FileMei { get; set; }

		/// <summary>PDS有効コード</summary>
		[Column("yakkyoku_code_pds")]
		public string YakkyokuCodePds { get; set; }

		/// <summary>有効区分</summary>
		[Column("yuko_flag")]
		public string YukoFlag { get; set; }

		/// <summary>登録日時</summary>
		[Column("insert_nitiji")]
		public DateTime? InsertNitiji { get; set; }

		/// <summary>登録者</summary>
		[Column("insert_user_id")]
		public string InsertUserId { get; set; }

		/// <summary>登録端末名</summary>
		[Column("insert_tanmatsu_id")]
		public string InsertTanmatsuId { get; set; }

		/// <summary>登録プログラム</summary>
		[Column("insert_program")]
		public string InsertProgram { get; set; }

		/// <summary>更新日時</summary>
		[Column("update_nitiji")]
		public DateTime? UpdateNitiji { get; set; }

		/// <summary>更新者</summary>
		[Column("update_user_id")]
		public string UpdateUserId { get; set; }

		/// <summary>更新端末名</summary>
		[Column("update_tanmatsu_id")]
		public string UpdateTanmatsuId { get; set; }

		/// <summary>更新プログラム</summary>
		[Column("update_program")]
		public string UpdateProgram { get; set; }

		/// <summary>通知識別</summary>
		[Column("tsuuchi_sikibetu")]
		public int? TsuuchiSikibetu { get; set; }

		/// <summary>通知日時</summary>
		[Column("tsuuchi_date")]
		public DateTime? TsuuchiDate { get; set; }

		/// <summary>PickedID</summary>
		[Column("picked_id")]
		public int? PickedId { get; set; }

		/// <summary>伝票番号</summary>
		[Column("order_no")]
		public int? OrderNo { get; set; }

		/// <summary> コンストラクタ</summary>
		public Nsips0Header()
		{

			Nsips0HeaderId = 0;
			Indate = 0;
			Inseq = 0;
			Fupdkbn = "";
			Version = "";
			SoshinNitiji = null;
			Biko = "";
			SoshinTanmatsuShikibetsujyoho = "";
			TodofukenBango = "";
			Tensuhyo = 0;
			YakkyokuCode = "";
			YakkyokuMei = "";
			Yubinbango = "";
			YakkyokuShozaiti = "";
			YakkyokuDenwabango = "";
			KyuFileMei = "";
			FileMei = "";
			YakkyokuCodePds = "";
			YukoFlag = "";
			InsertNitiji = null;
			InsertUserId = "";
			InsertTanmatsuId = "";
			InsertProgram = "";
			UpdateNitiji = null;
			UpdateUserId = "";
			UpdateTanmatsuId = "";
			UpdateProgram = "";
			TsuuchiSikibetu = 0;
			TsuuchiDate = null;
			PickedId = 0;
			OrderNo = 0;

		}
	} 
} 
