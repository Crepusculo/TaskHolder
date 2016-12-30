using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Models
{   
    /// <summary>
    /// 一颗成就树由一个单向拓扑图组成, 每个结点可以是一个公共任务, 可以是一个子成就树
    /// 子成就树递归展开以后必须为只有任务的结构
    /// 成就系统由多个成就树的森林组成
    /// </summary>
    class AchieveDataModel : BaseDataModel
    {
        // 任务的所有前驱
        private List<String> PrecursorList { get; set; }
        // 任务的所有后继
        private List<String> SuccessorList { get; set; }

        // 任务的所有可能终点
        private List<String> FinalTargetList { get; set; }
        // 任务的所有可能起点
        private List<String> StartPointList { get; set; }
        
        // 任务的前置条件
        private List<String> PreConfigurationList { get; set; }
        
        // 关联的 Task 列表
        private List<String> AssociatedTasksId { get; set; }
        // 关联的 Goal 列表
        private List<String> AssociatedGoalsId { get; set; }

        private Dictionary<string, int> AuthenticationMethodList { get; set; }
        private Dictionary<string, int> Type { get; set; }
    }
}
