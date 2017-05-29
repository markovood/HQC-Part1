namespace ClassChefInCSharp
{
    public class Bowl
    {
        public Bowl(uint volume, uint size)
        {
            this.TotalVolume = volume;
            this.EmptyVolume = this.TotalVolume;
            this.Size = size;
        }


        public bool IsFull
        {
            get
            {
                if (this.EmptyVolume <= 0)
                {
                    return true;
                }

                return false;
            }
        }

        public uint EmptyVolume { get; private set; }

        public uint TotalVolume { get; set; }

        public uint Size { get; set; }

        public void Add(Vegetable someVegetable)
        {
            // calculate volume of vegetable and decrease emptyVolume
        }
    }
}
