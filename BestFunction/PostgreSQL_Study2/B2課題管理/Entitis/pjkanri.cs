namespace B2
{ 
	using System;
    using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema;

    [Table("プロジェクト名管理表")]
	public partial class プロジェクト名管理表
	{ 
		[Key]
        [Column("プロジェクト番号", Order = 0)]
        public int? プロジェクト番号 { get; set; }

        [Column("プロジェクト名")]
		public string プロジェクト名 { get; set; }

        [Column("受注管理番号")]
		public string 受注管理番号 { get; set; }

        [Column("顧客名")]
		public string 顧客名 { get; set; }

        [Column("発注元名")]
		public string 発注先名 { get; set; }

        [Column("発注元担当者")]
		public string 発注元担当者 { get; set; }

        [Column("備考")]
		public string 備考 { get; set; }

 //       public virtual ICollection<課題管理> kadais { get; set; }
 //       public virtual 課題管理 課題管理 { get; set; }


	} 
} 
