using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwticherHUD : MonoBehaviour
{
    public NetworkManager networkManager;

    string sceneText;

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 200, 215, 9999));

        if (GUILayout.Button("Switch to Room1"))
        {
            networkManager.ServerChangeScene("Room1");
        }

        if (GUILayout.Button("Switch to Room2"))
        {
            networkManager.ServerChangeScene("Room2");
        }

        if (GUILayout.Button("Add Room1 Scene"))
        {
            SceneManager.LoadSceneAsync("Room1", new LoadSceneParameters()
            {
                loadSceneMode = LoadSceneMode.Additive,
                localPhysicsMode = LocalPhysicsMode.Physics3D
            });
        }

        if (GUILayout.Button("Remove All Scenes"))
        {
            RemoveScenes();
        }

        GUILayout.Label("List of Active Scenes:" + "\n" + sceneText);

        GUILayout.EndArea();
    }

    public void FixedUpdate()
    {
        int countLoaded = SceneManager.sceneCount;
        Scene[] loadedScenes = new Scene[countLoaded];
 
        sceneText = string.Empty;

        for (int i = 0; i < countLoaded; i++)
        {
            sceneText += SceneManager.GetSceneAt(i).name + "\n";
        }
    }

    private void RemoveScenes()
    {
        
    }
}
