using Clases;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class UpdateMenu : MonoBehaviour
    {
        [SerializeField] private Text incameOld;
        [SerializeField] private Text incameNew;

        [SerializeField] private Text levelOld;
        [SerializeField] private Text levelNew;

        [SerializeField] private Text updatePriceOld;
        [SerializeField] private Text updatePriceNew;

        [SerializeField] private Text updatePriceButton;

        private Build curentBuildInfo;

        void Start()
        {
            UpdateInfo();
        }

        public void UpdateInfo()
        {
            curentBuildInfo = GameManager.instance.curentContainerForBuild.GetComponent<BuildConteiner>().build;


            incameOld.text = curentBuildInfo.incomePerSecond.ToString();
            levelOld.text = curentBuildInfo.level.ToString();
            updatePriceOld.text = updatePriceButton.text = curentBuildInfo.upgradePrice.ToString();

            string[] data = new string[3];
            curentBuildInfo.InfoIfBuildLvlUp(ref data[0], ref data[1], ref data[2]);

            incameNew.text = data[0];
            levelNew.text = data[1];
            updatePriceNew.text = data[2];

        }

        public void BuyButtonPress()
        {
            if (Balance.balance >= curentBuildInfo.upgradePrice)
            {
                Balance.ChangeBalance(-curentBuildInfo.upgradePrice);
                curentBuildInfo.LevelUp();
                UpdateInfo();
            }
        }
    }
}