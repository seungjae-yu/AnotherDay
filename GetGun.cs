using UnityEngine;
using System.Collections;

public class GetGun : MonoBehaviour
{
    public int weaponType;
   
    //AK == 1 , ShotGun == 2 , Pistol == 3

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
            return;

        if (weaponType == 1)
        {
            WeaponManager.nAk = 20;
        }

        if (weaponType == 2)
        {
            WeaponManager.nShotGun = 10;
        }
        AudioManager.instance.Reloading();

        Destroy(gameObject);
    }
}
