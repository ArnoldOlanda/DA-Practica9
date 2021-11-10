using System.Linq;
using System.Xml.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqXML_Exp2
{
    public partial class _Default : Page
    {
        public class Movie
        {
            public string Title { get; set; }
            public string Director { get; set; }
            public int Genre { get; set; }
            public int RunTime { get; set; }
            public DateTime ReleaseDate { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var query = from m in
            XElement.Load(MapPath("Movies.xml")).Elements("Movie")
                        join g in
            XElement.Load(MapPath("Genres.xml")).Elements("Genre") on
            (int)m.Element("Genre") equals (int)g.Element("ID")
                        select new
                        {
                            Title = (string)m.Element("Title"),
                            Director = (string)m.Element("Director"),
                            Genre = (string)g.Element("Name"),
                            ReleaseDate = (DateTime)m.Element("ReleaseDate"),
                            RunTime = (int)m.Element("RunTime")
                        };
            this.GridView1.DataSource = query;
            this.GridView1.DataBind();
        }

    }
}