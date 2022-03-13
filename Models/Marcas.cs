namespace ConsumirAPI.Models
{
    public class Marcas
    {

        public string iIdMarca { get; set; }
        public string sMarca{ get; set; }

        public Marcas() { 
        }

        public Marcas(string idMarca, string marca ) 
        {
            idMarca = iIdMarca;
            marca = sMarca;
        }
    }
}
