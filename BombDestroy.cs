using UnityEngine;
using System.Collections;

public class BombDestroy : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.layer.ToString());
        Destroy(gameObject);
    }

    float stateTime = 0.0f;

    void Update()
    {
        stateTime += Time.deltaTime;
        if (stateTime > 2.0f)
        {
            Destroy(gameObject);
        }
    }

}