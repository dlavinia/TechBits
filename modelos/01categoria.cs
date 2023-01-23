using System;

namespace Modelos {
  
  public class Categoria {
    public int id;
    public string descricao;
    public Categoria() { }
    public Categoria(int id, string descricao) {
      this.id = id;
      this.descricao = descricao;
    }
    public void SetId(int id) {
      this.id = id;
    }
    public void SetDescricao(string descricao) {
      this.descricao = descricao;
    }
    public int GetId() {
      return id;
    }
    public string GetDescricao() {
      return descricao;
    }
    public override string ToString() {
      return $"{id} - {descricao}";
    }
  }
}