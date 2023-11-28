using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class DAL_BLL_QLBAN
    {
        QL_QuanAnDataContext ql = new QL_QuanAnDataContext();
        public DAL_BLL_QLBAN()
        {

        }

        public List<BAN> getData()
        {
            return ql.BANs.Select(k => k).ToList<BAN>();
        }
        public void themban()
        {
            int soban = ql.BANs.Select(k => k.SOBAN).OrderByDescending(k => k).FirstOrDefault() + 1;

            // Lấy mã bàn tiếp theo
            string mabantieptheo;

            // Kiểm tra mã bàn cuối cùng trong danh sách
            var maxMaBan = ql.BANs.Select(k => k.MABAN).OrderByDescending(k => k).FirstOrDefault();
            if (string.IsNullOrEmpty(maxMaBan))
            {
                // Trường hợp danh sách rỗng, sử dụng chỉ số duy nhất
                mabantieptheo = "01";
            }
            else
            {
                // Lấy mã bàn cuối cùng và tăng giá trị lên 1
                int maxMaBanInt = int.Parse(maxMaBan);
                mabantieptheo = (maxMaBanInt + 1).ToString().PadLeft(2, '0');
            }

            // Thêm bàn vào CSDL
            BAN ban = new BAN()
            {
                SOBAN = soban,
                MABAN = mabantieptheo
            };

            ql.BANs.InsertOnSubmit(ban);
            ql.SubmitChanges();
        }



        public void xoaBan(string _maban)
        {
            BAN ban = ql.BANs.Where(k => k.MABAN == _maban).FirstOrDefault();
            if (ban != null)
            {
                //lấy vị trí bàn cần xóa
                int indexToDelete = ql.BANs.ToList().FindIndex(b => b.MABAN == _maban);

                //xóa bàn
                ql.BANs.DeleteOnSubmit(ban);

                //Giảm số bàn có số thứ tự lướn hơn vị trí cần xóa
                foreach (BAN b in ql.BANs)
                {
                    if (b.SOBAN > indexToDelete)
                    {
                        b.SOBAN--;
                    }
                }

                ql.SubmitChanges();
            }
        }
    }
}
