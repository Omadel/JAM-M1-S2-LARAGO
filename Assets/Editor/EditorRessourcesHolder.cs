using UnityEngine;
using UnityEditor;
        [CustomEditor(typeof(RessourcesHolder))]
        public class EditorRessourcesHolder : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); 
        if(GUILayout.Button("UpgradeEnum"))
        {
            RessourcesHolder t =target as RessourcesHolder;
            t.UpdateEnumGO();
        }

    }
}
