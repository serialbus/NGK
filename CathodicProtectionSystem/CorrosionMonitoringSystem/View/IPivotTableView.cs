using System;
using System.Collections.Generic;
using System.Text;
using Mvp.View;

namespace NGK.CorrosionMonitoringSystem.View
{
    public interface IPivotTableView: IView
    {
        Boolean ButtonF3IsAccessible { get; set; }
        Boolean ButtonF4IsAccessible{ get; set; }
        Boolean ButtonF5IsAccessible{ get; set; }

        event EventHandler<ButtonClickEventArgs> ButtonClick;
    }
}
