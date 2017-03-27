using System;
using System.Collections.Generic;
using System.Text;
using Mvp.Plugin;
using Mvp.WinApplication;
using Mvp.WinApplication.Infrastructure;
using Infrastructure.Api.Managers;
using System.Windows.Forms;

namespace Infrastructure.Api.Plugins
{
    public abstract class Plugin : PluginBase, IPlugin
    {
        #region Constructors

        public Plugin()
        {
            _ApplicationServices = new List<IApplicationService>();
            _PartialPresenters = new List<IPartialViewPresenter>();
            _StatusBarItems = new List<ToolStripItem>();
        }

        #endregion

        #region Fields And Properties

        private readonly List<IApplicationService> _ApplicationServices;
        private readonly List<IPartialViewPresenter> _PartialPresenters;
        private readonly List<ToolStripItem> _StatusBarItems;
        private NavigationMenuItem _NavigationMenu;
        private IManagers _Managers;

        /// <summary>
        /// ������� ���������� ��������������� ��������
        /// </summary>
        protected IList<IApplicationService> ApplicationServices
        {
            get { return _ApplicationServices; }
        }
        /// <summary>
        /// �������� ������� �������������� ���� ���������������� ��������
        /// </summary>
        public NavigationMenuItem NavigationMenu
        {
            get { return _NavigationMenu; }
            protected set { _NavigationMenu = value; }
        }
        /// <summary>
        /// ��������� �������� ����� ��� ������� ����� ����������
        /// </summary>
        protected IList<IPartialViewPresenter> PartialPresenters
        {
            get { return _PartialPresenters; }
        }

        protected IList<ToolStripItem> StatusBarItems
        {
            get { return _StatusBarItems; }
        }

        public IManagers Managers
        {
            get { return _Managers; }
            protected set { _Managers = value; }
        }

        IEnumerable<IApplicationService> IPlugin.ApplicationServices
        {
            get { return _ApplicationServices; }
        }

        IEnumerable<IPartialViewPresenter> IPlugin.PartialPresenters
        {
            get { return _PartialPresenters; }
        }

        IEnumerable<ToolStripItem> IPlugin.StatusBarItems
        {
            get { return _StatusBarItems; }
        }

        #endregion

        #region Methods

        public virtual void Initialize(IManagers managers, object state)
        {
            _Managers = managers;
            _Managers.PartialViewService.Host.SelectedPartivalViewPresenterChanged +=
                new EventHandler(EventHandler_HostWindow_SelectedPartivalViewPresenterChanged);
        }

        private void EventHandler_HostWindow_SelectedPartivalViewPresenterChanged(object sender, EventArgs e)
        {
            OnHostWindowSelectedPartivalViewPresenterChanged();
        }

        public virtual void OnHostWindowSelectedPartivalViewPresenterChanged(){}

        #endregion         
    }
}