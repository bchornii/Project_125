using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_LinqToSql
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TsqlFundamDataContext())
            {
                context.Log = Console.Out;
                context.DeferredLoadingEnabled = false;

                Order order = context.Orders.Where(o => o.orderid == 10248).FirstOrDefault();

                List<OrderDetail> odetails = context.OrderDetails.Where(od => od.orderid == (order != null ? order.orderid : -1))
                                                                 .ToList();

                foreach (var o in odetails)
                {
                    var product = context.Products.Where(p => p.productid == o.productid).FirstOrDefault();
                    Console.WriteLine(o.orderid + " : " + o.productid + " : " + o.discount +
                                                    " : " + (product != null ? product.productname : "none"));
                    //Console.WriteLine(o.orderid + " : " + o.productid + " : " + o.discount + o.Product.productname);
                }
            }

            Console.ReadLine();
        }
    }
}
