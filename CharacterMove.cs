using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour
{
    public static CharacterMove instance { get; private set; }

    CharacterController characterController = null;
    public Transform cameraTransform;
    //public Transform editorCameraTransform;
    public float moveSpeed = 5.0f;
    public float jumpSpeed = 5.0f;
    public float gravity = -10.0f;
    float yVelocity = 0.0f;


    bool stop = false;

    void Start()
    {
        if (instance == null)
            instance = this;
        characterController = GetComponent<CharacterController>();        
    }

    public void StopPlayer()
    {
        stop = true; //플레이어 정지
    }

    public void StartPlayer()
    {
        stop = false; //플레이어 작동
    }

    void Update()
    {

        if (PlayerState.isDead) return;
        if (!stop)
        {

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(x, 0, z);

            //cameraTransform.localRotation = UnityEngine.VR.InputTracking.GetLocalRotation(UnityEngine.VR.VRNode.Head);
            moveDirection = cameraTransform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed;



            if (characterController.isGrounded == true)
            {
                yVelocity = 0.0f;

            }

            yVelocity += (gravity * Time.deltaTime);
            moveDirection.y = yVelocity;

            characterController.Move(moveDirection * Time.deltaTime);

            if (x != 0 || z != 0)
            {
                AudioManager.instance.FootStep();

            }

        }
    }

}
