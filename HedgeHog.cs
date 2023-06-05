using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class HedgeHog : Animal
    {
        public override KindOfSpecies Species => KindOfSpecies.EarthWorm;

        public override string ImageName => "hedgehog.png";
    }
}
