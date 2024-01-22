using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    [SerializeField] private AudioSource _effectSource;

    public void PlaySound(AudioClip clip)
    {
        if (PlayerPrefs.GetFloat("SoundVolume") == 0)
        {
            return;
        }
        else
        {
            _effectSource.PlayOneShot(clip);
        }
    }

    [SerializeField] private AudioSource _musicSource;

    private void Start()
    {
        MusicVolume();
    }

    public void MusicVolume()
    {
        if (PlayerPrefs.GetFloat("MusicVolume") == 0)
        {
            _musicSource.mute = true;
        }
        else
        {
            _musicSource.mute = false;
        }
    }
}
