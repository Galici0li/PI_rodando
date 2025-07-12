using model;
using Repository;

namespace controller;

public class ControllerPessoa
{
    public static void Sincronizar()
    {
        RepositoryPessoa.Sincronizar();
    }
    public static void Criar(string nome, string senha, string email, int permissao)
    {
        new User(nome, senha, email, permissao);
    }

    public static List<User> Listar()
    {
        return RepositoryPessoa.Listar();
    }

    public static void Alternar(int id, string nome, string senha, string email, int permissao)
    {
        RepositoryPessoa.Alternar(id, nome, senha, email, permissao);
    }

    public static void Deletar(int id)
    {
        RepositoryPessoa.Deletar(id);
    }
}