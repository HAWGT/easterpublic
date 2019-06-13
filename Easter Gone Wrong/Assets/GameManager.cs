using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreObject;
    [SerializeField] private Image fuelObject;
    [SerializeField] private Image heart1;
    [SerializeField] private Image heart2;
    [SerializeField] private Image heart3;
    public void GameOver(float score)
    {
        int oldScore = PlayerPrefs.GetInt("score");
        if (score > oldScore) PlayerPrefs.SetInt("score", (int)score);
        PlayerPrefs.SetInt("lastScore", (int)score);
        SceneManager.LoadScene(2);
    }

    public void UpdateScore(float score)
    {
        scoreObject.text = score.ToString();
    }

    public void UpdateFuel(float fuelPercent)
    {
        fuelObject.fillAmount = fuelPercent;
    }

    public void UpdateLives(float hp)
    {
        if(hp == 0)
        {
            heart1.color = new Color(heart1.color.r, heart1.color.g, heart1.color.b, 0);
            heart2.color = new Color(heart2.color.r, heart2.color.g, heart2.color.b, 0);
            heart3.color = new Color(heart3.color.r, heart3.color.g, heart3.color.b, 0);
        }
        if (hp == 1)
        {
            heart1.color = new Color(heart1.color.r, heart1.color.g, heart1.color.b, 1);
            heart2.color = new Color(heart2.color.r, heart2.color.g, heart2.color.b, 0);
            heart3.color = new Color(heart3.color.r, heart3.color.g, heart3.color.b, 0);
        }
        if (hp == 2)
        {
            heart1.color = new Color(heart1.color.r, heart1.color.g, heart1.color.b, 1);
            heart2.color = new Color(heart2.color.r, heart2.color.g, heart2.color.b, 1);
            heart3.color = new Color(heart3.color.r, heart3.color.g, heart3.color.b, 0);
        }
        if (hp == 3)
        {
            heart1.color = new Color(heart1.color.r, heart1.color.g, heart1.color.b, 1);
            heart2.color = new Color(heart2.color.r, heart2.color.g, heart2.color.b, 1);
            heart3.color = new Color(heart3.color.r, heart3.color.g, heart3.color.b, 1);
        }
    }
}
