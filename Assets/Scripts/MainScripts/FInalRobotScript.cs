using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FInalRobotScript : MonoBehaviour
{
    public static FInalRobotScript instance;

    private void Awake()
    {
        instance = this;
    }

    public string sceneToLoad;

    public int RequiredTool;
    private SpriteRenderer spriteRenderer;
    public Sprite lockedSprite;
    public Sprite UnlockedSprite;
    public View view;
    public View PView;
    private bool IsComplete = false;
    // Start is called before the first frame update
    void Start()
    {
        if (view == null)
        {
            Debug.LogWarning(gameObject.name + "has no set view!");
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = lockedSprite;
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (PlayerData.Instance.ToolStates[RequiredTool] == true)
            {
                UnlockDoor();
            }
            else
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Can't Open Dialogue");
                //Debug.Log("I can't Seem to open it yet...");
                SubtitleManager.instance.DoDialogue("I can't seem to open it yet...");
            }
        }
    }

    public static void GoToFinalScene()
    {
        ViewManager.Instance.ChangeView(instance.view);

    }


    void UnlockDoor()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Door Hiss");
        AdditiveSceneManager.Instance.LoadScene(sceneToLoad, PView.gameObject);
        //IsComplete = true;
        spriteRenderer.sprite = UnlockedSprite;
    }
}
