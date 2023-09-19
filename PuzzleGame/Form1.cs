namespace PuzzleGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int movesNumber = 0, labelIndex = 0;

        private void shuffleButtons()
        {
            List<int> labelList = new List<int>();

            Random rand = new Random();
            foreach (Button btn in this.pnl.Controls)
            {
                while (labelList.Contains(labelIndex))
                    labelIndex = rand.Next(16);
                
                btn.Text = (labelIndex == 0) ? "" : labelIndex + "";
                btn.BackColor = (btn.Text == "") ? Color.White : Color.FromKnownColor(KnownColor.ControlLight);
                labelList.Add(labelIndex);
            }
            movesNumber = 0;
            lblNOfMoves.Text = "Number of moves: " + movesNumber;
        }

        private void swapLabel(Object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "")
                return;
            
            Button whiteBtn = null;
            foreach (Button bt in this.pnl.Controls)
            {
                if (bt.Text == "")
                {
                    whiteBtn = bt;
                    break;

                }
            }

            if (btn.TabIndex == (whiteBtn.TabIndex - 1) ||
                 btn.TabIndex == (whiteBtn.TabIndex - 4) ||
                 btn.TabIndex == (whiteBtn.TabIndex + 1) ||
                 btn.TabIndex == (whiteBtn.TabIndex + 4))
            {
                whiteBtn.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
                btn.BackColor = Color.White;
                whiteBtn.Text = btn.Text;
                btn.Text = "";
                movesNumber++;
                lblNOfMoves.Text = "Number of moves: " + movesNumber;
            }

            CheckOrder();
        }

        private void CheckOrder()
        {
            int index = 1;
            foreach (Button btn in this.pnl.Controls)
            {
                if (btn.Text !="" && Convert.ToInt16(btn.Text) != index)
                {
                    return;
                }
                index++;
            }
            BackColor = Color.Green;
            MessageBox.Show("Congrats ! you did it in " + movesNumber + "moves");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            shuffleButtons();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            shuffleButtons();

        }
    }
}