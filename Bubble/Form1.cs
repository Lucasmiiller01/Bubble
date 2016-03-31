using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;


namespace Bubble
{
    public partial class Form1 : Form
    {
        
        private Random random = new Random();
        private bool finished1;
        public Form1()
        {
            finished1 = true;
            InitializeComponent();
            chart1.Series.Clear();
        }
        private void Start()
        {
            if (finished1)
            {
                finished1 = false;
                chart1.Series.Clear();
               

            }
        }
    
        private void StartBubble(object sender, EventArgs e)
        {
            Start();
        }
        int[] GenerateArray(int length)
        {
            int[] myReturn = new int[length];
            for (int i = 0; i < length; i++)
            {
                myReturn[i] = RandomElements(myReturn[i], myReturn, i);
            }
            return myReturn;
        }
        int RandomElements(int i, int[] numbers, int myPosition)
        {
            i = random.Next(0, numbers.Length);
            for (int f = 0; f < myPosition; f++)
            {
                if (i.Equals(numbers[f]))
                {
                    i = RandomElements(i, numbers, myPosition);
                }
            }

            return i;
        }
    }
}
