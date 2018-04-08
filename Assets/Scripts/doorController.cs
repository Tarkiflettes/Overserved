using UnityEngine;

namespace Assets.Scripts
{
    public class DoorController : MonoBehaviour
    {

        void LaunchAnimation()
        {
            GetComponent<Animation>().Play();
        }

    }
}
