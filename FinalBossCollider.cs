using UnityEngine;
using System.Collections;

public class FinalBossCollider : MonoBehaviour
{
    public FinalBoss fbScript;
    
    void Awake()
    {
        fbScript = GetComponentInParent<FinalBoss>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (fbScript.enemyState == FinalBoss.ENEMYSTATE.NONE ||
           fbScript.enemyState == FinalBoss.ENEMYSTATE.DEAD)
            return;

        //Debug.Log(other.gameObject.name + " in Child");
        if (other.gameObject.layer != LayerMask.NameToLayer("Bomb"))
            return;

        fbScript.enemyState = FinalBoss.ENEMYSTATE.DAMAGE;
    }
}
