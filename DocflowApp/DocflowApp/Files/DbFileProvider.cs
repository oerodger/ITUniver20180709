using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using DocflowApp.Models;
using DocflowApp.Models.Repositories;

namespace DocflowApp.Files
{
    public class DbFileProvider : IFileProvider
    {
        private BinaryFileContentRepository binaryFileContentRepository;

        public DbFileProvider(BinaryFileContentRepository binaryFileContentRepository)
        {
            this.binaryFileContentRepository = binaryFileContentRepository;
        }

        public string Name => "Database";

        public FileStream Load(BinaryFile file)
        {
            var content = binaryFileContentRepository.GetByBinaryFile(file);
            if (content == null || content.Content == null)
            {
                return null;
            }
            var path = Path.GetTempFileName();
            var fileName = Path.GetFileNameWithoutExtension(path);
            var extension = Path.GetExtension(file.Name);
            var fullPath = Path.Combine(Path.GetDirectoryName(path), $"{fileName}{extension}");
            using (var stream = new FileStream(fullPath, FileMode.CreateNew))
            {
                stream.Write(content.Content, 0, content.Content.Length);
            }
            return new FileStream(fullPath, FileMode.Open);
        }

        public void Save(BinaryFile file)
        {
            if (file != null && file.PostedFile != null && file.PostedFile.ContentLength > 0)
            {
                var content = new BinaryFileContent
                {
                    BinaryFile = file,
                    Content = file.PostedFile.InputStream.ToByteArray()
                };
                binaryFileContentRepository.Save(content);
             }
        }
    }
}