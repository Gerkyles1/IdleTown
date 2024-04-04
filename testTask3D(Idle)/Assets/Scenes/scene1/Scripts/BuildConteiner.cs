using Clases;
using UnityEngine;
using static Clases.Build;

namespace Scripts
{
    public class BuildConteiner : MonoBehaviour
    {
        public Build build { get; private set; }
        public static Build[] startBuildStats { get; private set;  } = new Build[]
        {
            new Build(kindOfBuilds.smallMail, 10, 0.5f, 20),
            new Build(kindOfBuilds.cocacola, 100, 2f, 200),
            new Build(kindOfBuilds.imptOffice, 1000, 20f, 2000),
        };
        private void Start()
        {
            GetComponent<BoxCollider>().enabled = false;
        }
        public void CreateBuild(kindOfBuilds kind)
        {
            ActivateChildObject((int)kind);
            build  = new Build(startBuildStats[(int)kind]);
            Balance.ChangeIncome(build.incomePerSecond);
            startBuildStats[(int)kind].price = (int)(build.price+build.incomePerSecond*20f);
            GameManager.instance.chooseBuildUI.GetComponent<ChooseBuildUI>().UpdateData();
            GetComponent<BoxCollider>().enabled = true;


        }

        private void ActivateChildObject(int childIndex)
        {
            if (childIndex >= 0 && childIndex < transform.childCount)
            {
                transform.GetChild(childIndex).gameObject.SetActive(true);
            }
            else
            {
                Debug.LogError("Invalid child index: " + childIndex);
            }
        }
    }
}
