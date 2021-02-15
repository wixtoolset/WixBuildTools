// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixBuildTools.TestSupport
{
    using System.IO;

    public class LargeFile
    {
        private readonly string path;

        public static LargeFile Create(string path, long size)
        {
            using (var stream = File.Create(path))
            {
                stream.Seek(size - 1, SeekOrigin.Begin);
                stream.WriteByte(1);
            }

            return new LargeFile(path);
        }

        private LargeFile(string path) => this.path = path;

        public void Delete()
        {
            if (File.Exists(this.path))
            {
                File.Delete(this.path);
            }
        }
    }
}
