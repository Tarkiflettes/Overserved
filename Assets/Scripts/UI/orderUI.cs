using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class OrderUi : MonoBehaviour
    {

        void Start()
        {
            var order = new Order.Order();
            order.GenerateRandomFood(5);
            ShowOrder(order);
        }

        static void ShowOrder(Order.Order order)
        {
            //show order nbr
            var foods = order.GetOrderedFood();
            foreach (var food in foods)
            {
                //AddTextToCanvas(food.getFoodName(), this.gameObject);
                Debug.Log(food.GetFoodName());
            }
        }

        public static Text AddTextToCanvas(string textString, GameObject canvasGameObject)
        {
            var text = canvasGameObject.AddComponent<Text>();
            text.text = textString;

            var arialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            text.font = arialFont;
            text.material = arialFont.material;

            return text;
        }

        public void AddImageToCanvas()
        {

        }


    }
}
