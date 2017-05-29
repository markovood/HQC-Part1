namespace ClassChefInCSharp
{
    public abstract class Vegetable
    {
        public Vegetable(string name, uint weight, uint calories)
        {
            this.Name = name;
            this.Weight = weight;
            this.CaloriesPer100Grams = calories;
        }

        public string Name { get; private set; }

        public uint Weight { get; set; }

        public uint CaloriesPer100Grams { get; private set; }
    }
}
