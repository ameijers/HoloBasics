using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : UIControlBase
{
    [Header("Button")]
    public GameObject Target;
    public string TargetMethod;
    public string Text;
    [Multiline(4)]
    public string Description;

    protected override void OnInit()
    {
        base.OnInit();
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
    }

    private void UpdateUI(GameObject button)
    {
        Dictionary<string, TextMesh> result = new Dictionary<string, TextMesh>();

        TextMesh[] textMeshes = button.GetComponentsInChildren<TextMesh>();
        foreach (TextMesh textMesh in textMeshes)
        {
            result[textMesh.gameObject.name] = textMesh;
        }

        if (result.ContainsKey("Text"))
        {
            result["Text"].text = Text;
        }

        if (result.ContainsKey("Description"))
        {
            result["Description"].text = Description;
        }
    }

    protected override void UpdateUI()
    {
        UpdateUI(buttonEnabledUI);
        UpdateUI(buttonDisabledUI);
        UpdateUI(buttonFocussedUI);

        base.UpdateUI();
    }

    protected override void LoadButtonUIElements()
    {
        base.LoadButtonUIElements();
    }

    public virtual object MessageValue
    {
        get
        {
            return this as UIControlBase;
        }
    }

    public override void OnButtonClicked()
    {
        base.OnButtonClicked();

        if (Target != null && TargetMethod != null)
        {
            Target.SendMessage(TargetMethod, MessageValue);
        }
    }

    // Use this for initialization
    void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }
}
