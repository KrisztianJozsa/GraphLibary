/*
 * Az algoritmus implementaciokat tartalmazo osztaly. Az osztaly az algoritmusok kulonbozo formait tartalmazza, más-más parameter listaval. Ez tobbek kozott szukseges a
 * peldaprogramokhoz illetve elosegiti a csomag szelesebb koru felhasznalhatosagat. A visszateresi tipus az osszes algoritmus eseteben List<Node>, ezzel torekedve a 
 * minel egysegesebb kodra,de az algoritmusok ebbol a szempontbol konnyen modosithatoak ha az szukseges.
 */

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace GraphLibary
{
    public class Algorithms
    {   
              
        /* Melysegi kereses: Egy olyan grafkereso algoritmus aminek alapelve, hogy eloszor probalja a gyokertol tavolabb eso, azaz "melyebb" csucsokat megvizsgalni 
         * és csak azután lep vissza a szomszedos illetve korábbi csucsokhoz.
         */



        /* Melysegi kereses-1
         * Hasznalatahoz megvalositandoak:
         *   A Node interfacebol:
         *                       -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
         *                        
         * Az algoritmus ezen verzioja egy melysegi bejarast valosit meg a (parameterkent kapott) gyokerbol kiindulva.
         */

        public static List<Node> depthFirstSearch(Node beginNode)
        {

            Stack<Node> stack = new Stack<Node>();
            List<Node> visited = new List<Node>();

            stack.Push(beginNode);
            
            while (stack.Count != 0)
            {

                Node n = stack.Pop();

            
                if (!visited.Contains(n))
                {
                    visited.Add(n);


                    for (int i = 0; i < n.getNeighBours().Count(); i++)
                    {
                        if (!visited.Contains(n.getNeighBours()[i]))
                        {
                            stack.Push(n.getNeighBours()[i]);
                        }
                    }
                }
            }
            
            return visited;
        }



        /* Melysegi kereses-2
         * 
         * Hasznalatahoz megvalositandoak:
         *   A Node interfacebol:
         *                       -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
         *                        
         *  Az algoritmus ezen verzioja parameterkent kap a gyoker mellett egy vegpontot is ami az algoritmus megallasi feltetele.
         */
        public static List<Node> depthFirstSearch(Node beginNode ,Node endNode)
         {

             Stack<Node> stack=new Stack<Node>();
             List<Node> visited = new List<Node>();
             stack.Push(beginNode);


             while (stack.Count != 0)
             {
             
                 Node n = stack.Pop();

                 if (n == endNode)
                 {
                     
                     visited.Add(n);
                     return visited;
                 }

                 if (!visited.Contains(n))
                 {
                    
                     visited.Add(n);

                     foreach (Node node in n.getNeighBours().Reverse<Node>())
                     {
                         if (!visited.Contains(node))
                         {   
                             stack.Push(node);
                             
                         }
                     }
                 }
             }

             return visited;
         }



        /* Melysegi kereses-3
         * Hasznalatahoz megvalositandoak:
         *   A Node interfacebol:
         *                       -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
         * 
         * Melysegi kereses ezen verzioja parameterkent egy List<Node> tipusban kapja a grafot  es az elso elemtol indulva az utolsoig meg.
         * 
         */

        public static List<Node> depthFirstSearch(List<Node> graph,Node goal)
        {
            Node beginNode = graph.First();
            Node endNode = goal;

            Stack<Node> stack = new Stack<Node>();
            List<Node> visited = new List<Node>();
            stack.Push(beginNode);


            while (stack.Count != 0)
            {

                Node n = stack.Pop();

                if (n == endNode)
                {

                    visited.Add(n);
                    return visited;
                }

                if (!visited.Contains(n))
                {

                    visited.Add(n);

                    foreach (Node node in n.getNeighBours().Reverse<Node>())
                    {
                        if (!visited.Contains(node))
                        {
                            stack.Push(node);
                        }
                    }
                }
            }

            return visited;
        }


        /* Melysegi kereses-4
        * Hasznalatahoz megvalositandoak:
        *   A Node interfacebol:
        *                       -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
        *   A Graph interfacebol:
        *                       -getNodes() (a Graph csucsait adja vissza)
        * 
        * Melysegi kereses ezen verzioja parameterkent egy Graphot kap es azon hajtja vegre a melysegi keresest.
        * 
        */

        public static List<Node> depthFirstSearch(Graph graph)
        {

            Node beginNode = graph.getNodes().First();

            Stack<Node> stack = new Stack<Node>();
            List<Node> visited = new List<Node>();

            stack.Push(beginNode);

            while (stack.Count != 0)
            {

                Node n = stack.Pop();


                if (!visited.Contains(n))
                {
                    visited.Add(n);


                    for (int i = 0; i < n.getNeighBours().Count(); i++)
                    {
                        if (!visited.Contains(n.getNeighBours()[i]))
                        {
                            stack.Push(n.getNeighBours()[i]);
                        }
                    }
                }
            }

            return visited;
        }


        public static List<Node> depthFirstSearch(Graph graph, Node goal)
        {
            Node beginNode = graph.getNodes().First();
            Node endNode = goal;

            Stack<Node> stack = new Stack<Node>();
            List<Node> visited = new List<Node>();
            stack.Push(beginNode);


            while (stack.Count != 0)
            {

                Node n = stack.Pop();

                if (n == endNode)
                {

                    visited.Add(n);
                    return visited;
                }

                if (!visited.Contains(n))
                {

                    visited.Add(n);

                    foreach (Node node in n.getNeighBours().Reverse<Node>())
                    {
                        if (!visited.Contains(node))
                        {
                            stack.Push(node);
                        }
                    }
                }
            }

            return visited;
        }


        /* Melysegi kereses-6
        * Hasznalatahoz megvalositandoak:
        *   A Node interfacebol:
        *                       -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
        * 
        * A formshoz keszult verzio
        * 
        */

        public static List<Node> depthFirstSearchD(Node beginNode)
        {

            Stack<Node> stack = new Stack<Node>();
            List<Node> visited = new List<Node>();

            stack.Push(beginNode);

            while (stack.Count != 0)
            {

                Node n = stack.Pop();


                if (!visited.Contains(n))
                {
                    visited.Add(n);


                    for (int i = 0; i < n.getNeighBours().Count(); i++)
                    {
                        if (!visited.Contains(n.getNeighBours()[i]))
                        {
                            stack.Push(n.getNeighBours()[i]);
                            n.getNeighBours()[i].setParent(n);
                        }
                    }
                }
            }

            return visited;
        }



      


        
    
        /* Szelessegi kereses: Egy olyan grafkereso algoritmus aminek alapelve pont ellentetes a melysegi algoritmuseval, eloszor probalja a gyokerhez kozelebb 
         * eso elemeket megvizsgalni majd ha ezekkel vegzett, csak akkor halad tovabb a tavolabbiak fele.
         */


        /* Szelessegi kereses-1
         * Hasznalatahoz megvalositandoak:
         *   A Node interfacebol:
         *                       -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
         *                        
         * Az algoritmus ezen verzioja egy melysegi bejarast valosit meg a (parameterkent kapott) gyokerbol kiindulva.
         */
        public static List<Node> breadthFirstSearch(Node beginNode)
        {

            Queue<Node> queue = new Queue<Node>();
            List<Node> visited = new List<Node>();

            queue.Enqueue(beginNode);

            while (queue.Count() != 0)
            {

                Node n = queue.Dequeue();

                if (!visited.Contains(n))
                {
                    visited.Add(n);

                    foreach (Node node in n.getNeighBours())
                    {
                        if (!visited.Contains(node))
                        {
                            queue.Enqueue(node);
                        }
                    }
                }
            }
           
            return visited;
        }


        /* Szelessegi kereses-2
         * 
         * Hasznalatahoz megvalositandoak:
         *   A Node interfacebol:
         *                       -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
         *                        
         *Az algoritmus ezen verzioja parameterkent kap a gyoker mellett egy vegpontot is ami az algoritmus megallasi feltetele.
         */

        public static List<Node> breadthFirstSearch(Node beginNode, Node endNode)
        {

            Queue<Node> queue = new Queue<Node>();
            List<Node> visited = new List<Node>();

            queue.Enqueue(beginNode);

            while (queue.Count() != 0)
            {

                Node n = queue.Dequeue();

                if (n == endNode)
                {
                    visited.Add(n);
                    return visited;
                }

                if (!visited.Contains(n))
                {
                    visited.Add(n);

                    foreach (Node node in n.getNeighBours())
                    {
                        if (!visited.Contains(node))
                        {
                            queue.Enqueue(node);
                        }
                    }
                }
            }

            return visited;
 
        }

        /* Szelessegi kereses-3
        * 
        * Hasznalatahoz megvalositandoak:
        *   A Node interfacebol:
        *                       -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
         *                       
        *   Az algoritmus ezen verzioja egy melysegi bejarast valosit meg a (parameterkent kapott) gyokerbol kiindulva.                    
        */


        public static List<Node> breadthFirstSearch(List<Node> graph)
        {

            Node beginNode=graph.First();
            Node endNode = graph.Last();

            Queue<Node> queue = new Queue<Node>();
            List<Node> visited = new List<Node>();

            queue.Enqueue(beginNode);

            while (queue.Count() != 0)
            {

                Node n = queue.Dequeue();

                if (n == endNode)
                {
                    visited.Add(n); 
                    return visited;
                }

                if (!visited.Contains(n))
                {
                    visited.Add(n);

                    foreach (Node node in n.getNeighBours())
                    {
                        if (!visited.Contains(node))
                        {
                            queue.Enqueue(node);
                        }
                    }
                }
            }

            return visited;

        }


        /* Szelessegi kereses-4
        * Hasznalatahoz megvalositandoak:
        *   A Node interfacebol:
        *                       -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
        *                        
        * Az algoritmus ezen verzioja egy grafot kap parameternek amelyen vegrehajtja a szellessegi keresest.
        */
        public static List<Node> breadthFirstSearch(Graph Graph)
        {

            Node beginNode = Graph.getNodes().First();

            Queue<Node> queue = new Queue<Node>();
            List<Node> visited = new List<Node>();

            queue.Enqueue(beginNode);

            while (queue.Count() != 0)
            {

                Node n = queue.Dequeue();

                if (!visited.Contains(n))
                {
                    visited.Add(n);

                    foreach (Node node in n.getNeighBours())
                    {
                        if (!visited.Contains(node))
                        {
                            queue.Enqueue(node);
                        }
                    }
                }
            }

            return visited;
        }



        /* Szelessegi kereses-4
        * Hasznalatahoz megvalositandoak:
        *   A Node interfacebol:
        *                       -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
        *                        
        * A szemlelteto formhoz keszult verzio.
        */

        public static List<Node> breadthFirstSearchD(Node beginNode)
        {
           
            Queue<Node> queue = new Queue<Node>();
            List<Node> visited = new List<Node>();

            queue.Enqueue(beginNode);

            while (queue.Count() != 0)
            {

                Node n = queue.Dequeue();

                if (!visited.Contains(n))
                {
                    foreach (Node node in visited.Reverse<Node>())
                    {
                        if(n.getNeighBours().Contains(node))
                        {
                            n.setParent(node);
                        }
                    }

                    visited.Add(n);

                  
                    foreach (Node node in n.getNeighBours())
                    {
                        if (!visited.Contains(node))
                        {
                            queue.Enqueue(node);
                        }
                    }
                }
            }

            return visited;
        }



        /*Nyalab kereses: Egy populacio alapu lokalis kereses amely egyszerre K kulonbozo (aktualis) allapotot hasznal. Lokalis keres reven remekul alkalmazhato
         * grafokkal abrazolhato optimalizalasi problemak megoldasara.
         */

       /* Nyalab kereses-1
        * 
        * Hasznalatahoz megvalositandoak:
        *   A Node interfacebol:
        *                       -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
        *                       -getGoodNess() (a csucs josagat adja vissza amit egy integer ertek, egybe eshet a csucs ertekevel)
        *                        
        * Az algoritmus ebben a formaban egy List<Node> tipusu listat kap parameterul ami tartalmazza az elso K allapotot ahonnan az algoritmus indul. Illetve a
        * megallasi feltetel itt az iteraciok szama, ami szinten parameterkent adhato meg integer-kent.
        */
    
        public static List<Node> beamSearch(List<Node> firstK,int i)
        {   
            List<Node> actual = new List<Node>();
            
            actual = firstK;
            int K = firstK.Count;
            int j=i,k;
            
            while (j > 0)
            {   List<Node> neighBours =new List<Node>();
                foreach (Node n in actual)
                {
                    neighBours.AddRange(n.getNeighBours());
                }
                actual.Clear();
                k = 0;
                foreach (Node n in neighBours)
                {                   
                    if (k < K)
                    {
                        actual.Add(n);
                        k++;
                    }
                    else
                    {
                        for(int o=0;o<actual.Count;o++)
                        {
                            for (int p = 0; p < neighBours.Count; p++)
                            {
                                if (actual[o].getGoodNess() < neighBours[p].getGoodNess()  // átírni , hogy az eddig állapotok ne kerülhessenek újra vissza--->> ne ragadjon be csak az iteráció letelt
                                    && !actual.Contains(neighBours[p]))
                                {
                                    actual[o] = neighBours[p];
                                }
                            }                                                      
                        }
    
                    }
                }
                neighBours.Clear();
                j--;
            }
            
            return actual;

        }


        /*Nyalab kereses: Egy populacio alapu lokalis kereses amely egyszerre K kulonbozo (aktualis) allapotot hasznal. Lokalis keres reven remekul alkalmazhato
     * grafokkal abrazolhato optimalizalasi problemak megoldasara.
     */

        /* Nyalab kereses-2
         * 
         * Hasznalatahoz megvalositandoak:
         *   A Node interfacebol:
         *                       -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
         *                       -getGoodNess() (a csucs josagat adja vissza amit egy integer ertek, egybe eshet a csucs ertekevel)
         *                        
         *  A pszeudo kódnak megfelelő alak.
         */
        public static List<Node> beamSearch(List<Node> firstK, List<Node> goals)
        {
            List<Node> actual = new List<Node>();

            actual = firstK;
            int K = firstK.Count,k;
            
            Boolean j = false;


            while (!j)
            {
                List<Node> neighBours = new List<Node>();
                foreach (Node n in actual)
                {
                    neighBours.AddRange(n.getNeighBours());
                }
                actual.Clear();
                k = 0;
                foreach (Node n in neighBours)
                {
                    if (k < K)
                    {
                        actual.Add(n);
                        k++;
                    }
                    else
                    {
                        for (int o = 0; o < actual.Count; o++)
                        {
                            for (int p = 0; p < neighBours.Count; p++)
                            {
                                if (actual[o].getGoodNess() < neighBours[p].getGoodNess()  // átírni , hogy az eddig állapotok ne kerülhessenek újra vissza--->> ne ragadjon be csak az iteráció letelt
                                    && !actual.Contains(neighBours[p]))
                                {
                                    actual[o] = neighBours[p];
                                }
                            }
                        }

                    }
                    for (int i = 0; i < actual.Count; i++)
                    {
                        for (int l = 0; l < goals.Count; i++)
                        {
                            if (actual[i] == goals[l])
                            {
                                Node  node =actual[i];
                                actual.Clear();
                                actual.Add(node);
                                j = true;
                            }
                        }
                    }

                }
                neighBours.Clear();
              
            }

            return actual;

        }


        /*Nyalab kereses: Egy populacio alapu lokalis kereses amely egyszerre K kulonbozo (aktualis) allapotot hasznal. Lokalis keres reven remekul alkalmazhato
         * grafokkal abrazolhato optimalizalasi problemak megoldasara.
         */

        /* Nyalab kereses-3
         * 
         * Hasznalatahoz megvalositandoak:
         *   A Node interfacebol:
         *                       -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
         *                       -getGoodNess() (a csucs josagat adja vissza amit egy integer ertek, egybe eshet a csucs ertekevel)
         *                        
         * A pszeudo kódnak megfelelő alak + iterációs feltétel.
         */

        public static List<Node> beamSearch(List<Node> firstK,List<Node> goals, int iteration)
        {
            List<Node> actual = new List<Node>();

            actual = firstK;
            int K = firstK.Count;
            int j = iteration, k;

            while (j > 0)
            {
                List<Node> neighBours = new List<Node>();
                foreach (Node n in actual)
                {
                    neighBours.AddRange(n.getNeighBours());
                }
                actual.Clear();
                k = 0;
                foreach (Node n in neighBours)
                {
                    if (k < K)
                    {
                        actual.Add(n);
                        k++;
                    }
                    else
                    {
                        for (int o = 0; o < actual.Count; o++)
                        {
                            for (int p = 0; p < neighBours.Count; p++)
                            {
                                if (actual[o].getGoodNess() < neighBours[p].getGoodNess()  // átírni , hogy az eddig állapotok ne kerülhessenek újra vissza--->> ne ragadjon be csak az iteráció letelt
                                    && !actual.Contains(neighBours[p]))
                                {
                                    actual[o] = neighBours[p];
                                }
                            }
                        }

                    }
                    for (int i = 0; i < actual.Count; i++)
                    {
                        for (int l = 0; l < goals.Count; i++)
                        {
                            if (actual[i] == goals[l])
                            {
                                Node node = actual[i];
                                actual.Clear();
                                actual.Add(node);
                                j = 0;
                            }
                        }
                    }
                }
                neighBours.Clear();
                j--;
            }

            return actual;

        }

        /*Nyalab kereses-4 --A szemlelteteshez*/

        public static List<Node> beamSearchD(List<Node> firstK,int i)
        {
            List<Node> actual = new List<Node>();
            List<Node> result = new List<Node>();

            actual = firstK;
            int K = firstK.Count;
            int j = i ;

            while (j > 0)
            {
                List<Node> neighBours = new List<Node>();
                foreach (Node n in actual)
                {
                    neighBours.AddRange(n.getNeighBours());
                }
                result.AddRange(actual);
              

                for (int l = 0; l <  neighBours.Count- 1; l++)
                {
                    for (int m = l + 1; m < neighBours.Count; m++)
                    {
                        if (neighBours[l].getGoodNess() > neighBours[m].getGoodNess())
                        {
                            Node a = neighBours[l];
                            neighBours[l] = neighBours[m];
                            neighBours[m] = a;
                        }
                    }
                }

                for (int k = 0; k < K; k++)
                {
                    for (int k2 = 0; k2 < K; k2++)
                    {
                        if (neighBours[k].getNeighBours().Contains(actual[k2]))
                        {
                            neighBours[k].setParent(actual[k2]);
                        }
                    }
                }

                actual.Clear();

                foreach(Node n in neighBours)
                {
                    if (!actual.Contains(n) && actual.Count<K)
                    {
                        actual.Add(n);
                    }
                }


                j--;
            }
           
            return result; 

        }



        /*Dijkstra algoritmus: Az egy kezdopontbol kiindulo legrovidebb utak problemajat oldja meg az osszes tobbi csucsra,ha a grafban nincsenek negativ elsulyok.*/


        /*Dijkstra algoritmus-1
         *Hasznalatahoz megvalositandoak:
         *  A Node Interfacebol:
         *                      -setNodeValue(o) (a csucs erteket allitja, object-et var, integer-rel megvalositando)
         *                      
         *                      -getNodeValue()  (a csucs erteket adja vissza,a metodus object-tel ter vissza, integer-rel megvalositando)
         *                      
         *                      -setParent(n)    (a csucs szulojenek megadasa, n megvalositja a Node interface-t)
         *                      
         *                      -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
         *                                        
         *                      -getEdge(n)      (a csucs amire meghivjuk es a parameterkent megadott csucs kozotti elt adja vissza)
         *                      
         *  Az Edge interfacbeol:
         *                      -getWeight()     (az el elsulyat adja vissza,integerrel ter vissza)
         *                      
         *     
         * Az algoritmus ezen valtozata parameterkent a grafot varja generikus lista formajaban illetve egy egesz szamot (integer-t) ami megadja,
         * hogy a lista hanyadik eleme legyen a kezdo allapot.
         */
        public static List<Node> dijkstra(List<Node> graph , int i)
        {
        
            foreach (Node n in graph)
            {
                n.setNodeValue(int.MaxValue);
                n.setParent(null);
            }

            graph[i].setNodeValue(0);
            List<Node> unexplored = graph;

            List<Node> explored=new List<Node>();

            while (unexplored.Count != 0)
            {
                Node x = graph.Last();

                foreach(Node n in unexplored)
                {
                    
                    if((int)n.getNodeValue()<(int)x.getNodeValue())
                    {
                        x = n;                        
                    }
                }
                explored.Add(x);
                unexplored.Remove(x);

                foreach (Node n in x.getNeighBours())
                {
                   
                    if ((int)n.getNodeValue()> (int) x.getNodeValue() + (int)x.getEdge(n).getWeight()
                        && (int)x.getNodeValue()!=int.MaxValue ) 
                    {
                        n.setNodeValue((int)x.getNodeValue() + (int)x.getEdge(n).getWeight());
                        n.setParent(x);                                                
                    }
                }
             }
            
            return explored;
        }



        /*Dijkstra algoritmus-2
        *Hasznalatahoz megvalositandoak:
        *  A Node Interfacebol:
        *                      -setNodeValue(o) (a csucs erteket allitja, object-et var, integer-rel megvalositando)
        *                      
        *                      -getNodeValue()  (a csucs erteket adja vissza,a metodus object-tel ter vissza, integer-rel megvalositando)
        *                      
        *                      -setParent(n)    (a csucs szulojenek megadasa, n megvalositja a Node interface-t)
        *                      
        *                      -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
        *                                        
        *                      -getEdge(n)      (a csucs amire meghivjuk es a parameterkent megadott csucs kozotti elt adja vissza)
        *                      
        *  Az Edge interfacbeol:
        *                      -getWeight()     (az el elsulyat adja vissza,integerrel ter vissza)
        *                      
        *             
        */
        public static List<Node> dijkstra(List<Node> graph, Node root)
        {

            foreach (Node n in graph)
            {
                n.setNodeValue(int.MaxValue);
                n.setParent(null);
            }

            root.setNodeValue(0);
            List<Node> unexplored = graph;

            List<Node> explored = new List<Node>();

            while (unexplored.Count != 0)
            {
                Node x = graph.Last();

                foreach (Node n in unexplored)
                {

                    if ((int)n.getNodeValue() < (int)x.getNodeValue())
                    {
                        x = n;
                    }
                }
                explored.Add(x);
                unexplored.Remove(x);

                foreach (Node n in x.getNeighBours())
                {

                    if ((int)n.getNodeValue() > (int)x.getNodeValue() + (int)x.getEdge(n).getWeight()
                        && (int)x.getNodeValue() != int.MaxValue)
                    {
                        n.setNodeValue((int)x.getNodeValue() + (int)x.getEdge(n).getWeight());
                        n.setParent(x);
                    }
                }
            }

            return explored;
        }


        /*Dijkstra algoritmus-3
         *Hasznalatahoz megvalositandoak:
         *  A Node Interfacebol:
         *                      -setNodeValue(o) (a csucs erteket allitja, object-et var, integer-rel megvalositando)
         *                      
         *                      -getNodeValue()  (a csucs erteket adja vissza,a metodus object-tel ter vissza, integer-rel megvalositando)
         *                      
         *                      -setParent(n)    (a csucs szulojenek megadasa, n megvalositja a Node interface-t)
         *                      
         *                      -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
         *                                        
         *                      -getEdge(n)      (a csucs amire meghivjuk es a parameterkent megadott csucs kozotti elt adja vissza)
         *                      
         *  Az Edge interfacbeol:
         *                      -getWeight()     (az el elsulyat adja vissza,integerrel ter vissza)
         *                      
         *     
         * Az algoritmus ezen valtozata parameterkent a grafot varja parameterkent illetve egy egesz szamot (integer-t) ami megadja,
         * hogy a lista hanyadik eleme legyen a kezdo allapot.
         */
        public static List<Node> dijkstra(Graph g, Node root)
        {
            List<Node> graph = g.getNodes();

            foreach (Node n in graph)
            {
                n.setNodeValue(int.MaxValue);
                n.setParent(null);
            }

            root.setNodeValue(0);
            List<Node> unexplored = graph;

            List<Node> explored = new List<Node>();

            while (unexplored.Count != 0)
            {
                Node x = graph.Last();

                foreach (Node n in unexplored)
                {

                    if ((int)n.getNodeValue() < (int)x.getNodeValue())
                    {
                        x = n;
                    }
                }
                explored.Add(x);
                unexplored.Remove(x);

                foreach (Node n in x.getNeighBours())
                {

                    if ((int)n.getNodeValue() > (int)x.getNodeValue() + (int)x.getEdge(n).getWeight()
                        && (int)x.getNodeValue() != int.MaxValue)
                    {
                        n.setNodeValue((int)x.getNodeValue() + (int)x.getEdge(n).getWeight());
                        n.setParent(x);
                    }
                }
            }

            return explored;
        }




        /*Dijkstra algoritmus-4
       *Hasznalatahoz megvalositandoak:
       *  A Node Interfacebol:
       *                      -setNodeValue(o) (a csucs erteket allitja, object-et var, integer-rel megvalositando)
       *                      
       *                      -getNodeValue()  (a csucs erteket adja vissza,a metodus object-tel ter vissza, integer-rel megvalositando)
       *                      
       *                      -setParent(n)    (a csucs szulojenek megadasa, n megvalositja a Node interface-t)
       *                      
       *                      -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
       *                                        
       *                      -getEdge(n)      (a csucs amire meghivjuk es a parameterkent megadott csucs kozotti elt adja vissza)
       *                      
       *  Az Edge interfacbeol:
       *                      -getWeight()     (az el elsulyat adja vissza,integerrel ter vissza)
       *                      
       *     
       * Az algoritmus ezen valtozata parameterkent a grafot varja generikus lista formajaban illetve egy egesz szamot (integer-t) ami megadja,
       * hogy a lista hanyadik eleme legyen a kezdo allapot.
       */
        public static List<Node> dijkstra(List<Node> graph, int i,Node goal)
        {

            foreach (Node n in graph)
            {
                n.setNodeValue(int.MaxValue);
                n.setParent(null);
            }

            graph[i].setNodeValue(0);
            List<Node> unexplored = graph;

            List<Node> explored = new List<Node>();

            while (unexplored.Count != 0)
            {
                Node x = graph.Last();

                foreach (Node n in unexplored)
                {

                    if ((int)n.getNodeValue() < (int)x.getNodeValue())
                    {
                        x = n;
                    }
                }
                explored.Add(x);
                unexplored.Remove(x);

                if (x == goal)
                {
                    return explored;
                }

                foreach (Node n in x.getNeighBours())
                {

                    if ((int)n.getNodeValue() > (int)x.getNodeValue() + (int)x.getEdge(n).getWeight()
                        && (int)x.getNodeValue() != int.MaxValue)
                    {
                        n.setNodeValue((int)x.getNodeValue() + (int)x.getEdge(n).getWeight());
                        n.setParent(x);
                    }
                }
            }

            return explored;
        }



        /*Dijkstra algoritmus-5
        *Hasznalatahoz megvalositandoak:
        *  A Node Interfacebol:
        *                      -setNodeValue(o) (a csucs erteket allitja, object-et var, integer-rel megvalositando)
        *                      
        *                      -getNodeValue()  (a csucs erteket adja vissza,a metodus object-tel ter vissza, integer-rel megvalositando)
        *                      
        *                      -setParent(n)    (a csucs szulojenek megadasa, n megvalositja a Node interface-t)
        *                      
        *                      -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
        *                                        
        *                      -getEdge(n)      (a csucs amire meghivjuk es a parameterkent megadott csucs kozotti elt adja vissza)
        *                      
        *  Az Edge interfacbeol:
        *                      -getWeight()     (az el elsulyat adja vissza,integerrel ter vissza)
        *                      
        *             
        */
        public static List<Node> dijkstra(List<Node> graph, Node root, Node goal)
        {

            foreach (Node n in graph)
            {
                n.setNodeValue(int.MaxValue);
                n.setParent(null);
            }

            root.setNodeValue(0);
            List<Node> unexplored = graph;

            List<Node> explored = new List<Node>();

            while (unexplored.Count != 0)
            {
                Node x = graph.Last();

                foreach (Node n in unexplored)
                {

                    if ((int)n.getNodeValue() < (int)x.getNodeValue())
                    {
                        x = n;
                    }
                }
                explored.Add(x);
                unexplored.Remove(x);

                if (x == goal)
                {
                    return explored;
                }

                foreach (Node n in x.getNeighBours())
                {

                    if ((int)n.getNodeValue() > (int)x.getNodeValue() + (int)x.getEdge(n).getWeight()
                        && (int)x.getNodeValue() != int.MaxValue)
                    {
                        n.setNodeValue((int)x.getNodeValue() + (int)x.getEdge(n).getWeight());
                        n.setParent(x);
                    }
                }
            }

            return explored;
        }


        /*Dijkstra algoritmus-6
         *Hasznalatahoz megvalositandoak:
         *  A Node Interfacebol:
         *                      -setNodeValue(o) (a csucs erteket allitja, object-et var, integer-rel megvalositando)
         *                      
         *                      -getNodeValue()  (a csucs erteket adja vissza,a metodus object-tel ter vissza, integer-rel megvalositando)
         *                      
         *                      -setParent(n)    (a csucs szulojenek megadasa, n megvalositja a Node interface-t)
         *                      
         *                      -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
         *                                        
         *                      -getEdge(n)      (a csucs amire meghivjuk es a parameterkent megadott csucs kozotti elt adja vissza)
         *                      
         *  Az Edge interfacbeol:
         *                      -getWeight()     (az el elsulyat adja vissza,integerrel ter vissza)
         *                      
         *     
         */
        public static List<Node> dijkstra(Graph g, Node root, Node goal)
        {
            List<Node> graph = g.getNodes();

            foreach (Node n in graph)
            {
                n.setNodeValue(int.MaxValue);
                n.setParent(null);
            }

            root.setNodeValue(0);
            List<Node> unexplored = graph;

            List<Node> explored = new List<Node>();

            while (unexplored.Count != 0)
            {
                Node x = graph.Last();

                foreach (Node n in unexplored)
                {

                    if ((int)n.getNodeValue() < (int)x.getNodeValue())
                    {
                        x = n;
                    }
                }
                explored.Add(x);
                unexplored.Remove(x);

                if (x == goal)
                {
                    return explored;
                }

                foreach (Node n in x.getNeighBours())
                {

                    if ((int)n.getNodeValue() > (int)x.getNodeValue() + (int)x.getEdge(n).getWeight()
                        && (int)x.getNodeValue() != int.MaxValue)
                    {
                        n.setNodeValue((int)x.getNodeValue() + (int)x.getEdge(n).getWeight());
                        n.setParent(x);
                    }
                }
            }

            return explored;
        }

        /*Dijkstra algoritmus-7
    *Hasznalatahoz megvalositandoak:
    *  A Node Interfacebol:
    *                      -setNodeValue(o) (a csucs erteket allitja, object-et var, integer-rel megvalositando)
    *                      
    *                      -getNodeValue()  (a csucs erteket adja vissza,a metodus object-tel ter vissza, integer-rel megvalositando)
    *                      
    *                      -setParent(n)    (a csucs szulojenek megadasa, n megvalositja a Node interface-t)
    *                      
    *                      -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
    *                                        
    *                      -getEdge(n)      (a csucs amire meghivjuk es a parameterkent megadott csucs kozotti elt adja vissza)
    *                      
    *  Az Edge interfacbeol:
    *                      -getWeight()     (az el elsulyat adja vissza,integerrel ter vissza)
    *                      
    *     
    * 
    */
        public static List<Node> dijkstra(List<Node> graph, int i,int j )
        {

            Node goal = graph[j];

            foreach (Node n in graph)
            {
                n.setNodeValue(int.MaxValue);
                n.setParent(null);
            }

            graph[i].setNodeValue(0);
            List<Node> unexplored = graph;

            List<Node> explored = new List<Node>();

            while (unexplored.Count != 0)
            {
                Node x = graph.Last();

                foreach (Node n in unexplored)
                {

                    if ((int)n.getNodeValue() < (int)x.getNodeValue())
                    {
                        x = n;
                    }
                }
                explored.Add(x);
                unexplored.Remove(x);

                if (x == goal)
                {
                    return explored;
                }

                foreach (Node n in x.getNeighBours())
                {

                    if ((int)n.getNodeValue() > (int)x.getNodeValue() + (int)x.getEdge(n).getWeight()
                        && (int)x.getNodeValue() != int.MaxValue)
                    {
                        n.setNodeValue((int)x.getNodeValue() + (int)x.getEdge(n).getWeight());
                        n.setParent(x);
                    }
                }
            }

            return explored;
        }


        /*A csillag algoritmus-1
         *Hasznalatahoz megvalositandoak:
         *  A Node Interfacebol:
         *                      -setNodeValue(o) (a csucs erteket allitja, object-et var, integer-rel megvalositando)
         *                      
         *                      -getNodeValue()  (a csucs erteket adja vissza,a metodus object-tel ter vissza, integer-rel megvalositando)
         *                      
         *                      -setParent(n)    (a csucs szulojenek megadasa, n megvalositja a Node interface-t)
         *                      
         *                      -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
         *                                        
         *                      -getEdge(n)      (a csucs amire meghivjuk es a parameterkent megadott csucs kozotti elt adja vissza)
         *                      
         *                      -getHeuristic() (a csucs heurisztikajat adja vissza)
         *                      
         *  Az Edge interfacbeol:
         *                      -getWeight()     (az el elsulyat adja vissza,integerrel ter vissza)
         *                      
         *     
         * Az algoritmus ezen valtozata parameterkent a grafot varja parameterkent illetve egy egesz szamot (integer-t) ami megadja,
         * hogy a lista hanyadik eleme legyen a kezdo allapot.
         */

        public static List<Node> aStar(List<Node> graph, int i)
        {

            foreach (Node n in graph)
            {
                n.setNodeValue(int.MaxValue);
                n.setParent(null);
            }

            graph[i].setNodeValue(0);
            List<Node> unexplored = graph;

            List<Node> explored = new List<Node>();

            while (unexplored.Count != 0)
            {
                Node x = graph.Last();

                foreach (Node n in unexplored)
                {
                    if ((int)n.getNodeValue() == int.MaxValue)
                    {
                        n.setNodeValue((int)n.getNodeValue() - (int)n.getHeuristic());
                    }

                    if ((int)x.getNodeValue() == int.MaxValue)
                    {
                        x.setNodeValue((int)x.getNodeValue() - (int)x.getHeuristic());
                    }

                    if ((int)n.getNodeValue()+(int)n.getHeuristic() < (int)x.getNodeValue()+(int)x.getHeuristic())
                    {
                      
                        x = n;
                    }
                }
                explored.Add(x);
                unexplored.Remove(x);

                foreach (Node n in x.getNeighBours())
                {

                    if ((int)x.getNodeValue() + (int)x.getEdge(n).getWeight()<(int)n.getNodeValue() )
                    {
                        n.setNodeValue((int)x.getNodeValue() + (int)x.getEdge(n).getWeight());
                        n.setParent(x);
                    }
                }
            }

            return explored;
        }



        /*A csillag algoritmus-2
         *Hasznalatahoz megvalositandoak:
         *  A Node Interfacebol:
         *                      -setNodeValue(o) (a csucs erteket allitja, object-et var, integer-rel megvalositando)
         *                      
         *                      -getNodeValue()  (a csucs erteket adja vissza,a metodus object-tel ter vissza, integer-rel megvalositando)
         *                      
         *                      -setParent(n)    (a csucs szulojenek megadasa, n megvalositja a Node interface-t)
         *                      
         *                      -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
         *                                        
         *                      -getEdge(n)      (a csucs amire meghivjuk es a parameterkent megadott csucs kozotti elt adja vissza)
         *                      
         *                      -getHeuristic() (a csucs heurisztikajat adja vissza)
         *                      
         *  Az Edge interfacbeol:
         *                      -getWeight()     (az el elsulyat adja vissza,integerrel ter vissza)
         *                      
         *           
         */

        public static List<Node> aStar(List<Node> graph, Node root)
        {

            foreach (Node n in graph)
            {
                n.setNodeValue(int.MaxValue);
                n.setParent(null);
            }

            root.setNodeValue(0);
            List<Node> unexplored = graph;

            List<Node> explored = new List<Node>();

            while (unexplored.Count != 0)
            {
                Node x = graph.Last();

                foreach (Node n in unexplored)
                {
                    if ((int)n.getNodeValue() == int.MaxValue)
                    {
                        n.setNodeValue((int)n.getNodeValue() - (int)n.getHeuristic());
                    }

                    if ((int)x.getNodeValue() == int.MaxValue)
                    {
                        x.setNodeValue((int)x.getNodeValue() - (int)x.getHeuristic());
                    }

                    if ((int)n.getNodeValue() + (int)n.getHeuristic() < (int)x.getNodeValue() + (int)x.getHeuristic())
                    {

                        x = n;
                    }
                }
                explored.Add(x);
                unexplored.Remove(x);

                foreach (Node n in x.getNeighBours())
                {

                    if ((int)x.getNodeValue() + (int)x.getEdge(n).getWeight() < (int)n.getNodeValue())
                    {
                        n.setNodeValue((int)x.getNodeValue() + (int)x.getEdge(n).getWeight());
                        n.setParent(x);
                    }
                }
            }

            return explored;
        }



        /*A csillag algoritmus-3
         *Hasznalatahoz megvalositandoak:
         *  A Node Interfacebol:
         *                      -setNodeValue(o) (a csucs erteket allitja, object-et var, integer-rel megvalositando)
         *                      
         *                      -getNodeValue()  (a csucs erteket adja vissza,a metodus object-tel ter vissza, integer-rel megvalositando)
         *                      
         *                      -setParent(n)    (a csucs szulojenek megadasa, n megvalositja a Node interface-t)
         *                      
         *                      -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
         *                                        
         *                      -getEdge(n)      (a csucs amire meghivjuk es a parameterkent megadott csucs kozotti elt adja vissza)
         *                      
         *                      -getHeuristic() (a csucs heurisztikajat adja vissza)
         *                      
         *  Az Edge interfacbeol:
         *                      -getWeight()     (az el elsulyat adja vissza,integerrel ter vissza)
         *                      
         *
         */

        public static List<Node> aStar(Graph g, Node root)
        {
            List<Node> graph = g.getNodes();

            foreach (Node n in graph)
            {
                n.setNodeValue(int.MaxValue);
                n.setParent(null);
            }

            root.setNodeValue(0);
            List<Node> unexplored = graph;

            List<Node> explored = new List<Node>();

            while (unexplored.Count != 0)
            {
                Node x = graph.Last();

                foreach (Node n in unexplored)
                {
                    if ((int)n.getNodeValue() == int.MaxValue)
                    {
                        n.setNodeValue((int)n.getNodeValue() - (int)n.getHeuristic());
                    }

                    if ((int)x.getNodeValue() == int.MaxValue)
                    {
                        x.setNodeValue((int)x.getNodeValue() - (int)x.getHeuristic());
                    }

                    if ((int)n.getNodeValue() + (int)n.getHeuristic() < (int)x.getNodeValue() + (int)x.getHeuristic())
                    {

                        x = n;
                    }
                }
                explored.Add(x);
                unexplored.Remove(x);

                foreach (Node n in x.getNeighBours())
                {

                    if ((int)x.getNodeValue() + (int)x.getEdge(n).getWeight() < (int)n.getNodeValue())
                    {
                        n.setNodeValue((int)x.getNodeValue() + (int)x.getEdge(n).getWeight());
                        n.setParent(x);
                    }
                }
            }

            return explored;
        }


        /*A csillag algoritmus-4
         *Hasznalatahoz megvalositandoak:
         *  A Node Interfacebol:
         *                      -setNodeValue(o) (a csucs erteket allitja, object-et var, integer-rel megvalositando)
         *                      
         *                      -getNodeValue()  (a csucs erteket adja vissza,a metodus object-tel ter vissza, integer-rel megvalositando)
         *                      
         *                      -setParent(n)    (a csucs szulojenek megadasa, n megvalositja a Node interface-t)
         *                      
         *                      -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
         *                                        
         *                      -getEdge(n)      (a csucs amire meghivjuk es a parameterkent megadott csucs kozotti elt adja vissza)
         *                      
         *                      -getHeuristic() (a csucs heurisztikajat adja vissza)
         *                      
         *  Az Edge interfacbeol:
         *                      -getWeight()     (az el elsulyat adja vissza,integerrel ter vissza)
         *                      
         * 
         */

        public static List<Node> aStar(List<Node> graph, int i, Node goal)
        {

            foreach (Node n in graph)
            {
                n.setNodeValue(int.MaxValue);
                n.setParent(null);
            }

            graph[i].setNodeValue(0);
            List<Node> unexplored = graph;

            List<Node> explored = new List<Node>();

            while (unexplored.Count != 0)
            {
                Node x = graph.Last();

                foreach (Node n in unexplored)
                {
                    if ((int)n.getNodeValue() == int.MaxValue)
                    {
                        n.setNodeValue((int)n.getNodeValue() - (int)n.getHeuristic());
                    }

                    if ((int)x.getNodeValue() == int.MaxValue)
                    {
                        x.setNodeValue((int)x.getNodeValue() - (int)x.getHeuristic());
                    }

                    if ((int)n.getNodeValue() + (int)n.getHeuristic() < (int)x.getNodeValue() + (int)x.getHeuristic())
                    {

                        x = n;
                    }
                }
                explored.Add(x);
                unexplored.Remove(x);

                if (x == goal)
                {
                    return explored;
                }

                foreach (Node n in x.getNeighBours())
                {

                    if ((int)x.getNodeValue() + (int)x.getEdge(n).getWeight() < (int)n.getNodeValue())
                    {
                        n.setNodeValue((int)x.getNodeValue() + (int)x.getEdge(n).getWeight());
                        n.setParent(x);
                    }
                }
            }

            return explored;
        }



        /*A csillag algoritmus-5
         *Hasznalatahoz megvalositandoak:
         *  A Node Interfacebol:
         *                      -setNodeValue(o) (a csucs erteket allitja, object-et var, integer-rel megvalositando)
         *                      
         *                      -getNodeValue()  (a csucs erteket adja vissza,a metodus object-tel ter vissza, integer-rel megvalositando)
         *                      
         *                      -setParent(n)    (a csucs szulojenek megadasa, n megvalositja a Node interface-t)
         *                      
         *                      -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
         *                                        
         *                      -getEdge(n)      (a csucs amire meghivjuk es a parameterkent megadott csucs kozotti elt adja vissza)
         *                      
         *                      -getHeuristic() (a csucs heurisztikajat adja vissza)
         *                      
         *  Az Edge interfacbeol:
         *                      -getWeight()     (az el elsulyat adja vissza,integerrel ter vissza)
         *                      
         *     
         *
         */

        public static List<Node> aStar(List<Node> graph, Node root,Node goal)
        {

            foreach (Node n in graph)
            {
                n.setNodeValue(int.MaxValue);
                n.setParent(null);
            }

            root.setNodeValue(0);
            List<Node> unexplored = graph;

            List<Node> explored = new List<Node>();

            while (unexplored.Count != 0)
            {
                Node x = graph.Last();

                foreach (Node n in unexplored)
                {
                    if ((int)n.getNodeValue() == int.MaxValue)
                    {
                        n.setNodeValue((int)n.getNodeValue() - (int)n.getHeuristic());
                    }

                    if ((int)x.getNodeValue() == int.MaxValue)
                    {
                        x.setNodeValue((int)x.getNodeValue() - (int)x.getHeuristic());
                    }

                    if ((int)n.getNodeValue() + (int)n.getHeuristic() < (int)x.getNodeValue() + (int)x.getHeuristic())
                    {
                        x = n;
                    }
                }
                explored.Add(x);
                unexplored.Remove(x);

                if (x == goal)
                {
                    return explored;
                }

                foreach (Node n in x.getNeighBours())
                {

                    if ((int)x.getNodeValue() + (int)x.getEdge(n).getWeight() < (int)n.getNodeValue())
                    {
                        n.setNodeValue((int)x.getNodeValue() + (int)x.getEdge(n).getWeight());
                        n.setParent(x);
                    }
                }
            }

            return explored;
        }



        /*A csillag algoritmus-6
         *Hasznalatahoz megvalositandoak:
         *  A Node Interfacebol:
         *                      -setNodeValue(o) (a csucs erteket allitja, object-et var, integer-rel megvalositando)
         *                      
         *                      -getNodeValue()  (a csucs erteket adja vissza,a metodus object-tel ter vissza, integer-rel megvalositando)
         *                      
         *                      -setParent(n)    (a csucs szulojenek megadasa, n megvalositja a Node interface-t)
         *                      
         *                      -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
         *                                        
         *                      -getEdge(n)      (a csucs amire meghivjuk es a parameterkent megadott csucs kozotti elt adja vissza)
         *                      
         *                      -getHeuristic() (a csucs heurisztikajat adja vissza)
         *                      
         *  Az Edge interfacbeol:
         *                      -getWeight()     (az el elsulyat adja vissza,integerrel ter vissza)
         *                      
         *     
         * Az algoritmus ezen valtozata parameterkent a grafot varja parameterkent illetve egy egesz szamot (integer-t) ami megadja,
         * hogy a lista hanyadik eleme legyen a kezdo allapot.
         */

        public static List<Node> aStar(Graph g, Node root, Node goal)
        {

            List<Node> graph = g.getNodes();
            foreach (Node n in graph)
            {
                n.setNodeValue(int.MaxValue);
                n.setParent(null);
            }

            root.setNodeValue(0);
            List<Node> unexplored = graph;

            List<Node> explored = new List<Node>();

            while (unexplored.Count != 0)
            {
                Node x = graph.Last();

                foreach (Node n in unexplored)
                {
                    if ((int)n.getNodeValue() == int.MaxValue)
                    {
                        n.setNodeValue((int)n.getNodeValue() - (int)n.getHeuristic());
                    }

                    if ((int)x.getNodeValue() == int.MaxValue)
                    {
                        x.setNodeValue((int)x.getNodeValue() - (int)x.getHeuristic());
                    }

                    if ((int)n.getNodeValue() + (int)n.getHeuristic() < (int)x.getNodeValue() + (int)x.getHeuristic())
                    {

                        x = n;
                    }
                }
                explored.Add(x);
                unexplored.Remove(x);

                if (x == goal)
                {
                    return explored;
                }

                foreach (Node n in x.getNeighBours())
                {

                    if ((int)x.getNodeValue() + (int)x.getEdge(n).getWeight() < (int)n.getNodeValue())
                    {
                        n.setNodeValue((int)x.getNodeValue() + (int)x.getEdge(n).getWeight());
                        n.setParent(x);
                    }
                }
            }

            return explored;
        }




        /*A csillag algoritmus-7
         *Hasznalatahoz megvalositandoak:
         *  A Node Interfacebol:
         *                      -setNodeValue(o) (a csucs erteket allitja, object-et var, integer-rel megvalositando)
         *                      
         *                      -getNodeValue()  (a csucs erteket adja vissza,a metodus object-tel ter vissza, integer-rel megvalositando)
         *                      
         *                      -setParent(n)    (a csucs szulojenek megadasa, n megvalositja a Node interface-t)
         *                      
         *                      -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
         *                                        
         *                      -getEdge(n)      (a csucs amire meghivjuk es a parameterkent megadott csucs kozotti elt adja vissza)
         *                      
         *                      -getHeuristic() (a csucs heurisztikajat adja vissza)
         *                      
         *  Az Edge interfacbeol:
         *                      -getWeight()     (az el elsulyat adja vissza,integerrel ter vissza)
         *                      
         *     
         * Az algoritmus ezen valtozata parameterkent a grafot varja parameterkent illetve egy egesz szamot (integer-t) ami megadja,
         * hogy a lista hanyadik eleme legyen a kezdo allapot.
         */

        public static List<Node> aStar(List<Node> graph, int i, int j)
        {
            Node goal = graph[j];

            foreach (Node n in graph)
            {
                n.setNodeValue(int.MaxValue);
                n.setParent(null);
            }

            graph[i].setNodeValue(0);
            List<Node> unexplored = graph;

            List<Node> explored = new List<Node>();

            while (unexplored.Count != 0)
            {
                Node x = graph.Last();

                foreach (Node n in unexplored)
                {
                    if ((int)n.getNodeValue() == int.MaxValue)
                    {
                        n.setNodeValue((int)n.getNodeValue() - (int)n.getHeuristic());
                    }

                    if ((int)x.getNodeValue() == int.MaxValue)
                    {
                        x.setNodeValue((int)x.getNodeValue() - (int)x.getHeuristic());
                    }

                    if ((int)n.getNodeValue() + (int)n.getHeuristic() < (int)x.getNodeValue() + (int)x.getHeuristic())
                    {

                        x = n;
                    }
                }
                explored.Add(x);
                unexplored.Remove(x);

                if (x == goal)
                {
                    return explored;
                }

                foreach (Node n in x.getNeighBours())
                {

                    if ((int)x.getNodeValue() + (int)x.getEdge(n).getWeight() < (int)n.getNodeValue())
                    {
                        n.setNodeValue((int)x.getNodeValue() + (int)x.getEdge(n).getWeight());
                        n.setParent(x);
                    }
                }
            }

            return explored;
        }


        /*A csillag algoritmus-D
         *Hasznalatahoz megvalositandoak:
         *  A Node Interfacebol:
         *                      -setNodeValue(o) (a csucs erteket allitja, object-et var, integer-rel megvalositando)
         *                      
         *                      -getNodeValue()  (a csucs erteket adja vissza,a metodus object-tel ter vissza, integer-rel megvalositando)
         *                      
         *                      -setParent(n)    (a csucs szulojenek megadasa, n megvalositja a Node interface-t)
         *                      
         *                      -getNeighBours() (a csucs szomszedait adja vissza, List<Node> tipusu generikus gyujtemennyel ter vissza)
         *                                        
         *                      -getEdge(n)      (a csucs amire meghivjuk es a parameterkent megadott csucs kozotti elt adja vissza)
         *                      
         *                      -getHeuristic() (a csucs heurisztikajat adja vissza)
         *                      
         *  Az Edge interfacbeol:
         *                      -getWeight()     (az el elsulyat adja vissza,integerrel ter vissza)
         *                      
         *Demonstrációhoz.     
         *
         */

        public static List<Node> aStarD(List<Node> graph, int i)
        {

            foreach (Node n in graph)
            {
                n.setNodeValue(int.MaxValue);
                n.setParent(null);
            }

            graph[i].setNodeValue(0);
            List<Node> unexplored = graph;

            List<Node> explored = new List<Node>();

            while (unexplored.Count != 0)
            {
                Node x = graph.Last();

                foreach (Node n in unexplored)
                {
                    if ((int)n.getNodeValue() == int.MaxValue)
                    {
                        n.setNodeValue((int)n.getNodeValue() - (int)n.getHeuristic());
                    }

                    if ((int)x.getNodeValue() == int.MaxValue)
                    {
                        x.setNodeValue((int)x.getNodeValue() - (int)x.getHeuristic());
                    }

                    if ((int)n.getNodeValue() + (int)n.getHeuristic() < (int)x.getNodeValue() + (int)x.getHeuristic())
                    {

                        x = n;
                    }
                }
                explored.Add(x);
                unexplored.Remove(x);

                foreach (Node n in x.getNeighBours())
                {

                    if ((int)x.getNodeValue() + (int)x.getEdge(n).getWeight() < (int)n.getNodeValue())
                    {
                        n.setNodeValue((int)x.getNodeValue() + (int)x.getEdge(n).getWeight());
                        n.setParent(x);
                    }
                }
            }

            return explored;
        }
    }
}