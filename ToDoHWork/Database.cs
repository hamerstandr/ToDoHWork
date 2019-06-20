using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoHWork
{
    class Database
    {
        public readonly Tasks Data = new Tasks();
        readonly string PathFileData= Path.Combine(Environment.GetFolderPath(
    Environment.SpecialFolder.ApplicationData), typeof(App).Assembly.GetName().Name);
        public Database()
        {
            if(!Directory.Exists(PathFileData))
                Directory.CreateDirectory(PathFileData);
            PathFileData = Path.Combine(PathFileData, "Data.xml");
            Data = Tasks.Load<Tasks>(PathFileData);
            if (Data == null)
            {
                Data = new Tasks();
                Tasks.Save(Data, PathFileData);
            }
                
        }
        public void Add(Task _Task)
        {
            Data.Items.Add(_Task);
        }
        public void Add(string _Title)
        {
            Task _Task = new Task() { Complte = false, Title = _Title, Date = DateTime.Now };
            Data.Items.Add(_Task);
        }
        internal void Save(string Path="")
        {
            if (Path == "")
            {
                Path = PathFileData;
            }
            Tasks.Save(Data, Path);
        }

    }
}
