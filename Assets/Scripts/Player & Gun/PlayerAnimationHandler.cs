using UnityEngine;


namespace Player___Gun
{
    public class PlayerAnimationHandler : MonoBehaviour
    {
        private static readonly int Shoot = Animator.StringToHash("Shoot");
        private static readonly int Reload = Animator.StringToHash("Reload");
        [SerializeField] private Animator playerAnimator;
        
        void Start()
        {
            InputHandler.ShootAction += TriggerShoot;
            InputHandler.ReloadAction += TriggerReload;
           
        }

        private void OnDisable()
        {
            InputHandler.ShootAction -=TriggerShoot;
            InputHandler.ReloadAction -=TriggerReload;
        }

        void TriggerShoot()
        {
            playerAnimator.SetTrigger(Shoot);
        }

        void TriggerReload()
        {
            playerAnimator.SetTrigger(Reload);
        }
    }
}
