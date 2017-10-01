using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Utilities
{
    public static GameObject Find(string objectName)
    {
        return GameObject.Find(objectName);
    }

    public static GameObject FindByTag(string tag)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        if (objects.Length > 0)
        {
            return objects[0];
        }

        return null;
    }
    public static GameObject Find(string objectName, GameObject parent)
    {
        Transform[] components = parent.GetComponentsInChildren<Transform>();

        foreach (Transform component in components)
        {
            if (component.gameObject.name == objectName)
            {
                return component.gameObject;
            }
        }

        return null;
    }

    public static GameObject LoadFromResource(string name, Transform parent)
    {
        GameObject gameObject = null;
        try
        {
            gameObject = GameObject.Instantiate(Resources.Load(name, typeof(GameObject)), parent) as GameObject;
        }
        catch (Exception)
        {

        }

        return gameObject;
    }

    public static GameObject GetChildByName(GameObject go, string name)
    {
        Transform[] transforms = go.GetComponentsInChildren<Transform>();

        foreach(Transform transform in transforms)
        {
            if (transform.gameObject.name == name)
            {
                return transform.gameObject;
            }
        }

        return null;
    }

    public static List<GameObject> GetChilds(GameObject go)
    {
        List<GameObject> list = new List<GameObject>();

        Transform[] transforms = go.GetComponentsInChildren<Transform>();

        foreach (Transform transform in transforms)
        {
            if (transform.gameObject != go)
            {
                list.Add(transform.gameObject);
            }
        }

        return list;
    }

    public static void PlaySound(GameObject gameObject)
    {
        AudioSource source = gameObject.GetComponent<AudioSource>();
        source.Play();
    }

    public static Vector3 CalculateOnCircle(Vector3 from, Vector3 to, float radius)
    {
        // circle on x and z axis causing a flat circle area
        float x = to.x - from.x;
        float z = to.z - from.z;

        float angle = Mathf.Atan2(z, x);

        float circleX = radius * Mathf.Cos(angle);
        float circleZ = radius * Mathf.Sin(angle);

        Vector3 positionMenu = new Vector3(from.x + circleX, from.y, from.z + circleZ);

        return positionMenu;
    }

    public static Vector3 CalculateLine(Vector3 from, Vector3 to, float distanceFrom)
    {
        // line vector from center to camera where
        // center = 0 and camera = 1
        Vector3 div = new Vector3(to.x - from.x, to.y - from.y, to.z - from.z);

        Vector3 positionMenu = new Vector3(from.x + div.x * distanceFrom, from.y + div.y * distanceFrom, from.z + div.z * distanceFrom);

        return positionMenu;
    }
}
