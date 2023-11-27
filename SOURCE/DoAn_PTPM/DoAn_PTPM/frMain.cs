using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_PTPM
{
    public partial class frMain : Form
    {
        public frMain()
        {
            InitializeComponent();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("Thông báo", "Thông báo");
        }

        private void ribbonPageGroup3_CaptionButtonClick(object sender, DevExpress.XtraBars.Ribbon.RibbonPageGroupEventArgs e)
        {
            MessageBox.Show("Thông báo", "Thông báo");

        }
    }
}
