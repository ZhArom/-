using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LogRizhi : MonoBehaviour {

	string path;
	// Use this for initialization
	void Start () {
		path = Application.persistentDataPath + "/Log";
		if (!Directory.Exists(path))
        {
			Directory.CreateDirectory(path);
        }

        Application.logMessageReceivedThreaded += Application_logMessageReceivedThreaded;
	}

    private void Application_logMessageReceivedThreaded(string condition, string stackTrace, LogType type)
    {
		string content = string.Format("[{0:yyyy-MM-dd hh:mm:ss}] {1} <{2}", System.DateTime.Now, condition, stackTrace);
		WriteLog(content);
    }

    // Update is called once per frame		
    void Update () {
		//print("成功输出");
	}

	public void WriteLog(string content)
    {
		string fileName = string.Format("{0:yyyy-MM-dd}.log ", System.DateTime.Now); ;
		string logfilePath = System.IO.Path.Combine(path,fileName);
		WriteTex(logfilePath, content);
	}

	private void WriteTex(string path, string content)
	{
		FileStream fileStream = new FileStream(path, FileMode.Append);
		StreamWriter sr = new StreamWriter(fileStream);
		sr.WriteLine(content);
		sr.Close();
		fileStream.Close();
	}
}
