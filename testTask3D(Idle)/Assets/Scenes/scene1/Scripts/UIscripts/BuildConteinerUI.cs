using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class BuildConteinerUI : MonoBehaviour
    {
        public GameObject plusButton;
        public void plusButtonClicked()
        {
            GameManager.instance.chooseBuildUI.gameObject.SetActive(true);
            GameManager.instance.curentPlaceForBuild = gameObject;
        }


    }
}