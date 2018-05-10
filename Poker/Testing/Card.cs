using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class Card
    {

        byte valor;
        Palo palo;

        public byte Valor { get => valor; set => valor = value; }
        public Palo Palo { get => palo; set => palo = value; }

        public Card(byte valor, Palo palo)
        {
            if (valor < 1 || valor > 13)
            {
                throw new Exception("Value not valid");
            }
            this.valor = valor;
            this.palo = palo;
        }

        public static Mano HandLevel(List<Card> cards)
        {
            if (cards.FindAll(x => x.palo == cards.ElementAt(0).palo).Count == 5)
            {
                if (MaxCard(cards).valor == 1 && MinCard(cards).valor == 10)
                {
                    return Mano.FlorImperial;
                }
                else if ((AbsoluteMaxCard(cards).valor - AbsoluteMinCard(cards).valor) == 4)
                {
                    return Mano.EscaleraColor;
                }
                else
                {
                    return Mano.Color;
                }
            }
            else if ((cards.FindAll(x => x.valor == cards.ElementAt(0).valor).Count == 4) ||
                (cards.FindAll(x => x.valor == cards.ElementAt(1).valor).Count == 4))
            {
                return Mano.Poker;
            }
            else if ((cards.FindAll(x => x.valor == cards.ElementAt(0).valor).Count == 3) ||
                (cards.FindAll(x => x.valor == cards.ElementAt(1).valor).Count == 3) ||
                (cards.FindAll(x => x.valor == cards.ElementAt(2).valor).Count == 3))
            {
                List<Card> kards = cards;
                Card kard = kards.ElementAt(0);
                kards.RemoveAll(x => x.valor == kard.valor);
                if (kards.Count == 3)
                {
                    return Mano.Full;
                }
                else if (kards.Count == 2)
                {
                    if (kards[0].valor == kards[1].valor)
                    {
                        return Mano.Full;
                    }
                    else
                    {
                        return Mano.Trio;
                    }
                }
                else
                {
                    return Mano.Trio;
                }
            }
            else if ((cards.FindAll(x => x.valor == cards.ElementAt(0).valor).Count == 2) ||
                (cards.FindAll(x => x.valor == cards.ElementAt(1).valor).Count == 2) ||
                (cards.FindAll(x => x.valor == cards.ElementAt(2).valor).Count == 2) ||
                (cards.FindAll(x => x.valor == cards.ElementAt(3).valor).Count == 2))
            {
                List<Card> kards = cards;
                Card kard = kards.ElementAt(0);
                kards.RemoveAll(x => x.valor == kard.valor);
                if (kards.Count == 4)
                {
                    kard = kards.ElementAt(0);
                    kards.RemoveAll(x => x.valor == kard.valor);
                    if (kards.Count == 3)
                    {
                        return Mano.Pareja;
                    }
                    else
                    {
                        if (kards.ElementAt(0).valor == kards.ElementAt(1).valor)
                        {
                            return Mano.DoblePareja;
                        }
                        else
                        {
                            return Mano.Pareja;
                        }
                    }
                }
                else
                {
                    kard = kards.ElementAt(0);
                    kards.RemoveAll(x => x.valor == kard.valor);
                    if (kards.Count == 1)
                    {
                        return Mano.DoblePareja;
                    }
                    else
                    {
                        if (kards.ElementAt(0).valor == kards.ElementAt(1).valor)
                        {
                            return Mano.DoblePareja;
                        }
                        else
                        {
                            return Mano.Pareja;
                        }
                    }
                }
            }
            else if ((AbsoluteMaxCard(cards).valor - AbsoluteMinCard(cards).valor) == 4)
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

    }

    public enum Palo
    {
        Espadas, Corazones, Diamantes, Treboles
    }

    public enum Mano
    {
        FlorImperial, EscaleraColor, Poker, Full, Color, Escalera, Trio, DoblePareja, Pareja, CartaAlta
    }
}
