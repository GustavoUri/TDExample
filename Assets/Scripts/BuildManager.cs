using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private GameObject turretToBuild;

    public GameObject turretPrefab;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Build Manager");
            return;
        }
            
        instance = this;
    }

    void Start()
    {
        turretToBuild = turretPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
