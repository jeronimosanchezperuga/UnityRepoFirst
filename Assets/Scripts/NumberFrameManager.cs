using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberFrameManager : MonoBehaviour
{
    [SerializeField] GameObject[] frames;

    public void ActivateFrameByIndex(int index)
    {
        
        if (index > -1 && index < frames.Length)
        {
            DeactivateAllFrames();
            frames[index].SetActive(true);
        }
        else
        {
            Debug.LogError("Index out of frame array index");
        }
    }

    public void DeactivateAllFrames()
    {
        foreach (GameObject f in frames)
        {
            f.SetActive(false);
        }
    }
}
