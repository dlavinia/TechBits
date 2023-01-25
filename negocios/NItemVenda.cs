using System;
using System.Collections.Generic;
using Modelos;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace Negocios {
  class NItemVenda {
    private static List<ItemVenda> itens = new List<ItemVenda>();
    public static void Inserir(ItemVenda item) {
      itens.Add(item);
    }
    public static List<ItemVenda> Listar() {
      return itens();
    }
    public static ItemVenda Listar(int id) {
      foreach (ItemVenda obj in itens) 
        if (obj.Id == id) return obj;
      return null;
    }
    public static void Excluir(ItemVenda item) {
      ItemVenda aux = Listar(item.Id);
      if (aux != null) {
        itens.Remove(aux);
      }
    }
    
}