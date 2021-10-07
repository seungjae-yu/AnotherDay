using UnityEngine;
using System.Collections;

public class E_Fade : MonoBehaviour {

    public Material mat;
    Color color;

    public void Start()
    {
        color = mat.color;
        color.a = 1;
        mat.color = color;

        StartCoroutine(FADE());
    }
    IEnumerator FADE()
    {

        float deltaTime = 0.0f;

        while (deltaTime < 1f)
        {
            deltaTime += Time.deltaTime;
            color.a = Mathf.MoveTowards(1.0f, 0f, deltaTime);
            mat.color = color;
            yield return new WaitForEndOfFrame();
        }

        color.a = 0f;
        mat.color = color;

        E_CharacterMove.instance.stop = false;
    }

}
