using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Reflection.Emit;
using System.IO.Ports;

namespace Scrabble_v4_client
{
    public partial class Form_Joc : Form
    {
        public TcpClient client;
        public NetworkStream clientStream;
        public bool ascult;
        public Form_Joc Form_client;
        public Thread t;

        private bool eRandulMeu;


        private Button[,] tabla;
        private Panel PanelTabla;
        private Panel PanelSuport;
        private Button[] ButoaneInterfataSuport;

        private Jucator jucatorCurent;
        private Mutare mutareCurenta;
        private int nr_Litere_Ramase;

        private int marime_piesa;
        private int LUNGIME = 16;
        private int LATIME = 16;
        private int numarPieseSuport = 7;
        private bool final;
        private int[,] AspectTabla = {
            {-1,  -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2},
            {-3,  32,  0,  0, 21,  0,  0,  0, 32,  0,  0,  0, 21,  0,  0, 32},
            {-3,   0, 22,  0,  0,  0, 31,  0,  0,  0, 31,  0,  0,  0, 22,  0},
            {-3,   0,  0, 22,  0,  0,  0, 21,  0, 21,  0,  0,  0, 22,  0,  0},
            {-3,  21,  0,  0, 22,  0,  0,  0, 21,  0,  0,  0, 22,  0,  0, 21},
            {-3,   0,  0,  0,  0, 22,  0,  0,  0,  0,  0, 22,  0,  0,  0,  0},
            {-3,   0, 31,  0,  0,  0, 31,  0,  0,  0, 31,  0,  0,  0, 31,  0},
            {-3,   0,  0, 21,  0,  0,  0, 21,  0, 21,  0,  0,  0, 21,  0,  0},
            {-3,  32,  0,  0, 21,  0,  0,  0, 22,  0,  0,  0, 21,  0,  0, 32},
            {-3,   0,  0, 21,  0,  0,  0, 21,  0, 21,  0,  0,  0, 21,  0,  0},
            {-3,   0, 31,  0,  0,  0, 31,  0,  0,  0, 31,  0,  0,  0, 31,  0},
            {-3,   0,  0,  0,  0, 22,  0,  0,  0,  0,  0, 22,  0,  0,  0,  0},
            {-3,  21,  0,  0, 22,  0,  0,  0, 21,  0,  0,  0, 22,  0,  0, 21},
            {-3,   0,  0, 22,  0,  0,  0, 21,  0, 21,  0,  0,  0, 22,  0,  0},
            {-3,   0, 22,  0,  0,  0, 31,  0,  0,  0, 31,  0,  0,  0, 22,  0},
            {-3,  32,  0,  0, 21,  0,  0,  0, 32,  0,  0,  0, 21,  0,  0, 32}
        };
        public Form_Joc()
        {
            InitializeComponent();
            Form_client = this;
            button_EnterCuvant.Visible = false;
            button_Undo.Visible = false;
            label_numeJucator.Visible = false;
            label_numeAdversar.Visible = false;
            label_ScorJucator.Visible = false;
            label_ScorAdversar.Visible = false;
            label_LitereRamase.Visible = false;
            label_nr_LitereRamase.Visible=false;
            final = false; 
        }
        private void StartJoc()
        {
            jucatorCurent = new Jucator(textBox_Nume.Text);
            mutareCurenta = new Mutare();

            button_EnterCuvant.Visible = true;
            button_Undo.Visible = true;
            label_numeJucator.Visible = true;
            label_numeAdversar.Visible = true;
            label_ScorJucator.Visible = true;
            label_ScorAdversar.Visible = true;
            label_LitereRamase.Visible = true;
            label_nr_LitereRamase.Visible = true;
            label_nr_LitereRamase.Text = nr_Litere_Ramase.ToString();
            label_numeJucator.Text = jucatorCurent.GetNume();
            AfiseazaInterfataTabla();
            AfiseazaInterfataSuport();

        }
        private void Asculta_client()
        {
            StreamReader citire = new StreamReader(clientStream);
            String dateClient;
            while (ascult)
            {
                try
                {
                    dateClient = citire.ReadLine();
                    Console.WriteLine("Server: " + dateClient + Environment.NewLine);
                    if (dateClient == null)
                        break;

                    else
                    {
                        if (dateClient.StartsWith("!Start#"))
                        {
                            string[] parti = dateClient.Split('#');
                            string literePrimite = parti[1];



                            string[] litere = literePrimite.Split(',');

                            this.Invoke(new MethodInvoker(() =>
                            {
                                label_waiting.Visible = false;
                                StartJoc();
                                foreach (string s in litere)
                                {
                                    jucatorCurent.AdaugaPiesa(new Piesa(char.Parse(s)));
                                }

                                UpdateInterfataSuport(jucatorCurent);
                                SeteazaRandul(false);
                            }));
                        }
                        else if(dateClient.StartsWith("!Nume#"))
                        {
                            string numeAdversar = dateClient.Split('#')[1];
                            this.Invoke(new MethodInvoker(() =>
                            label_numeAdversar.Text = numeAdversar));
                        }
                        else if (dateClient.StartsWith("!LitereNoi#"))
                        {
                            string[] parti = dateClient.Split('#');
                            string litereNoi = parti[1]; 

                            this.Invoke(new MethodInvoker(() =>
                            {
                                if (!string.IsNullOrEmpty(litereNoi))
                                {
                                    string[] litere = litereNoi.Split(',');
                                    foreach (string s in litere)
                                    {
                                        jucatorCurent.AdaugaPiesa(new Piesa(char.Parse(s)));
                                    }
                                }

                                UpdateInterfataSuport(jucatorCurent);

                            }));
                        }
                        else if (dateClient.StartsWith("!Rand#"))
                        {
                            eRandulMeu = dateClient.EndsWith("Client");
                            this.Invoke(new MethodInvoker(() => SeteazaRandul(eRandulMeu)));
                        }
                        else if (dateClient.StartsWith("!NrLitere#"))
                        {
                            string[] parti = dateClient.Split('#');
                            nr_Litere_Ramase = int.Parse(parti[1]);
                            this.Invoke(new MethodInvoker(() => AfiseazaNrLitereRamase()));
                        }
                        else if (dateClient.StartsWith("!Mutare:"))
                            AfiseazaMutarea(dateClient);
                        else if (dateClient.StartsWith("!Validare#"))
                        {
                            if (dateClient.EndsWith("Invalid"))
                            {
                                MessageBox.Show("Mutare invalida!");

                                this.Invoke(new MethodInvoker(() =>
                                {
                                    StergeMutareaCurenta();
                                    mutareCurenta.ClearMutare();
                                }));


                            }
                            else
                            {
                                int scor = int.Parse(dateClient.Split('#')[2]);
                                jucatorCurent.SetScor(scor);
                                this.Invoke(new MethodInvoker(() =>
                                {
                                    AfiseazaScorJucatorCurent();
                                    mutareCurenta.ClearMutare();
                                }));

                            }
                            CereLitere(GetNumarPieseNecesare());

                        }
                        else if(dateClient.StartsWith("!Gata") && final==false)
                        {
                            ServerDeconectat();
                        }
                        else if (dateClient.StartsWith("!Final#"))
                        {
                            final = true;
                            ascult = false;
                            string mesaj = " ";
                           
                            if (dateClient.EndsWith("Win"))
                            {
                                mesaj = "Ai castigat!";

                            }
                            else if (dateClient.EndsWith("Lost"))
                            {
                                mesaj = "Ai pierdut!";
                            }
                            else if (dateClient.EndsWith("Egal"))
                            {
                                mesaj = "Egalitate";
                            }
                            this.Invoke(new MethodInvoker(() =>
                            {
                                label_Win.Text = mesaj;
                                label_Win.Visible = true;
                                label_Win.BringToFront();

                                button_EnterCuvant.Enabled = false;
                                button_Undo.Enabled = false;
                                PanelSuport.Enabled = false;
                                PanelTabla.Enabled = false;
                            }));
                        }
                    }
                   
                }
                catch { ServerDeconectat(); }
            }
        }
        private void ServerDeconectat()
        {
            if (!ascult) return;   
            ascult = false;
            final = true;

            if (this.IsDisposed || !this.IsHandleCreated)
                return;

            this.Invoke(new MethodInvoker(() =>
            {
                label_Win.Text = "Ai castigat!\nAdversarul a abandonat.";
                label_Win.Visible = true;
                label_Win.BringToFront();

                button_EnterCuvant.Enabled = false;
                button_Undo.Enabled = false;
                if (PanelSuport != null)
                {
                    PanelSuport.Enabled = false;
                    PanelTabla.Enabled = false;
                }
            }));
        }
        private void AfiseazaNrLitereRamase()
        {
            label_nr_LitereRamase.Text = nr_Litere_Ramase.ToString();
        }
        

        
        public void AfiseazaInterfataTabla()
        {
            AfiseazaPanelTabla();
            AfiseazaButoaneTabla();
        }
        public void AfiseazaPanelTabla()
        {
            PanelTabla = new Panel();
            PanelTabla.Size = new Size(512, 512);
            PanelTabla.BackColor = Color.SeaGreen;
            this.Controls.Add(PanelTabla);
            PanelTabla.Left = (this.ClientSize.Width - PanelTabla.Width) / 2;
            PanelTabla.Top = 120;
        }
        private void AfiseazaButoaneTabla()
        {

            marime_piesa = PanelTabla.Width / LATIME;

            tabla = new Button[LUNGIME, LATIME];

            for (int i = 0; i < LUNGIME; i++)
            {
                for (int j = 0; j < LATIME; j++)
                {
                    Button btn = new Button();
                    btn.Width = marime_piesa;
                    btn.Height = marime_piesa;

                    btn.Left = j * marime_piesa;
                    btn.Top = i * marime_piesa;
                    btn.Tag = new Point(i, j);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.Font = new Font("Segoe UI", 7, FontStyle.Bold);
                    if (AspectTabla[i, j] < 0)
                    {
                        btn.Enabled = false;
                        btn.BackColor = Color.LightGreen;
                    }
                    else
                        btn.AllowDrop = true;

                    switch (AspectTabla[i, j])
                    {
                        case -3: 
                            btn.Text = ((char)('A' + i - 1)).ToString();
                            break;
                        case -2: 
                            btn.Text = j.ToString();
                            break;
                        case 21: 
                            btn.Text = "DL";
                            btn.BackColor = Color.LightBlue;
                            break;
                        case 22: 
                            btn.Text = "DW";
                            btn.BackColor = Color.Coral;
                            break;
                        case 31: 
                            btn.Text = "TL";
                            btn.BackColor = Color.Blue;
                            break;
                        case 32:
                            btn.Text = "TW";
                            btn.BackColor = Color.Red;
                            break;


                    }
                    btn.DragEnter += Btn_Tabla_DragEnter;
                    btn.DragDrop += Btn_Tabla_DragDrop;
                    tabla[i, j] = btn;

                    PanelTabla.Controls.Add(tabla[i, j]);
                }
            }

            tabla[8, 8].Text = "★";
            tabla[8, 8].Font = new Font("Segoe UI", 14, FontStyle.Bold);

        }

