namespace B2.BestFunction.Entities
{
    using System;
    using System.Data.Entity;
    using Npgsql;
    using System.Linq;
    using System.Linq.Expressions;      // ラムダ用！？
    using System.Text;
    using B2.Com;

    public class BfDbContext : DbContext
    {
        // コンテキストは、アプリケーションの構成ファイル (App.config または Web.config) から 'Entitis_Model' 
        // 接続文字列を使用するように構成されています。既定では、この接続文字列は LocalDb インスタンス上
        // の 'B2.Entitis_Model' データベースを対象としています。 
        // 
        // 別のデータベースとデータベース プロバイダーまたはそのいずれかを対象とする場合は、
        // アプリケーション構成ファイルで 'Entitis_Model' 接続文字列を変更してください。
        public BfDbContext()
            : base("name=public")
        {
        }

        /// <summary>	
        /// コンストラクタ	
        /// </summary>	
        /// <param name="b2Com">接続情報を含むB2共通ユーティリティ</param>	
        public BfDbContext(B2Com b2Com)
            : base(GetConnecting(b2Com.DbServerMei,b2Com.DbPortBango,b2Com.DbDatabaseMei,b2Com.DbUserMei,b2Com.DbPassword), true)
        {
            DefaultSchema = b2Com.DbSchema;
        }	

        //テーブル接続情報
        public DbSet<BfChouzai_jisseki> BfChouzai_jisseki { get; set; }
        public DbSet<BfIdou> BfIdou { get; set; }
        public DbSet<BfIni> BfIni { get; set; }
        public DbSet<BfStatus> BfStatus { get; set; }
        public DbSet<EigyouMaster> EigyouMaster { get; set; }
        public DbSet<HachukanriMaster> HachukanriMaster { get; set; }
        public DbSet<HachuuDetails> HachuuDetails { get; set; }
        public DbSet<HachuuHeader> HachuuHeader { get; set; }
        public DbSet<IniMaster> IniMaster { get; set; }
        public DbSet<KanjyaData> KanjyaData { get; set; }
        public DbSet<LogData> LogData { get; set; }
        public DbSet<LotinfoMaster> LotinfoMaster { get; set; }
        public DbSet<MakerMaster> MakerMaster { get; set; }
        public DbSet<MenuData> MenuData { get; set; }
        public DbSet<NouhinData> NouhinData { get; set; }
        public DbSet<Nsips0Header> Nsips0Header { get; set; }
        public DbSet<Nsips1Kanjya> Nsips1Kanjya { get; set; }
        public DbSet<Nsips2Shohosen> Nsips2Shohosen { get; set; }
        public DbSet<Nsips3Yoho> Nsips3Yoho { get; set; }
        public DbSet<Nsips4Yakuhin> Nsips4Yakuhin { get; set; }
        public DbSet<Nsips5Chozairoku> Nsips5Chozairoku { get; set; }
        public DbSet<Nsips6Chozairoku_meisai> Nsips6Chozairoku_meisai { get; set; }
        public DbSet<Nsips7Kasan> Nsips7Kasan { get; set; }
        public DbSet<NyuukoDetails> NyuukoDetails { get; set; }
        public DbSet<NyuukoHeader> NyuukoHeader { get; set; }
        public DbSet<OtcMaster> OtcMaster { get; set; }
        public DbSet<PickedYakuhin> PickedYakuhin { get; set; }
        public DbSet<SeibunMaster> SeibunMaster { get; set; }
        public DbSet<ShiiresakiMaster> ShiiresakiMaster { get; set; }
        public DbSet<StoreMaster> StoreMaster { get; set; }
        public DbSet<SyukkoDetails> SyukkoDetails { get; set; }
        public DbSet<SyukkoHeader> SyukkoHeader { get; set; }
        public DbSet<TanabanMaster> TanabanMaster { get; set; }
        public DbSet<TanabanSyouhin> TanabanSyouhin { get; set; }
        public DbSet<TanaoroshiHeader> TanaoroshiHeader { get; set; }
        public DbSet<TanaoroshiKaishi> TanaoroshiKaishi { get; set; }
        public DbSet<TanaoroshiMeisai> TanaoroshiMeisai { get; set; }
        public DbSet<TehaiMaster> TehaiMaster { get; set; }
        public DbSet<TenpoMaster> TenpoMaster { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<YakkyokuMaster> YakkyokuMaster { get; set; }
        public DbSet<YakuhinMaster> YakuhinMaster { get; set; }
        public DbSet<ZaikoMaster> ZaikoMaster { get; set; }

        /// <summary>
        /// 参照するスキーマ。
        /// </summary>
        public string DefaultSchema { get; private set; }

                /// <summary>
        /// スキーマを変更したい場合はここで変更
        /// 指定が無いとスキーマ名は『dbo』に設定される。
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             modelBuilder.HasDefaultSchema(DefaultSchema);
        }
        //=>  modelBuilder.HasDefaultSchema(DefaultSchema);


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