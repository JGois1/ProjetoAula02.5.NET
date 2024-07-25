using Dapper;
using ProjetoAula02.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula02.Repositories
{
    /// <summary>
    /// Classe de repositório de banco de dados para produto.
    /// </summary>
    public class ProductRepository
    {
        //atributos
        private string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBAula02;Integrated Security=True;";

        /// <summary>
        /// Método para inserir um produto na tabela do banco de dados.
        /// </summary>
        /// <param name="product">Objeto contendo os dados do produto.</param>
        public void Create(Product product)
        {
            //abrindo conexão com o banco de dados
            var connection = new SqlConnection(_connectionString);

            //escrevendo o comando SQL
            var sql = @"
                INSERT INTO PRODUCT(ID, NAME, PRICE, QUANTITY)
                VALUES(@Id, @Name, @Price, @Quantity)
            ";

            //inserir um produto na tabela do banco de dados
            connection.Execute(sql, product);

            //fechando a conexão
            connection.Close();
        }

        /// <summary>
        /// Método para atualizar um produto na tabela do banco de dados
        /// </summary>
        /// <param name="product">Recebendo objeto contendo os dados do produto</param>
        public void Update(Product product)
        {
            //abrindo conexão com o banco de dados
            var connection = new SqlConnection(_connectionString);

            //escrevendo o comando SQL
            var sql = @"
                UPDATE PRODUCT
                SET
                    NAME = @Name,
                    PRICE = @Price,
                    QUANTITY = @Quantity
                WHERE 
                    ID = @Id
            ";
            //executando o comando SQL no banco de dados
            connection.Execute(sql, product);

            //fechando a conexão
            connection.Close();

        }
        /// <summary>
        /// Método para excluir um produto na tabela do banco de dados
        /// </summary>
        /// <param name="id">Chave primaria do produto</param>
        public void Delete(Guid id)
        {
            //abrindo conexão com o banco de dados
            var connection = new SqlConnection(_connectionString);

            //escrevendo o comando SQL
            var sql = @"
                DELETE FROM PRODUCT
                WHERE ID = @Id
            ";

            //executando o comando SQL
            connection.Execute(sql, new { id });

            //fechando a conexão 
            connection.Close();
        }
        /// <summary>
        /// Método para consultar todos os produtos do banco de dados
        /// </summary>
        /// <returns>Lista de Produtos</returns>
        public List<Product> ReadAll()
        {
            //abrindo conexão com o banco de dados
            var connection = new SqlConnection(_connectionString);

            //escrevendo o comando SQL
            var sql = @"
                SELECT
                    ID, NAME, PRICE, QUANTITY
                FROM
                    PRODUCT
                ORDER BY
                    NAME
            ";

            //executando uma instrução SQL para consultar produtos no banco de dados
            var result = connection.Query<Product>(sql);

            //fechar a conexão
            connection.Close();

            //retornando a lista de produtos obtida
            return result.ToList();
        }
        /// <summary>
        /// Método para consultar 1 produto através do ID
        /// </summary>
        /// <param name="id">Chave primaría do produto</param>
        /// <returns>Objeto de produto ou vazio</returns>
        public Product? FindById(Guid id)
        {
            //abrindo a conexão com o banco de dados
            var connection = new SqlConnection(_connectionString);

            //escrevendo o comando sql
            var sql = @"
                SELECT
                    ID, NAME, PRICE, QUANTITY
                FROM
                    PRODUCT
                WHERE
                    ID = @Id
            ";

            //executando o comando SQL e capturando o retorno 
            var result = connection.Query<Product>(sql, new { id });

            //fechando conexao
            connection.Close();

            //retornando o conteudo da consulta
            return result.FirstOrDefault();
        }
    }
}
