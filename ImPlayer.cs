using UnityEngine;
using System.Collections;

public class ImPlayer : MonoBehaviour {

    public GameObject parent;
		
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = parent.transform.position;
        gameObject.transform.rotation = parent.transform.rotation;
    }
}
