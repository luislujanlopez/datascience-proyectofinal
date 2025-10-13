namespace ProyectoFinalWebApi.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioTotal { get; set; }
        public List<SubProducto> SubProductos { get; set; }
    }
}
