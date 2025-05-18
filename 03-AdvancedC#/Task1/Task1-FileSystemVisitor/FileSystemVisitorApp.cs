using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_FileSystemVisitor
{
    public class FileSystemVisitorApp
    {
        private readonly string _rootDirectory;
        private readonly Func<FileSystemInfo, bool> _filter;

        public event EventHandler<WorkEventArgs> SearchStarted;
        public event EventHandler<WorkEventArgs> SearchFinished;
        public event EventHandler<FileSystemEventArgs> FileFound;
        public event EventHandler<FileSystemEventArgs> DirectoryFound;
        public event EventHandler<FileSystemEventArgs> FilteredFileFound;
        public event EventHandler<FileSystemEventArgs> FilteredDirectoryFound;
        private bool _abortSearch;

        public FileSystemVisitorApp(string rootDirectory, Func<FileSystemInfo, bool> filter = null)
        {
            _rootDirectory = rootDirectory ?? throw new ArgumentNullException(nameof(rootDirectory));
            _filter = filter ?? (_ => true); // Default filter (no filtering)
        }

        public IEnumerable<FileSystemInfo> Traverse()
        {
            if (Directory.Exists(_rootDirectory))
            {
                OnSearchStarted(new WorkEventArgs());

                foreach (var item in TraverseDirectory(new DirectoryInfo(_rootDirectory)))
                {
                    yield return item;
                }

                OnSearchFinished(new WorkEventArgs());
            }
            else
            {
                throw new DirectoryNotFoundException($"The directory '{_rootDirectory}' does not exist.");
            }
        }

        private IEnumerable<FileSystemInfo> TraverseDirectory(DirectoryInfo directoryInfo)
        {
            foreach (var directory in directoryInfo.GetDirectories())
            {
                if (_abortSearch)
                {
                    OnSearchFinished(new WorkEventArgs { AbortSearch = true });
                    yield break;
                }

                OnDirectoryFound(new FileSystemEventArgs(directory));

                if (_filter(directory))
                {
                    OnFilteredDirectoryFound(new FileSystemEventArgs(directory));
                    yield return directory;
                }
                else
                {
                    OnFilteredDirectoryFound(new FileSystemEventArgs(directory, exclude: true));
                }

                foreach (var subItem in TraverseDirectory(directory))
                {
                    yield return subItem;
                }
            }

            foreach (var file in directoryInfo.GetFiles())
            {
                if (_abortSearch)
                {
                    OnSearchFinished(new WorkEventArgs { AbortSearch = true });
                    yield break;
                }

                OnFileFound(new FileSystemEventArgs(file));

                if (file.Name.Equals("f2.txt", StringComparison.OrdinalIgnoreCase))
                {
                    _abortSearch = true;
                    OnSearchFinished(new WorkEventArgs { AbortSearch = true });
                    yield break;
                }
                if (_filter(file))
                {
                    OnFilteredFileFound(new FileSystemEventArgs(file));
                    yield return file;
                }
                else
                {
                    OnFilteredFileFound(new FileSystemEventArgs(file, exclude: true));
                }
            }
        }

        protected virtual void OnSearchStarted(WorkEventArgs e)
        {
            SearchStarted?.Invoke(this, e);
        }

        protected virtual void OnSearchFinished(WorkEventArgs e)
        {
            SearchFinished?.Invoke(this, e);
        }

        protected virtual void OnFileFound(FileSystemEventArgs e)
        {
            FileFound?.Invoke(this, e);
        }

        protected virtual void OnDirectoryFound(FileSystemEventArgs e)
        {
            DirectoryFound?.Invoke(this, e);
        }

        protected virtual void OnFilteredFileFound(FileSystemEventArgs e)
        {
            FilteredFileFound?.Invoke(this, e);
        }

        protected virtual void OnFilteredDirectoryFound(FileSystemEventArgs e)
        {
            FilteredDirectoryFound?.Invoke(this, e);
        }
    }

    public class WorkEventArgs : EventArgs
    {
        public bool AbortSearch { get; set; }
    }

    public class FileSystemEventArgs : EventArgs
    {
        public FileSystemInfo FileSystemInfo { get; }
        public bool Exclude { get; set; }

        public FileSystemEventArgs(FileSystemInfo fileSystemInfo, bool exclude = false)
        {
            FileSystemInfo = fileSystemInfo;
            Exclude = exclude;
        }
    }
}
