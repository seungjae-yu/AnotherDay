using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{

    public AudioClip[] footSound = null;
    public AudioClip doorOpen = null;
    public AudioClip doorClose = null;
    public AudioClip scroll = null;
    public AudioClip button = null;
    public AudioClip medicalBox = null;
    public AudioClip closing = null;//문강제로 닫게하고 맵삭제하기
    public AudioClip reload = null;
    public AudioClip[] attacked = null;
    public AudioClip zombie = null;
    public AudioClip zombie_oh = null;


    public AudioSource audioSource_foot;
    public AudioSource audioSource_effect;
    public AudioSource audioSource_attack;
    public AudioSource audioSource_zombie;

    public static AudioManager instance { get; private set; }

    int num = 0;
    bool ok_foot = true;
    bool ok_close = true;
    // Use this for initialization
    void Start()
    {

        if (instance == null)
            instance = this;

    }
    IEnumerator OHProcess()
    {
        audioSource_attack.clip = zombie_oh;
        audioSource_attack.Play();
        yield return new WaitForEndOfFrame();
    }
    IEnumerator AttackProcess()
    {
        audioSource_attack.clip = attacked[Random.Range(0, 3)];
        audioSource_attack.Play();
        yield return new WaitForEndOfFrame();
    }
    IEnumerator ZombieProcess()
    {
        audioSource_zombie.clip = zombie;
        audioSource_zombie.Play();
        yield return new WaitForEndOfFrame();
    }
    IEnumerator ReloadProcess()
    {
        audioSource_effect.clip = reload;
        audioSource_effect.Play();
        yield return new WaitForEndOfFrame();
    }

    IEnumerator ClosingProcess()
    {
        audioSource_effect.clip = closing;
        audioSource_effect.Play();
        yield return new WaitForEndOfFrame();
    }

    IEnumerator MedicalBoxProcess()
    {
        audioSource_effect.clip = medicalBox;
        audioSource_effect.Play();
        yield return new WaitForEndOfFrame();
    }
    IEnumerator ButtonProcess()
    {
        audioSource_effect.clip = button;
        audioSource_effect.Play();
        yield return new WaitForEndOfFrame();
    }

    IEnumerator ScrollProcess()
    {

        audioSource_effect.clip = scroll;
        audioSource_effect.Play();
        yield return new WaitForEndOfFrame();
    }

    IEnumerator DoorOpenProcess()
    {

        audioSource_effect.clip = doorOpen;
        audioSource_effect.Play();
        yield return new WaitForEndOfFrame();
    }

    IEnumerator DoorLockProcess()
    {

        if (ok_close)
        {
            ok_close = false;

            audioSource_effect.clip = doorClose;
            audioSource_effect.Play();

            ok_close = true;
        }
        yield return new WaitForEndOfFrame();

    }


    IEnumerator FootStepProcess()
    {
        if (ok_foot)
        {
            ok_foot = false;

            num %= 2;
            audioSource_foot.clip = footSound[num];
            audioSource_foot.Play();

            num++;
            yield return new WaitForSeconds(Random.Range(0.55f, 0.65f));

            ok_foot = true;
        }
        yield return new WaitForEndOfFrame();

    }
    public void FootStep()
    {
        if (ok_foot)
            StartCoroutine(FootStepProcess());
    }
    public void OpenDoor()
    {
        StartCoroutine(DoorOpenProcess());
    }
    public void CloseDoor()
    {
        if (ok_close)
            StartCoroutine(DoorLockProcess());
    }
    public void Scroll()
    {
        StartCoroutine(ScrollProcess());
    }
    public void Button()
    {
        StartCoroutine(ButtonProcess());
    }
    public void MedicalBox()
    {
        StartCoroutine(MedicalBoxProcess());
    }
    public void ClosingDoor()
    {
        StartCoroutine(ClosingProcess());
    }
    public void Reloading()
    {
        StartCoroutine(ReloadProcess());
    }
    public void Attacked()
    {
        StartCoroutine(AttackProcess());
    }
    public void Zombie()
    {
        StartCoroutine(ZombieProcess());
    }
    public void OH()
    {
        StartCoroutine(OHProcess());
    }
}