using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 预先加载文件数据.
/// </summary>
public class PreloadFileManager : MonoBehaviour
{
    void Awake()
    {
        PreloadInvnetoryData();
    }

    /// <summary>
    /// 预先加载背包数据.
    /// </summary>
    private void PreloadInvnetoryData()
    {
        StartCoroutine(GameObject.Find("InventoryPanel").GetComponent<InventoryPanelModel>().
            LoadInentoryDataByName("InventoryJsonData.txt"));
    }
}
