using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SkillsDevelopmentScotland.Demo.Functions
{
    public static class WhoBuilt
    {
        static Dictionary<string, string> projects = new Dictionary<string, string>();

        [FunctionName("WhoBuilt")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest request,
            ILogger log)
        {
            log.LogInformation("YELLOW !!!!!");

            string project = request.Query["project"];
            string role = request.Query["role"];

            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            
            project = project ?? data?.project;
            role = role ?? data?.role;

            return new OkObjectResult($"Project: {project}. Role: {role}.");
        }
    }
}
