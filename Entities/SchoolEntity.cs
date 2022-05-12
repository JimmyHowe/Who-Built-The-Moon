using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace SkillsDevelopmentScotland.Demo.Functions
{
    public class SchoolEntity : TableEntity
    {
        public SchoolEntity()
        {
        }

        public SchoolEntity(string level, string name)
        {
            PartitionKey = level;
            RowKey = name;
        }
    }
}