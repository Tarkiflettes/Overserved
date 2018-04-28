using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.IA
{
    public class ClientIA : MonoBehaviour
    {

        public bool MovingToDestination { get; set; }

        public Vector3 Destination { get; set; }

        public NavMeshAgent NavMeshAgent { get; private set; }

        private bool _move;
        private Vector3 _dest;

        private void Start()
        {
            MovingToDestination = false;
            Destination = Vector3.negativeInfinity;
            NavMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
        }

        public void MoveTo(Vector3 destVector3)
        {
            _dest = destVector3;
            _move = true;
            GetComponent<NavMeshAgent>().destination = destVector3;
        }

    }
}
