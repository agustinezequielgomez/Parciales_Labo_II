using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Entidades.SP;

namespace SP
{
    //DESARROLLAR DENTRO DEL NAMESPACE RAIZ ENTIDADES.SP EN UN PROYECTO DE TIPO CLASS LIBRARY

    public partial class SegundoParcial: Form
    {
        private Manzana _manzana;
        private Banana _banana;
        private Durazno _durazno;

        public Cajon<Manzana> c_manzanas;
        public Cajon<Banana> c_bananas;
        public Cajon<Durazno> c_duraznos;

        public SegundoParcial()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Gomez Agustin. 2°A");
        }

        //Crear la siguiente jerarquía de clases:
        //Fruta-> _color:string y _peso:double (protegidos); TieneCarozo:bool (prop. s/l, abstracta);
        //constructor con 2 parametros y FrutaToString():string (protegido y virtual, retorna los valores de la fruta)
        //Manzana-> _provinciaOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Manzana'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true
        //Banana-> _paisOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Banana'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->false
        //Durazno-> _cantPelusa:int (protegido); Nombre:string (prop. s/l, retornará 'Durazno'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true
        //Crear una instancia de cada clase e inicializar los atributos del form _manzana, _banana y _durazno. 
        private void btnPunto1_Click(object sender, EventArgs e)
        {
            this._manzana = new Manzana("verde", 2, "rio negro");
            this._banana = new Banana("amarillo", 5, "ecuador");
            this._durazno = new Durazno("rojo", 2.5, 53);

            MessageBox.Show(this._manzana.ToString());
            MessageBox.Show(this._banana.ToString());
            MessageBox.Show(this._durazno.ToString());

        }

        //Crear la clase Cajon<T>
        //atributos: _capacidad:int, _elementos:List<T> y _precioUnitario:double (todos protegidos)        
        //Propiedades
        //Elementos:(sólo lectura) expone al atributo de tipo List<T>.
        //PrecioTotal:(sólo lectura) retorna el precio total del cajón (precio * cantidad de elementos).
        //Constructor
        //Cajon(), Cajon(int), Cajon(int, double); 
        //El por default: es el único que se encargará de inicializar la lista.
        //Métodos
        //ToString: Mostrará en formato de tipo string, la capacidad, la cantidad total de elementos, el precio total 
        //y el listado de todos los elementos contenidos en el cajón. Reutilizar código.
        //Sobrecarga de operador
        //(+) Será el encargado de agregar elementos al cajón, siempre y cuando no supere la capacidad del mismo.
        private void btnPunto2_Click(object sender, EventArgs e)
        {
            this.c_manzanas = new Cajon<Manzana>(1.58, 3);
            this.c_bananas = new Cajon<Banana>(15.96, 4);
            this.c_duraznos = new Cajon<Durazno>(21.5, 1);

            this.c_manzanas += new Manzana("roja", 1, "neuquen");
            this.c_manzanas += this._manzana;
            this.c_manzanas += new Manzana("amarilla", 3, "san juan");

            this.c_bananas += new Banana("verde", 3, "brasil");
            this.c_bananas += this._banana;

            this.c_duraznos += this._durazno;

            MessageBox.Show(this.c_manzanas.ToString());
            MessageBox.Show(this.c_bananas.ToString());
            MessageBox.Show(this.c_duraznos.ToString());

        }

        //Crear las interfaces: 
        //ISerializar -> Xml(string):bool
        //IDeserializar -> Xml(string, out Fruta):bool
        //Implementar (implicitamente) ISerializar en Cajon y manzana
        //Implementar (explicitamente) IDeserializar en manzana
        //Los archivos .xml guardarlos en el escritorio del cliente
        private void btnPunto3_Click(object sender, EventArgs e)
        {
            Fruta aux = null;

            if (this._manzana.Xml("manzana.xml"))
            {
                MessageBox.Show("Manzana serializada OK");
            }
            else
            {
                MessageBox.Show("NO Serializado");
            }

            if (((IDeserializar)this._manzana).Xml("manzana.xml", out aux))
            {
                MessageBox.Show("Manzana deserializada OK");
                MessageBox.Show(((Manzana)aux).ToString());
            }
            else
            {
                MessageBox.Show("NO Deserializado");
            }

            if (this.c_manzanas.Xml("manzanas.xml"))
            {
                MessageBox.Show("Cajon de Manzanas serializado OK");
            }
            else
            {
                MessageBox.Show("NO Serializado");
            }

        }

