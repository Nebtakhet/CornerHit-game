using System.IO;
using UnityEditor;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.UI;

public static class CreatePausePanelPrefab
{
    [MenuItem("Tools/Create Pause Panel Prefab")]
    public static void CreatePrefab()
    {
        // Root canvas
        var canvasGO = new GameObject("PausePanel_Canvas");
        var canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        // Panel
        var panelGO = new GameObject("PausePanel");
        panelGO.transform.SetParent(canvasGO.transform, false);
        var panelImage = panelGO.AddComponent<Image>();
        panelImage.color = new Color(0f, 0f, 0f, 0.6f);
        var panelRect = panelGO.GetComponent<RectTransform>();
        panelRect.anchorMin = Vector2.zero;
        panelRect.anchorMax = Vector2.one;
        panelRect.offsetMin = Vector2.zero;
        panelRect.offsetMax = Vector2.zero;

        // PausePanelController
        var hook = panelGO.AddComponent<PausePanelController>();

        // Create buttons container
        var container = new GameObject("Buttons");
        container.transform.SetParent(panelGO.transform, false);
        var containerRect = container.AddComponent<RectTransform>();
        containerRect.sizeDelta = new Vector2(300, 150);
        containerRect.anchorMin = new Vector2(0.5f, 0.5f);
        containerRect.anchorMax = new Vector2(0.5f, 0.5f);
        containerRect.anchoredPosition = Vector2.zero;

        // Resume button
        var resumeBtn = CreateButton("ResumeButton", "Resume", container.transform);
        var resumeRect = resumeBtn.GetComponent<RectTransform>();
        resumeRect.anchoredPosition = new Vector2(0, 30);

        // Restart button
        var restartBtn = CreateButton("RestartButton", "Restart", container.transform);
        var restartRect = restartBtn.GetComponent<RectTransform>();
        restartRect.anchoredPosition = new Vector2(0, -30);

        // Wire persistent listeners to the PausePanelController methods
        UnityEventTools.AddPersistentListener(resumeBtn.onClick, hook.Resume);
        UnityEventTools.AddPersistentListener(restartBtn.onClick, hook.Restart);

        // Ensure Prefabs folder
        var prefabsPath = "Assets/Prefabs";
        if (!Directory.Exists(prefabsPath))
            Directory.CreateDirectory(prefabsPath);

        var prefabPath = Path.Combine(prefabsPath, "PausePanel.prefab");
        PrefabUtility.SaveAsPrefabAssetAndConnect(canvasGO, prefabPath, InteractionMode.UserAction);

        // Clean up temporary scene objects
        Object.DestroyImmediate(canvasGO);

        Debug.Log($"Created PausePanel prefab at {prefabPath}");
    }

    static Button CreateButton(string name, string label, Transform parent)
    {
        var btnGO = new GameObject(name);
        btnGO.transform.SetParent(parent, false);
        var img = btnGO.AddComponent<Image>();
        img.color = Color.white;
        var rect = btnGO.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(160, 40);

        var btn = btnGO.AddComponent<Button>();

        var textGO = new GameObject("Text");
        textGO.transform.SetParent(btnGO.transform, false);
        var txt = textGO.AddComponent<Text>();
        txt.text = label;
        txt.alignment = TextAnchor.MiddleCenter;
        txt.color = Color.black;
        txt.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        var txtRect = textGO.GetComponent<RectTransform>();
        txtRect.anchorMin = Vector2.zero;
        txtRect.anchorMax = Vector2.one;
        txtRect.offsetMin = Vector2.zero;
        txtRect.offsetMax = Vector2.zero;

        return btn;
    }
}
