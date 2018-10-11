/*
 * @Author: simonne.xu 
 * @Date: 2018-08-10 17:31:14 
 * @Last Modified by: simonne.xu
 * @Last Modified time: 2018-08-13 15:43:59
 * @Description: desc 
 */

using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class UIUtils
{
    public const string UICANVAS_NAME = "UICanvas";

    /// <summary>
    /// 显示UI界面
    /// </summary>
    /// <param name="prefabRelativePath">相对路径</param>
    /// <returns></returns>
    public static GameObject ShowUIView(string prefabRelativePath)
    {
        GameObject uiCanvas = GameObject.Find(UICANVAS_NAME);
        if (uiCanvas == null)
        {
            Debug.LogWarning("UIUtils >> Cant Find UICanvas");
            return null;
        }

        GameObject uiInstanceObj = UIUtils.InstantiateGameObject(prefabRelativePath);
        if (uiInstanceObj == null)
        {
            return null;
        }

        uiInstanceObj.transform.SetParent(uiCanvas.transform, false);
        return uiInstanceObj;
    }

    /// <summary>
    /// 实例化一个prefab
    /// </summary>
    /// <param name="prefabRelativePath">相对路径</param>
    /// <returns></returns>
    public static GameObject InstantiateGameObject(string prefabRelativePath)
    {
        GameObject uiObj = ResourcesManager.Instance.GetResourcesObject<GameObject>(prefabRelativePath);
        if (uiObj == null)
        {
            Debug.LogWarning("UIUtils >> Cant Find UIObject With Path:" + prefabRelativePath);
            return null;
        }

        return GameObject.Instantiate(uiObj);
    }

}