        //Si se intenta agregar frutas al cajón y se supera la cantidad máxima, se lanzará un CajonLlenoException, 
        //cuyo mensaje explicará lo sucedido.
        private void btnPunto4_Click(object sender, EventArgs e)
        {
            //implementar estructura de manejo de excepciones
            try
            {
                this.c_duraznos += this._durazno;
            }
            catch(CajonLlenoException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        //Si el precio total del cajon supera los 55 pesos, se disparará el evento EventoPrecio. 
        //Diseñarlo (de acuerdo a las convenciones vistas) en la clase cajon. 
        //Crear el manejador necesario para que se imprima en un archivo de texto: 
        //la fecha (con hora, minutos y segundos) y el total del precio del cajón en un nuevo renglón.
        private void btnPunto5_Click(object sender, EventArgs e)
        {
            Manejadora manejadora = new Manejadora();

            this.c_bananas.EventoPrecio += manejadora.ManejadorEvento;
            this.c_bananas += new Banana("verde", 2, "argentina");
            this.c_bananas += new Banana("amarilla", 4, "ecuador");
        }

        //Obtener de la base de datos (sp_lab_II) el listado de frutas:
        //frutas { id(autoincremental - numérico) - nombre(cadena) - peso(numérico) - precio(numérico) }. 
        //Invocar al método ObtenerListadoFrutas.
        private void btnPunto6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(SegundoParcial.ObtenerListadoFrutas());
        }

        //Agregar en la base de datos las frutas del formulario (_manzana, _banana y _durazno).
        //Invocar al metodo AgregarFrutas():bool
        private void btnPunto7_Click(object sender, EventArgs e)
        {
            if (SegundoParcial.AgregarFrutas())
            {
                MessageBox.Show("Se agregaron las frutas a la Base de Datos");
            }
            else
            {
                MessageBox.Show("NO se agregaron las frutas a la Base de Datos");
            }
        }


        private static string ObtenerListadoFrutas()
        {
            StringBuilder sb = new StringBuilder();
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.Conexion);
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM frutas";
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                sb.AppendFormat("ID: {0}\nNombre: {1}\nPeso: {2}\nPrecio: {3}\n\n", reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetDouble(3));
            }
            connection.Close();
            return sb.ToString();
        }

        private static bool AgregarFrutas()
        {
            SegundoParcial segundoParcial = new SegundoParcial();
            segundoParcial._manzana = new Manzana("verde", 2, "rio negro");
            segundoParcial._banana = new Banana("amarillo", 5, "ecuador");
            segundoParcial._durazno = new Durazno("rojo", 2, 53);

            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = String.Format("INSERT INTO sp_lab_II.dbo.frutas (nombre, peso, precio) values ('{0}', {1}, {2})", segundoParcial._manzana.Nombre, segundoParcial._manzana.Peso, (double)45); 
            command.CommandText = String.Format("\nINSERT INTO sp_lab_II.dbo.frutas (nombre, peso, precio) values ('{0}', {1}, {2})", segundoParcial._durazno.Nombre, segundoParcial._durazno.Peso, (double)15);
            command.CommandText = String.Format("\nINSERT INTO sp_lab_II.dbo.frutas (nombre, peso, precio) values ('{0}', {1}, {2})", segundoParcial._banana.Nombre, segundoParcial._banana.Peso, (double)487);
            command.Connection = conexion;
            try
            {
                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception exception)
            {
                return false;
            }
            return true;
        }
    }
}
