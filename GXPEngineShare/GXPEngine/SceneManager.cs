using System;
using GXPEngine;

public class SceneManager : GameObject
{
    public Menu _menu { get; private set; }

    public HUD _gameHUD { get; private set; }

    public Environment _environment { get; private set; }

    public Residence _penguinResidence;

    public SceneManager()
    {
        _menu = new Menu();
        AddChild(_menu);

        _penguinResidence = new Residence();
        _penguinResidence.x = game.width / 2;

        _gameHUD = new HUD();
    }

    private void Update()
    {
        CheckLevelStart();
        CheckResidenceActivity();
        CheckGameReset();
    }

    private void CheckLevelStart()
    {
        if (_menu.levelStarted)
        {
            _environment = new Environment();
            AddChild(_environment);
            AddChild(_gameHUD);
            _menu.levelStarted = false;
            RemoveChild(_menu);
        }
    }

    private void CheckGameReset()
    {
        if (_gameHUD.backToMainMenu)
        {
            _menu = new Menu();
            AddChild(_menu);
            RemoveChild(_environment);
            _gameHUD.backToMainMenu = false;
        }
    }

    private void CheckResidenceActivity()
    {
        if (_environment != null)
        {
            if (_environment.residenceActive)
            {
                AddChild(_penguinResidence);
                RemoveChild(_environment);
            }

        }

        if (_gameHUD.mainAreaActive)
        {
            AddChild(_environment);
            RemoveChild(_penguinResidence);
        }
    }
}
