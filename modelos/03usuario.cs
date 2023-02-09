using System;

public class Usuario {
  public int Id { get; set; }
  public string Nome { get; set; }
  public string User { get; set; }
  public string Senha { get; set; }
  public DateTime Nascimento { get; set; }
  public bool Admin { get; set; }

  public override string ToString() {
    return $"{Id} - {Nome} - {Nascimento:dd/MM/yyyy}";
  }
}