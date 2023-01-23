using System;
using System.Collections.Generic;
using Modelos;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace Negocios {
  class NUsuario {
    private static List<Usuario> users = new List<Usuario>();
    public static void Inserir(Usuario user) {
        users = Abrir();
        int id = 0;
        foreach (Usuario aux in users)
        if (aux.Id > id) id = aux.Id;
        user.Id = id + 1;
        users.Add(user);
        Salvar(users);
    }
    public static List<Usuario> Listar() {
      return Abrir();
    }
    public static Usuario Listar(int id) {
      Abrir();
      foreach (Usuario obj in users) 
        if (obj.Id == id) return obj;
      return null;
    }
    public static void Atualizar(Usuario user) {
      Usuario aux = Listar(user.Id);
      if (aux != null)
        aux.Nome = user.Nome;
        aux.Nascimento = user.Nascimento;
        aux.User = user.User;
        aux.Senha = user.Senha;
      Salvar(users);
    }
    public static void Excluir(Usuario user) {
      users = Abrir();
      Usuario aux = Listar(user.Id);
      if (aux != null) {
        users.Remove(aux);
        Salvar(users);
      }
    }
    private static string arquivo = "arquivos/usuarios.xml";
  
    private static List<Usuario> Abrir() {
      try {
          return Arquivo<List<Usuario>>.Abrir(arquivo);
      }
      catch(FileNotFoundException) {
        return new List<Usuario>();
      }
    }
    
    private static void Salvar(List<Usuario> obj) {
      Arquivo<List<Usuario>>.Salvar(arquivo, obj);
    }
  }
}