namespace B2
{ 
	using System; 
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema; 

	[Table("kadai_kanri")]
	public partial class kadai_kanri
	{ 
		[Key]
        [Column("p_no", Order = 0)]
		public decimal p_no { get; set; }

		[Key]
        [Column("renban", Order = 1)]
		public decimal renban { get; set; }

        [Column("kanribangou")]
		public decimal kanribangou { get; set; }

        [Column("bunrui")]
		public string bunrui { get; set; }

        [Column("kinoumei")]
		public string kinoumei { get; set; }

        [Column("kanrinaiyou")]
		public string kanrinaiyou { get; set; }

        [Column("syochinaiyou")]
		public string syochinaiyou { get; set; }

        [Column("syubetu")]
		public string syubetu { get; set; }

        [Column("jyoutai")]
		public string jyoutai { get; set; }

        [Column("hassei_f")]
		public string hassei_f { get; set; }

        [Column("genin_f")]
		public string genin_f { get; set; }

        [Column("geninkubun")]
		public string geninkubun { get; set; }

        [Column("geninsyousai")]
		public string geninsyousai { get; set; }

        [Column("jyuuyoudo")]
		public string jyuuyoudo { get; set; }

        [Column("hasseibi")]
		public DateTime hasseibi { get; set; }

        [Column("taiouyoteibi")]
		public DateTime taiouyoteibi { get; set; }

        [Column("kanryoubi")]
		public DateTime kanryoubi { get; set; }

        [Column("sitekisya")]
		public string sitekisya { get; set; }

        [Column("syochisya")]
		public string syohisya { get; set; }

        [Column("zeseikubun")]
        public string zeseikubun { get; set; }

        [Column("cyuusyutu_g")]
        public string cyuusyutu_g { get; set; }

        [Column("tourokusya")]
		public string tourokusya { get; set; }

        [Column("tourokubi")]
		public DateTime tourokubi { get; set; }

        [Column("yoteikousuu")]
		public decimal yoteikousuu { get; set; }

        [Column("jissekikousuu")]
		public decimal jissekikousuu { get; set; }

        [Column("cyakusyubi")]
        public DateTime cyakusyubi { get; set; }

        [Column("kannryoubi2")]
        public DateTime kannryoubi2 { get; set; }

        [Column("shincyokuritu")]
		public decimal shincyokuritu { get; set; }

        [Column("bikou")]
		public string bikou { get; set; }

	} 
} 
