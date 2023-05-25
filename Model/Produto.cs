namespace Produto_MVC.Model
{
    public class Produto
    {
        //propriedades     
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        //caminho da pasta e do arquivo definido
        private const string PATH = "Database/Produto.csv";

        //criar um constutor
        public Produto()
        {
            //obter o caminho da pasta
            string pasta = PATH.Split("/")[0];

            // Pasta chamada"Database"
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            //se nao existir um arquivo csv no caminho, entao cria-se um
            if (!File.Exists(PATH))
            {
                File.Create(PATH);
            }
        }

        public List<Produto> Ler()
        {
            //instanciar uma lista de produto
            List<Produto> produtos = new List<Produto>();
            string[] Linhas = File.ReadAllLines(PATH);
            //array de string que recebe cada linha do csv
            foreach (var item in Linhas)
            //001;Refrigerante;6,50
            {
                string[] atributos = item.Split(";");
                //atributo[0] = "001"
                //atributo[1] = "Refrigerante"
                //atributo[2] = "6,50

                Produto p = new Produto();
                
                p.Codigo = int.Parse(atributos[0]); //001
                p.Nome = atributos[1];//Refrigerante"
                p.Preco = float.Parse(atributos[2]); // 6,50f
                                                     //adiciona os objetos dentro da lista
                produtos.Add(p);
            }
            //retorna a lista de produtos
            return produtos;
        }

         //metodo para preparar a linha do csv
        public string PrepararLinhasCSV(Produto p)
        {
            return $"{p.Codigo};{p.Nome};{p.Preco}";
            //metodo para inserir um produto no arquivo csv
        }

       
        public void Inserir(Produto p)
        {
            //array que vai armazenar as linhas (cada "objeto)
            string[] linhas = { PrepararLinhasCSV(p) };
            File.AppendAllLines(PATH, linhas);
        }
    }
}