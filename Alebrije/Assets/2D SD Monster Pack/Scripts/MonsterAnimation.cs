using System;
using UnityEngine;

public class MonsterAnimation : MonsterCharacterAnimation
{

    protected override void SetAnimation(MonsterActing Monsteracting)
    {
        if (IsDead)
        {
            return;
        }

        MonsterActing = Monsteracting;
        switch (Monsteracting)
        {
            case MonsterActing.Attack:
                Animator.Play("attack");
                break;
            case MonsterActing.Bow:
                Animator.Play("attack-bow");
                break;
            case MonsterActing.Smash:
                Animator.Play("attack-smash");
                break;
            case MonsterActing.Stab:
                Animator.Play("attack-stab");
                break;
            case MonsterActing.Swing:
                Animator.Play("attack-swing");
                break;
            case MonsterActing.Buffdown:
                Animator.Play("buff-down");
                break;
            case MonsterActing.Buffup:
                Animator.Play("buff-up");
                break;
            case MonsterActing.Dance1:
                Animator.Play("dance1");
                break;
            case MonsterActing.Dance2:
                Animator.Play("dance2");
                break;
            case MonsterActing.Dance3:
                Animator.Play("dance3");
                break;
            case MonsterActing.Die:
                Animator.Play("die");
                break;
            case MonsterActing.Duck:
                Animator.Play("duck");
                break;
            case MonsterActing.Fall:
                Animator.Play("fall");
                break;
            case MonsterActing.Fly:
                Animator.Play("fly");
                break;
            case MonsterActing.Ground:
                Animator.Play("ground");
                break;
            case MonsterActing.Happy:
                Animator.Play("happy");
                break;
            case MonsterActing.Hurt:
                Animator.Play("hurt");
                break;
            case MonsterActing.Idle:
                Animator.Play("idle");
                break;
            case MonsterActing.Jump:
                Animator.Play("jump");
                break;
            case MonsterActing.Laugh:
                Animator.Play("laugh");
                break;
            case MonsterActing.Leap:
                Animator.Play("leap");
                break;
            case MonsterActing.Pull:
                Animator.Play("pull");
                break;
            case MonsterActing.Push:
                Animator.Play("push");
                break;
            case MonsterActing.Roll:
                Animator.Play("roll");
                break;
            case MonsterActing.Run:
                Animator.Play("run");
                break;
            case MonsterActing.Sad:
                Animator.Play("sad");
                break;
            case MonsterActing.Sit:
                Animator.Play("sit");
                break;
            case MonsterActing.Slide:
                Animator.Play("slide-down");
                break;
            case MonsterActing.Spring:
                Animator.Play("spring");
                break;
            case MonsterActing.Sleep:
                Animator.Play("sleep");
                break;
            case MonsterActing.Walk:
                Animator.Play("walk");
                break;
        }
    }

}
