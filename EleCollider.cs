using UnityEngine;
using System.Collections;

public class EleCollider : MonoBehaviour {

    public Collider ele;
    public Animation ing;
    bool once = true;

	void Update () {
        if (ing.isPlaying && once)
        {
            ele.isTrigger = false;
            F1Show.instance.SetDestroy();
        }
	}
}
