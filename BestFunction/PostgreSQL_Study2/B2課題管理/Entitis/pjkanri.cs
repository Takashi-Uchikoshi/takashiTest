namespace B2
{ 
	using System;
    using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations; 
	using System.ComponentModel.DataAnnotations.Schema;

    [Table("�v���W�F�N�g���Ǘ��\")]
	public partial class �v���W�F�N�g���Ǘ��\
	{ 
		[Key]
        [Column("�v���W�F�N�g�ԍ�", Order = 0)]
        public int? �v���W�F�N�g�ԍ� { get; set; }

        [Column("�v���W�F�N�g��")]
		public string �v���W�F�N�g�� { get; set; }

        [Column("�󒍊Ǘ��ԍ�")]
		public string �󒍊Ǘ��ԍ� { get; set; }

        [Column("�ڋq��")]
		public string �ڋq�� { get; set; }

        [Column("��������")]
		public string �����於 { get; set; }

        [Column("�������S����")]
		public string �������S���� { get; set; }

        [Column("���l")]
		public string ���l { get; set; }

 //       public virtual ICollection<�ۑ�Ǘ�> kadais { get; set; }
 //       public virtual �ۑ�Ǘ� �ۑ�Ǘ� { get; set; }


	} 
} 
