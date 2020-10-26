using System;using System.Collections.Generic;using System.Data;using System.Linq;using System.Threading.Tasks;using drhipocratesCore.Model;
using drhipocratesCore.Config;using drhipocratesCore.Model;using MySql.Data;using MySql.Data.MySqlClient;namespace drhipocratesCore.Repository{
    public class ProdutosRepository
    {

        String connect = Connect.getConnect;


        public List<Produtos> List()
        {
            MySqlConnection conn = new MySqlConnection(connect);
            System.Text.StringBuilder query = new System.Text.StringBuilder();
            query.Append("select idprodutos, nome, descricao, ativo, categoria, idfabricante from produtos");

            MySqlCommand comm = new MySqlCommand(query.ToString(), conn);
            MySqlDataReader dr = null;
            List<Produtos> lista = new List<Produtos>();

            try
            {
                conn.Open();
                dr = comm.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    Produtos unitario = new Produtos();

                    unitario.idprodutos = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                    unitario.nome = dr.IsDBNull(1) ? "" : dr.GetString(1);
                    unitario.descricao = dr.IsDBNull(2) ? dr.GetString(2) : dr.GetString(2);
                    unitario.ativo = dr.IsDBNull(3) ? "" : dr.GetString(3);
                    unitario.categoria = dr.IsDBNull(4) ? "" : dr.GetString(4);
                    unitario.idfabricante = dr.IsDBNull(5) ? 0 : dr.GetInt32(5);

                    lista.Add(unitario);
                }
            }
            catch (Exception ex)
            {
                string ERRO = ex.Message;
                return new List<Produtos>();
            }
            finally
            { conn.Close(); }

            return lista;
        }


        public Produtos Get(int primary_key)
        {
            MySqlConnection conn = new MySqlConnection(connect);
            System.Text.StringBuilder query = new System.Text.StringBuilder();
            query.Append("select idprodutos, nome, descricao, ativo, categoria, idfabricante from produtos where idprodutos = @idprodutos");

            MySqlCommand comm = new MySqlCommand(query.ToString(), conn);

            comm.Parameters.Add("@idprodutos", MySqlDbType.Int32);

            comm.Parameters[0].Value = primary_key;
            MySqlDataReader dr = null;

            Produtos lista = new Produtos();

            try
            {
                conn.Open();
                dr = comm.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    Produtos unitario = new Produtos();

                    unitario.idprodutos = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                    unitario.nome = dr.IsDBNull(1) ? "" : dr.GetString(1);
                    unitario.descricao = dr.IsDBNull(2) ? dr.GetString(2) : dr.GetString(2);
                    unitario.ativo = dr.IsDBNull(3) ? "" : dr.GetString(3);
                    unitario.categoria = dr.IsDBNull(4) ? "" : dr.GetString(4);
                    unitario.idfabricante = dr.IsDBNull(5) ? 0 : dr.GetInt32(5);

                    lista = unitario;
                }
            }
            catch (Exception ex)
            {
                string ERRO = ex.Message;
                return new Produtos();
            }
            finally
            { conn.Close(); }

            return lista;
        }

        public int Post(Produtos produtos)
        {
            MySqlConnection conn = new MySqlConnection(connect);
            System.Text.StringBuilder query = new System.Text.StringBuilder();
            query.Append("insert into produtos (nome, descricao, ativo, categoria, idfabricante) values (@nome, @descricao, @ativo, @categoria, @idfabricante)");
            MySqlCommand comm = new MySqlCommand(query.ToString(), conn);

            comm.Parameters.Add("@nome", MySqlDbType.VarChar);
            comm.Parameters.Add("@descricao", MySqlDbType.VarChar);
            comm.Parameters.Add("@ativo", MySqlDbType.VarChar);
            comm.Parameters.Add("@categoria", MySqlDbType.VarChar);
            comm.Parameters.Add("@idfabricante", MySqlDbType.Int32);

            comm.Parameters[0].Value = produtos.nome;
            comm.Parameters[1].Value = produtos.descricao;
            comm.Parameters[2].Value = produtos.ativo;
            comm.Parameters[3].Value = produtos.categoria;
            comm.Parameters[4].Value = produtos.idfabricante;

            Int32 id = 0;

            try
            {
                conn.Open();

                comm.ExecuteNonQuery();
                query.Clear();
                query.Append("Select @@Identity");

                comm.CommandText = query.ToString();
                var resultado = comm.ExecuteScalar();

                id = Convert.ToInt32(resultado);


            }
            catch (Exception ex)
            {
                string ERRO = ex.Message;
                return 0;
            }
            finally
            { conn.Close(); }

            return id;

        }

        public int Put(Produtos produtos)
        {

            MySqlConnection conn = new MySqlConnection(connect);

            System.Text.StringBuilder query = new System.Text.StringBuilder();

            query.Append("update produtos set idprodutos = @idprodutos, nome = @nome, descricao = @descricao, ativo = @ativo, categoria = @categoria, idfabricante = @idfabricante where idprodutos = @idprodutos");

            MySqlCommand comm = new MySqlCommand(query.ToString(), conn);

            comm.Parameters.Add("@idprodutos", MySqlDbType.Int32);
            comm.Parameters.Add("@nome", MySqlDbType.VarChar);
            comm.Parameters.Add("@descricao", MySqlDbType.VarChar);
            comm.Parameters.Add("@ativo", MySqlDbType.VarChar);
            comm.Parameters.Add("@categoria", MySqlDbType.VarChar);
            comm.Parameters.Add("@idfabricante", MySqlDbType.Int32);

            comm.Parameters[0].Value = produtos.idprodutos;
            comm.Parameters[1].Value = produtos.nome;
            comm.Parameters[2].Value = produtos.descricao;
            comm.Parameters[3].Value = produtos.ativo;
            comm.Parameters[4].Value = produtos.categoria;
            comm.Parameters[5].Value = produtos.idfabricante;

            try
            {
                conn.Open();
                return comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string ERRO = ex.Message;
                return 0;
            }
            finally
            { conn.Close(); }

        }

        public int Delete(int idprodutos)
        {

            MySqlConnection conn = new MySqlConnection(connect);

            System.Text.StringBuilder query = new System.Text.StringBuilder();

            query.Append("delete from produtos where idprodutos = @idprodutos");

            MySqlCommand comm = new MySqlCommand(query.ToString(), conn);

            comm.Parameters.Add("@idprodutos", MySqlDbType.Int32);

            comm.Parameters[0].Value = idprodutos;

            try
            {
                conn.Open();
                return comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string ERRO = ex.Message;
                return 0;
            }
            finally
            { conn.Close(); }

        }
    }}