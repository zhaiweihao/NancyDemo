using Nancy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace NancyDemo_0726.Modules
{
    public class ImageModule:NancyModule
    {
        public ImageModule(IRootPathProvider rootPathProvider):base("/image")
        {
            Post["/add"] = param =>
              {
                  var uploadDirectory = Path.Combine(rootPathProvider.GetRootPath(),"Content","uploads");
                  if (!Directory.Exists(uploadDirectory))
                  {
                      Directory.CreateDirectory(uploadDirectory);
                  }
                  foreach (var file in Request.Files)
                  {
                      var filename = Path.Combine(uploadDirectory, file.Name);
                      using (FileStream fileStream = new FileStream(filename, FileMode.Create))
                      {
                          file.Value.CopyTo(fileStream);
                      }
                  }
                  return HttpStatusCode.OK;
              };
        }
    }
}