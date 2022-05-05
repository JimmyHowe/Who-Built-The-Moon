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
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest request,
            ILogger log)
        {
            if (!projects.ContainsKey("ypg"))
            {
                projects.Add("ypg", "Young Persons Guarentee");
            }

            log.LogInformation("YELLOW !!!!!");

            string project = request.Query["project"];
            string role = request.Query["role"];

            if (project != null)
            {
                project = projects.GetValueOrDefault(project, "N/A");
            }

            return new OkObjectResult($"Project: {project}. Role: {role}.");
        }
    }
}
