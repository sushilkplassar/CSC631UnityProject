using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanProjectile : MonoBehaviour
{

    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public RotateToMouse rotateToMouse;
    private float timetoFire = 0;

    private GameObject effectToSpawn;


    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = vfx[0];
     }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && Time.time >= timetoFire)
        {
            timetoFire = Time.time + 1 / effectToSpawn.GetComponent < ProjectileMove>().fireRate;
            spawnVFX();
        }
    }

    void spawnVFX()
    {
        GameObject vfx;
        if(firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            if(rotateToMouse != null)
            {
                vfx.transform.localRotation = rotateToMouse.GetRotation();
            }
        }
        else
        {
            Debug.Log("No Fire Point");
        }
    }
}
