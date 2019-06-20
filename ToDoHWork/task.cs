using System;
using System.Xml.Serialization;

namespace ToDoHWork
{
    public class Task
    {
        [XmlAttribute]
        public bool Complte { get; set ; }
        [XmlAttribute]
        public string Title { get ; set ; }
        [XmlAttribute]
        public DateTime Date { get; set; }

    }
}