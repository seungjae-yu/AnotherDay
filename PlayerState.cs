using UnityEngine;
using System.Collections;

using UnityEngine.UI;
public class PlayerState : MonoBehaviour {

    public static PlayerState instance { get; private set; }
    public GameObject[] blood = null;


    int healthPoint = 50;
    int pre_case =1 ;

    public static int weaponType;
    public GameObject GameOver = null;
    public static bool isDead = false;
    void Start()
    {
        if (instance == null)
            instance = this;

        for(int i = 0; i < 4; i++)
        {
            blood[i].transform.localScale *= 0;
        }
        weaponType = 3;

        GameOver.SetActive(false);
    }
    
    public void DrinkPotion()
    {
        healthPoint += 20;
        if (healthPoint > 50)
            healthPoint = 50;
        Debug.LogWarning("healthPoint :" + healthPoint);
    }

    void Update()
    {
        if (healthPoint < 10)
            return;
        //Debug.Log("health" + healthPoint);
        if(pre_case < 5&& pre_case != 0)
            blood[4-pre_case].transform.localScale *= 0;
        pre_case = healthPoint / 10;

        
        switch (pre_case)
        {
            case 4:
                blood[0].transform.localScale =
                        new Vector3(0.007486752f, 0.008820317f, 0.107688f);
                break;
            case 3:
                //Debug.LogWarning("dd000");
                blood[1].transform.localScale =
                        new Vector3(0.007486752f, 0.008820317f, 0.107688f);
                break;
            case 2:
                blood[2].transform.localScale =
                        new Vector3(0.007486752f, 0.008820317f, 0.107688f);
                break;
            case 1:
            case 0:
                blood[3].transform.localScale =
                        new Vector3(0.007486752f, 0.008820317f, 0.107688f);
                break;
        }
    }
    
    /*void OnGUI()
    {
        float x = (Screen.width / 2.0f) - 100;

        Rect rect = new Rect(x, 10, 200, 25);

        if (isDead == true)
            GUI.Box(rect, "Game Over!");

        else
            GUI.Box(rect, "My Health : " + healthPoint);
    }*/

    public void DamagedByEnemy()
    {
        if (isDead)
            return;

        AudioManager.instance.Attacked();
        --healthPoint;
        // cameraShake.PlayCameraShake();

        if (healthPoint <= 0)
        {
            isDead = true;
            GameOver.SetActive(true);
            StartCoroutine(waitForSec(0.5f));

            Time.timeScale = 0.0f;
        }
    }
    IEnumerator waitForSec(float t)
    {

        yield return new WaitForSeconds(t);

    }

}
