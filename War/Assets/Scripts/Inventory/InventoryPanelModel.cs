using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using UnityEngine.Networking;

/// <summary>
/// 背包模块M层.
/// </summary>
public class InventoryPanelModel : MonoBehaviour
{
    private static List<InventoryItem> inventoryDataList;

    /// <summary>
    /// 通过Json文件名获取背包数据.
    /// </summary>
    public List<InventoryItem> GetInentoryData()
    {
        return inventoryDataList;
    }

    /// <summary>
    /// 背包数据存档.
    /// </summary>
    public void ObjectToJson(List<GameObject> slotsList)
    {
        List<InventoryItem> tempList = new List<InventoryItem>(slotsList.Count);

        // 遍历物品槽数据.
        for (int i = 0; i < slotsList.Count; ++i)
        {
            Transform tempTransform = slotsList[i].GetComponent<Transform>().Find("InventoryItem");

            if (tempTransform != null)
            {
                InventoryItemController iic = tempTransform.GetComponent<InventoryItemController>();
                InventoryItem item = new InventoryItem(iic.ItemId, iic.GetComponent<Image>().sprite.name,
                    iic.ItemNum, iic.ItemBar);
                tempList.Add(item);
            }
        }

        // 转换为Json数据.
        string jsonStr = JsonMapper.ToJson(tempList);
        string jsonPath = Application.persistentDataPath + "/JsonData/InventoryJsonData.txt";

        // 更新Json文件.
        File.Delete(jsonPath);
        StreamWriter sw = new StreamWriter(jsonPath);
        sw.Write(jsonStr);
        sw.Close();
    }

    /// <summary>
    /// 通过Json文件名加载数据.
    /// </summary>
    public IEnumerator LoadInentoryDataByName(string fileName)
    {
        inventoryDataList = new List<InventoryItem>();

        // 解析Json数据, 第一次读取的是AB包.
        string jsonPath = null;
        if (File.Exists(Application.persistentDataPath + "/JsonData/" + fileName))
        {
            jsonPath = Application.persistentDataPath + "/JsonData/" + fileName;
        }
        else
        {
            jsonPath = Application.streamingAssetsPath + "/JsonData/".ToLower() 
                + Path.GetFileNameWithoutExtension(fileName.ToLower()) + ".assetbundle";

            AssetBundle ab = AssetBundle.LoadFromFile(jsonPath);
            string jsonDataStr = ab.LoadAsset<TextAsset>("InventoryJsonData").text;

            //UnityWebRequest request = UnityWebRequest.Get(jsonPath);
            //yield return request.SendWebRequest();
            yield return null;

            //SaveJsonToPersistent(fileName, request.downloadHandler.text);
            SaveJsonToPersistent(fileName, jsonDataStr);
        }

        string jsonStr = File.ReadAllText(Application.persistentDataPath + "/JsonData/" + fileName);
        JsonData jsonData = JsonMapper.ToObject(jsonStr);
        for (int i = 0; i < jsonData.Count; ++i)
        {
            inventoryDataList.Add(JsonMapper.ToObject<InventoryItem>(jsonData[i].ToJson()));
        }
    }

    /// <summary>
    /// 数据持久保存.
    /// </summary>
    private static void SaveJsonToPersistent(string fileName, string fileData)
    {
        string folderPath = Application.persistentDataPath + "/JsonData";
        if (Directory.Exists(folderPath) == false)
        {
            Directory.CreateDirectory(folderPath);
        }

        string filePath = folderPath + "/" + fileName;
        File.WriteAllText(filePath, fileData);
    }
}
