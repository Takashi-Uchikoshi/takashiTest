namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>仕入先マスタ</summary>
	[Table("shiiresaki_master")]
	public partial class ShiiresakiMaster
	{ 
		/// <summary>仕入先コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("shiiresaki_code", Order = 0)]
		public string ShiiresakiCode { get; set; }

		/// <summary>郵便番号</summary>
		[Column("yuubin")]
		public string Yuubin { get; set; }

		/// <summary>住所（１）</summary>
		[Column("jyu1")]
		public string Jyu1 { get; set; }

		/// <summary>住所（２）</summary>
		[Column("jyu2")]
		public string Jyu2 { get; set; }

		/// <summary>仕入先名</summary>
		[Column("name")]
		public string Name { get; set; }

		/// <summary>仕入先名(略称)</summary>
		[Column("name_ryakusyo")]
		public string NameRyakusyo { get; set; }

		/// <summary>電話番号</summary>
		[Column("tel")]
		public string Tel { get; set; }

		/// <summary>ＦＡＸ番号</summary>
		[Column("fax")]
		public string Fax { get; set; }

		/// <summary>変更日</summary>
		[Column("henkou_ymd")]
		public DateTime? HenkouYmd { get; set; }

		/// <summary>継続区分</summary>
		[Column("keizoku_kubun")]
		public int? KeizokuKubun { get; set; }

		/// <summary>仕入伝票行数</summary>
		[Column("shiire_line")]
		public int? ShiireLine { get; set; }

		/// <summary>卸コード</summary>
		[Column("oroshi_code")]
		public string OroshiCode { get; set; }

		/// <summary>サイト区分</summary>
		[Column("site_kubun")]
		public int? SiteKubun { get; set; }

		/// <summary>消費税算出区分</summary>
		[Column("tax_san_kubun")]
		public int? TaxSanKubun { get; set; }

		/// <summary>消費税端数処理区分</summary>
		[Column("tax_hasu_kubun")]
		public int? TaxHasuKubun { get; set; }

		/// <summary>仕入先名(集計用)</summary>
		[Column("name_syukei")]
		public string NameSyukei { get; set; }

		/// <summary>使用開始</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("start_use_date", Order = 1)]
		public int? StartUseDate { get; set; }

		/// <summary>使用終了</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("end_use_date", Order = 2)]
		public int? EndUseDate { get; set; }

		/// <summary>通知識別</summary>
		[Column("tsuchi_sikibetsu")]
		public int? TsuchiSikibetsu { get; set; }

		/// <summary>通知日時</summary>
		[Column("tsuchi_date")]
		public DateTime? TsuchiDate { get; set; }

		/// <summary>管理属性</summary>
		[Column("kanri_zokusei")]
		public int? KanriZokusei { get; set; }

		/// <summary> コンストラクタ</summary>
		public ShiiresakiMaster()
		{

			ShiiresakiCode = "";
			Yuubin = "";
			Jyu1 = "";
			Jyu2 = "";
			Name = "";
			NameRyakusyo = "";
			Tel = "";
			Fax = "";
			HenkouYmd = null;
			KeizokuKubun = 0;
			ShiireLine = 0;
			OroshiCode = "";
			SiteKubun = 0;
			TaxSanKubun = 0;
			TaxHasuKubun = 0;
			NameSyukei = "";
			StartUseDate = 0;
			EndUseDate = 0;
			TsuchiSikibetsu = 0;
			TsuchiDate = null;
			KanriZokusei = 0;

		}
	} 
} 
