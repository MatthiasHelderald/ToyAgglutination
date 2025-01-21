using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

public class GradientChange : MonoBehaviour
{
    [GradientUsage(true)]
    public Gradient newGradient;

    public Color baseColor;
    public Color newColor;

    private bool changeGradient;

    public TrailRenderer trailRenderer;

    private GradientColorKey[] colors = new GradientColorKey[2];
    private GradientAlphaKey[] alphas = new GradientAlphaKey[2];

    public VisualEffect vfx;

    private Color lerpedColor;

    public float transitionTime;

    // Start is called before the first frame update
    void Start()
    {
        //trailRenderer = GetComponent<TrailRenderer>();
        alphas[0] = new GradientAlphaKey(1.0f, 0.0f);
        //alphas[1] = new GradientAlphaKey(1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            changeGradient = true;
            colors[0] = new GradientColorKey(baseColor, 0.99f);
            colors[1] = new GradientColorKey(newColor, 1f);
        }

        lerpedColor = Color.Lerp(vfx.GetVector4("PartColor"), vfx.GetVector4("Color2"), Mathf.Cos(Time.realtimeSinceStartup / transitionTime)/2 +0.5f);

        vfx.SetFloat("TimeSec", Mathf.Cos(Time.realtimeSinceStartup / transitionTime)/2 +0.5f);


        colors[0] = new GradientColorKey(lerpedColor, 0f);
        baseColor = vfx.GetVector4("PartColor");
        newGradient.SetKeys(colors, alphas);
        trailRenderer.colorGradient = newGradient;
    }

    private void FixedUpdate()
    {
        if (changeGradient)
        {
            trailRenderer.colorGradient = newGradient;
            newGradient.SetKeys(colors, alphas);
            colors[0].time -= 0.01f;
            colors[1].time -= 0.01f;

            if(colors[0].time <= 0.00f)
            {
                colors[0].time = 0f;
                colors[1].time = 0.01f;
                changeGradient = false;
                baseColor = newColor;
                newGradient.SetKeys(colors, alphas);
                trailRenderer.colorGradient = newGradient;
            }
        }
    }
}
