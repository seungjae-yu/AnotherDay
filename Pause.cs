using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
    public static bool gamePause = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePause = !gamePause;

            if (gamePause == true)
                Time.timeScale = 0.0f;
            else
                Time.timeScale = 1.0f;
        }
        //Time.unscaledDeltaTime
    }
}
