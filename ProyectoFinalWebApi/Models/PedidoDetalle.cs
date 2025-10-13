namespace ProyectoFinalWebApi.Models
{
    public class PedidoDetalle
    {
        public int IdPedido { get; set; }
        public int IdSubProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioTotal { get; set; }
    }
}
