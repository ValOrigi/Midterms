using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    public Transform spawnBulletHere;
    public GameObject redBulletPrefab, blueBulletPrefab, greenBulletPrefab;
    public float bulletSpeed = 5f;
    public float fireRate = 2.5f;
    private float baseFireRate;

    private Renderer rend;
    public Color[] colors;
    public int colorIntPlayerBullet;

	public Transform target;
    public float range = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        baseFireRate = fireRate;
        colorIntPlayerBullet = 0;
    }

    // Update is called once per frame
    void Update()
    {
        fireRate -= Time.deltaTime;
        if ( fireRate <= 0 )
        {
            Shoot();
        }
        
        target = GameObject.FindWithTag("Enemy").transform;
        if(Vector3.Distance(transform.position, target.position) <= range)
        {
        transform.LookAt(target);
        }
    }

    private void OnMouseUp()
    {
        ChangeColor();
    }

    void Shoot()
    {
        GameObject bullet;
        Rigidbody bulletRB;

        switch (colorIntPlayerBullet)
        {
            case 0:
                bullet = Instantiate(redBulletPrefab, spawnBulletHere.position, spawnBulletHere.rotation);
                bulletRB = bullet.GetComponent<Rigidbody>();
                bulletRB.AddForce(spawnBulletHere.forward * bulletSpeed, ForceMode.Impulse);
                break;
            case 1:
                bullet = Instantiate(blueBulletPrefab, spawnBulletHere.position, spawnBulletHere.rotation);
                bulletRB = bullet.GetComponent<Rigidbody>();
                bulletRB.AddForce(spawnBulletHere.forward * bulletSpeed, ForceMode.Impulse);
                break;
            case 2:
                bullet = Instantiate(greenBulletPrefab, spawnBulletHere.position, spawnBulletHere.rotation);
                bulletRB = bullet.GetComponent<Rigidbody>();
                bulletRB.AddForce(spawnBulletHere.forward * bulletSpeed, ForceMode.Impulse);
                break;
        }

        fireRate = baseFireRate;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red") || other.CompareTag("Blue") || other.CompareTag("Green"))
        {
            Destroy(gameObject);
        }

    }

    void ChangeColor()
    {
        if (colorIntPlayerBullet < 2)
        {
            colorIntPlayerBullet += 1;
            rend.material.color = colors[colorIntPlayerBullet];
        }

        else if (colorIntPlayerBullet == 2)
        {
            colorIntPlayerBullet = 0;
            rend.material.color = colors[colorIntPlayerBullet];
        }
    }
}
