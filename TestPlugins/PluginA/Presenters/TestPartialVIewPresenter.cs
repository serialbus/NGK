using System;
using System.Collections.Generic;
using System.Text;
using PluginsInfrastructure;
using PluginA.Views;

namespace PluginA.Presenters
{
    public class TestPartialViewPresenter: PartialViewPresenter<TestPartialView>
    {
        public TestPartialViewPresenter(): base()
        {
            View.ButtonClick += new EventHandler(
                delegate(object sender, EventArgs args) 
                { 
                    //this.Close();
                    this.Hide();
                });
        }

        public override string Title
        {
            get { return "Тестовое частичное представление"; }
        }

        public override void Close()
        {
            View.Close();
        }
    }
}
