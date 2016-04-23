namespace Localwire.Graphinder.Algorithms.DataAccess.EntityFramework
{
    using System.Data.Entity;
    using Entities.Algorithms;
    using Entities.Algorithms.GeneticAlgorithm;
    using Entities.Algorithms.SimulatedAnnealing;
    using Entities.Graph;
    using Entities.Problems;

    internal class AlgorithmContext : DbContext 
    {
        public AlgorithmContext() : base("name=Algorithms.Core.SqlServer")
        {
            Database.SetInitializer(new InitialConfiguration());
            this.Configuration.LazyLoadingEnabled = true;
        }

        public IDbSet<AlgorithmEntity> Algorithms { get; set; }
        public IDbSet<IndividualEntity> Individuals { get; set; }
        public IDbSet<GraphEntity> Graphs { get; set; }
        public IDbSet<NodeEntity> Nodes { get; set; } 
        public IDbSet<ProblemEntity> Problems { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AlgorithmEntity>().ToTable("Algorithm");
            modelBuilder.Entity<AlgorithmEntity>().HasRequired(a => a.Graph);
            modelBuilder.Entity<AlgorithmEntity>().HasRequired(a => a.Problem);

            modelBuilder.Entity<SimulatedAnnealingEntity>().ToTable("SimulatedAnnealing");
            modelBuilder.Entity<GeneticAlgorithmEntity>().ToTable("GeneticAlgorithm");
            modelBuilder.Entity<IndividualEntity>().ToTable("Individual");
            modelBuilder.Entity<GraphEntity>().ToTable("Graph");
            modelBuilder.Entity<NodeEntity>().ToTable("Node");

            modelBuilder.Entity<ProblemEntity>().ToTable("Problem");
            modelBuilder.Entity<MinimumVertexCoverEntity>().ToTable("MinimumVertexCover");

            modelBuilder.Entity<NodeEntity>()
                .HasMany(m => m.Neighbours)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("NodeId");
                    m.MapRightKey("NeighbourId");
                    m.ToTable("NodeNeighbourhood");
                });
        }

    }
}
