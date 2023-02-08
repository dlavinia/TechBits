using System;

public class ItemVenda {
  public Produto Prod { get; set;}
  public int IdProd { get; set; }
  public int IdVenda { get; set; }
  public int Qtd { get; set; }
  public double Preco { get; set; }

  public ItemVenda() { }

  public ItemVenda(int qtd, Produto prod) {
    this.Prod = prod;
    this.Preco = prod.GetPreco();
    this.IdProd = prod.GetId();
    if (qtd > 0) this.Qtd = qtd;
    
  }
  public override string ToString() {
    return $"{IdProd} - {Prod.GetTitulo()} - {Qtd} - {Preco}";
  }
}