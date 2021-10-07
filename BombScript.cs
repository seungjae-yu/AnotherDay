using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour
{

    // GameObject explosionParticleForGround;
    //public GameObject explosionParticleForEnemy;
    //on붙으면 이벤트 함수다
    void OnCollisionEnter(Collision other)
    {
        /*
        GameObject explosionParticleObj;


        
        if (other.gameObject.name == "Plane")//이 비교는 contains를 써서 하는게 낫다. //그리고layer랑 tag써라
        {
            explosionParticleObj = Instantiate(explosionParticleForGround) as GameObject;
           // Debug.Log("FOR Ground");
        }

        else
        {
            explosionParticleObj = Instantiate(explosionParticleForEnemy) as GameObject;
           // Debug.Log("FOR WAll");
        }

        explosionParticleObj.transform.position = transform.position;
        */
        Destroy(gameObject);
    }
}