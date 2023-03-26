using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color _startColor;
    private GameObject _turret;
    private Renderer _renderer;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseEnter()
    {
        _renderer.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }

    private void OnMouseDown()
    {
        if (_turret != null)
        {
            Debug.Log("Низя");
            return;
        }

        var turretToBuild = BuildManager.instance.GetTurretToBuild();
        _turret = Instantiate(turretToBuild, transform.position + offset, transform.rotation);
    }
}