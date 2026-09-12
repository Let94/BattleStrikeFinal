using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private float size = 8f;
    [SerializeField] private float thickness = 2f;
    [SerializeField] private float gap = 5f;

    private void OnGUI()
    {
        float centerX = Screen.width * 0.5f;
        float centerY = Screen.height * 0.5f;

        GUI.Box(new Rect(centerX - thickness * 0.5f, centerY - gap - size, thickness, size), GUIContent.none);
        GUI.Box(new Rect(centerX - thickness * 0.5f, centerY + gap, thickness, size), GUIContent.none);
        GUI.Box(new Rect(centerX - gap - size, centerY - thickness * 0.5f, size, thickness), GUIContent.none);
        GUI.Box(new Rect(centerX + gap, centerY - thickness * 0.5f, size, thickness), GUIContent.none);
    }
}
