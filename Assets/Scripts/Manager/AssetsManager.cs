using Assets.Scripts.Interactive;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Manager
{
    public class AssetsManager : MonoBehaviour
    {

        [Header("UI")]
        public GameObject Icon;
        public GameObject ProgressBar;
        public EventUI EventUI;

        [Header("Interactives")]
        public GameObject[] Interactives;
        public Phone Phone;

        [Header("Clients")]
        public GameObject[] Clients;
        public GameObject ClientSpawner;

    }
}
