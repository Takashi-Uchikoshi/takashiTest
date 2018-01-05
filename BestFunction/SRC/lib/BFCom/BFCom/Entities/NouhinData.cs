namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>納品データ</summary>
	[Table("nouhin_data")]
	public partial class NouhinData
	{ 
		/// <summary>薬局コード</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>レコード区分</summary>
		[Column("record_kbn")]
		public string RecordKbn { get; set; }

		/// <summary>データ識別</summary>
		[Column("data_class")]
		public string DataClass { get; set; }

		/// <summary>送信元卸コード</summary>
		[Key]
		[Column("oroshi_cd", Order = 0)]
		public string OroshiCd { get; set; }

		/// <summary>送信先医療機関コード</summary>
		[Key]
		[Column("iryokikan_cd", Order = 1)]
		public string IryokikanCd { get; set; }

		/// <summary>副送信先医療機関コード</summary>
		[Key]
		[Column("sub_iryokikan_cd", Order = 2)]
		public string SubIryokikanCd { get; set; }

		/// <summary>伝票区分</summary>
		[Key]
		[Column("slip_kbn", Order = 3)]
		public int? SlipKbn { get; set; }

		/// <summary>伝票日付</summary>
		[Key]
		[Column("slip_date", Order = 4)]
		public DateTime? SlipDate { get; set; }

		/// <summary>伝票番号</summary>
		[Key]
		[Column("slip_number", Order = 5)]
		public string SlipNumber { get; set; }

		/// <summary>伝票行番号</summary>
		[Key]
		[Column("slip_line_number", Order = 6)]
		public int? SlipLineNumber { get; set; }

		/// <summary>商品コード区分</summary>
		[Column("medicine_cd_kbn")]
		public int? MedicineCdKbn { get; set; }

		/// <summary>商品コード</summary>
		[Column("jan_cd")]
		public string JanCd { get; set; }

		/// <summary>GTIN商品コード</summary>
		[Column("gtin_cd")]
		public string GtinCd { get; set; }

		/// <summary>商品名</summary>
		[Column("name_alpha")]
		public string NameAlpha { get; set; }

		/// <summary>数量</summary>
		[Column("suryo")]
		public decimal? Suryo { get; set; }

		/// <summary>単価</summary>
		[Column("tanka")]
		public decimal? Tanka { get; set; }

		/// <summary>金額</summary>
		[Column("kingaku")]
		public decimal? Kingaku { get; set; }

		/// <summary>薬価</summary>
		[Column("yakka")]
		public decimal? Yakka { get; set; }

		/// <summary>有効期限</summary>
		[Column("siyou_ymd")]
		public DateTime? SiyouYmd { get; set; }

		/// <summary>製造番号</summary>
		[Column("lot")]
		public string Lot { get; set; }

		/// <summary>固定項目</summary>
		[Column("filler1")]
		public string Filler1 { get; set; }

		/// <summary>登録日時</summary>
		[Column("insert_date")]
		public DateTime? InsertDate { get; set; }

		/// <summary>ファイル名</summary>
		[Column("file_name")]
		public string FileName { get; set; }

		/// <summary>入庫フラグ</summary>
		[Column("nyuuko_flg")]
		public int? NyuukoFlg { get; set; }

		/// <summary> コンストラクタ</summary>
		public NouhinData()
		{

			YakkyokuCode = "";
			RecordKbn = "";
			DataClass = "";
			OroshiCd = "";
			IryokikanCd = "";
			SubIryokikanCd = "";
			SlipKbn = 0;
			SlipDate = null;
			SlipNumber = "";
			SlipLineNumber = 0;
			MedicineCdKbn = 0;
			JanCd = "";
			GtinCd = "";
			NameAlpha = "";
			Suryo = 0;
			Tanka = 0;
			Kingaku = 0;
			Yakka = 0;
			SiyouYmd = null;
			Lot = "";
			Filler1 = "";
			InsertDate = null;
			FileName = "";
			NyuukoFlg = 0;

		}
	} 
} 
