using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DieSpace : MonoBehaviour {
    public GameObject respawn;

    void OnTriggerEnter2D (Collider2D other) {

        switch (other.tag) {
            case "Player":
                other.transform.position = respawn.transform.position;
                break;
            case "box":
                Vector3 boxVector = new Vector3 (Random.Range (-33f, 16f), 5.9f, 0f);
                other.transform.Translate (boxVector);
                break;
            case "Battary":
                Destroy (other.gameObject);
                break;
            case "Enemy":
                Destroy (other.gameObject);
                break;

        }

    }
}