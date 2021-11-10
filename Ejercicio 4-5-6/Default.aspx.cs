using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejercicio_4
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //FarmaciaDataContext dc = new FarmaciaDataContext(); 
            //var query = from m in dc.ventas
            //select m;
            //this.GridView1.DataSource = query; 
            //this.GridView1.DataBind();

            FarmaciaEntities dc = new FarmaciaEntities(); var query = from m in dc.ventas
                                                                  select m;
            GridView1.DataSource = query.ToList();
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int num = Int32.Parse(TextBox1.Text);
            FarmaciaEntities dc = new FarmaciaEntities(); 
            var query = from m in dc.ventas where m.id==num select m;
            GridView2.DataSource = query.ToList();
            GridView2.DataBind();
        }
    }
}