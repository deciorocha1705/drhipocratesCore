using System;using System.Collections.Generic;using System.Data;using System.Linq;using System.Threading.Tasks;using drhipocratesCore.Config;using drhipocratesCore.Model;using MySql.Data;using MySql.Data.MySqlClient;namespace drhipocratesCore.Repository{   public class ImagensprodutosRepository   {      String connect = Connect.getConnect;              public List<Imagensprodutos> List()         {             MySqlConnection conn = new MySqlConnection(connect);             System.Text.StringBuilder query = new System.Text.StringBuilder();             query.Append("select idimagensprodutos, idproduto, path, principal from imagensprodutos");                  MySqlCommand comm = new MySqlCommand(query.ToString(), conn);             MySqlDataReader dr = null;             List<Imagensprodutos> lista = new List<Imagensprodutos>();                  try             {                 conn.Open();                 dr = comm.ExecuteReader(CommandBehavior.CloseConnection);                      while (dr.Read())                     {                     Imagensprodutos unitario = new Imagensprodutos();                          unitario.idimagensprodutos = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);                     unitario.idproduto = dr.IsDBNull(1) ? 0 : dr.GetInt32(1);                     unitario.path = dr.IsDBNull(2) ? "" : dr.GetString(2);                     unitario.principal = dr.IsDBNull(3) ? "" : dr.GetString(3);                          lista.Add(unitario);                     }             }             catch (Exception ex)             {                 string ERRO = ex.Message;                 return new List<Imagensprodutos>();             }             finally             { conn.Close(); }                  return lista;         }              public Imagensprodutos Get(int primary_key)         {             MySqlConnection conn = new MySqlConnection(connect);             System.Text.StringBuilder query = new System.Text.StringBuilder();             query.Append("select idimagensprodutos, idproduto, path, principal from imagensprodutos where idimagensprodutos = @idimagensprodutos");                  MySqlCommand comm = new MySqlCommand(query.ToString(), conn);             comm.Parameters.Add("@idimagensprodutos", MySqlDbType.Int32);             comm.Parameters[0].Value = primary_key;             MySqlDataReader dr = null;             Imagensprodutos lista = new Imagensprodutos();             try             {                 conn.Open();                 dr = comm.ExecuteReader(CommandBehavior.CloseConnection);                      while (dr.Read())                     {                     Imagensprodutos unitario = new Imagensprodutos();                          unitario.idimagensprodutos = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);                     unitario.idproduto = dr.IsDBNull(1) ? 0 : dr.GetInt32(1);                     unitario.path = dr.IsDBNull(2) ? "" : dr.GetString(2);                     unitario.principal = dr.IsDBNull(3) ? "" : dr.GetString(3);                          lista = unitario;                     }             }             catch (Exception ex)             {                 string ERRO = ex.Message;                 return new Imagensprodutos();             }             finally             { conn.Close(); }                  return lista;         }    public int Post(Imagensprodutos imagensprodutos)    {        MySqlConnection conn = new MySqlConnection(connect);        System.Text.StringBuilder query = new System.Text.StringBuilder();        query.Append("insert into imagensprodutos (idproduto, path, principal) values (@idproduto, @path, @principal)");        MySqlCommand comm = new MySqlCommand(query.ToString(), conn);        comm.Parameters.Add("@idproduto", MySqlDbType.Int32 );        comm.Parameters.Add("@path", MySqlDbType.VarChar );        comm.Parameters.Add("@principal", MySqlDbType.VarChar );        comm.Parameters[0].Value = imagensprodutos.idproduto;        comm.Parameters[1].Value = imagensprodutos.path;        comm.Parameters[2].Value = imagensprodutos.principal;        Int32 id = 0;        try        {            conn.Open();            comm.ExecuteNonQuery();            query.Clear();            query.Append("Select @@Identity");            comm.CommandText = query.ToString();            var resultado = comm.ExecuteScalar();            id = Convert.ToInt32(resultado);        }        catch (Exception ex)        {            string ERRO = ex.Message;            return 0;        }        finally        { conn.Close(); }        return id;    }    public int Put(Imagensprodutos imagensprodutos)    {        MySqlConnection conn = new MySqlConnection(connect);        System.Text.StringBuilder query = new System.Text.StringBuilder();        query.Append("update imagensprodutos set idimagensprodutos = @idimagensprodutos, idproduto = @idproduto, path = @path, principal = @principal where idimagensprodutos = @idimagensprodutos");        MySqlCommand comm = new MySqlCommand(query.ToString(), conn);        comm.Parameters.Add("@idimagensprodutos", MySqlDbType.Int32 );        comm.Parameters.Add("@idproduto", MySqlDbType.Int32 );        comm.Parameters.Add("@path", MySqlDbType.VarChar );        comm.Parameters.Add("@principal", MySqlDbType.VarChar );        comm.Parameters[0].Value = imagensprodutos.idimagensprodutos;        comm.Parameters[1].Value = imagensprodutos.idproduto;        comm.Parameters[2].Value = imagensprodutos.path;        comm.Parameters[3].Value = imagensprodutos.principal;        try        {            conn.Open();            return comm.ExecuteNonQuery();        }        catch (Exception ex)        {            string ERRO = ex.Message;            return 0;        }        finally        { conn.Close(); }    }    public int Delete(int idimagensprodutos)    {        MySqlConnection conn = new MySqlConnection(connect);        System.Text.StringBuilder query = new System.Text.StringBuilder();        query.Append("delete from imagensprodutos where idimagensprodutos = @idimagensprodutos");        MySqlCommand comm = new MySqlCommand(query.ToString(), conn);        comm.Parameters.Add("@idimagensprodutos", MySqlDbType.Int32 );        comm.Parameters[0].Value = idimagensprodutos;        try        {            conn.Open();            return comm.ExecuteNonQuery();        }        catch (Exception ex)        {            string ERRO = ex.Message;            return 0;        }        finally        { conn.Close(); }    }   }}