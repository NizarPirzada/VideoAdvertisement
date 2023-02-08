using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace VimeoVSV.Web.DBModels
{
    public partial class pubsContext : DbContext
    {
        public pubsContext()
        {
        }

        public pubsContext(DbContextOptions<pubsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CsactiveProduct> CsactiveProducts { get; set; }
        public virtual DbSet<Csbrand> Csbrands { get; set; }
        public virtual DbSet<Csinventory> Csinventories { get; set; }
        public virtual DbSet<Cslocation> Cslocations { get; set; }
        public virtual DbSet<Csmarket> Csmarkets { get; set; }
        public virtual DbSet<CsmasterCat> CsmasterCats { get; set; }
        public virtual DbSet<Csproduct> Csproducts { get; set; }
        public virtual DbSet<Csreconcile> Csreconciles { get; set; }
        public virtual DbSet<CsreconcileClose> CsreconcileCloses { get; set; }
        public virtual DbSet<Csrollup> Csrollups { get; set; }
        public virtual DbSet<CsspecialPricing> CsspecialPricings { get; set; }
        public virtual DbSet<CssubCat> CssubCats { get; set; }
        public virtual DbSet<Csuser> Csusers { get; set; }
        public virtual DbSet<Ev1000> Ev1000s { get; set; }
        public virtual DbSet<Ev3000> Ev3000s { get; set; }
        public virtual DbSet<GeneralSetting> GeneralSettings { get; set; }
        public virtual DbSet<Gwywmember> Gwywmembers { get; set; }
        public virtual DbSet<Gwywmemberfafe> Gwywmemberfaves { get; set; }
        public virtual DbSet<Gwywnamegender> Gwywnamegenders { get; set; }
        public virtual DbSet<Gwywshop> Gwywshops { get; set; }
        public virtual DbSet<Gwywwishitem> Gwywwishitems { get; set; }
        public virtual DbSet<Gwywwishlist> Gwywwishlists { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<JuiceClub> JuiceClubs { get; set; }
        public virtual DbSet<JuiceStation> JuiceStations { get; set; }
        public virtual DbSet<Market> Markets { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Rtoken> Rtokens { get; set; }
        public virtual DbSet<Sheet1> Sheet1s { get; set; }
        public virtual DbSet<Storelocator> Storelocators { get; set; }
        public virtual DbSet<Vccustomer> Vccustomers { get; set; }
        public virtual DbSet<VccustomerTest> VccustomerTests { get; set; }
        public virtual DbSet<Vcjuice> Vcjuices { get; set; }
        public virtual DbSet<Vckit> Vckits { get; set; }
        public virtual DbSet<Vcproduct> Vcproducts { get; set; }
        public virtual DbSet<Vcsale> Vcsales { get; set; }
        public virtual DbSet<VcsalesItem> VcsalesItems { get; set; }
        public virtual DbSet<VctempOrder> VctempOrders { get; set; }
        public virtual DbSet<VctempOrderDetail> VctempOrderDetails { get; set; }
        public virtual DbSet<Vsvaccount> Vsvaccounts { get; set; }
        public virtual DbSet<Vsvaccountprodvideo> Vsvaccountprodvideos { get; set; }
        public virtual DbSet<Vsvartist> Vsvartists { get; set; }
        public virtual DbSet<Vsvbrand> Vsvbrands { get; set; }
        public virtual DbSet<VsventertainmentVideo> VsventertainmentVideos { get; set; }
        public virtual DbSet<VsventertainmentVideo1> VsventertainmentVideo1s { get; set; }
        public virtual DbSet<Vsvlocation> Vsvlocations { get; set; }
        public virtual DbSet<Vsvmanufacturer> Vsvmanufacturers { get; set; }
        public virtual DbSet<VsvmasterGenre> VsvmasterGenres { get; set; }
        public virtual DbSet<VsvmusicGenre> VsvmusicGenres { get; set; }
        public virtual DbSet<Vsvplay> Vsvplays { get; set; }
        public virtual DbSet<VsvplaySummary> VsvplaySummaries { get; set; }
        public virtual DbSet<Vsvproduct> Vsvproducts { get; set; }
        public virtual DbSet<Vsvpromo> Vsvpromos { get; set; }
        public virtual DbSet<VsvpromoLog> VsvpromoLogs { get; set; }
        public virtual DbSet<VsvpromoRequestSummary> VsvpromoRequestSummaries { get; set; }
        public virtual DbSet<VsvsampleLog> VsvsampleLogs { get; set; }
        public virtual DbSet<VsvsampleRequestSummary> VsvsampleRequestSummaries { get; set; }
        public virtual DbSet<VsvshopIntro> VsvshopIntros { get; set; }
        public virtual DbSet<VsvshopOutro> VsvshopOutros { get; set; }
        public virtual DbSet<VsvshopWarning> VsvshopWarnings { get; set; }
        public virtual DbSet<VsvstoreCountSummary> VsvstoreCountSummaries { get; set; }
        public virtual DbSet<Vsvuser> Vsvusers { get; set; }
        public virtual DbSet<VsvuserEvid> VsvuserEvids { get; set; }
        public virtual DbSet<VsvuserVid> VsvuserVids { get; set; }
        public virtual DbSet<VsvuserVid09dec2020> VsvuserVid09dec2020s { get; set; }
        public virtual DbSet<VsvuserVid1> VsvuserVid1s { get; set; }
        public virtual DbSet<_2000> _2000s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(projectPath)
                    .AddJsonFile("appsettings.json")
                    .Build();
                string connectionString = configuration.GetConnectionString("DevConnection");
                //optionsBuilder.UseSqlServer("Server=.\\FAZALSQL;Database=pubs;Trusted_Connection=True;MultipleActiveResultSets=true");
                 optionsBuilder.UseSqlServer(connectionString);
              

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CsactiveProduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CSActiveProducts");

                entity.HasIndex(e => e.ActiveProductsId, "IX_CSActiveProducts")
                    .IsUnique();

                entity.HasIndex(e => new { e.LocationsId, e.MasterCatId, e.SubCatId, e.Brand, e.ProductName }, "IX_CSActiveProducts_1");

                entity.Property(e => e.ActiveProductsId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ActiveProductsID");

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocationsId).HasColumnName("LocationsID");

                entity.Property(e => e.MasterCatId).HasColumnName("MasterCatID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.SubCatId).HasColumnName("SubCatID");
            });

            modelBuilder.Entity<Csbrand>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CSBrands");

                entity.HasIndex(e => e.BrandId, "IX_CSBrands")
                    .IsUnique();

                entity.HasIndex(e => e.BrandName, "IX_CSBrands_1")
                    .IsUnique();

                entity.Property(e => e.BrandId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BrandID");

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Csinventory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CSInventory");

                entity.HasIndex(e => e.InventoryId, "IX_CSInventory")
                    .IsUnique();

                entity.HasIndex(e => new { e.MarketId, e.MasterCatId, e.Brand, e.ProductName }, "IX_CSInventory_1");

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InventoryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("InventoryID");

                entity.Property(e => e.MarketId).HasColumnName("MarketID");

                entity.Property(e => e.MasterCatId).HasColumnName("MasterCatID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cslocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CSLocations");

                entity.HasIndex(e => e.LocationsId, "IX_CSLocations")
                    .IsUnique();

                entity.HasIndex(e => e.LocationsName, "IX_CSLocations_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.MarketId, e.LocationsName }, "IX_CSLocations_2")
                    .IsUnique();

                entity.Property(e => e.Accessories).HasColumnType("money");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cbd)
                    .HasColumnType("money")
                    .HasColumnName("CBD");

                entity.Property(e => e.CityStateZip)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Distro100)
                    .HasColumnType("money")
                    .HasColumnName("DISTRO100");

                entity.Property(e => e.Distro120)
                    .HasColumnType("money")
                    .HasColumnName("DISTRO120");

                entity.Property(e => e.Distro60)
                    .HasColumnType("money")
                    .HasColumnName("DISTRO60");

                entity.Property(e => e.Distrosalts)
                    .HasColumnType("money")
                    .HasColumnName("DISTROsalts");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fourtwenty)
                    .HasColumnType("money")
                    .HasColumnName("fourtwenty");

                entity.Property(e => e.Hardware).HasColumnType("money");

                entity.Property(e => e.Kratom).HasColumnType("money");

                entity.Property(e => e.LocationsId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LocationsID");

                entity.Property(e => e.LocationsName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MarketId).HasColumnName("MarketID");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrefilledPods).HasColumnType("money");

                entity.Property(e => e.QbcustomerName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("QBCustomerName");

                entity.Property(e => e.Rme60)
                    .HasColumnType("money")
                    .HasColumnName("RME60");

                entity.Property(e => e.Rmesalts)
                    .HasColumnType("money")
                    .HasColumnName("RMEsalts");

                entity.Property(e => e.SavedReconcile)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SpecialPricing)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Csmarket>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CSMarkets");

                entity.HasIndex(e => e.MarketsId, "IX_CSMarkets")
                    .IsUnique();

                entity.HasIndex(e => e.MarketName, "IX_CSMarkets_1")
                    .IsUnique();

                entity.Property(e => e.MarketName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MarketsId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MarketsID");
            });

            modelBuilder.Entity<CsmasterCat>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CSMasterCat");

                entity.HasIndex(e => e.MasterCatId, "IX_CSMasterCat")
                    .IsUnique();

                entity.HasIndex(e => e.MasterCatName, "IX_CSMasterCat_1")
                    .IsUnique();

                entity.Property(e => e.MasterCatId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MasterCatID");

                entity.Property(e => e.MasterCatName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubCat)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Csproduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CSProducts");

                entity.HasIndex(e => e.ProductId, "IX_CSProducts")
                    .IsUnique();

                entity.HasIndex(e => new { e.MasterCatId, e.SubCatId, e.ProductName }, "IX_CSProducts_1")
                    .IsUnique();

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Consignment).HasColumnType("money");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.MasterCatId).HasColumnName("MasterCatID");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ProductID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.SubCatId).HasColumnName("SubCatID");
            });

            modelBuilder.Entity<Csreconcile>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CSReconcile");

                entity.HasIndex(e => e.ReconcileId, "IX_CSReconcile")
                    .IsUnique();

                entity.HasIndex(e => new { e.LocationsId, e.ReconcileId, e.ProductId }, "IX_CSReconcile_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.LocationsId, e.RecDate, e.ReconcileId, e.ProductId }, "IX_CSReconcile_2")
                    .IsUnique();

                entity.Property(e => e.AddDeductOnly)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LocationsId).HasColumnName("LocationsID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.RecDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ReconcileId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ReconcileID");
            });

            modelBuilder.Entity<CsreconcileClose>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CSReconcileClose");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("Created Date");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LocationsName).HasMaxLength(200);

                entity.Property(e => e.SavedReconcile)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Csrollup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CSRollup");

                entity.HasIndex(e => e.RollUpId, "IX_CSRollup")
                    .IsUnique();

                entity.HasIndex(e => new { e.LocationsId, e.Dmya, e.MasterCatId, e.SubCatId, e.RollUpId }, "IX_CSRollup_1")
                    .IsUnique();

                entity.Property(e => e.Dmya)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DMYA")
                    .IsFixedLength(true);

                entity.Property(e => e.Gross).HasColumnType("money");

                entity.Property(e => e.LocationsId).HasColumnName("LocationsID");

                entity.Property(e => e.MarketId).HasColumnName("MarketID");

                entity.Property(e => e.MasterCatId).HasColumnName("MasterCatID");

                entity.Property(e => e.Net).HasColumnType("money");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.RollUpId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("RollUpID");

                entity.Property(e => e.Rudate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("RUDate");

                entity.Property(e => e.Rumonth).HasColumnName("RUMonth");

                entity.Property(e => e.Ruyear)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("RUYear")
                    .IsFixedLength(true);

                entity.Property(e => e.StockValue).HasColumnType("money");

                entity.Property(e => e.SubCatId).HasColumnName("SubCatID");
            });

            modelBuilder.Entity<CsspecialPricing>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CSSpecialPricing");

                entity.HasIndex(e => e.SpecialPricingId, "IX_CSSpecialPricing")
                    .IsUnique();

                entity.HasIndex(e => new { e.LocationsId, e.ProductId, e.SpecialPricingId }, "IX_CSSpecialPricing_1")
                    .IsUnique();

                entity.Property(e => e.Consignment).HasColumnType("money");

                entity.Property(e => e.EffectiveDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LocationsId).HasColumnName("LocationsID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SpecialPricingId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SpecialPricingID");
            });

            modelBuilder.Entity<CssubCat>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CSSubCat");

                entity.HasIndex(e => e.SubCatId, "IX_CSSubCats")
                    .IsUnique();

                entity.HasIndex(e => new { e.MasterCatId, e.SubCatId }, "IX_CSSubCats_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.MasterCatId, e.SubCatName }, "IX_CSSubCats_2")
                    .IsUnique();

                entity.Property(e => e.MasterCatId).HasColumnName("MasterCatID");

                entity.Property(e => e.SubCatId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SubCatID");

                entity.Property(e => e.SubCatName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Csuser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CSUser");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MarketId).HasColumnName("MarketID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("UserID");

                entity.Property(e => e.Zip)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ev1000>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EV1000$");

                entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                entity.Property(e => e.Mgid).HasColumnName("MGID");

                entity.Property(e => e.MusicId).HasColumnName("MusicID");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<Ev3000>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EV3000$");

                entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                entity.Property(e => e.Mgid).HasColumnName("MGID");

                entity.Property(e => e.MusicId).HasColumnName("MusicID");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<GeneralSetting>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GeneralSetting");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Key)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Gwywmember>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GWYWmembers");

                entity.HasIndex(e => e.MemberId, "IX_GWYWmembers")
                    .IsUnique();

                entity.HasIndex(e => e.CellNumber, "IX_GWYWmembers_1")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "IX_GWYWmembers_2")
                    .IsUnique();

                entity.Property(e => e.CellNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Dob)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MemberID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StreetAddress1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ZipPlus5)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Gwywmemberfafe>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GWYWmemberfaves");

                entity.HasIndex(e => e.MemberFaveId, "IX_GWYWmemberfaves")
                    .IsUnique();

                entity.HasIndex(e => new { e.MemberId, e.ShopId }, "IX_GWYWmemberfaves_1")
                    .IsUnique();

                entity.Property(e => e.MemberFaveId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MemberFaveID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");
            });

            modelBuilder.Entity<Gwywnamegender>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GWYWnamegender");

                entity.HasIndex(e => e.NameId, "IX_GWYWnamegender")
                    .IsUnique();

                entity.HasIndex(e => e.NameValue, "IX_GWYWnamegender_1")
                    .IsUnique();

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NameId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NameID");

                entity.Property(e => e.NameValue)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Gwywshop>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GWYWshops");

                entity.HasIndex(e => e.ShopId, "IX_GWYWshops")
                    .IsUnique();

                entity.HasIndex(e => e.ShopName, "IX_GWYWshops_1")
                    .IsUnique();

                entity.Property(e => e.BmorOnline)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("BMorONLINE")
                    .IsFixedLength(true);

                entity.Property(e => e.GiftCard)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.GiftCardImageName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShopGender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ShopId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ShopID");

                entity.Property(e => e.ShopName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShopType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Gwywwishitem>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GWYWwishitems");

                entity.HasIndex(e => e.WishItemId, "IX_GWYWwishitems")
                    .IsUnique();

                entity.HasIndex(e => new { e.WishListId, e.ItemType, e.ShopId }, "IX_GWYWwishitems_1")
                    .IsUnique();

                entity.Property(e => e.ItemType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ShopId).HasColumnName("ShopID");

                entity.Property(e => e.ShopName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WishItemId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("WishItemID");

                entity.Property(e => e.WishListId).HasColumnName("WishListID");
            });

            modelBuilder.Entity<Gwywwishlist>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GWYWwishlist");

                entity.HasIndex(e => e.WishListId, "IX_GWYWwishlist")
                    .IsUnique();

                entity.HasIndex(e => new { e.MemberId, e.Wlname }, "IX_GWYWwishlist_1")
                    .IsUnique();

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.WishListId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("WishListID");

                entity.Property(e => e.Wlname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("WLName");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Invoice");

                entity.Property(e => e.AddDeductOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BillToAddress).HasMaxLength(100);

                entity.Property(e => e.BillToName).HasMaxLength(100);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("Created Date");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.InvoiceFilePath).HasMaxLength(500);

                entity.Property(e => e.InvoiceNumber).HasMaxLength(100);

                entity.Property(e => e.ReportFilePath)
                    .HasMaxLength(500)
                    .HasColumnName("ReportFIlePath");

                entity.Property(e => e.ShipToAddress).HasMaxLength(100);

                entity.Property(e => e.ShipToName).HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<JuiceClub>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("JuiceClub");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Bs1).HasColumnName("BS1");

                entity.Property(e => e.Bs10).HasColumnName("BS10");

                entity.Property(e => e.Bs11).HasColumnName("BS11");

                entity.Property(e => e.Bs12).HasColumnName("BS12");

                entity.Property(e => e.Bs13).HasColumnName("BS13");

                entity.Property(e => e.Bs14).HasColumnName("BS14");

                entity.Property(e => e.Bs15).HasColumnName("BS15");

                entity.Property(e => e.Bs2).HasColumnName("BS2");

                entity.Property(e => e.Bs3).HasColumnName("BS3");

                entity.Property(e => e.Bs4).HasColumnName("BS4");

                entity.Property(e => e.Bs5).HasColumnName("BS5");

                entity.Property(e => e.Bs6).HasColumnName("BS6");

                entity.Property(e => e.Bs7).HasColumnName("BS7");

                entity.Property(e => e.Bs8).HasColumnName("BS8");

                entity.Property(e => e.Bs9).HasColumnName("BS9");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Jf1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JF1");

                entity.Property(e => e.Jf10)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JF10");

                entity.Property(e => e.Jf11)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JF11");

                entity.Property(e => e.Jf12)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JF12");

                entity.Property(e => e.Jf13)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JF13");

                entity.Property(e => e.Jf14)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JF14");

                entity.Property(e => e.Jf15)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JF15");

                entity.Property(e => e.Jf2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JF2");

                entity.Property(e => e.Jf3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JF3");

                entity.Property(e => e.Jf4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JF4");

                entity.Property(e => e.Jf5)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JF5");

                entity.Property(e => e.Jf6)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JF6");

                entity.Property(e => e.Jf7)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JF7");

                entity.Property(e => e.Jf8)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JF8");

                entity.Property(e => e.Jf9)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JF9");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ns1).HasColumnName("NS1");

                entity.Property(e => e.Ns10).HasColumnName("NS10");

                entity.Property(e => e.Ns11).HasColumnName("NS11");

                entity.Property(e => e.Ns12).HasColumnName("NS12");

                entity.Property(e => e.Ns13).HasColumnName("NS13");

                entity.Property(e => e.Ns14).HasColumnName("NS14");

                entity.Property(e => e.Ns15).HasColumnName("NS15");

                entity.Property(e => e.Ns2).HasColumnName("NS2");

                entity.Property(e => e.Ns3).HasColumnName("NS3");

                entity.Property(e => e.Ns4).HasColumnName("NS4");

                entity.Property(e => e.Ns5).HasColumnName("NS5");

                entity.Property(e => e.Ns6).HasColumnName("NS6");

                entity.Property(e => e.Ns7).HasColumnName("NS7");

                entity.Property(e => e.Ns8).HasColumnName("NS8");

                entity.Property(e => e.Ns9).HasColumnName("NS9");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Recordid).ValueGeneratedOnAdd();

                entity.Property(e => e.SalesId).HasColumnName("SalesID");

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JuiceStation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("JuiceStation");

                entity.HasIndex(e => e.Recordid, "IX_JuiceStation")
                    .IsUnique();

                entity.Property(e => e.JuiceDescription)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.JuiceName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lenexa)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Vendor)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Market>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Market");

                entity.HasIndex(e => e.City, "IX_Market")
                    .IsUnique();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.ProductId, "IX_Products")
                    .IsUnique();

                entity.HasIndex(e => new { e.ProductType, e.ProductName, e.ProductId }, "IX_Products_1")
                    .IsUnique();

                entity.Property(e => e.ProductDescrip)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ProductID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rtoken>(entity =>
            {
                entity.ToTable("Rtoken");

                entity.Property(e => e.CreatedTimestamp).HasColumnType("datetime");

                entity.Property(e => e.RefreshToken).IsRequired();
            });

            modelBuilder.Entity<Sheet1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Sheet1$");

                entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                entity.Property(e => e.Mgid).HasColumnName("MGID");

                entity.Property(e => e.MusicId).HasColumnName("MusicID");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<Storelocator>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Storelocator");

                entity.Property(e => e.StoreAddress)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.StoreCity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StorePhone)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StoreState)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StoreZip)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.WebSiteId).HasColumnName("WebSiteID");
            });

            modelBuilder.Entity<Vccustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VCcustomer");

                entity.HasIndex(e => e.CustomerId, "IX_VCcustomer")
                    .IsUnique();

                entity.HasIndex(e => new { e.AssociateId, e.VaporGroup, e.LastName, e.CustomerId }, "IX_VCcustomer_1")
                    .IsUnique();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AssociateId).HasColumnName("AssociateID");

                entity.Property(e => e.BirthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CustomerID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FedTaxIdNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.JoinDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LastActivity).HasColumnType("smalldatetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaypalEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RetailOrAssociate)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SocialSecurityNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StreetAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VaporGroup)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VaporRoomJoinDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<VccustomerTest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VCcustomer_test");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AssociateId).HasColumnName("AssociateID");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CustomerID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FedTaxIdNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.JoinDate).HasColumnType("datetime");

                entity.Property(e => e.LastActivity).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaypalEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RetailOrAssociate)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SocialSecurityNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StreetAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VaporGroup)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VaporRoomJoinDate).HasColumnType("datetime");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Vcjuice>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VCJuice");

                entity.HasIndex(e => new { e.ProductId, e.Size, e.Nic }, "IX_VCJuice")
                    .IsUnique();

                entity.Property(e => e.Nic).HasColumnName("NIC");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SubId).HasColumnName("SubID");
            });

            modelBuilder.Entity<Vckit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VCKit");

                entity.HasIndex(e => new { e.ProductId, e.Color }, "IX_VCKit")
                    .IsUnique();

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SubId).HasColumnName("SubID");
            });

            modelBuilder.Entity<Vcproduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VCProducts");

                entity.HasIndex(e => e.ProductId, "IX_Products")
                    .IsUnique();

                entity.HasIndex(e => new { e.ProductType, e.ProductName }, "IX_Products_1")
                    .IsUnique();

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductDescrip)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ProductID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vcsale>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VCSales");

                entity.HasIndex(e => e.InvoiceNumber, "IX_VCSales")
                    .IsUnique();

                entity.HasIndex(e => new { e.AssociateId, e.InvoiceNumber }, "IX_VCSales_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.UplineAssociateId, e.InvoiceNumber }, "IX_VCSales_2")
                    .IsUnique();

                entity.HasIndex(e => new { e.InvoiceDate, e.InvoiceNumber }, "IX_VCSales_3")
                    .IsUnique();

                entity.Property(e => e.AssocCom).HasColumnType("money");

                entity.Property(e => e.AssocStock)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AssociateId).HasColumnName("AssociateID");

                entity.Property(e => e.CompanyCom).HasColumnType("money");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.InvoiceDate).HasColumnType("smalldatetime");

                entity.Property(e => e.InvoiceNumber).ValueGeneratedOnAdd();

                entity.Property(e => e.PaymentType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaypalInvoiceId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Paypal_InvoiceID");

                entity.Property(e => e.SalesTax).HasColumnType("money");

                entity.Property(e => e.ShipDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Shipping).HasColumnType("money");

                entity.Property(e => e.SubTotal).HasColumnType("money");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.Property(e => e.UplineAssocCom).HasColumnType("money");

                entity.Property(e => e.UplineAssociateId).HasColumnName("UplineAssociateID");
            });

            modelBuilder.Entity<VcsalesItem>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VCSalesItems");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductPrice).HasColumnType("money");

                entity.Property(e => e.ProductSubId).HasColumnName("ProductSubID");

                entity.Property(e => e.ProductType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SalesItemsId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SalesItemsID");

                entity.Property(e => e.TotalPrice).HasColumnType("money");
            });

            modelBuilder.Entity<VctempOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VCTempOrder");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Discounttotal)
                    .HasColumnType("money")
                    .HasColumnName("discounttotal");

                entity.Property(e => e.Entryid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("entryid");

                entity.Property(e => e.Invtotal)
                    .HasColumnType("money")
                    .HasColumnName("invtotal");

                entity.Property(e => e.Ordercompleteddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ordercompleteddate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Orderdate)
                    .HasColumnType("datetime")
                    .HasColumnName("orderdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("remarks");

                entity.Property(e => e.Shiptotal)
                    .HasColumnType("money")
                    .HasColumnName("shiptotal");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Subtotal)
                    .HasColumnType("money")
                    .HasColumnName("subtotal");

                entity.Property(e => e.Taxtotal)
                    .HasColumnType("money")
                    .HasColumnName("taxtotal");
            });

            modelBuilder.Entity<VctempOrderDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VCTempOrderDetail");

                entity.Property(e => e.Dateadded)
                    .HasColumnType("datetime")
                    .HasColumnName("dateadded");

                entity.Property(e => e.Discount)
                    .HasColumnType("money")
                    .HasColumnName("discount");

                entity.Property(e => e.Entryid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("entryid");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductPrice).HasColumnType("money");

                entity.Property(e => e.ProductSubId).HasColumnName("ProductSubID");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Tax)
                    .HasColumnType("money")
                    .HasColumnName("tax");

                entity.Property(e => e.TempOid).HasColumnName("temp_oid");
            });

            modelBuilder.Entity<Vsvaccount>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVAccount");

                entity.HasIndex(e => e.VsvaccountId, "IX_VSVAccount")
                    .IsUnique();

                entity.HasIndex(e => new { e.Email, e.Password }, "IX_VSVAccount_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.AcctName, e.VsvaccountId }, "IX_VSVAccount_2")
                    .IsUnique();

                entity.Property(e => e.AcctName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dmemail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DMEmail");

                entity.Property(e => e.Dmname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DMName");

                entity.Property(e => e.Dmphone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DMPhone");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SamplesAddress1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SamplesAddress2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SamplesCity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SamplesNiclevel).HasColumnName("SamplesNICLevel");

                entity.Property(e => e.SamplesState)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SamplesZip)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.Property(e => e.VsvaccountId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("VSVAccountID");
            });

            modelBuilder.Entity<Vsvaccountprodvideo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVaccountprodvideo");

                entity.HasIndex(e => e.AccountVidId, "IX_VSVaccountprodvideo")
                    .IsUnique();

                entity.Property(e => e.AccountVidId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AccountVidID");

                entity.Property(e => e.Shown)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Url)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("URL");

                entity.Property(e => e.VidId).HasColumnName("VidID");

                entity.Property(e => e.VsvaccountId).HasColumnName("VSVAccountID");

                entity.Property(e => e.VsvlocationId).HasColumnName("VSVLocationID");
            });

            modelBuilder.Entity<Vsvartist>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVArtist");

                entity.HasIndex(e => e.ArtistId, "IX_VSVArtist")
                    .IsUnique();

                entity.HasIndex(e => new { e.MusicId, e.ArtistName }, "IX_VSVArtist_1")
                    .IsUnique();

                entity.Property(e => e.ArtistId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ArtistID");

                entity.Property(e => e.ArtistName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MusicId).HasColumnName("MusicID");
            });

            modelBuilder.Entity<Vsvbrand>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVBrands");

                entity.HasIndex(e => e.BrandId, "IX_VSVBrand")
                    .IsUnique();

                entity.HasIndex(e => e.BrandName, "IX_VSVBrand_1");

                entity.HasIndex(e => new { e.ManId, e.BrandName }, "IX_VSVBrands")
                    .IsUnique();

                entity.Property(e => e.BrandId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BrandID");

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ManId).HasColumnName("ManID");
            });

            modelBuilder.Entity<VsventertainmentVideo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVEntertainmentVideo");

                entity.HasIndex(e => e.Evid, "IX_VSVEntertainmentVideo")
                    .IsUnique();

                entity.Property(e => e.Evid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EVID");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<VsventertainmentVideo1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVEntertainmentVideo1");

                entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                entity.Property(e => e.Evid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EVID");

                entity.Property(e => e.Mgid).HasColumnName("MGID");

                entity.Property(e => e.MusicId).HasColumnName("MusicID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("URL");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Vsvlocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVLocations");

                entity.HasIndex(e => new { e.VsvaccountId, e.LocationName }, "IX_VSVLocations")
                    .IsUnique();

                entity.HasIndex(e => e.VsvlocationId, "IX_VSVLocations_1")
                    .IsUnique();

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VsvaccountId).HasColumnName("VSVAccountID");

                entity.Property(e => e.VsvlocationId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("VSVLocationID");

                entity.Property(e => e.YouTubeChannel)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vsvmanufacturer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVManufacturer");

                entity.HasIndex(e => e.ManId, "IX_VSVManufacturer")
                    .IsUnique();

                entity.HasIndex(e => e.ManName, "IX_VSVManufacturer_2")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ManID");

                entity.Property(e => e.ManName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PromoEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SampleEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VsvmasterGenre>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVMasterGenre");

                entity.HasIndex(e => e.Mgid, "IX_VSVMasterGenre")
                    .IsUnique();

                entity.Property(e => e.GenreName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mgid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MGID");
            });

            modelBuilder.Entity<VsvmusicGenre>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVMusicGenre");

                entity.HasIndex(e => e.MusicId, "IX_VSVMusicGenre")
                    .IsUnique();

                entity.HasIndex(e => e.GenreName, "IX_VSVMusicGenre_1")
                    .IsUnique();

                entity.Property(e => e.GenreName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MusicId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MusicID");
            });

            modelBuilder.Entity<Vsvplay>(entity =>
            {
                entity.ToTable("VSVPlays");

                entity.HasIndex(e => e.VsvplayId, "IX_VSVPlays")
                    .IsUnique();

                entity.HasIndex(e => new { e.VidId, e.PlayTimeStamp, e.VsvlocationId }, "IX_VSVPlays_1")
                    .IsUnique();

                entity.Property(e => e.VsvplayId).HasColumnName("VSVPlayID");

                entity.Property(e => e.PlayTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.VidId).HasColumnName("VidID");

                entity.Property(e => e.VsvaccountId).HasColumnName("VSVAccountID");

                entity.Property(e => e.VsvlocationId).HasColumnName("VSVLocationID");
            });

            modelBuilder.Entity<VsvplaySummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVPlaySummary");

                entity.HasIndex(e => e.PlaySummaryId, "IX_VSVPlaySummary")
                    .IsUnique();

                entity.HasIndex(e => new { e.ManId, e.VidId, e.Year, e.Month }, "IX_VSVPlaySummary_1")
                    .IsUnique();

                entity.Property(e => e.DateSummary)
                    .HasColumnType("datetime")
                    .HasColumnName("dateSummary");

                entity.Property(e => e.ManId).HasColumnName("ManID");

                entity.Property(e => e.PlaySummaryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PlaySummaryID");

                entity.Property(e => e.VidId).HasColumnName("VidID");
            });

            modelBuilder.Entity<Vsvproduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVProducts");

                entity.HasIndex(e => e.VidId, "IX_VSVprodvideomaster")
                    .IsUnique();

                entity.HasIndex(e => new { e.ProdType, e.BrandName, e.ProductName }, "IX_VSVprodvideomaster_1")
                    .IsUnique();

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ELiquidIntroDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("eLiquidIntroDate");

                entity.Property(e => e.HardwareSubType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManId).HasColumnName("ManID");

                entity.Property(e => e.Private)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PrivateVsvaccountId).HasColumnName("PrivateVSVAccountID");

                entity.Property(e => e.ProdType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("URL");

                entity.Property(e => e.VidId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("VidID");
            });

            modelBuilder.Entity<Vsvpromo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVPromos");

                entity.HasIndex(e => e.PromosId, "IX_VSVPromos")
                    .IsUnique();

                entity.HasIndex(e => new { e.PromoStart, e.PromosId }, "IX_VSVPromos_1")
                    .IsUnique();

                entity.Property(e => e.BottleSize)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.ManId).HasColumnName("ManID");

                entity.Property(e => e.PromoEnd).HasColumnType("smalldatetime");

                entity.Property(e => e.PromoStart).HasColumnType("smalldatetime");

                entity.Property(e => e.PromosId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PromosID");

                entity.Property(e => e.TargetExisting)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TargetNew)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TheOffer)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.VidId).HasColumnName("VidID");
            });

            modelBuilder.Entity<VsvpromoLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVPromoLog");

                entity.HasIndex(e => e.LogId, "IX_VSVPromoLog")
                    .IsUnique();

                entity.HasIndex(e => new { e.ManId, e.BrandId, e.DateStamp }, "IX_VSVPromoLog_1");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.DateStamp).HasColumnType("smalldatetime");

                entity.Property(e => e.LogId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LogID");

                entity.Property(e => e.ManId).HasColumnName("ManID");

                entity.Property(e => e.TheOffer)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.VsvaccountId).HasColumnName("VSVAccountID");
            });

            modelBuilder.Entity<VsvpromoRequestSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVPromoRequestSummary");

                entity.HasIndex(e => e.PromoRequestSummaryId, "IX_VSVPromoRequestSummary")
                    .IsUnique();

                entity.HasIndex(e => new { e.ManId, e.BrandId, e.Year, e.Month }, "IX_VSVPromoRequestSummary_1")
                    .IsUnique();

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.DateSummary)
                    .HasColumnType("datetime")
                    .HasColumnName("dateSummary");

                entity.Property(e => e.ManId).HasColumnName("ManID");

                entity.Property(e => e.PromoRequestSummaryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PromoRequestSummaryID");
            });

            modelBuilder.Entity<VsvsampleLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVSampleLog");

                entity.HasIndex(e => e.LogId, "IX_VSVSampleLog")
                    .IsUnique();

                entity.HasIndex(e => new { e.ManId, e.BrandId, e.VidId, e.DateStamp, e.LogId }, "IX_VSVSampleLog_1")
                    .IsUnique();

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.DateStamp).HasColumnType("smalldatetime");

                entity.Property(e => e.LogId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LogID");

                entity.Property(e => e.ManId).HasColumnName("ManID");

                entity.Property(e => e.VidId).HasColumnName("VidID");

                entity.Property(e => e.VsvaccountId).HasColumnName("VSVAccountID");
            });

            modelBuilder.Entity<VsvsampleRequestSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVSampleRequestSummary");

                entity.HasIndex(e => e.SampleRequestSummaryId, "IX_VSVSampleRequestSummary")
                    .IsUnique();

                entity.HasIndex(e => new { e.ManId, e.VidId, e.Year, e.Month }, "IX_VSVSampleRequestSummary_1")
                    .IsUnique();

                entity.Property(e => e.DateSummary)
                    .HasColumnType("datetime")
                    .HasColumnName("dateSummary");

                entity.Property(e => e.ManId).HasColumnName("ManID");

                entity.Property(e => e.SampleRequestSummaryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SampleRequestSummaryID");

                entity.Property(e => e.VidId).HasColumnName("VidID");
            });

            modelBuilder.Entity<VsvshopIntro>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVShopIntro");

                entity.HasIndex(e => e.ShopIntroId, "IX_VSVIntro")
                    .IsUnique();

                entity.HasIndex(e => new { e.VsvaccountId, e.ShopIntroId }, "IX_VSVIntro_1")
                    .IsUnique();

                entity.Property(e => e.IntroUrl)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("IntroURL");

                entity.Property(e => e.ShopIntroId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ShopIntroID");

                entity.Property(e => e.VsvaccountId).HasColumnName("VSVAccountID");

                entity.Property(e => e.VsvlocationId).HasColumnName("VSVLocationID");
            });

            modelBuilder.Entity<VsvshopOutro>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVShopOutro");

                entity.HasIndex(e => e.ShopOutroId, "IX_VSVShopOutro")
                    .IsUnique();

                entity.HasIndex(e => new { e.VsvaccountId, e.ShopOutroId }, "IX_VSVShopOutro_1");

                entity.Property(e => e.OutroUrl)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("OutroURL");

                entity.Property(e => e.ShopOutroId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ShopOutroID");

                entity.Property(e => e.VsvaccountId).HasColumnName("VSVAccountID");

                entity.Property(e => e.VsvlocationId).HasColumnName("VSVLocationID");
            });

            modelBuilder.Entity<VsvshopWarning>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVShopWarning");

                entity.Property(e => e.ShopWarningId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ShopWarningID");

                entity.Property(e => e.WarningUrl)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("WarningURL");
            });

            modelBuilder.Entity<VsvstoreCountSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVStoreCountSummary");

                entity.HasIndex(e => e.StoreCountSummaryId, "IX_VSVStoreCountSummary")
                    .IsUnique();

                entity.HasIndex(e => new { e.ManId, e.VidId, e.Year, e.Month }, "IX_VSVStoreCountSummary_1")
                    .IsUnique();

                entity.Property(e => e.DateSummary)
                    .HasColumnType("datetime")
                    .HasColumnName("dateSummary");

                entity.Property(e => e.ManId).HasColumnName("ManID");

                entity.Property(e => e.StoreCountSummaryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("StoreCountSummaryID");

                entity.Property(e => e.VidId).HasColumnName("VidID");
            });

            modelBuilder.Entity<Vsvuser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVUser");

                entity.HasIndex(e => new { e.VsvaccountId, e.ListName, e.VsvuserId }, "IX_VSVUser")
                    .IsUnique();

                entity.Property(e => e.ListName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VsvaccountId).HasColumnName("VSVAccountID");

                entity.Property(e => e.VsvlocationId).HasColumnName("VSVLocationID");

                entity.Property(e => e.VsvuserId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("VSVUserID");
            });

            modelBuilder.Entity<VsvuserEvid>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVuserEVid");

                entity.Property(e => e.Evid)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("EVID");

                entity.Property(e => e.Vsvuevid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("VSVUEVID");

                entity.Property(e => e.VsvuserId).HasColumnName("VSVUserID");
            });

            modelBuilder.Entity<VsvuserVid>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVuserVid");

                entity.HasIndex(e => e.UserVidId, "IX_VSVuserVid")
                    .IsUnique();

                entity.HasIndex(e => new { e.VsvuserId, e.Title, e.UserVidId }, "IX_VSVuserVid_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.VsvuserId, e.Title, e.Url }, "IX_VSVuserVid_2")
                    .IsUnique();

                entity.Property(e => e.Evid).HasColumnName("EVID");

                entity.Property(e => e.Shown)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("URL");

                entity.Property(e => e.UserVidId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("UserVidID");

                entity.Property(e => e.VsvuserId).HasColumnName("VSVUserID");
            });

            modelBuilder.Entity<VsvuserVid09dec2020>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVuserVid_09dec2020");

                entity.Property(e => e.Evid).HasColumnName("EVID");

                entity.Property(e => e.Shown)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("URL");

                entity.Property(e => e.UserVidId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("UserVidID");

                entity.Property(e => e.VsvuserId).HasColumnName("VSVUserID");
            });

            modelBuilder.Entity<VsvuserVid1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VSVuserVid1");

                entity.Property(e => e.Evid).HasColumnName("EVID");

                entity.Property(e => e.Shown)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("URL");

                entity.Property(e => e.UserVidId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("UserVidID");

                entity.Property(e => e.VsvuserId).HasColumnName("VSVUserID");
            });

            modelBuilder.Entity<_2000>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("'2000$'");

                entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                entity.Property(e => e.Mgid).HasColumnName("MGID");

                entity.Property(e => e.MusicId).HasColumnName("MusicID");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("URL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
