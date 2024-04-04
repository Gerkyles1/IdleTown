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
        public void SetContent(Build build)
        {
            this.build = build;
            kindName.text = build.GetKindOfBuildsInString();
            incoming.text = build.incomePerSecond.ToString();
            price.text = build.price.ToString();
        }
        public void CreateBuild()
        {
            if (build.price <= Balance.balance)
            {
                Balance.ChangeBalance(-build.price);
                GameManager.instance.curentContainerForBuild.GetComponent<BuildConteiner>().CreateBuild(build.kind);
                GameManager.instance.chooseBuildUI.SetActive(false);
                GameManager.instance.curentContainerForBuild.GetComponent<BuildConteinerUI>().plusButton.SetActive(false);
                GameManager.instance.isNoOtherMenuShown = true;
            }
        }
    }

}
