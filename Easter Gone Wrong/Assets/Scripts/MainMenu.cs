using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreObject;
    private bool muted = false;
    [SerializeField] private Image muteIcon;
    [SerializeField] private Sprite offImage;
    [SerializeField] private Sprite onImage;


    private Text score;

    private void Start()
    {
        scoreObject.text = PlayerPrefs.GetInt("score").ToString();
        if (PlayerPrefs.GetInt("volume") == 0)
        {
            muteIcon.GetComponent<Button>().image.sprite = onImage;
            AudioListener.pause = false;
        }
        else if (PlayerPrefs.GetInt("volume") == -1)
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

    public void PlayGame()
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
