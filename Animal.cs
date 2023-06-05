namespace Game
{
    public abstract class Animal : Sprite
    {
        //ToDo Make an abstract read only property Species
        public abstract KindOfSpecies Species { get; }

        public override void AdjustSize(double width, double height)
        {
            //todo volledige hoogte en breedte;
            Image.Width = width;
            Image.Height = height;
        }
        
    }
}

