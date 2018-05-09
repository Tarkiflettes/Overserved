using Assets.Scripts.Interactive.Abstract;
using Assets.Scripts.Interactive.Food;
using UnityEngine;

namespace Assets.Scripts.Interactive
{
    public class Broom : Catchable
    {

        private RottenFood _rottenFood;

        private void Update()
        {
            if (IsInteracting && _rottenFood != null)
                _rottenFood.Clean();
        }

        private void OnTriggerEnter(Collider col)
        {
            var rottenFood = col.gameObject.GetComponent<RottenFood>();
            if (rottenFood != null)
                _rottenFood = rottenFood;
        }

        private void OnTriggerExit(Collider col)
        {
            var rottenFood = col.gameObject.GetComponent<RottenFood>();
            if (rottenFood != null)
                _rottenFood = null;
        }

    }
}
