using UnityEngine;
using System.Collections;

public class VR_FadeSample : MonoBehaviour {

    public Material mat;
    Color color;

    public void Start()
    {
        color = mat.color;
        color.a = 0;
        mat.color = color;
    }

    
    public void Fade()
    {
        StartCoroutine(FADE());
        
    } 


     IEnumerator FADE() {

        float deltaTime = 0.0f;

        while (deltaTime < 1.0f)
        {
            deltaTime += Time.deltaTime;
            color.a = Mathf.MoveTowards(0.0f,1.0f, deltaTime);
            mat.color = color;
            yield return new WaitForEndOfFrame();
        }

        color.a = 1.0f;
        mat.color = color;

        LoadGame.changeScene = true;
    }
}
