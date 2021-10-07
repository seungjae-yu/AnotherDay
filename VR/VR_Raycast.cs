using UnityEngine;
using System.Collections;

public class VR_Raycast : MonoBehaviour {

	void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = new Ray(Camera.main.transform.position,
                Camera.main.transform.forward);
            RaycastHit hit;
            int includeLayer = 1 << 0;//0번째 레이어
            if(Physics.Raycast (ray, out hit, 100.0f, includeLayer))
            {
                Debug.Log("Hit Object: " + hit.transform.name + "\nHit Pos: "
                    + hit.point);
            }

        }
    }
}
