using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WaypointSwitcher : MonoBehaviour
{
    public int val;
    private static GameObject points1 = GameObject.FindGameObjectWithTag("waypoint1");
    private GameObject[] points1Childrens = points1.GetComponentsInChildren<GameObject>();
    private static GameObject points2 = GameObject.FindGameObjectWithTag("waypoint2");
    private GameObject[] points2Childrens = points2.GetComponentsInChildren<GameObject>();
    private static GameObject points3 = GameObject.FindGameObjectWithTag("waypoint3");
    private GameObject[] points3Childrens = points3.GetComponentsInChildren<GameObject>();
    public static Transform[] points;

    
    public void Switcher()
    {
        val = Random.Range(1, 3);
        switch (val)
        {
            case 1:
                points1.SetActive(true);
                points2.SetActive(false);
                points3.SetActive(false);
                foreach (var g in points1Childrens)
                {
                    g.SetActive(true);
                }
                foreach (var g in points2Childrens)
                {
                    g.SetActive(false);
                }foreach (var g in points3Childrens)
                {
                    g.SetActive(false);
                }
                break;
            case 2 :
                points1.SetActive(false);
                points2.SetActive(true);
                points3.SetActive(false);
                foreach (var g in points1Childrens)
                {
                    g.SetActive(false);
                }
                foreach (var g in points1Childrens)
                {
                    g.SetActive(true);
                }
                foreach (var g in points1Childrens)
                {
                    g.SetActive(false);
                }
                
                break;
            case 3 :
                points1.SetActive(false);
                points2.SetActive(false);
                points3.SetActive(true);
                foreach (var g in points1Childrens)
                {
                    g.SetActive(true);
                }
                foreach (var g in points1Childrens)
                {
                    g.SetActive(true);
                }
                foreach (var g in points1Childrens)
                {
                    g.SetActive(true);
                }
                break;
            

        }
        
    }
    private void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
