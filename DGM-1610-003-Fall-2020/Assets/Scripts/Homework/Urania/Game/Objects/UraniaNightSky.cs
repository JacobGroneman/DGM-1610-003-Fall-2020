using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UraniaObject
{
    public string 
        name;

    public Vector3
        location;

    public Sprite
        sprite;
}

public class UraniaNightSky : MonoBehaviour
{
    //Organized By Distance
    public List<HomeStar> HomeStars;
    public List<HomeMoon> HomeMoons;
    public List<Satellite> Satellites;
    
    public List<Planet> Planets;
    public List<Comet> Comets;
    public List<Asteroid> Asteroids;
    
    public List<Star> Stars;
    public List<Nebula> Nebulae;
    public List<BlackHole> BlackHoles;
    
    //Outside System
    public List<Galaxy> Galaxies;
    
    //Anonymous
    public List<UAO> UAOs; //Unidentified Astronomical Object
    public List<Other> Others;
    public List<Creature> Creatures;
}

public class HomeStar : UraniaObject
{
   
}
