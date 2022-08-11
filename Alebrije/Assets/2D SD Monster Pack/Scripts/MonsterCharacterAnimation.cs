using System;
using UnityEngine;

public abstract class MonsterCharacterAnimation : MonoBehaviour
{
    protected bool IsDead;
    protected Animator Animator;

    public MonsterActing MonsterActing { get; protected set; }

    protected void Start()
    {
        Animator = GetComponent<Animator>();
        SetAnimation(MonsterActing.Idle);
    }

    public void Attack() => SetAnimation(MonsterActing.Attack);
    public void Bow() => SetAnimation(MonsterActing.Bow);
    public void Smash() => SetAnimation(MonsterActing.Smash);
    public void Stab() => SetAnimation(MonsterActing.Stab);
    public void Swing() => SetAnimation(MonsterActing.Swing);
    public void Buffdown() => SetAnimation(MonsterActing.Buffdown);
    public void Buffup() => SetAnimation(MonsterActing.Buffup);
    public void Dance1() => SetAnimation(MonsterActing.Dance1);
    public void Dance2() => SetAnimation(MonsterActing.Dance2);
    public void Dance3() => SetAnimation(MonsterActing.Dance3);
    public void Die() => SetAnimation(MonsterActing.Die);
    public void Duck() => SetAnimation(MonsterActing.Duck);
    public void Fall() => SetAnimation(MonsterActing.Fall);
    public void Fly() => SetAnimation(MonsterActing.Fly);
    public void Ground() => SetAnimation(MonsterActing.Ground);
    public void Happy() => SetAnimation(MonsterActing.Happy);
    public void Hurt() => SetAnimation(MonsterActing.Hurt);
    public void Idle() => SetAnimation(MonsterActing.Idle);
    public void Jump() => SetAnimation(MonsterActing.Jump);
    public void Laugh() => SetAnimation(MonsterActing.Laugh);
    public void Leap() => SetAnimation(MonsterActing.Leap);
    public void Pull() => SetAnimation(MonsterActing.Pull);
    public void Push() => SetAnimation(MonsterActing.Push);
    public void Roll() => SetAnimation(MonsterActing.Roll);
    public void Run() => SetAnimation(MonsterActing.Run);
    public void Sad() => SetAnimation(MonsterActing.Sad);
    public void Sit() => SetAnimation(MonsterActing.Sit);
    public void Slide() => SetAnimation(MonsterActing.Slide);
    public void Spring() => SetAnimation(MonsterActing.Spring);
    public void Sleep() => SetAnimation(MonsterActing.Sleep);
    public void Walk() => SetAnimation(MonsterActing.Walk);

    public void PlayAnimationComplete()
    {
        SetAnimation(MonsterActing.Idle);
    }

    protected abstract void SetAnimation(MonsterActing Monsteracting);
}
