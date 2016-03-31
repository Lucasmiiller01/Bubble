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
        private Thread backgroundWorker1;
        private int valueToRand1, comparisons1;
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
                comparisons1 = 0;
                backgroundWorker1.IsBackground = true;
                backgroundWorker1.Start();

            }
        }
    
        private void StartBubble(object sender, EventArgs e)
        {
            Start();
        }
      
        private void BubbleSort(int[] data, int myThread)
        {
            for (int i = data.Length - 1; i >= 1; i--)
            {
                for (int j = 0; j < i; j++)
                {

                    if (data[j] > data[j + 1])
                    {
                        int aux = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = aux;
                        if (myThread.Equals(1))
                        {
                            comparisons1++;
                            for (int k = 0; k < data.Length; k++)
                            {
                                this.Invoke(new MethodInvoker(() =>
                                {

                                    if (k.Equals(j + 1) || k.Equals(j + 2))
                                        chart1.Series[0].Points[k].Color = Color.Red;
                                    else
                                        chart1.Series[0].Points[k].Color = Color.Black;
                                    chart1.Series[0].Points[k].SetValueXY(k, data[k]);
                                    label1.Text = "Comparisons: " + comparisons1;
                                }));
                            }
                        }
                      
                        Thread.Sleep(5);
                    }
                }
            }
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
