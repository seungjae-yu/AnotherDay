using UnityEngine;
using System.Collections;

public class FriendChk : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {

        if (Friend.dialogEnd)
        {
            F2Show.instance.SetAppear();
            Destroy(gameObject);
        }

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
