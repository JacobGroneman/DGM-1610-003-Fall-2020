using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeSimpleColorChange : MonoBehaviour
{
    private GameObject _colorOrb;

    private Color _color;
    
    void Start()
    {
        #region Assignment
            _colorOrb = GameObject.Find("Color Orb");
            #endregion
    }

    void Update()
    {
        #region Input
        //Changes _colorOrb Material Color Randomly
            if (Input.GetKeyDown(KeyCode.Return))
            {
                RandomChangeColor();
            }
            #endregion
    }

    private Color RandomChangeColor()
    {//Changes _colorOrb Material Color Randomly
        _color = new Color
            (Random.value, Random.value, Random.value, Random.value);
        _colorOrb.GetComponent<MeshRenderer>().material.color = _color;

        return _color;
    }
}
