using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeDaynNight : MonoBehaviour
{
    [SerializeField] private Transform directionalLight;
    [SerializeField] private float fullDayInRealSec;
    [Range(0, 24)] [SerializeField] private float currentTime;
    [SerializeField] private Material skybox;
    [Range(0, 1)] private float blend;
    [SerializeField] private Light _light;
    private Color nightColor = new Color(0.314f, 0.420f, 0.502f);
    private Color dayColor = new Color(0.631f, 0.592f, 0.529f);

void Start()
{
    
}
    void FixedUpdate()
    {
        if (currentTime >= 24) currentTime = 0; else if (currentTime < 0) currentTime = 0;

        directionalLight.localRotation = Quaternion.Euler((currentTime * 15f) - 90, -125, 0);
        currentTime += Time.deltaTime / (fullDayInRealSec / 24);
        
        skybox.SetFloat("_Blend", blend);
        ChangeColor();
        ChangeSkybox();
    }


    void ChangeColor()
    {
        if (currentTime > 19f || currentTime < 4f)
        {
            _light.color = nightColor;
        }
        if (currentTime > 4f && currentTime < 19f)
        {
            _light.color = dayColor;
        }
    }
    void ChangeSkybox()
    {

        if (currentTime > 0.5f && currentTime < 12f)
        {
            blend = currentTime / 12;
        }
        if (currentTime > 12f && currentTime < 23.5f)
        {
            blend = 12 / currentTime;
        }
    }
}