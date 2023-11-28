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
    public partial class TextBox_KhongNhapSo_VaKyTuDacBiet : TextBox
    {
        public TextBox_KhongNhapSo_VaKyTuDacBiet()
        {
            this.KeyPress += TextBox_KhongNhapSo_VaKyTuDacBiet_KeyPress;
        }

        void TextBox_KhongNhapSo_VaKyTuDacBiet_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là chữ cái, khoảng trắng hoặc dấu gạch dưới (underscore) hay không
            if (char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == '_')
            {
                // Nếu là các ký tự được phép, cho phép nhập
                e.Handled = false;
                return;
            }
            else
            {
                // Nếu không phải là các ký tự được phép, không cho phép nhập
                e.Handled = true;
                return;
            }
        }
    }
}
