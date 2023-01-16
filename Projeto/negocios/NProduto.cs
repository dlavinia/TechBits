using System;
using System.Collections.Generic;

class NProduto {
  private static List<Produto> prods = new List<Produto>();
  public static void Inserir(Produto prod) {
    prods.Add(prod);
  }
  public static List<Produto> Listar() {
    return prods;
  }
  public static Produto Listar(int id) {
    foreach (Produto obj in prods) 
      if (obj.GetId() == id) return obj;
    return null;
  }
  public static void Atualizar(Produto prod) {
    Produto aux = Listar(prod.GetId());
    if (aux != null) {
      aux.SetNome(prod.GetNome());
      aux.SetQtd(prod.GetQtd());
      aux.SetPreco(prod.GetPreco());
      aux.SetIdCat(prod.GetIdCat());
    }
  }
  public static void Excluir(Produto prod) {
    Produto aux = Listar(prod.GetId());
    if (aux != null) {
      prods.Remove(aux);
    }
  }
}