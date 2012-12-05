using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphLibary
{
    public interface Edge
    {
       object getWeight();  //az el sulyt adja vissza

       void setWeight(object weight);

       void addNode(bool begin, Node node); //az el egyik vegehez hozzaad egy csucsot

       Node getNode(bool ending); //true=end , false=begin   //az el egyik vegerol visszadja a csucsot   

       Edge copy();
    }
}
