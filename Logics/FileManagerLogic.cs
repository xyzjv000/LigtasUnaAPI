using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using ligtasUnaAPI.Models;

namespace ligtasUnaAPI.Logics
{
    public class FileManagerLogic : IFileManagerLogic
    {
        private readonly BlobServiceClient _blobServiceClient;
        public FileManagerLogic(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task Upload(File model)
        {
            var blobContainer = _blobServiceClient.GetBlobContainerClient("files");

            var blobClient = blobContainer.GetBlobClient(model.FileData.FileName);

            var blobUrl = blobClient.Uri.AbsoluteUri;

            await blobClient.UploadAsync(model.FileData.OpenReadStream());

        }

        public async Task<byte[]> Get(string imageName)
        {
            var blobContainer = _blobServiceClient.GetBlobContainerClient("files");

            var blobClient = blobContainer.GetBlobClient(imageName);
            var downloadContent = await blobClient.DownloadAsync();
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                await downloadContent.Value.Content.CopyToAsync(ms);
                return ms.ToArray();
            }
        }
    }
}
