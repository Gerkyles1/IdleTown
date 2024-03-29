using Clases;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class BuildInfoUI : MonoBehaviour
    {
        [SerializeField] private Text kindName;
        [SerializeField] private Text incoming;
        [SerializeField] private Text price;
        private Build build;
        public void setContent(Build build)
        {
            this.build = build;
            kindName.text = build.getKindOfBuildsInString();
            incoming.text = build.incomePerSecond.ToString();
            price.text = build.price.ToString();
        }
        public void createBuild()
        {
            if (build.price <= Balance.balance)
            {
                Balance.changeBalance(-build.price);
                GameManager.instance.curentPlaceForBuild.GetComponent<BuildConteiner>().createBuild(build.kind);
                GameManager.instance.chooseBuildUI.SetActive(false);
                GameManager.instance.curentPlaceForBuild.GetComponent<BuildConteinerUI>().plusButton.SetActive(false);
            }
        }
    }

}
