using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Strategies
{
    public interface ISortStrategy
    {
        public List<Player> Sort(List<Player> players);
    }
    
    public class DefaultSort : ISortStrategy
    {
        public List<Player> Sort(List<Player> players)
        {
            Debug.Log("Don't do anything, leave order as it is!");

            return players;
        }
    }
    
    public class TopRankSort : ISortStrategy
    {
        public List<Player> Sort(List<Player> players)
        {
            Debug.Log("Sort by rank.");

            return players.OrderBy(p => p.Rank).ToList();
        }
    }
    
    public class AlphabeticalSort : ISortStrategy
    {
        public List<Player> Sort(List<Player> players)
        {
            Debug.Log("Sort by alphabetical letter");
            
            players.Sort((first, second) => string.Compare(first.name, second.name));

            return players.ToList();
        }
    }
}