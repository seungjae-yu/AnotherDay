using UnityEngine;
using System.Collections;

public class FloorOneDoor : MonoBehaviour {

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
