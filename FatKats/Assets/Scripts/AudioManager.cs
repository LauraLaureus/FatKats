using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
    private static AudioSource normalMiau;
    private static AudioSource namNam;

    void Start() {
        AudioSource[] sources = GetComponents<AudioSource>();
        normalMiau = sources[0];
        namNam = sources[1];
    }

	public static void PlayNormalMiau() {
        normalMiau.Play();
    }

    public static void PlayNamNam() {
        namNam.Play();
    }
}
