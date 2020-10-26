using System;using System.Collections.Generic;using System.Data;using System.Linq;using System.Threading.Tasks;using drhipocratesCore.Config;using drhipocratesCore.Model;using MySql.Data;using MySql.Data.MySqlClient;namespace drhipocratesCore.Repository{   public class LancamentoscontacorrenteRepository   {      String connect = Connect.getConnect;              public List<Lancamentoscontacorrente> List()         {             MySqlConnection conn = new MySqlConnection(connect);             System.Text.StringBuilder query = new System.Text.StringBuilder();             query.Append("select idlancamentoscontacorrente, idassociado, valorlancamento, datalancamento, tipolancamento, idpedido from lancamentoscontacorrente");                  MySqlCommand comm = new MySqlCommand(query.ToString(), conn);             MySqlDataReader dr = null;             List<Lancamentoscontacorrente> lista = new List<Lancamentoscontacorrente>();                  try             {                 conn.Open();                 dr = comm.ExecuteReader(CommandBehavior.CloseConnection);                      while (dr.Read())                     {                     Lancamentoscontacorrente unitario = new Lancamentoscontacorrente();                          unitario.idlancamentoscontacorrente = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);                     unitario.idassociado = dr.IsDBNull(1) ? 0 : dr.GetInt32(1);                     unitario.valorlancamento = dr.IsDBNull(2) ? 0 : dr.GetFloat(2);                     unitario.datalancamento = dr.IsDBNull(3) ? Convert.ToDateTime( "01/01/0001 00:00:00" ) : dr.GetDateTime(3);                     unitario.tipolancamento = dr.IsDBNull(4) ? "" : dr.GetString(4);                     unitario.idpedido = dr.IsDBNull(5) ? 0 : dr.GetInt32(5);                          lista.Add(unitario);                     }             }             catch (Exception ex)             {                 string ERRO = ex.Message;                 return new List<Lancamentoscontacorrente>();             }             finally             { conn.Close(); }                  return lista;         }              public Lancamentoscontacorrente Get(int primary_key)         {             MySqlConnection conn = new MySqlConnection(connect);             System.Text.StringBuilder query = new System.Text.StringBuilder();             query.Append("select idlancamentoscontacorrente, idassociado, valorlancamento, datalancamento, tipolancamento, idpedido from lancamentoscontacorrente where idlancamentoscontacorrente = @idlancamentoscontacorrente");                  MySqlCommand comm = new MySqlCommand(query.ToString(), conn);             comm.Parameters.Add("@idlancamentoscontacorrente", MySqlDbType.Int32);             comm.Parameters[0].Value = primary_key;             MySqlDataReader dr = null;             Lancamentoscontacorrente lista = new Lancamentoscontacorrente();             try             {                 conn.Open();                 dr = comm.ExecuteReader(CommandBehavior.CloseConnection);                      while (dr.Read())                     {                     Lancamentoscontacorrente unitario = new Lancamentoscontacorrente();                          unitario.idlancamentoscontacorrente = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);                     unitario.idassociado = dr.IsDBNull(1) ? 0 : dr.GetInt32(1);                     unitario.valorlancamento = dr.IsDBNull(2) ? 0 : dr.GetFloat(2);                     unitario.datalancamento = dr.IsDBNull(3) ? Convert.ToDateTime( "01/01/0001 00:00:00" ) : dr.GetDateTime(3);                     unitario.tipolancamento = dr.IsDBNull(4) ? "" : dr.GetString(4);                     unitario.idpedido = dr.IsDBNull(5) ? 0 : dr.GetInt32(5);                          lista = unitario;                     }             }             catch (Exception ex)             {                 string ERRO = ex.Message;                 return new Lancamentoscontacorrente();             }             finally             { conn.Close(); }                  return lista;         }    public int Post(Lancamentoscontacorrente lancamentoscontacorrente)    {        MySqlConnection conn = new MySqlConnection(connect);        System.Text.StringBuilder query = new System.Text.StringBuilder();        query.Append("insert into lancamentoscontacorrente (idassociado, valorlancamento, datalancamento, tipolancamento, idpedido) values (@idassociado, @valorlancamento, @datalancamento, @tipolancamento, @idpedido)");        MySqlCommand comm = new MySqlCommand(query.ToString(), conn);        comm.Parameters.Add("@idassociado", MySqlDbType.Int32 );        comm.Parameters.Add("@valorlancamento", MySqlDbType.Float );        comm.Parameters.Add("@datalancamento", MySqlDbType.DateTime );        comm.Parameters.Add("@tipolancamento", MySqlDbType.VarChar );        comm.Parameters.Add("@idpedido", MySqlDbType.Int32 );        comm.Parameters[0].Value = lancamentoscontacorrente.idassociado;        comm.Parameters[1].Value = lancamentoscontacorrente.valorlancamento;        comm.Parameters[2].Value = lancamentoscontacorrente.datalancamento;        comm.Parameters[3].Value = lancamentoscontacorrente.tipolancamento;        comm.Parameters[4].Value = lancamentoscontacorrente.idpedido;        Int32 id = 0;        try        {            conn.Open();            comm.ExecuteNonQuery();            query.Clear();            query.Append("Select @@Identity");            comm.CommandText = query.ToString();            var resultado = comm.ExecuteScalar();            id = Convert.ToInt32(resultado);        }        catch (Exception ex)        {            string ERRO = ex.Message;            return 0;        }        finally        { conn.Close(); }        return id;    }    public int Put(Lancamentoscontacorrente lancamentoscontacorrente)    {        MySqlConnection conn = new MySqlConnection(connect);        System.Text.StringBuilder query = new System.Text.StringBuilder();        query.Append("update lancamentoscontacorrente set idlancamentoscontacorrente = @idlancamentoscontacorrente, idassociado = @idassociado, valorlancamento = @valorlancamento, datalancamento = @datalancamento, tipolancamento = @tipolancamento, idpedido = @idpedido where idlancamentoscontacorrente = @idlancamentoscontacorrente");        MySqlCommand comm = new MySqlCommand(query.ToString(), conn);        comm.Parameters.Add("@idlancamentoscontacorrente", MySqlDbType.Int32 );        comm.Parameters.Add("@idassociado", MySqlDbType.Int32 );        comm.Parameters.Add("@valorlancamento", MySqlDbType.Float );        comm.Parameters.Add("@datalancamento", MySqlDbType.DateTime );        comm.Parameters.Add("@tipolancamento", MySqlDbType.VarChar );        comm.Parameters.Add("@idpedido", MySqlDbType.Int32 );        comm.Parameters[0].Value = lancamentoscontacorrente.idlancamentoscontacorrente;        comm.Parameters[1].Value = lancamentoscontacorrente.idassociado;        comm.Parameters[2].Value = lancamentoscontacorrente.valorlancamento;        comm.Parameters[3].Value = lancamentoscontacorrente.datalancamento;        comm.Parameters[4].Value = lancamentoscontacorrente.tipolancamento;        comm.Parameters[5].Value = lancamentoscontacorrente.idpedido;        try        {            conn.Open();            return comm.ExecuteNonQuery();        }        catch (Exception ex)        {            string ERRO = ex.Message;            return 0;        }        finally        { conn.Close(); }    }    public int Delete(int idlancamentoscontacorrente)    {        MySqlConnection conn = new MySqlConnection(connect);        System.Text.StringBuilder query = new System.Text.StringBuilder();        query.Append("delete from lancamentoscontacorrente where idlancamentoscontacorrente = @idlancamentoscontacorrente");        MySqlCommand comm = new MySqlCommand(query.ToString(), conn);        comm.Parameters.Add("@idlancamentoscontacorrente", MySqlDbType.Int32 );        comm.Parameters[0].Value = idlancamentoscontacorrente;        try        {            conn.Open();            return comm.ExecuteNonQuery();        }        catch (Exception ex)        {            string ERRO = ex.Message;            return 0;        }        finally        { conn.Close(); }    }   }}