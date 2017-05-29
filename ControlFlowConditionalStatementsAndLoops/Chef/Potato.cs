namespace ClassChefInCSharp
{
    public class Potato : Vegetable
    {
        public Potato(uint weight, uint caloriesPer100Grams, string name = "potato") :
            base(name, weight, caloriesPer100Grams)
        {
        }
    }
}
