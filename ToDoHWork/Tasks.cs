using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ToDoHWork
{
    [XmlRoot("Tasks", Namespace = "http://www.cpandl.com",
   IsNullable = false)]
    public class Tasks
    {
        [XmlArray("Items")]
        private List<Task> items = new List<Task>();

        public List<Task> Items { get => items; set => items = value; }

        public static void Save(object obj, string path)
        {
            try {
                XmlSerializer s = new XmlSerializer(obj.GetType());
                using (StreamWriter writer = new StreamWriter(path))
                {
                    s.Serialize(writer, obj);
                }
            } catch { }
            
        }

        public static T Load<T>(string path)
        {
            try
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                using (StreamReader reader = new StreamReader(path))
                {
                    object obj = s.Deserialize(reader);
                    return (T)obj;
                }
            }
            catch { return default; }
            

        }

    }
}
