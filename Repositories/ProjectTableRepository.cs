using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;
using System;

namespace SkillsDevelopmentScotland.Demo.Functions
{
    public class ProjectTableRepository : TableRepository, ProjectRepository
    {
        public async Task<List<SchoolEntity>> GetAll()
        {
            TableContinuationToken token = null;
            var entities = new List<SchoolEntity>();
            do
            {
                var queryResult = await this.table.ExecuteQuerySegmentedAsync(new TableQuery<SchoolEntity>(), token);
                entities.AddRange(queryResult.Results);
                token = queryResult.ContinuationToken;
            } while (token != null);

            return entities;
        }

        public async Task<bool> Save(SchoolEntity schoolEntity)
        {
            TableOperation insert = TableOperation.Insert(schoolEntity);
            try
            {

                await this.table.ExecuteAsync(insert);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
