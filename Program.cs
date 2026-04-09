using System;

public class Categoria
{
    public string Nome { get; }

    public Categoria(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("Nome da categoria invalido");
        }

        Nome = nome;
    }
}

public class Midia
{
    public string Titulo { get; private set; }
    public int Duracao { get; private set; }

    public Midia(string titulo, int duracao)
    {
        if (string.IsNullOrWhiteSpace(titulo))
        {
            throw new ArgumentException("Titulo invalido");
        }

        if (duracao <= 0)
        {
            throw new ArgumentException("Duracao deve ser maior que zero");
        }

        Titulo = titulo;
        Duracao = duracao;
    }

    public virtual void Exibir()
    {
        Console.WriteLine($"Titulo: {Titulo} | Duracao: {Duracao} min");
    }
}

public class Filme : Midia
{
    public Categoria Genero { get; private set; }

    public Filme(string titulo, int duracao, Categoria genero)
        : base(titulo, duracao)
    {
        if (genero == null)
        {
            throw new ArgumentException("Genero obrigatorio");
        }

        Genero = genero;
    }

    public override void Exibir()
    {
        Console.WriteLine($"Filme: {Titulo} | Duracao: {Duracao} min | Genero: {Genero.Nome}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Categoria acao = new Categoria("Acao");
        Categoria drama = new Categoria("Drama");

        Filme filme1 = new Filme("Velozes e Furiosos", 130, acao);
        Filme filme2 = new Filme("Missao Impossivel", 120, acao);
        Filme filme3 = new Filme("O Pianista", 150, drama);

        filme1.Exibir();
        filme2.Exibir();
        filme3.Exibir();
    }
}