using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public static class UI
    {
        public static void DisplayHit()
        {
            Console.WriteLine("\r\nIT'S A HIT!");

        }
        public static void DisplayMiss()
        {
            Console.WriteLine("\r\nIt's A Miss.");
        }
    }
}