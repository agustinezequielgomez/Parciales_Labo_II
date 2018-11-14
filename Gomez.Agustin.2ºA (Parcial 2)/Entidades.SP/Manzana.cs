using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Entidades.SP
{
    public class Manzana : Fruta,ISerializar,IDeserializar
    {
        #region Atributos
        protected string _provinciaOrigen;
        #endregion

        #region Propiedades
        public string Nombre
        {
            get
            {
                return "Manzana";
            }
        }

        public override bool TieneCarozo
        {
            get
            {
                return true;
            }
        }

        public string ProvinciaOrigen
        {
            get
            {
                return this._provinciaOrigen;
            }
            set
            {
                this._provinciaOrigen = value;
            }
        }
        #endregion

        #region Constructor
        public Manzana() :this("sin color",0,"sin provincia")
        {
        }

        public Manzana(string color, double precio, string provinciaOrigen): base(color,precio)
        {
            this.ProvinciaOrigen = provinciaOrigen;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return String.Format("Nombre: {0}{1}\nCarozo: {2}\nProvnicia de origen: {3}", this.Nombre,base.FrutaToString(), this.TieneCarozo, this.ProvinciaOrigen);
        }

        public bool Xml(string ruta)
        {
            bool retorno = false;
            using (TextWriter writer = new StreamWriter(String.Format(@"{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), ruta)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Manzana));
                serializer.Serialize(writer, this);
                retorno = true;
            }
            return retorno;
        }

        bool IDeserializar.Xml(string ruta, out Fruta fruta)
        {
            bool retorno = false;
            using (TextReader reader = new StreamReader(String.Format(@"{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), ruta)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Manzana));
                fruta = (Manzana)serializer.Deserialize(reader);
                retorno = true;
            }
            return retorno;
        }
        #endregion
    }
}
