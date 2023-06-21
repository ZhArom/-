using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    public float speed = 10;
    public float hp = 150;
    private float totalHp;
    public GameObject explosionEffect;
    private Slider hpSlider;
    private Transform[] positions;
    private int index = 0;
    //public Music audio;
    float des;
    AudioManagerShoot audio;



    // Use this for initialization
    void Start () {
        audio = GameObject.Find("AudioManager").GetComponent<AudioManagerShoot>();
        positions = Waypoints.positions;
        totalHp = hp;
        hpSlider = GetComponentInChildren<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}


    void Move()
    {
       // if (index > positions.Length - 1) return;
        //transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed);
        //if (Vector3.Distance(positions[index].position, transform.position) < 0.2f)
        //{
        //    index++;
        //}
        //看向目标点
        this.transform.LookAt(positions[index].transform);
        //计算与目标点间的距离
        des = Vector3.Distance(this.transform.position, positions[index].transform.position);
        //移向目标
        transform.position = Vector3.MoveTowards(this.transform.position, positions[index].transform.position, Time.deltaTime * speed);
        //如果移动到当前目标点，就移动向下个目标
        if (des < 0.1f && index < positions.Length - 1)
        {
            index++;
        }
        if (index >= positions.Length-1)
        {
            ReachDestination();
        }
    }
    //达到终点
    void ReachDestination()
    {
        BuildManager.xieliang = BuildManager.xieliang - 1 ;
        audio.PlayAudio(0);
        GameObject.Destroy(this.gameObject);

    }


    void OnDestroy()
    {
        EnemySpawner.CountEnemyAlive--;
    }

    public void TakeDamage(float damage)
    {
        if (hp <= 0) return;
        hp -= damage;
        hpSlider.value = (float)hp / totalHp;
        if (hp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        GameObject effect = GameObject.Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(effect, 1.5f);
        audio.PlayAudio(0);
        Destroy(this.gameObject);
        BuildManager.money += 50;
    }

}
