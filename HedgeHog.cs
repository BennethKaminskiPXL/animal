using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class HedgeHog : Animal
    {
       

        public override string ImageName
        {
            get => "hedgehog.png";
        }

        public override KindOfSpecies Species => KindOfSpecies.EarthWorm;
    }
}
