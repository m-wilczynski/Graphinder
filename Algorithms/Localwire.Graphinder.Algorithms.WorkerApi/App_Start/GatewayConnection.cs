namespace Localwire.Graphinder.Algorithms.WorkerApi
{
    using System;
    using System.Configuration;
    using System.Net;
    using System.Reactive.Linq;
    using System.Web;
    using System.Web.Configuration;
    using DTO.Administration.WorkerRegistration;
    using RestSharp;

    /// <summary>
    /// Connects to Algorithms services gateway and registers itself
    /// </summary>
    public class GatewayConnection
    {
        private readonly IDisposable _retrySubscription;
        private bool _shouldRetry = true;

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
                throw new ConfigurationErrorsException($"GatewayRetryDelayInSeconds has invalid value of {WebConfigurationManager.AppSettings["GatewayRetryDelayInSeconds"]}");
            }
            return Observable.Interval(TimeSpan.FromSeconds(retryDelay))
                .Subscribe(_ =>
                {
                    if (!_shouldRetry)
                    {
                        _retrySubscription.Dispose();
                    }
                    else
                    {
                        _shouldRetry = RegisterInGateway();
                    }
                });
        }

        private bool RegisterInGateway()
        {
            Uri gatewayAddress = null;
            string instanceName = null;
            try
            {
                gatewayAddress = new Uri(WebConfigurationManager.AppSettings["GatewayRegistrationAddress"]);
                instanceName = WebConfigurationManager.AppSettings["InstanceName"];
                if (string.IsNullOrEmpty(instanceName))
                    throw new ArgumentNullException();
            }
            catch
            {
                throw new ConfigurationErrorsException($"GatewayRegistrationAddress has invalid value of {WebConfigurationManager.AppSettings["GatewayAddress"]}");
            }
            var client = new RestClient(gatewayAddress);
            var request = new RestRequest(Method.POST);
            request.AddBody(new WorkerRegistration { WorkerName = instanceName });
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.Accepted)
                return false;
            return true;
        }
    }
}