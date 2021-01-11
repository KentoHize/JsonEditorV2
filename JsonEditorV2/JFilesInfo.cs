using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonEditor
{
    public class JFilesInfo : IDisposable
    {
        public const string FilesInfoName = "JFilesInfo.json";

        public string Name { get; set; }
        public string DirectoryPath { get; set; }

        [JsonIgnore]
        public string FileInfoPath { get => Path.Combine(DirectoryPath, FilesInfoName); }
        public List<JTableInfo> TablesInfo { get; set; }

        public JFilesInfo()
            : this("")
        { }

        public JFilesInfo(string directoryPath)
            : this(directoryPath.Substring(directoryPath.LastIndexOf("\\") + 1), directoryPath)
        { }

        public JFilesInfo(string name, string directoryPath)
        {
            Name = name;
            DirectoryPath = directoryPath;
            TablesInfo = new List<JTableInfo>();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~JDirectoryInfo() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
