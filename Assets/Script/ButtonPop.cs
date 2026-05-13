using UnityEngine;

public class ButtonPop : MonoBehaviour
{
    public Animator animator;

    public void PlayAnimation()
    {
        animator.Play("ButtonPop");
    }
}