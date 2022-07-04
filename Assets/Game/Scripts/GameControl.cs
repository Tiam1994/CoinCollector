using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public AudioSource[] sfxSounds;
    public AudioSource backgroundMusic;
    public GameObject coin;
    private float creationTime = 0;
    public string sceneName;
    public CanvasGroup loadingPanel;
    public TextMeshProUGUI loadingText;

    private void Start()
    {
        CheckingSettings();
    }

    private void Update()
    {
        CreateCoin();
    }

    private void CreateCoin()
    {
        creationTime += Time.deltaTime;
        if (creationTime >= 3f)
        {
            Vector3 location = new Vector3(Random.Range(-17, 17), 5, 1);
            Instantiate(coin, location, Quaternion.identity);
            creationTime = 0f;
        }
    }

    public void OnMenu()
    {
        loadingPanel.DOFade(1, 2f).OnComplete(() => loadingText.DOFade(0, 2f).OnComplete(() => SceneManager.LoadScene(sceneName)));
    }

    private void CheckingSettings()
    {
        backgroundMusic.mute = System.Convert.ToBoolean(PlayerPrefs.GetInt("MusicMute", 0));

        for (int i = 0; i < sfxSounds.Length; i++)
        {
            sfxSounds[i].mute = System.Convert.ToBoolean(PlayerPrefs.GetInt("SFXMute", 0));
        }
    }
}
