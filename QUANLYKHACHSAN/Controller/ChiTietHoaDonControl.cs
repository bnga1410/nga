using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using QUANLYKHACHSAN.DataPlayer;
using QUANLYKHACHSAN.BusinessObject;
using System.Data;
using System.Windows.Forms;

namespace QUANLYKHACHSAN.Controller
{
    public class ChiTietHoaDonControl
    {
        ChiTietHoaDonData data = new ChiTietHoaDonData();


        public IList<ChiTietHoaDonInFo> ChiTietHoaDon(String id)
         {
             IList<ChiTietHoaDonInFo> ds = new List<ChiTietHoaDonInFo>();

             DataTable tbl = data.LayMaChiTietHoaDon(id);
             foreach (DataRow row in tbl.Rows)
             {
                 HoaDonControl hdctrl = new HoaDonControl();
                 ChiTietPhieuNhanControl ctpnctrl = new ChiTietPhieuNhanControl();
                 PhongControl pctrl = new PhongControl();
                 ChiTietHoaDonInFo ct = new ChiTietHoaDonInFo();
                 DanhSachSuDungDichVuControl dsdvctrl = new DanhSachSuDungDichVuControl();
                 ChinhSachTraControl cstctrl = new ChinhSachTraControl();
                 
                 ct.MaHoaDon = hdctrl.LayHoaDon(Convert.ToString(row["MaHoaDon"]));
                 ct.MaPhong = pctrl.LayMaPhong(Convert.ToString(row["MaPhong"]));
                 ct.TienPhong = Convert.ToSingle(row["TienPhong"]);
                 ct.SoNgay = Convert.ToInt32(row["SoNgay"]);
                 ct.MaDichVu = dsdvctrl.LayDSSuDungDVu(Convert.ToString(row["MaDichVu"]));
                 ct.TienDichVu = Convert.ToSingle(row["TienDichVu"]);
                 ct.GiamGiaKH = Convert.ToSingle(row["GiamGiaKH"]);
                 ct.HinhThucThanhToan = Convert.ToString(row["HinhThucThanhToan"]);
                 ct.MaChinhSach = cstctrl.LayMaChinhSach(Convert.ToString(row["MaChinhSach"]));
                 ct.ThanhTien = Convert.ToSingle(row["ThanhTien"]);
                 ct.PhuThu = Convert.ToSingle(row["PhuThu"]);

                 ds.Add(ct);
             }
             return ds;
         }

        public QUANLYKHACHSAN.BusinessObject.ChiTietHoaDonInFo LayMaChietHoaDon(string mahd)
        {
            HoaDonControl hdctrl = new HoaDonControl();
            ChiTietPhieuNhanControl ctpnctrl = new ChiTietPhieuNhanControl();
            PhongControl pctrl = new PhongControl();
            //ChiTietHoaDonInFo ct = new ChiTietHoaDonInFo();
            DanhSachSuDungDichVuControl dsdvctrl = new DanhSachSuDungDichVuControl();
            ChinhSachTraControl cstctrl = new ChinhSachTraControl();
            QUANLYKHACHSAN.BusinessObject.ChiTietHoaDonInFo ct = null;
            ct = new QUANLYKHACHSAN.BusinessObject.ChiTietHoaDonInFo();
            DataTable tbl = data.LayMaChiTietHoaDon(mahd);
            if (tbl.Rows.Count > 0)
            {
                ct.MaHoaDon = hdctrl.LayHoaDon(Convert.ToString( tbl.Rows[0]["MaHoaDon"]));
                ct.MaPhong = pctrl.LayMaPhong(Convert.ToString(tbl.Rows[0]["MaPhong"]));
                ct.TienPhong = Convert.ToSingle(tbl.Rows[0]["TienPhong"]);
                ct.SoNgay = Convert.ToInt32(tbl.Rows[0]["SoNgay"]);
                ct.MaDichVu = dsdvctrl.LayDSSuDungDVu(Convert.ToString(tbl.Rows[0]["MaDichVu"]));
                ct.TienDichVu = Convert.ToSingle(tbl.Rows[0]["TienDichVu"]);
                ct.GiamGiaKH = Convert.ToSingle(tbl.Rows[0]["GiamGiaKH"]);
                ct.HinhThucThanhToan = Convert.ToString(tbl.Rows[0]["HinhThucThanhToan"]);
                ct.MaChinhSach = cstctrl.LayMaChinhSach(Convert.ToString(tbl.Rows[0]["MaChinhSach"]));
                ct.ThanhTien = Convert.ToSingle(tbl.Rows[0]["ThanhTien"]);
                ct.PhuThu = Convert.ToSingle(tbl.Rows[0]["PhuThu"]);

            }
            return ct;

        }

        public void HienThiChiTietHoaDon(DataGridView dg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LaydanhSachChiTietHoaDon();
            dg.DataSource = bs;
            bn.BindingSource = bs;
        }

        public void HienThi(DataGridView dg, string id)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayMaChiTietHoaDon(id);
            dg.DataSource = bs;            
        }            
          
        public void Update()
        {
            BindingSource bs = new BindingSource();
            bs.MoveNext();
            data.Save();
        }
        public DataRow NewRow()
        {
            return data.NewRow();
        }
        public void Add(DataRow row)
        {
            data.Add(row);
        }
        public bool Save()
        {
            return data.Save();
        }      
    }
}
