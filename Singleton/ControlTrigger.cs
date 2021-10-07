using UnityEngine;
using System.Collections;

public class ControlTrigger : MonoBehaviour {

    public static ControlTrigger instance { get; private set; }
    // Update is called once per frame
    public Collider doorTrigger;
    
    void Start()
    {
        if (instance == null)
            instance = this;
        doorTrigger.isTrigger = false;
    }

    public void OpenDoor()
    {
        AudioManager.instance.OpenDoor();
        doorTrigger.isTrigger = true;    
    }

    void OnCollisionEnter(Collision other)
    {
        //Debug.Log(other.transform.name.ToString());
        //Debug.Log(other.transform.gameObject.layer.ToString());

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            AudioManager.instance.CloseDoor();
        }
    }
    
}
