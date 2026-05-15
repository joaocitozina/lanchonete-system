namespace Lanchonete.Domain.Entities;

public enum StatusPedido { Aberto, Finalizado, Cancelado }

public class Pedido
{
    private readonly List<PedidoItem> _items = new();

    public Guid Id { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public StatusPedido Status { get; private set; }
    public decimal ValorTotal { get; private set; }

    public IReadOnlyCollection<PedidoItem> Items => _items.AsReadOnly();


    public Pedido()
    {
        Id = Guid.NewGuid();
        DataCriacao = DateTime.UtcNow;
        Status = StatusPedido.Aberto;
    }


    public void AdicionarItem(PedidoItem item)
    {
        if (Status != StatusPedido.Aberto)
            throw new InvalidOperationException("Pedido não está aberto.");

        _items.Add(item);
        RecalcularTotal();
    }

    public void Finalizar()
    {
        if (!_items.Any())
            throw new InvalidOperationException("Pedido não possui itens.");

        Status = StatusPedido.Finalizado;
    }

    public void Cancelar() => Status = StatusPedido.Cancelado;

    private void RecalcularTotal() =>
        ValorTotal = _items.Sum(i => i.SubTotal);
}