namespace ConsumirAPI.Models
{
    public class RequestAPI
    {

        public string Filtro { get; set; }
        public int IdAplication { get; set; }
        public string NombreCatalogo { get; set; }

        public RequestAPI() { 
        }

        public RequestAPI(string filtro, int idAplication, string nombreCatalogo) {
            Filtro = filtro;
            IdAplication = idAplication;
            NombreCatalogo = nombreCatalogo;
        }
    }
}
