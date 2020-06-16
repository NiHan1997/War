using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 适配全面屏分辨率.
/// </summary>
public class FullScreenManager : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<CanvasScaler>().referenceResolution =
            new Vector2(Screen.width, Screen.height);
    }
}
