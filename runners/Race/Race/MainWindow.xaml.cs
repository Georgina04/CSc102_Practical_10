using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Race
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
   


    public partial class MainWindow : Window
    {
        Dictionary<string,Runner> EnteredRunner = new Dictionary<string , Runner>();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        

        public string ShowInfo(string name)
        {
            return "" + EnteredRunner[name].RunnerName + "(" + EnteredRunner[name].RunnerTimeMin + ":" + EnteredRunner[name].RunnerTimeSec + ")";
        }
        private string ShowInfo(Runner rn)
        {
            return "" + rn.RunnerName + "(" + rn.RunnerTimeMin + ":" + rn.RunnerTimeSec + ")";
        }
        private Runner[] sortLst()
        {
            Runner[] lst = new Runner[EnteredRunner.Count];
            EnteredRunner.Values.CopyTo(lst, 0);
            Runner temporary;

            for (int w = 0; w < lst.Length; w++)
            {
                for (int s = 0; s < lst.Length - 1; s++)
                {
                    if (lst[s].RunnerTimeMin > lst[s + 1].RunnerTimeMin && lst[s].RunnerTimeSec > lst[s + 1].RunnerTimeSec)
                    {
                        temporary = lst[s + 1];
                        lst[s + 1] = lst[s];
                        lst[s] = temporary;
                    }
                }

            }
            return lst.ToArray();
        }
        

        private int AvMin()
        {
            int avg = 0;
            Runner[] arr = new Runner[EnteredRunner.Count];
            EnteredRunner.Values.CopyTo(arr, 0);
            
            foreach(Runner rn in arr)
            {
                avg += rn.RunnerTimeMin;
            }
            return avg/arr.Length;
        }

        private int AvSec()
        {
            int avg = 0;
            

            Runner[] arr = new Runner[EnteredRunner.Count];
            EnteredRunner.Values.CopyTo(arr, 0);
            foreach (Runner rn in arr)
            {
                avg += rn.RunnerTimeSec;
            }
            return avg / arr.Length;
        }

        private int AvAge()
        {
            int avg = 0;
            Runner[] arr = new Runner[EnteredRunner.Count];
            EnteredRunner.Values.CopyTo(arr, 0);

            foreach (Runner rn in arr)
            {
                avg += rn.RunnerAge;
            }
            return avg / arr.Length;
        }

        private int between_0and15()
        {
            int count = 0;
            Runner[] arr = new Runner[EnteredRunner.Count];
            EnteredRunner.Values.CopyTo(arr, 0);

            foreach (Runner rn in arr)
            {
                if(rn.RunnerAge<16)
                {
                    count++;
                }
            }
            return count;
        }

        private int between_16and29()
        {
            int count = 0;
            Runner[] arr = new Runner[EnteredRunner.Count];
            EnteredRunner.Values.CopyTo(arr, 0);

            foreach (Runner rn in arr)
            {
                if (rn.RunnerAge>15&&rn.RunnerAge < 30 )
                {
                    count++;
                }
            }
            return count;
        }
        private int Is_30andolder()
        {
            int count = 0;
            Runner[] arr = new Runner[EnteredRunner.Count];
            EnteredRunner.Values.CopyTo(arr, 0);

            foreach (Runner rn in arr)
            {
                if (rn.RunnerAge > 29)
                {
                    count++;
                }
            }
            return count;
        }
        private Runner FirstPlace()
        {
            Runner[] arr = new Runner[EnteredRunner.Count];
            EnteredRunner.Values.CopyTo(arr, 0);

            Runner winner = arr[0];
            for (int i = 0; i <arr.Length ; i++)
            {
                if(arr[i].RunnerTimeMin<=winner.RunnerTimeMin && arr[i].RunnerTimeSec<winner.RunnerTimeSec)
                {
                    winner = arr[i];
                }
                
            }
            return winner;
        }
        private void btnAnanlyseRace_Click(object sender, RoutedEventArgs e)
        {
            string rWinner = "";
            rWinner +="Winner: "+ ShowInfo( FirstPlace())+" Age: "+ FirstPlace().RunnerAge+"\nAverage time: "+AvMin()+":"+AvSec()+"\nAverage age: " + AvAge()
                +"\n15 or younger: " +between_0and15() + "\nBetween 16 and 29: " + between_16and29()+ "\n30 or older: " + Is_30andolder() ;
            txtDisp.Text = rWinner;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!(txtAge.Text.Equals(null) || txtName.Text.Equals(null) || txtTimeMin.Text.Equals(null) || txtTimeSec.Text.Equals(null) || int.TryParse(txtTimeMin.Text, out int res) == false
                || int.TryParse(txtTimeSec.Text, out int res1) == false || int.TryParse(txtAge.Text, out int res2) == false || int.Parse(txtTimeSec.Text) > 60))
            {


                Runner rn = new Runner();
                rn.setRunner(txtName.Text, int.Parse(txtTimeMin.Text), int.Parse(txtTimeSec.Text), int.Parse(txtAge.Text));
                EnteredRunner.Add(rn.RunnerName, rn);
                txtName.Text = "";
                txtTimeMin.Text = "";
                txtTimeSec.Text = "";
                txtAge.Text = "";
            }
            else
            {
                MessageBox.Show("There was an Error. Please check values you have entered.");
            }
        }

        private void btnShowRunners_Click(object sender, RoutedEventArgs e)
        {

            Runner[] run = sortLst();
            string TxtDisplay = "";
            for (int i = 0; i < run.Length; i++)
            {
                TxtDisplay += run[i].RunnerName + "\n";
            }
            txtDisp.Text = TxtDisplay;
        }
    }

}
