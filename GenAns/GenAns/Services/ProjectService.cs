using GenAns.Data;
using GenAns.Services.Interfaces;

namespace GenAns.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationContext _context;
        private readonly IDataService _dataService;
        
        public ProjectService(ApplicationContext context, IDataService dataService)
        {
            _context = context;
            _dataService = dataService;
        }

        public void GetProject()
        {

        }
    }
}
