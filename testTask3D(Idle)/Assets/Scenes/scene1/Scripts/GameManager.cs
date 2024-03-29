using UnityEngine;

namespace Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public GameObject chooseBuildUI;
        public GameObject curentPlaceForBuild = null;

        void Awake()
        {
            if (instance == null)
                instance = this;

            else if (instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);


        }
    }
}