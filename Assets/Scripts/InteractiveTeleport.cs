using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveTeleport : MonoBehaviour
{
    public Vector3 rotation;

    public GameObject cam;

    public bool isDisabled;

    public GameObject[] disableObjs;
    public GameObject[] selectedObjs;
    public GameObject rotObj;

    public GameObject effect;
    public MoodType mood;

    public void Update()
    {
        var tempLookPos = cam.transform.position;
        tempLookPos.y = 0;
        rotObj.transform.LookAt(tempLookPos);
    }
    
    public void Enable()
    {
        effect.SetActive(true);
    }

    public void Disable()
    {
        effect.SetActive(false);
    }

    public void Click()
    {
        isDisabled = true;
        InteractiveManager.instance.Teleport(this);
        print("click");
        SetActive(false);
        Disable();
        rotObj.transform.rotation = new Quaternion(0,0,0,0);
        gameObject.SetActive(false);
    }

    public void SetActive(bool active)
    {
        foreach (var selectedObj in selectedObjs)
        {
            selectedObj.SetActive(!active);
        }

        foreach (var disableObj in disableObjs)
        {
            disableObj.SetActive(active);
        }
    }

}

public enum MoodType
{
    Good,
    Bad, 
    Neutral
}