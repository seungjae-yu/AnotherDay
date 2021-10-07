using UnityEngine;
using System.Collections;

public class Load : MonoBehaviour {
    string num;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GetComponent<Collider>().enabled = false;
            num = gameObject.layer.ToString();
            Debug.LogWarning("현재위치는 " + num);
            switch (num)
            {
                case "15":
                    F3Show.instance.SetAppear();
                    break;
                case "16":
                    F4Show.instance.SetAppear();
                    F2Show.instance.SetDestroy();
                    break;
                case "17":
                    F5Show.instance.SetAppear();
                    F3Show.instance.SetDestroy();
                    break;
                case "18":
                    F6Show.instance.SetAppear();
                    F4Show.instance.SetDestroy();
                    break;
                case "19":
                    F7Show.instance.SetAppear();
                    F5Show.instance.SetDestroy();
                    break;
                case "20":
                    ZombieManager.instance.mid = false;
                    F8Show.instance.SetAppear();
                    F6Show.instance.SetDestroy();
                    break;
                case "21":
                    F7Show.instance.SetDestroy();
                    F8Show.instance.SetDestroy();
                    break;
                

            }   
        }
    }
}
