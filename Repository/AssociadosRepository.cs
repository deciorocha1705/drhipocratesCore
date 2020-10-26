using System;using System.Collections.Generic;using System.Data;using System.Linq;using System.Threading.Tasks;using drhipocratesCore.Config;using drhipocratesCore.Model;using MySql.Data;using MySql.Data.MySqlClient;namespace drhipocratesCore.Repository{   public class AssociadosRepository   {      String connect = Connect.getConnect;              public List<Associados> List()         {             MySqlConnection conn = new MySqlConnection(connect);             System.Text.StringBuilder query = new System.Text.StringBuilder();             query.Append("select idassociados, cpf, nome, cep, endereco, numero, complemento, bairro, cidade, estado, idupline, datanascimento, datainclusao, celular, telefonefixo, usuario, senha, idtipousuario, idtipoadesao from associados");                  MySqlCommand comm = new MySqlCommand(query.ToString(), conn);             MySqlDataReader dr = null;             List<Associados> lista = new List<Associados>();                  try             {                 conn.Open();                 dr = comm.ExecuteReader(CommandBehavior.CloseConnection);                      while (dr.Read())                     {                     Associados unitario = new Associados();                          unitario.idassociados = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);                     unitario.cpf = dr.IsDBNull(1) ? "" : dr.GetString(1);                     unitario.nome = dr.IsDBNull(2) ? "" : dr.GetString(2);                     unitario.cep = dr.IsDBNull(3) ? "" : dr.GetString(3);                     unitario.endereco = dr.IsDBNull(4) ? "" : dr.GetString(4);                     unitario.numero = dr.IsDBNull(5) ? "" : dr.GetString(5);                     unitario.complemento = dr.IsDBNull(6) ? "" : dr.GetString(6);                     unitario.bairro = dr.IsDBNull(7) ? "" : dr.GetString(7);                     unitario.cidade = dr.IsDBNull(8) ? "" : dr.GetString(8);                     unitario.estado = dr.IsDBNull(9) ? "" : dr.GetString(9);                     unitario.idupline = dr.IsDBNull(10) ? 0 : dr.GetInt32(10);                     unitario.datanascimento = dr.IsDBNull(11) ? Convert.ToDateTime( "01/01/0001 00:00:00" ) : dr.GetDateTime(11);                     unitario.datainclusao = dr.IsDBNull(12) ? Convert.ToDateTime( "01/01/0001 00:00:00" ) : dr.GetDateTime(12);                     unitario.celular = dr.IsDBNull(13) ? "" : dr.GetString(13);                     unitario.telefonefixo = dr.IsDBNull(14) ? "" : dr.GetString(14);                     unitario.usuario = dr.IsDBNull(15) ? "" : dr.GetString(15);                     unitario.senha = dr.IsDBNull(16) ? "" : dr.GetString(16);                     unitario.idtipousuario = dr.IsDBNull(17) ? 0 : dr.GetInt32(17);                     unitario.idtipoadesao = dr.IsDBNull(18) ? 0 : dr.GetInt32(18);                          lista.Add(unitario);                     }             }             catch (Exception ex)             {                 string ERRO = ex.Message;                 return new List<Associados>();             }             finally             { conn.Close(); }                  return lista;         }              public Associados Get(int primary_key)         {             MySqlConnection conn = new MySqlConnection(connect);             System.Text.StringBuilder query = new System.Text.StringBuilder();             query.Append("select idassociados, cpf, nome, cep, endereco, numero, complemento, bairro, cidade, estado, idupline, datanascimento, datainclusao, celular, telefonefixo, usuario, senha, idtipousuario, idtipoadesao from associados where idassociados = @idassociados");                  MySqlCommand comm = new MySqlCommand(query.ToString(), conn);             comm.Parameters.Add("@idassociados", MySqlDbType.Int32);             comm.Parameters[0].Value = primary_key;             MySqlDataReader dr = null;             Associados lista = new Associados();             try             {                 conn.Open();                 dr = comm.ExecuteReader(CommandBehavior.CloseConnection);                      while (dr.Read())                     {                     Associados unitario = new Associados();                          unitario.idassociados = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);                     unitario.cpf = dr.IsDBNull(1) ? "" : dr.GetString(1);                     unitario.nome = dr.IsDBNull(2) ? "" : dr.GetString(2);                     unitario.cep = dr.IsDBNull(3) ? "" : dr.GetString(3);                     unitario.endereco = dr.IsDBNull(4) ? "" : dr.GetString(4);                     unitario.numero = dr.IsDBNull(5) ? "" : dr.GetString(5);                     unitario.complemento = dr.IsDBNull(6) ? "" : dr.GetString(6);                     unitario.bairro = dr.IsDBNull(7) ? "" : dr.GetString(7);                     unitario.cidade = dr.IsDBNull(8) ? "" : dr.GetString(8);                     unitario.estado = dr.IsDBNull(9) ? "" : dr.GetString(9);                     unitario.idupline = dr.IsDBNull(10) ? 0 : dr.GetInt32(10);                     unitario.datanascimento = dr.IsDBNull(11) ? Convert.ToDateTime( "01/01/0001 00:00:00" ) : dr.GetDateTime(11);                     unitario.datainclusao = dr.IsDBNull(12) ? Convert.ToDateTime( "01/01/0001 00:00:00" ) : dr.GetDateTime(12);                     unitario.celular = dr.IsDBNull(13) ? "" : dr.GetString(13);                     unitario.telefonefixo = dr.IsDBNull(14) ? "" : dr.GetString(14);                     unitario.usuario = dr.IsDBNull(15) ? "" : dr.GetString(15);                     unitario.senha = dr.IsDBNull(16) ? "" : dr.GetString(16);                     unitario.idtipousuario = dr.IsDBNull(17) ? 0 : dr.GetInt32(17);                     unitario.idtipoadesao = dr.IsDBNull(18) ? 0 : dr.GetInt32(18);                          lista = unitario;                     }             }             catch (Exception ex)             {                 string ERRO = ex.Message;                 return new Associados();             }             finally             { conn.Close(); }                  return lista;         }    public int Post(Associados associados)    {        MySqlConnection conn = new MySqlConnection(connect);        System.Text.StringBuilder query = new System.Text.StringBuilder();        query.Append("insert into associados (cpf, nome, cep, endereco, numero, complemento, bairro, cidade, estado, idupline, datanascimento, datainclusao, celular, telefonefixo, usuario, senha, idtipousuario, idtipoadesao) values (@cpf, @nome, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado, @idupline, @datanascimento, @datainclusao, @celular, @telefonefixo, @usuario, @senha, @idtipousuario, @idtipoadesao)");        MySqlCommand comm = new MySqlCommand(query.ToString(), conn);        comm.Parameters.Add("@cpf", MySqlDbType.VarChar );        comm.Parameters.Add("@nome", MySqlDbType.VarChar );        comm.Parameters.Add("@cep", MySqlDbType.VarChar );        comm.Parameters.Add("@endereco", MySqlDbType.VarChar );        comm.Parameters.Add("@numero", MySqlDbType.VarChar );        comm.Parameters.Add("@complemento", MySqlDbType.VarChar );        comm.Parameters.Add("@bairro", MySqlDbType.VarChar );        comm.Parameters.Add("@cidade", MySqlDbType.VarChar );        comm.Parameters.Add("@estado", MySqlDbType.VarChar );        comm.Parameters.Add("@idupline", MySqlDbType.Int32 );        comm.Parameters.Add("@datanascimento", MySqlDbType.DateTime );        comm.Parameters.Add("@datainclusao", MySqlDbType.DateTime );        comm.Parameters.Add("@celular", MySqlDbType.VarChar );        comm.Parameters.Add("@telefonefixo", MySqlDbType.VarChar );        comm.Parameters.Add("@usuario", MySqlDbType.VarChar );        comm.Parameters.Add("@senha", MySqlDbType.VarChar );        comm.Parameters.Add("@idtipousuario", MySqlDbType.Int32 );        comm.Parameters.Add("@idtipoadesao", MySqlDbType.Int32 );        comm.Parameters[0].Value = associados.cpf;        comm.Parameters[1].Value = associados.nome;        comm.Parameters[2].Value = associados.cep;        comm.Parameters[3].Value = associados.endereco;        comm.Parameters[4].Value = associados.numero;        comm.Parameters[5].Value = associados.complemento;        comm.Parameters[6].Value = associados.bairro;        comm.Parameters[7].Value = associados.cidade;        comm.Parameters[8].Value = associados.estado;        comm.Parameters[9].Value = associados.idupline;        comm.Parameters[10].Value = associados.datanascimento;        comm.Parameters[11].Value = associados.datainclusao;        comm.Parameters[12].Value = associados.celular;        comm.Parameters[13].Value = associados.telefonefixo;        comm.Parameters[14].Value = associados.usuario;        comm.Parameters[15].Value = associados.senha;        comm.Parameters[16].Value = associados.idtipousuario;        comm.Parameters[17].Value = associados.idtipoadesao;        Int32 id = 0;        try        {            conn.Open();            comm.ExecuteNonQuery();            query.Clear();            query.Append("Select @@Identity");            comm.CommandText = query.ToString();            var resultado = comm.ExecuteScalar();            id = Convert.ToInt32(resultado);        }        catch (Exception ex)        {            string ERRO = ex.Message;            return 0;        }        finally        { conn.Close(); }        return id;    }    public int Put(Associados associados)    {        MySqlConnection conn = new MySqlConnection(connect);        System.Text.StringBuilder query = new System.Text.StringBuilder();        query.Append("update associados set idassociados = @idassociados, cpf = @cpf, nome = @nome, cep = @cep, endereco = @endereco, numero = @numero, complemento = @complemento, bairro = @bairro, cidade = @cidade, estado = @estado, idupline = @idupline, datanascimento = @datanascimento, datainclusao = @datainclusao, celular = @celular, telefonefixo = @telefonefixo, usuario = @usuario, senha = @senha, idtipousuario = @idtipousuario, idtipoadesao = @idtipoadesao where idassociados = @idassociados");        MySqlCommand comm = new MySqlCommand(query.ToString(), conn);        comm.Parameters.Add("@idassociados", MySqlDbType.Int32 );        comm.Parameters.Add("@cpf", MySqlDbType.VarChar );        comm.Parameters.Add("@nome", MySqlDbType.VarChar );        comm.Parameters.Add("@cep", MySqlDbType.VarChar );        comm.Parameters.Add("@endereco", MySqlDbType.VarChar );        comm.Parameters.Add("@numero", MySqlDbType.VarChar );        comm.Parameters.Add("@complemento", MySqlDbType.VarChar );        comm.Parameters.Add("@bairro", MySqlDbType.VarChar );        comm.Parameters.Add("@cidade", MySqlDbType.VarChar );        comm.Parameters.Add("@estado", MySqlDbType.VarChar );        comm.Parameters.Add("@idupline", MySqlDbType.Int32 );        comm.Parameters.Add("@datanascimento", MySqlDbType.DateTime );        comm.Parameters.Add("@datainclusao", MySqlDbType.DateTime );        comm.Parameters.Add("@celular", MySqlDbType.VarChar );        comm.Parameters.Add("@telefonefixo", MySqlDbType.VarChar );        comm.Parameters.Add("@usuario", MySqlDbType.VarChar );        comm.Parameters.Add("@senha", MySqlDbType.VarChar );        comm.Parameters.Add("@idtipousuario", MySqlDbType.Int32 );        comm.Parameters.Add("@idtipoadesao", MySqlDbType.Int32 );        comm.Parameters[0].Value = associados.idassociados;        comm.Parameters[1].Value = associados.cpf;        comm.Parameters[2].Value = associados.nome;        comm.Parameters[3].Value = associados.cep;        comm.Parameters[4].Value = associados.endereco;        comm.Parameters[5].Value = associados.numero;        comm.Parameters[6].Value = associados.complemento;        comm.Parameters[7].Value = associados.bairro;        comm.Parameters[8].Value = associados.cidade;        comm.Parameters[9].Value = associados.estado;        comm.Parameters[10].Value = associados.idupline;        comm.Parameters[11].Value = associados.datanascimento;        comm.Parameters[12].Value = associados.datainclusao;        comm.Parameters[13].Value = associados.celular;        comm.Parameters[14].Value = associados.telefonefixo;        comm.Parameters[15].Value = associados.usuario;        comm.Parameters[16].Value = associados.senha;        comm.Parameters[17].Value = associados.idtipousuario;        comm.Parameters[18].Value = associados.idtipoadesao;        try        {            conn.Open();            return comm.ExecuteNonQuery();        }        catch (Exception ex)        {            string ERRO = ex.Message;            return 0;        }        finally        { conn.Close(); }    }    public int Delete(int idassociados)    {        MySqlConnection conn = new MySqlConnection(connect);        System.Text.StringBuilder query = new System.Text.StringBuilder();        query.Append("delete from associados where idassociados = @idassociados");        MySqlCommand comm = new MySqlCommand(query.ToString(), conn);        comm.Parameters.Add("@idassociados", MySqlDbType.Int32 );        comm.Parameters[0].Value = idassociados;        try        {            conn.Open();            return comm.ExecuteNonQuery();        }        catch (Exception ex)        {            string ERRO = ex.Message;            return 0;        }        finally        { conn.Close(); }    }   }}