using GenAns.Services.Interfaces;
using GenAns.Data;
using Microsoft.Identity.Client;
using GenAns.Models.DTOs;
using Minio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GenAns.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IDataService _dataService;
        private readonly ApplicationContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMinioClient _client;

        public MaterialService(IDataService dataService, ApplicationContext context, IConfiguration configuration, IMinioClient client)
        {
            _dataService = dataService;
            _context = context;
            _configuration = configuration;
            _client = client;
        }

        public async Task<List<ShortMaterialDTO>> GetMinerals()
        {
            var result = new List<ShortMaterialDTO>();
            var mineralsEntity = await _context.Minerals.ToArrayAsync();
            var mineralsNames = new List<string>();

            var bucketName = _configuration.GetSection("MinioCredentials")["MineralBucketName"];
            foreach ( var m in mineralsEntity)
            {
                mineralsNames.Add(m.Name);
            }

            foreach ( var m in mineralsNames)
            {
                var mineral = await _dataService.GetFiles(new GetFileDTO
                {
                    BucketName = bucketName,
                    FileName = m
                });
            }
            return result;
        }
        public async Task CreateMineral(CreateMineralDTO mineral)
        {
            
        }
    }
}
