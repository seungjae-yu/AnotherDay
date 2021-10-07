using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour
{

    public Transform cameraTransform;
    public GameObject fireObject;
    public GameObject ShotgunObject;
    public float forwardPower = 100.0f;
    bool isShooting = false;
    int akCnt = 0;
    public AudioSource audioSource;

    public AudioClip asAk;
    public AudioClip asSG;
    public AudioClip asPistol;

    public Transform firePos;

    public GameObject[] muzzleFlash;

    void Start()
    {
        for (int i = 0; i < muzzleFlash.Length; i++)
        {
            muzzleFlash[i].SetActive(false);
        }
    }

    void Update()
    {
        if (PlayerState.isDead) return;
        if (isShooting) return;
        
        if (PlayerState.isDead) return;

        if (Input.GetButtonDown("Fire1"))
        {

            if (PlayerState.weaponType == 1)
            {
                if (WeaponManager.nAk == 0) return;
                audioSource.PlayOneShot(asAk);
               
            }

            else if (PlayerState.weaponType == 2)
            {
                if (WeaponManager.nShotGun == 0) return;
                audioSource.PlayOneShot(asSG);

            }

            else if (PlayerState.weaponType == 3)
            {
                if (WeaponManager.nPistol == 0) return;
                audioSource.PlayOneShot(asPistol);
               
            }            

            if(PlayerState.weaponType == 1 || PlayerState.weaponType == 3)
            {
                Fire();
            }

            else
            {
                GameObject obj = Instantiate(ShotgunObject) as GameObject;
                obj.transform.position = firePos.position ;                
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                rb.velocity = (cameraTransform.forward * forwardPower);
                StartCoroutine(this.ShowMuzzleFlash());
                StartCoroutine(ShotGunFire(obj));
            }

            if (PlayerState.weaponType == 1)
            {
                WeaponManager.nAk--;
                StartCoroutine(waitTime(0.2f));
            }

            if (PlayerState.weaponType == 2)
            {
                //ShotGun
                WeaponManager.nShotGun--;
                StartCoroutine(waitTime(1.0f));
            }

            if (PlayerState.weaponType == 3)
            {
                //Pistol       
                WeaponManager.nPistol--;
                StartCoroutine(waitTime(0.5f));
            }
        }
    }

    IEnumerator waitTime(float t)
    {
        isShooting = true;
        yield return new WaitForSeconds(t);
        isShooting = false;
        yield return new WaitForEndOfFrame();
    }

    void Fire()
    {
        GameObject obj = Instantiate(fireObject) as GameObject;
        obj.transform.position = firePos.position;//
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.velocity = (cameraTransform.forward * forwardPower);
        StartCoroutine(this.ShowMuzzleFlash());
    }

    IEnumerator ShowMuzzleFlash()
    {
        float scale = 0.0f;
        int type = PlayerState.weaponType - 1;
        if (type == 0)//Rifle
        {
            scale = Random.Range(0.15f, 0.25f);
        }
        else if (type == 1)//ShotGun
        {
            scale = Random.Range(0.4f, 0.5f);
        }
        else//pistol
        {
            scale = Random.Range(0.1f, 0.15f);
        }
        Quaternion rot = Quaternion.Euler(0, 0, Random.Range(0, 360));
        muzzleFlash[type].transform.localScale = Vector3.one * scale;
        muzzleFlash[type].transform.localRotation = rot;
        muzzleFlash[type].SetActive(true);

        float randomTime = Random.Range(0.1f, 0.2f);

        LeanTween.scale(muzzleFlash[type], new Vector3(0.001f, 0.001f, 0.001f), randomTime).setEase(LeanTweenType.easeInOutQuint);
        yield return new WaitForSeconds(randomTime);

        muzzleFlash[type].SetActive(false);

    }

    IEnumerator ShotGunFire(GameObject obj)
    {
        yield return new WaitForSeconds(0.07f);
        Destroy(obj);
    }

}
