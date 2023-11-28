using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_BLL;
namespace DoAn
{
    public partial class frm_QL_NV : DevExpress.XtraEditors.XtraForm
    {

        QL_QuanAnDataContext ql = new QL_QuanAnDataContext();
        BLL_DAL_NhomNguoiDung nnd = new BLL_DAL_NhomNguoiDung();
        DAL_BLL_QL_NguoiDung tk = new DAL_BLL_QL_NguoiDung();
        BLL_DAL_NhanVien nv = new BLL_DAL_NhanVien();
        BLL_DAL_NguoiDungNhomNguoiDung ndnnd = new BLL_DAL_NguoiDungNhomNguoiDung();
        public frm_QL_NV()
        {
            InitializeComponent();
        }

        private void frm_QL_NV_Load(object sender, EventArgs e)
        {
            var _maNhom = nnd.ListMaNhom();
            comboBox1.DataSource = _maNhom;

            dataGridView1.DataSource = tk.GetDataNguoiDung();
            dataGridView2.DataSource = ndnnd.GetData();

            var maNhanVienList = nv.LayMaNhanVien();

            cbbmanhanvien.DataSource = maNhanVienList;

            dataGridView3.DataSource = tk.GetDataNguoiDung();
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBox1.SelectedValue.ToString();
            var duplicateData = ndnnd.GetData().Where(data => data.MaNhomNguoiDung == selectedValue).ToList();
            dataGridView2.DataSource = duplicateData;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string _tendn = row.Cells[0].Value.ToString();
                string _maNhomNguoiDung = comboBox1.SelectedValue.ToString().Trim();

                if (!string.IsNullOrEmpty(_tendn) && !string.IsNullOrEmpty(_maNhomNguoiDung))
                {
                    bool kiemtra = ndnnd.kiemtra(_tendn, _maNhomNguoiDung);
                    if (!kiemtra)
                    {
                        ndnnd.themNguoiDungVaoNhom(_tendn, _maNhomNguoiDung);
                        dataGridView2.DataSource = ndnnd.GetData();
                    }
                    else
                    {
                        MessageBox.Show("Đã có người dùng trong nhóm.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn người dùng và nhóm người dùng.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                int selectedRowindex = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView2.Rows[selectedRowindex];
                string _tendn = selectedRow.Cells[0].Value.ToString();
                ndnnd.xoaNguoiDungKhoiNhom(_tendn);

                dataGridView2.DataSource = ndnnd.GetData();
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string tendangnhap = cbbmanhanvien.SelectedItem.ToString();

            // Kiểm tra nếu thông tin tài khoản đã tồn tại
            if (tk.GetDataNguoiDung().Any(nd => nd.TenDangNhap == tendangnhap))
            {
                // Thông báo lỗi nếu tài khoản đã tồn tại
                MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên đăng nhập khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Kết thúc sự kiện
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Nhập mật khẩu cho người dùng");
            }
            else
            {
                // Nếu thông tin tài khoản chưa tồn tại, tiến hành thêm tài khoản

                string matkhau = textBox1.Text;
                tk.ThemTaiKhoan(tendangnhap, matkhau);
                dataGridView1.DataSource = tk.GetDataNguoiDung();
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chưa chọn thông tin để xóa");
                return;
            }
            else
            {
                tk.XoaTaiKhoan(cbbmanhanvien.SelectedItem.ToString());
                dataGridView1.DataSource = tk.GetDataNguoiDung();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Sửa mật khẩu");
                return;
            }
            else
            {
                tk.SuaTaiKhoan(cbbmanhanvien.SelectedItem.ToString(), textBox1.Text);
                dataGridView1.DataSource = tk.GetDataNguoiDung();
            }
        }
    }
}