namespace B2
{
    using System;
    using System.Data.Entity;
    using Npgsql;
    using System.Linq;
    using System.Linq.Expressions;      // ラムダ用！？
    using System.Text;
    using B2.Com;

    public class Entitis_Model : DbContext
    {
        // コンテキストは、アプリケーションの構成ファイル (App.config または Web.config) から 'Entitis_Model' 
        // 接続文字列を使用するように構成されています。既定では、この接続文字列は LocalDb インスタンス上
        // の 'B2.Entitis_Model' データベースを対象としています。 
        // 
        // 別のデータベースとデータベース プロバイダーまたはそのいずれかを対象とする場合は、
        // アプリケーション構成ファイルで 'Entitis_Model' 接続文字列を変更してください。
        public Entitis_Model()
            : base("name=pgadmin")
        {
        }

        /// <summary>	
        /// コンストラクタ	
        /// </summary>	
        /// <param name="userid">接続ID。</param>	
        /// <param name="password">接続パスワード。</param>	
        /// <param name="defaultSchema">接続先スキーマ。</param>	
        //public Entitis_Model(string userid, string password, string defaultSchema)	
        //    : base(GetConnecting(userid, password), true)	
        //{	
        //    DefaultSchema = defaultSchema;	
        //}
        public Entitis_Model(clsB2Com b2Com)
            : base(GetConnecting(b2Com.DB_Server,b2Com.DB_Port,b2Com.DB_Database,b2Com.DB_User,b2Com.DB_Password), true)
        {
            DefaultSchema = b2Com.DB_Schema;
        }	

        //テーブル接続情報
        public DbSet<課題管理> 課題管理 { get; set; }

        public DbSet<kadai_kanri> kadai_kanri { get; set; }

        public DbSet<プロジェクト名管理表> プロジェクト名管理表 { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<課題管理>()
        //        .HasMany(c => c.pjkanris).WithMany(i => i.kadais)
        //        .Map(t => t.MapLeftKey("プロジェクト番号")
        //            .MapRightKey("プロジェクト番号")
        //            .ToTable("PJ_Name"));
        //}


        /// <summary>
        /// 参照するスキーマ。
        /// </summary>
        public string DefaultSchema { get; private set; }

                /// <summary>
        /// スキーマを変更したい場合はここで変更
        /// 指定が無いとスキーマ名は『dbo』に設定される。
        /// </summary>
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //     modelBuilder.HasDefaultSchema(DefaultSchema);
        //}
        //=>  modelBuilder.HasDefaultSchema(DefaultSchema);
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DefaultSchema);

            //modelBuilder.Entity<課題管理>()
            //    .HasMany(c => c.pjkanris).WithMany(i => i.kadais)
            //    .Map(t => t.MapLeftKey("プロジェクト番号")
            //        .MapRightKey("プロジェクト番号")
            //        .ToTable("PJ_Name"));
        }


        /// <summary>
        /// コネクションの取得
        /// </summary>
        /// <param name="userid">ユーザーID</param>
        /// <param name="password">パスワード</param>
        static NpgsqlConnection GetConnecting(string Server, string portNo, string Database, string userid, string password)
        {
            var sb = new StringBuilder();
            sb.Append(@"Server=" + Server + ";");
            sb.Append(@"Port=" + portNo + ";");
            sb.Append(@"Database=" + Database + ";");
            sb.Append(@"User Id=" + userid + ";");
            sb.Append(@"Password=" + password + ";");
            return new NpgsqlConnection(sb.ToString());
        }


        // モデルに含めるエンティティ型ごとに DbSet を追加します。Code First モデルの構成および使用の
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=390109 を参照してください。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }


        //public class MyEntity
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //}
    }
}