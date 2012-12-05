using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphLibary
{
     public interface Graph
    {
        void setBeginNode(Node beginNode) ;//a kezdo csucs beallitasahoz

        void addEdge(Node from, Node to);

        void deleteEdge(Node from, Node to);

        void addNode(Node node);

        void deleteNode(Node node);

        List<Node> getNodes();

        List<Edge> getEdges();

        Graph copy();


    }
}
