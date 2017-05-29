namespace ClassChefInCSharp
{
    public class Chef
    {
        public void Cook()
        {
            uint potatoWeight = 200;
            uint potatoCalories = 77;
            uint carrotWeight = 50;
            uint carrotCalories = 41;
            uint bowlVolume = 2000;
            uint bowlSize = 22;

            Potato potato = this.GetPotato(potatoWeight, potatoCalories);
            Carrot carrot = this.GetCarrot(carrotWeight, carrotCalories);
            Bowl bowl = this.GetBowl(bowlVolume, bowlSize);

            this.Peel(potato);
            this.Peel(carrot);

            this.Cut(potato);
            this.Cut(carrot);

            bowl.Add(carrot);
            bowl.Add(potato);
        }

        private void Peel(Vegetable anyVegetable)
        {
            uint waste = 5;
            anyVegetable.Weight -= waste;
        }

        private Bowl GetBowl(uint volume, uint size)
        {
            // ... 
            return new Bowl(volume, size);
        }

        private Carrot GetCarrot(uint weight, uint caloriesPer100Grams)
        {
            // ...
            return new Carrot(weight, caloriesPer100Grams);
        }

        private Potato GetPotato(uint weight, uint caloriesPer100Grams)
        {
            // ...
            return new Potato(weight, caloriesPer100Grams);
        }

        private void Cut(Vegetable someVegetable)
        {
            // ...
        }
    }
}
