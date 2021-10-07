using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour
{

    public bool activ = false;

    public enum ENEMYSTATE
    {
        NONE = -1,
        IDLE = 0,
        MOVE,
        ATTACK,
        DAMAGE,
        DEAD
    }

    public ENEMYSTATE enemyState;
    Dictionary<ENEMYSTATE, System.Action> dicState = new Dictionary<ENEMYSTATE, System.Action>();
    public CharacterController characterController;
    public Animation anim;

    public float moveSpeed = 5.0f;
    public float rotationSpeed = 10.0f;
    public float attackRange = 2.5f;
    float stateTime = 0.0f;

    public float idleStateMaxTime = 0.01f;
    int healthPoint = 3;
    PlayerState playerState = null;

    UnityEngine.AI.NavMeshAgent zombie2;
    CapsuleCollider zombie;


    #region basic Function
    void Awake()
    {
        InitZombie();

        dicState[ENEMYSTATE.NONE] = None;
        dicState[ENEMYSTATE.IDLE] = Idle;
        dicState[ENEMYSTATE.MOVE] = Move;
        dicState[ENEMYSTATE.ATTACK] = Attack;
        dicState[ENEMYSTATE.DAMAGE] = Damage;
        dicState[ENEMYSTATE.DEAD] = Dead;
    }

    Transform target = null;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        playerState = target.GetComponent<PlayerState>();
        zombie = GetComponent<CapsuleCollider>();
        zombie2 = GetComponent<UnityEngine.AI.NavMeshAgent>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        dicState[enemyState]();
    }

    #endregion

    #region State Function

    void None()
    {
        //do nothing
    }

    void Idle()
    {
        stateTime += Time.deltaTime;
        if (stateTime > idleStateMaxTime)
        {
            stateTime = 0.0f;
            enemyState = ENEMYSTATE.MOVE;
        }
    }

    void DIdle()
    {
        enemyState = ENEMYSTATE.MOVE;
    }

    void Move()
    {
        anim["Walk"].speed = 1.2f;
        anim.CrossFade("Walk");

        float distance = (target.position - transform.position).magnitude;

        if (distance < attackRange)
        {
            enemyState = ENEMYSTATE.ATTACK;
            stateTime = attackStateMaxTime;
        }

        else
        {
            Rotate(rotationSpeed);
        }
    }

    public float attackStateMaxTime = 2.0f;

    void Attack()
    {

        Rotate(100.0f);

        stateTime += Time.deltaTime;
        if (stateTime > attackStateMaxTime)
        {
            stateTime = 0.0f;
            anim.Play("Attack" + Random.Range(1, 4));
            AudioManager.instance.Zombie();
            anim.PlayQueued("Idle", QueueMode.CompleteOthers);
            enemyState = ENEMYSTATE.IDLE;
        }
    }

    void Damage()
    {

        if (healthPoint <= 0) return;

        if (PlayerState.weaponType == 1)
            healthPoint = healthPoint - 2;

        if (PlayerState.weaponType == 2)
            healthPoint = healthPoint - 4;

        if (PlayerState.weaponType == 3)
            healthPoint--;

        anim["Damage"].speed = 2.0f;
        anim.Play("Damage");
        AudioManager.instance.OH();

        DIdle();
        //enemyState = ENEMYSTATE.IDLE;

        if (healthPoint <= 0)
        {
            enemyState = ENEMYSTATE.DEAD;
        }


    }

    void Dead()
    {
        //anim.Play("die");
        StartCoroutine(DeadProcess());
        enemyState = ENEMYSTATE.NONE;
        zombie.enabled = false;
        activ = false;

    }

    public GameObject explosionParticle = null;
    public GameObject deadObject = null;

    IEnumerator DeadProcess()
    {
        anim["Dead"].speed = 2.0f;
        anim.Play("Dead");

        while (anim.isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }
        ZombieManager.instance.DeadZombie();
        yield return new WaitForSeconds(1.0f);
        Destroy(zombie);
        characterController.enabled = false;
        Destroy(zombie2);

    }

    #endregion

    #region func

    void InitZombie()
    {
        enemyState = ENEMYSTATE.NONE;

        anim["Idle"].speed = 1.5f;
        anim.Play("Idle");
    }

    public void AttackPlayer()
    {
        playerState.DamagedByEnemy();
    }

    void OnCollisionEnter(Collision other)
    {
        if (enemyState == ENEMYSTATE.NONE ||
            enemyState == ENEMYSTATE.DEAD)
            return;
    }

    public void ActiveDamage()
    {
        enemyState = ENEMYSTATE.ATTACK;
    }


    void Rotate(float t)
    {
        Vector3 dir = target.position - transform.position;
        dir.y = 0.0f;
        dir.Normalize();
        characterController.SimpleMove(dir * moveSpeed);

        transform.rotation = Quaternion.Lerp(transform.rotation,
                                             Quaternion.LookRotation(dir),
                                             t * Time.deltaTime);
    }


    #endregion
}