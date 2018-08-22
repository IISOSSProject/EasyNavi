using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EasyNavi.PluginInterfaces.Interfaces
{
    public interface IFileStragePath
    {
        DirectoryInfo BaseDirectory { get; }
        DirectoryInfo TempDirectory { get; }
        DirectoryInfo ImagesDirectory { get; }
        FileInfo TempFile { get; }
        FileInfo ContentsDataFile { get; }
    }
}
