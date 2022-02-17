﻿using UnityEngine;
using UnityEngine.UI;

public class UIAutoNaming
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("UIAutoNaming/Naming")]
    private static void Naming()
    {
        foreach (var text in Object.FindObjectsOfType<Text>())
        {
            var parent = text.transform.parent;
            var selectable = parent.GetComponent<Selectable>();
            if (selectable)
            {
                parent.name = string.Format("{0} - {1}", selectable.GetType().Name, text.text);
                continue;
            }

            foreach (Transform tr in parent)
            {
                selectable = tr.GetComponent<Selectable>();
                if (selectable)
                {
                    parent.name = string.Format("{0} - {1}", selectable.GetType().Name, text.text);
                    break;
                }
            }

        }
    }
#endif
}
