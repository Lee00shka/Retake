using GenAns.Models.DTOs;

namespace GenAns.Services.Interfaces
{
    public interface IDataService
    {
        public Task CreateDefaultBuckets();
        public Task CreateBucket(string name);
        public Task RemoveBucket(string name);
        public Task<FileDownloadDTO> GetFiles(GetFileDTO fileInfo);
        public Task<FileKyeDTO> UploadFile(UploadFileDTO fileInfo);
        public Task RemoveFiles(GetFileDTO fileInfo);
    }
}
