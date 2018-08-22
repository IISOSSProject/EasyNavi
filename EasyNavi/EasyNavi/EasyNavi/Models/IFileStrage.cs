using EasyNavi.PluginInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EasyNavi.Core.Models
{
    interface IFileStrage : IFileStragePath
    {
        FileInfo NoMediaFile { get; }

        void InitializeStorage();

        void UnzipImages(byte[] images);

        void WriteAllBytes(FileInfo file, byte[] data);
    }
}
