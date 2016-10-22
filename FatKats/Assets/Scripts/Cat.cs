using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {
    public InputManager inputManager;

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag.Equals("Plataforma")) {
            inputManager.CatInPlatform(gameObject.name);
        }
    }

    void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.tag.Equals("Plataforma")) {
            inputManager.CatOutOfPlatform(gameObject.name);
        }
    }
}
