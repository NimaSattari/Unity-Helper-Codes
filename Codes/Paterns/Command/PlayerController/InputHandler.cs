using System.Collections;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    List<Command> oldCommands = new List<Command>();
    public GameObject actor;
    Animator anim;
    Command keyQ, keyW, keyK, keyP,keySpace;

    Coroutine replayCoroutine;
    bool shouldStartReplay;
    bool isReplaying;

    void Start()
    {
        keyQ = new DoNothing();
        keyW = new PerformMoveForward();
        keyK = new PerformKick();
        keyP = new PerformPunch();
        keySpace = new PerformJump();

        anim = actor.GetComponent<Animator>();
    }

    void Update()
    {
        if (!isReplaying)
        {
            HandleInput();
        }
        StartReplay();
    }
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            keyQ.Execute(anim, true);
            oldCommands.Add(keyQ);
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            keyW.Excute(anim, true);
            oldCommands.Add(keyW);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            keyK.Excute(anim, true);
            oldCommands.Add(keyK);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            keyP.Excute(anim, true);
            oldCommands.Add(keyP);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            keySpace.Excute(anim, true);
            oldCommands.Add(keySpace);
        }
        if (Input.GetKeyDown(KeyCode.Enter))
        {
            shouldStartReplay = true;
        }
        if (Input.GetKeyDown(KeyCode.BackSpace))
        {
            UndoLastCommand();
        }
    }

    void UndoLastCommand()
    {
        if(oldCommands.Count > 0)
        {
            Command c = oldCommands[oldCommands.Count - 1];
            c.Execute(anim, false);
            oldCommands.RemoveAt(oldCommands.Count - 1);
        }
    }

    void StartReplay()
    {
        if(shouldStartReplay && oldCommands.Count > 0)
        {
            shouldStartReplay = false;
            if (replayCoroutine != null)
            {
                StopCoroutine(replayCoroutine);
            }
            replayCoroutine = StartCoroutine(ReplayCommands());
        }
    }
    IEnumerator ReplayCommands()
    {
        isReplaying = true;

        for(int i = 0l i < oldCommands.Count; i++)
        {
            oldCommands[i].Execute(anim, true);
            yield return new WaitForSeconds(1f);
        }
        isReplaying = false;
    }
}