using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RainbowApp.Application.Model
{
    public partial class RainbowContext : DbContext
    {
        public RainbowContext()
        {
        }

        public RainbowContext(DbContextOptions<RainbowContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblMember> TblMembers { get; set; }
        public virtual DbSet<TblNotification> TblNotifications { get; set; }
        public virtual DbSet<TblServiceProvider> TblServiceProviders { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=rainbow-bridge.co3a9rtnyqgv.ap-northeast-2.rds.amazonaws.com,1433;Database=rainbow;Uid=rainbowsa;Pwd=anwlroakstp;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblMember>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__tblMembe__1788CC4C7F810C5C");

                entity.ToTable("tblMember");

                entity.Property(e => e.ChagedYmd).HasColumnType("datetime");

                entity.Property(e => e.CreatedYmd).HasColumnType("datetime");

                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MailAddr)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<TblNotification>(entity =>
            {
                entity.HasKey(e => e.NotiId);

                entity.ToTable("tblNotification");

                entity.Property(e => e.CreatedYmd).HasColumnType("datetime");

                entity.Property(e => e.NotiBody).HasMaxLength(255);

                entity.Property(e => e.NotiHeader).HasMaxLength(255);

                entity.Property(e => e.Url).HasMaxLength(255);
            });

            modelBuilder.Entity<TblServiceProvider>(entity =>
            {
                entity.HasKey(e => e.MgtNo)
                    .HasName("PK__tblServi__190CE2362A3F7730");

                entity.ToTable("tblServiceProvider");

                entity.Property(e => e.MgtNo).HasMaxLength(50);

                entity.Property(e => e.ApvCancelYmd).HasColumnType("datetime");

                entity.Property(e => e.ApvPermYmd).HasColumnType("datetime");

                entity.Property(e => e.BplcNm)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ClgEnddt).HasColumnType("datetime");

                entity.Property(e => e.ClgStdt).HasColumnType("datetime");

                entity.Property(e => e.DcbYmd).HasColumnType("datetime");

                entity.Property(e => e.DtlStateGbn).HasMaxLength(10);

                entity.Property(e => e.DtlStateNm).HasMaxLength(10);

                entity.Property(e => e.LocalCode)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PositionX).HasMaxLength(255);

                entity.Property(e => e.PositionY).HasMaxLength(255);

                entity.Property(e => e.RdnPostNo).HasMaxLength(50);

                entity.Property(e => e.RdnWhlAddr).HasMaxLength(255);

                entity.Property(e => e.Seq).ValueGeneratedOnAdd();

                entity.Property(e => e.SiteTel).HasMaxLength(50);

                entity.Property(e => e.TrdStateGbn)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TrdStateNm)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__tblUser__1788CC4CC34E8520");

                entity.ToTable("tblUser");

                entity.Property(e => e.ChagedYmd).HasColumnType("datetime");

                entity.Property(e => e.CreatedYmd).HasColumnType("datetime");

                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MailAddr)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PasswordResetYmd).HasColumnType("datetime");

                entity.Property(e => e.ResetToken).HasMaxLength(255);

                entity.Property(e => e.ResetTokenExpiredYmd).HasColumnType("datetime");

                entity.Property(e => e.VerificationToken).HasMaxLength(255);

                entity.Property(e => e.VerifiedYmd).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
