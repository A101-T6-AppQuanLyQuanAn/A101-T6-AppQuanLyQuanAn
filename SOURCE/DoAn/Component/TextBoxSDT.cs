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
    public partial class TextBoxSDT : TextBox
    {
        public TextBoxSDT()
        {
            this.KeyPress += TextBoxSDT_KeyPress;
        }

        void TextBoxSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là số và không phải ký tự điều hướng (phím mũi tên, backspace, delete)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\u001b')
            {
                // Không cho phép nhập ký tự không phải số
                e.Handled = true;
                return;
            }

            // Kiểm tra độ dài của chuỗi đã nhập
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text.Length >= 10 && e.KeyChar != '\b' && textBox.SelectionLength == 0)
            {
                // Nếu độ dài đã đạt tới giới hạn 10 ký tự và không phải là xóa ký tự hoặc chọn đoạn văn bản, không cho phép nhập thêm ký tự nữa
                e.Handled = true;
                return;
            }
        }
    }
}
