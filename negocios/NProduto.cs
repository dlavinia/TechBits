using System;
using System.Collections.Generic;
using Modelos;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace Negocios {
  class NProduto {
    private static List<Produto> prods = new List<Produto>();
    public static void Inserir(Produto prod) {
      prods = Abrir();
      prods.Add(prod);
      Salvar(prods);
    }
    public static List<Produto> Listar() {
      return Abrir();
    }
    public static Produto Listar(int id) {
     prods = Abrir();
      foreach (Produto obj in prods) 
        if (obj.GetId() == id) return obj;
      return null;
    }
    public static void Atualizar(Produto prod) {
      Produto aux = Listar(prod.GetId());
      if (aux != null)
        aux.SetTitulo(prod.GetTitulo());
        aux.SetQtd(prod.GetQtd());
        aux.SetPreco(prod.GetPreco());
        aux.SetIdCat(prod.GetIdCat());
      Salvar(prods);
    }
    public static void Excluir(Produto prod) {
       prods = Abrir();
      Produto aux = Listar(prod.GetId());
      if (aux != null) {
        prods.Remove(aux);
        Salvar(prods);
      }
    }
    private static string arquivo = "arquivos/produtos.xml";
  
    private static List<Produto> Abrir() {
      try {
          return Arquivo<List<Produto>>.Abrir(arquivo);
      }
      catch(FileNotFoundException) {
        return new List<Produto>();
      }
    }
    
    private static void Salvar(List<Produto> obj) {
      Arquivo<List<Produto>>.Salvar(arquivo, obj);
    }
  }
}