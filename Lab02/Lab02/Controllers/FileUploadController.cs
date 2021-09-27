using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lab02.Models;

namespace Lab02.Controllers
{
    public class FileUploadController : Controller
    {
        private readonly IFileProvider fileProvider;

        public FileUploadController(IFileProvider fileProvider) { 
            this.fileProvider = fileProvider; 
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");
            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot", "UploadFiles", 
                file.GetFilename()
            );
            using (var stream = new FileStream(path, FileMode.Create)) { 
                await file.CopyToAsync(stream); 
            }
            return RedirectToAction("ListFiles");
        }
        [HttpPost] 
        public async Task<IActionResult> UploadFiles(List<IFormFile> files) { 
            if (files == null || files.Count == 0) 
                return Content("files not selected"); 
            foreach (var file in files) { 
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadFiles", 
                    file.GetFilename()
                ); 
                using (var stream = new FileStream(path, FileMode.Create)) { 
                    await file.CopyToAsync(stream); } 
            } 
            return RedirectToAction("ListFiles"); 
        }
        [HttpPost]
        public async Task<IActionResult> UploadFileViaModel(FileInputModel model)
        {
            if (model == null || model.FileToUpload == null || model.FileToUpload.Length == 0) 
                return Content("file not selected"); 
            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot", "UploadFiles", 
                model.FileToUpload.GetFilename()
            ); 
            using (var stream = new FileStream(path, FileMode.Create)) { 
                await model.FileToUpload.CopyToAsync(stream); 
            }
            return RedirectToAction("ListFiles");
        }
        public IActionResult ListFiles()
        {
            var model = new FilesViewModel();
            foreach(var item in this.fileProvider.GetDirectoryContents("UploadFiles"))
            {
                model.Files.Add(new FileDetails { Name = item.Name, Path = item.PhysicalPath });
            }
            return View(model);
        }
    }
}
