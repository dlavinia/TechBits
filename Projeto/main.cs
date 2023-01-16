using System; 

public class Program {

  public static void Main() {
    Console.WriteLine("----- Bem-vindo(a) a TechBits -----");
    int op = 0;
    do {
      try {
        op = Menu();
        switch(op) {
          case 1 : CategoriaInserir(); break;
          case 2 : CategoriaListar(); break;
          case 3 : CategoriaAtualizar(); break;
          case 4 : CategoriaExcluir(); break;
          case 5 : ProdutoInserir(); break;
          case 6 : ProdutoListar(); break;
          case 7 : ProdutoAtualizar(); break;
          case 8 : ProdutoExcluir(); break;
          case 9 : ClienteInserir(); break;
          case 10: ClienteListar(); break;
          case 11: ClienteAtualizar(); break;
          case 12: ClienteExcluir(); break;
        }
      } 
      catch (Exception erro) {
        op = -1;
        Console.WriteLine("Erro: " + erro.Message);
      }
    } while (op != 0);
  }

  public static int Menu() {
    Console.WriteLine();
    Console.WriteLine("===================================");
    Console.WriteLine("------------ Categoria ------------");
    Console.WriteLine("01 - Inserir");
    Console.WriteLine("02 - Listar");
    Console.WriteLine("03 - Atualizar");
    Console.WriteLine("04 - Excluir");
    Console.WriteLine("===================================");
    Console.WriteLine("------------- Produto -------------");
    Console.WriteLine("05 - Inserir");
    Console.WriteLine("06 - Listar");
    Console.WriteLine("07 - Atualizar");
    Console.WriteLine("08 - Excluir");
    Console.WriteLine("===================================");
    Console.WriteLine("------------- Cliente -------------");
    Console.WriteLine("09 - Inserir");
    Console.WriteLine("10 - Listar");
    Console.WriteLine("11 - Atualizar");
    Console.WriteLine("12 - Excluir");
    Console.WriteLine("===================================");
    Console.WriteLine("00 - Sair");
    Console.WriteLine();
    Console.Write("Opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static void CategoriaInserir() {
    Console.WriteLine("--- Inserir uma nova categoria ---");
    Console.Write("Informe o id: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome da categoria: ");
    string descricao = Console.ReadLine();
    Categoria obj = new Categoria(id, descricao);
    NCategoria.CategoriaInserir(obj);  // Inserir uma categoria no sistema
    Console.WriteLine("---- Operação realizada com sucesso! ----");
  }

  public static void CategoriaListar() {
    Console.WriteLine("---- Listar as categorias cadastradas ----");
    foreach (Categoria obj in Sistema.CategoriaListar())
      NCategoria.WriteLine(obj);
    Console.WriteLine("------------------------------------------");
  }

  public static void CategoriaAtualizar() {
    Console.WriteLine("-------- Atualizar uma categoria --------");
    Console.Write("Informe o id da categoria a ser atualizada: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o novo nome da categoria: ");
    string descricao = Console.ReadLine();
    Categoria obj = new Categoria(id, descricao);
    Sistema.CategoriaAtualizar(obj);  // Atualizar uma categoria no sistema
    Console.WriteLine("---- Operação realizada com sucesso! ----");
  }

  public static void CategoriaExcluir() {
    Console.WriteLine("--------- Excluir uma categoria ---------");
    Console.Write("Informe o id da categoria a ser excluída: ");
    int id = int.Parse(Console.ReadLine());
    string descricao = "";
    Categoria obj = new Categoria(id, descricao);
    Sistema.CategoriaExcluir(obj);  // Excluir uma categoria no sistema
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
    ClienteListar();
    Console.Write("Informe o id do cliente: ");
    int idCliente = int.Parse(Console.ReadLine());
    Produto obj = new Produto(id, nome, qtd, preco, idCat, idCliente);
    Sistema.ProdutoInserir(obj);  // Inserir um produto no sistema
    Console.WriteLine("---- Operação realizada com sucesso! ----");
  }

  public static void ProdutoListar() {
    Console.WriteLine("----- Listar os produtos cadastrados -----");
    foreach (Produto obj in Sistema.ProdutoListar()) {
      Categoria c = Sistema.CategoriaListar(obj.GetIdCat());
      Cliente s = Sistema.ClienteListar(obj.GetIdCliente());
      Console.WriteLine($"{obj} - {c.GetDescricao()} - {s.Nome}");
    }
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
    ClienteListar();
    Console.Write("Informe o id do cliente: ");
    int idCliente = int.Parse(Console.ReadLine());
    Produto obj = new Produto(id, nome, qtd, preco, idCat, idCliente);
    
    Sistema.ProdutoAtualizar(obj);  // Atualizar um produto no sistema
    Console.WriteLine("---- Operação realizada com sucesso! ----");
  }

  public static void ProdutoExcluir() {
    Console.WriteLine("----------- Excluir um produto -----------");
    Console.Write("Informe o id do produto a ser excluído: ");
    int id = int.Parse(Console.ReadLine());
    Produto obj = new Produto(id);
    Sistema.ProdutoExcluir(obj);  // Excluir um produto no sistema
    Console.WriteLine("---- Operação realizada com sucesso! ----");
  }

  public static void ClienteInserir() {
    Console.WriteLine("-------- Inserir um novo cliente --------");
    Console.Write("Informe o nome do cliente: ");
    string nome = Console.ReadLine();
    Console.Write("Informe o telefone do cliente: ");
    string fone = Console.ReadLine();
    Cliente obj = new Cliente {Nome = nome, Telefone = fone };
    Sistema.ClienteInserir(obj);  // Inserir um cliente no sistema
    Console.WriteLine("---- Operação realizada com sucesso! ----");
  }

  public static void ClienteListar() {
    Console.WriteLine("----- Listar os clientes cadastrados -----");
    foreach (Cliente obj in Sistema.ClienteListar())
      Console.WriteLine(obj);
    Console.WriteLine("------------------------------------------");
  }

  public static void ClienteAtualizar() {
    Console.WriteLine("---------- Atualizar um cliente ----------");
    Console.Write("Informe o id do cliente a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome do cliente: ");
    string nome = Console.ReadLine();
    Console.Write("Informe o telefone do cliente: ");
    string fone = Console.ReadLine();
    Cliente obj = new Cliente {Id = id, Nome = nome, Telefone = fone };
    Sistema.ClienteAtualizar(obj);  // Atualizar um cliente no sistema
    
    Console.WriteLine("---- Operação realizada com sucesso! ----");
  }

  public static void ClienteExcluir() {
    Console.WriteLine("----------- Excluir um cliente -----------");
    Console.Write("Informe o id do cliente a ser excluído: ");
    int id = int.Parse(Console.ReadLine());
    Cliente obj = new Cliente {Id = id };
    Sistema.ClienteExcluir(obj);  // Excluir um cliente no sistema
    Console.WriteLine("---- Operação realizada com sucesso! ----");
  }
  
}