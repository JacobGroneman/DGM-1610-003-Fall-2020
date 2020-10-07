using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour
{
    [NonSerialized] public float currentTime;
    [SerializeField] public int daysPassed = 0;

    // Time of Day. H/Min/Sec: Default is 6:00am (_hMS.x)
    [SerializeField] private Vector3 
        _hms = new Vector3(6f, 0f, 0f),
        _hmsSunset = new Vector3(10f, 0f, 0f);
    
    [SerializeField] public float
        IntensityAtNoon = 1f,
        IntensityAtSunSet = 0.5f;

    //Sun Variables
    [SerializeField] private Transform _solTransform;
    [SerializeField] private Light _sol;
    [SerializeField] private float _solAngleAtNoon;
    private float
        _intensity, _rotation, _previousRotation = -1f,
        _sunset, _sunrise, _sunDayRatio;
    private Vector3 _direction;
    

    [SerializeField] public float
        Velocity = 100f;
    
    //Fog Color
    [SerializeField] private Color 
        _fogColorDay = Color.gray,
        _fogColorNight = Color.black;
    
    void Start()
    {
        //Time Conversions
            currentTime = HRS_ToTime(_hms.x, _hms.y, _hms.z);
            _sunset = HRS_ToTime(_hmsSunset.x, _hmsSunset.y, _hmsSunset.z); 
        //Sun Variable Assignment
        _sunrise = 86400f - _sunset;
        _sunDayRatio = (_sunset - _sunrise) / 43200f;
        _direction = new Vector3(
            Mathf.Cos(Mathf.Deg2Rad * _solAngleAtNoon), 
            Mathf.Sin(Mathf.Deg2Rad * _solAngleAtNoon),
            0);
    }

    void Update()
    {
        //Time Updates
        currentTime += UnityEngine.Time.deltaTime * Velocity;
        if (currentTime > 86400f)
        {
            daysPassed += 1;
            currentTime -= 86400f;
        }

        //Rotation Updates
        if (_previousRotation == -1f)
        {
            _solTransform.eulerAngles = Vector3.zero;
            _previousRotation = 0f;
        }
        else
        {
            _previousRotation = _rotation;
        }

        _rotation = (currentTime - 21600f) / 86400f * 360f; // 86400/4 = 21600
        _solTransform.Rotate(_direction, _rotation - _previousRotation);

        //Sol Intensity Updates
        if (currentTime < _sunrise)
        {
            _intensity =
                IntensityAtSunSet * currentTime / _sunrise;
        }
        else if (currentTime < 43200f)
        {
            _intensity =
                IntensityAtSunSet + (IntensityAtNoon - IntensityAtSunSet)
                * (currentTime - _sunrise) / (43200f - _sunrise);
        }
        else if (currentTime < _sunset)
        {
            _intensity =
                IntensityAtNoon + (IntensityAtNoon - IntensityAtSunSet)
                * (currentTime - 43200f) / (_sunset - 43200f);
        }
        else
        {
            _intensity =
                IntensityAtSunSet - (1f - IntensityAtSunSet)
                * (currentTime - _sunset) / (86400f - _sunset);
        }
        
        RenderSettings.fogColor = 
            Color.Lerp(_fogColorNight, _fogColorDay, _intensity * _intensity);
        if (_sol != null) {_sol.intensity = _intensity;}
    }
    
    
    
    
    
    //Converts Vector3 Times to a Float
    private float HRS_ToTime(float hour, float minute, float second)
    {
        return 3600 * hour + 60 * minute + second;
    }
}
