using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker.Classes
{
    public class Player
    {

        public int id;
        public int retired = 0;
        public bool retirable = true;
        string name;
        Mano handLevel;
        List<Card> cards;
        UiBundle bundle;
        bool reverse;
        bool active;
        Deck d;

        public string Name { get => name; set => name = value; }
        public Mano HandLevel { get => handLevel; set => handLevel = value; }
        public List<Card> Cards { get => cards; set => cards = value; }

        public Player(string name, Deck deck, UiBundle bundle, int id)
        {
            this.id = id;
            d = deck;
            cards = new List<Card>();
            this.Name = name;
            this.bundle = bundle;
            for(int i = 0; i < 5; i++)
            {
                cards.Add(deck.GetCard());
            }
            List<Card> k = new List<Card>(cards);
            
            HandLevel = Card.HandLevel(k);
            reverse = true;
            active = false;
            RefreshUI();
        }

        public void RefreshUI()
        {
            bundle.name.Text = Name;
            if(active)
            {
                try
                {
                    Card.UpdateImage(bundle.c1, cards.ElementAt(0));
                }
                catch
                {
                    Card.UpdateImage(bundle.c1, null);
                }
                try
                {
                    Card.UpdateImage(bundle.c2, cards.ElementAt(1));
                }
                catch
                {
                    Card.UpdateImage(bundle.c2, null);
                }
                try
                {
                    Card.UpdateImage(bundle.c3, cards.ElementAt(2));
                }
                catch
                {
                    Card.UpdateImage(bundle.c3, null);
                }
                try
                {
                    Card.UpdateImage(bundle.c4, cards.ElementAt(3));
                }
                catch
                {
                    Card.UpdateImage(bundle.c4, null);
                }
                try
                {
                    Card.UpdateImage(bundle.c5, cards.ElementAt(4));
                }
                catch
                {
                    Card.UpdateImage(bundle.c5, null);
                }
            } else
            {
                Card.UpdateImage(bundle.c1, null);
                Card.UpdateImage(bundle.c2, null);
                Card.UpdateImage(bundle.c3, null);
                Card.UpdateImage(bundle.c4, null);
                Card.UpdateImage(bundle.c5, null);
            }

        }


        public void ReverseCards()
        {

                Deactivate();
                RefreshUI();
            
        }

        public void Deactivate()
        {
            active = !active;
        }

        public void Refill()
        {
            for(int i = 0; i < 5; i++)
            {
                if(cards.ElementAt(i) == null)
                {
                    cards[i] = d.GetCard();
                }
            }
            List<Card> k = new List<Card>(cards);
            HandLevel = Card.HandLevel(k);
        }

        public void RetireCard(int i)
        {
            try
            {
                switch (i)
                {
                    case 1:
                        cards[0] = null;
                        break;
                    case 2:
                        cards[1] = null;
                        break;
                    case 3:
                        cards[2] = null;
                        break;
                    case 4:
                        cards[3] = null;
                        break;
                    case 5:
                        cards[4] = null;
                        break;
                }
                retired++;
            }
            catch (Exception) { }
        }

    }

    public struct UiBundle
    {
        public Label name, bet;
        public PictureBox c1, c2, c3, c4, c5;

    }
}
