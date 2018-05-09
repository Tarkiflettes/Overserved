using Assets.Scripts.Interactive.Abstract;
using Assets.Scripts.Interactive.Food;
using UnityEngine;

namespace Assets.Scripts.Interactive
{
    public class Broom : Catchable
    {

        public override void Interact(GameObject obj)
        {
            var rottenFood = obj.GetComponent<RottenFood>();
            Debug.Log("LA : " + obj);
        }

    }
}
