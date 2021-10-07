using UnityEngine;
using System.Collections;

public class ZombieZeroDoor : MonoBehaviour {

    public Collider doorTrigger;

    void Start()
    {
      
        doorTrigger.isTrigger = false;
    }

    void Update()
    {
        if(ZombieManager.instance.NumofZombie())
        {
           
            doorTrigger.isTrigger = true;
        }
        else
            doorTrigger.isTrigger = false;
    }


    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            AudioManager.instance.OpenDoor();
        }
    }
}
