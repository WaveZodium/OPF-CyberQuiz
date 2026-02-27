using CyberQuiz.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CyberQuiz.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<SubCategory> SubCategories => Set<SubCategory>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<AnswerOption> AnswerOptions => Set<AnswerOption>();
        public DbSet<UserResult> UserResults => Set<UserResult>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //========================= konfiguration=========================

            // =========================
            // Category
            // =========================
            builder.Entity<Category>(e =>
            {
                e.Property(x => x.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                // Category (1) -> (many) SubCategory
                e.HasMany(x => x.SubCategories)//Category (1) → (många) SubCategory
                    .WithOne(x => x.Category)//SubCategory (många) → (1) Category
                    .HasForeignKey(x => x.CategoryId)//FK i SubCategory-tabellen
                    .OnDelete(DeleteBehavior.Cascade);//Om en kategori raderas så raderas alla dess subkategorier
                                                      //(och därmed också frågor/svar i de subkategorierna,
                                                      //pga Cascade på de relationerna).
            });

            // =========================
            // SubCategory
            // =========================
            builder.Entity<SubCategory>(e =>
            {
                e.Property(x => x.Name)//“Jag vill konfigurera egenskapen Name på den här entiteten.”
                    .HasMaxLength(120)
                    .IsRequired();

                // Ordning inom en kategori (så "nästa" blir förutsägbart)
                e.HasIndex(x => new { x.CategoryId, x.OrderIndex })//Skapar index på kombinationen (CategoryId, OrderIndex)
                    .IsUnique();//Unikt index på CategoryId + OrderIndex så att vi kan ha en bestämd ordning av
                                //subkategorier inom varje kategori.

                // SubCategory (1) -> (many) Question
                e.HasMany(x => x.Questions)
                    .WithOne(x => x.SubCategory)
                    .HasForeignKey(x => x.SubCategoryId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // =========================
            // Question
            // =========================
            builder.Entity<Question>(e =>
            {
                e.Property(x => x.Text)
                    .HasMaxLength(500)
                    .IsRequired();

                // Ordning inom en subkategori
                e.HasIndex(x => new { x.SubCategoryId, x.OrderIndex })
                    .IsUnique();

                // Question (1) -> (many) AnswerOption
                e.HasMany(x => x.AnswerOptions)
                    .WithOne(x => x.Question)
                    .HasForeignKey(x => x.QuestionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // =========================
            // AnswerOption
            // =========================
            builder.Entity<AnswerOption>(e =>
            {
                e.Property(x => x.Text)
                    .HasMaxLength(300)
                    .IsRequired();

                e.HasIndex(x => x.QuestionId);//“Skapa ett index i databasen på kolumnen QuestionId för den här tabellen.”
            });

            // =========================
            // UserResult
            // =========================
            builder.Entity<UserResult>(e =>
            {
                // Snabba queries för progress/80%
                e.HasIndex(x => x.UserId);//För att snabbt kunna hämta alla svar från en användare
                                          //(för progress-beräkning och historik).
                e.HasIndex(x => new { x.UserId, x.SubCategoryId });//För att snabbt kunna hämta alla svar från en användare inom en subkategori
                                                                   //(för progress-beräkning på subkategori-nivå).

                e.Property(x => x.AnsweredAtUtc)
                    .IsRequired();

                // FK -> Question
                e.HasOne(x => x.Question)//Varje UserResult hör till exakt en Question.
                    .WithMany()
                    .HasForeignKey(x => x.QuestionId)
                    .OnDelete(DeleteBehavior.Restrict);//betyder att vi kan inte radera
                                                       //en Question om det finns UserResult som pekar på den.

                // FK -> SubCategory
                e.HasOne(x => x.SubCategory)
                    .WithMany()
                    .HasForeignKey(x => x.SubCategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                // FK -> SelectedAnswerOption
                e.HasOne(x => x.SelectedAnswerOption)
                    .WithMany()
                    .HasForeignKey(x => x.SelectedAnswerOptionId)
                    .OnDelete(DeleteBehavior.Restrict);//Restrict på UserResult-relationerna så att
                                                       //vi inte råkar radera historik om vi t.ex. tar bort en fråga/svar.

                // FK -> Identity user.
                e.HasOne(r => r.User)
                    .WithMany()
                    .HasForeignKey(r => r.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
