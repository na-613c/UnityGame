using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunEnemy : MonoBehaviour {

    public float speed;
    public GameObject enemyObj;
    public GameObject enemySpawn;

    private Vector2 enemyVector;
    private bool move = false;

    void Update () {
        if (move) transform.Translate (speed * Time.deltaTime, 0f, 0f);
    }

    public void StartMotion () {
        move = true;
        float rnd = Random.Range (-5f, 5f);
        enemyVector = new Vector2 (enemySpawn.transform.position.x, enemySpawn.transform.position.y + rnd);
        enemyObj.transform.position = enemyVector;

    }

    void OnTriggerEnter2D (Collider2D other) {
        switch (other.tag) {
            case "Battary":
                Destroy (other.gameObject);
                break;
            case "AddHP":
                Destroy (other.gameObject);
                break;
        }

    }
}