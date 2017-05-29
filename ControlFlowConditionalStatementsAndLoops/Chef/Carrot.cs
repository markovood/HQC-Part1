namespace ClassChefInCSharp
{
    public class Carrot : Vegetable
    {
        public Carrot(uint weight, uint caloriesPer100Grams, string name = "carrot") : 
            base(name, weight, caloriesPer100Grams)
        {
        }
    }
}
