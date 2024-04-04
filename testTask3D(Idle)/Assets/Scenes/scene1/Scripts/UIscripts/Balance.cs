using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class Balance : MonoBehaviour
    {
        [SerializeField] private Text balanceText;
        public static float balance { get; private set; } = 50;
        private static Action balanceChanded;
        public static float incomePerSec { get; private set; } = 0;
        private void Start()
        {
            UpdateBalance();
            balanceChanded += UpdateBalance;
        }
        public static void ChangeBalance(float sum)
        {
            if ((balance + sum) >= 0)  
            {
                balance += sum;
                balanceChanded?.Invoke();
            }
        }
        public static void ChangeIncome(float sum)
        {
            incomePerSec += sum;
        }
        private void UpdateBalance()
        {
            balanceText.text = ((int)balance).ToString();
        }
    }
}