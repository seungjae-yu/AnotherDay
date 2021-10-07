using UnityEngine;
using System.Collections;

public class MedicalBox : MonoBehaviour {

    bool once = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && once)
        {
            once = false;
            PlayerState.instance.DrinkPotion();
            AudioManager.instance.MedicalBox();

            StartCoroutine(RemoveBoxProcess());
        }
    }

    IEnumerator RemoveBoxProcess()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        yield return new WaitForEndOfFrame();
    }
}
