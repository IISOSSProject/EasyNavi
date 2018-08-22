using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;

namespace EasyNavi.Core.Models
{
    class FileStrage : IFileStrage
    {
        public DirectoryInfo BaseDirectory { get; }
        public DirectoryInfo TempDirectory { get; }
        public DirectoryInfo ImagesDirectory { get; }
        public FileInfo TempFile { get; }
        public FileInfo NoMediaFile { get; }
        public FileInfo ContentsDataFile { get; }

        public FileStrage()
        {
            BaseDirectory = new DirectoryInfo(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), typeof(App).Namespace.Split('.')[0]));
            TempDirectory = new DirectoryInfo(Path.Combine(BaseDirectory.FullName, "temp"));
            ImagesDirectory = new DirectoryInfo(Path.Combine(BaseDirectory.FullName, "images", "jpeg"));
            TempFile = new FileInfo(Path.Combine(TempDirectory.FullName, "temp.zip"));
            NoMediaFile = new FileInfo(Path.Combine(ImagesDirectory.FullName, ".nomedia"));
            ContentsDataFile = new FileInfo(Path.Combine(ImagesDirectory.FullName, "ContentsData.zip"));
        }

        public void InitializeStorage()
        {
            foreach (var info in new[] { BaseDirectory, TempDirectory, ImagesDirectory })
                if (!info.Exists) info.Create();
            foreach (var info in new[] { NoMediaFile })
            {
                if (!info.Exists)
                    File.WriteAllText(info.FullName, string.Empty);
            }
        }

        public void UnzipImages(byte[] images)
        {
            InitializeStorage();
            Unzip(images, TempFile, ImagesDirectory);
        }
        private void Unzip(byte[] images, FileInfo tempFile, DirectoryInfo imagesDirectory)
        {
            File.WriteAllBytes(tempFile.FullName, images);
            using (var stream = tempFile.OpenRead())
            using (var archive = new ZipArchive(stream))
            {
                foreach (var entry in archive.Entries)
                {
                    var filename = Path.Combine(imagesDirectory.FullName, entry.Name);
                    using (var entryStream = entry.Open())
                    {
                        var q = new Queue<byte>();
                        int b;
                        while ((b = entryStream.ReadByte()) != -1) q.Enqueue((byte)b);
                        File.WriteAllBytes(filename, q.ToArray());
                    }
                }
            }
            tempFile.Delete();
        }

        public void WriteAllBytes(FileInfo file, byte[] data) => File.WriteAllBytes(file.FullName, data);
    }
}
