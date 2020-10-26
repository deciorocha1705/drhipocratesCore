using System;using System.Collections.Generic;using System.Data;using System.Linq;using System.Threading.Tasks;using drhipocratesCore.Config;using drhipocratesCore.Model;using MySql.Data;using MySql.Data.MySqlClient;namespace drhipocratesCore.Repository{   public class PagamentopedidoRepository   {      String connect = Connect.getConnect;              public List<Pagamentopedido> List()         {             MySqlConnection conn = new MySqlConnection(connect);             System.Text.StringBuilder query = new System.Text.StringBuilder();             query.Append("select idpagamentopedido, tipopedido, idpontoapoio, idpedido, idboleto, valorpagamento, valorpagocomsaldo, valorpagonoboleto, valorpagoaopa from pagamentopedido");                  MySqlCommand comm = new MySqlCommand(query.ToString(), conn);             MySqlDataReader dr = null;             List<Pagamentopedido> lista = new List<Pagamentopedido>();                  try             {                 conn.Open();                 dr = comm.ExecuteReader(CommandBehavior.CloseConnection);                      while (dr.Read())                     {                     Pagamentopedido unitario = new Pagamentopedido();                          unitario.idpagamentopedido = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);                     unitario.tipopedido = dr.IsDBNull(1) ? "" : dr.GetString(1);                     unitario.idpontoapoio = dr.IsDBNull(2) ? 0 : dr.GetInt32(2);                     unitario.idpedido = dr.IsDBNull(3) ? 0 : dr.GetInt32(3);                     unitario.idboleto = dr.IsDBNull(4) ? 0 : dr.GetInt32(4);                     unitario.valorpagamento = dr.IsDBNull(5) ? 0 : dr.GetFloat(5);                     unitario.valorpagocomsaldo = dr.IsDBNull(6) ? 0 : dr.GetFloat(6);                     unitario.valorpagonoboleto = dr.IsDBNull(7) ? 0 : dr.GetFloat(7);                     unitario.valorpagoaopa = dr.IsDBNull(8) ? 0 : dr.GetFloat(8);                          lista.Add(unitario);                     }             }             catch (Exception ex)             {                 string ERRO = ex.Message;                 return new List<Pagamentopedido>();             }             finally             { conn.Close(); }                  return lista;         }              public Pagamentopedido Get(int primary_key)         {             MySqlConnection conn = new MySqlConnection(connect);             System.Text.StringBuilder query = new System.Text.StringBuilder();             query.Append("select idpagamentopedido, tipopedido, idpontoapoio, idpedido, idboleto, valorpagamento, valorpagocomsaldo, valorpagonoboleto, valorpagoaopa from pagamentopedido where idpagamentopedido = @idpagamentopedido");                  MySqlCommand comm = new MySqlCommand(query.ToString(), conn);             comm.Parameters.Add("@idpagamentopedido", MySqlDbType.Int32);             comm.Parameters[0].Value = primary_key;             MySqlDataReader dr = null;             Pagamentopedido lista = new Pagamentopedido();             try             {                 conn.Open();                 dr = comm.ExecuteReader(CommandBehavior.CloseConnection);                      while (dr.Read())                     {                     Pagamentopedido unitario = new Pagamentopedido();                          unitario.idpagamentopedido = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);                     unitario.tipopedido = dr.IsDBNull(1) ? "" : dr.GetString(1);                     unitario.idpontoapoio = dr.IsDBNull(2) ? 0 : dr.GetInt32(2);                     unitario.idpedido = dr.IsDBNull(3) ? 0 : dr.GetInt32(3);                     unitario.idboleto = dr.IsDBNull(4) ? 0 : dr.GetInt32(4);                     unitario.valorpagamento = dr.IsDBNull(5) ? 0 : dr.GetFloat(5);                     unitario.valorpagocomsaldo = dr.IsDBNull(6) ? 0 : dr.GetFloat(6);                     unitario.valorpagonoboleto = dr.IsDBNull(7) ? 0 : dr.GetFloat(7);                     unitario.valorpagoaopa = dr.IsDBNull(8) ? 0 : dr.GetFloat(8);                          lista = unitario;                     }             }             catch (Exception ex)             {                 string ERRO = ex.Message;                 return new Pagamentopedido();             }             finally             { conn.Close(); }                  return lista;         }    public int Post(Pagamentopedido pagamentopedido)    {        MySqlConnection conn = new MySqlConnection(connect);        System.Text.StringBuilder query = new System.Text.StringBuilder();        query.Append("insert into pagamentopedido (tipopedido, idpontoapoio, idpedido, idboleto, valorpagamento, valorpagocomsaldo, valorpagonoboleto, valorpagoaopa) values (@tipopedido, @idpontoapoio, @idpedido, @idboleto, @valorpagamento, @valorpagocomsaldo, @valorpagonoboleto, @valorpagoaopa)");        MySqlCommand comm = new MySqlCommand(query.ToString(), conn);        comm.Parameters.Add("@tipopedido", MySqlDbType.VarChar );        comm.Parameters.Add("@idpontoapoio", MySqlDbType.Int32 );        comm.Parameters.Add("@idpedido", MySqlDbType.Int32 );        comm.Parameters.Add("@idboleto", MySqlDbType.Int32 );        comm.Parameters.Add("@valorpagamento", MySqlDbType.Float );        comm.Parameters.Add("@valorpagocomsaldo", MySqlDbType.Float );        comm.Parameters.Add("@valorpagonoboleto", MySqlDbType.Float );        comm.Parameters.Add("@valorpagoaopa", MySqlDbType.Float );        comm.Parameters[0].Value = pagamentopedido.tipopedido;        comm.Parameters[1].Value = pagamentopedido.idpontoapoio;        comm.Parameters[2].Value = pagamentopedido.idpedido;        comm.Parameters[3].Value = pagamentopedido.idboleto;        comm.Parameters[4].Value = pagamentopedido.valorpagamento;        comm.Parameters[5].Value = pagamentopedido.valorpagocomsaldo;        comm.Parameters[6].Value = pagamentopedido.valorpagonoboleto;        comm.Parameters[7].Value = pagamentopedido.valorpagoaopa;        Int32 id = 0;        try        {            conn.Open();            comm.ExecuteNonQuery();            query.Clear();            query.Append("Select @@Identity");            comm.CommandText = query.ToString();            var resultado = comm.ExecuteScalar();            id = Convert.ToInt32(resultado);        }        catch (Exception ex)        {            string ERRO = ex.Message;            return 0;        }        finally        { conn.Close(); }        return id;    }    public int Put(Pagamentopedido pagamentopedido)    {        MySqlConnection conn = new MySqlConnection(connect);        System.Text.StringBuilder query = new System.Text.StringBuilder();        query.Append("update pagamentopedido set idpagamentopedido = @idpagamentopedido, tipopedido = @tipopedido, idpontoapoio = @idpontoapoio, idpedido = @idpedido, idboleto = @idboleto, valorpagamento = @valorpagamento, valorpagocomsaldo = @valorpagocomsaldo, valorpagonoboleto = @valorpagonoboleto, valorpagoaopa = @valorpagoaopa where idpagamentopedido = @idpagamentopedido");        MySqlCommand comm = new MySqlCommand(query.ToString(), conn);        comm.Parameters.Add("@idpagamentopedido", MySqlDbType.Int32 );        comm.Parameters.Add("@tipopedido", MySqlDbType.VarChar );        comm.Parameters.Add("@idpontoapoio", MySqlDbType.Int32 );        comm.Parameters.Add("@idpedido", MySqlDbType.Int32 );        comm.Parameters.Add("@idboleto", MySqlDbType.Int32 );        comm.Parameters.Add("@valorpagamento", MySqlDbType.Float );        comm.Parameters.Add("@valorpagocomsaldo", MySqlDbType.Float );        comm.Parameters.Add("@valorpagonoboleto", MySqlDbType.Float );        comm.Parameters.Add("@valorpagoaopa", MySqlDbType.Float );        comm.Parameters[0].Value = pagamentopedido.idpagamentopedido;        comm.Parameters[1].Value = pagamentopedido.tipopedido;        comm.Parameters[2].Value = pagamentopedido.idpontoapoio;        comm.Parameters[3].Value = pagamentopedido.idpedido;        comm.Parameters[4].Value = pagamentopedido.idboleto;        comm.Parameters[5].Value = pagamentopedido.valorpagamento;        comm.Parameters[6].Value = pagamentopedido.valorpagocomsaldo;        comm.Parameters[7].Value = pagamentopedido.valorpagonoboleto;        comm.Parameters[8].Value = pagamentopedido.valorpagoaopa;        try        {            conn.Open();            return comm.ExecuteNonQuery();        }        catch (Exception ex)        {            string ERRO = ex.Message;            return 0;        }        finally        { conn.Close(); }    }    public int Delete(int idpagamentopedido)    {        MySqlConnection conn = new MySqlConnection(connect);        System.Text.StringBuilder query = new System.Text.StringBuilder();        query.Append("delete from pagamentopedido where idpagamentopedido = @idpagamentopedido");        MySqlCommand comm = new MySqlCommand(query.ToString(), conn);        comm.Parameters.Add("@idpagamentopedido", MySqlDbType.Int32 );        comm.Parameters[0].Value = idpagamentopedido;        try        {            conn.Open();            return comm.ExecuteNonQuery();        }        catch (Exception ex)        {            string ERRO = ex.Message;            return 0;        }        finally        { conn.Close(); }    }   }}