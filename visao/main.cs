using System; 
using Modelos;
using Negocios;
using System.Globalization;
using System.Threading;

public class Program {
  private static bool adminLogado = false;
  private static Usuario userLogado = null;

  public static void Main() {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
    Console.WriteLine();
    Console.WriteLine("=========================================");
    Console.WriteLine("-------- Bem-vindo(a) a TechBits --------");
    int op = 0;
    do {
      try {
        op = Menu();
        switch(op) {
        case 1:
          if (Login()) {            
            if (adminLogado) MainAdmin();
            else MainUser();
          } else {
            Console.WriteLine();
            Console.WriteLine("Usuário ou senha inválidos");
            Console.WriteLine();
          }; break;
        case 2 : Cadastro(); break;
        }
      } 
      catch (Exception erro) {
        op = -1;
        Console.WriteLine("Erro: " + erro.Message);
      }
    } while (op != 0);
  }
  
  public static int Menu() {
    Console.WriteLine("=========================================");
    Console.WriteLine("01 - Login");
    Console.WriteLine("02 - Cadastre-se");
    Console.WriteLine("=========================================");
    Console.WriteLine("00 - Fechar");
    Console.WriteLine();
    Console.Write("Opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static bool Login() {
    Console.WriteLine("=========================================");
    Console.WriteLine("----------------- Login -----------------");
    Console.Write("Nome do usuário: ");
    string n = Console.ReadLine();
    Console.Write("Senha: ");
    string s = Console.ReadLine();
    Usuario user = NUsuario.Entrar(n, s);
    if (user != null) {
      adminLogado = user.Admin;
      userLogado = user;
      return true;
    }
    return false;
  }

  public static void MainAdmin() {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
    int op = 0;
    do {
      try {
        op = MenuAdmin();
        switch(op) {
          case 1 : CategoriaInserir(); break;
          case 2 : CategoriaListar(); break;
          case 3 : CategoriaAtualizar(); break;
          case 4 : CategoriaExcluir(); break;
          case 5 : ProdutoInserir(); break;
          case 6 : ProdutoListar(); break;
          case 7 : ProdutoAtualizar(); break;
          case 8 : ProdutoExcluir(); break;
          case 9 : UsuarioInserir(); break;
          case 10: UsuarioListar(); break;
          case 11: UsuarioAtualizar(); break;
          case 12: UsuarioExcluir(); break;
        }
      } 
      catch (Exception erro) {
        op = -1;
        Console.WriteLine("Erro: " + erro.Message);
      }
    } while (op != 0);
  }

  public static int MenuAdmin() {
    Console.WriteLine();
    Console.WriteLine("=========================================");
    Console.WriteLine($"Olá, {userLogado.Nome}");
    Console.WriteLine("=========================================");
    Console.WriteLine("--------------- Categoria ---------------");
    Console.WriteLine("01 - Inserir");
    Console.WriteLine("02 - Listar");
    Console.WriteLine("03 - Atualizar");
    Console.WriteLine("04 - Excluir");
    Console.WriteLine("=========================================");
    Console.WriteLine("---------------- Produto ----------------");
    Console.WriteLine("05 - Inserir");
    Console.WriteLine("06 - Listar");
    Console.WriteLine("07 - Atualizar");
    Console.WriteLine("08 - Excluir");
    Console.WriteLine("=========================================");
    Console.WriteLine("---------------- Usuario ----------------");
    Console.WriteLine("09 - Inserir admin");
    Console.WriteLine("10 - Listar");
    Console.WriteLine("11 - Atualizar");
    Console.WriteLine("12 - Excluir");
    Console.WriteLine("=========================================");
    Console.WriteLine("00 - Sair");
    Console.WriteLine();
    Console.Write("Opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
  
  public static void MainUser() {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
    int op = 0;
    do {
      try {
        op = MenuUser();
        switch(op) {
          case 1 : CategoriaListar(); break;
          case 2 : ProdutoListar(); break;
          //case 3 : AddCarrinho(); break;
          //case 4 : VerCarrinho(); break;
          //case 5 : ClearCarrinho(); break;
        }
      } 
      catch (Exception erro) {
        op = -1;
        Console.WriteLine("Erro: " + erro.Message);
      }
    } while (op != 0);
  }

  public static int MenuUser() {
    Console.WriteLine();
    Console.WriteLine("=========================================");
    Console.WriteLine($"Olá, {userLogado.Nome}");
    Console.WriteLine("=========================================");
    Console.WriteLine("01 - Listar categorias");
    Console.WriteLine("02 - Listar produtos");
    Console.WriteLine("03 - Adicionar produto no carrinho");
    Console.WriteLine("04 - Ver carrinho");
    Console.WriteLine("05 - Limpar carrinho");
    Console.WriteLine("=========================================");
    Console.WriteLine("00 - Sair");
    Console.WriteLine();
    Console.Write("Opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static void Cadastro() {
    Console.WriteLine("-------------- Cadastre-se --------------");
    Console.Write("Informe o nome do Usuario: ");
    string nome = Console.ReadLine();
    Console.Write("Informe o nome do login: ");
    string user = Console.ReadLine();
    Console.Write("Informe a senha do Usuario: ");
    string senha = Console.ReadLine();
    Console.Write("Informe a data de nascimento do Usuario: ");
    DateTime data = DateTime.Parse(Console.ReadLine());
    Usuario obj = new Usuario {Nome = nome, User = user, Senha = senha, Nascimento = data, Admin = false};
    NUsuario.Inserir(obj);  // Cadastra um novo usuário no sistema
    Console.WriteLine("---- Operação realizada com sucesso! ----");
  }

  public static void CategoriaInserir() {
    Console.WriteLine("------- Inserir uma nova categoria ------");
    Console.Write("Informe o id: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome da categoria: ");
    string descricao = Console.ReadLine();
    Categoria obj = new Categoria(id, descricao);
    NCategoria.Inserir(obj);  // Inserir uma categoria no sistema
    Console.WriteLine("---- Operação realizada com sucesso! ----");
  }

  public static void CategoriaListar() {
    Console.WriteLine("---- Listar as categorias cadastradas ---");
    foreach (Categoria obj in NCategoria.Listar())
      Console.WriteLine(obj);
    Console.WriteLine("------------------------------------------");
  }

  public static void CategoriaAtualizar() {
    Console.WriteLine("-------- Atualizar uma categoria ---------");
    Console.Write("Informe o id da categoria a ser atualizada: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o novo nome da categoria: ");
    string descricao = Console.ReadLine();
    Categoria obj = new Categoria(id, descricao);
    NCategoria.Atualizar(obj);  // Atualizar uma categoria no sistema
    Console.WriteLine("---- Operação realizada com sucesso! ----");
  }

  public static void CategoriaExcluir() {
    Console.WriteLine("--------- Excluir uma categoria ---------");
    Console.Write("Informe o id da categoria a ser excluída: ");
    int id = int.Parse(Console.ReadLine());
    string descricao = "";
    Categoria obj = new Categoria(id, descricao);
    NCategoria.Excluir(obj);  // Excluir uma categoria no sistema
    Console.WriteLine("---- Operação realizada com sucesso! ----");
  }

  public static void ProdutoInserir() {
    Console.WriteLine("-------- Inserir um novo produto --------");
    Console.Write("Informe o id: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome do produto: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a quantidade: ");
    int qtd = int.Parse(Console.ReadLine());
    Console.Write("Informe o preço do produto: ");
    double preco = double.Parse(Console.ReadLine());

    CategoriaListar();
    Console.Write("Informe o id da categoria: ");
    int idCat = int.Parse(Console.ReadLine());
    Produto obj = new Produto(id, nome, qtd, preco, idCat);
    NProduto.Inserir(obj);  // Inserir um produto no sistema
    Console.WriteLine("---- Operação realizada com sucesso! ----");
  }

  public static void ProdutoListar() {
    Console.WriteLine("---- Listar as produtos cadastradas ----");
    foreach (Produto obj in NProduto.Listar())
      Console.WriteLine(obj);
    Console.WriteLine("------------------------------------------");
  }
  
  public static void ProdutoAtualizar() {
    Console.WriteLine("---------- Atualizar um produto ----------");
    Console.Write("Informe o id do produto a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome do produto: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a quantidade: ");
    int qtd = int.Parse(Console.ReadLine());
    Console.Write("Informe o preço do produto: ");
    double preco = double.Parse(Console.ReadLine());

    CategoriaListar();
    Console.Write("Informe o id da categoria: ");
    int idCat = int.Parse(Console.ReadLine());
    Produto obj = new Produto(id, nome, qtd, preco, idCat);
    
    NProduto.Atualizar(obj);  // Atualizar um produto no sistema
    Console.WriteLine("---- Operação realizada com sucesso! ----");
  }

  public static void ProdutoExcluir() {
    Console.WriteLine("----------- Excluir um produto -----------");
    Console.Write("Informe o id do produto a ser excluído: ");
    int id = int.Parse(Console.ReadLine());
    Produto obj = new Produto(id);
    NProduto.Excluir(obj);  // Excluir um produto no sistema
    Console.WriteLine("---- Operação realizada com sucesso! ----");
  }

  public static void UsuarioInserir() {
    Console.WriteLine("-------- Inserir um novo Usuario --------");
    Console.Write("Informe o nome do Usuario: ");
    string nome = Console.ReadLine();
    Console.Write("Informe o nome do login: ");
    string user = Console.ReadLine();
    Console.Write("Informe a senha do Usuario: ");
    string senha = Console.ReadLine();
    Console.Write("Informe a data de nascimento do Usuario: ");
    DateTime data = DateTime.Parse(Console.ReadLine());
    Console.Write("O Usuario é um administrador? (s/n) ");
    char adm = Console.ReadLine()[0];
    bool isAdm = false;
    if (adm == 's'){
      isAdm = true;
    }
    Usuario obj = new Usuario {Nome = nome, User = user, Senha = senha, Nascimento = data, Admin = isAdm};
    NUsuario.Inserir(obj);  // Inserir um usuário no sistema
    Console.WriteLine("---- Operação realizada com sucesso! ----");
  }

  public static void UsuarioListar() {
    Console.WriteLine("----- Listar os Usuarios cadastrados -----");
    foreach (Usuario obj in NUsuario.Listar())
      Console.WriteLine(obj);
    Console.WriteLine("------------------------------------------");
  }

  public static void UsuarioAtualizar() {
    Console.WriteLine("---------- Atualizar um Usuario ----------");
    Console.Write("Informe o id do Usuario a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome do Usuario: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a data de nascimento do Usuario (dd/mm/aaaa): ");
    DateTime data = DateTime.Parse(Console.ReadLine());
    Usuario obj = new Usuario {Id = id, Nome = nome, Nascimento = data };
    NUsuario.Atualizar(obj);  // Atualizar um usuário no sistema
    
    Console.WriteLine("---- Operação realizada com sucesso! ----");
  }

  public static void UsuarioExcluir() {
    Console.WriteLine("----------- Excluir um Usuario -----------");
    Console.Write("Informe o id do Usuario a ser excluído: ");
    int id = int.Parse(Console.ReadLine());
    Usuario obj = new Usuario {Id = id };
    NUsuario.Excluir(obj);  // Excluir um usuário no sistema
    Console.WriteLine("---- Operação realizada com sucesso! ----");
  }
  
}