using UnityEngine;
using System.Collections;

public class ClosingDoorTrigger : MonoBehaviour {

    public ClosingDoor CD;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GetComponent<Collider>().enabled = false;
            CD.doorback = true;
        }
    }
}
