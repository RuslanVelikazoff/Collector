using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button musicButton;
    [SerializeField] private Sprite musicOnSprite;
    [SerializeField] private Sprite musicOffSprite;

    [Space(5)]

    [SerializeField] private Button soundButton;
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;

    private void Awake()
    {
        SetVolume();
        SetSprites();
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (musicButton != null)
        {
            musicButton.onClick.RemoveAllListeners();
            musicButton.onClick.AddListener(() =>
            {
                if (PlayerPrefs.GetFloat("MusicVolume") == 1f)
                {
                    PlayerPrefs.SetFloat("MusicVolume", 0f);
                    Debug.Log(PlayerPrefs.GetFloat("MusicVolume"));
                    SoundManager.Instance.MusicVolume();
                }
                else
                {
                    PlayerPrefs.SetFloat("MusicVolume", 1f);
                    Debug.Log(PlayerPrefs.GetFloat("MusicVolume"));
                    SoundManager.Instance.MusicVolume();
                }
                SetSprites();
            });
        }

        if (soundButton != null)
        {
            soundButton.onClick.RemoveAllListeners();
            soundButton.onClick.AddListener(() =>
            {
                if (PlayerPrefs.GetFloat("SoundVolume") == 1f)
                {
                    PlayerPrefs.SetFloat("SoundVolume", 0f);
                }
                else
                {
                    PlayerPrefs.SetFloat("SoundVolume", 1f);
                }
                SetSprites();
            });
        }
    }

    private void SetSprites()
    {
        if (PlayerPrefs.GetFloat("SoundVolume") == 0f)
        {
            soundButton.GetComponent<Image>().sprite = soundOffSprite;
        }
        else if (PlayerPrefs.GetFloat("SoundVolume") == 1f)
        {
            soundButton.GetComponent<Image>().sprite = soundOnSprite;
        }

        if (PlayerPrefs.GetFloat("MusicVolume") == 0f)
        {
            musicButton.GetComponent<Image>().sprite = musicOffSprite;
        }
        else if (PlayerPrefs.GetFloat("MusicVolume") == 1f)
        {
            musicButton.GetComponent<Image>().sprite = musicOnSprite;
        }
    }

    private void SetVolume()
    {
        if (!PlayerPrefs.HasKey("SoundVolume"))
        {
            PlayerPrefs.SetFloat("SoundVolume", 1f);
        }
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1f);
        }
    }
}
