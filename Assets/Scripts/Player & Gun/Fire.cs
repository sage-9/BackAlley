using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player___Gun
{
    public class Fire : MonoBehaviour
    {
        [Header("Gun Parameters")]
        [SerializeField] int maxAmmo = 12;
        [SerializeField] float reloadTime;
        [SerializeField] float fireInterval;
        [SerializeField] TMPro.TMP_Text ammoText;
    
        int _currentAmmo;
        bool _canFire = true;
        bool _isReloading;
        public static event Action AddScore; 
        public static event Action AddBullets;
    
        [Header("Projectile Parameters")]
        [SerializeField] private float spreadAmount;
        [SerializeField] GameObject hitSpark;
        [SerializeField] float forceAmount;
        
        [Header("Reference Utils")]
        [SerializeField] Transform cameraTransform;
        private Rigidbody _rb;
 
        void Start()
        {
            InputHandler.ShootAction += Shoot;
            InputHandler.ReloadAction += Reload;
            _rb = GetComponent<Rigidbody>();
            _currentAmmo = maxAmmo;
        }

        void OnDisable()
        {
            InputHandler.ShootAction -= Shoot;
            InputHandler.ReloadAction -= Reload;
        }


        void Shoot()
        {
            if (_currentAmmo <= 0) return;
            if(_isReloading) return;
            if(!_canFire) return;
            _currentAmmo--;
            AddBullets?.Invoke();
            bool collided=Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit);
            HandleCollision(collided,hit);
            StartCoroutine(nameof(HandleFireInterval));
            ammoText.text = _currentAmmo.ToString();
        }
        void HandleCollision(bool collided,RaycastHit hit)
        {
            if (collided)
            {
                Debug.Log($"{hit.collider.gameObject.name}");
                HitSparkEffect(hit);
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    Destroy(hit.collider.gameObject,0.1f);
                    AddScore?.Invoke();
                }
            }
        }

        IEnumerator HandleFireInterval()
        {
            _canFire=false;
            yield return new WaitForSeconds(fireInterval);
            _canFire=true;
        }

        void HitSparkEffect(RaycastHit raycastHit)
        {
            for (int i = 0; i < 15; i++)
            {
                Vector3 randomPositions = raycastHit.point + Random.insideUnitSphere * spreadAmount;
                GameObject sparks=Instantiate(hitSpark, randomPositions, Quaternion.LookRotation(raycastHit.normal));
                Destroy(sparks,1f);
            }
            _rb.AddExplosionForce(forceAmount, raycastHit.point, spreadAmount);
        }

        void Reload()
        {
            StartCoroutine(nameof(ReloadCoroutine));
        }

        IEnumerator ReloadCoroutine()
        {
            if (_isReloading) yield break;
            if(_currentAmmo>=maxAmmo)yield break;
            _isReloading = true;
            ammoText.text = "Reloading";
            yield return new WaitForSeconds(reloadTime);
            _currentAmmo = maxAmmo;
            ammoText.text = _currentAmmo.ToString();
            _isReloading = false;
        }
    
    }
}
