using Britzza___v6.Models;

namespace Britzza___v6.Interfaces
{
    public interface IPedidoRepository
    {
        List<PedidoModel> BuscaTodosPedidos();
        PedidoModel BuscaPedidoPorDocumento(string documento);
        void CriaPedido(PedidoModel pedido);
        void AlteraPedido(PedidoModel model);
        void DeletaPedido(string documento);
    }
}
