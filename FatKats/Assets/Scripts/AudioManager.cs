using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
    private static AudioSource normalMiau;

    void Start() {
        AudioSource[] sources = GetComponents<AudioSource>();
        normalMiau = sources[0];
    }

	public static void PlayNormalMiau() {
        normalMiau.Play();
    }
}
