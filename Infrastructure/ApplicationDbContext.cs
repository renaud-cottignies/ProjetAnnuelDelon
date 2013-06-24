using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domaine.Common;
using Domaine.CoursService;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cours> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<UserRelation> UsersRelations { get; set; }


        public ApplicationDbContext()
            : base("ProjetAnnuel")
        {

        }
    }
}