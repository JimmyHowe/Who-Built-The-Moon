

namespace SkillsDevelopmentScotland.Demo.Functions {

    public sealed class RepositoryFactory {

        public static ProjectRepository buildProjectRepository()
        {
            return new ProjectTableRepository();
        }
    }

}