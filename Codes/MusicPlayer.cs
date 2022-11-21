using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] Musics;
    [SerializeField] AudioSource source;
    [SerializeField] public static Music instance;

    private void Start()
    {
        if (Music.instance == null)
        {
            Music.instance = this;
            PlayNextSong();
        }
        else
        {
            if (Music.instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void PlayNextSong()
    {
        AudioClip audio = Musics[Random.Range(0, Musics.Length)];
        source.PlayOneShot(audio);
        Invoke("PlayNextSong", audio.length);
    }

    public void CancelInvokes()
    {
        CancelInvoke();
    }
}