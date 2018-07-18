using DocflowApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DocflowApp.Files
{
    public interface IFileProvider
    {
        string Name { get; }

        void Save(BinaryFile file);

        FileStream Load(BinaryFile file);
    }
}