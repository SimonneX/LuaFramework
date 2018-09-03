/*
 * @Author: simonne.xu 
 * @Date: 2018-08-10 16:50:22 
 * @Last Modified by: simonne.xu
 * @Last Modified time: 2018-08-13 15:40:08
 * @Description: 管理游戏相关的逻辑
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : Manager<GameManager>
{
    public const string CDN_URL = "http://127.0.0.1:3000";

    protected override void Awake()
    {
        base.Awake();

        s_instance = this;
    }
    protected override void Start()
    {
        base.Start();

        // 开始游戏入口
        ApplicationFacade.Instance.StartUp();

        // 调试界面只在development下打开
        if (Debug.isDebugBuild)
        {
            UIUtils.InstantiateGameObject(Path.Combine(UIUtils.STAIC_PREFAB_PREFIX_PATH, DebugView.PREFAB_PATH));
        }
    }
}
