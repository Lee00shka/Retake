using GenAns.Models.DTOs;
using GenAns.Services.Interfaces;
using Minio.DataModel.Args;
using Minio;

namespace GenAns.Services
{
    public class DataService : IDataService
    {
        private readonly IMinioClient _client;
        private readonly IConfiguration _configuration;
        public DataService(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new MinioClient()
                .WithEndpoint(_configuration.GetSection("MinioCredentials")["URL"])
                .WithCredentials(
                _configuration.GetSection("MinioCredentials")["Accsess"],
                _configuration.GetSection("MinioCredentials")["Secret"])
                .WithSSL(_configuration.GetSection("MinioCredentials")["SSL"] == "True")
                .Build();
        }

        public async Task CreateDefaultBuckets()
        {
            var bucketNames = new List<string?>
            {
                _configuration.GetSection("MinioCredentials")["MineralBucketName"],
                _configuration.GetSection("MinioCredentials")["RockBucketName"]
            };

            foreach (var bucket in bucketNames)
            {
                var beArgs = new BucketExistsArgs().WithBucket(bucket);
                if (!await _client.BucketExistsAsync(beArgs).ConfigureAwait(false))
                {
                    var mbArgs = new MakeBucketArgs().WithBucket(bucket);
                    await _client.MakeBucketAsync(mbArgs).ConfigureAwait(false);
                }
            }
        }

        public async Task CreateBucket(string name)
        {
            var beArgs = new BucketExistsArgs().WithBucket(name);
            if (!await _client.BucketExistsAsync(beArgs).ConfigureAwait(false))
            {
                var mbArgs = new MakeBucketArgs().WithBucket(name);
                await _client.MakeBucketAsync(mbArgs).ConfigureAwait(false);
            }
        }

        public async Task RemoveBucket(string name)
        {
            var beArgs = new BucketExistsArgs().WithBucket(name);
            if (await _client.BucketExistsAsync(beArgs).ConfigureAwait(false))
            {
                var rbArgs = new RemoveBucketArgs().WithBucket(name);
                await _client.RemoveBucketAsync(rbArgs).ConfigureAwait(false);
            }
        }

        public async Task<FileDownloadDTO> GetFiles(GetFileDTO fileInfo)
        {
            var file = new FileDownloadDTO();
            var stream = new MemoryStream();
            StatObjectArgs soArgs = new StatObjectArgs()
                .WithBucket(fileInfo.BucketName)
                .WithObject(fileInfo.FileName);
            await _client.StatObjectAsync(soArgs).ConfigureAwait(false);

            var goArgs = new GetObjectArgs()
                .WithBucket(fileInfo.BucketName)
                .WithObject(fileInfo.FileName)
                .WithFile(fileInfo.FileName)
                .WithCallbackStream(data =>
                {
                    data.CopyTo(stream);
                });
            var objStat = await _client.GetObjectAsync(goArgs).ConfigureAwait(false);
            file = new FileDownloadDTO
            {
                Name = fileInfo.FileName,
                ContentType = objStat.ContentType,
                Content = stream.ToArray()
            };

            return file;
        }

        public async Task<FileKyeDTO> UploadFile(UploadFileDTO fileInfo)
        {
            FileKyeDTO fileName = new();
            if (fileInfo.File.Length > 0)
            {
                await using var stream = fileInfo.File.OpenReadStream();
                var bucketName = fileInfo.BucketName;
                var id = Guid.NewGuid();
                var NewFileName = $"{bucketName}{id}{Path.GetExtension(fileInfo.File.FileName)}";
                fileName = new FileKyeDTO
                {
                    NewFileName = NewFileName,
                    PreviousFileName = fileInfo.File.FileName
                };
                var poArgs = new PutObjectArgs()
                    .WithBucket(bucketName)
                    .WithStreamData(stream)
                    .WithObjectSize(stream.Length)
                    .WithObject(NewFileName)
                    .WithContentType(fileInfo.File.ContentType);
                await _client.PutObjectAsync(poArgs).ConfigureAwait(false);
            }
            
            return fileName;
        }

        public async Task RemoveFiles(GetFileDTO fileInfo)
        {
            var objArgs = new RemoveObjectsArgs()
                .WithBucket(fileInfo.BucketName)
                .WithObjects(new List<string>{ fileInfo.FileName});
            await _client.RemoveObjectsAsync(objArgs).ConfigureAwait(false);
        }
    }
}
