using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Input;
using System.Net;
using System.IO;

namespace WpfApp4
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        long[] times = new long[26];
        int[] number = new int[26];
        int buton;
        long time;
        long[] times2 = new long[26];
        int[] number2 = new int[26];
        int buton2;
        long time2;
        long[] times5 = new long[26];
        int[] number5=new int[26];
        int buton5;
        long time5;
        public MainWindow()
        { 

            InitializeComponent();
            for (int i = 0; i < 26; i++) {
                times[i] = 0;
                number[i] = 0;
            }
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
             
        }



        private void Sign_Click(object sender, RoutedEventArgs e)
        {
            string password = "Myszka123";
            string connStr =
                "server=localhost;user=root;database=meh;port=3306;password=" + password;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select login from User where login='" + siglog.Text + "'", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "Table");

           // Console.WriteLine(ds.Tables[0].Rows.Count);
            if (ds.Tables[0].Rows.Count == 0) {
                MySqlCommand add = new MySqlCommand("Insert into User (login) values ('" + siglog.Text + "')", conn);
                add.ExecuteReader();
            }
            MySqlCommand user = new MySqlCommand("Select iduser from User where login='" + siglog.Text + "'", conn);
            MySqlDataAdapter useradapt = new MySqlDataAdapter(user);
            DataSet dsid = new DataSet();
            useradapt.Fill(dsid, "Table");
            string iduser = (dsid.Tables[0].Rows[0]["iduser"].ToString());

            int pom = 0;
            for (int j = 0;j < 26; j++){
                if (times2[j] == 0) {
                    pom++;
                }
            }
            if (pom > 0)
            {

            }
            else
            {
                for (int i = 0; i < 26; i++)
                {
                   times2[i]=times2[i] / number2[i];
                }
                MySqlCommand add = new MySqlCommand("Insert into val (a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,iduser) values ('" + times2[0] + "','" + times2[1] + "','" + times2[2] + "','" + times2[3] + "','" + times2[4] + "','" + times2[5] + "','" + times2[6] + "','" + times2[7] + "','" + times2[8] + "','" + times2[9] + "','" + times2[10] + "','" + times2[11] + "','" + times2[12] + "','" + times2[13] + "','" + times2[14] + "','" + times2[15] + "','" + times2[16] + "','" + times2[17] + "','" + times2[18] + "','" + times2[19] + "','" + times2[20] + "','" + times2[21] + "','" + times2[22] + "','" + times2[23] + "','" + times2[24] + "','" + times2[25] + "','" + iduser + "')", conn);
                add.ExecuteReader();
            }
            conn.Close();
            MessageBoxResult result = MessageBox.Show("One more time!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                
            }
        }

        private void Logtxt_KeyDown(object sender, KeyEventArgs e)
        {
            time= (DateTime.Now.Millisecond);
            buton = Convert.ToInt32(Convert.ToChar(e.Key.ToString()))-65;
            
        }

        private void Logtxt_KeyUp(object sender, KeyEventArgs e)
        {
            
            long time3 = DateTime.Now.Millisecond;
            if (time > time3) { time = 999 - time + time3; } else { time = time3 - time; }
            times[buton] =time;
            number[buton]++;
        }

        private void sigtxt_KeyDown(object sender, KeyEventArgs e)
        {
            time2 = (DateTime.Now.Millisecond);
            Console.WriteLine(DateTime.Now.Millisecond);
            buton2 = Convert.ToInt32(Convert.ToChar(e.Key.ToString())) - 65;
        }

        private void sigtxt_KeyUp(object sender, KeyEventArgs e)
        {
            long time4 = DateTime.Now.Millisecond;
            if (time2 > time4) { time2 = 999 - time2 + time4; } else { time2 = time4 - time2; };
            times2[buton2] = time2;
            Console.WriteLine(DateTime.Now.Millisecond);
            Console.WriteLine(time2);
            Console.WriteLine();
            number2[buton2]++;
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            string password = "Myszka123";
            string connStr =
                "server=localhost;user=root;database=meh;port=3306;password=" + password;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select login from User where login='" + siglog.Text + "'", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "Table");

            // Console.WriteLine(ds.Tables[0].Rows.Count);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBoxResult brak = MessageBox.Show("No user with that login!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Question);
                if (brak == MessageBoxResult.OK) { }
            }
            else
            {
                int pom = 0;
                for (int j = 0; j < 26; j++)
                {
                    if (times2[j] == 0)
                    {
                        pom++;
                    }
                }


                {

                    MySqlCommand add = new MySqlCommand("Insert into val (a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,iduser) values ('" + times2[0] + "','" + times2[1] + "','" + times2[2] + "','" + times2[3] + "','" + times2[4] + "','" + times2[5] + "','" + times2[6] + "','" + times2[7] + "','" + times2[8] + "','" + times2[9] + "','" + times2[10] + "','" + times2[11] + "','" + times2[12] + "','" + times2[13] + "','" + times2[14] + "','" + times2[15] + "','" + times2[16] + "','" + times2[17] + "','" + times2[18] + "','" + times2[19] + "','" + times2[20] + "','" + times2[21] + "','" + times2[22] + "','" + times2[23] + "','" + times2[24] + "','" + times2[25] + "', NULL)", conn);
                    add.ExecuteReader();

                    WebRequest request = WebRequest.Create("http://127.0.0.1:8000/neuralnet");
                    request.Method = "GET";
                    WebResponse response = request.GetResponse();
                    Stream ReceiveStream = response.GetResponseStream();

                    System.Text.Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
                    StreamReader readStream = new StreamReader(ReceiveStream, encode);

                    String line = readStream.ReadToEnd();
                    string val = null;
                    for (int i = 2; i < line.Length - 2; i++)
                    {
                        if (line[i] == '.')
                        {
                            val = val + ',';
                        }
                        else
                        {
                            val = val + line[i];
                        }
                    }
                    Console.WriteLine(val);
                    double vall = Convert.ToDouble(val);
                    int valll = Convert.ToInt32(vall);
                    Console.WriteLine(valll);
                    conn.Close();
                    conn.Open();
                    MySqlCommand delete = new MySqlCommand("Delete from val where iduser is NULL", conn);
                    delete.ExecuteReader();

                    conn.Close();
                    conn.Open();
                    MySqlCommand user = new MySqlCommand("Select login from User where iduser='" + valll + "'", conn);
                    MySqlDataAdapter useradapt = new MySqlDataAdapter(user);
                    DataSet dsid = new DataSet();
                    useradapt.Fill(dsid, "Table");
                    string login = (dsid.Tables[0].Rows[0]["login"].ToString());
                    conn.Close();
                    if (login == loglog.Text)
                    {
                        MessageBoxResult result = MessageBox.Show("Right man in right place", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Question);
                        if (result == MessageBoxResult.OK)
                        {

                        }
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("Fail :"+login+"  "+loglog.Text, "Confirmation", MessageBoxButton.OK, MessageBoxImage.Question);
                        if (result == MessageBoxResult.OK)
                        {

                        }
                    }
                }
            }
        }

        private void Whotxt_KeyDown(object sender, KeyEventArgs e)
        {
            time5 = (DateTime.Now.Millisecond);
            Console.WriteLine(DateTime.Now.Millisecond);
            buton5 = Convert.ToInt32(Convert.ToChar(e.Key.ToString())) - 65;
        }

        private void Whotxt_KeyUp(object sender, KeyEventArgs e)
        {
            long time6 = DateTime.Now.Millisecond;
            if (time5 > time6) { time5 = 999 - time5 + time6; } else { time5 = time6 - time5; };
            times5[buton5] = time5;
            Console.WriteLine(DateTime.Now.Millisecond);
            Console.WriteLine(time5);
            
            number5[buton5]++;
        }

        private void Who_Click(object sender, RoutedEventArgs e)
        {
            string password = "Myszka123";
            string connStr =
                "server=localhost;user=root;database=meh;port=3306;password=" + password;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            
            {
                int pom = 0;
                for (int j = 0; j < 26; j++)
                {
                    if (times5[j] == 0)
                    {
                        pom++;
                    }
                }


                {

                    MySqlCommand add = new MySqlCommand("Insert into val (a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,iduser) values ('" + times5[0] + "','" + times5[1] + "','" + times5[2] + "','" + times5[3] + "','" + times5[4] + "','" + times5[5] + "','" + times5[6] + "','" + times5[7] + "','" + times5[8] + "','" + times5[9] + "','" + times5[10] + "','" + times5[11] + "','" + times5[12] + "','" + times5[13] + "','" + times5[14] + "','" + times5[15] + "','" + times5[16] + "','" + times5[17] + "','" + times5[18] + "','" + times5[19] + "','" + times5[20] + "','" + times5[21] + "','" + times5[22] + "','" + times5[23] + "','" + times5[24] + "','" + times5[25] + "', NULL)", conn);
                    add.ExecuteReader();

                    WebRequest request = WebRequest.Create("http://127.0.0.1:8000/neuralnet");
                    request.Method = "GET";
                    WebResponse response = request.GetResponse();
                    Stream ReceiveStream = response.GetResponseStream();

                    System.Text.Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
                    StreamReader readStream = new StreamReader(ReceiveStream, encode);

                    String line = readStream.ReadToEnd();
                    string val = null;
                    for (int i = 2; i < line.Length - 2; i++)
                    {
                        if (line[i] == '.')
                        {
                            val = val + ',';
                        }
                        else
                        {
                            val = val + line[i];
                        }
                    }
                    Console.WriteLine(val);
                    double vall = Convert.ToDouble(val);
                    int valll = Convert.ToInt32(vall);
                    Console.WriteLine(valll);
                    conn.Close();
                    conn.Open();
                    MySqlCommand delete = new MySqlCommand("Delete from val where iduser is NULL", conn);
                    delete.ExecuteReader();

                    conn.Close();
                    conn.Open();
                    MySqlCommand user = new MySqlCommand("Select login from User where iduser='" + valll + "'", conn);
                    MySqlDataAdapter useradapt = new MySqlDataAdapter(user);
                    DataSet dsid = new DataSet();
                    useradapt.Fill(dsid, "Table");
                    string login = (dsid.Tables[0].Rows[0]["login"].ToString());
                    conn.Close();
                    
                    {
                        MessageBoxResult result = MessageBox.Show("Czy jesteś: "+login+"?", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Question);
                        if (result == MessageBoxResult.OK)
                        {

                        }
                    }
                   
                }
            }
        }
    }
}
