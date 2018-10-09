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
        Dictionary<string,Runner> RunBoi = new Dictionary<string , Runner>();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!(txtAge.Text.Equals(null) || txtName.Text.Equals(null) || txtTimeMin.Text.Equals(null) || txtTimeSec.Text.Equals(null) || int.TryParse(txtTimeMin.Text,out int res) == false
                || int.TryParse(txtTimeSec.Text, out int res1) == false || int.TryParse(txtAge.Text, out int res2)== false || int.Parse(txtTimeSec.Text) > 60 ))
            {


                Runner rn = new Runner();
                rn.setRunner(txtName.Text, int.Parse(txtTimeMin.Text), int.Parse(txtTimeSec.Text), int.Parse(txtAge.Text));
                RunBoi.Add(rn.RunnerName,rn);
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

        public string ShowForm(string name)
        {
            return "" + RunBoi[name].RunnerName + "(" + RunBoi[name].RunnerTimeMin + ":" + RunBoi[name].RunnerTimeSec + ")";
        }
        private string ShowForm(Runner rn)
        {
            return "" + rn.RunnerName + "(" + rn.RunnerTimeMin + ":" + rn.RunnerTimeSec + ")";
        }
        private Runner[] sortLst()
        {
            Runner[] lst = new Runner[RunBoi.Count];
            RunBoi.Values.CopyTo(lst, 0);
            Runner temp;

            for (int write = 0; write < lst.Length; write++)
            {
                for (int sort = 0; sort < lst.Length - 1; sort++)
                {
                    if (lst[sort].RunnerTimeMin > lst[sort + 1].RunnerTimeMin && lst[sort].RunnerTimeSec > lst[sort + 1].RunnerTimeSec)
                    {
                        temp = lst[sort + 1];
                        lst[sort + 1] = lst[sort];
                        lst[sort] = temp;
                    }
                }

            }
            return lst.ToArray();
        }
        private void btnShowRunners_Click(object sender, RoutedEventArgs e)
        {
            
            Runner[] arr = sortLst(); 
            string disp = "";
            for (int i = 0; i < arr.Length; i++)
            {
                disp += arr[i].RunnerName +"\n";
            }
            txtDisp.Text = disp;
        }

        private int AverageMin()
        {
            int avg = 0;
            Runner[] arr = new Runner[RunBoi.Count];
            RunBoi.Values.CopyTo(arr, 0);
            
            foreach(Runner rn in arr)
            {
                avg += rn.RunnerTimeMin;
            }
            return avg/arr.Length;
        }

        private int AverageSec()
        {
            int avg = 0;
            

            Runner[] arr = new Runner[RunBoi.Count];
            RunBoi.Values.CopyTo(arr, 0);
            foreach (Runner rn in arr)
            {
                avg += rn.RunnerTimeSec;
            }
            return avg / arr.Length;
        }

        private int AverageAge()
        {
            int avg = 0;
            Runner[] arr = new Runner[RunBoi.Count];
            RunBoi.Values.CopyTo(arr, 0);

            foreach (Runner rn in arr)
            {
                avg += rn.RunnerAge;
            }
            return avg / arr.Length;
        }

        private int bet0and15()
        {
            int count = 0;
            Runner[] arr = new Runner[RunBoi.Count];
            RunBoi.Values.CopyTo(arr, 0);

            foreach (Runner rn in arr)
            {
                if(rn.RunnerAge<16)
                {
                    count++;
                }
            }
            return count;
        }

        private int bet16and29()
        {
            int count = 0;
            Runner[] arr = new Runner[RunBoi.Count];
            RunBoi.Values.CopyTo(arr, 0);

            foreach (Runner rn in arr)
            {
                if (rn.RunnerAge>15&&rn.RunnerAge < 30 )
                {
                    count++;
                }
            }
            return count;
        }
        private int bet30andolder()
        {
            int count = 0;
            Runner[] arr = new Runner[RunBoi.Count];
            RunBoi.Values.CopyTo(arr, 0);

            foreach (Runner rn in arr)
            {
                if (rn.RunnerAge > 29)
                {
                    count++;
                }
            }
            return count;
        }
        private Runner Winna()
        {
            Runner[] arr = new Runner[RunBoi.Count];
            RunBoi.Values.CopyTo(arr, 0);

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
            rWinner +="Winner: "+ ShowForm( Winna())+" Age: "+Winna().RunnerAge+"\nAverage time: "+AverageMin()+":"+AverageSec()+"\nAverage age: " + AverageAge()
                +"\n15 or younger: " +bet0and15() + "\nBetween 16 and 29: " + bet16and29()+ "\n30 or older: " + bet30andolder() ;
            txtDisp.Text = rWinner;
        }

        
    }

}
