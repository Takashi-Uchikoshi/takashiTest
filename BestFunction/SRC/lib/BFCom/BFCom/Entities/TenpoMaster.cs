namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>XÜ}X^</summary>
	[Table("tenpo_master")]
	public partial class TenpoMaster
	{ 
		/// <summary>òÇR[h</summary>
		[Key]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>XXÖÔ</summary>
		[Column("mise_yuubin")]
		public string MiseYuubin { get; set; }

		/// <summary>XÜZiPj</summary>
		[Column("mise_jyu1")]
		public string MiseJyu1 { get; set; }

		/// <summary>XÜZiQj</summary>
		[Column("mise_jyu2")]
		public string MiseJyu2 { get; set; }

		/// <summary>XÜ¼</summary>
		[Column("mise_tenmei")]
		public string MiseTenmei { get; set; }

		/// <summary>XÜ¼(ªÌ)</summary>
		[Column("mise_tenpomei")]
		public string MiseTenpomei { get; set; }

		/// <summary>XÜdbÔ</summary>
		[Column("mise_tel")]
		public string MiseTel { get; set; }

		/// <summary>XÜe`wÔ</summary>
		[Column("mise_fax")]
		public string MiseFax { get; set; }

		/// <summary>ÏXú</summary>
		[Column("henkou_ymd")]
		public DateTime? HenkouYmd { get; set; }

		/// <summary>T[o[Æ§æª</summary>
		[Column("server_kbn")]
		public int? ServerKbn { get; set; }

		/// <summary>MEDZÚ±¶ñ</summary>
		[Column("medz_easyconfig")]
		public string MedzEasyconfig { get; set; }

		/// <summary>PHARÚ±¶ñ</summary>
		[Column("phar_easyconfig")]
		public string PharEasyconfig { get; set; }

		/// <summary>Ç®«</summary>
		[Column("kanri_zokusei")]
		public int? KanriZokusei { get; set; }

		/// <summary> RXgN^</summary>
		public TenpoMaster()
		{

			YakkyokuCode = "";
			MiseYuubin = "";
			MiseJyu1 = "";
			MiseJyu2 = "";
			MiseTenmei = "";
			MiseTenpomei = "";
			MiseTel = "";
			MiseFax = "";
			HenkouYmd = null;
			ServerKbn = 0;
			MedzEasyconfig = "";
			PharEasyconfig = "";
			KanriZokusei = 0;

		}
	} 
} 
