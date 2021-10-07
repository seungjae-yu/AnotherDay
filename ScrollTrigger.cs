using UnityEngine;
using System.Collections;

public class ScrollTrigger : MonoBehaviour {
    bool once = true;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && once)
        {
            once = false;
            AudioManager.instance.Scroll();

            Scroll.instance.ShowScroll();
            StartCoroutine(RemoveScrollProcess());
        }
    }

    IEnumerator RemoveScrollProcess()
    {

        yield return new WaitForSeconds(0.2f);
        KeyTrigger.instance.AfterReadScroll();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        yield return new WaitForEndOfFrame();
    }
}
