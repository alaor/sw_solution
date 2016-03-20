using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projeto.Models
{
    public class ProdutoPedidoModel
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public String DescricaoPromocao { get; set; }
        public float ValorFinal { get; set; }

        public ProdutoPedidoModel adicionaPedido(ProdutoPedidoModel produtoPedidoModel, int promocao) 
        {
            switch (promocao)
            {
                case 1:
                    Console.WriteLine("Case 1");
                    produtoPedidoModel.DescricaoPromocao = "-";
                    produtoPedidoModel.ValorFinal = (produtoPedidoModel.Produto.Valor * produtoPedidoModel.Quantidade);
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    produtoPedidoModel.DescricaoPromocao = "Pague 1 Leve 2";
                    produtoPedidoModel.ValorFinal = produtoPedidoModel.Produto.Valor;
                    produtoPedidoModel.Quantidade = 2;
                    break;
                case 3:
                    Console.WriteLine("Case 3");
                    produtoPedidoModel.DescricaoPromocao = "3 por 10";
                    produtoPedidoModel.ValorFinal = 10;
                    produtoPedidoModel.Quantidade = 3;
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

            return produtoPedidoModel;
        }

        public ProdutoPedidoModel findByNomePromocao(String nome, String promocao, List<ProdutoPedidoModel> list)
        {
            ProdutoPedidoModel pedidoRemover = null;

            foreach (ProdutoPedidoModel p in list)
            {
                if(p.DescricaoPromocao.Equals(promocao) && p.Produto.Nome.Equals(nome))
                {
                    pedidoRemover = p;

                }
                
            }

            return pedidoRemover;
        }


    }



}