using System;
using GXPEngine;

public class SceneManager : GameObject
{
    public Menu _menu { get; private set; }

    public HUD _gameHUD { get; private set; }

    public Environment _environment { get; private set; }

    public Residence _penguinResidence;
    public Residence _zebraResidence;
    public Residence _seaLionResidence;
    public Residence _turtleResidence;
    public Residence _monkeyResidence;
    public Residence _lionResidence;
    public Residence _giraffeResidence;
    public Residence _hippoResidence;

    public bool residenceActive;

    public SceneManager()
    {
        _menu = new Menu();
        AddChild(_menu);

        _gameHUD = new HUD();
        AddChild(_gameHUD);
        _gameHUD.visible = false;

        _environment = new Environment();
        AddChild(_environment);
        _environment.x = 1920;


        //Animal residences
        _penguinResidence = new Residence();
        AddChild(_penguinResidence);
        _penguinResidence.x = 1920;

        //_zebraResidence = new Residence();
        //AddChild(_zebraResidence);
        //_zebraResidence.x = 1920;

        //_seaLionResidence = new Residence();
        //AddChild(_seaLionResidence);
        //_seaLionResidence.x = 1920;

        //_turtleResidence = new Residence();
        //AddChild(_turtleResidence);
        //_turtleResidence.x = 1920;

        //_monkeyResidence = new Residence();
        //AddChild(_monkeyResidence);
        //_monkeyResidence.x = 1920;

        //_lionResidence = new Residence();
        //AddChild(_lionResidence);
        //_lionResidence.x = 1920;

        //_giraffeResidence = new Residence();
        //AddChild(_giraffeResidence);
        //_giraffeResidence.x = 1920;

        //_hippoResidence = new Residence();
        //AddChild(_hippoResidence);
        //_hippoResidence.x = 1920;
        /////////////////////
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
            if (_menu.x < 1920)
            {
                _gameHUD.visible = true;
                _menu.x = 1920;
                _environment.x = 0;
            }
        }
    }

    private void CheckGameReset()
    {

    }

    private void CheckResidenceActivity()
    {
        if (_environment._penguinsActive)
        {
            Console.WriteLine("reached this");
            _penguinResidence._penguinActive = true;
            _penguinResidence.x = 0;
            _environment.x = 1920;
        }

        if (_gameHUD.clickedBack)
        {
            _environment._penguinsActive = false;
            _penguinResidence.x = 1920;
            _environment.x = 0;
            _gameHUD.clickedBack = false;
        }

        if (_environment._zebraActive)
        {
            _zebraResidence.x = 0;
            _environment.x = 1920;
        }

        if (_environment._seaLionActive)
        {
            _seaLionResidence.x = 0;
            _seaLionResidence._seaLionActive = true;
            _environment.x = 1920;
        }

        if (_environment._turtleActive)
        {
            _turtleResidence.x = 0;
            _environment.x = 1920;
            _environment._turtleActive = true;
        }

        if (_environment._monkeyActive)
        {
            _monkeyResidence.x = 0;
            _environment.x = 1920;
            _environment._monkeyActive = true;
        }

        if (_environment._lionActive)
        {
            _lionResidence.x = 0;
            _environment.x = 1920;
            _environment._lionActive = true;
        }

        if (_environment._giraffeActive)
        {
            _giraffeResidence.x = 0;
            _environment.x = 1920;
            _environment._giraffeActive = true;
        }

        if (_environment._hippoActive)
        {
            _hippoResidence.x = 0;
            _environment.x = 1920;
            _environment._hippoActive = true;
        }

        //////////////////////////////////////
        ///
    }
}
