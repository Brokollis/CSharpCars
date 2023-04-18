using Models;

namespace Controllers
{
    public class Produto{
    
        public static void store(Models.Produto produto) {
            Models.Produto.store(produto);
        }

        public static List<Models.Produto> index(){
            return Models.Produto.index();
        }
    }
}