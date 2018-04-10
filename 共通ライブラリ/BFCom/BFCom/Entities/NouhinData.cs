namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
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
		[Column("record_kubun")]
		public string RecordKubun { get; set; }

		/// <summary>データ識別</summary>
		[Column("data_class")]
		public string DataClass { get; set; }

		/// <summary>送信元卸コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("oroshi_code", Order = 0)]
		public string OroshiCode { get; set; }

		/// <summary>送信先医療機関コード</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("iryokikan_code", Order = 1)]
		public string IryokikanCode { get; set; }

		/// <summary>副送信先医療機関コード</summary>
		[Column("sub_iryokikan_code")]
		public string SubIryokikanCode { get; set; }

		/// <summary>伝票区分</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("slip_kubun", Order = 2)]
		public int? SlipKubun { get; set; }

		/// <summary>伝票日付</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("slip_date", Order = 3)]
		public DateTime? SlipDate { get; set; }

		/// <summary>伝票番号</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("slip_number", Order = 4)]
		public string SlipNumber { get; set; }

		/// <summary>伝票行番号</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("slip_line_number", Order = 5)]
		public int? SlipLineNumber { get; set; }

		/// <summary>商品コード区分</summary>
		[Column("medicine_code_kubun")]
		public int? MedicineCodeKubun { get; set; }

		/// <summary>商品コード</summary>
		[Column("jan_code")]
		public string JanCode { get; set; }

		/// <summary>GTIN商品コード</summary>
		[Column("gtin_code")]
		public string GtinCode { get; set; }

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
		[Column("shiyo_kigen")]
		public DateTime? ShiyoKigen { get; set; }

		/// <summary>製造番号</summary>
		[Column("lot_bango")]
		public string LotBango { get; set; }

		/// <summary>固定項目</summary>
		[Column("filler1")]
		public string Filler1 { get; set; }

		/// <summary>登録日時</summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("insert_date", Order = 6)]
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
			RecordKubun = "";
			DataClass = "";
			OroshiCode = "";
			IryokikanCode = "";
			SubIryokikanCode = "";
			SlipKubun = 0;
			SlipDate = null;
			SlipNumber = "";
			SlipLineNumber = 0;
			MedicineCodeKubun = 0;
			JanCode = "";
			GtinCode = "";
			NameAlpha = "";
			Suryo = 0;
			Tanka = 0;
			Kingaku = 0;
			Yakka = 0;
			ShiyoKigen = null;
			LotBango = "";
			Filler1 = "";
			InsertDate = null;
			FileName = "";
			NyuukoFlg = 0;

		}
	} 
} 
