using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImprovementArsenalPlugin
{
    public class ImprovementArsenalSummaryInfo
    {
        public List<ImprovementArsenalInfo> IAInfoList { get; set; } = new List<ImprovementArsenalInfo>();
        public string EquipType { get; set; }
        public ImprovementArsenalSummaryInfo(string equipType)
        {
            EquipType = equipType;
        }
    }
}
