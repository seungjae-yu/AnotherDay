using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FinalBoss : MonoBehaviour
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

    public float idleStateMaxTime = 2.0f;
    int healthPoint = 70;
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
        //characterController = GetComponentInChildren<CharacterController>();
        activ = false;
        playerState = target.GetComponent<PlayerState>();
        zombie = GetComponent<CapsuleCollider>();
        zombie2 = GetComponent<UnityEngine.AI.NavMeshAgent>();
        characterController = GetComponent<CharacterController>();
        enemyState = ENEMYSTATE.IDLE;

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

    void Move()
    {
        anim["Run"].speed = 1.5f;
        anim.CrossFade("Run");

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
            anim.PlayQueued("Run", QueueMode.CompleteOthers);
            StartCoroutine(waitForSecond(0.1f));

            enemyState = ENEMYSTATE.IDLE;
            //enemyState = ENEMYSTATE.IDLE;
            //playerState.DamagedByEnemy();
        }
    }

    void Damage()
    {
        if (healthPoint == 0) return;

        if (PlayerState.weaponType == 1)
            healthPoint = healthPoint - 2;

        if (PlayerState.weaponType == 2)
            healthPoint = healthPoint - 4;

        if (PlayerState.weaponType == 3)
            healthPoint--;

        AnimationState animState = anim.PlayQueued("Damage", QueueMode.PlayNow);

        animState.speed = 3.0f;
        StartCoroutine(waitForSecond(0.1f));

        stateTime = 0.0f;
        AudioManager.instance.OH();
        enemyState = ENEMYSTATE.MOVE;

        if (healthPoint <= 0)
        {
            enemyState = ENEMYSTATE.DEAD;
        }
    }

    void Dead()
    {
        //anim.Play("die");
        StartCoroutine(DeadProcess());
        activ = false;
        enemyState = ENEMYSTATE.NONE;

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
        //gameObject.SetActive(false);
        //ZombieManager.instance.DeadZombie();
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

        anim["Shout"].speed = 1.5f;
        anim.Play("Shout");
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

    IEnumerator waitForSecond(float t)
    {
        yield return new WaitForSeconds(t);
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