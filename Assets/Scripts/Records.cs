using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Records : MonoBehaviour {

    public Text recordName;
    public Text recordScore;

    void Start () {
        recordName.text = "1. " + PlayerPrefs.GetString ("Name1") + "\n" +
                        "2. " + PlayerPrefs.GetString ("Name2") + "\n" +
                        "3. " + PlayerPrefs.GetString ("Name3");

        recordScore.text = PlayerPrefs.GetInt ("Score1").ToString () + "\n" +
                        PlayerPrefs.GetInt ("Score2").ToString () + "\n" +
                        PlayerPrefs.GetInt ("Score3").ToString ();

    }

    public void OnClickStart () {
        SceneManager.LoadScene (0);
    }
}