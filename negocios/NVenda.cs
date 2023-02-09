using System;
using System.Collections.Generic;
using Modelos;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace Negocios {
  class NVenda {
    private static List<Venda> vendas = new List<Venda>();

    public static List<Venda> Listar() {
      return Abrir();
    }
    public static Venda Listar(int id) {
      vendas = Abrir();
      foreach (Venda obj in vendas) 
        if (obj.Id == id) return obj;
      return null;
    }

    public static List<ItemVenda> ListarItens(Venda v) {
      return v.ItemListar();
    }

    public static void AddCarrinho(Venda v, int qtd, Produto prod) {
      v.ItemInserir(qtd, prod);
    }  
    public static void FinalizarCompra(Venda v) {
      vendas = Abrir();
      int id = 0;
      foreach (Venda aux in vendas)
        if (aux.Id > id) id = aux.Id;
      v.Id = id + 1;
      vendas.Add(v);
      v.Carrinho = false;
      Salvar(vendas);
    }
    public static void Excluir(Venda v) {
      vendas = Abrir();
      v.ItemExcluir();
      Salvar(vendas);
    }
    
    private static string arquivo = "arquivos/vendas.xml";
  
    private static List<Venda> Abrir() {
      try {
          return Arquivo<List<Venda>>.Abrir(arquivo);
      }
      catch(FileNotFoundException) {
        return new List<Venda>();
      }
    }
    
    private static void Salvar(List<Venda> obj) {
      Arquivo<List<Venda>>.Salvar(arquivo, obj);
    }
  }
}