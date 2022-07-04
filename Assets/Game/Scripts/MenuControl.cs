using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject settingsPanel;
    public CanvasGroup loadingPanel;
    public TextMeshProUGUI loadingText;
    public Button playButton;
    public Button settingsButton;
    public Button backButton;
    public AudioSource buttonsClick;
    public AudioSource backgroundMusic;
    public Toggle toggleSFX;
    public Toggle toggleMusic;
    public string sceneName;

    private void Start()
    {
        CheckingSettings();
    }

    public void SelectOptions()
    {
        buttonsClick.Play();
        menuPanel.transform.DOLocalMove(new Vector3(-1000, 0, 0), 0.5f);
        settingsPanel.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f).OnComplete(() => settingsButton.interactable = true);;
    }

    public void SelectMenu()
    {
        buttonsClick.Play();
        menuPanel.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
        settingsPanel.transform.DOLocalMove(new Vector3(1000, 0, 0), 0.5f).OnComplete(() => backButton.interactable = true);
    }

    public void SelectPlay()
    {
        buttonsClick.Play();
        menuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        loadingPanel.DOFade(1, 2f).OnComplete(() => loadingText.DOFade(0, 2f).OnComplete(() => SceneManager.LoadScene(sceneName)));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SFXActive()
    {
        buttonsClick.Play();

        if (buttonsClick.mute == false)
        {
            buttonsClick.mute = true;
            PlayerPrefs.SetInt("SFXMute", 1);
            toggleSFX.isOn = false;
        }
        else
        {
            buttonsClick.mute = false;
            PlayerPrefs.SetInt("SFXMute", 0);
            toggleSFX.isOn = true;
        }
    }

    public void MusicActive()
    {
        buttonsClick.Play();

        if (backgroundMusic.mute == false)
        {
            backgroundMusic.mute = true;
            PlayerPrefs.SetInt("MusicMute", 1);
            toggleMusic.isOn = false;
        }
        else
        {
            backgroundMusic.mute = false;
            PlayerPrefs.SetInt("MusicMute", 0);
            toggleMusic.isOn = true;
        }
    }

    private void CheckingSettings()
    {
        toggleSFX.isOn = !System.Convert.ToBoolean(PlayerPrefs.GetInt("SFXMute", 0));
        buttonsClick.mute = System.Convert.ToBoolean(PlayerPrefs.GetInt("SFXMute"));
        toggleMusic.isOn = !System.Convert.ToBoolean(PlayerPrefs.GetInt("MusicMute", 0));
        backgroundMusic.mute = System.Convert.ToBoolean(PlayerPrefs.GetInt("MusicMute"));
    }
}
