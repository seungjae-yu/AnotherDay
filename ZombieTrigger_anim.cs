using UnityEngine;
using System.Collections;

public class ZombieTrigger_anim : MonoBehaviour
{

    public Animation ing;//여기에 넣으세요.그 yesRoom의 애니메이션을
    bool once = true;

    public EnemyScript[] normalZombie;
    public MiddleBoss middleBoss;
    public FinalBoss finalBoss;
    public bool mode_n;
    public bool mode_m;
    public bool mode_f;
   


    void Update()
    {
        if (ing.isPlaying && once)
        {
            ZombieManager.instance.ZombieNumber(normalZombie.Length);

            once = false; //한번만 작동하게하는 장치

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
            
        }
    }
}
