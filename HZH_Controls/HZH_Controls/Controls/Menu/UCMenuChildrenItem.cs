﻿// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：UCMenuChildrenItem.cs
// 创建日期：2019-08-15 16:02:26
// 功能描述：Menu
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// 子类节点
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCMenuChildrenItem : UserControl, IMenuItem
    {
        public event EventHandler SelectedItem;

        private MenuItemEntity m_dataSource;
        public MenuItemEntity DataSource
        {
            get
            {
                return m_dataSource;
            }
            set
            {
                m_dataSource = value;
                if (value != null)
                {
                    lblTitle.Text = value.Text;
                }
            }
        }
        public UCMenuChildrenItem()
        {
            InitializeComponent();
            this.lblTitle.MouseDown += lblTitle_MouseDown;
        }

        void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (SelectedItem != null)
            {
                SelectedItem(this, null);
            }
        }

        public void SetStyle(Dictionary<string, object> styles)
        {
            Type t = this.GetType();
            foreach (var item in styles)
            {
                var pro = t.GetProperty(item.Key);
                if (pro != null && pro.CanWrite)
                {
                    try
                    {
                        pro.SetValue(this, item.Value, null);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("菜单元素设置样式异常", ex);
                    }
                }
            }
        }

        public void SetSelectedStyle(bool? blnSelected)
        {

        }
    }
}
