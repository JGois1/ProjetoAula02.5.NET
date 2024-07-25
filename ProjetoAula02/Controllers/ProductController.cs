using ProjetoAula02.Entities;
using ProjetoAula02.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula02.Controllers
{
    /// <summary>
    /// Controlador para realizar os fluxos de entrada de dados de produtos.
    /// </summary>
    public class ProductController
    {
        /// <summary>
        /// Método para realizar o cadastro de um produto.
        /// </summary>
        public void AddProduct()
        {
            Console.WriteLine("\nCADASTRO DE PRODUTO:\n");

            var product = new Product();
            product.Id = Guid.NewGuid();

            Console.Write("NOME DO PRODUTO....: ");
            product.Name = Console.ReadLine();

            Console.Write("PREÇO..............: ");
            product.Price = decimal.Parse(Console.ReadLine());

            Console.Write("QUANTIDADE.........: ");
            product.Quantity = int.Parse(Console.ReadLine());

            //Gravar os dados do produto em banco de dados
            var productRepository = new ProductRepository();
            productRepository.Create(product);

            Console.WriteLine("\nPRODUTO CADASTRADO COM SUCESSO!");
        }

        /// <summary>
        /// Método realizar a atualização dos dados do produto.
        /// </summary>
        public void UpdateProduct()
        {
            Console.WriteLine("\nEDIÇÃO DE PRODUTO:\n");

            //solicitando que o usuário informe o id do produto
            Console.Write("INFORME O ID DO PRODUTO..: ");
            var id = Guid.Parse(Console.ReadLine());

            //consultando o produto no banco de dados através do id
            var productRepository = new ProductRepository();
            var product = productRepository.FindById(id);

            //verificando se o produto foi encontrado
            if (product != null)
            {
                Console.Write("ALTERE O NOME............: ");
                product.Name = Console.ReadLine();

                Console.Write("ALTERE O PREÇO...........: ");
                product.Price = decimal.Parse(Console.ReadLine());

                Console.Write("ALTERE A QUANTIDADE......: ");
                product.Quantity = int.Parse(Console.ReadLine());

                //atualizando os dados do produto no banco de dados
                productRepository.Update(product);

                Console.WriteLine("\nPRODUTO ATUALIZADO COM SUCESSO!");
            }
            else
            {
                Console.WriteLine("\nPRODUTO NÃO ENCONTRADO!");
            }
        }

        /// <summary>
        /// Método para realizar a exclusão de um produto.
        /// </summary>
        public void DeleteProduct()
        {
            Console.WriteLine("\nEXCLUSÃO DE PRODUTO:\n");

            //solicitando que o usuário informe o id do produto
            Console.Write("INFORME O ID DO PRODUTO..: ");
            var id = Guid.Parse(Console.ReadLine());

            //consultando o produto no banco de dados através do id
            var productRepository = new ProductRepository();
            var product = productRepository.FindById(id);

            //verificando se o produto foi encontrado
            if (product != null)
            {
                //excluindo o produto no banco de dados
                productRepository.Delete(id);

                Console.WriteLine("\nPRODUTO EXCLUÍDO COM SUCESSO!");
            }
            else
            {
                Console.WriteLine("\nPRODUTO NÃO ENCONTRADO!");
            }
        }

        /// <summary>
        /// Método para exibir todos os produtos contidos no banco de dados
        /// </summary>
        public void ListProducts()
        {
            Console.WriteLine("\nCONSULTA DE PRODUTOS:\n");

            //realizando a consulta de produtos no banco de dados
            var productRepository = new ProductRepository();
            var products = productRepository.ReadAll();

            //foreach -> percorrer todos os itens da lista
            foreach (var product in products)
            {
                Console.WriteLine("ID.......: " + product.Id);
                Console.WriteLine("NAME.....: " + product.Name);
                Console.WriteLine("PRICE....: " + product.Price);
                Console.WriteLine("QUANTITY.: " + product.Quantity);
                Console.WriteLine("...");
            }
        }
    }
}



