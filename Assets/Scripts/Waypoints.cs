using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {
    public static Transform[] positions;

    void Awake()
    {
        positions = new Transform[transform.childCount];//获取该物体下的子物体数量
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = transform.GetChild(i);
        }
    }
}
