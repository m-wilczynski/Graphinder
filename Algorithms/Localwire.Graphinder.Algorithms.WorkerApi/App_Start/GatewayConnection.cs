namespace Localwire.Graphinder.Algorithms.WorkerApi
{
    using System;
    using System.Configuration;
    using System.Reactive.Linq;
    using System.Web.Configuration;
    using System.Web.Http.Routing.Constraints;

    /// <summary>
    /// Connects to Algorithms services gateway and registers itself
    /// </summary>
    public class GatewayConnection
    {
        private IDisposable _retrySubscription;

        public GatewayConnection()
        {
            _retrySubscription = AttemptToRegister();
        }

        private IDisposable AttemptToRegister()
        {
            int retryDelay = 0;
            try
            {
                retryDelay = Convert.ToInt32(WebConfigurationManager.AppSettings["GatewayRetryDelayInSeconds"]);
            }
            catch
            {
                throw new ConfigurationErrorsException("GatewayRetryDelayInSeconds has invalid value");
            }
            return Observable.Interval(TimeSpan.FromSeconds(retryDelay))
                .Subscribe(_ =>
                {
                    //Use RestSharp to connect to gateway
                });
        }
    }
}