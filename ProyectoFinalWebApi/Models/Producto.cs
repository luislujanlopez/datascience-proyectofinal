namespace ProyectoFinalWebApi.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public string Modelo { get; set; }
        public string urlImagen { get; set; }
        public List<SubProducto> Productos { get; set; }
    }
}
