using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UraniaStarManager : MonoBehaviour
{
    //Research using: https://medium.com/microsoft-design/building-a-virtual-sky-883d4d1080f4
    
    void GenerateNightSky()
    {
        float
            x = 0.0f,
            y = 0.0f,
            z = 0.0f,
            ra = 0.0f,
            dec = 0.0f,
            r = 1000.0f; //(r is the night sky radius)
        //  mag = 0.0f;

/*        GetComponent<ParticleSystem>().GetParticles(particleStars);

        for (int a = 0; a < maxParticles; a++)
        {
            ra = starDatabase.star_Database[a].ra * -15.0f * deg2rad;
            dec = starDatabase.star_Database[a].dec * deg2rad;
            SphericalToCartesian(ra, dec, r, ref x, ref y, ref z);
            particleStars[a].position = new Vector3(x, y, z);
            particleStars[a].remainingLifetime = Mathf.Infinity;
            particleStars[a].startSize = 2.0f * (8.0f - starDatabase.star_Database[a].mag);
            particleStars[a].startColor = Color.white * 0.1f * (8.0f - starDatabase.star_Database[a].mag);
        }
        
        GetComponent<ParticleSystem>().SetParticles(particleStars, maxParticles); */
    }

    void SphericalToCartesian( float ra, float dec, float r, ref float x, ref float y, ref float z)
    {
        dec = (Mathf.PI / 2) - dec;
        var rr = r * Mathf.Sin(dec);
        
        //x y z Conversions
        z = rr * Mathf.Cos(ra);
        x = rr * Mathf.Sin(ra);
        y = r * Mathf.Cos(dec);
    }
}
