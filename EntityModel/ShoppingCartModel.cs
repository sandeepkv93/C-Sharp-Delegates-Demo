using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityModel
{
    public class ShoppingCartModel
    {
        public delegate void MentionSubTotal(decimal subTotal);
        public List<ProductModel> Items { get; set; } = new List<ProductModel>();

        public decimal GenerateTotal(MentionSubTotal mentionSubTotal,
                                    Func<List<ProductModel>, decimal, decimal> calculateDiscountedTotal,
                                    Action<string> tellUserWeAreDiscounting)
        {
            decimal subTotal = Items.Sum(x => x.Price);

            mentionSubTotal(subTotal);

            tellUserWeAreDiscounting("We are applying your discount");

            decimal total = calculateDiscountedTotal(Items, subTotal);
            return total;
        }
    }
}
