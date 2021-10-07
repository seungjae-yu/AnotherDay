using UnityEngine;
using System.Collections;

public class AttackEvent : MonoBehaviour {

    public int mode;

	public void AttackToPlayer()
    {   
        if(mode == 1) { 
        EnemyScript es = transform.parent.GetComponent<EnemyScript>();
        es.AttackPlayer();
        }

        if(mode == 2)
        {
            MiddleBoss mb = transform.parent.GetComponent<MiddleBoss>();
            mb.AttackPlayer();
        }

        if(mode == 3)
        {
            FinalBoss fb = transform.parent.GetComponent<FinalBoss>();
            fb.AttackPlayer();
        }

    }

}
