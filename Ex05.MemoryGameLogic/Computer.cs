using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGameLogic
{
    public class Computer : Player
    {
        private List<Cell> m_remainingCells = new List<Cell>();
        private List<Cell> m_computerMemory = new List<Cell>();
        public Computer(string i_Name= "- computer -") : base("- computer -")
        {
        }
        public List<Cell> OpenedCells
        {
            get { return m_remainingCells; }
        }
        public Cell AddToMemory
        {
            set
            {
                m_computerMemory.Add(value);
            }
        }
        public List<Cell> MemoryOfCells
        {
            get { return m_computerMemory; }
        }
    }
}
