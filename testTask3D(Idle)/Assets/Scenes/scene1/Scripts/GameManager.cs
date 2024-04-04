using UnityEngine;

namespace Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public GameObject chooseBuildUI;
        public GameObject curentContainerForBuild = null;
        public GameObject updateMenu;
        public bool isNoOtherMenuShown = true;

        void Awake()
        {
            if (instance == null)
                instance = this;

            else if (instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }
        public void SetIsNoOtherMenuShown(bool b)
        {
            isNoOtherMenuShown = b;
        }
    }
}