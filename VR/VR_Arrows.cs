using UnityEngine;
using System.Collections;

public class VR_Arrows : MonoBehaviour {

    //public Renderer[] arrowRenderers;
    //그리기 위해서 쓰는 것 복사본 생성되므로 그냥 쓰자
    public float fadeSpeed = 10.0f;

    Vector3 baseVector = Vector3.right;
    float currentAlpha = 0.0f;
    float targetAlpha;

    public Material mat;//전체적으로 한꺼번에 제어할때 하는것

    void Update()
    {
        Vector3 camForward = VrCameraManager.instance.transform.forward;
        //
        float angle = Vector3.Angle(camForward, baseVector);

        //Debug. Log("각은 : " + angle);

        //90기본 10좌 170후


        if (angle < 60)
            targetAlpha = 0.0f;
        else
            targetAlpha = 1.0f;
        currentAlpha = Mathf.MoveTowards(currentAlpha, targetAlpha,
                                                    fadeSpeed * Time.deltaTime);
        //Mathf.Learp()와 동작하는것이 같다. (from, to , percent)인것인데 percent계산시에 약간 다름

        //for( int i =0; i<arrowRenderers.Length; i++)
        //{
        //    arrowRenderers[i].material.SetFloat("_Alpha", currentAlpha);
        //}이런식으로 하면 복제를 2개씩해서 drawcall이 늘어나서 최적화가 안좋다.

        mat.SetFloat("_Alpha", currentAlpha);//복사본안만드는 코드
    }


}
