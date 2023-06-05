using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Rabbit : Animal
    {
        public override KindOfSpecies Species => KindOfSpecies.Carrot;

        public override string ImageName => "rabbit.png";
    }
}
