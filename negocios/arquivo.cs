using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

static class Arquivo<T> {
  public static T Abrir(string arquivo) {
    XmlSerializer xml = new XmlSerializer(typeof(T));
    StreamReader arq = new StreamReader(arquivo);
    T obj = (T) xml.Deserialize(arq);
    arq.Close();
    return obj;
  }
  public static void Salvar(string arquivo, T obj) {
    XmlSerializer xml = new XmlSerializer(typeof(T));
    StreamWriter arq = new StreamWriter(arquivo, false);
    xml.Serialize(arq, obj);
    arq.Close();
  }
}