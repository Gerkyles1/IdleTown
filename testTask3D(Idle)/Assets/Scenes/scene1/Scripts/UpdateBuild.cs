using UnityEngine.EventSystems;
using UnityEngine;
using Scripts;

public class UpdateBuild : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.instance.isNoOtherMenuShown)
        {
            GameManager.instance.curentContainerForBuild = gameObject;
            GameManager.instance.updateMenu.SetActive(true);
            GameManager.instance.updateMenu.GetComponent<UpdateMenu>().UpdateInfo();
            GameManager.instance.isNoOtherMenuShown = false;
        }
    }
}
