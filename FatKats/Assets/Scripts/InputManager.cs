using UnityEngine;

public class InputManager : MonoBehaviour {
    public float FUERZA_ELEMENTAL = 12.0f;
    // Referencias a personajes
    public Rigidbody2D luffy;
    public Rigidbody2D pastelito;

    // Variables con movimiento de los personajes
    public bool luffyLocked;
    public bool pastelitoLocked;
    private bool luffyLeft;
    private bool luffyRight;
    private bool luffyJump;
    private bool luffyDash;
    private bool pastelitoLeft;
    private bool pastelitoRight;
    private bool pastelitoJump;
    private bool pastelitoDash;
    public float movementImpulse;
    public float dashImpulse;
    public float dashTime;

    // Variables para saltos personajes
    public float maxJumpImpulse = 2.0f;
    public float initialImpulse = 10.0f;
    private float luffyJumpImpulse;
    private float pastelitoJumpImpulse;
    private bool luffyInPlatform;
    private bool pastelitoInPlatform;

    void Start() {
        Time.timeScale = 1;
        luffyLeft = false;
        luffyRight = false;
        luffyJump = false;
        pastelitoLeft = false;
        pastelitoRight = false;
        pastelitoJump = false;
        luffyInPlatform = false;
        luffyJumpImpulse = 0.0f;
    }

    void FixedUpdate() {
        if (!luffyLocked) {
            MovimientoLuffy();
        }
        if (!pastelitoLocked) {
            MovimientoPastelito();
        }
    }

    // Update is called once per frame
    void Update() {
        // Inputs Luffy
        luffyLeft = (Input.GetKey(KeyCode.A));
        luffyRight = (Input.GetKey(KeyCode.D));
        luffyJump = (Input.GetKey(KeyCode.W));
        if ((Input.GetKeyDown(KeyCode.S)) && (!luffyDash)) {
            luffyDash = true;
            luffy.gameObject.GetComponent<Cat>().StartDash(dashTime);
        }
        // Inputs Pastelito
        pastelitoLeft = (Input.GetKey(KeyCode.LeftArrow));
        pastelitoRight = (Input.GetKey(KeyCode.RightArrow));
        pastelitoJump = (Input.GetKey(KeyCode.UpArrow));
        if ((Input.GetKeyDown(KeyCode.DownArrow)) && (!pastelitoDash)) {
            pastelitoDash = true;
            pastelito.gameObject.GetComponent<Cat>().StartDash(dashTime);
        }
    }

    public void CatInPlatform(string cat) {
        if (cat.Equals("Luffy")) {
            luffyJumpImpulse = 0.0f;
            luffyInPlatform = true;
        } else if (cat.Equals("Pastelito")) {
            pastelitoJumpImpulse = 0.0f;
            pastelitoInPlatform = true;
        }
		// Modificamos animación
		GameObject.Find ("GameScene/" + cat).GetComponent <Animator>().SetBool ("Jump", false);
    }

    public void CatOutOfPlatform(string cat) {
        if (cat.Equals("Luffy")) {
            luffyInPlatform = false;
        } else if (cat.Equals("Pastelito")) {
            pastelitoInPlatform = false;
        }
    }

    void MovimientoLuffy() {
        Vector2 force = new Vector2();
        if (luffyJump) {
			// Modificamos animación
			luffy.GetComponent <Animator>().SetBool ("Jump", true);
            if ((luffyJumpImpulse == 0.0f) && (luffyInPlatform)) {
                force += initialImpulse * Vector2.up;
            } else if ((luffyJumpImpulse < maxJumpImpulse) && (luffy.velocity.y > 0.0f)) {
                force += Vector2.up;
            }
            luffyJumpImpulse += 1.0f;
        }
        float impulse = 1;
        if (luffyDash) {
            impulse = dashImpulse;
        } else if (luffy.velocity.y == 0.0f) {
            impulse = movementImpulse;
        }
        if (luffyLeft) {
			if (luffy.GetComponent <SpriteRenderer> ().flipX) {
				luffy.GetComponent <SpriteRenderer> ().flipX = false;
			}
            force += impulse * Vector2.left;
        } else if (luffyRight) {
			if (!luffy.GetComponent <SpriteRenderer> ().flipX) {
				luffy.GetComponent <SpriteRenderer> ().flipX = true;
			}
            force += impulse * Vector2.right;
        }
        luffy.AddForce(FUERZA_ELEMENTAL * force);
    }

    void MovimientoPastelito() {
        Vector2 force = new Vector2();
        if (pastelitoJump) {
			pastelito.GetComponent <Animator>().SetBool ("Jump", true);
            if ((pastelitoJumpImpulse == 0.0f) && (pastelitoInPlatform)) {
                force += initialImpulse * Vector2.up;
            } else if ((pastelitoJumpImpulse < maxJumpImpulse) && (pastelito.velocity.y > 0.0f)) {
                force += Vector2.up;
            }
            pastelitoJumpImpulse += 1.0f;
        }
        float impulse = 1;
        if (pastelitoDash) {
            impulse = dashImpulse;
        } else if (pastelito.velocity.y == 0.0f) {
            impulse = movementImpulse;
        }
        if (pastelitoLeft) {
            force += impulse * Vector2.left;
			if (pastelito.GetComponent <SpriteRenderer> ().flipX) {
				pastelito.GetComponent <SpriteRenderer> ().flipX = false;
			}
        } else if (pastelitoRight) {
            force += impulse * Vector2.right;
			if (!pastelito.GetComponent <SpriteRenderer> ().flipX) {
				pastelito.GetComponent <SpriteRenderer> ().flipX = true;
			}
        }
        pastelito.AddForce(FUERZA_ELEMENTAL * force);
    }

    public void StopDash(string cat) {
        if (cat.Equals("Luffy")) {
            luffyDash = false;
        } else if (cat.Equals("Pastelito")) {
            pastelitoDash = false;
        }
    }
}
