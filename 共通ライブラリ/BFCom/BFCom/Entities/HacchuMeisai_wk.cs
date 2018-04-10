namespace B2.BestFunction.Entities
{ 
	using System; 
	using System.Collections.Generic; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	/// <summary>発注明細ワーク</summary>
	[Table("hacchu_meisai_wk")]
	public partial class HacchuMeisai_wk
	{ 
		/// <summary>薬局コード</summary>
		[Column("yakkyoku_code")]
		public string YakkyokuCode { get; set; }

		/// <summary>一意キー</summary>
		[Key]
		[Column("ichi_bango")]
		public int IchiBango { get; set; }

		/// <summary>伝票区分</summary>
		[Column("denpyo_kubun")]
		public int DenpyoKubun { get; set; }

		/// <summary>取引区分</summary>
		[Column("torihiki_kubun")]
		public int TorihikiKubun { get; set; }

		/// <summary>処理日</summary>
		[Column("shori_date")]
		public DateTime? ShoriDate { get; set; }

		/// <summary>商品コード区分</summary>
		[Column("shohin_code_kubun")]
		public int? ShohinCodeKubun { get; set; }

		/// <summary>商品コード</summary>
		[Column("shohin_code")]
		public string ShohinCode { get; set; }

		/// <summary>商品名、規格、容量</summary>
		[Column("shohin_name_kikaku_yoryo")]
		public string ShohinNameKikakuYoryo { get; set; }

		/// <summary>箱数</summary>
		[Column("hako_suryo")]
		public decimal? HakoSuryo { get; set; }

		/// <summary>包装数</summary>
		[Column("hoso_suryo")]
		public decimal? HosoSuryo { get; set; }

		/// <summary>バラ数</summary>
		[Column("bara_suryo")]
		public decimal? BaraSuryo { get; set; }

		/// <summary>納品指定日</summary>
		[Column("delivery_date")]
		public DateTime? DeliveryDate { get; set; }

		/// <summary>納品指定場所</summary>
		[Column("delivery_location")]
		public int? DeliveryLocation { get; set; }

		/// <summary>備考</summary>
		[Column("biko")]
		public string Biko { get; set; }

		/// <summary>入庫数</summary>
		[Column("nyuuko_su")]
		public int? NyuukoSu { get; set; }

		/// <summary>残区分</summary>
		[Column("zan_kubun")]
		public int? ZanKubun { get; set; }

		/// <summary>登録日時</summary>
		[Column("insert_nitiji")]
		public DateTime? InsertNitiji { get; set; }

		/// <summary> コンストラクタ</summary>
		public HacchuMeisai_wk()
		{

			YakkyokuCode = "";
			IchiBango = 0;
			DenpyoKubun = 0;
			TorihikiKubun = 0;
			ShoriDate = null;
			ShohinCodeKubun = 0;
			ShohinCode = "";
			ShohinNameKikakuYoryo = "";
			HakoSuryo = 0;
			HosoSuryo = 0;
			BaraSuryo = 0;
			DeliveryDate = null;
			DeliveryLocation = 0;
			Biko = "";
			NyuukoSu = 0;
			ZanKubun = 0;
			InsertNitiji = null;

		}
	} 
} 
