using SQLite4Unity3d;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class dennglu : MonoBehaviour
{
	public string savePath;
	public SQLiteConnection connection;
	public InputField zhanghao;
	public InputField mima;
	public GameObject gameimage;
	public GameObject zhuceError;
	public InputField dengluzhanghao;
	public InputField denglumima;
	bool isright = true;
	public int index;
	public GameObject dengluError;
	public GameObject zhucejiemian;
	// Use this for initialization
	void Start()
	{
	}
	public void onclickzhuce()
	{
		string name = zhanghao.text;
		string password = mima.text;
		bool isinthetabel = false;
		openSQL();
		if (connection == null)
		{
			print(1);
		}

		if (connection != null)
		{
			SQLiteCommand a = connection.CreateCommand("SELECT * FROM Denglu ");
			List<Denglu> b = a.ExecuteQuery<Denglu>();
			foreach (var item in b)
			{
				if (item.Name == name)
				{
					isinthetabel = true;
				}
			}
			print(b[0].Name);
			if (isinthetabel == false)
			{
				SQLiteCommand x = connection.CreateCommand("INSERT INTO Denglu Values(\"" + name + "\",\"" + password + "\")");
				x.ExecuteNonQuery();
				closeSQL();
				zhanghao.text = "";
				mima.text = "";
				gameimage.SetActive(false);
			}
			else
			{

				zhuceError.SetActive(true);
				Invoke("closezhuceError", 2);
				closeSQL();
			}

		}

	}
	public void openSQL()
	{
		savePath = Application.persistentDataPath + "SaveMessage.db";
		connection = new SQLiteConnection(savePath, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite);
	}
	public void closeSQL()
	{
		if (connection != null)
		{
			connection.Close();
			connection.Dispose();
			System.GC.Collect();
		}
	}
	public void createtable()
	{
		if (connection != null)
		{
			SQLiteCommand a = connection.CreateCommand("CREATE TABLE Denglu(Name varchar(255),Password varchar(255))");
			a.ExecuteNonQuery();
		}
	}
	public void closezhuceError()
	{
		zhuceError.SetActive(false);
	}

	void Update()
	{

	}
	public void onclickdenglu()
	{
		string a1 = dengluzhanghao.text;
		string a2 = denglumima.text;
		openSQL();
		SQLiteCommand a = connection.CreateCommand("SELECT * FROM Denglu ");
		List<Denglu> b = a.ExecuteQuery<Denglu>();
		foreach (var item in b)
		{
			if (item.Name == a1 && item.Password == a2)
			{
				SceneManager.LoadScene(index);
			}
			else
			{
				isright = false;
			}
		}
		if (isright == false)
		{
			dengluError.SetActive(true);
			Invoke("closeDengluError", 2);
		}
		closeSQL();
	}
	public void closeDengluError()
	{
		dengluError.SetActive(false);
	}
	public void zhucemianban()
	{
		zhucejiemian.SetActive(true);
	}

	public class Denglu
	{

		public string Name { get; set; }
		public string Password { get; set; }
	}
}
