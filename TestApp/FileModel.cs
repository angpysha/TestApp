using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using TestApp.Annotations;

namespace TestApp
{
    public enum FileStatus : int
    {
        ExistsInFirstForlder = 1,
        ExistsInSecondFolder = 2,
        ExistsInTwoFoldersDiffSize=3,
        ExistsInTwoFolders=4
    }
    public class FileModel : INotifyPropertyChanged
    {

        private string fileName;
        private string fileSize;
        private string fileDate;
        private FileStatus filestatus;

        public string FileName
        {
            get => fileName;
            set
            {
                fileName = value;
                OnPropertyChanged(nameof(FileName));
            }
        }

        public string FileSize
        {
            get => fileSize;
            set
            {
                fileSize = value;
                OnPropertyChanged(nameof(FileSize));
            }
        }

        public string FileDate
        {
            get => fileDate;
            set
            {
                fileDate = value;
                OnPropertyChanged(nameof(FileDate));
            }
        }

        public FileStatus FileStatus
        {
            get => filestatus;
            set
            {
                filestatus = value;
                OnPropertyChanged(nameof(FileStatus));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
