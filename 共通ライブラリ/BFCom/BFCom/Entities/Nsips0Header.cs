namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>NSIPSヘッダ部テーブル</summary>
	[Table("nsips0_header")]
	public partial class Nsips0Header
	{ 
		/// <summary>Nsips0ヘッダID</summary>
		[Key]
		[Column("nsips0_header_id")]
		public int? Nsips0HeaderId { get; set; }

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

		/// <summary>ファイル更新区分</summary>
		[Column("fupdkbn")]
		public string Fupdkbn { get; set; }

		/// <summary>ファイル名</summary>
		[Column("file_mei")]
		public string FileMei { get; set; }

		/// <summary>有効区分</summary>
		[Column("yuko_flag")]
		public int? YukoFlag { get; set; }

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
		[Column("tsuchi_sikibetsu")]
		public int? TsuchiSikibetsu { get; set; }

		/// <summary>通知日時</summary>
		[Column("tsuchi_date")]
		public DateTime? TsuchiDate { get; set; }

		/// <summary>PickedID</summary>
		[Column("picked_id")]
		public int? PickedId { get; set; }

		/// <summary>伝票番号</summary>
		[Column("denpyo_bango")]
		public int? DenpyoBango { get; set; }

		/// <summary> コンストラクタ</summary>
		public Nsips0Header()
		{

			Nsips0HeaderId = 0;
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
			Fupdkbn = "";
			FileMei = "";
			YukoFlag = 0;
			InsertNitiji = null;
			InsertUserId = "";
			InsertTanmatsuId = "";
			InsertProgram = "";
			UpdateNitiji = null;
			UpdateUserId = "";
			UpdateTanmatsuId = "";
			UpdateProgram = "";
			TsuchiSikibetsu = 0;
			TsuchiDate = null;
			PickedId = 0;
			DenpyoBango = 0;

		}
	} 
} 
