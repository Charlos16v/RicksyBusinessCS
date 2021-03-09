namespace RicksyBusinessCS.domain
{
    public class CreditCard
    {
        private readonly string number;
        private readonly string owner;
        private readonly string SYMBOL = "EZI";
        private double credit = 3000.0;

        public CreditCard(string owner, string number)
        {
            this.owner = owner;
            this.number = number;
        }

        public string getOwner()
        {
            return owner;
        }

        public string getNumber()
        {
            return number;
        }

        public double getCredit()
        {
            return credit;
        }

        public string getSymbol()
        {
            return SYMBOL;
        }

        public bool pay(double credit)
        {
            if (credit > this.credit)
            {
                return false;
            }

            this.credit -= credit;
            return true;
        }

        public override string ToString()
        {
            return "Owner: " + getOwner() + '\n' +
                   "Number: " + getNumber() + '\n' +
                   "Credit: " + getCredit() + ' ' + getSymbol();
        }
    }
}