        public void ResetButonTabla(int i, int j)
        {
            tabla[i, j].FlatStyle = FlatStyle.Flat;
            tabla[i, j].FlatAppearance.BorderSize = 1;
            tabla[i, j].Font = new Font("Segoe UI", 7, FontStyle.Bold);
            tabla[i, j].Enabled = true;
            if (i == 8 && j == 8)
            {
                tabla[i, j].Text = "★";
                tabla[i, j].Font = new Font("Segoe UI", 14, FontStyle.Bold);

                tabla[i, j].BackColor = Color.Coral;
            }
            else
            {
                switch (AspectTabla[i, j])
                {
                    case 0:
                        tabla[i, j].Text = "";
                        tabla[i, j].BackColor = Color.SeaGreen;
                        break;
                    case 21: 
                        tabla[i, j].Text = "DL";
                        tabla[i, j].BackColor = Color.LightBlue;
                        break;
                    case 22:
                        tabla[i, j].Text = "DW";
                        tabla[i, j].BackColor = Color.Coral;
                        break;
                    case 31: 
                        tabla[i, j].Text = "TL";
                        tabla[i, j].BackColor = Color.Blue;
                        break;
                    case 32:
                        tabla[i, j].Text = "TW";
                        tabla[i, j].BackColor = Color.Red;
                        break;
                }
            }
        }
        private void Btn_Tabla_DragDrop(object sender, DragEventArgs e)
        {
            Button BtnSursa = (Button)e.Data.GetData(typeof(Button));
            Button BtnDestinatie = sender as Button;

            char litera = char.Parse(BtnSursa.Text);
            Piesa piesa = new Piesa(litera);

            BtnDestinatie.Text = litera.ToString();
            BtnDestinatie.Font = BtnSursa.Font;
            BtnDestinatie.BackColor = BtnSursa.BackColor;
            BtnDestinatie.FlatStyle = BtnSursa.FlatStyle;
            BtnDestinatie.Enabled = false;

            Point pozitie = (Point)BtnDestinatie.Tag;
            int i = pozitie.X;
            int j = pozitie.Y;

            mutareCurenta.AdaugaPiesa(new Patrat(i, j, litera));

            jucatorCurent.ScoatePiesaDePeSuport((int)BtnSursa.Tag);

            UpdateInterfataSuport(jucatorCurent);
        }


