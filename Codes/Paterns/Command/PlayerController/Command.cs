using System.Collections;
using UnityEngine;

public abstract class Command
{
    public abstract void Excute(Animator anim, bool forward);
}

public class PerformMoveForward : Command
{
    public override void Excute(Animator anim, bool forward)
    {
        if (forward)
        {
            anim.SetTrigger("isWalking");
        }
        else
        {
            anim.SetTrigger("isWalkingR");
        }
    }
}
public class PerformJump: Command
{
    public override void Excute(Animator anim, bool forward)
    {
        if (forward)
        {
            anim.SetTrigger("isJumping");
        }
        else
        {
            anim.SetTrigger("isJumpingR");
        }
    }
}
public class PerformKick : Command
{
    public override void Excute(Animator anim, bool forward)
    {
        if (forward)
        {
            anim.SetTrigger("isKicking");
        }
        else
        {
            anim.SetTrigger("isKickingR");
        }
    }
}
public class PerformPunch : Command
{
    public override void Excute(Animator anim, bool forward)
    {
        if (forward)
        {
            anim.SetTrigger("isPunching");
        }
        else
        {
            anim.SetTrigger("isPunchingR");
        }
    }
}
public class DoNothing : Command
{
    public override void Excute(Animator anim, bool forward)
    {

    }
}