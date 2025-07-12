using model;
using MySqlConnector;

namespace Repository;

public class RepositoryPessoa
{
    
    static List<User> users = [];
    private static MySqlConnection conexao;
    private static void StartConexao()
    {
        string info = "server=localhost;database=projetointegrador;user id=root;password=''";
        conexao = new MySqlConnection(info);
        try
        {
            conexao.Open();
        }
        catch (System.Exception)
        {
            MessageBox.Show("Erro de conexão");
        }
    }
    public static void EndConexao()
    {
        conexao.Close();
    }

    public static List<User> Sincronizar()
    {
        StartConexao();
        string query = "SELECT * FROM pessoas";
        MySqlCommand command = new MySqlCommand(query, conexao);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            User pessoa = new User();
            pessoa.Id = Convert.ToInt32(reader["id"].ToString);
            pessoa.Nome = reader["nome"].ToString();
            pessoa.Senha = reader["senha"].ToString();
            pessoa.Email = reader["emial"].ToString();
            pessoa.Permissao = Convert.ToInt32(reader["permissao"].ToString);

            users.Add(pessoa);
        }

        EndConexao();
        return users;
    }
    public static void Criar(User pessoa)
    {
        users.Add(pessoa);
    }

    public static List<User> Listar()
    {
        return users;
    }

    public static void Alternar(int id, string nome, string senha, string email, int permissao)
    {
        users[id].Nome = nome;
        users[id].Senha = senha;
        users[id].Email = email;
        users[id].Permissao = permissao;
    }

    public static void Deletar(int id)
    {
        users.RemoveAt(id);
    }
}