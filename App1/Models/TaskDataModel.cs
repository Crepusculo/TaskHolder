using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Utils;
using SQLite.Net.Attributes;

namespace App1.Models
{
    public class TaskDataModel : BaseDataModel
    {   
        /// <summary>
        /// JSON
        /// saves subtasks IDs
        /// </summary>
        
        public string SubTasks { get; set; }
        /// <summary>
        /// ProgressPrecent = WorkAmount/WorkProgress
        /// </summary>
        public int WorkAmount { get; set; }

        public int WorkProgress { get; set; }
        /// <summary>
        /// Task work group
        /// </summary>
        public string UserGroup { get; set; }
        /// <summary>
        /// Task Type
        /// </summary>
        [MaxLength(20)]
        public string Type{ get; set; }
        /// <summary>
        /// IF Repeat is false -> Interval == -1 
        /// </summary>
        public bool Repeat { get; set; }
        public int Interval { get; set; }

        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }

        public override string ToString()
        {
            return this.Id + "\t" + this.Name + "\t" + this.BelongsTo + "\t" + this.Points + "\n" +
                   this.Description + "\t" + this.Content + "\n" +
                   this.SubTasks + "\n" +
                   this.WorkProgress + "/" + this.WorkAmount + "\n" +
                   this.UserGroup + "\t" + this.Type + "\n" + this.Repeat + "\t" + this.Interval + "\n" +
                   this.StartTime + " to " + this.EndTime + "\n";
        }
    }

    class SubTaskDataModel
    {
        [PrimaryKey,AutoIncrement]
        private int Id { get; set; }
        private string Name { get; set; }
        private string Describe { get; set; }
        private int Progress { get; set; }
        private bool IsProgress { get; set; }
    }
}