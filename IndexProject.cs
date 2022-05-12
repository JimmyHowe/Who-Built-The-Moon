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
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace SkillsDevelopmentScotland.Demo.Functions
{
    public static class IndexProject
    {
        [FunctionName("IndexProject")]
        public static async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "projects")] HttpRequest request,
            ILogger log)
        {
            log.LogInformation("Index Project");

            ProjectRepository projectRepository = new ProjectTableRepository();

            return new OkObjectResult(await projectRepository.GetAll());
        }
    }
}
