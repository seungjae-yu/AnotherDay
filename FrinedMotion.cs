using UnityEngine;
using System.Collections;

public class FrinedMotion : MonoBehaviour {

    public static FrinedMotion instance {get; private set;}

    public Animation friendMotion;
    bool state = false;
    bool once = true;
	// Use this for initialization
	void Start () {
        if (instance == null)
            instance = this;
    }

    public void GoConver()
    {
        state = true;//이제 대화 하고 죽는당
    }
	
    void Idle()
    {
        friendMotion["Zomb_Crawl"].speed = 0.5f;
        friendMotion.Play("Char_Cower",PlayMode.StopAll);

    }

    void Update()
    {
        if (!state)//주인공 조우 하기 전 상태
            Idle();
        else//주인공과 대화하고 죽는 상태
        {
            conversation();
        }
            
    }

    void conversation() {

        if(once)
            StartCoroutine("DeadProcess");
        
    }

    IEnumerator DeadProcess()
    {
        friendMotion["Zomb_Crawl"].speed = 0.1f;//1.속도반영
        friendMotion.CrossFade("Zomb_Crawl",1.0f);

        while (friendMotion.isPlaying)
        {
            yield return new WaitForEndOfFrame();
            
        }

        yield return new WaitForSeconds(1.0f);
        once = false;
    }
}
