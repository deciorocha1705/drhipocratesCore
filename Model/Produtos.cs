using System;using System.Collections.Generic;using System.Linq;using System.Threading.Tasks;    namespace drhipocratesCore.Model{    /// <summary>    /// Summary description for produtos    /// </summary>    public class Produtos    {         public Produtos() {}                 public Int32 idprodutos { get; set; }         public String nome { get; set; }         public String descricao { get; set; }         public String ativo { get; set; }         public String categoria { get; set; }         public Int32 idfabricante { get; set; }    }}