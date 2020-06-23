using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using QUANLYKHACHSAN.DataPlayer;

namespace QUANLYKHACHSAN.Controller
{
    public class QuiDinhControl
    {
        QuiDinhData data = new QuiDinhData();

        public void HienThi( DataGridView dg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            DataTable tbl = data.LayQuiDinh();
            bs.DataSource = tbl;
            
            dg.DataSource = bs;
            bn.BindingSource = bs;
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