        private void Btn_Tabla_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Button)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        public void AfiseazaInterfataSuport()
        {
            AfiseazaPanelSuport();
            AfiseazaButoaneSuport();
        }

        public void AfiseazaPanelSuport()
        {
            PanelSuport = new Panel();
            PanelSuport.Size = new Size(marime_piesa * 10, marime_piesa + 20);
            PanelSuport.BackColor = Color.SeaGreen;
            this.Controls.Add(PanelSuport);
            PanelSuport.Left = (this.ClientSize.Width - PanelTabla.Width) / 2;
            PanelSuport.Left = (this.ClientSize.Width - PanelSuport.Width) / 2;

            int margin = 10;
            PanelSuport.Top = PanelTabla.Bottom + margin;
        }
        public void AfiseazaButoaneSuport()
        {
            int spatiu = (PanelSuport.Width - (numarPieseSuport * marime_piesa)) / (numarPieseSuport + 1);
            ButoaneInterfataSuport = new Button[numarPieseSuport];

            for (int i = 0; i < numarPieseSuport; i++)
            {
                Button btn = new Button();
                btn.Width = marime_piesa;
                btn.Height = marime_piesa;
                btn.BackColor = Color.Khaki;
                btn.Tag = i;

                btn.Left = spatiu + i * (marime_piesa + spatiu);
                btn.Top = (PanelSuport.Height - marime_piesa) / 2;


                btn.MouseDown += Btn_Suport_MouseDown;

                ButoaneInterfataSuport[i] = btn;

                PanelSuport.Controls.Add(ButoaneInterfataSuport[i]);
            }
        }

