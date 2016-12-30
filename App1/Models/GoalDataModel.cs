using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Models
{
    class GoalDataModel : BaseDataModel
    {
        private List<SubTaskDataModel> SubTasks { get; set; }
        private int Progress { get; set; }
        private List<string> UserGroup { get; set; }
        private Dictionary<string, int> Type { get; set; }
        private DateTime StartTime { get; set; }
        private DateTime DeadLine { get; set; }
    }

    class SubGoalDataModel
    {
        private string Name { get; set; }
        private string Describe { get; set; }
        private int Progress { get; set; }
        private bool IsProgress { get; set; }
    }
}
