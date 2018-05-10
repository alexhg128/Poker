using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Classes
{
    public class Deck
    {

        List<Card> cards;
        Stack<Card> kards;

        public Deck()
        {
            cards = new List<Card>();
            kards = new Stack<Card>();
            Random random = new Random();
            bool flag = true;

            while(flag)
            {
                byte valor = (byte) random.Next(1, 14);
                Palo palo = (Palo)random.Next(0, 4);
                Card card = new Card(valor, palo);
                if(cards.Find(x => (x.Valor == valor) && (x.Palo == palo)) == null)
                {
                    cards.Add(card);
                }
                if(cards.Count == 52)
                {
                    flag = false;
                }
            }

            foreach(Card c in cards)
            {
                kards.Push(c);
            }
            
        }

        public Card GetCard()
        {
            return kards.Pop();
        }

    }
}
