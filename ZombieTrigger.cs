using UnityEngine;
using System.Collections;

public class ZombieTrigger : MonoBehaviour
{
    public EnemyScript[] normalZombie;
    public MiddleBoss middleBoss;
    public FinalBoss finalBoss;
    public bool mode_n;
    public bool mode_m;
    public bool mode_f;

    int num = 0;
    public Collider triger;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            
                
            if (mode_m)
            {
                ZombieManager.instance.mid = false;
                num++;
            }
            if (mode_f)
            {
                num++;
            }
            triger.enabled = false;
            ZombieManager.instance.ZombieNumber(normalZombie.Length + num);

            
            Debug.Log("통과했다 좀비 트리거");

            if (mode_n)
            {
                for (int i = 0; i < normalZombie.Length; i++)
                {
                    normalZombie[i].activ = true;
                    normalZombie[i].enemyState = EnemyScript.ENEMYSTATE.MOVE;
                }
            }

            if (mode_m)
            {
                middleBoss.activ = true;
                middleBoss.enemyState = MiddleBoss.ENEMYSTATE.MOVE;
            }

            if (mode_f)
            {
                finalBoss.activ = true;
                finalBoss.enemyState = FinalBoss.ENEMYSTATE.MOVE;

            }

            if (gameObject.tag == "Elevator")
                eleCloseDoor.instance.INRoom();
        }
    }
}