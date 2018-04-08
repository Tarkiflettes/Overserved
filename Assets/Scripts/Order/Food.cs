namespace Assets.Scripts.Order
{
    public class Food
    {

        public enum FoodName { Hamburger, Salad };
        private readonly FoodName _name;

        public Food(FoodName food)
        {
            _name = food;
        }

        public string GetFoodName()
        {
            switch (_name)
            {
                case FoodName.Hamburger: return "Hamburger";
                case FoodName.Salad: return "Salad";
                default: return "";
            }
        }
    }
}
