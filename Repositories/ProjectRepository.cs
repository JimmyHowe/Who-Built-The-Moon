using System.Threading.Tasks;
using System.Collections.Generic;

namespace SkillsDevelopmentScotland.Demo.Functions
{
    public interface ProjectRepository
    {
        /// <summary>
        /// Returns all School entries.
        /// </summary>
        /// <returns>List of school entries.</returns>
        public Task<List<SchoolEntity>> GetAll();

        /// <summary>
        /// Saves a school entry.
        /// </summary>
        /// <param name="schoolEntity"></param>
        /// <returns>TRUE if sucessful and FALSE if not.</returns>
        public Task<bool> Save(SchoolEntity schoolEntity);
    }
}
