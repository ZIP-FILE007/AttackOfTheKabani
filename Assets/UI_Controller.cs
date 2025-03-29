using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UI_Controller : MonoBehaviour
{
    public Button CompanyStartBtn;
    public Button MultiplayerBtn;
    public Button SettingsBtn;
    public Button AuthorsBtn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        CompanyStartBtn = root.Q<Button>("company-button");
        MultiplayerBtn = root.Q<Button>("multiplayer-button");
        SettingsBtn = root.Q<Button>("settings-button");
        AuthorsBtn = root.Q<Button>("authors-button");
    }

    // Update is called once per frame
    void CompanyStartBtnPressed()
    {
        //SceneManager.LoadScene("company");
    }

    void MultiplayerBtnPressed() {
        //SceneManager.LoadScene("multiplayer");
    }
    void SettingsBtnPressed() {
        //SceneManager.LoadScene("settings");
    }

    void AuthorsBtnPressed() {
        SceneManager.LoadScene("authors");
    }
}
