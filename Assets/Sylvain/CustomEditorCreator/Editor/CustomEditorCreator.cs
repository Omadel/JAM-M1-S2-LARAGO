using UnityEngine;
using UnityEditor;
using System.IO;

namespace Sylvain
{
    
    public class CustomEditorCreator
    {
        [MenuItem("Tools/Sylvain/CustomEditor %&e")]
        public static void CreatEditorTemplate()
        {
            
            string name=Selection.activeObject.name;
            if (name != null)
            {
                if (!Directory.Exists("Assets/Editor/"))
                {
                    Directory.CreateDirectory("Assets/Editor/");
                }
                string editor =
                   "using UnityEngine;" + "\n" + "using UnityEditor;" + "\n"
                   + $"        [CustomEditor(typeof({name}))]" + "\n"
                   + $"        public class Editor{name} : Editor" + "\n"
                   + "{" + "\n"
                   + "    public override void OnInspectorGUI()" + "\n"
                   + "    {" + "\n"
                   + "        base.OnInspectorGUI(); " + "\n"
                   + "    }" + "\n"
                   + "}" + "\n"
                   ;
                System.IO.File.WriteAllText($"Assets/Editor/Editor{name}.cs", editor);
                AssetDatabase.Refresh();
                Debug.Log($"Custom Inspector has been created at : Assets/Editor/Editor{name}.cs For the Script : {name}");
            }
        }
    }
}
