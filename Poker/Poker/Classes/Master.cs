using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Classes
{
    class Master
    {

        Deck deck;
        Queue<Player> player;
        List<Player> p;
        Player current;
        int step;
        public Players pla;

        public Player Current { get => current; set => current = value; }
        public List<Player> P { get => p; set => p = value; }

        public Master(GameForm gameForm, List<string> players)
        {
            player = new Queue<Player>();
            P = new List<Player>();
            pla = new Players();
            deck = new Deck();
            try
            {
                UiBundle u = new UiBundle();
                u.name = gameForm.p3n;
                u.c1 = gameForm.p3c1;
                u.c2 = gameForm.p3c2;
                u.c3 = gameForm.p3c3;
                u.c4 = gameForm.p3c4;
                u.c5 = gameForm.p3c5;
                player.Enqueue(new Player(players.ElementAt(0), deck, u, 1));
                pla.p1 = true;
            }
            catch { pla.p1 = false; }

            try
            {
                UiBundle u2 = new UiBundle();
                u2.name = gameForm.p4n;
                u2.c1 = gameForm.p4c1;
                u2.c2 = gameForm.p4c2;
                u2.c3 = gameForm.p4c3;
                u2.c4 = gameForm.p4c4;
                u2.c5 = gameForm.p4c5;
                player.Enqueue(new Player(players.ElementAt(1), deck, u2, 2));
                pla.p2 = true;
            }
            catch { pla.p2 = false; }

            try
            {
                UiBundle u3 = new UiBundle();
                u3.name = gameForm.p1n;
                u3.c1 = gameForm.p1c1;
                u3.c2 = gameForm.p1c2;
                u3.c3 = gameForm.p1c3;
                u3.c4 = gameForm.p1c4;
                u3.c5 = gameForm.p1c5;
                player.Enqueue(new Player(players.ElementAt(2), deck, u3, 3));
                pla.p3 = true;
            }
            catch { pla.p3 = false; }

            try
            {
                UiBundle u4 = new UiBundle();
                u4.name = gameForm.p2n;
                u4.c1 = gameForm.p2c1;
                u4.c2 = gameForm.p2c2;
                u4.c3 = gameForm.p2c3;
                u4.c4 = gameForm.p2c4;
                u4.c5 = gameForm.p2c5;
                player.Enqueue(new Player(players.ElementAt(3), deck, u4, 4));
                pla.p4 = true;
            }
            catch { pla.p4 = false; }

        }

        public bool Next()
        {
            if(step == 0)
            {
                if(current != null)
                {
                    current.Deactivate();
                    current.RefreshUI();
                } 
               
                
                current = player.Dequeue();
                current.Deactivate();
                current.RefreshUI();

                step++;
            }
            else if(step == 1)
            {
                current.retirable = false;
                current.Refill();
                current.RefreshUI();
                P.Add(current);
                if (player.Count == 0 && step == 1)
                {
                    current.Deactivate();
                    return true;
                }
                
                step = 0;
            }
            return false;
            

        }

        public Player Winner()
        {
            List<Player> i = new List<Player>();
            i = P.OrderByDescending(o => int.Parse(((int)(o.HandLevel)).ToString())).ToList();
            List<Player> e = i.FindAll(x => x.HandLevel == i.ElementAt(0).HandLevel);
            if (e.Count > 1)
            {
                if(e.ElementAt(0).HandLevel == Mano.Pareja || e.ElementAt(0).HandLevel == Mano.DoblePareja || e.ElementAt(0).HandLevel == Mano.Poker)
                {
                    Dictionary<Player, int> ps = new Dictionary<Player, int>();
                    List<int> nums = new List<int>();
                    foreach (Player o in e)
                    {
                        List<Card> repetidas = o.Cards.GroupBy(x => x.Valor).Where(x => x.Count() != 1).SelectMany(G => G).ToList();
                        
                            ps.Add(o, repetidas.ElementAt(0).Valor);
                            nums.Add(repetidas.ElementAt(0).Valor);
                        
                    }
                    if (nums.Count == nums.Distinct().Count())
                    {
                        if (nums.Contains(1))
                        {
                            ps = ps.OrderBy(x => x.Value).ToDictionary(t => t.Key, t => t.Value);
                            return ps.ElementAt(0).Key;
                        }
                        else
                        {
                            ps = ps.OrderByDescending(x => x.Value).ToDictionary(t=>t.Key, t=>t.Value);
                            return ps.ElementAt(0).Key;
                        }
                    }
                }
                else if(e.ElementAt(0).HandLevel == Mano.Trio)
                {
                    Dictionary<Player, int> ps = new Dictionary<Player, int>();
                    List<int> nums = new List<int>();
                    foreach (Player o in e)
                    {
                        List<Card> repetidas = o.Cards.GroupBy(x => x.Valor).Where(x => x.Count() != 1).SelectMany(G => G).ToList();
                        ps.Add(o, repetidas.ElementAt(0).Valor);
                        nums.Add(repetidas.ElementAt(0).Valor);
                    }
                    if(nums.Count == nums.Distinct().Count())
                    {
                        if(nums.Contains(1))
                        {
                            ps = ps.OrderBy(x => x.Value).ToDictionary(t => t.Key, t => t.Value);
                            return ps.ElementAt(0).Key;
                        }
                        else
                        {
                            ps = ps.OrderByDescending(x => x.Value).ToDictionary(t => t.Key, t => t.Value);
                            return ps.ElementAt(0).Key;
                        }
                    }
                }
                else if(e.ElementAt(0).HandLevel == Mano.Full)
                {
                    Dictionary<Player, int> trios = new Dictionary<Player, int>();
                    List<int> tr = new List<int>();
                    List<int> dos = new List<int>();
                    Dictionary<Player, int> dobles = new Dictionary<Player, int>();
                    foreach (Player o in e)
                    {
                        List<Card> repetidas = o.Cards.GroupBy(x => x.Valor).Where(x => x.Count() != 1).SelectMany(G => G).ToList();
                        trios.Add(o, repetidas.ElementAt(0).Valor);
                        tr.Add(repetidas.ElementAt(0).Valor);

                        List<Card> repetidas2 = o.Cards.GroupBy(x => x.Valor).Where(x => x.Count() != 1).SelectMany(G => G).ToList();
                        dobles.Add(o, repetidas2.ElementAt(0).Valor);
                        dos.Add(repetidas2.ElementAt(0).Valor);
                    }
                    if (tr.Count == tr.Distinct().Count())
                    {
                        if (tr.Contains(1))
                        {
                            trios = trios.OrderBy(x => x.Value).ToDictionary(t => t.Key, t => t.Value);
                            return trios.ElementAt(0).Key;
                        }
                        else
                        {
                            trios = trios.OrderByDescending(x => x.Value).ToDictionary(t => t.Key, t => t.Value);
                            return trios.ElementAt(0).Key;
                        }
                    }
                    else if (dos.Count == dos.Distinct().Count())
                    {
                        if (dos.Contains(1))
                        {
                            dobles = dobles.OrderBy(x => x.Value).ToDictionary(t => t.Key, t => t.Value);
                            return dobles.ElementAt(0).Key;
                        }
                        else
                        {
                            dobles = dobles.OrderByDescending(x => x.Value).ToDictionary(t => t.Key, t => t.Value);
                            return dobles.ElementAt(0).Key;
                        }
                    }

                } else if (e.ElementAt(0).HandLevel == Mano.FlorImperial)
                {
                    while(true)
                    {
                        Dictionary<Player, int> ps = new Dictionary<Player, int>();
                        List<int> nums = new List<int>();
                        foreach(Player o in e)
                        {
                            Card c = deck.GetCard();
                            nums.Add(c.Valor);
                            ps.Add(o, c.Valor);
                        }
                        if (nums.Count == nums.Distinct().Count())
                        {
                            if (nums.Contains(1))
                            {
                                ps = ps.OrderBy(x => x.Value).ToDictionary(t => t.Key, t => t.Value);
                                return ps.ElementAt(0).Key;
                            }
                            else
                            {
                                ps = ps.OrderByDescending(x => x.Value).ToDictionary(t => t.Key, t => t.Value);
                                return ps.ElementAt(0).Key;
                            }
                        }
                    }
                }

                List<int> a = new List<int>();
                foreach(Player o in e)
                {
                    a.Add(Card.MaxCardDes(o.Cards).Valor);
                }
                if (a.Contains(1))
                {
                    a = a.OrderBy(x => x).ToList();
                }
                else
                {
                    a = a.OrderByDescending(x => x).ToList();
                }
                if(a.FindAll(x => x == a.ElementAt(0)).Count > 1)
                {
                    while (true)
                    {
                        Dictionary<Player, int> ps = new Dictionary<Player, int>();
                        List<int> nums = new List<int>();
                        foreach (Player o in e)
                        {
                            Card c = deck.GetCard();
                            nums.Add(c.Valor);
                            ps.Add(o, c.Valor);
                        }
                        if (nums.Count == nums.Distinct().Count())
                        {
                            if (nums.Contains(1))
                            {
                                ps = ps.OrderBy(x => x.Value).ToDictionary(t=>t.Key, t=>t.Value);
                                return ps.ElementAt(0).Key;
                            }
                            else
                            {
                                ps = ps.OrderByDescending(x => x.Value).ToDictionary(t => t.Key, t => t.Value);
                                return ps.ElementAt(0).Key;
                            }
                        }
                    }
                }
                else
                {
                    return P.Find(x => Card.MaxCardDes(x.Cards).Valor == a.ElementAt(0));
                }
            }
            else
            {
                return e.ElementAt(0);
            }
        }

    }

    public struct Players
    {
        public bool p1, p2, p3, p4;
    }
}
