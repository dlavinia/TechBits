using System;

public class Produto {
  public int id, qtd, idCat;
  public string titulo;
  public double preco;
  public Produto() { }
  public Produto(int id, string titulo, int qtd, double preco, int idCat) {
    this.id = id;
    this.titulo = titulo;
    if (qtd > 0) this.qtd = qtd;
    if (preco > 0) this.preco = preco;
    this.idCat = idCat;
  }
  
  public Produto(int id) {
    this.id = id;
  }
  public void SetId(int id) {
    this.id = id;
  }
  public void SetTitulo(string titulo) {
    this.titulo = titulo;
  }
  public void SetQtd(int qtd) {
    if (qtd > 0) this.qtd = qtd;
  }
  public void SetPreco(double preco) {
    if (preco > 0) this.preco = preco;
  }
  public void SetIdCat(int idCat) {
    this.idCat = idCat;
  }
  public int GetId() {
    return id;
  }
  public string GetTitulo() {
    return titulo;
  }
  public int GetQtd() {
    return qtd;
  }
  public double GetPreco() {
    return preco;
  }
  public int GetIdCat() {
    return idCat;
  }
  public override string ToString() {
    return $"{id} - {titulo} - {qtd} - {preco:0.00} - {idCat}";
  }
}