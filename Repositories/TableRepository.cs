using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace SkillsDevelopmentScotland.Demo.Functions
{
    public abstract class TableRepository
    {
        protected CloudStorageAccount account;
        protected CloudTableClient client;
        protected CloudTable table;

        protected TableRepository()
        {
            this.account = new CloudStorageAccount(
                new StorageCredentials(
                    "whobuiltthemoon",
                    "QYIvaAd/l0fknphMvCQyZJH+GNmR9AkfJVBfqiagy7vz4ouq2es8ai0ppIPDLW1CUjdildav4OgkyEQ5vE/JVg=="),
                    false
                );
            this.client = account.CreateCloudTableClient();
            this.table = client.GetTableReference("projects");
        }
    }
}
