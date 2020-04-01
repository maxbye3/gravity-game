﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class tagHelper : MonoBehaviour
{
  public void AddTag(string tag)
  {
    UnityEngine.Object[] asset = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset");
    if ((asset != null) && (asset.Length > 0))
    {
      SerializedObject so = new SerializedObject(asset[0]);
      SerializedProperty tags = so.FindProperty("tags");

      for (int i = 0; i < tags.arraySize; ++i)
      {
        if (tags.GetArrayElementAtIndex(i).stringValue == tag)
        {
          return;     // Tag already present, nothing to do.
        }
      }

      tags.InsertArrayElementAtIndex(tags.arraySize);
      tags.GetArrayElementAtIndex(tags.arraySize - 1).stringValue = tag;
      so.ApplyModifiedProperties();
      so.Update();
    }
  }
}