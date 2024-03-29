using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class ProgressBar : MonoBehaviour
    {
        private float lastTime;
        private void Start()
        {
            lastTime = Time.time;
        }
        void Update()
        {
            float dif = Time.time - lastTime;
            if (dif < 1)
            {
                GetComponent<Slider>().value = dif;
            }
            else
            {
                lastTime = Time.time;
                GetComponent<Slider>().value = 0;
                Balance.changeBalance(Balance.incomePerSec);

            }
        }
    }
}