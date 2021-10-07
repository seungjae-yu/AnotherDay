using UnityEngine;
using System.Collections;

public class ClosingDoor : MonoBehaviour
{
    public bool doorback = false;

    void Update()
    {

        if (doorback)
        {
            doorback = false;
            transform.Rotate(new Vector3(0, 83, 0));
            AudioManager.instance.ClosingDoor();

        }
    }
}
  

