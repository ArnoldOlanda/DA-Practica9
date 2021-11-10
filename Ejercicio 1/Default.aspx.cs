using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejercicio_1
{
    public partial class _Default : Page
    {

        public class Employee
        {
            private int id;
            private string nombre;
            private string area;
            private string sueldo;

            public int ID
            {
                get { return id; }
                set { id = value; }
            }
            public string Name
            {
                get { return nombre; }
                set { nombre = value; }
            }
            public string Area
            {
                get { return area; }
                set { area = value; }
            }
            public string Sueldo
            {
                get { return sueldo; }
                set { sueldo = value; }
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"D:\(a)-Trabajos Universidad\6to Semestre\Desarrollo App\Practicas\Practica 09\Ejercicios\Ejercicio 1\trabajadores.xml", FileMode.Create);
            XmlTextWriter w = new XmlTextWriter(fs, null);
            w.WriteStartDocument();
            w.WriteStartElement("Trabajadores");
            //
            w.WriteStartElement("Trabajador");
            w.WriteAttributeString("ID", "", "1");
            w.WriteAttributeString("Nombre", "", "Jose");
            w.WriteStartElement("Area");
            w.WriteString("Administracion");
            w.WriteEndElement();

            w.WriteStartElement("Sueldo");
            w.WriteString("1450");
            w.WriteEndElement();
            w.WriteEndElement();

            //
            w.WriteStartElement("Trabajador");
            w.WriteAttributeString("ID", "", "2");
            w.WriteAttributeString("Nombre", "", "Mario");
            w.WriteStartElement("Area");
            w.WriteString("Logistica");
            w.WriteEndElement();

            w.WriteStartElement("Sueldo");
            w.WriteString("1200");
            w.WriteEndElement();
            w.WriteEndElement();

            w.WriteStartElement("Trabajador");
            w.WriteAttributeString("ID", "", "3");
            w.WriteAttributeString("Nombre", "", "Arnold");
            w.WriteStartElement("Area");
            w.WriteString("Informatica");
            w.WriteEndElement();

            w.WriteStartElement("Sueldo");
            w.WriteString("2200");
            w.WriteEndElement();
            w.WriteEndElement();

            w.WriteStartElement("Trabajador");
            w.WriteAttributeString("ID", "", "4");
            w.WriteAttributeString("Nombre", "", "Gabriel");
            w.WriteStartElement("Area");
            w.WriteString("Informatica");
            w.WriteEndElement();

            w.WriteStartElement("Sueldo");
            w.WriteString("2200");
            w.WriteEndElement();
            w.WriteEndElement();

            w.WriteEndElement();
            w.WriteEndDocument();
            w.Close();
            Label1.Text = "Archivo escrito satisfactoriamente";

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"D:\(a)-Trabajos Universidad\6to Semestre\Desarrollo App\Practicas\Practica 09\Ejercicios\Ejercicio 1\trabajadores.xml", FileMode.Open);
            XmlTextReader r = new XmlTextReader(fs);
            string filter = "";

            List<Employee> employees = new List<Employee>();
            while (r.Read())
            {
                if (r.NodeType == XmlNodeType.Element && r.Name == "Trabajador")
                {
                    Employee newEmployee = new Employee();
                    newEmployee.ID = Int32.Parse(r.GetAttribute(0));
                    newEmployee.Name = r.GetAttribute(1);
                    while (r.NodeType != XmlNodeType.EndElement)
                    {
                        r.Read();
                        if (r.Name == "Area")
                        {
                            while (r.NodeType != XmlNodeType.EndElement)
                            {
                                r.Read();
                                if (r.NodeType == XmlNodeType.Text)
                                {
                                    newEmployee.Area = r.Value;
                                    filter = r.Value;
                                }
                            }
                        }
                        r.Read();
                        if (r.Name == "Sueldo")
                        {
                            while (r.NodeType != XmlNodeType.EndElement)
                            {
                                r.Read();
                                if (r.NodeType == XmlNodeType.Text)
                                {
                                    newEmployee.Sueldo = r.Value;
                                }
                            }
                        }
                    }

                    if (filter == TextBox1.Text || TextBox1.Text=="")
                    {
                        employees.Add(newEmployee);
                    }
                    
                }
            }
            r.Close();
            GridView1.DataSource = employees;
            GridView1.DataBind();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"D:\(a)-Trabajos Universidad\6to Semestre\Desarrollo App\Practicas\Practica 09\Ejercicios\Ejercicio 1\trabajadores.xml", FileMode.Open);
            XmlTextReader r = new XmlTextReader(fs);
            int sueldoTotal = 0;
            while (r.Read())
            {
                if (r.NodeType == XmlNodeType.Element && r.Name == "Trabajador")
                {
                    while (r.NodeType != XmlNodeType.EndElement)
                    {
                        r.Read();
                        r.Read();
                        if (r.Name == "Sueldo")
                        {
                            while (r.NodeType != XmlNodeType.EndElement)
                            {
                                r.Read();
                                if (r.NodeType == XmlNodeType.Text)
                                {
                                    sueldoTotal = sueldoTotal + Int32.Parse(r.Value);
                                }
                            }
                        }
                    }

                }
            }
            r.Close();
            Label1.Text =sueldoTotal.ToString();
        }
    }
}