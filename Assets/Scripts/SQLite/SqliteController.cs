using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SqliteController : MonoBehaviour {
    public InputField LuserName;
    public InputField LassWord;
    string name;
	string pwd;
	public GameObject errorText;
	SQLiteConnection liteConnection;
	// Use this for initialization
	void Start () {

		OpenSqlite();
	}
	
	public void OpenSqlite()
    {
		string path = Application.persistentDataPath + "/登录账号密码存储数据库.db";
		liteConnection = new SQLiteConnection(path, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite);
	}

	public void CreatTable()
    {
        if (liteConnection!=null)
        {
			SQLiteCommand liteCommand = liteConnection.CreateCommand("CREATE TABLE IF NOT EXISTS User(UserName varchar(255),PassWord varchar(255))");
			liteCommand.ExecuteNonQuery();
        }
		
    } 

	public void Insert()
    {
		name = Login.NM;
		pwd = Login.PW;
		if (liteConnection != null)
		{
			//string sql = string.Format("INSERT INTO VALUES (\"{0}\",\"{1}\")", name, pwd);
			SQLiteCommand liteCommand = liteConnection.CreateCommand("INSERT INTO User VALUES (\"" + name + "\",\"" + pwd + "\")");
			liteCommand.ExecuteNonQuery();
		}
	}

	public void Select()
    {
        string nm = LuserName.text;
        string pw = LassWord.text;
        OpenSqlite();
        //if (liteConnection != null)
        //{
            //SQLiteCommand liteCommand = liteConnection.CreateCommand("select pwd from 登录账号密码存储数据库table where uname ='" + name + "'");
            //liteCommand.ExecuteNonQuery();			
            
            SQLiteCommand liteCommand = liteConnection.CreateCommand("SELECT * FROM User ");
            List<User> ZH = liteCommand.ExecuteQuery<User>();
            foreach (var item in ZH)
            {
                if (item.UserName == nm && item.PassWord == pw)
                {
                    SceneManager.LoadScene(1);
                break;
                }
                else
                {
                    errorText.SetActive(true);
                    Invoke("DisText", 2);
                    errorText.SetActive(false);

            }
            }
            liteCommand.ExecuteNonQuery();
            OnDestroy();
       // }

    }
	private void OnDestroy()
    {
        if (liteConnection!=null)
        {
			liteConnection.Close();
			liteConnection.Dispose();
			//System.GC.Collect();//清除数据库数据
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
