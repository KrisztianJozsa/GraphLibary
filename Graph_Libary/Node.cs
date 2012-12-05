using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphLibary
{
    public interface Node 
    {
        
        void setNodeValue(object nodeValue); //a csucs ertekenek beallitasahoz

        object getNodeValue(); //a csucs erteket adja vissza

        void setGoodNess(int goodNess); //a csucs "josagat" lehet vele beallitani, peldaul populacio alapu keresesekhez

        int getGoodNess(); // a csucs "josagahoz" rendelt erteket(egesz szamot) adja vissza

        void setNeighBour(Node neighbour); // a csucsnak szomszedot allit be

        List<Node> getNeighBours(); // a csucs szomszedait adja vissza
        
        void setEdge(Edge edge) ; //elt add a csucshoz 

        List<Edge> getEdges(); //visszaadja a grafhoz tartozo eleket

        Edge getEdge(Node other); //visszaadja az ebbol a parameter listaban megadott csuba vezeto elt

        void setParent(Node parent); //szolut allit be  csucshoz, Dijkstrahoz es A*hoz

        Node getParent(); // visszaadja a szulot Dijkstrahoz es A*hoz

        object getHeuristic(); //visszaadja a heurisztikát

        Node copy();

    }
}
