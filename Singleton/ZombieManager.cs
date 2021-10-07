using UnityEngine;
using System.Collections;

public class ZombieManager : MonoBehaviour {

    int zombieNum = 0;
    bool open = false;
    public bool mid = true;//중간좀비 복도들어갈때 false되어 모든 문 잠기게함
    public bool midKill = false;//중간좀비 잡았을때 true로 바뀜
    public static ZombieManager instance { get; private set; }
    void Start () {
        if (instance == null)
            instance = this;
	}
	
    void Update()
    {
        if (zombieNum == 0)
        {
            if (mid == false&&midKill)
            {
                F9Show.instance.SetAppear();
                mid = true;
            }
                

            open = true;
        }
        else
            open = false;
    }

    public void ZombieNumber(int num)
    {
        zombieNum += num;
        Debug.LogWarning("좀비 마리수" + zombieNum);
    }
    public void DeadZombie()
    {
        zombieNum--;
        Debug.Log("좀비한마리 죽었다"+ zombieNum);
    }

    public bool NumofZombie()
    {
        if (mid)
            return open;
        else
            return false;
    }

}
