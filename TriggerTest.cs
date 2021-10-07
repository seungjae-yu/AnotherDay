using UnityEngine;
using System.Collections;

public class TriggerTest : MonoBehaviour
{
    public EnemyScript[] normalZombie;
    public MiddleBoss middleBoss;
    public FinalBoss finalBoss;
    public int mode;
    public bool chk;

    void Start()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        //if (other.transform.tag == "Player")
        //    for (int i = 0; i < normalZombie.Length; i++)
        //        normalZombie[i].SetActive(true);

        

        if (other.transform.tag == "Player")
        {
            if (mode == 1)
            {

                for (int i = 0; i < normalZombie.Length; i++)
                {
                    normalZombie[i].activ = true;
                    normalZombie[i].enemyState = EnemyScript.ENEMYSTATE.MOVE;
                }
            }

            else if (mode == 2)
            {
                middleBoss.activ = true;
                middleBoss.enemyState = MiddleBoss.ENEMYSTATE.MOVE;
            }

            else if (mode == 3)
            {
                finalBoss.activ = true;
                finalBoss.enemyState = FinalBoss.ENEMYSTATE.MOVE;
            }

            else
            {
                for (int i = 0; i < normalZombie.Length; i++)
                {
                    normalZombie[i].activ = true;
                    normalZombie[i].enemyState = EnemyScript.ENEMYSTATE.MOVE;
                }
                middleBoss.activ = true;
                middleBoss.enemyState = MiddleBoss.ENEMYSTATE.MOVE;
                finalBoss.activ = true;
                finalBoss.enemyState = FinalBoss.ENEMYSTATE.MOVE;
            }
        }

    }
}