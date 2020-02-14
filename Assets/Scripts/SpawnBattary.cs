using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBattary : MonoBehaviour {
    public Transform spawnPos;
    public GameObject battary;
    public GameObject heart;
    public GameObject bomb;
    private int counter = 0;
    private Vector2 newVector;

    void Start () {
        GenerateBattary ();
    }

    void FixedUpdate () {
        counter++;

        if ((counter % 20) == 0) GenerateBattary ();
        if ((counter % 600) == 0) GenerateHealth ();
        if ((counter % 400) == 0) GenerateBomb ();
        if ((counter % 2400) == 0) counter = 0;

    }

    private void GenerateBattary () {
        GenerteNewVector ();
        Instantiate (battary, newVector, Quaternion.identity);
    }

    private void GenerateHealth () {
        GenerteNewVector ();
        Instantiate (heart, newVector, Quaternion.identity);
    }

    private void GenerateBomb () {
        GenerteNewVector ();
        Instantiate (bomb, newVector, Quaternion.identity);
    }

    private void GenerteNewVector () {
        newVector = new Vector2 (spawnPos.position.x + Random.Range (-34f, 17f), spawnPos.position.y);
    }
}