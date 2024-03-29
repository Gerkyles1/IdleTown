using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class Balance : MonoBehaviour
    {
        [SerializeField] private Text balanceText;
        public static float balance { get; private set; } = 10;
        private static Action balanceChanded;
        public static float incomePerSec { get; private set; } = 0;
        private void Start()
        {
            updateBalance();
            balanceChanded += updateBalance;
        }
        public static void changeBalance(float sum)
        {
            if ((balance + sum) >= 0)  
            {
                balance += sum;
                balanceChanded?.Invoke();
            }
        }
        public static void changeIncome(float sum)
        {
            incomePerSec += sum;
        }
        private void updateBalance()
        {
            balanceText.text = ((int)balance).ToString();
        }
    }
}