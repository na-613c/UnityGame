using UnityEngine;
using UnityEngine.UI;

public class MaxScore : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {
        GetComponent<Text> ().text = "Рекорд : " + PlayerPrefs.GetInt ("Score1").ToString ();
    }

}