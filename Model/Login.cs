using Repository;

namespace model;

public class User
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Senha { get; set; }
    public string Email { get; set; }
    public int Permissao { get; set; }

    public User() { }

    public User(string nome, string senha, string email, int permissao)
    {
        
        Nome = nome;
        Senha = senha;
        Email = email;
        Permissao = permissao;


        RepositoryPessoa.Criar(this);
    }

    public void MostrarDados()
    {
        MessageBox.Show($"O aluno {Nome}, {Email} anos de idade. Está cadastrado em nosso sistema");
    }
}