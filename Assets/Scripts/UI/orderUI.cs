using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class orderUI : MonoBehaviour {


	// Use this for initialization
	void Start () {

        Order order = new Order();
        order.generateRandomFood(5);
        showOrder(order);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void showOrder(Order order)
    {
        //show order nbr
        List<Food> foods = order.getOrderedFood();
        foreach(var food in foods)
        {
            //AddTextToCanvas(food.getFoodName(), this.gameObject);
            Debug.Log(food.getFoodName());
        }
    }

    public static Text AddTextToCanvas(string textString, GameObject canvasGameObject)
    {
        Text text = canvasGameObject.AddComponent<Text>();
        text.text = textString;

        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        text.font = ArialFont;
        text.material = ArialFont.material;

        return text;
    }

    public void addImageToCanvas()
    {

    }


}
