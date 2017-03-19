namespace RefactoringMake_Чуек
{
    public class HumanFactory
    {
        public void Create_Human(int age)
        {
            var human = new Human();
            human.Age = age;
            if (age % 2 == 0)
            {
                human.Name = "Big Brother";
                human.Gender = Gender.Ultra_Macho;
            }
            else
            {
                human.Name = "The chick";
                human.Gender = Gender.Nice_Chick;
            }
        }
    }
}
