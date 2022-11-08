using System;
using System.Collections.Generic;

namespace DamkaGameLogic
{
    internal class AI
    {
        internal static Move GetBestComputerMove(Game i_GameToFindMove)
        {
            Move bestComputerMove = null;
            List<Move> allPossibleMoves = getAllPossibleMove(i_GameToFindMove);
            foreach (Move move in allPossibleMoves)
            {
                if (move.HadEat())
                {
                    bestComputerMove = move;
                    break;
                }
            }

            if (bestComputerMove == null && allPossibleMoves.Count != 0)
            {
                Random rand = new Random();
                int randomIndex = rand.Next(0, allPossibleMoves.Count);
                bestComputerMove = allPossibleMoves[randomIndex];
            }

            return bestComputerMove;
        }

        private static List<Move> getAllPossibleMove(Game i_GameToFindMoves)
        {
            List<Move> allPossibleMoves = new List<Move>();
            foreach (Square squareStart in i_GameToFindMoves.Board.SquareBoard)
            {
                if (squareStart.GameToolsType == i_GameToFindMoves.CurrentTurnPlayer.ToolsTypes[0]
                    || squareStart.GameToolsType == i_GameToFindMoves.CurrentTurnPlayer.ToolsTypes[1])
                {
                    foreach (Square squareTarget in i_GameToFindMoves.Board.SquareBoard)
                    {
                        Move possibleMove = new Move(i_GameToFindMoves.CurrentTurnPlayer, squareStart, squareTarget);
                        if (i_GameToFindMoves.IsValidMove(possibleMove))
                        {
                            allPossibleMoves.Add(possibleMove);
                        }
                    }
                }
            }

            return allPossibleMoves;
        }
    }
}
