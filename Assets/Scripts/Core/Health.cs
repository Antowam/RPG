using UnityEngine;

namespace RPG.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        float healthPoints = 100f;

        public bool isDead = false;

        public bool IsDead() { return isDead; }

        public void TakeDamage(float damage)
        {
            if (healthPoints > Mathf.Max(healthPoints - damage, 0))
            {
                healthPoints -= damage;
                print(healthPoints);

                if (healthPoints <= 0)
                    TriggerDeath();
            }
        }

        public void TriggerDeath()
        {
            if (isDead) return;

            isDead = true;
            GetComponent<Animator>().SetTrigger("Die");
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }
    }
}