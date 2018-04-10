namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>店舗マスタ</summary>
	[Table("tenpo_master")]
	public partial class TenpoMaster
	{ 
		/// <summary>薬局コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>店舗番号</summary>
		[Column("tenpo_no")]
		public int? TenpoNo { get; set; }

		/// <summary>店郵便番号</summary>
		[Column("mise_yuubin")]
		public string MiseYuubin { get; set; }

		/// <summary>店舗住所（１）</summary>
		[Column("mise_jyu1")]
		public string MiseJyu1 { get; set; }

		/// <summary>店舗住所（２）</summary>
		[Column("mise_jyu2")]
		public string MiseJyu2 { get; set; }

		/// <summary>店舗名</summary>
		[Column("mise_tenmei")]
		public string MiseTenmei { get; set; }

		/// <summary>店舗名(略称)</summary>
		[Column("mise_tenpomei")]
		public string MiseTenpomei { get; set; }

		/// <summary>店舗電話番号</summary>
		[Column("mise_tel")]
		public string MiseTel { get; set; }

		/// <summary>店舗ＦＡＸ番号</summary>
		[Column("mise_fax")]
		public string MiseFax { get; set; }

		/// <summary>変更日</summary>
		[Column("henkou_ymd")]
		public DateTime? HenkouYmd { get; set; }

		/// <summary>サーバー独立区分</summary>
		[Column("server_kubun")]
		public int? ServerKubun { get; set; }

		/// <summary>MEDZ接続文字列</summary>
		[Column("medz_easyconfig")]
		public string MedzEasyconfig { get; set; }

		/// <summary>PHAR接続文字列</summary>
		[Column("phar_easyconfig")]
		public string PharEasyconfig { get; set; }

		/// <summary>管理属性</summary>
		[Column("kanri_zokusei")]
		public int? KanriZokusei { get; set; }

		/// <summary>消費税率１</summary>
		[Column("syouhi_zeiritu1")]
		public int? SyouhiZeiritu1 { get; set; }

		/// <summary>消費税率２</summary>
		[Column("syouhi_zeiritu2")]
		public int? SyouhiZeiritu2 { get; set; }

		/// <summary>消費税端数区分</summary>
		[Column("syouhizei_hasuu_kubun")]
		public int? SyouhizeiHasuuKubun { get; set; }

		/// <summary>金額端数区分</summary>
		[Column("kingaku_hasuu_kubun")]
		public int? KingakuHasuuKubun { get; set; }

		/// <summary>医療機関コード</summary>
		[Column("iryoukikan_code")]
		public string IryoukikanCode { get; set; }

		/// <summary>仕入先マスタ通知日時</summary>
		[Column("shiire_tuuchi")]
		public DateTime? ShiireTuuchi { get; set; }

		/// <summary>ＯＴＣ商品マスタ通知日時</summary>
		[Column("otc_tuuchi")]
		public DateTime? OtcTuuchi { get; set; }

		/// <summary>使用開始</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("start_use_date", Order = 1)]
		public int? StartUseDate { get; set; }

		/// <summary>使用終了</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("end_use_date", Order = 2)]
		public int? EndUseDate { get; set; }

		/// <summary> コンストラクタ</summary>
		public TenpoMaster()
		{

			YakkyokuCode = "";
			TenpoNo = 0;
			MiseYuubin = "";
			MiseJyu1 = "";
			MiseJyu2 = "";
			MiseTenmei = "";
			MiseTenpomei = "";
			MiseTel = "";
			MiseFax = "";
			HenkouYmd = null;
			ServerKubun = 0;
			MedzEasyconfig = "";
			PharEasyconfig = "";
			KanriZokusei = 0;
			SyouhiZeiritu1 = 0;
			SyouhiZeiritu2 = 0;
			SyouhizeiHasuuKubun = 0;
			KingakuHasuuKubun = 0;
			IryoukikanCode = "";
			ShiireTuuchi = null;
			OtcTuuchi = null;
			StartUseDate = 0;
			EndUseDate = 0;

		}
	} 
} 
