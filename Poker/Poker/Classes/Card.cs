using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker.Classes
{
    public class Card
    {

        byte valor;
        Palo palo;

        public byte Valor { get => valor; set => valor = value; }
        public Palo Palo { get => palo; set => palo = value; }

        public Card(byte valor, Palo palo)
        {
            if (valor < 1 || valor > 14)
            {
                throw new Exception("Value not valid");
            }
            this.valor = valor;
            this.palo = palo;
        }

        public static Mano HandLevel(List<Card> cards)
        {
            List<int> a = new List<int>();
            foreach (Card c in cards) { a.Add(c.Valor); }
            if (a.Distinct().Count() == 2)
            {
                List<Card> repetidas = cards.GroupBy(x => x.Valor).Where(x => x.Count() == 4).SelectMany(G => G).ToList();

                if (repetidas.Count() == 4)
                {
                    return Mano.Poker;
                }
                else
                {
                    return Mano.Full;
                }

            }
            else if (a.Distinct().Count() == 3)
            {

                List<Card> repetidas = cards.GroupBy(x => x.Valor).Where(x => x.Count() == 3).SelectMany(G => G).ToList();

                if (repetidas.Count() == 3)
                {
                    return Mano.Trio;
                }
                else
                {
                    return Mano.DoblePareja;
                }

            }
            else if (a.Distinct().Count() == 4)
            {

                return Mano.Pareja;

            }
            else if (cards.FindAll(x => x.palo == cards.ElementAt(0).palo).Count == 5)
            {
                if (MaxCard(cards).valor == 1 && MinCard(cards).valor == 10)
                {
                    return Mano.FlorImperial;
                }
                else if ((AbsoluteMaxCard(cards).valor - AbsoluteMinCard(cards).valor) == 4
                    || (MaxCard(cards).Valor == 1) && (AbsoluteMaxCard(cards).valor - AbsoluteMinCard(cards).valor) == 3)
                {
                    return Mano.EscaleraColor;
                }
                else
                {
                    return Mano.Color;
                }
            }
            else if ((AbsoluteMaxCard(cards).valor - AbsoluteMinCard(cards).valor) == 4
                || (MaxCard(cards).Valor == 1) && (AbsoluteMaxCard(cards).valor - MinCard(cards).valor) == 3)
            {
                return Mano.Escalera;
            }
            else
            {
                return Mano.CartaAlta;
            }
        }

        public static Card MaxCard(List<Card> cards)
        {
            List<int> values = new List<int>();
            foreach (Card card in cards)
            {
                values.Add(card.valor);
            }
            if (values.Min() == 1)
            {
                Palo palo = cards.Find(x => x.valor == 1).palo;
                return new Card(1, palo);
            }
            else
            {
                int max = values.Max();
                Palo palo = cards.Find(x => x.valor == max).palo;
                return new Card((byte)max, palo);
            }

        }

        public static Card MaxCardDes(List<Card> cards)
        {
            List<int> values = new List<int>();
            foreach (Card card in cards)
            {
                values.Add(card.valor);
            }
            if (values.Min() == 1)
            {
                Palo palo = cards.Find(x => x.valor == 1).palo;
                return new Card(14, palo);
            }
            else
            {
                int max = values.Max();
                Palo palo = cards.Find(x => x.valor == max).palo;
                return new Card((byte)max, palo);
            }

        }

        public static Card MinCard(List<Card> cards)
        {
            List<int> values = new List<int>();
            foreach (Card card in cards)
            {
                values.Add(card.valor);
            }
            if (values.Min() == 1 && values.Count != 1)
            {
                values.RemoveAll(x => x == 1);
            }
            int min = values.Min();
            return new Card((byte)min, cards.Find(x => x.valor == min).palo);


        }

        public static Card AbsoluteMaxCard(List<Card> cards)
        {
            List<int> values = new List<int>();
            foreach (Card card in cards)
            {
                values.Add(card.valor);
            }

            int max = values.Max();
            Palo palo = cards.Find(x => x.valor == max).palo;
            return new Card((byte)max, palo);

        }

        public static Card AbsoluteMinCard(List<Card> cards)
        {
            List<int> values = new List<int>();
            foreach (Card card in cards)
            {
                values.Add(card.valor);
            }
            int min = values.Min();
            return new Card((byte)min, cards.Find(x => x.valor == min).palo);


        }

        public static void UpdateImage(PictureBox pb, Card c)
        {
            if(c == null)
            {
                pb.BackgroundImage = Properties.Resources.espalda;
            }
            else if (c.palo == Palo.Corazones)
            {
                switch(c.Valor)
                {
                    case 1:
                        pb.BackgroundImage = Properties.Resources.cac;
                        break;
                    case 2:
                        pb.BackgroundImage = Properties.Resources.c2;
                        break;
                    case 3:
                        pb.BackgroundImage = Properties.Resources.c3c;
                        break;
                    case 4:
                        pb.BackgroundImage = Properties.Resources.c4c;
                        break;
                    case 5:
                        pb.BackgroundImage = Properties.Resources.c5c;
                        break;
                    case 6:
                        pb.BackgroundImage = Properties.Resources.c6c;
                        break;
                    case 7:
                        pb.BackgroundImage = Properties.Resources.c7c;
                        break;
                    case 8:
                        pb.BackgroundImage = Properties.Resources.c8c;
                        break;
                    case 9:
                        pb.BackgroundImage = Properties.Resources.c9c;
                        break;
                    case 10:
                        pb.BackgroundImage = Properties.Resources.c10c;
                        break;
                    case 11:
                        pb.BackgroundImage = Properties.Resources.c11c;
                        break;
                    case 12:
                        pb.BackgroundImage = Properties.Resources.c12c;
                        break;
                    case 13:
                        pb.BackgroundImage = Properties.Resources.c13c;
                        break;
                }
            }
            else if (c.palo == Palo.Diamantes)
            {
                switch (c.Valor)
                {
                    case 1:
                        pb.BackgroundImage = Properties.Resources.cad;
                        break;
                    case 2:
                        pb.BackgroundImage = Properties.Resources.C2d;
                        break;
                    case 3:
                        pb.BackgroundImage = Properties.Resources.c3d;
                        break;
                    case 4:
                        pb.BackgroundImage = Properties.Resources.c4d;
                        break;
                    case 5:
                        pb.BackgroundImage = Properties.Resources.c5d;
                        break;
                    case 6:
                        pb.BackgroundImage = Properties.Resources.c6d;
                        break;
                    case 7:
                        pb.BackgroundImage = Properties.Resources.c7d;
                        break;
                    case 8:
                        pb.BackgroundImage = Properties.Resources.c8d;
                        break;
                    case 9:
                        pb.BackgroundImage = Properties.Resources.c9d;
                        break;
                    case 10:
                        pb.BackgroundImage = Properties.Resources.c10d;
                        break;
                    case 11:
                        pb.BackgroundImage = Properties.Resources.c11d;
                        break;
                    case 12:
                        pb.BackgroundImage = Properties.Resources.c12d;
                        break;
                    case 13:
                        pb.BackgroundImage = Properties.Resources.c13d;
                        break;
                }
            }
            else if (c.palo == Palo.Treboles)
            {
                switch (c.Valor)
                {
                    case 1:
                        pb.BackgroundImage = Properties.Resources.cat;
                        break;
                    case 2:
                        pb.BackgroundImage = Properties.Resources.c2t;
                        break;
                    case 3:
                        pb.BackgroundImage = Properties.Resources.c3t;
                        break;
                    case 4:
                        pb.BackgroundImage = Properties.Resources.c4t;
                        break;
                    case 5:
                        pb.BackgroundImage = Properties.Resources.c5t;
                        break;
                    case 6:
                        pb.BackgroundImage = Properties.Resources.c6t;
                        break;
                    case 7:
                        pb.BackgroundImage = Properties.Resources.c7t;
                        break;
                    case 8:
                        pb.BackgroundImage = Properties.Resources.c8t;
                        break;
                    case 9:
                        pb.BackgroundImage = Properties.Resources.c9t;
                        break;
                    case 10:
                        pb.BackgroundImage = Properties.Resources.c10t;
                        break;
                    case 11:
                        pb.BackgroundImage = Properties.Resources.c11t;
                        break;
                    case 12:
                        pb.BackgroundImage = Properties.Resources.c12t;
                        break;
                    case 13:
                        pb.BackgroundImage = Properties.Resources.c13t;
                        break;
                }
            }
            else if (c.palo == Palo.Espadas)
            {
                switch (c.Valor)
                {
                    case 1:
                        pb.BackgroundImage = Properties.Resources.cae;
                        break;
                    case 2:
                        pb.BackgroundImage = Properties.Resources.c2e;
                        break;
                    case 3:
                        pb.BackgroundImage = Properties.Resources.c3e;
                        break;
                    case 4:
                        pb.BackgroundImage = Properties.Resources.c4e;
                        break;
                    case 5:
                        pb.BackgroundImage = Properties.Resources.c5e;
                        break;
                    case 6:
                        pb.BackgroundImage = Properties.Resources.c6e;
                        break;
                    case 7:
                        pb.BackgroundImage = Properties.Resources.c7e;
                        break;
                    case 8:
                        pb.BackgroundImage = Properties.Resources.c8e;
                        break;
                    case 9:
                        pb.BackgroundImage = Properties.Resources.c9e;
                        break;
                    case 10:
                        pb.BackgroundImage = Properties.Resources.c10e;
                        break;
                    case 11:
                        pb.BackgroundImage = Properties.Resources.c11e;
                        break;
                    case 12:
                        pb.BackgroundImage = Properties.Resources.c12e;
                        break;
                    case 13:
                        pb.BackgroundImage = Properties.Resources.c13e;
                        break;
                }
            }
        }

    }

    public enum Palo
    {
        Espadas, Corazones, Diamantes, Treboles
    }

    public enum Mano
    {
        CartaAlta, Pareja, DoblePareja, Trio, Escalera, Color, Full, Poker, EscaleraColor, FlorImperial
    }
}
