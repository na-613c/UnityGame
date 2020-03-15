using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerWork : MonoBehaviour {

    public Text scoreText;
    public Text animationText;
    public GameObject game_over;
    public GameObject lowHP;
    public GameObject respawn;
    public GameObject playerObj;
    public GameObject hp2;
    public GameObject hp3;
    private SpriteRenderer playerSprite;
    private SpriteRenderer lowHPSprite, hpSprite2, hpSprite3, game_overSprite;
    private bool timeForDeath = true;
    private int counterHP = 3;
    private int timeCounter, tmpScore, tmpTime, score = 0;
    private Color display, no_display;

    void Start () {
        display = new Color (1, 1, 1, 1.0f);
        no_display = new Color (0, 0, 0, 0);
        game_overSprite = game_over.GetComponent<SpriteRenderer> ();
        playerSprite = playerObj.GetComponent<SpriteRenderer> ();
        lowHPSprite = lowHP.GetComponent<SpriteRenderer> ();
        hpSprite2 = hp2.GetComponent<SpriteRenderer> ();
        hpSprite3 = hp3.GetComponent<SpriteRenderer> ();
    }

    void Update () {
        switch (counterHP) {
            case 3:
                lowHPSprite.color = no_display;
                break;
            case 2:
                lowHPSprite.color = new Color (0, 0, 0, Mathf.PingPong (Time.time / 5, 0.2f));
                break;
            case 1:
                lowHPSprite.color = new Color (0, 0, 0, Mathf.PingPong (Time.time / 5, 0.8f));
                break;
        }

        if (!timeForDeath) {
            playerSprite.color = new Color (1, 1, 1, Mathf.PingPong (Time.time * 10, 1.0f));
        } else {
            playerSprite.color = display;
        }

        switch (tmpTime) {
            case 1:
                animationText.color = new Color (0.08737493f, 1.0f, 0, 1.0f);
                break;
            case 70:
                animationText.color = new Color (0.08737493f, 1.0f, 0, 1.0f / Time.time);
                break;
            case 100:
                animationText.text = "";
                tmpScore = 0;
                break;
        }
    }

    void FixedUpdate () {

        timeCounter++;
        tmpTime++;

        if (timeCounter == 200) timeForDeath = true;

        if (timeCounter == 2000) timeCounter = 101;
        if (tmpTime == 2000) tmpTime = 201;

    }

    public void OnTriggerEnter2D (Collider2D other) {
        switch (other.tag) {
            case "Enemy":
                playerObj.transform.position = respawn.transform.position;
                other.transform.position = new Vector2 (27f, -20f);
                if (timeForDeath) DealthController ();
                if (counterHP != 0) playerObj.GetComponent<AudioSource> ().Play ();

                break;
            case "Finish":
                playerObj.transform.position = respawn.transform.position;
                DealthController ();
                break;
            case "AddHP":
                Destroy (other.gameObject);
                counterHP = counterHP == 3 ? 3 : counterHP + 1;
                HealthController ();
                break;
            case "Battary":
                score++;
                tmpScore++;

                animationText.text = $"+ {tmpScore}";
                tmpTime = 0;

                if (score == 1) {
                    scoreText.text = $" Собрано {score} батарейка";
                } else if (score > 1 && score < 5) {
                    scoreText.text = $" Собрано {score} батарейки";
                } else {
                    scoreText.text = $" Собрано {score} батареек";
                }

                Destroy (other.gameObject);
                break;

        }

    }

    private void DealthController () {
        timeForDeath = false;
        timeCounter = 0;
        counterHP--;

        HealthController ();
    }

    private void HealthController () {

        switch (counterHP) {
            case 3:
                hpSprite3.color = display;
                hpSprite2.color = display;
                break;
            case 2:
                hpSprite3.color = no_display;
                hpSprite2.color = display;
                break;
            case 1:
                hpSprite2.color = no_display;
                break;
            case 0:
                WriteRecord ();
                playerObj.transform.position = new Vector2 (0, -100);
                game_overSprite.color = display;
                game_over.GetComponent<AudioSource> ().Play ();
                Invoke ("ChangeScene", 2.0f);
                break;
        }
    }

    private void ChangeScene () {
        SceneManager.LoadScene (2);
    }

    private void WriteRecord () {
        int PlayerScoreTMP = score;
        string PlayerNameTMP = PlayerPrefs.GetString ("NameTMP");

        int PlayerScore1 = PlayerPrefs.GetInt ("Score1");
        string PlayerName1 = PlayerPrefs.GetString ("Name1");

        int PlayerScore2 = PlayerPrefs.GetInt ("Score2");
        string PlayerName2 = PlayerPrefs.GetString ("Name2");

        int PlayerScore3 = PlayerPrefs.GetInt ("Score3");

        if (PlayerScoreTMP >= PlayerScore1) {
            PlayerPrefs.SetString ("Name1", PlayerNameTMP);
            PlayerPrefs.SetInt ("Score1", PlayerScoreTMP);

            PlayerPrefs.SetString ("Name2", PlayerName1);
            PlayerPrefs.SetInt ("Score2", PlayerScore1);

            PlayerPrefs.SetString ("Name3", PlayerName2);
            PlayerPrefs.SetInt ("Score3", PlayerScore2);

        } else if (PlayerScoreTMP >= PlayerScore2) {
            PlayerPrefs.SetString ("Name2", PlayerNameTMP);
            PlayerPrefs.SetInt ("Score2", PlayerScoreTMP);

            PlayerPrefs.SetString ("Name3", PlayerName2);
            PlayerPrefs.SetInt ("Score3", PlayerScore2);

        } else if (PlayerScoreTMP >= PlayerScore3) {
            PlayerPrefs.SetString ("Name3", PlayerNameTMP);
            PlayerPrefs.SetInt ("Score3", PlayerScoreTMP);

        }

    }
}