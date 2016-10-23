using UnityEngine;
using System.Collections;

public class WoolEnemy : MonoBehaviour {
    public float playTime = 2.0f;
    public float forceSpeed = 2.0f;
    public float velocityToImpulse = 0.25f;
    private Rigidbody2D rb;

    void Start() {
        // Elección color aleatorio
        Color c = Color.blue;
        switch (Random.Range(0, 7)) {
            case 0:
                c = Color.cyan;
                break;
            case 1:
                c = Color.green;
                break;
            case 2:
                c = Color.grey;
                break;
            case 3:
                c = Color.magenta;
                break;
            case 4:
                c = Color.red;
                break;
            case 5:
                c = Color.yellow;
                break;
        }
        GetComponent<SpriteRenderer>().color = c;
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D (Collision2D coll) {
        if (coll.gameObject.tag.Equals("Player")) {
            // El gato se pone a jugar y se escucha el sonido
            coll.gameObject.GetComponent<Cat>().Playing(playTime);
            AudioManager.PlayNormalMiau();
            Destroy(gameObject);
        }
    }

    void Update() {
        // Si no se mueve, se mueve a un lado
        if (rb.velocity.magnitude < velocityToImpulse) {
            if (Random.Range(0,2) == 0) {
                rb.AddForce(forceSpeed * Vector2.left);
            } else {
                rb.AddForce(forceSpeed * Vector2.right);
            }
        }
        // Animación de movimiento
        transform.Rotate(0, 0, rb.velocity.x);
    }
}