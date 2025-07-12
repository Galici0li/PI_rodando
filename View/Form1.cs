using controller;
using model;

namespace PI_Teste;

public partial class ViewAdmin : Form 
{
    private readonly Label Lbllogin;
    private readonly Label LblSenha;
    private readonly Label LblEmail;
    private readonly ComboBox comboBox;
    private readonly TextBox InptEmail;
    private readonly TextBox InptLogin;
    private readonly TextBox InptSenha;
    private readonly Button BttnLogar;
    private readonly Button BttnAlterar;
    private readonly Button BttnDeletar;
    private readonly DataGridView DgvAlunos;
    
   
    public ViewAdmin()
    {
        ControllerPessoa.Sincronizar();

        Size = new Size(800, 800);
        StartPosition = FormStartPosition.CenterScreen;

        Lbllogin = new Label
        {
            Text = "User: ",
            Location = new Point(50, 50)
        };

        LblSenha = new Label
        {
            Text = "Senha: ",
            Location = new Point(100, 100),

        }; LblEmail = new Label
        {
            Text = "Email: ",
            Location = new Point(150, 150),

        };

        InptLogin = new TextBox
        {
            Text = " ",
            Location = new Point(50, 100),
            Size = new Size(200, 100)
        };

        InptSenha = new TextBox
        {
            Text = " ",
            Location = new Point(150, 100),
            Size = new Size(250, 100)
        };
        InptEmail = new TextBox
        {
            Text = " ",
            Location = new Point(250, 100),
            Size = new Size(200, 100)
        };
        comboBox = new ComboBox
        {
            Text = "Selecione o nível de acesso do usuário",
            Location = new Point(300, 300),
            Size = new Size(350, 350),

        };  comboBox.Items.Add("1 - Aluno");
            comboBox.Items.Add("2 - Professor");
            comboBox.SelectedIndex = 99;

        BttnLogar = new Button
        {
            Text = "Login ",
            Location = new Point(300, 100),
        }; BttnLogar.Click += Criar;

        BttnAlterar = new Button
        {
            Text = "Alterar",
            Location = new Point(300, 200),
        }; BttnAlterar.Click += Alterar;

        BttnDeletar = new Button
        {
            Text = "Deletar",
            Location = new Point(300, 300)
        }; BttnDeletar.Click += Deletar;


        Controls.Add(Lbllogin);
        Controls.Add(LblSenha);
        Controls.Add(LblEmail);
        Controls.Add(InptEmail);
        Controls.Add(InptLogin);
        Controls.Add(InptSenha);
        Controls.Add(comboBox);
        Controls.Add(BttnLogar);
        Controls.Add(BttnAlterar);
        Controls.Add(BttnDeletar);
        Controls.Add(DgvAlunos);

    }
    private void Listar()
    {
        List<User> pessoas = ControllerPessoa.Listar();
        DgvAlunos.DataSource = pessoas;
        DgvAlunos.AutoGenerateColumns = false;
        DgvAlunos.Columns.Clear();

        DgvAlunos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Nome",
            HeaderText = "Nome",
        });

        DgvAlunos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Senha",
            HeaderText = "Senha",
        });
    }

    private void Criar(object? sender, EventArgs e)
    {
        if (InptLogin.Text.Length < 1)
        {
            MessageBox.Show("Preencha o seu login");
            return;
        }
        else if (InptSenha.Text.Length < 1)
        {
            MessageBox.Show("Preencha a sua senha");
            return;
        }
        else if (InptEmail.Text.Length < 1)
        {
            MessageBox.Show("Preencha o seu email");
            return;
        }
        else if (comboBox.SelectedIndex < 1 || comboBox.SelectedIndex > 2)
        {
            MessageBox.Show("Preencha o nível de acesso");
            return;
        }

        MessageBox.Show("Usuário Cadastrado com sucesso!");
        ControllerPessoa.Criar(InptLogin.Text, InptSenha.Text, InptEmail.Text, Convert.ToInt32(comboBox.Text));
        Listar();
    }

    private void Alterar(object? sender, EventArgs e)
    {
        int Id = DgvAlunos.SelectedRows[0].Index;

        if (InptLogin.Text.Length < 1)
        {
            MessageBox.Show("Preencha o seu login novamente");
            return;
        }
        else if (InptSenha.Text.Length < 1)
        {
            MessageBox.Show("Preencha a sua senha novamente");
            return;
        }
        else if (InptEmail.Text.Length < 1)
        {
            MessageBox.Show("Preencha o seu email");
            return;
        }
        else if (comboBox.SelectedIndex < 1 || comboBox.SelectedIndex > 2)
        {
            MessageBox.Show("Preencha o nível de acesso");
            return;
        }
        
        MessageBox.Show("Dados alterados com sucesso!");

        ControllerPessoa.Alternar(Id, InptLogin.Text, InptSenha.Text, InptEmail.Text, Convert.ToInt32(comboBox.Text));
        Listar();
    }

    private void Deletar(object? sender, EventArgs e)
    {
        int index = DgvAlunos.SelectedRows[0].Index;

        ControllerPessoa.Deletar(index);

        MessageBox.Show("Usuário deletado com sucesso");
        Listar();
    }
}

