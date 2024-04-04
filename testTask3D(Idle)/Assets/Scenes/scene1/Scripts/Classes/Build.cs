using Scripts;
using System;


namespace Clases
{
    public class Build
    {
        public int price;
        public kindOfBuilds kind { get; private set; }
        public float incomePerSecond { get; private set; }
        public int upgradePrice { get; private set; }
        public int level { get; private set; }

        public Build(kindOfBuilds kind, int price, float incomePerSecond, int upgradePrice)
        {
            this.kind = kind;
            this.price = price;
            this.incomePerSecond = incomePerSecond;
            this.upgradePrice = upgradePrice;
            level = 1;
        }
        public Build(Build build)
        {
            this.kind = build.kind;
            this.price = build.price;
            this.incomePerSecond = build.incomePerSecond;
            this.upgradePrice = build.upgradePrice;
            level = build.level;
        }

        public void LevelUp()
        {
            float oldIncome = incomePerSecond;

            incomePerSecond = (float)Math.Round(incomePerSecond * 2.5f, 1);
            Balance.ChangeIncome(incomePerSecond - oldIncome);
            level++;
            upgradePrice += (int)incomePerSecond * 100;
        }
        public void InfoIfBuildLvlUp(ref string newIncome, ref string newLevel, ref string newUpdatePrice)
        {
            newIncome = incomePerSecond * 2.5f + "";
            newLevel = level+1+"";
            newUpdatePrice = (upgradePrice + (int)(incomePerSecond * 2.5) * 100) + "";
        }

        public string GetKindOfBuildsInString()
        {
            switch ((int)kind)
            {
                case 0:
                    return "Small Mail";

                case 1:
                    return "Coca-Cola shop";

                case 2:
                    return "IMPT Office";
            }

            return "name for kind " + (int)kind + "not found";
        }

        public enum kindOfBuilds
        {
            smallMail = 0,
            cocacola = 1,
            imptOffice = 2
        }

    }
}
