using System.Collections;
using Assets.Scripts.Interactive;
using UnityEngine;

namespace Assets.Scripts.IA
{
    public class Client : MonoBehaviour
    {
        
        private Plate _plate;

        public void StartEating(Plate plate)
        {
            _plate = plate;
            StartCoroutine(Eat());
        }

        private void Finish()
        {
            var table = GetComponentInParent<Table>();
            table.AddPlateToFinishPosition(_plate);
        }

        private IEnumerator Eat()
        {
            yield return _plate.Consume();
            Finish();
        }

    }
}
