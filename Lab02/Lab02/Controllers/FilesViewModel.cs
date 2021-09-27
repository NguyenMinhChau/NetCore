using System.Collections.Generic;

namespace Lab02.Controllers
{
    internal class FilesViewModel
    {
        public FilesViewModel()
        {
        }
        public List<FileDetails> Files { get; set; } = new List<FileDetails>();
    }
}