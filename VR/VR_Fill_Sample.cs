using UnityEngine;
using System.Collections;

using UnityEngine.UI;//For canvasScaler
public class VR_Fill_Sample : MonoBehaviour {

    public VRLookAtObjectBase vrLookAtObjectBase;

    int targetCanvas = 0;
    public CanvasScaler canvasScaler;

    Vector3 originScale1 ;
    Vector3 originScale2 ;

    Coroutine changeCanvasProcess;
    public GameObject canvasTitle;

    public Text titleText;

    public VR_FadeSample forfade;

    void Awake()
    {
        vrLookAtObjectBase = GetComponent<VRLookAtObjectBase>();
        originScale1 = new Vector3(0.18f, 0.01f, 0.0f);
        originScale2 = new Vector3(0.045f, 0.045f, 0.045f);

    }

    void OnEnable()
    {
        vrLookAtObjectBase.ButtonFillFinish += ButtonFillFinish;
        vrLookAtObjectBase.ButtonOnOver += ButtonOnOver;
        vrLookAtObjectBase.ButtonOnOut += ButtonOnOut;
        vrLookAtObjectBase.FillUpdate += FillUpdate;


    }
    void OnDisble()
    {
        vrLookAtObjectBase.ButtonFillFinish -= ButtonFillFinish;
        vrLookAtObjectBase.ButtonOnOver -= ButtonOnOver;
        vrLookAtObjectBase.ButtonOnOut -= ButtonOnOut;
        vrLookAtObjectBase.FillUpdate -= FillUpdate;
    }

    void ButtonOnOver()
    {
        Vector3 targetScale1 = 1.3f * originScale1;
        Vector3 targetScale2 = 1.3f * originScale2;
        LeanTween.scale(gameObject, targetScale1, 0.5f).setEase(LeanTweenType.easeOutBack);
        LeanTween.scale(canvasTitle, targetScale2, 0.5f).setEase(LeanTweenType.easeOutBack);
        
    }
    void ButtonOnOut()
    {
        Vector3 targetScale1 = originScale1;
        Vector3 targetScale2 = originScale2;
        LeanTween.scale(gameObject, targetScale1, 0.5f).setEase(LeanTweenType.easeOutBack);
        LeanTween.scale(canvasTitle, targetScale2, 0.5f).setEase(LeanTweenType.easeOutBack);
        titleText.color = Color.white;
    }

    public Color targetColor;
    void FillUpdate(float value)
    {
        titleText.color = Color.Lerp(Color.white, targetColor, value);
    }

    void ButtonFillFinish()
    {
        if (changeCanvasProcess!= null)
            StopCoroutine(changeCanvasProcess);
        changeCanvasProcess = StartCoroutine(ChangeCanvasProcess());
        
    }

    IEnumerator ChangeCanvasProcess()
    {
        forfade.Fade();
        yield return new WaitForEndOfFrame();
        
    }  
}
