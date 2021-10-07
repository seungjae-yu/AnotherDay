using UnityEngine;
using System.Collections;

public class MiddleBossCollider : MonoBehaviour
{
    public MiddleBoss mbScript;
    
    void Awake()
    {
        mbScript = GetComponentInParent<MiddleBoss>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (mbScript.enemyState == MiddleBoss.ENEMYSTATE.NONE ||
           mbScript.enemyState == MiddleBoss.ENEMYSTATE.DEAD)
            return;

        //Debug.Log(other.gameObject.name + " in Child");
        if (other.gameObject.layer != LayerMask.NameToLayer("Bomb"))
            return;

        mbScript.enemyState = MiddleBoss.ENEMYSTATE.DAMAGE;
    }
}
