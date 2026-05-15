

namespace Lanchonete.Domain.Entities;

public class Produto
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }
    public bool Ativo { get; private set; }


    public Produto(string nome, decimal preco)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome nao pode ser vazio", nameof(nome));
        if (preco <= 0)
            throw new ArgumentException("Preco deve ser maior que zero", nameof(preco));
        
        Id = Guid.NewGuid();
        Nome = nome;
        Preco = preco;
        Ativo = true;

    }

    public void Desativar()
    {
        Ativo = false;
    }

    public void AtualizarPreco(decimal novoPreco)
    { 
        if (novoPreco <= 0)
            throw new ArgumentException("Preco deve ser maior que zero", nameof(novoPreco));
        Preco = novoPreco;
    }

}
