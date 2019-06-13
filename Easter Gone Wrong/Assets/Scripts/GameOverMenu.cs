using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreObject;
    [SerializeField] TextMeshProUGUI recordObject;
    private bool muted = false;
    [SerializeField] private Image muteIcon;
    [SerializeField] private Sprite offImage;
    [SerializeField] private Sprite onImage;

    private void Start()
    {
        bool isHighScore = PlayerPrefs.GetInt("lastScore") == PlayerPrefs.GetInt("score");
        scoreObject.text = PlayerPrefs.GetInt("lastScore").ToString();
        if (isHighScore) recordObject.text = "New Record!";
        if (PlayerPrefs.GetInt("volume") == 0)
        {
            muteIcon.GetComponent<Button>().image.sprite = onImage;
            AudioListener.pause = false;
        }
        else if(PlayerPrefs.GetInt("volume") == -1)
        {
            muteIcon.GetComponent<Button>().image.sprite = offImage;
            AudioListener.pause = true;
        }
        else if (PlayerPrefs.GetInt("volume") == 1)
        {
            muteIcon.GetComponent<Button>().image.sprite = onImage;
            AudioListener.pause = false;
        }

    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ToggleMute()
    {
        muted = !muted;
        if (muted)
        {
            muteIcon.GetComponent<Button>().image.sprite = offImage;
            AudioListener.pause = true;
            PlayerPrefs.SetInt("volume", -1);
        }
        else
        {
            muteIcon.GetComponent<Button>().image.sprite = onImage;
            AudioListener.pause = false;
            PlayerPrefs.SetInt("volume", 1);
        }
    }
}
