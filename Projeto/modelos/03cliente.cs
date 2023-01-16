using System;

class Cliente : IComparable {
  public int Id { get; set; }
  public string Nome { get; set; }
  public string User { get; set; }
  public string Senha { get; set; }
  public DateTime Nascimento { get; set; }
  public boolean Admin { get; set; }
  public int CompareTo(object obj) {
    return Nome.CompareTo(((Cliente)obj).Nome);
  }
  public override string ToString() {
    return $"{Id} - {Nome} - {Nascimento:dd/MM/yyyy}";
  }
}