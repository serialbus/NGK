using System;
using System.Collections.Generic;
using System.Text;

//===================================================================================
namespace Modbus.OSIModel.ApplicationLayer.Slave.DataModel.DataTypes
{
    //===============================================================================
    /// <summary>
    /// ��� ������ (���������) ������ ������ modbus
    /// </summary>
    public enum ModbusParameterType
    {
        //---------------------------------------------------------------------------
        /// <summary>
        /// ��� ������ ����������
        /// </summary>
        Unknown,
        //---------------------------------------------------------------------------
        /// <summary>
        /// ������� ��������
        /// </summary>
        HoldingRegister,
        //---------------------------------------------------------------------------
        /// <summary>
        /// ������� �������
        /// </summary>
        InputRegister,
        //---------------------------------------------------------------------------
        /// <summary>
        /// ���������� ����/�����
        /// </summary>
        Coil,
        //---------------------------------------------------------------------------
        /// <summary>
        /// ���������� ����
        /// </summary>
        DiscreteInput,
        //---------------------------------------------------------------------------
        /// <summary>
        /// ������ ��������� � �����.
        /// </summary>
        Record,
        //---------------------------------------------------------------------------
    }
    //===============================================================================
}
//===================================================================================
// End of file