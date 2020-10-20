using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAppDemo.HealthChecks
{
    public class ResponseTimeHealthCheck : IHealthCheck
    {
        public static Random Random => new Random();
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            //Do your Checks
            //...         
            //
            //This the sample example in the current health context
            var resTimeInMS = Random.Next(1, 500);
            if (resTimeInMS < 200)
                return Task.FromResult(HealthCheckResult.Healthy($"The response perfect. Time :{resTimeInMS}"));
            else if (resTimeInMS < 300)
                return Task.FromResult(HealthCheckResult.Degraded($"The response time is a bit slow. Time :{resTimeInMS}"));
            else
                return Task.FromResult(HealthCheckResult.Unhealthy($"Oppss! The response time not good. Time :{resTimeInMS}"));
        }
    }
}
