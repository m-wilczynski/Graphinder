﻿namespace Localwire.Graphinder.Algorithms.DataAccess.EntityFramework
{
    using System.Data.Entity;
    using System.Linq;
    using Entities.Algorithms;
    using Entities.Algorithms.GeneticAlgorithm;
    using Entities.Algorithms.SimulatedAnnealing;
    using Entities.Graph;
    using Entities.Problems;
    using Mappers.Algorithms;

    internal class AlgorithmContext : DbContext 
    {
        public AlgorithmContext(IDatabaseConfiguration configuration) : base(configuration.ConnectionString)
        {
            Database.SetInitializer(new InitialConfiguration());
            this.Configuration.LazyLoadingEnabled = false;
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

    internal static class AlgorithmContextExtensions
    {
        public static IQueryable<AlgorithmEntity> EagerLoaded(this IDbSet<AlgorithmEntity> algorithms)
        {
            return algorithms
                .Include(a => a.Graph)
                .Include(a => a.Problem)
                .Include(a => a.Graph.Nodes)
                .Include(a => a.Graph.Nodes.Select(n => n.Neighbours))
                .Include(a => a.Problem.Graph);
        }

        public static IQueryable<ProblemEntity> EagerLoaded(this IDbSet<ProblemEntity> problems)
        {
            return problems.Include(p => p.Graph);
        }

        public static IQueryable<GraphEntity> EagerLoaded(this IDbSet<GraphEntity> graphs)
        {
            return graphs
                .Include(g => g.Nodes)
                .Include(g => g.Nodes.Select(n => n.Neighbours));
        } 
    }
}
