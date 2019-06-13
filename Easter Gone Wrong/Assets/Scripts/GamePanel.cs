using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{

    private bool muted = false;
    [SerializeField] private Image muteIcon;
    [SerializeField] private Sprite offImage;
    [SerializeField] private Sprite onImage;

    private void Start()
    {
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

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ToggleMute()
    {
        muted = !muted;
        if(muted)
        {
            muteIcon.GetComponent<Button>().image.sprite = offImage;
            AudioListener.pause = true;
            PlayerPrefs.SetInt("volume", -1);
        } else
        {
            muteIcon.GetComponent<Button>().image.sprite = onImage;
            AudioListener.pause = false;
            PlayerPrefs.SetInt("volume", 1);
        }
    }
}
