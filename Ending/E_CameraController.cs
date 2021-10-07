using UnityEngine;
using System.Collections;

public class E_CameraController : MonoBehaviour {

    public float sensitivity = 250.0f;
    float rotationX;
    float rotationY;

    bool stop = false;

    //frame마다 1번씩 호출   

    void Update()
    {

        float mouseMoveValueX = Input.GetAxis("Mouse X");
        float mouseMoveValueY = Input.GetAxis("Mouse Y");

        rotationY += mouseMoveValueX * sensitivity * Time.deltaTime;
        rotationX += mouseMoveValueY * sensitivity * Time.deltaTime;

        rotationX %= 360;
        rotationY %= 360;

        rotationX = Mathf.Clamp(rotationX, -80.0f, 80.0f);
        transform.eulerAngles = new Vector3(-rotationX, rotationY - 90, 0.0f);

    }

}
