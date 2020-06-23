using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using QUANLYKHACHSAN.DataPlayer;

namespace QUANLYKHACHSAN.Controller
{
    public class PhongControl
    {
        PhongData data = new PhongData();

        public void HienThi(TextBox txtMaPhong, ComboBox cmbMaLPhong, ComboBox cmbMaTTrPhong, TextBox txtGhiChu, DataGridView dg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayMaPhong();
            dg.DataSource = bs;
            bn.BindingSource = bs;   

            txtMaPhong.DataBindings.Clear();
            txtMaPhong.DataBindings.Add("Text", bs, "MaPhong");

            cmbMaLPhong.DataBindings.Clear();
            cmbMaLPhong.DataBindings.Add("SelectedValue", bs, "MaLoaiPhong");

            cmbMaTTrPhong.DataBindings.Clear();
            cmbMaTTrPhong.DataBindings.Add("SelectedValue", bs, "MaLoaiTinhTrangPhong");

            txtGhiChu.DataBindings.Clear();
            txtGhiChu.DataBindings.Add("Text", bs, "GhiChu");             
        }

        public void HienthiDataGridviewComboBoxMaPhong(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = data.LayMaPhong();
            cmb.DisplayMember = "MaPhong";
            cmb.ValueMember = "MaPhong";
            cmb.DataPropertyName = "MaPhong";
            cmb.HeaderText = "Mã phòng";
        }

        public void HienthiComboBox(ComboBox cmb)
        {
            cmb.DataSource = data.LayMaTinhTrangPhong(1);
            cmb.DisplayMember = "MaPhong";
            cmb.ValueMember = "MaPhong";           
        }

        public void HienthiComboBoxPhongDat(ComboBox cmb)
        {
            cmb.DataSource = data.LayMaTinhTrangPhong(2);
            cmb.DisplayMember = "MaPhong";
            cmb.ValueMember = "MaPhong";
        }

        public void HienthiComboBoxPhongTra(ComboBox cmb)
        {
            cmb.DataSource = data.LayMaTinhTrangPhong(3);
            cmb.DisplayMember = "MaPhong";
            cmb.ValueMember = "MaPhong";
        }

        public QUANLYKHACHSAN.BusinessObject.PhongInFo LayMaPhong(string maphong)
        {
            PhongData p = new PhongData();
            LoaiPhongControl lp = new LoaiPhongControl();
            DataTable tbl = p.LayMaPhong(maphong);
            QUANLYKHACHSAN.BusinessObject.PhongInFo pif = null;
            pif = new QUANLYKHACHSAN.BusinessObject.PhongInFo();
            
            if (tbl.Rows.Count > 0)
            {                             
                
                pif.MaPhong = Convert.ToString(tbl.Rows[0]["MaPhong"]);
                pif.MaLoaiPhong = Convert.ToString(tbl.Rows[0]["MaLoaiPhong"]);
                pif.GhiChu = Convert.ToString(tbl.Rows[0]["GhiChu"]);              
                

            }
            return pif;

        }

        public void HienThiChiTietPhieuDangKy(DataGridView dg,String id)
        {

            dg.DataSource = data.LayMaPhong();
        }

        public void TimMaLoaiPhong(string maloaiphong)
        {
            data.TimMaLoaiPhong(maloaiphong.ToString());
        }

        public void TimTinhTrangPhong(string tinhtrangphong)
        {
            data.TimTinhTrangPhong(tinhtrangphong.ToString());
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
    }
}
