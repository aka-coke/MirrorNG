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

        if (GUILayout.Button("Add Room1 Scene"))
        {
            SceneManager.LoadSceneAsync("Room1", new LoadSceneParameters()
            {
                loadSceneMode = LoadSceneMode.Additive,
                localPhysicsMode = LocalPhysicsMode.Physics3D
            });
        }

        if (GUILayout.Button("Add Room2 Scene"))
        {
            SceneManager.LoadSceneAsync("Room2", new LoadSceneParameters()
            {
                loadSceneMode = LoadSceneMode.Additive,
                localPhysicsMode = LocalPhysicsMode.Physics3D
            });
        }

        if (GUILayout.Button("Move Players Room1"))
        {
            MovePlayers(SceneManager.GetSceneByName("Room1"));
        }

        if (GUILayout.Button("Move Players Room2"))
        {
            MovePlayers(SceneManager.GetSceneByName("Room2"));
        }

        GUILayout.Label("List of Active Scenes:" + "\n" + sceneText);

        GUILayout.EndArea();
    }

    public void FixedUpdate()
    {
        int countLoaded = SceneManager.sceneCount;
        sceneText = string.Empty;

        for (int i = 0; i < countLoaded; i++)
        {
            sceneText += SceneManager.GetSceneAt(i).name + "\n";
        }
    }

    void MovePlayers(Scene scene)
    {
        foreach(NetworkConnection connection in networkManager.server.connections)
        {
            SceneManager.MoveGameObjectToScene(connection.Identity.gameObject, scene);
        }
    }
}
