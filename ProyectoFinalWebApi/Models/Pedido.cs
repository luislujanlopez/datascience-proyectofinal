namespace ProyectoFinalWebApi.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int CantidadTotal { get; set; }
        public decimal PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }
        public List<PedidoDetalle> Detalle { get; set; }
    }
}
