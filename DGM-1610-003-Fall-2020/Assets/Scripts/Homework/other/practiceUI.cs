using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class practiceUI : MonoBehaviour
{
    private Image _image;

    void Start()
    {
        GUI.color = Color.black;
        
        Matrix4x4 matrix4X4 = GUI.matrix;
        matrix4X4.m00 = Single.Epsilon;

        float _infiniti = Mathf.Infinity;

        var length = Uri.UriSchemeHttps.Length;

        var  _batteryStatus = BatteryStatus.Charging;
        
        Skybox.Destroy(this.gameObject);

        var b = Texture.anisotropicFiltering == AnisotropicFiltering.Disable;
        
        WindZone.Destroy(gameObject); //Research these 
    }
}
