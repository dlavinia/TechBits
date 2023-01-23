using System;

class ItemVenda {
  public int Id { get; set; }
  public int IdProd { get; set; }
  public int IdVenda { get; set; }
  public int Qtd { get; set; }
  public double Preco { get; set; }
  public override string ToString() {
    return $"{Id} - {IdProd} - {IdVenda} - {Qtd} - {Preco}";
  }
}