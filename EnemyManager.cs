using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public GameObject enemy;
    public float spawnTime = 2.0f;
    float delateSpawnTime = 0.0f;
    public int enemyCnt = 1;

    //
    //Memory pool
    GameObject[] enemyPool = null;
    int poolSize = 10;

    void Start()
    {
        enemyPool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            enemyPool[i] = Instantiate(enemy) as GameObject;
            enemyPool[i].name = "Enemy_" + i;
            enemyPool[i].SetActive(false);
        }
    }

    //

    void Update()
    {
        if (enemyCnt >= 5) return;

        delateSpawnTime += Time.deltaTime;

        if (delateSpawnTime > spawnTime)
        {
            delateSpawnTime = 0.0f;

            //GameObject enemyObj = Instantiate(enemy) as GameObject;

            for (int i = 0; i < poolSize; i++)
            {
                //enemyCnt++;
                GameObject enemyObj = enemyPool[i];

                if (enemyObj.activeSelf == true)
                    continue;

                enemyObj.SetActive(true);
                //
                float x = Random.Range(-20.0f, 20.0f);
                enemyObj.transform.position = new Vector3(x, 1.5f, 20.0f);               
                break;
                           
            }
        }
    }



}
