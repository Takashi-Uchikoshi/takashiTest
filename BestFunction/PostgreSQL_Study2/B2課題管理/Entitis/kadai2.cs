namespace B2
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	[Table("課題管理")]
	public partial class 課題管理2
	{ 
        [Key]
        [Column("プロジェクト番号", Order = 0)]
		public decimal? プロジェクト番号 { get; set; }

        [Key]
        [Column("連番", Order = 1)]
		public decimal? 連番 { get; set; }

        [Column("管理番号")]
		public decimal? 管理番号 { get; set; }

        [Column("分類")]
		public string 分類 { get; set; }

        [Column("機能名称")]
		public string 機能名称 { get; set; }

        [Column("管理内容")]
		public string 管理内容 { get; set; }

        [Column("処置内容")]
		public string 処置内容 { get; set; }

        [Column("種別")]
		public string 種別 { get; set; }

        [Column("状態")]
		public string 状態 { get; set; }

        [Column("発生フェーズ")]
		public string 発生フェーズ { get; set; }

        [Column("原因フェーズ")]
		public string 原因フェーズ { get; set; }

        [Column("原因区分")]
		public string 原因区分 { get; set; }

        [Column("原因詳細")]
		public string 原因詳細 { get; set; }

        [Column("重要度")]
		public string 重要度 { get; set; }

        [Column("発生日")]
		public DateTime? 発生日 { get; set; }

        [Column("対応予定日")]
		public DateTime? 対応予定日 { get; set; }

        [Column("完了日")]
		public DateTime? 完了日 { get; set; }

        [Column("指摘者")]
		public string 指摘者 { get; set; }

        [Column("処置者")]
		public string 処置者 { get; set; }

        [Column("是正区分")]
		public string 是正区分 { get; set; }

        [Column("抽出グループ")]
		public string 抽出グループ { get; set; }

        [Column("登録者")]
		public string 登録者 { get; set; }

        [Column("登録日")]
		public DateTime? 登録日 { get; set; }

        [Column("予定工数")]
		public decimal? 予定工数 { get; set; }

        [Column("実績工数")]
		public decimal? 実績工数 { get; set; }

        [Column("開発着手日")]
		public DateTime? 開発着手日 { get; set; }

        [Column("開発完了日")]
		public DateTime? 開発完了日 { get; set; }

        [Column("進捗率")]
		public decimal? 進捗率 { get; set; }

        [Column("備考")]
		public string 備考 { get; set; }

	} 
} 
