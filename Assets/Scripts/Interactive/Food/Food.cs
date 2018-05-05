﻿using System.Collections;
using Assets.Scripts.Interactive.Abstract;
using UnityEngine;

namespace Assets.Scripts.Interactive.Food
{
    public class Food : Catchable
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
