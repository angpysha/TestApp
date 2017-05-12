using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestApp.Annotations;

namespace TestApp
{
    public class ApplicationViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<FileModel> _files;

        public ObservableCollection<FileModel> Files
        {
            get => _files;
            set
            {
                _files = value;
                OnPropertyChanged(nameof(Files));
            }
        }

        public ApplicationViewModel(string path1,string path2)
        {
            var FilesC = new FilesClass(path1,path2);
            FilesC.getFiles();
            this.Files = FilesC.getData();
            int i = 0;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
