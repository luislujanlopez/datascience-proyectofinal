namespace ProyectoFinalWebApi.Models
{
    public class SubProducto
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
    }
}
