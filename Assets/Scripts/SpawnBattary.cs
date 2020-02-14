using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBattary : MonoBehaviour {
    public Transform spawnPos;
    public GameObject battary;
    public GameObject heart;
    public GameObject bomb;
    private int time_counter = 0;
    private Vector2 newVector;

    void Start () {
        GenerateBattary ();
    }

    void FixedUpdate () {
        time_counter++;

        if ((time_counter % 20) == 0) GenerateBattary ();
        if ((time_counter % 600) == 0) GenerateHealth ();
        if ((time_counter % 400) == 0) GenerateBomb ();
        if ((time_counter % 2400) == 0) time_counter = 0;

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