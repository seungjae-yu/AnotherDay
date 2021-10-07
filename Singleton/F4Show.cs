using UnityEngine;
using System.Collections;

public class F4Show : MonoBehaviour {

    public static F4Show instance { get; private set; }
    public GameObject obj;
    // Use this for initialization
    void Start()
    {
        if (instance == null)
            instance = this;
    }

    public void SetAppear()
    {
        obj.SetActive(true);
    }
    public void SetDisapper()
    {
        obj.SetActive(false);
    }
    public void SetDestroy()
    {
        Destroy(obj);
    }
}
