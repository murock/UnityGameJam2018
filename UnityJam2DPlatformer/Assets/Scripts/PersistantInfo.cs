using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantInfo : Singleton<PersistantInfo> {

    public int sceneNumber = 0;

    private void Awake()
    {
        // Gameobject will not be destoryed
        DontDestroyOnLoad(transform.gameObject);
    }

}
