using UnityEngine;
using System.Collections;

public class RotateKey : MonoBehaviour
{
    public FinalBoss fb;
    int a=0;
    bool b=true;
    bool ok = true;
    float deltaTime;

    public AudioClip key;
    public AudioSource source;
    void Start()
    {
        deltaTime = 0;
        gameObject.transform.position = Vector3.one * 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (fb.activ)
        {
            if (b)
            {
                b = false;
                a++;
            }
            return;
        }

        if (a > 0) {
            deltaTime += Time.deltaTime;
            Vector3 pos = new Vector3(61.428f, 49.9f, -282.389f);
            gameObject.transform.position = pos;
            StartCoroutine(RotationProcess());

        }
    }
    IEnumerator RotationProcess()
    {
        if (ok)
        {
            
            ok = false;
            transform.Rotate(0, deltaTime*0.5f, 0);
            yield return new WaitForEndOfFrame();


            yield return new WaitForSeconds(0.1f);
            ok = true;
        }
    }
    void OnTriggerEnter()
    {
        source.clip = key;
        source.Play();
        LoadEnding.instance.LoadEnd();
        LoadEnding.instance.changeScene = true;
    }

}
