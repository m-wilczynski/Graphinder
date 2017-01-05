using System.Web.Mvc;

namespace Localwire.Graphinder.WebVisualizer.Controllers
{
    using System;
    using System.Net;
    using Core.Algorithms.SimulatedAnnealing;
    using Core.Algorithms.SimulatedAnnealing.CoolingStrategies;
    using Core.Algorithms.SimulatedAnnealing.Setup;
    using Core.Graph;
    using Core.Problems.OptimizationProblems;
    using Helpers.Graph;
    using Hubs;
    using Microsoft.AspNet.SignalR;
    using Models;

    public class AlgorithmsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SimulatedAnnealingPanel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StartSimulatedAnnealing(SimulatedAnnealingRequestViewModel algorithmRequest)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var graph = new Graph();
            graph.FillGraphRandomly(algorithmRequest.NumberOfNodesToGenerate, algorithmRequest.MaxNeighboursForNode);

            var hubContext = GlobalHost.ConnectionManager.GetHubContext<SimulatedAnnealingHub>();
            var algorithm = new SimulatedAnnealing(graph, new MinimumVertexCover(),
                new CoolingSetup(4000, 0.03, new AllRandomCooling()));
            
            algorithm.LaunchAlgorithm();
            algorithm.ProgressReportChanged.Subscribe(report =>
            {
                hubContext.Clients.Group(algorithm.Id.ToString()).send(report.AsReportViewModel());
            });

            return new JsonResult
            {
                Data = new { graph = graph.AsD3ViewModel(), hubId = algorithm.Id },
                ContentType = "application/x-javascript",
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}