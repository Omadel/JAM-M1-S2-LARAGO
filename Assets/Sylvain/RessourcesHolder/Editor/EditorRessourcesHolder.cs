using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(RessourcesHolder))]
public class EditorRessourcesHolder : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("UpgradeEnums"))
        {
            RessourcesHolder t = target as RessourcesHolder;
            t.UpdateEnums();
        }

    }
}
