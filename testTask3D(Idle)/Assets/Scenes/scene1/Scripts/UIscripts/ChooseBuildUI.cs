using UnityEngine;

namespace Scripts
{
    public class ChooseBuildUI : MonoBehaviour
    {
        [SerializeField] private GameObject buildsContainer;
        [SerializeField] private GameObject buildInfoPrefab;
        void Start()
        {
            if (buildsContainer.transform.childCount == BuildConteiner.startBuildStats.Length)
            {
                for (int i = 0; i < buildsContainer.transform.childCount; i++)
                {
                    buildsContainer.transform.GetChild(i).GetComponent<BuildInfoUI>().SetContent(BuildConteiner.startBuildStats[i]);
                }
            }
            else
            {
                foreach (Transform child in buildsContainer.transform)
                    Destroy(child.gameObject);

                for (int i = 0; i < BuildConteiner.startBuildStats.Length; i++)
                {
                    Instantiate(buildInfoPrefab, buildsContainer.transform).GetComponent<BuildInfoUI>().SetContent(BuildConteiner.startBuildStats[i]);
                }
            }

        }
        public void UpdateData()
        {
            if (buildsContainer.transform.childCount == BuildConteiner.startBuildStats.Length)
            {
                for (int i = 0; i < buildsContainer.transform.childCount; i++)
                {
                    buildsContainer.transform.GetChild(i).GetComponent<BuildInfoUI>().SetContent(BuildConteiner.startBuildStats[i]);
                }
            }
            else
            {
                foreach (Transform child in buildsContainer.transform)
                    Destroy(child.gameObject);

                for (int i = 0; i < BuildConteiner.startBuildStats.Length; i++)
                {
                    Instantiate(buildInfoPrefab, buildsContainer.transform).GetComponent<BuildInfoUI>().SetContent(BuildConteiner.startBuildStats[i]);
                }
            }
        }
    }
}