using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

    public GameObject Ak;
    public GameObject ShotGun;
    public GameObject Pistol;

    public static int nAk;
    public static int nShotGun;
    public static int nPistol;

    void Start()
    {
        nAk = 0;
        nShotGun = 1000;
        nPistol = 210000000;
    }

    public ArrayList weaponList = new ArrayList();
    
    void Update()
    {        
        if (Input.GetButtonDown("Jump"))
        {
            ChangeWeapon((PlayerState.weaponType % 3 + 1));
        }
    }

    void ChangeWeapon(int type)
    {
        if (type == 1)
        {
            Ak.SetActive(true);
            ShotGun.SetActive(false);
            Pistol.SetActive(false);
            PlayerState.weaponType = 1;
        }

        else if (type == 2)
        {
            Ak.SetActive(false);
            ShotGun.SetActive(true);
            Pistol.SetActive(false);
            PlayerState.weaponType = 2;
        }

        else if (type == 3)
        {
            Ak.SetActive(false);
            ShotGun.SetActive(false);
            Pistol.SetActive(true);
            PlayerState.weaponType = 3;
        }
    }

}
