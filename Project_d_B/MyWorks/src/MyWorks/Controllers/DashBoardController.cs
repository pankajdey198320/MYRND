using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWorks.Controllers
{

    public class DashBoardController : Controller
    {
        public string path { get; private set; }

        // GET: /<controller>/
        [Route("dashboard/{*pth}")]
        public IActionResult Index(string pth)
        {

            path = "C:\\Projects";
            if (!string.IsNullOrWhiteSpace(pth))
            {
                path += $"\\{pth}";
            }
            DirectoryInfo dir = new DirectoryInfo(path);
            var listDir = new List<DirFile>();
            if (Directory.Exists(path))
            {
                foreach (FileInfo flInfo in dir.GetFiles())
                {
                    var id = new Guid();
                    listDir.Add(new DirFile
                    {
                        Name = flInfo.Name,
                        Type = DirFile.FileType.file,
                        FileId = id.ToString()
                    });

                    TempData[id.ToString()] = new FileData()
                    {
                        Path = flInfo.FullName,
                        ID = id
                    };
                }

                foreach (DirectoryInfo flInfo in dir.GetDirectories())
                {
                    listDir.Add(new DirFile
                    {
                        Name = flInfo.Name,
                        Type = DirFile.FileType.folder
                    });
                    //String name = flInfo.Name;
                    //long size = flInfo.Length;
                    //DateTime creationTime = flInfo.CreationTime;
                    //x  Console.WriteLine("{0, -30:g} {1,-12:N0} {2} ", name, size, creationTime);
                }
            }
            return View(listDir);
        }

        public IActionResult DownLoadfile(Guid ID)
        {
            var path = TempData[ID.ToString()] as FileData;
            if (path != null)
                using (var x = System.IO.File.OpenRead(""))
                {
                    return File(path.Path, "multipart/form-data", Path.GetFileName(path.Path));
                }
            return null;
        }

        class FileData
        {
            public Guid ID { get; set; }
            public string Path { get; set; }
        }
    }

}
