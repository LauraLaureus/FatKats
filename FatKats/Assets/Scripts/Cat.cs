using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {
    public InputManager inputManager;
    public PhysicsMaterial2D catPhysicMaterial;

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

    public void Playing(float time) {
        if (gameObject.name.Equals("Luffy")) {
            inputManager.luffyLocked = true;
        } else {
            inputManager.pastelitoLocked = true;
        }
        Invoke("StopPlaying", time);
    }

    public void StartDash(float dashTime) {
        gameObject.layer = 0;
        GetComponent<CircleCollider2D>().sharedMaterial = catPhysicMaterial;
        Invoke("StopDash",dashTime);
    }

    void StopDash() {
        gameObject.layer = 8;
        GetComponent<CircleCollider2D>().sharedMaterial = null;
        inputManager.StopDash(gameObject.name);
    }

    void StopPlaying() {
        if (gameObject.name.Equals("Luffy")) {
            inputManager.luffyLocked = false;
        } else {
            inputManager.pastelitoLocked = false;
        }
    }
}