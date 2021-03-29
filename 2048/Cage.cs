using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _2048 {
    public partial class Cage : UserControl {

        public Cage() {
            InitializeComponent();
            font = new Font("Google Sans", 28, FontStyle.Regular);
            Colors = new Dictionary<int, Color>() {
                { 2, Color.FromArgb(213,146,213) },
                { 4, Color.FromArgb(213,102,213) },
                { 8, Color.FromArgb(181,72,181) },
                { 16, Color.FromArgb(146,213,194) },
                { 32, Color.FromArgb(102,213,182) },
                { 64, Color.FromArgb(72,181,150) },
                { 128, Color.FromArgb(213,165,146) },
                { 256, Color.FromArgb(213,124,102) },
                { 512, Color.FromArgb(181,90,72) },
                { 1024, Color.FromArgb(205,181,100) },
                { 2048, Color.FromArgb(205,169,52) },
                { 4096, Color.FromArgb(249,192,5) },
            };
        }

        public Dictionary<int, Color> Colors { get; set; }

        public int Number { get; set; }

        public bool CanMix { get; set; } = true;

        public void ApplyNumber() {
            Text = Number.ToString();
            BackColor = Colors[NearbyNumber(Number)];
        }

        private int NearbyNumber(int number) {
            bool isHaveNumber = Colors.ContainsKey(number);
            if (isHaveNumber)
                return number;
            else {
                List<int> numList = Colors.Keys.ToList();
                int minNumber = numList[0];
                foreach (int num in numList)
                    if (Math.Abs(num - number) < Math.Abs(number - minNumber))
                        minNumber = num;
                return minNumber;
            }
        }

        public Point Position { get; set; }

        public override String Text {
            get {
                return label1.Text;
            }
            set {
                label1.Text = value;
            }
        }

        private Font font { get; set; }
        public override Font Font {
            get {
                return font;
            }
            set {
                font = value;
                label1.Font = font;
            }
        }

        private Color foreColor { get; set; }
        public override Color ForeColor {
            get {
                return foreColor;
            }
            set {
                foreColor = value;
                label1.ForeColor = foreColor;
            }
        }

        public bool IsBackground { get; set; }

        public int Radius {
            get {
                return bunifuElipse1.ElipseRadius;
            }
            set {
                bunifuElipse1.ElipseRadius = value;
            }
        }
    }
}
