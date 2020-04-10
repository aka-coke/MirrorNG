using UnityEngine;

public class CurrentScene : MonoBehaviour
{
    private void OnGUI()
    {
        GUILayout.Label("Player In Scene: " + gameObject.scene.name);
    }
}
