using System;
using System.Collections.Generic;
using System.Text;
using NGK.CAN.DataTypes;

namespace NGK.CAN.ApplicationLayer.Network.Devices.Profiles.ObjectDictionary
{
    /// <summary>
    /// ����� ��� �������� ������� ������� ����������
    /// </summary>
    public class ObjectInfo
    {
        #region Fields And Properties
        /// <summary>
        /// ����� �������
        /// </summary>
        public UInt16 Index;
        /// <summary>
        /// �������� �������
        /// </summary>
        public string Name;
        /// <summary>
        /// �������� �������
        /// </summary>
        public string Description;
        /// <summary>
        /// ������ ������ (������ �������� �������� � ������� ����������)
        /// </summary>
        public bool ReadOnly;
        /// <summary>
        /// 
        /// </summary>
        public bool SdoCanRead;
        /// <summary>
        /// ���������/��������� ����������� 
        /// ������� ������� � GUI
        /// </summary>
        public bool Visible;
        /// <summary>
        /// ������������ ������� � GUI
        /// </summary>
        public string DisplayedName;
        /// <summary>
        /// ������� ���������
        /// </summary>
        public string MeasureUnit;
        /// <summary>
        /// ��������� ������� �������
        /// </summary>
        public Category Category;
        /// <summary>
        /// ��� ������ �������� �������
        /// </summary>
        public DataConvertor DataType;
        /// <summary>
        /// �������� �� ��������
        /// </summary>
        public UInt32 DefaultValue;

        #endregion

        #region Constructors
        public ObjectInfo(UInt16 index, string name, string description,
            bool readOnly, bool sdoCanRead, bool visible, string displayedName,
            string measureUnit, Category category, DataConvertor convertor,
            UInt32 defaultValue)
        {
            Index = index;
            Name = name;
            Description = description;
            ReadOnly = readOnly;
            SdoCanRead = sdoCanRead;
            Visible = visible;
            DisplayedName = displayedName;
            MeasureUnit = measureUnit;
            Category = category;
            DataType = convertor;
            DefaultValue = defaultValue;
        }
        #endregion
    }
}
