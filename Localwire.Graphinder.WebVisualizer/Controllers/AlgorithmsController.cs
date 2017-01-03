using System.Web.Mvc;

namespace Localwire.Graphinder.WebVisualizer.Controllers
{
    using System.Net;
    using Core.Graph;
    using Helpers.Graph;
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

            return new JsonResult
            {
                Data = graph.AsD3ViewModel(),
                ContentType = "application/x-javascript",
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}