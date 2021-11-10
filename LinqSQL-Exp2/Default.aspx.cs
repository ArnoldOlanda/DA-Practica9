using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqSQL_Exp2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MoviesDataContext dc = new MoviesDataContext();
            //Select and remove all Action movies
            var query = from m in dc.Movie
            where m.Genre == 2 select m;
            dc.Movie.DeleteAllOnSubmit(query);
            //Select a single movie and remove it
            var movie = dc.Movie.Single(m => m.Title == "Fletch");
            dc.Movie.DeleteOnSubmit(movie);
            dc.SubmitChanges();
 var query2 = from m2 in dc.Movie select m2;
            this.GridView1.DataSource = query2; this.GridView1.DataBind();
        }
    }
}