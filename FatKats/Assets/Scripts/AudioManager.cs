using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {
    private static AudioManager instance;
    private AudioSource button;
    private AudioSource gameMusic;
    private AudioSource menuMusic;
    private AudioSource normalMiau;
    private AudioSource namNam;

    void Awake() {
        // Patrón Singleton
        if (instance == null) {
            instance = this;
        } else if (!instance.Equals(this)) {
            Destroy(gameObject);
        }
        // Referencias a componentes
        AudioSource[] sources = GetComponents<AudioSource>();
        normalMiau = sources[0];
        namNam = sources[1];
        menuMusic = sources[2];
        gameMusic = sources[3];
        button = sources[4];
        SceneManager.activeSceneChanged += ChangeSceneTheme;
    }

    void ChangeSceneTheme(Scene prev, Scene current) {
        switch (current.name) {
            case "Instructions":
                instance.menuMusic.Stop();
                break;
            case "InGame":
                instance.menuMusic.Stop();
                if (!instance.gameMusic.isPlaying) {
                    instance.gameMusic.Play();
                }
                break;
            default:
                if (!instance.menuMusic.isPlaying) {
                    instance.menuMusic.Play();
                }
                break;
        }
    }

    void Start() {
        DontDestroyOnLoad(gameObject);
    }

    public static void PlayButton() {
        instance.button.Play();
    }

    public static void PlayNormalMiau() {
        instance.normalMiau.Play();
    }

    public static void PlayNamNam() {
        instance.namNam.Play();
    }
}
