using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using QUANLYKHACHSAN.DataPlayer;
using QUANLYKHACHSAN.Setting;

namespace QUANLYKHACHSAN.Controller    
{
    public class BaoCaoDoanhThuControl
    {
        BaoCaoDoanhThuData data = new BaoCaoDoanhThuData();
                
        public void LayDS(BindingNavigator bd, DataGridView dt, int thang, int nam)
        {
            BindingSource ds = new BindingSource();
            BindingSource ds1 = new BindingSource();
            ds.DataSource = data.TruyVan(thang,nam);
            //ds1.DataSource = data.TruyVanTyLe(thang, nam);

            bd.BindingSource = ds;
            dt.DataSource = ds;

        }
        public bool Save()
        {
            return data.Save();
        }               
        
    }
}
