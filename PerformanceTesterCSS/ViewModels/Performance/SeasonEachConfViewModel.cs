using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceTesterCSS.ViewModels.Performance
{
    public class SeasonEachConfViewModel
    {
        public String Season { get; set; }
        public List<PartEachConfViewModel> Participations { get; set; }
    }
}
