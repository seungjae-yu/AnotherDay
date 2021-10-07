using UnityEngine;
using System.Collections;

public class E_CharacterMove : MonoBehaviour {

    public static E_CharacterMove instance { get; private set; }

    CharacterController characterController = null;
    public GameObject inner = null;
    public GameObject outt = null;
    public float moveSpeed = 1.0f;
    Vector3 C_move;

    public bool stop = true;
    // Use this for initialization
    void Start () {
        if (instance == null)
            instance = this;
        stop = true;
        characterController = GetComponent<CharacterController>();
        C_move = new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y, gameObject.transform.position.z);

    }
	
	// Update is called once per frame
	void Update () {
        if (!stop)
        {
            C_move -= new Vector3(moveSpeed* Time.deltaTime, 0, 0);

            AudioManager.instance.FootStep();
            gameObject.transform.position = C_move;


            if (gameObject.transform.position.x < 83)
                stop = true;
        }
    }

    public void remove()
    {
        Destroy(inner);
    }

    public void appear()
    {
        outt.SetActive(true);

    }

    public void StopPlayer()
    {
        stop = true; //플레이어 정지
    }

    public void StartPlayer()
    {
        stop = false; //플레이어 작동
    }
}
