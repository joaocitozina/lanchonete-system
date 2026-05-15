using Lanchonete.Domain.Entities;

namespace Lanchonete.Domain.Interfaces;

public interface IPedidoRepository
{
    Task<Pedido?> ObterPorIdAsync(Guid id);
    Task<IEnumerable<Pedido>> ObterTodosAsync();
    Task<IEnumerable<Pedido>> ObterPorDataAsync(DateTime data);
    Task AdicionarAsync(Pedido pedido);
    Task AtualizarAsync(Pedido pedido);
}