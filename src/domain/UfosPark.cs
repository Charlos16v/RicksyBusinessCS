using System;
using System.Collections.Generic;

namespace RicksyBusinessCS.domain
{
    public class UfosPark : GuestDispatcher
    {
        private readonly double fee = 500.0;
        private readonly Dictionary<string, string> fleet = new();

        public void dispatch(CreditCard creditCard)
        {
            if (!fleet.ContainsValue(creditCard.getNumber()))
                foreach (var item in fleet)
                    if (item.Value == null && creditCard.pay(fee))
                    {
                        fleet[item.Key] = creditCard.getNumber();
                        break;
                    }
        }

        public void add(string ufo)
        {
            if (!fleet.ContainsKey(ufo))
                fleet.Add(ufo, null);
            else
                Console.WriteLine("The ufo exists in the fleet.");
        }

        // Tests
        public List<string> getUfos()
        {
            List<string> ufos = new(fleet.Keys);
            return ufos;
        }

        public void printUfos()
        {
            foreach (var ufo in fleet.Keys) Console.WriteLine(ufo);
        }

        public string getUfoOf(string cardNumber)
        {
            string ufo = null;

            if (fleet.ContainsValue(cardNumber))
                foreach (var item in fleet)
                    if (item.Value == cardNumber)
                    {
                        ufo = item.Key;
                        break;
                    }

            if (ufo == null) return "null";
            return ufo;
        }

        private bool containsCard(string cardNumber)
        {
            return fleet.ContainsValue(cardNumber);
        }
    }
}