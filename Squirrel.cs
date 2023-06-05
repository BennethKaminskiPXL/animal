using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Squirrel : Animal
    {
        public override KindOfSpecies Species => KindOfSpecies.Acorn;

        public override string ImageName => "squirrel.png";
    }
}
