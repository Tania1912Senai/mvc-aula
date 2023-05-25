using Produto_MVC;
using Produto_MVC.Model;
internal class Program
{
    private static void Main(string[] args)
    {
        //instancia do objeto produto
        //o produto precisa conhecer a model e a view de produto
        Produto p = new Produto();

        // instancia do objeto produtoController
        ProdutoController controller = new ProdutoController();

        controller.CadastrarProduto();

        //chamada do metodo controlador
        controller.ListarProdutos();
    }
}