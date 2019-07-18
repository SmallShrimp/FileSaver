using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using X.FileSaver.Store;

namespace X.FileSaver.DemoApp.Controllers
{

    [RemoteService]
    [Area("file")]
    [Route("api/xfile/files")]
    public class FileController : AbpController
    {
        private IFileStoreManager _fileStoreManager;
        public FileController(IFileStoreManager fileStoreManager)
        {
            _fileStoreManager = fileStoreManager;
        }

        [HttpPost]
        [Route("upload")]
        public JsonResult UploadFile(IFormFile file)
        {

            // TODO 限制文件大小
            if (file == null)
            {
                throw new UserFriendlyException("No file found!");
            }
            if (file.Length <= 0)
            {
                throw new UserFriendlyException("File is empty!");
            }

            var output = _fileStoreManager.SaveFile(
                new FileInfo
                {
                    Bytes = file.GetAllBytes(),
                    FileName = file.FileName,
                    FileSize = file.Length,
                    FileType = file.ContentType
                }
            );
            output.Items.ForEach(m => m.Raw = null);
            return Json(output);
        }

        [HttpGet]
        [Route("www/{fileid}")]
        public FileResult GetForWebAsync(string fileid,string storeName)
        {
            var file =   _fileStoreManager.GetFile(fileid, storeName);
            return File(
                file.Bytes,
                file.FileType
            );
        }


    }
}
