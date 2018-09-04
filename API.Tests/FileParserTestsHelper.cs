using Microsoft.AspNetCore.Http;
using Moq;
using System.IO;

namespace Tests
{
    public static class FileParserTestsHelper
    {
        public static IFormFile AsMockIFormFile(this FileInfo physicalFile)
        {
            using (FileStream fileStream = File.OpenRead(physicalFile.FullName))
            {
                var fileMock = new Mock<IFormFile>();
                var ms = new MemoryStream();
                ms.SetLength(fileStream.Length);
                fileStream.Read(ms.GetBuffer(), 0, (int)fileStream.Length);
                ms.Position = 0;
                var fileName = physicalFile.Name;
                //Setup mock file using info from physical file
                fileMock.Setup(_ => _.FileName).Returns(fileName);
                fileMock.Setup(_ => _.Length).Returns(ms.Length);
                fileMock.Setup(m => m.OpenReadStream()).Returns(ms);
                fileMock.Setup(m => m.ContentDisposition).Returns(string.Format("inline; filename={0}", fileName));

                return fileMock.Object;
            }  
            
        }
    }
}
