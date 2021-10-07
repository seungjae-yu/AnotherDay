using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using VRStandardAssets.Utils;

public class VrCameraManager : MonoBehaviour
{
    public static VrCameraManager instance { get; private set; }
    public VRInput vrInput { get; private set; }

    [Header("VR Reticle")]
    public Image reticleUi;
    public Image selectionRadiusBar;

    void Start()
    {
        transform.Rotate(new Vector3(0.0f, 45.0f, 0.0f));

    }
    void Awake()
    {
        if( instance == null)
            instance = this;

        vrInput = GetComponentInChildren<VRInput>();
    }

    // ========================== Reticle
    public void SetReticleRadiusValue(float fillValue)
    {
        if (selectionRadiusBar)
        {
            selectionRadiusBar.fillAmount = fillValue;
        }
    }

    public void ReticleOn()
    {
        Color baseColor = reticleUi.color;
        baseColor.a = 1.0f;
        reticleUi.color = baseColor;
    }

    public void ReticleOff()
    {
        Color baseColor = reticleUi.color;
        baseColor.a = 0.0f;
        reticleUi.color = baseColor;

        SetReticleRadiusValue(0.0f);
    }
}
