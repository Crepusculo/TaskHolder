using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace App1.Models
{
    class GoalDataModel : BaseDataModel
    {
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
        public string Type { get; set; }
        /// <summary>
        /// IF Repeat is false -> Interval == -1 
        /// </summary>

        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }

        public override string ToString()
        {
            return this.Id + "\t" + this.Name + "\t" + this.BelongsTo + "\t" + this.Points + "\n" +
                   this.Description + "\t" + this.Content + "\n" +
                   this.WorkProgress + "/" + this.WorkAmount + "\n" +
                   this.StartTime + " to " + this.EndTime + "\n";
        }
    }
}
