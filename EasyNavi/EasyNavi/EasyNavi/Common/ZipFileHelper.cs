using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasyNavi.Core.Common
{
    static class ZipFileHelper
    {
        public async static Task<string> ReadStringFromResource(Assembly assembly, string zipFileName, string zipEntryName)
        {
            return await Task.Run(async () =>
            {
                using (var stream = assembly.GetManifestResourceStream(zipFileName))
                using (var archive = new ZipArchive(stream))
                using (var entry = archive.GetEntry(zipEntryName).Open())
                using (var reader = new StreamReader(entry))
                    return await reader.ReadToEndAsync();
            });
        }

        public async static Task<byte[]> ReadBytesFromResource(Assembly assembly, string zipFileName, string zipEntryName)
        {
            return await Task.Run(() =>
            {
                using (var stream = assembly.GetManifestResourceStream(zipFileName))
                using (var archive = new ZipArchive(stream))
                using (var entry = archive.GetEntry(zipEntryName).Open())
                {
                    var q = new Queue<byte>();
                    int b;
                    while ((b = entry.ReadByte()) != -1) q.Enqueue((byte)b);
                    return q.ToArray();
                }
            });
        }

        public async static Task<string> ReadStringFromFile(FileInfo zipFile, string zipEntryName)
        {
            return await Task.Run(async () =>
            {
                using (var stream = zipFile.OpenRead())
                using (var archive = new ZipArchive(stream))
                using (var entry = archive.GetEntry(zipEntryName).Open())
                using (var reader = new StreamReader(entry))
                    return await reader.ReadToEndAsync();
            });
        }

        public async static Task<byte[]> ReadBytesFromFile(FileInfo zipFile, string zipEntryName)
        {
            return await Task.Run(() =>
            {
                using (var stream = zipFile.OpenRead())
                using (var archive = new ZipArchive(stream))
                using (var entry = archive.GetEntry(zipEntryName).Open())
                {
                    var q = new Queue<byte>();
                    int b;
                    while ((b = entry.ReadByte()) != -1) q.Enqueue((byte)b);
                    return q.ToArray();
                }
            });
        }

    }
}
