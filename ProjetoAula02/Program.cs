using ProjetoAula02.Controllers;

namespace ProjetoAula02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nSISTEMA DE CONTROLE DE PRODUTOS:\n");

            Console.WriteLine("(1) CADASTRAR PRODUTO");
            Console.WriteLine("(2) ATUALIZAR PRODUTO");
            Console.WriteLine("(3) EXCLUIR PRODUTO");
            Console.WriteLine("(4) CONSULTAR PRODUTOS");

            Console.Write("\nINFORME A OPÇÃO DESEJADA: ");
            var opcao = int.Parse(Console.ReadLine());

            var productController = new ProductController();

            switch(opcao)
            {
                case 1: productController.AddProduct(); break;
                case 2: productController.UpdateProduct(); break;
                case 3: productController.DeleteProduct(); break;
                case 4: productController.ListProducts(); break;
                default:
                    Console.WriteLine("\nOPÇÃO INVALIDA.");
                    break;
            }

            Console.Write("\nDESEJA CONTINUAR? (S,N): ");
            var continuar = Console.ReadLine();

            if (continuar == "S" || continuar == "s")
            {
                Console.Clear(); //limpar a tela do prompt
                Main(args); //recursividade!
            }
            else
            {
                Console.WriteLine("\nFIM DO PROGRAMA.");
            }
        }

    }
}


