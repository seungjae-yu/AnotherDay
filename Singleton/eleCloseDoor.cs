using UnityEngine;
using System.Collections;

public class eleCloseDoor : MonoBehaviour {

    public static eleCloseDoor instance { get; private set; }

    public GameObject ele = null;
    Collider button = null;

    bool InRoom = false;
    
    float origin_z;
    void Start()
    {
        if (instance == null)
            instance = this;

        button = GetComponent<Collider>();
        button.isTrigger = false;

        origin_z = gameObject.transform.position.z;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y, 60.0f);
    }
    public void INRoom()
    {
        InRoom = true;
         Debug.LogWarning("나는 방에 들어왔다");
    }


    void Update()
    {
        if (InRoom)
        {
            if (ZombieManager.instance.NumofZombie())
            {
                button.isTrigger = true;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x,
               gameObject.transform.position.y, origin_z);
            }
            else
            {
                button.isTrigger = false;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                    gameObject.transform.position.y, 60.0f);
            }

        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            AudioManager.instance.OpenDoor();
            button.enabled = false;

            Destroy(ele);
            gameObject.SetActive(false);
        }
    }
}
