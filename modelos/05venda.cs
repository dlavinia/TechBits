using System;
using System.Collections.Generic;

namespace Modelos {
  public class Venda {
    private List<ItemVenda> itens = new List<ItemVenda>();
    
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public bool Carrinho { get; set; }
    public int IdUser { get; set;}
    public string NomeUser { get; set;}
    public List<ItemVenda> Itens { get => itens; set => itens = value; }

    public Venda() { }
    
    public Venda(DateTime data, Usuario user) {
      this.Data = data;
      this.Carrinho = true;
      this.IdUser = user.Id;
      this.NomeUser = user.Nome;
    }

    private ItemVenda ItemListar(Produto prod) {
      foreach(ItemVenda iv in itens) 
        if (iv.Prod == prod) return iv;
      return null;  
    }

    public List<ItemVenda> ItemListar() {
      return itens;
    }

    public void ItemInserir(int qtd, Produto prod) {
      ItemVenda item = ItemListar(prod);
      if (item == null) {
        item = new ItemVenda(qtd, prod);
        itens.Add(item);
      }
      else
        item.Qtd = item.Qtd + qtd;
    }

    public void ItemExcluir() {
      itens.Clear();
    }

    public override string ToString() {
      return $"{Id} - {Data} - {NomeUser}";
    }
  }
}