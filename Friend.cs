using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]

public class Friend : MonoBehaviour
{
    public TextMesh a;
    bool showDialog = false;
    string answer = "";
    bool isText = false;
    string[] dialogue = new string[10];
    public int line = 1;
    float deltaTime = 0.0f;
    public static bool dialogEnd = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GetComponent<Collider>().enabled = false;       // only do it once
            isText = true;
            StartCoroutine("DialogueProcess");
            CharacterMove.instance.StopPlayer();//플레이어 정지시킴


        }
    }
    IEnumerator DialogueProcess()
    {
        while (line != dialogue.Length)
        {

            if (line == 6)
            {
                FrinedMotion.instance.GoConver();
            }
            yield return new WaitForFixedUpdate();
        }
        
        if (line == dialogue.Length)
        {   
            CharacterMove.instance.StartPlayer();//다시 플레이어 작동 시킴
            dialogEnd = true;
            Destroy(gameObject);
        }


    }
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Q)) && isText)
            line++;
    }
    void Start()
    {
        dialogue[0] = "[Player] 애쉬? ▼";
        dialogue[1] = "[Ashe] 이제 돌이킬수 없어..다 끝났어.. ▼";
        dialogue[2] = "[Player] 무슨 말이야? 이게 무슨 상황이야? ▼";
        dialogue[3] = "[Ashe] 실험은 실패했어..1층으로 어서 탈출해.. ▼";
        dialogue[4] = "[Player] 온몸이 피범벅이잖아, 일어나 같이 나가야지!! ▼";
        dialogue[5] = "[Ashe] 열쇠는 2층에 있을거야..난 이미 늦었어.. ▼";
        dialogue[6] = "[Player] 애쉬? 정신차려봐!! 애쉬!!! ▼";
        dialogue[7] = "[Ashe] ... ... ... ▼";
        dialogue[8] = "[Player] ..!. ▼";
        dialogue[9] = "";

    }

    void OnGUI()
    {
        if (isText)
        {
            a.text = dialogue[line - 1];
            //a.fontSize = 7;

        }
    }
}