using System;
using GXPEngine;

public class MyGame : Game
{
	private GameManager _sceneManager;

	public MyGame() : base(1920, 1080, false)
	{
		_sceneManager = new GameManager();
		AddChild(_sceneManager);
	}

	static void Main()
	{
		new MyGame().Start();
	}

	private void Update()
	{
		//Console.WriteLine(currentFps);
	}
}