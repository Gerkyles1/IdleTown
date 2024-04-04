using UnityEngine;

namespace Scripts
{
    public class BuildConteinerUI : MonoBehaviour
    {
        public GameObject plusButton;
        public void PlusButtonClicked()
        {
            if (GameManager.instance.isNoOtherMenuShown)
            {
                GameManager.instance.chooseBuildUI.gameObject.SetActive(true);
                GameManager.instance.curentContainerForBuild = gameObject;
                GameManager.instance.isNoOtherMenuShown = false;
            }
        }
    }
}