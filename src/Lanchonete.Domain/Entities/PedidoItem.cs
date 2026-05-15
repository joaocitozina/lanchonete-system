
namespace Lanchonete.Domain.Entities;

public class PedidoItem
{
    public Guid Id { get; private set; }
    public Guid ProdutoId { get; private set; }
    public int Quantidade { get; private set; }
    public decimal PrecoUnitario { get; private set; }

    public decimal SubTotal => PrecoUnitario * Quantidade;


    public PedidoItem( Guid produtoId, int quantidade, decimal precoUnitario) 
    {
        if (quantidade <= 0)
            throw new ArgumentException("Quantidade deve ser maior que zero", nameof(quantidade));
        if (precoUnitario <= 0)
            throw new ArgumentException("Preco unitario deve ser maior que zero", nameof(precoUnitario));

        Id = Guid.NewGuid();
        ProdutoId = produtoId;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;

    }

}
