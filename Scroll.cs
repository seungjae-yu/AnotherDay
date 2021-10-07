using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour
{
	public static Scroll instance { get; private set; }
	public GameObject[] scroll = null;
	int num = 0;
	bool ok_num = false;

	public GameObject Gun = null;
	float gun_y;
	// Use this for initialization
	void Start()
	{
		gun_y = Gun.transform.localPosition.y;
		if (instance == null)
			instance = this;

		//don't see scroll
		scroll[1].transform.localPosition =
		   new Vector3(-0.005999226f, 5f, -3.5f);
		scroll[2].transform.localPosition =
		   new Vector3(-0.005999226f, 5f, -3.5f);
		scroll[0].transform.localPosition =
		   new Vector3(-0.005999226f, 5f, -3.5f);
	}

	public void ShowScroll()
	{
		CharacterMove.instance.StopPlayer();//플레이어 정지시킴
		Gun.transform.localPosition = 
			new Vector3(Gun.transform.localPosition.x, 15, Gun.transform.localPosition.z);//총 위치이동 없앰

		scroll[num].transform.localScale *= 0.8f;
		scroll[num].transform.localPosition =
			new Vector3(-0.005999226f, 0.878f, -3.5f);//스크롤 차례로 나타나게 하기
		
		LeanTween.scale(scroll[num], new Vector3(0.007081821f, 0.004877057f, 0.3407066f), 0.5f)//2배까지 크기를 키운다.
								.setEase(LeanTweenType.easeOutElastic);
								


		StartCoroutine(ScrollProcess());    //시간 차 두기
	}


	IEnumerator ScrollProcess()
	{
		ok_num = false;
		
		yield return new WaitForSeconds(1f);

		
		yield return new WaitForEndOfFrame();
		ok_num = true;

	}
	// Update is called once per frame
	void Update()
	{
		
		if (ok_num)
		{
			if ((Input.GetKeyDown(KeyCode.Q))){
				Destroy(scroll[num]);
				num++;
				if (num == 3)
				{
                    ok_num = false;
                    CharacterMove.instance.StartPlayer();//다시 플레이어 작동 시킴
					Gun.transform.localPosition =
						new Vector3(Gun.transform.localPosition.x, gun_y, Gun.transform.localPosition.z);
					//Destroy(gameObject);
					return;
				}
				   
				AudioManager.instance.Scroll();
				scroll[num].transform.localPosition =
				   new Vector3(-0.005999226f, 0.878f, -3.5f);
				StartCoroutine(ScrollProcess());

			}
		}
	}
}
	