        private void Btn_Suport_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.DoDragDrop(btn, DragDropEffects.Move);
            }
        }

        private int GetNumarPieseNecesare()
        {
            int ct = 0;
            int numarNecesar = 0;
            foreach (Button btn in ButoaneInterfataSuport)
            {
                if (btn.Visible == true)
                    ct++;
            }
            numarNecesar = numarPieseSuport - ct;
            if (nr_Litere_Ramase < numarNecesar)
                return nr_Litere_Ramase;
            return numarNecesar;
        }
        private void Form_Joc_Resize(object sender, EventArgs e)
        {
            if (PanelTabla != null)
                PanelTabla.Left = (this.ClientSize.Width - PanelTabla.Width) / 2;
            if (PanelSuport!=null)
                PanelSuport.Left = (this.ClientSize.Width - PanelSuport.Width) / 2;
        }
        private void button_EnterCuvant_Click(object sender, EventArgs e)
        {
            if(eRandulMeu)
                client_TrimiteMutarea();
        }
        private void AfiseazaScorJucatorCurent()
        {
            label_ScorJucator.Text = "Scor: "+jucatorCurent.GetScor().ToString();
        }
        private void AfiseazaScorJucatorAdversar(int scor)
        {
            label_ScorAdversar.Text = "Scor: "+scor.ToString();

        }
        private void StergeMutareaCurenta()
        {
            List<Patrat> listaPlasate = mutareCurenta.GetListaPlasate();

            foreach (Patrat p in listaPlasate)
            {
                Console.WriteLine("Sterg " + p.GetLitera() + " " + p.GetX() + " " + p.GetY());
                ResetButonTabla(p.GetX(), p.GetY());
            }
        }
       

        private void button_Undo_Click(object sender, EventArgs e)
        {
            List<Patrat> listaPlasate = mutareCurenta.GetListaPlasate();
            if (listaPlasate.Count == 0) return;

            Patrat ultimaPlasata = listaPlasate[listaPlasate.Count - 1];
            int x = ultimaPlasata.GetX();
            int y = ultimaPlasata.GetY();
            char litera = ultimaPlasata.GetLitera();

            ResetButonTabla(x, y);

            mutareCurenta.StergeUltimaLitera();

            jucatorCurent.AdaugaPiesa(new Piesa(litera));

            UpdateInterfataSuport(jucatorCurent);
        }


        private void UpdateInterfataSuport(Jucator j)
        {
            List<char> lista_litere = j.GetLitereSuport();
            for (int i = 0; i < ButoaneInterfataSuport.Length; i++)
            {
                if (i < lista_litere.Count)
                {
                    ButoaneInterfataSuport[i].Text = lista_litere[i].ToString();
                    ButoaneInterfataSuport[i].Visible = true;
                    ButoaneInterfataSuport[i].Enabled = true;
                }
                else
                {
                    ButoaneInterfataSuport[i].Text = "";
                    ButoaneInterfataSuport[i].Visible = false;
                }
            }

            label_nr_LitereRamase.Text = nr_Litere_Ramase.ToString();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (textBox_Adresa.Text.Length > 0)
                {
                    client = new TcpClient(textBox_Adresa.Text, 3000);
                    ascult = true;
                    t = new Thread(new ThreadStart(Asculta_client));
                    t.IsBackground = true;
                    t.Start();
                    clientStream = client.GetStream();

                    panel_Nume.Visible = false;
                    label_waiting.Visible = true;

                    if (String.IsNullOrEmpty(textBox_Nume.Text))
                        textBox_Nume.Text = "Player 1";
                    
                    StreamWriter scriere = new StreamWriter(clientStream);
                    scriere.AutoFlush = true;

                    scriere.WriteLine("!Nume#" + textBox_Nume.Text);
                    Console.WriteLine("!Nume#" + textBox_Nume.Text);

                }
                else
                {
                        MessageBox.Show("Specificati adresa de IP");
                }
            }
            catch
            {
                MessageBox.Show("Asteptati serverul...");
            }
            
           
        }

        private void client_TrimiteMutarea()
        {
            try
            {
                StreamWriter scriere = new StreamWriter(clientStream);
                scriere.AutoFlush = true;
                scriere.WriteLine("!Mutare:"+mutareCurenta.GetMutarea());
                Console.WriteLine("Client: " + "!Mutare:"+ mutareCurenta.GetMutarea());
                
            }
            finally
            {
            }
        }

       

        private void AfiseazaMutarea(string mutare)
        {
            string litere = mutare.Split(':')[1];
            string[] grupuri = litere.Split('#');
            foreach (string grup in grupuri)
            {
                string[] date = grup.Split(' ');
                if (date.Length == 3)
                {
                    char litera = char.Parse(date[0]);
                    int x = int.Parse(date[1]);
                    int y = int.Parse(date[2]);

                    this.Invoke(new MethodInvoker(() =>
                    {
                        Button BtnDestinatie = tabla[x, y];
  
                        BtnDestinatie.Text = litera.ToString(); 
                        BtnDestinatie.Font = new Font("Microsoft Sans Serif", 8);
                        BtnDestinatie.BackColor = Color.Khaki;
                        BtnDestinatie.FlatStyle = FlatStyle.Standard;
                        BtnDestinatie.Enabled = false;
                    }));
                }
                else if (date.Length == 1)
                {
                    int scor = int.Parse(date[0]);
                    this.Invoke(new MethodInvoker(() => AfiseazaScorJucatorAdversar(scor)));
                }
            }
        }
        private void SeteazaRandul(bool randulMeu)
        {
            eRandulMeu = randulMeu;

            button_EnterCuvant.Enabled = randulMeu;
            button_Undo.Enabled = randulMeu;

            if (PanelSuport != null)
            {
                PanelSuport.Enabled = randulMeu;
                if (randulMeu)
                    PanelSuport.BackColor = Color.SeaGreen;
                else
                    PanelSuport.BackColor = Color.Gray;
            }

            if (randulMeu)
            {
                this.Text = "Scrabble - " + jucatorCurent.GetNume() + " - Randul tau";
            }
            else
            {
                this.Text = "Scrabble - " + jucatorCurent.GetNume() + " - Randul adversarului";
            }
        }
        private void CereLitere(int n)
        {
            StreamWriter scriere = new StreamWriter(clientStream);
            scriere.AutoFlush = true;
            scriere.WriteLine("!CereLitere#"+n);
            Console.WriteLine("Client: " + "!CereLitere#" + n);

        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            DeconecteazaClient();
            Application.Exit();
        }

        private void DeconecteazaClient()
        {
            try
            {
                ascult = false;


                if (clientStream != null && client.Connected)
                {
                    try
                    {
                        StreamWriter scriere = new StreamWriter(clientStream);
                        
                        scriere.AutoFlush = true;
                        scriere.WriteLine("!Gata");
                        scriere.Close();
                        clientStream.Close();
                        client.Close();
                    }
                    catch 
                    {  }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during disconnect: " + ex.Message);
            }
        }
    }
}
