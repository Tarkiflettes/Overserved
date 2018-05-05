using System.Collections;
using Assets.Scripts.Interactive;
using Assets.Scripts.Interactive.Abstract;
using UnityEngine;

namespace Assets.Scripts.IA
{
    public class Client : MonoBehaviour
    {
        
        private Dish _dish;

        public void StartEating(Dish dish)
        {
            _dish = dish;
            StartCoroutine(Eat());
        }

        private void Finish()
        {
            var table = GetComponentInParent<Table>();
            table.AddPlateToFinishPosition(_dish);
        }

        private IEnumerator Eat()
        {
            yield return _dish.Consume();
            Finish();
        }

    }
}
