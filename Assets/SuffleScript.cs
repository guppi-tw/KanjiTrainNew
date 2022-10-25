using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SuffleScript : MonoBehaviour
{
    [ContextMenu("Show game object")]
    private void ShowGameObjects() {
        // 子階層のGameObjectをすべて表示
        foreach ( var obj in GetComponentsInChildren<Transform>() ) {
            ShowGameObject(obj.gameObject);
        }
    }

    [ContextMenu("Shuffle game object")]
    
    private void ShuffleGameObjects() {
        foreach ( var obj in GetComponentsInChildren<Transform>() ) {
            obj.SetSiblingIndex(0);
        }
    }

    // 指定されたGameObjectの名前とインデックスを表示
    private static void ShowGameObject(GameObject obj) {
        Debug.Log("name = " + obj.name + ", index = " + obj.transform.GetSiblingIndex());
    }
}
