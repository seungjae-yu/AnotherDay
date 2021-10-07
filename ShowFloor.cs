using UnityEngine;
using System.Collections;
using UnityEngine.UI;//For canvasScaler

public class ShowFloor : MonoBehaviour {

    public CanvasScaler floor;
    bool once = true;

    //public CharacterController ch;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player")&&once)
        {
            StartCoroutine(changeCanvasProcess());
            once = false;
        }
       

    }

    IEnumerator changeCanvasProcess()
    {


      
        //if(floor.transform.position.z - ch.transform.position.z>0)
        //floor.transform.rotation.y = c.transform.rotation.y - 90;

        float sec = 1.0f;
        float deltaTime = 0.0f;

        while (floor.dynamicPixelsPerUnit < 25)
        {
            deltaTime += Time.deltaTime;

            floor.dynamicPixelsPerUnit =
                Mathf.Lerp(0, 25, deltaTime / sec);//4에서 0 만들기를 2초 걸리게하겠당
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(0.5f);
        deltaTime = 0.0f;

        while (floor.dynamicPixelsPerUnit > 0)
        {
            deltaTime += Time.deltaTime;

            floor.dynamicPixelsPerUnit =
                Mathf.Lerp(25, 0, deltaTime / sec);//4에서 0 만들기를 2초 걸리게하겠당
            yield return new WaitForEndOfFrame();
        }
    }
}
