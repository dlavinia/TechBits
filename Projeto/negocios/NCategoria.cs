using System;
using System.Collections.Generic;

class NCategoria {
  private static List<Categoria> cats = new List<Categoria>();
  public static void Inserir(Categoria cat) {
    cats.Add(cat);
  }
  public static List<Categoria> Listar() {
    return cats;
  }
  public static Categoria Listar(int id) {
    foreach (Categoria obj in cats) 
      if (obj.GetId() == id) return obj;
    return null;
  }
  public static void Atualizar(Categoria cat) {
    Categoria aux = Listar(cat.GetId());
    if (aux != null)
      aux.SetDescricao(cat.GetDescricao());
  }
  public static void Excluir(Categoria cat) {
    Produto aux = Listar(cat.GetId());
    if (aux != null) {
      cats.Remove(aux);
    }
  }
}