using UnityEngine;
using UnityEditor;
        [CustomEditor(typeof(ExecuteAllCubeFindNeighbours))]
        public class EditorExecuteAllCubeFindNeighbours : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); 
        if(GUILayout.Button("ExecuteOrder66"))
        {
            ExecuteAllCubeFindNeighbours.ExecuteOrder66();
        }
    }
}
