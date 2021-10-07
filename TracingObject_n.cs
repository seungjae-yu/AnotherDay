using UnityEngine;
using System.Collections;

public class TracingObject_n : MonoBehaviour
{
    public Transform target;
    UnityEngine.AI.NavMeshAgent agent;
    public EnemyScript state;




    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        if (agent == null) return;
        if (state.activ == false) return;

        if (EnemyScript.ENEMYSTATE.MOVE == state.enemyState)
            agent.SetDestination(target.position);

        else
        {
            agent.SetDestination(gameObject.transform.position);
        }
    }
}
