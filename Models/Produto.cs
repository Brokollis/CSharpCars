namespace Models
{
    public class Produto{
        public string Nome { get; set; }
        public float Preco { get; set; }

        public static List<Produto> produtos = new List<Produto>();

        public Produto(string nome, float preco){
            this.Nome = nome;
            this.Preco = preco;
        }

        public static void store(Produto produto) {
            produtos.Add(produto);
        }

        public static List<Produto> index(){
            return produtos;
        }

        public override String ToString(){
            return $"Nome: {this.Nome} - Preço: {this.Preco}";
        }
    }
}