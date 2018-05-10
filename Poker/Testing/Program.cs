using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deck d = new Deck();
            //Console.ReadKey();
            List<Card> kards = new List<Card>();
            int i = 0;
            while (true)
            {
                if (i == 5)
                {
                    Mano m = Card.HandLevel(kards);
                    switch (m)
                    {
                        case Mano.CartaAlta:
                            Console.WriteLine("Carta Alta");
                            break;
                        case Mano.Color:
                            Console.WriteLine("Color");
                            break;
                        case Mano.DoblePareja:
                            Console.WriteLine("Doble Pareja");
                            break;
                        case Mano.Escalera:
                            Console.WriteLine("Escalera");
                            break;
                        case Mano.EscaleraColor:
                            Console.WriteLine("Escalera de Color");
                            break;
                        case Mano.FlorImperial:
                            Console.WriteLine("Flor Imperial");
                            break;
                        case Mano.Full:
                            Console.WriteLine("Full");
                            break;
                        case Mano.Pareja:
                            Console.WriteLine("Pareja");
                            break;
                        case Mano.Poker:
                            Console.WriteLine("Poker");
                            break;
                        case Mano.Trio:
                            Console.WriteLine("Trio");
                            break;
                    }
                    i++;
                }
                else if (i == 6)
                {
                    Console.ReadKey();
                    Console.Clear();
                    i = 0;
                    kards.Clear();
                }
                else
                {

                    string x = Console.ReadLine();
                    if (x == "exit")
                    {
                        return;
                    }
                    else
                    {
                        try
                        {
                            string[] strs = x.Split(',');
                            kards.Add(new Card(byte.Parse(strs[0]), (Palo)int.Parse(strs[1])));
                            i++;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Te peleaste con la Yessica Eequivocada");
                        }
                    }
                }
            }
        }
    }
}
