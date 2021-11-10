using System.Xml.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejercicio_2
{
    public partial class _Default : Page
    {
        public class Producto //Clase para crear productos
        {
            public int id { get; set; }
            public string descripcion { get; set; }
            public int precio { get; set; }
        }
        public class Venta //Clase para crear ventas
        {
            public int id { get; set; }
            public DateTime fecha { get; set; }
            public int idProd { get; set; }
        }
        public List<Venta> GetVentas() //Lista de ventas
        {
            return new List<Venta> {
             new Venta { id=1,fecha=DateTime.Parse("10/02/2021"),idProd=5 },
             new Venta { id=2,fecha=DateTime.Parse("01/06/2020"),idProd=1 },
             new Venta { id=3,fecha=DateTime.Parse("20/04/2021"),idProd=2 },
             new Venta { id=4,fecha=DateTime.Parse("18/11/2020"),idProd=4 },
             new Venta { id=5,fecha=DateTime.Parse("07/01/2021"),idProd=3 },
             };
        }
        public List<Producto> GetProductos() //Lista de productos
        {
            return new List<Producto>
            {
                new Producto{id=1,descripcion="Jarabe",precio=20},
                new Producto{id=2,descripcion="Pastilla para el dolor de cabeza",precio=30},
                new Producto{id=3,descripcion="Mascarillas",precio=120},
                new Producto{id=4,descripcion="Inyectable",precio=60},
                new Producto{id=5,descripcion="Gotas",precio=7}
            };
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //var ventas = GetVentas(); 
            //var productos = GetProductos();

            //var query = from v in ventas
            //           join p in productos on v.idProd equals p.id
            //          select
            //new { v.id,v.fecha, Producto = p.descripcion,Precio=p.precio };
            //this.GridView1.DataSource = query; this.GridView1.DataBind();
            {
                var query = from v in
                XElement.Load(MapPath("Venta.xml")).Elements("Venta")
                            join p in
                XElement.Load(MapPath("Producto.xml")).Elements("Producto") on
                (int)v.Element("idProd") equals (int)p.Element("id")
                            select new
                            {
                                Codigo = (int)v.Element("id"),
                                Fecha = (string)v.Element("fecha"),
                                Producto = (string)p.Element("descripcion"),
                                Precio = (int)p.Element("precio")
                            };
                this.GridView1.DataSource = query;
                this.GridView1.DataBind();
            }
        }
    }
}