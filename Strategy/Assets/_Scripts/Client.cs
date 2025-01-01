using System.Collections;
using System.Collections.Generic;
using Strategies;
using UnityEngine;
using TMPro;

public class Client : MonoBehaviour
{
    public TMP_Text Leaderboard;
    public List<Player> Players;

    private LeaderboardContext _context;

    void Start()
    {
        _context = new LeaderboardContext();

        List<Player> defaultList = _context.SortPlayers(Players);
        
        UpdateLeaderboard(defaultList);
    }

    public void RankSort()
    {
        _context = new LeaderboardContext(new TopRankSort());

        List<Player> rankedList = _context.SortPlayers(Players);
        
        UpdateLeaderboard(rankedList);
    }

    public void AlphabeticalSort()
    {
        _context = new LeaderboardContext(new AlphabeticalSort());

        List<Player> alphabetList = _context.SortPlayers(Players);
        
        UpdateLeaderboard(alphabetList);
    }

    private void UpdateLeaderboard(List<Player> players)
    {
        Leaderboard.text = "";

        for (int i = 0; i < players.Count; i++)
        {
            Leaderboard.text += $"#{i + 1}: {players[i].name}\n\n";
        }
    }
}