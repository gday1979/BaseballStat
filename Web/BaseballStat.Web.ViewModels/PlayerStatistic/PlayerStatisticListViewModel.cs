﻿namespace BaseballStat.Web.ViewModels.PlayerStatistic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PlayerStatisticListViewModel
    {
        public IEnumerable<PlayerStatisticViewModel> PlayerStatistics { get; set; }
    }
}