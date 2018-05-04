using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Food
{
    public class Food : MonoBehaviour
    {

        public bool Finished { get; private set; }
        public int TimeToEat = 2;

        public IEnumerator Consume()
        {
            if (Finished)
                yield break;
            yield return new WaitForSeconds(TimeToEat);
            Finish();
        }

        public void Finish()
        {
            Finished = true;
        }

    }
}
