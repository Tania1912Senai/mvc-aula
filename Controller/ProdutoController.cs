using Produto_MVC.Model;

namespace Produto_MVC;

public class ProdutoController
{
    //instanciar objeto produto e produtoView
    Produto produto = new Produto();
    ProdutoView produtoView = new ProdutoView();

    public void ListarProdutos()
    {
        //Lista de Produtos chamada pela Model
        List<Produto> p = produto.Ler();

        //chamada do metodo de exibicao (view) recebendo como argumento a lista 
        produtoView.Listar(p);
    }

    //metodo controlador para acessar o cadastro de produto
    public void CadastrarProduto()
    {
        //chamada para a view que recebe cada objeto a ser inserido no csv
        Produto novoProduto = produtoView.Cadastrar();

        //chamada para a model inserir esse objeto no csv
        produto.Inserir(novoProduto);
    }
}

