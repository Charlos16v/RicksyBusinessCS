using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client.Payloads;

namespace RicksyBusinessCS.domain
{
    public class CrystalExpender : GuestDispatcher
    {
        private int stock = 0;
        private double itemCost = 0.0d;

        public CrystalExpender(int stock, double itemCost)
        {
            this.stock = stock;
            this.itemCost = itemCost;
        }

        public int getStock() => stock;

        public double getItemCost() => itemCost;

        public void dispatch(CreditCard card)
        {
            if ( this.stock > 0 && card.pay(itemCost) )
            {
                this.stock -= 1;
            }
        }

        public override string ToString()
        {
            return "Stock: " + getStock() + '\n' +
                   "ItemCost: " + getItemCost() + '\n';
        }
    }
}