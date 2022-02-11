using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    //singleton
    private static GameplayManager s_Instance = null;    
    public static GameplayManager Instance
    {
        get { return s_Instance; }
    }

    [Header("Game")]
    [SerializeField]
    private GameObject m_GameGroup;
    [SerializeField]
    private bool m_IsCPU;

    [Header("Game Over")]
    [SerializeField]
    private GameObject m_GameOverGroup;
    [SerializeField]
    private UnityEngine.UI.Text m_UITextWinner;

    [Header("Score")]
    [SerializeField]
    private UnityEngine.UI.Text[] m_UITextScore = new UnityEngine.UI.Text[2];

   [SerializeField]
    private int m_EndGameScore;

    private int[] m_Score;

    private bool m_IsGameOver;


    public enum PlayerType
    {
        P1 = 0,
        P2
    }

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
        SetGameOver(false);
    }

    private void SetGameOver(bool isGameOver)
    {
        m_IsGameOver = isGameOver;
        m_GameGroup.SetActive(!m_IsGameOver);
        m_GameOverGroup.SetActive(m_IsGameOver);
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
        if(m_IsCPU)
        {
            if((int)GetWinner() == 1)
            {
                m_UITextWinner.text = "Vencedor CPU";
            }
            else
            {
                m_UITextWinner.text = "Vencedor Player 1";
            }            
        }
        else
        {
            m_UITextWinner.text = "Vencedor Player " + ((int)GetWinner() + 1);
        }        
        SetGameOver(true);        
    }

    void Update()
    {
        if  ((Input.GetKeyDown(KeyCode.Escape)) ||
             (m_IsGameOver && Input.anyKeyDown))
            {
                SceneManager.LoadScene("Menu");
            }
        
    }
}
