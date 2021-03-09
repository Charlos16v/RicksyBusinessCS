using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RicksyBusinessCS.domain
{
    public class RickMenu : GuestDispatcher
    {
        private int stock = 0;
        private double itemCost = 0.0d;
        private LinkedList<string> orders = new LinkedList<string>();

        public RickMenu(int stock, double itemCost)
        {
            this.stock = stock;
            this.itemCost = itemCost;
        }
        
        public int getStock() => stock;

        public double getItemCost() => itemCost;

        public LinkedList<string> getClients()
        {
            return orders;
        }

        public void addClient(string client)
        {
            this.orders.AddLast(client);
        }
        
        public void printClients()
        {
            foreach (var client in orders)
            {
                Console.Write(client);
            }
        }
        
        public void dispatch(CreditCard card)
        {
            if (this.stock > 0 && card.pay(itemCost))
            {
                this.stock -= 1;
                addClient(card.getOwner());
            }
        }
        
        public override string ToString()
        {
            return "Stock: " + getStock() + '\n' +
                   "MenuCost: " + getItemCost() + '\n' +
                   "Orders: " + getClients() + '\n' +
                   "OrdersQuantity: " + getClients().Count;
        }
    }
}