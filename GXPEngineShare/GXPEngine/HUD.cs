using System;
using GXPEngine;

public class HUD : GameObject
{
    private BackButton _backButton;
    public StartButton _backToMenuButton { get; set; }

    public bool clickedBack { get; set; }

    public bool mainAreaActive { get; set; }

    public bool backToMainMenu { get; set; }

    public HUD()
    {
        _backButton = new BackButton();
        AddChild(_backButton);
    }

    private void Update()
    {
        CheckForBackRequest();
    }

    private void CheckForBackRequest()
    {
        if (_backButton.HitTestPoint(Input.mouseX, Input.mouseY))
        {
            if (Input.GetMouseButtonDown(0))
            {
                clickedBack = true;
                mainAreaActive = true;
            }
        }
    }
}
