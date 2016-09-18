using System;
using System.Collections.Generic;
using System.Text;
using NGK.Log;
using Infrastructure.API.Services;

namespace Infrastructure.API.Managers
{
    public interface IManagers
    {
        /// <summary>
        /// ������ ��
        /// </summary>
        Version SoftwareVersion { get; }
        /// <summary>
        /// ������ ����������
        /// </summary>
        Version HardwareVersion { get; }
        /// <summary>
        /// �������� ��� ����������� ����������
        /// </summary>
        ILogManager Logger { get; set; }
        /// <summary>
        /// �������� ��� ������ ��������� ����������
        /// � ������ ������� ����������
        /// </summary>
        //ISysLogManager SystemLogger { get; }
        /// <summary>
        /// �������� ��� ������ � ������ ������������
        /// ����������
        /// </summary>
        IConfigManager ConfigManager { get; }
        /// <summary>
        /// ������ ��� ������ � CAN-������
        /// </summary>
        ICanNetworkService CanNetworkService { get; }
        /// <summary>
        /// ������ ��� ������ � Modbus-����� 
        /// (����� Slave: ��� ���������� ������ �������� ������ )
        /// </summary>
        //ISystemInformationModbusNetworkService ModbusSystemInfoNetworkService { get; }
    }
}