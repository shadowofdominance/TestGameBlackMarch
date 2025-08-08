using UnityEditor;
using UnityEngine;

public class ObstacleEditorTool : EditorWindow
{
    private ObstacleData obstacleData;

    [MenuItem("Tools/Obstacle Editor Tool")]

    public static void ShowWindow()
    {
        GetWindow<ObstacleEditorTool>().Show();
    }
    public void OnGUI()
    {
        if(obstacleData == null)
        {
            obstacleData = (ObstacleData)EditorGUILayout.ObjectField("Obstacle Data", obstacleData, typeof(ObstacleData), false);
            return;
        }
        EditorGUILayout.LabelField("10 * 10 Grid for Obstacle");

        for(int y = 0; y < 10; y++)
        {
            EditorGUILayout.BeginHorizontal();
            for(int x = 0; x < 10; x++)
            {
                int index = y * 10 + x;
                obstacleData.obstaclearray[index] = GUILayout.Toggle(obstacleData.obstaclearray[index], "");

            }
            EditorGUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Save"))
        {
            EditorUtility.SetDirty(obstacleData);
            AssetDatabase.SaveAssets();
        }
    }
}
