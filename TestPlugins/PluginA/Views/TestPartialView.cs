using System;
using System.Collections.Generic;
using System.Text;
using Mvp.View;
using System.Windows.Forms;

namespace PluginA.Views
{
    public class TestPartialView : PartialView<TestControl>
    {
        #region Constructors

        public TestPartialView()
        {
            base.Control._Button.Click += new EventHandler(EventHandler_Button_Click);
        }

        #endregion 

        #region Fields And Properties

        public DockStyle Dock
        {
            get { return base.Control.Dock; }
            set { base.Control.Dock = value; }
        }

        private void EventHandler_Button_Click(object sender, EventArgs args)
        {
            if (ButtonClick != null)
                ButtonClick(this, args);
        }

        #endregion

        #region Methods
        #endregion

        #region Events

        public EventHandler ButtonClick;

        #endregion 
    }
}