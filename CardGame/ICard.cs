using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame
{
    public interface ICard
    {
        string Name{get;}
        int Cost{get;}
        int Attack{get;}
        int Defense{get;}
    }
}