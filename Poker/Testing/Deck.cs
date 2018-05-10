using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class Deck
    {

        List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();
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
                    foreach (Card c in cards)
                    {
                        valor = c.Valor;
                        palo = c.Palo;
                        if(c.Palo == Palo.Corazones)
                        {
                            switch (valor)
                            {
                                case 1:
                                    Console.Write("As - ");
                                    break;
                                case 11:
                                    Console.Write("Joto - ");
                                    break;
                                case 12:
                                    Console.Write("Reina - ");
                                    break;
                                case 13:
                                    Console.Write("Rey - ");
                                    break;
                                default:
                                    Console.Write(valor.ToString() + " - ");
                                    break;
                            }
                            switch (palo)
                            {
                                case Palo.Corazones:
                                    Console.Write("Corazones\n");
                                    break;
                                case Palo.Diamantes:
                                    Console.Write("Diamantes\n");
                                    break;
                                case Palo.Espadas:
                                    Console.Write("Espadas\n");
                                    break;
                                case Palo.Treboles:
                                    Console.Write("Treboles\n");
                                    break;
                            }
   
                        }

                    }

                    foreach (Card c in cards)
                    {
                        valor = c.Valor;
                        palo = c.Palo;
                        if (c.Palo == Palo.Diamantes)
                        {
                            switch (valor)
                            {
                                case 1:
                                    Console.Write("As - ");
                                    break;
                                case 11:
                                    Console.Write("Joto - ");
                                    break;
                                case 12:
                                    Console.Write("Reina - ");
                                    break;
                                case 13:
                                    Console.Write("Rey - ");
                                    break;
                                default:
                                    Console.Write(valor.ToString() + " - ");
                                    break;
                            }
                            switch (palo)
                            {
                                case Palo.Corazones:
                                    Console.Write("Corazones\n");
                                    break;
                                case Palo.Diamantes:
                                    Console.Write("Diamantes\n");
                                    break;
                                case Palo.Espadas:
                                    Console.Write("Espadas\n");
                                    break;
                                case Palo.Treboles:
                                    Console.Write("Treboles\n");
                                    break;
                            }

                        }

                    }

                    foreach (Card c in cards)
                    {
                        valor = c.Valor;
                        palo = c.Palo;
                        if (c.Palo == Palo.Espadas)
                        {
                            switch (valor)
                            {
                                case 1:
                                    Console.Write("As - ");
                                    break;
                                case 11:
                                    Console.Write("Joto - ");
                                    break;
                                case 12:
                                    Console.Write("Reina - ");
                                    break;
                                case 13:
                                    Console.Write("Rey - ");
                                    break;
                                default:
                                    Console.Write(valor.ToString() + " - ");
                                    break;
                            }
                            switch (palo)
                            {
                                case Palo.Corazones:
                                    Console.Write("Corazones\n");
                                    break;
                                case Palo.Diamantes:
                                    Console.Write("Diamantes\n");
                                    break;
                                case Palo.Espadas:
                                    Console.Write("Espadas\n");
                                    break;
                                case Palo.Treboles:
                                    Console.Write("Treboles\n");
                                    break;
                            }

                        }

                    }

                    foreach (Card c in cards)
                    {
                        valor = c.Valor;
                        palo = c.Palo;
                        if (c.Palo == Palo.Treboles)
                        {
                            switch (valor)
                            {
                                case 1:
                                    Console.Write("As - ");
                                    break;
                                case 11:
                                    Console.Write("Joto - ");
                                    break;
                                case 12:
                                    Console.Write("Reina - ");
                                    break;
                                case 13:
                                    Console.Write("Rey - ");
                                    break;
                                default:
                                    Console.Write(valor.ToString() + " - ");
                                    break;
                            }
                            switch (palo)
                            {
                                case Palo.Corazones:
                                    Console.Write("Corazones\n");
                                    break;
                                case Palo.Diamantes:
                                    Console.Write("Diamantes\n");
                                    break;
                                case Palo.Espadas:
                                    Console.Write("Espadas\n");
                                    break;
                                case Palo.Treboles:
                                    Console.Write("Treboles\n");
                                    break;
                            }

                        }

                    }
                }
            }
            
        }


    }
}
