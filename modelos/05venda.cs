using System;

class Venda {
  public int Id { get; set; }
  public DateTime Data { get; set; }
  public bool Carrinho { get; set; }
  public Cliente Usuario { get; set; }
  public override string ToString() {
    return $"{Id} - {Data} - {Usuario}";
  }
}