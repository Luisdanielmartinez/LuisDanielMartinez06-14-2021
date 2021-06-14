using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList.Models
{
    [SQLite.Table("TaskModel")]
    public   class TaskModel
    {
        [PrimaryKey]
        public int ID { get; set; } = (int) DateTime.Now.Hour;
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
        public DateTime Date { get; set; }
    }
}
