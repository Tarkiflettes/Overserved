using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {

        [Header("Manager")]
        public static GameManager Instance;
        public static AssetsManager AssetsManager;
        public UIManager UIManager;

        [Header("Score")]
        public int PlacedClient;
        public int ServedClient;
        public int MissedReservation;
        public int TakenReservation;

        void Awake()
        {
            if (Instance == null)
                Instance = this;

            else if (Instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }

        private void OnEnable()
        {
            AssetsManager = GetComponent<AssetsManager>();
        }

        private void Start()
        {
            StartCoroutine(Test());
        }

        private IEnumerator Test()
        {
            yield return new WaitForSeconds(1);
            RingPhone();
        }

        private void RingPhone()
        {
            AssetsManager.Phone.Ring();
        }

    }
}
