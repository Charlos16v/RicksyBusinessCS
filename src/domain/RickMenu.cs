using System;
using System.Collections.Generic;

namespace RicksyBusinessCS.domain
{
    public class RickMenu : GuestDispatcher
    {
        private readonly double itemCost;
        private readonly LinkedList<string> orders = new();
        private int stock;

        public RickMenu(int stock, double itemCost)
        {
            this.stock = stock;
            this.itemCost = itemCost;
        }

        public void dispatch(CreditCard card)
        {
            if (stock > 0 && card.pay(itemCost))
            {
                stock -= 1;
                addClient(card.getOwner());
            }
        }

        public int getStock()
        {
            return stock;
        }

        public double getItemCost()
        {
            return itemCost;
        }

        public LinkedList<string> getClients()
        {
            return orders;
        }

        public void addClient(string client)
        {
            orders.AddLast(client);
        }

        public void printClients()
        {
            foreach (var client in orders) Console.Write(client);
        }

        public override string ToString()
        {
            return "Stock: " + getStock() + '\n' +
                   "MenuCost: " + getItemCost() + '\n' +
                   "Orders: " + string.Join(", ", getClients()) + '\n' +
                   "OrdersQuantity: " + getClients().Count;
        }
    }
}