using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float horizontalSpeed;
    public float verticalImpulse;
    public GameObject jumpBtn;
    private Rigidbody2D rb;
    private float speedX = 0f;
    private int time = 0;
    private bool faseLeft = true;
    private bool timeToJump = true;

    void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }

    void Update () {
        time++;
        if (time > 50) timeToJump = true;

        transform.Translate (speedX, 0, 0);
    }

    void flip () {
        faseLeft = !faseLeft;
        transform.localScale = new Vector3 (transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
    }

    public void leftBtnDown () {
        speedX = -horizontalSpeed;

        if (!faseLeft) flip ();
    }

    public void rightBtnDown () {
        speedX = horizontalSpeed;

        if (faseLeft) flip ();
    }

    public void stop () {
        speedX = 0;
    }

    public void jump () {
        if (timeToJump) {
            jumpBtn.GetComponent<AudioSource> ().Play ();
            rb.AddForce (new Vector2 (0, verticalImpulse), ForceMode2D.Impulse);
            time = 0;
            timeToJump = false;
        }

    }

}