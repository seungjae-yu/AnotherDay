using UnityEngine;
using System.Collections;

public class KeyTrigger : MonoBehaviour {
    public static KeyTrigger instance { get; private set; }
    bool once = true;

    public Collider keyTrigger;
    public GameObject keyParticle;

    float origin_z;
    void Start()
    {
        if (instance == null)
            instance = this;
        keyTrigger.isTrigger = false;
        origin_z = keyParticle.transform.position.z;
        keyParticle.transform.position = new Vector3(keyParticle.transform.position.x,
            keyParticle.transform.position.y,60.0f);
        
    }

    public void AfterReadScroll()
    {
        keyParticle.transform.position = new Vector3(keyParticle.transform.position.x,
            keyParticle.transform.position.y, origin_z);
        keyTrigger.isTrigger = true;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")&& once)
        {
            once = false;
            ControlTrigger.instance.OpenDoor();

            StartCoroutine(RemoveKeyProcess());
        }
    }

    IEnumerator RemoveKeyProcess()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        yield return new WaitForEndOfFrame();
    }
}
