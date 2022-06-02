using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] Text waveText;
    [SerializeField] Text healthText;
    [SerializeField] Text timerText;

    public void setWaveText(int waveCounter)
    {
        waveText.text = "Wave " + waveCounter.ToString();
    }

    public void setHealthText(float health)
    {
        healthText.text = "Health: " + (int)health;
    }

    public void setTimer(string x)
    {
        timerText.text = x;
    }
}
