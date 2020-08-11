using System;
using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public int currentBulletCountInMag;
    [SerializeField] private int m_maxBulletCount;

    public static string lookingAtString;

    public float FirePower
    {
        get { return config.firePower; }
    }
    public int RemainingAmmo
    {
        get
        {
            return m_maxBulletCount;
        }
    }

    [SerializeField] private GunConfig config;

    private AudioSource source;
    private LineRenderer gunLine;
    private Light gunLight;



    private float timer;
    [SerializeField] [Range(0, 1)] private float m_effectsDisplayTime = .2f;
    private bool canShoot = true;
    private float nextFire = 0.0f;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        gunLine = GetComponent<LineRenderer>();
        gunLight = GetComponentInChildren<Light>();
    }

    void Start()
    {
        currentBulletCountInMag = config.magazineSize;
        source.clip = config.gunshot;
    }

    void Update()
    {
        if(PauseMenu.GamePaused) return;

        timer += Time.deltaTime;

        if ((Input.GetButton("Fire1") || Input.GetButton("JShoot")) && Time.time > nextFire && canShoot)
            Shoot();

        if (timer >= config.fireRate * m_effectsDisplayTime)
            DisableEffects();

        if ((Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("JReload")) && m_maxBulletCount > 0)
            StartCoroutine(Reload());
    }

    public void DisableEffects()
    {
        // Disable the line renderer and the light. 
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    void Shoot()
    {
        // don't shoot if there is no ammo.
        if (currentBulletCountInMag <= 0)
            return;

        // reset the timer
        timer = 0f;

        // change audio clip to gun fire clip
        source.clip = config.gunshot;

        gunLight.enabled = true;
        gunLine.enabled = true;

        // update next fire var
        nextFire = Time.time + config.fireRate;

        // play the audio.
        source.Play();

        // make a ray that shoots forward from the barrel
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        gunLine.SetPosition(0, ray.origin);

        if (Physics.Raycast(ray, out hit, config.range))
        {
            
            if (hit.collider.tag == "enemy")
            {
                hit.collider.GetComponent<EnemyHealth>().TakeDamage(FirePower);
            }
            gunLine.SetPosition(1, hit.point);
        }
        else
        {
            // set the second position of the line renderer to the fullest extent of the gun's range.
            gunLine.SetPosition(1, ray.origin + ray.direction * config.range);
        }
        // remove a bullet from mag
        currentBulletCountInMag -= 1;

    }

    IEnumerator Reload()
    {
        // make sure the player can't shoot while reloading.
        canShoot = false;

        // temp var to calc how many bullets should be added.
        int bulletsToAdd;

        // change audio clip to reload clip the play.
        source.clip = config.reload;
        source.Play();

        // wait a second for the audio clip to finish playing.
        yield return new WaitForSeconds(1f);

        //calc how many bullets should be added.
        bulletsToAdd = Math.Min(m_maxBulletCount, config.magazineSize - currentBulletCountInMag);
        // add the amount of bullets to mag.
        currentBulletCountInMag += bulletsToAdd;
        // deduct that amount from the max amount of bullets you can carry.
        m_maxBulletCount -= bulletsToAdd;

        // allow the player to shoot
        canShoot = true;

    }
}
