namespace RicksyBusinessCS.domain
{
    public class CreditCard
    {
        private readonly string owner;
        private readonly string number;
        private double credit = 3000.0;
        private readonly string SYMBOL = "EZI";

        public CreditCard(string owner, string number)
        {
            this.owner = owner;
            this.number = number;
        }

        public string getOwner()
        {
            return this.owner;
        }

        public string getNumber()
        {
            return this.number;
        }
        
        public double getCredit()
        {
            return this.credit;
        }

        public string getSymbol()
        {
            return this.SYMBOL;
        }

        public bool pay(double credit)
        {
            if (credit > this.credit)
            {
                return false;
            }
            else
            {
                this.credit -= credit;
                return true;
            }
            
        }
        public override string ToString()
        {
            return "Owner: " + getOwner() + '\n' +
                   "Number: " + getNumber() + '\n' + 
                   "Credit: " + getCredit() + ' ' +getSymbol();
        }
    }
}