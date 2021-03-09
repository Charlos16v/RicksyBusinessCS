using System.Collections.Generic;

namespace RicksyBusinessCS.domain
{
    public class Receptivo
    {
        private readonly LinkedList<GuestDispatcher> observers = new();

        public void registra(GuestDispatcher observer)
        {
            if (!observers.Contains(observer)) observers.AddLast(observer);
        }

        public void dispatch(CreditCard card)
        {
            foreach (var observer in observers) observer.dispatch(card);
        }

        public LinkedList<GuestDispatcher> getObservers()
        {
            return observers;
        }
    }
}