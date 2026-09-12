using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float damage = 25f;
    [SerializeField] private float range = 150f;
    [SerializeField] private float fireRate = 8f;
    [SerializeField] private int magazineSize = 30;
    [SerializeField] private float reloadTime = 1.8f;
    [SerializeField] private LayerMask hitMask = ~0;

    private int ammo;
    private float nextFireTime;
    private bool reloading;

    private void Awake()
    {
        ammo = magazineSize;
        if (playerCamera == null)
            playerCamera = Camera.main;
    }

    private void Update()
    {
        if (reloading) return;

        if (Input.GetButton("Fire1"))
            TryShoot();

        if (Input.GetKeyDown(KeyCode.R) || ammo <= 0)
            StartCoroutine(Reload());
    }

    private void TryShoot()
    {
        if (Time.time < nextFireTime || ammo <= 0 || playerCamera == null)
            return;

        nextFireTime = Time.time + 1f / fireRate;
        ammo--;

        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, range, hitMask, QueryTriggerInteraction.Ignore))
        {
            EnemyHealth enemy = hit.collider.GetComponentInParent<EnemyHealth>();
            if (enemy != null)
                enemy.TakeDamage(damage);
        }
    }

    private IEnumerator Reload()
    {
        if (reloading || ammo == magazineSize)
            yield break;

        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        ammo = magazineSize;
        reloading = false;
    }

    public int GetAmmo() => ammo;
    public int GetMagazineSize() => magazineSize;
    public bool IsReloading() => reloading;
}
