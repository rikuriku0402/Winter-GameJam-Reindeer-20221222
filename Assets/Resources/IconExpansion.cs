using UnityEngine;
using UnityEditor;

public static class IconExpansion
{
    const int ICON_SIZE = 16;

    [InitializeOnLoadMethod]
    static void Initialize()
    {
        EditorApplication.hierarchyWindowItemOnGUI += OnGUI;
    }

    private static void OnGUI(int instanceID, Rect selectionRect)
    {
        var go = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if (go == null)
        {
            return;
        }


        var components = go.GetComponents<Component>();
        if (components.Length == 0)
        {
            return;
        }

        selectionRect.x = selectionRect.xMax - ICON_SIZE * components.Length;
        selectionRect.width = ICON_SIZE;

        foreach (var component in components)
        {
            var texture2D = AssetPreview.GetMiniThumbnail(component);

            GUI.DrawTexture(selectionRect, texture2D);
            selectionRect.x += ICON_SIZE;
        }
    }
}
