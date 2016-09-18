using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Api.Plugins;
using Mvp.WinApplication.Infrastructure;
using NGK.Plugins.Services;
using NGK.CAN.ApplicationLayer.Network.Master;
using Mvp.WinApplication.ApplicationService;
using Mvp.Input;
using NGK.Plugins.Presenters;
using Infrastructure.API.Managers;
using System.Windows.Forms;
using Mvp.Controls;
using Infrastructure.API.Models.CAN;

namespace NGK.Plugins
{
    public class NgkCanPlugin: Plugin
    {
        #region Constructors

        public NgkCanPlugin()
        {
            Name = @"Plugin CAN ��� ���";

            _ShowDevicesListCommand = new Command(OnShowDevicesList, CanShowDevicesList);
            _UpdateTotalDevicesCommand = new Command(OnUpdateTotalDevices, CanUpdateTotalDevices);
            _UpdateFaultyDevicesCommand = new Command(OnUpdateFaultyDevices, CanUpdateFaultyDevices);

            NavigationMenu = new NavigationMenuItem(Name, null);
            NavigationMenu.SubMenuItems.Add(new NavigationMenuItem("����������", _ShowDevicesListCommand));

            _BindableToolStripButtonTotalDevices = new BindableToolStripButton();
            _BindableToolStripButtonTotalDevices.Name = "_ToolStripButtonTotalDevices";
            _BindableToolStripButtonTotalDevices.Text = "����� ���������: ";
            _BindableToolStripButtonTotalDevices.ToolTipText = "����� ��������� � �������";
            _BindableToolStripButtonTotalDevices.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _BindableToolStripButtonTotalDevices.Action = _ShowDevicesListCommand;
            StatusBarItems.Add(_BindableToolStripButtonTotalDevices);

            BindableToolStripButton _BindableToolStripButtonFaultyDevices = 
                new BindableToolStripButton();
            _BindableToolStripButtonFaultyDevices = new BindableToolStripButton();
            _BindableToolStripButtonFaultyDevices.Name = "_ToolStripButtonFaultyDevices";
            _BindableToolStripButtonFaultyDevices.Text = "����������� ���������: ";
            _BindableToolStripButtonFaultyDevices.ToolTipText = "����������� ��������� � �������";
            _BindableToolStripButtonFaultyDevices.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _BindableToolStripButtonFaultyDevices.DataBindings.Add(
                new Binding("Enabled", _UpdateFaultyDevicesCommand, "Status"));
            StatusBarItems.Add(_BindableToolStripButtonFaultyDevices);

            CanNetworkService = null;
        }

        #endregion

        #region Fields And Properties

        private CanNetworkService _CanNetworkService;
        private readonly BindableToolStripButton _BindableToolStripButtonTotalDevices;
        private readonly BindableToolStripButton _BindableToolStripButtonFaultyDevices;

        private ToolStripButton ToolStripButtonTotalDevices
        {
            get { return _BindableToolStripButtonTotalDevices; }
        }

        internal CanNetworkService CanNetworkService
        {
            get { return _CanNetworkService; }
            set 
            { 
                _CanNetworkService = value;
                _ShowDevicesListCommand.CanExecute();

                if (_UpdateTotalDevicesCommand.CanExecute())
                    _UpdateTotalDevicesCommand.Execute();

                _UpdateFaultyDevicesCommand.CanExecute();
            }
        }
        
        #endregion 

        #region Methods

        public override void Initialize(IHostWindow hostWindow, IManagers managers, object state)
        {
            Managers = managers;
            HostWindow = hostWindow;

            // ������ ������� ����������
            try
            {
                // ��������� ������������ �� �����
                NgkCanNetworksManager.Instance.LoadConfig(Managers.ConfigManager.PathToAppDirectory +
                    @"\newtorkconfig.bin.nwc");

                //������ ������� ������ � ������������ ���
                CanNetworkService = new CanNetworkService(
                    "NgkCanService", NgkCanNetworksManager.Instance, 300, Managers);
                CanNetworkService.Initialize(null);
                base.ApplicationServices.Add(CanNetworkService);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    String.Format("������ ��� ������������� ������� {0}", Name), ex);
            }
        }

        public override void OnHostWindowSelectedPartivalViewPresenterChanged()
        {
            _ShowDevicesListCommand.CanExecute();
        }

        #endregion 

        #region Commands

        private Command _ShowDevicesListCommand;
        private void OnShowDevicesList()
        {
            DevicesListPresenter presenter = new DevicesListPresenter(this);
            presenter.Show();
        }
        private bool CanShowDevicesList()
        {
            return (CanNetworkService != null &&
                HostWindow.SelectedPartivalViewPresenter == null) ||
                (CanNetworkService != null &&
                HostWindow.SelectedPartivalViewPresenter != null &&
                !(HostWindow.SelectedPartivalViewPresenter is DevicesListPresenter));
        }

        private Command _UpdateTotalDevicesCommand;
        private void OnUpdateTotalDevices()
        {
            _BindableToolStripButtonTotalDevices.Text = 
                String.Format("����� ���������: {0}", CanNetworkService.Devices.Count);
        }
        private bool CanUpdateTotalDevices()
        {
            return CanNetworkService != null;
        }

        private Command _UpdateFaultyDevicesCommand;
        private void OnUpdateFaultyDevices()
        {
            _BindableToolStripButtonFaultyDevices.Text =
                String.Format("����������� ���������: {0}", CanNetworkService.Devices.Count);
        }
        private bool CanUpdateFaultyDevices()
        {
            return CanNetworkService != null;
        }

        #endregion
    }
}