using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] AudioSource gameMusic;

	[SerializeField] float gameTimer;

	[Header("Events")]
	[SerializeField] EventRouter startGameEvent;
	[SerializeField] EventRouter stopGameEvent;
	[SerializeField] EventRouter winGameEvent;

	public enum State
	{
		TITLE,
		START_GAME,
		PLAY_GAME,
		GAME_FINISHED
	}

	State state = State.TITLE;
	float gameTime = 0;
	float stateTimer = 0;

	private void Start()
	{
		winGameEvent.onEvent += OnGameWin;
	}

	private void Update()
	{
		switch (state)
		{
			case State.TITLE:
				UIManager.Instance.ShowTitle(true);
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				gameTime = gameTimer;


				break;
				
			case State.START_GAME:
				UIManager.Instance.ShowTitle(false);
				Cursor.lockState = CursorLockMode.Locked;

				if (gameMusic != null) gameMusic.Play();
				state = State.PLAY_GAME;
				break;

			case State.PLAY_GAME:
				UIManager.Instance.ShowGameUI(true);

				gameTime -= Time.deltaTime;
				UIManager.Instance.SetTimer(gameTime);
				if (gameTime <= 0)
				{
					UIManager.Instance.ShowGameUI(false);
					SetGameFinish();
				}

				break;

			case State.GAME_FINISHED:
				
				UIManager.Instance.ShowGameFinish(true);
				stateTimer -= Time.deltaTime;
				if (stateTimer <= 0)
				{
					UIManager.Instance.ShowGameFinish(false);
					state = State.TITLE;
				}
				break;

			default:
				break;
		}
	}

	public void SetGameFinish()
	{
		gameMusic.Stop();
		state = State.GAME_FINISHED;
		stateTimer = 3;
	}

	public void OnStartGame()
	{
		state = State.START_GAME;
	}

    public void OnGameWin()
	{
		state = State.GAME_FINISHED;
	}
}
