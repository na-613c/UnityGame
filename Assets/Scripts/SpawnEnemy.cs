using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public Transform spawnPos;
    public GameObject enemy;
    private int counterTime = 80;
    private Vector2 enemyVector;
    private RunEnemy[] ObjectPool = new RunEnemy[6];
    private int counterEnemy = 0;

    void Start () {
        for (int i = 0; i < ObjectPool.Length; i++) {
            ObjectPool[i] = Instantiate (enemy, spawnPos).GetComponent<RunEnemy> ();
        }
    }

    void FixedUpdate () {

        if (counterTime == 130) {
            counterTime = 0;
            ObjectPool[counterEnemy].StartMotion ();

            counterEnemy = counterEnemy == ObjectPool.Length - 1 ? 0 : counterEnemy + 1;
        }
        counterTime++;

    }

}