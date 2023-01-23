using System;
using System.Collections.Generic;
using Modelos;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace Negocios {
  class NCategoria {
    private static List<Categoria> cats = new List<Categoria>();
    public static void Inserir(Categoria cat) {
      cats = Abrir();
      cats.Add(cat);
      Salvar(cats);
    }
    public static List<Categoria> Listar() {
      return Abrir();
;
    }
    public static Categoria Listar(int id) {
      Abrir();
      foreach (Categoria obj in cats) 
        if (obj.GetId() == id) return obj;
      return null;
    }
    public static void Atualizar(Categoria cat) {
      Categoria aux = Listar(cat.GetId());
      if (aux != null)
        aux.SetDescricao(cat.GetDescricao());
      Salvar(cats);
    }
    public static void Excluir(Categoria cat) {
      Abrir();
      Categoria aux = Listar(cat.GetId());
      if (aux != null) {
        cats.Remove(aux);
        Salvar(cats);
      }
    }
    private static string arquivo = "arquivos/categorias.xml";
  
    private static List<Categoria> Abrir() {
      try {
          return Arquivo<List<Categoria>>.Abrir(arquivo);
      }
      catch(FileNotFoundException) {
        return new List<Categoria>();
      }
    }
    
    private static void Salvar(List<Categoria> obj) {
      Arquivo<List<Categoria>>.Salvar(arquivo, obj);
    }
  }
}