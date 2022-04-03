using Microsoft.EntityFrameworkCore;

namespace OPD_EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public ApplicationContext()
        {
/*            Database.EnsureDeleted();
            Database.EnsureCreated();*/
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=testopd;Username=postgres;Password=ember12345");
        }
        public List<User> GetUsers()
        {
             return this.Users.ToList();
        }
        public User? GetUser(int id)
        {
           return this.Users.First(c => c.Id == id);
        }
        public void SetUser(User user)
        {
            this.Users.Add(user);
            this.SaveChanges();
        }
        public void DeleteUser(int id)
        {
            var user = GetUser(id);
            if (user == null)
            {
                return;
            }
            this.Users.Remove(user);
            this.SaveChanges();
        }
        public void UpdateUser(User user)
        {
            var u = GetUser(user.Id);
            if (u == null)
            {
                this.SetUser(user);
                return;
            }
            u.Name = user.Name;
            u.Email = user.Email;
            u.Password = user.Password;
            u.Created = user.Created;
            u.Updated = user.Updated;
            this.SaveChanges();
        }
        public List<Comment> GetComments()
        {
            return this.Comments.ToList();
        }
        public Comment? GetComment(int id)
        {
            return this.Comments.First(c => c.Id == id);
        }
        public void SetComment(Comment com)
        {
            this.Comments.Add(com);
            this.SaveChanges();
        }
        public void DeleteComment(int id)
        {
            var comm = GetComment(id);
            if (comm == null)
            {
                return;
            }
            this.Comments.Remove(comm);
            this.SaveChanges();
        }
        public void UpdatComment(Comment com)
        {
            var comm = GetComment(com.Id);
            if (comm == null)
            {
                this.SetComment(com);
                return;
            }
            com.Text = comm.Text;
            com.Created = comm.Created;
            com.Updated = comm.Updated;
            com.UserId = comm.UserId;
            this.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User u1 = new User { Id = 1, Name = "Tom", Email = "test@mail.ru", Password = "pass" };
            User u2 = new User { Id = 2, Name = "Alice", Email = "test@mail.ru", Password = "pass" };
            User u3 = new User { Id = 3, Name = "Sam", Email = "test@mail.ru", Password = "pass" };
            modelBuilder.Entity<User>().HasData(
             new User[]
             {
                u1,
                u2,
                u3
             });

            modelBuilder.Entity<Comment>().HasData(
                new Comment[]
                {
                    new Comment { Id = 1, Text = "Simple YEET", UserId = u1.Id},
                    new Comment { Id = 2, Text = "ADVANCED YEET", UserId = u1.Id},
                    new Comment { Id = 3, Text = "COOL YEET", UserId = u2.Id},
                    new Comment { Id = 4, Text = "???? YEET", UserId = u3.Id},
                });

            modelBuilder.Entity<User>()
                .Property(u => u.Created)
                .HasDefaultValueSql("current_timestamp");
            modelBuilder.Entity<User>()
                .Property(u => u.Updated)
                .HasDefaultValueSql("current_timestamp");


            modelBuilder.Entity<Comment>()
                .Property(u => u.Created)
                .HasDefaultValueSql("current_timestamp");
            modelBuilder.Entity<Comment>()
                .Property(u => u.Updated)
                .HasDefaultValueSql("current_timestamp");
        }
    }
}
