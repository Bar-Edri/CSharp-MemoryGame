using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MemoryGameLogic
{
    public class Cell : Button , ICell
    {
        private static readonly string m_imagePath = Directory.GetCurrentDirectory();

        private static string Path
        {
            get { return m_imagePath; }
        }
        string m_Name = string.Empty;
        public Cell(string name)
        {
            CellName = name;
        }
        public string CellName
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        public void HideCell()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.BackgroundImage = System.Drawing.Image.FromFile(String.Format(@"{0}\questionMark.png", Path));
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Image = null;
        }
        public void ExposeCell()
        {
            this.BackgroundImage = null;
            this.Image = System.Drawing.Image.FromFile(String.Format(@"{0}\{1}.png", Path, this.Tag));
            this.Image = (Image)new Bitmap(this.Image, new Size(this.Width, this.Height));
        }
        public bool CheckCellsImageIsSimilar(Cell io_secondCell)
        {
            return this.Tag.Equals(io_secondCell.Tag) && this.CheckIfNotSameCell( io_secondCell);
        }
        public bool CheckIfNotSameCell( Cell io_secondCell)
        {
            return !this.CellName.Equals(io_secondCell.CellName);
        }
    }
}
