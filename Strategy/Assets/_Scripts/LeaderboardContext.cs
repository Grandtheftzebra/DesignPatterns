using System.Collections.Generic;
using Strategies;
using UnityEngine;

public class LeaderboardContext
{
    public ISortStrategy SortStrategy { get; set; }

    public LeaderboardContext(ISortStrategy strategy = null)
    {
        SortStrategy = strategy ?? new DefaultSort();
    }

    public List<Player> SortPlayers(List<Player> players) => SortStrategy.Sort(players);
}
