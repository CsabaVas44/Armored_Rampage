using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Turret : MonoBehaviour
{
    public List<Transform> turretBarels;
    public GameObject bulletPrefab;
    public float reloadDelay = 1;

    bool canShoot = true;
    Collider2D[] tankcolliders;
    public float currentDelay = 0;


    public UnityEvent OnShoot, OnCantShoot;
    public UnityEvent<float> OnRealoading;
    private void Start()
    {
        OnRealoading?.Invoke(currentDelay);
    }


    private void Awake()
    {
        tankcolliders = GetComponentsInParent<Collider2D>();

        if (DataHolder.TankLevel == 1)
        {
            reloadDelay = 0.5f;
        }
    }

    private void Update()
    {
        if(canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            OnRealoading?.Invoke(currentDelay);

            if(currentDelay <= 0)
            {
                canShoot = true;
            }
        }
    }



    public void Shoot()
    {
        if (!PauseMenu.isPaused)
        {
            if (canShoot)
            {
                canShoot = false;
                currentDelay = reloadDelay;

                foreach (var barrel in turretBarels)
                {


                    var hit = Physics2D.Raycast(barrel.position, barrel.up);
                    if (hit.collider != null)
                    {
                        Debug.Log(hit.collider.name);
                    }


                    GameObject bullet = Instantiate(bulletPrefab);
                    bullet.transform.position = barrel.position;
                    bullet.transform.localRotation = barrel.rotation;
                    bullet.GetComponent<Bullet>().Initialize();

                    if (DataHolder.TankLevel == 1)
                    {
                        GameObject bullet2 = Instantiate(bulletPrefab);
                        GameObject bullet3 = Instantiate(bulletPrefab);

                        bullet2.transform.position = barrel.position;
                        bullet2.transform.localRotation = barrel.rotation * Quaternion.Euler(0f, 0f, 10f);
                        bullet2.GetComponent<Bullet>().Initialize();

                        bullet3.transform.position = barrel.position;
                        bullet3.transform.localRotation = barrel.rotation * Quaternion.Euler(0f, 0f, -10f);
                        bullet3.GetComponent<Bullet>().Initialize();
                    }
                           

                    foreach (var collider in tankcolliders)
                    {
                        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider);
                    }
                }
                OnShoot?.Invoke();
                ScreenShake.Instance.ShakeCamera(3f, .1f,2f);
                OnRealoading?.Invoke(currentDelay);
            }
            OnCantShoot?.Invoke();
        }
    }
   
}
