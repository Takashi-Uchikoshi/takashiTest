namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>手配管理マスタ</summary>
	[Table("tehai_master")]
	public partial class TehaiMaster
	{ 
		/// <summary>薬局コード</summary>
		[Key]
		[Column("yakkyoku_code", Order = 0)]
		public string YakkyokuCode { get; set; }

		/// <summary>YJコード</summary>
		[Key]
		[Column("yj_code", Order = 1)]
		public string YjCode { get; set; }

		/// <summary>GTINコード</summary>
		[Key]
		[Column("gtin_code", Order = 2)]
		public string GtinCode { get; set; }

		/// <summary>JANコード</summary>
		[Key]
		[Column("jan_code", Order = 3)]
		public string JanCode { get; set; }

		/// <summary>明細コード</summary>
		[Column("meisai_code")]
		public string MeisaiCode { get; set; }

		/// <summary>仕入先ｺｰﾄﾞ</summary>
		[Column("shiiresaki_cd")]
		public string ShiiresakiCd { get; set; }

		/// <summary>購入価</summary>
		[Column("price")]
		public decimal? Price { get; set; }

		/// <summary>登録日</summary>
		[Column("insert_date")]
		public DateTime? InsertDate { get; set; }

		/// <summary>更新日</summary>
		[Column("update_date")]
		public DateTime? UpdateDate { get; set; }

		/// <summary>使用開始</summary>
		[Key]
		[Column("start_use_date", Order = 4)]
		public int? StartUseDate { get; set; }

		/// <summary>使用終了</summary>
		[Key]
		[Column("end_use_date", Order = 5)]
		public int? EndUseDate { get; set; }

		/// <summary> コンストラクタ</summary>
		public TehaiMaster()
		{

			YakkyokuCode = "";
			YjCode = "";
			GtinCode = "";
			JanCode = "";
			MeisaiCode = "";
			ShiiresakiCd = "";
			Price = 0;
			InsertDate = null;
			UpdateDate = null;
			StartUseDate = 0;
			EndUseDate = 0;

		}
	} 
} 
