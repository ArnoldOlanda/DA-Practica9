using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;


using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exp1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void cmdCreateXml_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"D:\(a)-Trabajos Universidad\6to Semestre\Desarrollo App\Practicas\Practica 09\SuperProProductList.xml", FileMode.Create);
            XmlTextWriter w= new XmlTextWriter(fs, null);
            w.WriteStartDocument();
            w.WriteStartElement("SuperProProductList");
            w.WriteComment("Este archivo fue generado por");
            //
            w.WriteStartElement("Product");
            w.WriteAttributeString("ID", "", "1");
            w.WriteAttributeString("Name", "", "chair");
            w.WriteStartElement("Price");
            w.WriteString("49.33");
            w.WriteEndElement();
            w.WriteEndElement();

            //
            w.WriteStartElement("Product");
            w.WriteAttributeString("ID", "", "2");
            w.WriteAttributeString("Name", "", "Car");
            w.WriteStartElement("Price");
            w.WriteString("43399.55");
            w.WriteEndElement();
            w.WriteEndElement();

            //
            w.WriteStartElement("Product");
            w.WriteAttributeString("ID", "", "3");
            w.WriteAttributeString("Name", "", "Fresh fruit basket");
            w.WriteStartElement("Price");
            w.WriteString("49.99");
            w.WriteEndElement();
            w.WriteEndElement();

            w.WriteEndElement();
            w.WriteEndDocument();
            w.Close();
            lblXml.Text = "Archivo escrito satisfactoriamente";
        }

        protected void cmdReadXml_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"D:\(a)-Trabajos Universidad\6to Semestre\Desarrollo App\Practicas\Practica 09\SuperProProductList.xml", FileMode.Open);
            XmlTextReader r = new XmlTextReader(fs);

            StringWriter writer = new StringWriter();

            while (r.Read())
            {
                writer.Write("<b>Type:</b>");
                writer.Write(r.NodeType.ToString());
                writer.Write("<br>");

                if (r.Name!="")
                {
                    writer.Write("<b>Name:</b>");
                    writer.Write(r.Name);
                    writer.Write("<br>");
                }
                if (r.Value != "")
                {
                    writer.Write("<b>Value:</b>");
                    writer.Write(r.Value);
                    writer.Write("<br>");
                }
                if (r.AttributeCount > 0)
                {
                    writer.Write("<b>Atributes:</b>");
                    for(int i = 0; i < r.AttributeCount; i++)
                    {
                        writer.Write(" ");
                        writer.Write(r.GetAttribute(i));
                        writer.Write(" ");
                    }
                    writer.Write("<br>");
                }
                writer.Write("<br>");
            }
            r.Close();
            lblXml.Text = writer.ToString();
        }

        protected void cmdReadXmlAsObjects_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"D:\(a)-Trabajos Universidad\6to Semestre\Desarrollo App\Practicas\Practica 09\SuperProProductList.xml", FileMode.Open);
            XmlTextReader r = new XmlTextReader(fs);

            List<Product> products = new List<Product>();
            while (r.Read())
            {
                if(r.NodeType==XmlNodeType.Element && r.Name == "Product")
                {
                    Product newProduct = new Product();
                    newProduct.ID = Int32.Parse(r.GetAttribute(0));
                    newProduct.Name = r.GetAttribute(1);
                    while (r.NodeType!=XmlNodeType.EndElement)
                    {
                        r.Read();
                        if (r.Name == "Price")
                        {
                            while (r.NodeType != XmlNodeType.EndElement)
                            {
                                r.Read();
                                if (r.NodeType == XmlNodeType.Text)
                                {
                                    newProduct.Price = decimal.Parse(r.Value);
                                }
                            }
                        }
                    }
                    products.Add(newProduct);
                }
            }
            r.Close();
            gridResults.DataSource = products;
            gridResults.DataBind();
        }
    }
}