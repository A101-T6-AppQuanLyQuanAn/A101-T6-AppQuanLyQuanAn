using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Component
{
    public partial class TextBox_KhongNhanKyTuDacBiet : TextBox
    {
        ErrorProvider ep;
        public TextBox_KhongNhanKyTuDacBiet()
        {
            ep = new ErrorProvider();
            this.KeyPress += TextBox_KhongNhanKyTuDacBiet_KeyPress;
        }

        void TextBox_KhongNhanKyTuDacBiet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar)) //Kiểm tra xem có ký tự đặc biệt  không
            {
                ep.SetError((Control)sender, "Không được nhập ký tự đặc biệt");
                e.Handled = true; // Ngăn không cho ký tự đặc biệt được nhập
            }
            else
            {
                ep.Clear(); //Xóa thông báo lỗi
            }
        }
    }
}
