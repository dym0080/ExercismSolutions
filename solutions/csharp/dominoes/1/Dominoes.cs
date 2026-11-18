public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
         var list = dominoes.ToList();

        if (list.Count == 0)
        {
            return true;
        }

        return Backtrack(list, new List<(int, int)>());
    }

    private static bool Backtrack(
        List<(int, int)> remaining,
        List<(int, int)> chain)
    {
        if (remaining.Count == 0)
        {
            return chain[0].Item1 == chain[^1].Item2;
        }

        for (int i = 0; i < remaining.Count; i++)
        {
            var domino = remaining[i];

            foreach (var candidate in GetOrientations(domino))
            {

                if (chain.Count == 0 ||
                    chain[^1].Item2 == candidate.Item1)
                {
                    var nextRemaining = new List<(int, int)>(remaining);
                    nextRemaining.RemoveAt(i);

                    chain.Add(candidate);

                    if (Backtrack(nextRemaining, chain))
                    {
                        return true;
                    }

                    chain.RemoveAt(chain.Count - 1);
                }
            }
        }

        return false;
    }

    private static IEnumerable<(int, int)> GetOrientations((int, int) domino)
    {
        yield return domino;

        if (domino.Item1 != domino.Item2)
        {
            yield return (domino.Item2, domino.Item1);
        }
    }
}