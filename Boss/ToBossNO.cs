using UnityEngine;
using System.Collections;

public class ToBossNO : MonoBehaviour {
 
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            BossNo.instance.No();

        }
    }
}
