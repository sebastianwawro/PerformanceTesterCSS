using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceTesterCSS.ViewModels.Performance
{
    public class ParticipationViewModel
    {
        public Int64 Id { get; set; }
        public String User { get; set; }
        public String Season { get; set; }
        public Boolean ConfPart { get; set; }
        public Boolean PaperPub { get; set; }
    }
}
