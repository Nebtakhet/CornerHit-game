using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ResponsiveUI : MonoBehaviour
{
    RectTransform rectTransform;
    Rect lastSafeArea = new Rect(0,0,0,0);
    Vector2Int lastResolution = new Vector2Int(0,0);

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        ApplySafeArea();
    }

    void Update()
    {
        Vector2Int res = new Vector2Int(Screen.width, Screen.height);
        if (res.x != lastResolution.x || res.y != lastResolution.y)
        {
            ApplySafeArea();
        }
    }

    void ApplySafeArea()
    {
        Rect safeArea = Screen.safeArea;
        if (safeArea.Equals(lastSafeArea) && Screen.width == lastResolution.x && Screen.height == lastResolution.y)
            return;

        lastSafeArea = safeArea;
        lastResolution = new Vector2Int(Screen.width, Screen.height);

        // Convert safe area rectangle from pixel coordinates to anchor coordinates
        Vector2 anchorMin = new Vector2(safeArea.xMin / Screen.width, safeArea.yMin / Screen.height);
        Vector2 anchorMax = new Vector2(safeArea.xMax / Screen.width, safeArea.yMax / Screen.height);

        rectTransform.anchorMin = anchorMin;
        rectTransform.anchorMax = anchorMax;
        rectTransform.anchoredPosition = Vector2.zero;
        rectTransform.sizeDelta = Vector2.zero;
    }
}
