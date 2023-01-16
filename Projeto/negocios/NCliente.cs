using System;
using System.Collections.Generic;

class NCliente {
  private static List<Cliente> usuarios = new List<Cliente>();
  public static void Inserir(Cliente c) {
    int id = 0;
    foreach (Cliente aux in usuarios)
      if (aux.Id > id) id = aux.Id;
    c.Id = id + 1;
    usuario.Add(c);
  }
  public static List<Cliente> Listar() {
    return usuarios;
  }
  public static Cliente Listar(int id) {
    foreach (Cliente obj in usuarios) 
      if (obj.Id == id) return obj;
    return null;
  }
  public static void Atualizar(Cliente c) {
    Cliente aux = Listar(c.Id);
    if (aux != null) {
      aux.Nome = c.Nome;
      aux.Nascimento = c.Nascimento;
      aux.User = c.User;
      aux.Senha = c.Senha;
    }
  }
  public static void Excluir(Cliente c) {
    Cliente aux = Listar(c.Id);
    if (aux != null)
      usuarios.Remove(aux);
  }
}