using UnityEngine;
using System.Collections;

public class EnemyCollider : MonoBehaviour
{
    public EnemyScript enemyScript;
    
    void Awake()
    {
        enemyScript = GetComponentInParent<EnemyScript>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (enemyScript.enemyState == EnemyScript.ENEMYSTATE.NONE ||
           enemyScript.enemyState == EnemyScript.ENEMYSTATE.DEAD)
            return;

        //Debug.Log(other.gameObject.name + " in Child");
        if (other.gameObject.layer != LayerMask.NameToLayer("Bomb"))
            return;

        enemyScript.enemyState = EnemyScript.ENEMYSTATE.DAMAGE;
    }
}
