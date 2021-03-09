namespace RicksyBusinessCS.domain
{
    public class CrystalExpender : GuestDispatcher
    {
        private readonly double itemCost;
        private int stock;

        public CrystalExpender(int stock, double itemCost)
        {
            this.stock = stock;
            this.itemCost = itemCost;
        }

        public void dispatch(CreditCard card)
        {
            if (stock > 0 && card.pay(itemCost)) stock -= 1;
        }

        public int getStock()
        {
            return stock;
        }

        public double getItemCost()
        {
            return itemCost;
        }

        public override string ToString()
        {
            return "Stock: " + getStock() + '\n' +
                   "ItemCost: " + getItemCost() + '\n';
        }
    }
}