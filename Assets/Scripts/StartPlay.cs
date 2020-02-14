using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartPlay : MonoBehaviour {
    public InputField field;
    public Text errorName;
    private string playerName = "";

    void Start () {
        field.text = PlayerPrefs.GetString ("NameTMP") + "";
    }

    public void OnClickStart () {
        playerName = field.text.Trim ();
        if (playerName.Length != 0) {
            PlayerPrefs.SetString ("NameTMP", playerName);
            SceneManager.LoadScene (1);
            errorName.text = "";
        } else {
            errorName.text = "Введите имя!";
        }
    }

    public void OnClickRecord () {
        SceneManager.LoadScene (3);
    }
}