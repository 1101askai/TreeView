namespace TreeHierarchy.Migrations.DbContext
{
    using Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    /// <summary>
    /// Configuration relating to the use of migrations for a given model. 
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigrationsConfiguration{TreeHierarchy.DbContexts.DbContext}" />
    internal sealed class Configuration : DbMigrationsConfiguration<TreeHierarchy.DbContexts.DbContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations";
        }
        /// <summary>
        /// Runs after upgrading to the latest migration to allow seed data to be updated.
        /// </summary>
        /// <param name="context">Context to be used for updating seed data.</param>
        /// <remarks>
        /// Note that the database may already contain seed data when this method runs. This means that
        /// implementations of this method must check whether or not seed data is present and/or up-to-date
        /// and then only make changes if necessary and in a non-destructive way. The
        /// <see cref="M:System.Data.Entity.Migrations.DbSetMigrationsExtensions.AddOrUpdate``1(System.Data.Entity.IDbSet{``0},``0[])" />
        /// can be used to help with this, but for seeding large amounts of data it may be necessary to do less
        /// granular checks if performance is an issue.
        /// If the <see cref="T:System.Data.Entity.MigrateDatabaseToLatestVersion`2" /> database
        /// initializer is being used, then this method will be called each time that the initializer runs.
        /// If one of the <see cref="T:System.Data.Entity.DropCreateDatabaseAlways`1" />, <see cref="T:System.Data.Entity.DropCreateDatabaseIfModelChanges`1" />,
        /// or <see cref="T:System.Data.Entity.CreateDatabaseIfNotExists`1" /> initializers is being used, then this method will not be
        /// called and the Seed method defined in the initializer should be used instead.
        /// </remarks>
        protected override void Seed(TreeHierarchy.DbContexts.DbContext context)
        {
            var nodes = context.TreeNodes.ToList();
            if (nodes.Count() == 0)
            {
                TreeNode el = new TreeNode(0, "Creating digital images");
                context.TreeNodes.Add(el);
                context.SaveChanges();

                TreeNode res = new TreeNode(el.Id, "Resources");
                context.TreeNodes.Add(res);
                TreeNode evidence = new TreeNode(el.Id, "Evidence");
                context.TreeNodes.Add(evidence);
                TreeNode grProducts = new TreeNode(el.Id, "Graphic Products");
                context.TreeNodes.Add(grProducts);
                context.SaveChanges();


                TreeNode pSources = new TreeNode(res.Id, "Primary Sources");
                context.TreeNodes.Add(pSources);
                TreeNode sSources = new TreeNode(res.Id, "Secondary Sources");
                context.TreeNodes.Add(sSources);
                context.SaveChanges();


                TreeNode process = new TreeNode(grProducts.Id, "Process");
                context.TreeNodes.Add(process);
                TreeNode finalProducts = new TreeNode(grProducts.Id, "Final Product");
                context.TreeNodes.Add(finalProducts);
                context.SaveChanges();
            }
        }
    }
}