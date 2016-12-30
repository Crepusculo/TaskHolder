using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Models
{
    class PlayStoreDataModel:BaseDataModel
    {
        private List<SubTaskDataModel> SubTasks { get; set; }
        private int Progress { get; set; }
        private List<string> UserGroup { get; set; }
        private Dictionary<string, int> Type { get; set; }
    }
   

}
