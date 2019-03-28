using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject levelPrefab;
    public Sprite levelUnlocked;

    public Sprite levelLocked;

    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    private GameObject latestLevelUnlockedPrefab;

    public void SnapTo(RectTransform target)
    {
        Canvas.ForceUpdateCanvases();

         Vector2 anchoredPosition =
            (Vector2)scrollRect.transform.InverseTransformPoint(contentPanel.position)
            - (Vector2)scrollRect.transform.InverseTransformPoint(target.position);

        contentPanel.anchoredPosition = new Vector2(contentPanel.anchoredPosition.x, anchoredPosition.y - 100);
    }

    // Use this for initialization
    void Start()
    {
    }

    public static void GoToLevel(GameObject levelPrefab)
    {
        // Load level data
        int levelIndex = 1;
        int.TryParse(levelPrefab.GetComponentInChildren<Text>().text, out levelIndex);
        Level level = LevelUtil.LoadLevelData(levelIndex);
        // Set seleted level data to main scene
        LevelUtil.setCurrentLevel(level);
        // Load scene
        SceneManager.LoadScene((int)SceneEnum.MainScene);
    }
}
