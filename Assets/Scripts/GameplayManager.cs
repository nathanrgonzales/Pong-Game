using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    //singleton
    private static GameplayManager s_Instance = null;    
    public static GameplayManager Instance
    {
        get { return s_Instance; }
    }

    [Header("Score")]
    [SerializeField]
    private UnityEngine.UI.Text[] m_UITextScore = new UnityEngine.UI.Text[2];

    void Awake()
    {
        if(s_Instance == null)
        {
            s_Instance = this;
        }
        else if(s_Instance != this)        
        {
            Destroy(gameObject);
        }
    }

    public enum PlayerType
    {
        P1 = 0,
        P2
    }

    [SerializeField]
    private int m_EndGameScore;

    private int[] m_Score;

    private bool m_IsGameOver;

    void Start()
    {
        m_Score = new int[2];
        ResetScore();
    }
    
    public void ResetScore()
    {
        m_Score[0] = 0;
        m_Score[1] = 0;
        m_UITextScore[0].text = m_Score[0].ToString();
        m_UITextScore[1].text = m_Score[1].ToString();
        m_IsGameOver = false;
    }

    public void IncScore(PlayerType player)
    {
        int index = (int)player;
        ++m_Score[index];
        m_UITextScore[index].text = m_Score[index].ToString();
        
        if(m_Score[index] == m_EndGameScore)
        {
            GameOver();
        }
    }

    public int GetScore(PlayerType player)
    {
        return m_Score[(int)player];
    }

    public PlayerType GetWinner()
    {
        return m_Score[0] > m_Score[1] ? PlayerType.P1 : PlayerType.P2;
    }

    public void GameOver()
    {
        Debug.Log("GameOver: Winner - " + GetWinner());
        m_IsGameOver = true;
    }

    void Update()
    {
        
    }
}
