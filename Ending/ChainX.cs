using UnityEngine;
using System.Collections;

public class ChainX : MonoBehaviour {

    public static ChainX instance { get; private set; }
    // Use this for initializationG
    public GameObject chain = null;
    public GameObject doorLeft = null;
    public GameObject doorRight = null;
    public Collider col = null;

    bool ok = false;
    float right = -24;
    float left = 3.4f;

    public AudioClip opendoor = null;

    public AudioSource door;

    void Start () {
        if (instance == null)
            instance = this;
        door.clip = opendoor;
    }
    void OnTriggerEnter(Collider other)
    {
        E_CharacterMove.instance.stop = true;
        col.enabled = false;

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            AudioManager.instance.OpenDoor();
            chain.SetActive(false);

            ok = true;
            StartCoroutine(ReGoProcess());
        }
    }
    IEnumerator ReGoProcess()
    {
        E_CharacterMove.instance.moveSpeed = 2;
        yield return new WaitForSeconds(0.5f);
        door.Play();
        yield return new WaitForSeconds(2.5f);
        E_CharacterMove.instance.stop = false;
        E_CharacterMove.instance.appear();

        yield return new WaitForSeconds(2f);
        E_CharacterMove.instance.remove();


    }


    void Update()
    {
        if (ok) {
       
            LeanTween.rotateY(doorLeft, left,  3).setEase(LeanTweenType.easeInOutQuart);
            LeanTween.rotateY(doorRight, right, 3).setEase(LeanTweenType.easeInOutQuart);
            ok = false;       
        }
    }
}
