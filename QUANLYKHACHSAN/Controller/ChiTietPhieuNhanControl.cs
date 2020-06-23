using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QUANLYKHACHSAN.DataPlayer;
using QUANLYKHACHSAN.BusinessObject;

namespace QUANLYKHACHSAN.Controller
{
    public class ChiTietPhieuNhanControl
    {
        ChiTietPhieuNhanPhongData data = new ChiTietPhieuNhanPhongData();
        public void HienThi(DataGridView dg, String id)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayChiTietPhieuNhan(id);
            dg.DataSource = bs;                       
        }

        public QUANLYKHACHSAN.BusinessObject.ChiTietPhieuNhanPhongInFo LayChiTietPhieuNhan(String id)
        {            
            QUANLYKHACHSAN.BusinessObject.ChiTietPhieuNhanPhongInFo ph = null;
            ph = new QUANLYKHACHSAN.BusinessObject.ChiTietPhieuNhanPhongInFo();
            DataTable tbl = data.LayChiTietPhieuNhan(id);
            PhongControl pctrl = new PhongControl();
            PhieuNhanPhongControl ptctrl = new PhieuNhanPhongControl();
            if (tbl.Rows.Count > 0)
            {
               
                ph.MaNhanPhong = Convert.ToString(tbl.Rows[0]["MaNhanPhong"]);
                ph.MaPhong= Convert.ToString(tbl.Rows[0]["MaPhong"]);
                ph.HoTenKhachHang = Convert.ToString(tbl.Rows[0]["HoTenKhachHang"]);
                ph.CMND = Convert.ToString(tbl.Rows[0]["CMND"]);
                ph.NgayNhan = Convert.ToDateTime(tbl.Rows[0]["NgayNhan"]);
                ph.NgayTraDuKien = Convert.ToDateTime(tbl.Rows[0]["NgayTraDuKien"]);                
                ph.NgayTraThucTe = Convert.ToDateTime(tbl.Rows[0]["NgayTraThucTe"]);
            }
            return ph;
        }

        public int TinhSoNgay(int songay)
        {
            DataTable tbl = data.LayDanhSachChiTietPhieuNhan();
            DateTime nnhan = Convert.ToDateTime(tbl.Rows[0]["NgayNhan"].ToString());
            DateTime ntra = Convert.ToDateTime(tbl.Rows[0]["NgayTraThucTe"].ToString());

            int soNgay = 0;
            if (nnhan.Year == ntra.Year)
                soNgay = ntra.DayOfYear - nnhan.DayOfYear;
            else
            {
                int soNam = ntra.Year - nnhan.Year;
                if (soNam == 1)
                {
                    if ((nnhan.Year % 400 == 0) || (nnhan.Year % 4 == 0 && nnhan.Year % 100 == 0))
                        soNgay = (366 - nnhan.DayOfYear) + ntra.DayOfYear;
                    else
                        soNgay = (365 - nnhan.DayOfYear) + ntra.DayOfYear;
                }
                else
                {
                    for (int i = 0; i < soNam - 1; i++)
                    {
                        if (((nnhan.Year + i) % 400 == 0) || ((nnhan.Year + i) % 4 == 0 && (nnhan.Year + i) % 100 == 0))
                            soNgay = soNgay + 366;
                        else
                            soNgay = soNgay + 365;
                    }
                    if ((nnhan.Year % 400 == 0) || (nnhan.Year % 4 == 0 && nnhan.Year % 100 == 0))
                        soNgay = (366 - nnhan.DayOfYear) + ntra.DayOfYear;
                    else
                        soNgay = (365 - nnhan.DayOfYear) + ntra.DayOfYear;

                }
            }
            if (soNgay == 0)
                soNgay = 1;

            return soNgay;

        }

        public void TimPhieuNhan(string cmnd)
        {
            data.LayChiTietPhieuNhan(cmnd.ToString());
        }

        public DataRow NewRow()
        {
            return this.data.NewRow();
        }

        public void Add(DataRow row)
        {
            this.data.Add(row);
        }

        public bool Save()
        {
            return this.data.Save();
        }

        public void Update()
        {
            BindingSource bs = new BindingSource();
            bs.MoveNext();
            data.Save();
        }

        public IList<ChiTietPhieuNhanPhongInFo> ChiTietPhieuNhan(String id)
        {
            KhachHangControl khctrl = new KhachHangControl();
            PhongControl pctrl = new PhongControl();
            IList<ChiTietPhieuNhanPhongInFo> ds = new List<ChiTietPhieuNhanPhongInFo>();

            DataTable tbl = data.LayChiTietPhieuNhan(id);
            foreach (DataRow row in tbl.Rows)
            {
                //PhongControl pctrl = new PhongControl();
                ChiTietPhieuNhanPhongInFo ct = new ChiTietPhieuNhanPhongInFo();
                ct.MaNhanPhong = Convert.ToString(row["MaNhanPhong"]);
                ct.HoTenKhachHang = Convert.ToString(row["HoTenKhachHang"]);
                ct.CMND = Convert.ToString(row["CMND"]);
                ct.NgayNhan = Convert.ToDateTime(row["NgayNhan"]);
                ct.NgayTraDuKien = Convert.ToDateTime(row["NgayTraDuKien"]);
                ct.NgayTraThucTe = Convert.ToDateTime(row["NgayTraThucTe"]);
                ct.MaPhong = Convert.ToString(row["MaPhong"]);

                ds.Add(ct);
            }
            return ds;
        }        
    }
}
