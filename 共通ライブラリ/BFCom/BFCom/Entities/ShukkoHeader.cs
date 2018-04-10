namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>出庫ヘッダ</summary>
	[Table("shukko_header")]
	public partial class ShukkoHeader
	{ 
		/// <summary>薬局コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>伝票番号</summary>
		[Key]
		[Column("denpyo_bango")]
		public int? DenpyoBango { get; set; }

		/// <summary>明細数</summary>
		[Column("meisaisu")]
		public int? Meisaisu { get; set; }

		/// <summary>伝票区分</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("denpyo_kubun", Order = 1)]
		public int? DenpyoKubun { get; set; }

		/// <summary>処理日</summary>
		[Column("shori_date")]
		public DateTime? ShoriDate { get; set; }

		/// <summary>取引先コード</summary>
		[Column("torihikisaki_code")]
		public string TorihikisakiCode { get; set; }

		/// <summary>卸コード</summary>
		[Column("oroshi_code")]
		public string OroshiCode { get; set; }

		/// <summary>消費税算出区分</summary>
		[Column("shohizei_sanshutsu_kubun")]
		public int? ShohizeiSanshutsuKubun { get; set; }

		/// <summary>消費税区分</summary>
		[Column("shohizei_kubun")]
		public int? ShohizeiKubun { get; set; }

		/// <summary>金額</summary>
		[Column("kingaku")]
		public decimal? Kingaku { get; set; }

		/// <summary>消費税金額</summary>
		[Column("shohizei_kingaku")]
		public decimal? ShohizeiKingaku { get; set; }

		/// <summary>合計金額</summary>
		[Column("goke_kingaku")]
		public decimal? GokeKingaku { get; set; }

		/// <summary>プリント区分</summary>
		[Column("print_kubun")]
		public int? PrintKubun { get; set; }

		/// <summary>プリント日時</summary>
		[Column("print_nitiji")]
		public DateTime? PrintNitiji { get; set; }

		/// <summary>送信区分</summary>
		[Column("soshin_kubun")]
		public int? SoshinKubun { get; set; }

		/// <summary>送信日時</summary>
		[Column("soshin_nitiji")]
		public DateTime? SoshinNitiji { get; set; }

		/// <summary>備考</summary>
		[Column("biko")]
		public string Biko { get; set; }

		/// <summary>伝票番号PDS</summary>
		[Column("denpyo_bango_pds")]
		public int? DenpyoBangoPds { get; set; }

		/// <summary>登録日時</summary>
		[Column("insert_nitiji")]
		public DateTime? InsertNitiji { get; set; }

		/// <summary>通知識別</summary>
		[Column("tsuchi_sikibetsu")]
		public int? TsuchiSikibetsu { get; set; }

		/// <summary>通知日時</summary>
		[Column("tsuchi_date")]
		public DateTime? TsuchiDate { get; set; }

		/// <summary> コンストラクタ</summary>
		public ShukkoHeader()
		{

			YakkyokuCode = "";
			DenpyoBango = 0;
			Meisaisu = 0;
			DenpyoKubun = 0;
			ShoriDate = null;
			TorihikisakiCode = "";
			OroshiCode = "";
			ShohizeiSanshutsuKubun = 0;
			ShohizeiKubun = 0;
			Kingaku = 0;
			ShohizeiKingaku = 0;
			GokeKingaku = 0;
			PrintKubun = 0;
			PrintNitiji = null;
			SoshinKubun = 0;
			SoshinNitiji = null;
			Biko = "";
			DenpyoBangoPds = 0;
			InsertNitiji = null;
			TsuchiSikibetsu = 0;
			TsuchiDate = null;

		}
	} 
} 
