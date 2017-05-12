using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class FilesClass
    {
        private readonly List<FileInfo> fileInfos1;
        private readonly List<FileInfo> fileInfos2;
        private ObservableCollection<FileModel> fileModels = new ObservableCollection<FileModel>();
        public FilesClass(string path1, string path2)
        {
            var dirInfo1 = new DirectoryInfo(path1);
            var dirInfo2 = new DirectoryInfo(path2);
            fileInfos1 = dirInfo1.GetFiles().ToList();
            fileInfos2 = dirInfo2.GetFiles().ToList();

        }

        public void getFiles()
        {
            foreach (var info1 in fileInfos1)
            {
                if (!fileInfos2.Any(x => x.Name == info1.Name))
                {
                   // if (fileModels.Any(x => x.FileName != info1.Name))
                   // {
                        fileModels.Add(new FileModel
                        {
                            FileName = info1.Name,
                            FileDate = info1.LastWriteTime.ToShortDateString(),
                            FileSize = info1.Length.ToString(),
                            FileStatus = FileStatus.ExistsInFirstForlder
                        });
                  //  }
                }
            }

            foreach (var info2 in fileInfos2)
            {
                if (!fileInfos1.Any(x => x.Name == info2.Name))
                {
                    fileModels.Add(new FileModel
                    {
                        FileName = info2.Name,
                        FileDate = info2.LastWriteTime.ToShortDateString(),
                        FileSize = info2.Length.ToString(),
                        FileStatus = FileStatus.ExistsInSecondFolder
                    });
                }
                else
                {
                   var info1_t = fileInfos1.Find(x=>x.Name==info2.Name);
                    if (info1_t.Length == info2.Length)
                    {
                        fileModels.Add(new FileModel
                        {
                            FileName = info2.Name,
                            FileDate = info2.LastWriteTime.ToShortDateString(),
                            FileSize = info2.Length.ToString(),
                            FileStatus = FileStatus.ExistsInTwoFolders
                        });
                    }
                    else
                    {
                        fileModels.Add(new FileModel
                        {
                            FileName = info2.Name,
                            FileDate = info2.LastWriteTime.ToShortDateString(),
                            FileSize = info2.Length.ToString(),
                            FileStatus = FileStatus.ExistsInTwoFoldersDiffSize
                        });

                        fileModels.Add(new FileModel
                        {
                            FileName = info1_t.Name,
                            FileDate = info1_t.LastWriteTime.ToShortDateString(),
                            FileSize = info1_t.Length.ToString(),
                            FileStatus = FileStatus.ExistsInTwoFoldersDiffSize
                        });
                    }
                }
            }
        }

        public ObservableCollection<FileModel> getData()
        {
            return this.fileModels;
        }

    }
}
