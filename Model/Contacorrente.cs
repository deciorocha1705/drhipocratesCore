using System;using System.Collections.Generic;using System.Linq;using System.Threading.Tasks;    namespace drhipocratesCore.Model{    /// <summary>    /// Summary description for contacorrente    /// </summary>    public class Contacorrente    {         public Contacorrente() {}                 public Int32 idcontacorrente { get; set; }         public Int32 idassociado { get; set; }         public DateTime datasaldo { get; set; }         public float saldo { get; set; }    }}