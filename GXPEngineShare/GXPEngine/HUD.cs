using System;
using GXPEngine;

public class HUD : GameObject
{
    private BackButton _backButton;
    public StartButton _backToMenuButton { get; set; }

    private Environment _environment;

    public bool activeResidence {get; set;}
    public bool mainAreaActive {get; set; }

    public bool backToMainMenu { get; set; }


    public HUD()
    {
        _backButton = new BackButton();
        AddChild(_backButton);
        _backButton.visible = true;

        _backToMenuButton = new StartButton();
        AddChild(_backToMenuButton);
        _backToMenuButton.y += 100;
    }

    private void Update()
    {
        BackToMenu();
        CheckForResidenceActivity();
    }

    private void BackToMenu()
    {
        
    }

    private void CheckForResidenceActivity()
    {
        
    }
}
