using UnityEngine;
using System.Collections;

public class BossNo : MonoBehaviour {

    public static BossNo instance { get; private set; }
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Collider>().enabled = false;
        if (instance == null)
            instance = this;
	}
	public void No()
    {
        gameObject.GetComponent<Collider>().enabled = true;
    }
}
