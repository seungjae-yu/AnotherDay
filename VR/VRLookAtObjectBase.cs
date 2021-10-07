using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using VRStandardAssets.Utils;

[RequireComponent(typeof(VRInteractiveItem))]
//()안의 컴포넌트를 강제하게 추가하게 하는 코드

public class VRLookAtObjectBase : MonoBehaviour
{
    VRInteractiveItem interactiveItem;       // Reference to the VRInteractiveItem to determine when to fill the bar.
    VRInput vrInput;                         // Reference to the VRInput to detect button presses.
    Slider uiSlider;
    
    // Touch Input event
    public event System.Action ButtonDoubleClick;
    public event System.Action ButtonOnClick;
    public event System.Action ButtonOnCancel;
    public event System.Action ButtonOnDown;
    public event System.Action ButtonOnUp;

    // Look At Input event
    public event System.Action ButtonOnOver;
    public event System.Action ButtonOnOut;

    // Fill Finish event
    public event System.Action ButtonFillFinish;

    public event System.Action<float> FillUpdate;

    void OnEnable()
    {
        // Set Component
        interactiveItem = GetComponent<VRInteractiveItem>();
        vrInput = VrCameraManager.instance.vrInput;
        uiSlider = GetComponentInChildren<Slider>();

        // Touch Input
        vrInput.OnDoubleClick += OnDoubleClick; 
        vrInput.OnClick += OnClick;
        vrInput.OnCancel += OnCancel;
        vrInput.OnDown += OnDown;
        vrInput.OnUp += OnUp;

        // Look At Input
        interactiveItem.OnOver += OnOver;
        interactiveItem.OnOut += OnOut;
    }

    public void OnDisable()
    {
        // Touch Input
        vrInput.OnDoubleClick -= OnDoubleClick;
        vrInput.OnClick -= OnClick;
        vrInput.OnCancel -= OnCancel;
        vrInput.OnDown -= OnDown;
        vrInput.OnUp -= OnUp;

        // Look At Input
        interactiveItem.OnOver -= OnOver;
        interactiveItem.OnOut -= OnOut;
    }

    void Update()
    {
        if (fillMode == FILLMODE.LOOKAT)
        {
            if (lookAtOver)
            {
                if (fillSliderRoutine == null)
                {
                    fillSliderRoutine = StartCoroutine(FillBar());
                }
            }
            else
            {
                StopFillSlider();
            }
        }
        else if (fillMode == FILLMODE.LOOKATWITHTAP)
        {
            if (lookAtOver && pressed)
            {
                if (fillSliderRoutine == null)
                {
                    fillSliderRoutine = StartCoroutine(FillBar());
                }
            }
            else
            {
                StopFillSlider();
            }
        }
    }

    // ============================== Touch Input

    bool pressed = false;

    public void OnDoubleClick()
    {
        //Debug.Log("======== OnDoubleClick ==========");

        if (ButtonDoubleClick != null)
            ButtonDoubleClick();        
    }

    public void OnCancel()
    {
        //Debug.Log("======== OnCancel ==========");

        if (ButtonOnCancel != null)
            ButtonOnCancel();        
    }

    public void OnClick()
    {
        //Debug.Log("======== OnClick ==========" + Time.realtimeSinceStartup);

        if (ButtonOnClick != null)
            ButtonOnClick();        
    }

    public void OnDown()
    {
        //Debug.Log("======== OnDown ==========");
        pressed = true;        

        if (ButtonOnDown != null)
            ButtonOnDown();
    }

    public void OnUp()
    {
        pressed = false;

        if (ButtonOnUp != null)
            ButtonOnUp();
        //Debug.Log("======== OnUp ==========" + Time.realtimeSinceStartup);
    }

    // ============================== Look at Input

    public FILLMODE fillMode = FILLMODE.LOOKATWITHTAP;

    Coroutine fillSliderRoutine;
    bool lookAtOver = false;
    public void OnOver()
    {        
        lookAtOver = true;

        if (ButtonOnOver != null)
            ButtonOnOver();

        //Debug.Log("======== OnOver ==========");
    }

    public void OnOut()
    {
        lookAtOver = false;

        if (ButtonOnOut != null)
            ButtonOnOut();

        //Debug.Log("======== OnOut ==========");
    }

    public void FillFinish()
    {
        if (ButtonFillFinish != null)
            ButtonFillFinish();

        Debug.LogWarning("===== Fill MAX ==================");
    }

    public bool useReticleOutline = true;
    [Header("Look At Fill Time")]
    public float fillTime = 1.0f;

    IEnumerator FillBar()
    {
        float calcTime = 0.0f;

        while (calcTime < fillTime)
        {
            calcTime += Time.deltaTime;
            float fillRatio = calcTime / fillTime;
            SetSliderValue(fillRatio);

            if(FillUpdate!= null)
                FillUpdate(fillRatio);


            yield return new WaitForEndOfFrame();
        }

        FillFinish();
    }

    void SetSliderValue(float sliderValue)
    {
        if (uiSlider)
            uiSlider.value = sliderValue;

        if(useReticleOutline)
            VrCameraManager.instance.SetReticleRadiusValue(sliderValue);
    }

    void StopFillSlider()
    {
        if (fillSliderRoutine != null)
            StopCoroutine(fillSliderRoutine);

        fillSliderRoutine = null;
        SetSliderValue(0f);
    }
}
