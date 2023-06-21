using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {
    public InputField LuserName;
    public InputField LassWord;
    public InputField RuserName;
    public InputField RpassWord;
    public GameObject registerPanel;
    public GameObject errorText;
    public GameObject errorText2;
    public GameObject settingPanel;
    public string name;
    public string pass;
    public static string NM;
    public static string PW;
    public static string NM2;
    public static string PW2;
    // Use this for initialization
    void Start()
    {
        LuserName = LuserName.GetComponent<InputField>();
        LassWord = LassWord.GetComponent<InputField>();
        RuserName = RuserName.GetComponent<InputField>();
        RpassWord = RpassWord.GetComponent<InputField>();
       
    }
    public void OpenRegisterPanel()
    {
        registerPanel.SetActive(true);
    }

    public void ConforRegisterButton()
    {
        name = RuserName.text;
        pass = RpassWord.text;
        RuserName.text = "";
        RpassWord.text = "";
        if (name == "" || pass == "")
        {
            print("注册失败");
            errorText2.SetActive(true);
            Invoke("DisText2", 2);
        }
        else
        {
            NM = name;
            PW = pass;
            registerPanel.SetActive(false);

        }
    }
    public void LoginSuccess()
    {
        NM2 = LuserName.text;
        PW2 = LassWord.text;
        //if (LuserName.text == name && LassWord.text == pass)
        //{
        //    print("登录成功");
        //    //SceneManager.LoadScene(1);
        //}
        //else
        //{
        //    print("登录失败");
        //    errorText.SetActive(true);
        //    Invoke("DisText", 3);
        //    //LuserName.text = "";
        //    //LassWord.text = "";
        //}

    }
    public void DisText()
    {
        errorText.SetActive(false);
    }
    public void DisText2()
    {
        errorText2.SetActive(false);
    }
    public void OpenSetting()
    {
        settingPanel.SetActive(true);
    }
    public void CloseSetting()
    {
        settingPanel.SetActive(false);
    }

    public void Close()
    {
        registerPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
