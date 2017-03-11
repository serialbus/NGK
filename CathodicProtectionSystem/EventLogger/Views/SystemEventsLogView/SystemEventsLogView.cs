using System;
using System.Collections.Generic;
using System.Text;
using Mvp.View;
using System.ComponentModel;
using Infrastructure.Api.Models;
using System.Windows.Forms;
using System.Data;
using Infrastructure.Dal.DbEntity;

namespace NGK.Plugins.Views
{
    public class SystemEventsLogView: PartialView<SystemEventsLog>
    {
        #region Fields And Properties

        public DockStyle Dock
        {
            get { return base.Control.Dock; }
            set { base.Control.Dock = value; }
        }

        public BindingList<ISystemEventMessage> SystemEvents
        {
            set { Control.SystemEvents = value; }
        }

        #endregion 
    }
}