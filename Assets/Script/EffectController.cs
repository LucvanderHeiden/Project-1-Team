using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using URPGlitch.Runtime.DigitalGlitch;

public class EffectController : MonoBehaviour
{
    [SerializeField]
    private Volume volume;
    private DigitalGlitchVolume digitalGlitch;
    [SerializeField]
    private float maxDistance = 10f;
    [SerializeField]
    private float maxIntensity = 0.5f;
    [SerializeField]
    private GameObject targetObject1;
    [SerializeField]
    private GameObject targetObject2;

    // Update is called once per frame.
    void Update()
    {
        float distance = Vector3.Distance(targetObject1.transform.position, targetObject2.transform.position);
        float mappedDistance = Remap(distance, 0f, maxDistance, 0f, maxIntensity);
        volume.profile.TryGet(out digitalGlitch);
        digitalGlitch.intensity.value = mappedDistance;
    }

    private float Remap(float value, float inputMin, float inputMax, float outputMin, float outputMax)
    {
        return outputMax - (outputMax - outputMin) * ((value - inputMin) / (inputMax - inputMin));
    }
}
