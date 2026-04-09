using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private AnimationActions _anim;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private int _damage = 10;

    public void AttackHero()
    {
        _anim.TriggerAttack();
        _playerHealth.Reduce(_damage);
    }
}