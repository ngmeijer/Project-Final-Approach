using System;
using GXPEngine;

public class MyGame : Game
{
	private SceneManager _sceneManager;

	private Menu _menu;

	public MyGame() : base(1920, 1080, false)
	{
		_sceneManager = new SceneManager();
		AddChild(_sceneManager);
	}

	static void Main()
	{
		new MyGame().Start();
	}
}