using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : MonoBehaviour
{
	// Use this for initialization
	void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
		
	}

    public void OnPinned()
    {
        SceneManager.LoadSceneAsync("pinned", LoadSceneMode.Single);

    }

    public void OnFollow()
    {
        SceneManager.LoadSceneAsync("followme", LoadSceneMode.Single);

    }

    public void OnSound()
    {
        SceneManager.LoadSceneAsync("spatialsound", LoadSceneMode.Single);

    }

    public void OnGestures()
    {
        SceneManager.LoadSceneAsync("gestures", LoadSceneMode.Single);

    }

    public void OnSpatial()
    {
        SceneManager.LoadSceneAsync("spatialmapping", LoadSceneMode.Single);

    }

    public void OnOcclusion()
    {
        SceneManager.LoadSceneAsync("spatialmappingocclusion", LoadSceneMode.Single);

    }
}
