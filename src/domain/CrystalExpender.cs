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

        public void dispatch(CreditCard card)
        {
            
        }
    }
}