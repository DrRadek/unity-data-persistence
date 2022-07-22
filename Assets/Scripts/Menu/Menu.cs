using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TMP_InputField nameInputField;
    // Start is called before the first frame update
    void Start()
    {
        LoadMenuData();
    }

    void LoadMenuData()
    {
        bestScoreText.text = "Best Score : " + Data.instance.bestScoreName + " : " + Data.instance.bestScore;
        nameInputField.text = Data.instance.currentName;
    }

    public void onStartClick()
    {
        Data.instance.currentName = nameInputField.text;
        Data.SaveData();
        SceneManager.LoadScene(1);
    }

    public void onQuitClick()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
