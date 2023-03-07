using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    public GameObject Background;

    public void Launch() {
        if(Background != null) {
            Animator animator = Background.GetComponent<Animator>();
            if(animator != null) {
                animator.SetBool("launch", true);
            }
        }
    }

    public void Settings() {
        if(Background != null) {
            Animator animator = Background.GetComponent<Animator>();
            if(animator != null) {
                animator.SetBool("settingslaunch", true);
                animator.SetBool("settingsclosed", false);
            }
        }
    }

    public void SettingsClose() {
        if(Background != null) {
            Animator animator = Background.GetComponent<Animator>();
            if(animator != null) {
                animator.SetBool("settingslaunch", false);
                animator.SetBool("settingsvideosound", false);
                animator.SetBool("settingsclosed", true);
            }
        }
    }

    public void SettingsCommands()
    {
        if (Background != null)
        {
            Animator animator = Background.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("settingslaunch", false);
                animator.SetBool("settingscommands", true);
                animator.SetBool("settingscommandsclosed", false);
                animator.SetBool("settingsvideosound", false);
            }
        }
    }

    public void SettingsVideoSound()
    {
        if (Background != null)
        {
            Animator animator = Background.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("settingscommands", false);
                animator.SetBool("settingsclosed", false);
                animator.SetBool("settingsvideosound", true);
            }
        }
    }

    public void SettingsCommandsClose()
    {
        if (Background != null)
        {
            Animator animator = Background.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("settingscommands", false);
                animator.SetBool("settingscommandsclosed", true);
                animator.SetBool("settingsvideosound", false);
            }
        }
    }

    public void Quit() {
        if(Background != null) {
            Animator animator = Background.GetComponent<Animator>();
            if(animator != null) {
                animator.SetBool("quit_deny", false);
                animator.SetBool("quit", true);
            }
        }
    }

    public void QuitConfirm() {
        if(Background != null) {
            Animator animator = Background.GetComponent<Animator>();
            if(animator != null) {
                animator.SetBool("quit_confirm", true);
                StartCoroutine(_FadeSound(animator)); 
            }
        }
    }

    public void QuitDeny() {
        if(Background != null) {
            Animator animator = Background.GetComponent<Animator>();
            if(animator != null) {
                animator.SetBool("quit_deny", true);
                animator.SetBool("quit", false);
            }
        }
    }

    IEnumerator _FadeSound(Animator animator) {
    float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
    yield return new WaitForSecondsRealtime(animationLength);
    Application.Quit();
 }


}
