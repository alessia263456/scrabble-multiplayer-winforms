using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace Scrabble_v4_server
{
    public partial class Form_Joc : Form
    {
        public TcpListener server;
        public String dateServer;

        private static Form_Joc serverForm;
        Thread t;
        bool workThread;
        NetworkStream streamServer;

        private Panel PanelTabla;
        private Panel PanelSuport;
        private Button[] ButoaneInterfataSuport;

        private Joc joc;
        private Jucator jucatorCurent;
        private Jucator jucatorAdversar;
        private Mutare mutareAdversar;
        private bool eRandulMeu;

        string numeAdversar;
        int buttonSize;
        Button[,] tablaInterfata;
        int LUNGIME = 16;
        int LATIME = 16;
        int numarPieseSuport = 7;
       
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

            server = new TcpListener(System.Net.IPAddress.Any, 3000);
            server.Start();
            t = new Thread(new ThreadStart(Asculta_Server));
            t.IsBackground = true;
            workThread = true;
            t.Start();
            serverForm = this;

            button_Start.Enabled = false;
            button_EnterCuvant.Visible = false;
            button_Undo.Visible = false;
            label_numeJucator.Visible = false;
            label_numeAdversar.Visible = false;
            label_ScorJucator.Visible = false;
            label_ScorAdversar.Visible = false;
            label_LitereRamase.Visible = false;
            label_nr_LitereRamase.Visible = false;
        }

        public void Asculta_Server()
        {
            try
            {
                while (workThread)
                {
                    Socket socketServer = server.AcceptSocket();

                    streamServer = new NetworkStream(socketServer);
                    StreamReader citireServer = new StreamReader(streamServer);

                    this.Invoke(new MethodInvoker(() =>
                    {
                        button_Start.Enabled=true;
                        label_client_conectat.Text = "Client conectat!";
                    }));

                    while (workThread)
                    {
                        string dateServer = citireServer.ReadLine();
                        if (dateServer == null) break;
                        else if (dateServer == "!Gata") 
                        {
                            workThread = false;
                            if (VerificaSfarsitJoc() == false)
                            {
                                try
                                {
                                    this.Invoke(new MethodInvoker(() =>
                                    {
                                        label_Win.Text = "Ai castigat!\n Adversarul a abandonat.";
                                        label_Win.Visible = true;
                                        label_Win.BringToFront();
                                        PanelSuport.Enabled = false;
                                        PanelTabla.Enabled = false;
                                        workThread = false;
                                    }));
                                }
                                catch { }
                            }
                        }
                        else if(dateServer.StartsWith("!Nume#"))
                        {
                            numeAdversar = dateServer.Split('#')[1];
                        }
                        else if (dateServer.StartsWith("!CereLitere#"))
                        {
                            int nr_litere = int.Parse(dateServer.Split('#')[1]);
                            ScoateLiterePentruAdversar(nr_litere);
                        }
                        else if (dateServer.StartsWith("!Mutare:"))
                        {
                            Console.WriteLine("Client: " + dateServer);
                            ValideazaMutareAdversar(dateServer);
                        }
                    }

                    streamServer.Close();
                    socketServer.Close();
                }
            }
            catch (SocketException e)
            {
               
                Console.WriteLine( e.Message);
            }
        }
        private void ValideazaMutareAdversar(string mutare)
        {
            Console.WriteLine("validare...");
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
                    jucatorAdversar.ScoatePiesaDePeSuport(litera);
                    jucatorAdversar.afiseazaSuport();
                    Console.WriteLine(jucatorAdversar.NrLitereSuport());
                    mutareAdversar.AdaugaPiesa(new Patrat(x, y, litera));
                }
                
            }
            StreamWriter scriere = new StreamWriter(streamServer);
            scriere.AutoFlush = true;
            mutareAdversar.AfiseazaMutare();
            Console.WriteLine("am creeat mutarea");
            if (joc.MutareValida(mutareAdversar))
            {
                Console.WriteLine("ok");
                joc.AdaugaScorMutare(jucatorAdversar,mutareAdversar);
                joc.PuneMutareaPeTabla(mutareAdversar);

                AfiseazaMutarea(mutare);
                joc.AfiseazaMatriceLitere();

                scriere.WriteLine("!Validare#OK#"+jucatorAdversar.GetScor());
                Console.WriteLine("!Validare#OK#" + jucatorAdversar.GetScor());

                this.Invoke(new MethodInvoker(() => AfiseazaScor(jucatorAdversar)));

                
            }
            else
            {
                scriere.WriteLine("!Validare#Invalid");

            }
            mutareAdversar.ClearMutare();

            this.Invoke(new MethodInvoker(() =>
            {
                SeteazaRandul(true);
            }));
            scriere.WriteLine("!Rand#Server");
        }
        private void ScoateLiterePentruAdversar(int nr_litere)
        {
            if (VerificaSfarsitJoc())
            {
                FinalizeazaJoc();
                return;
            }

            if (joc.GetNrLitereInSac()<nr_litere)
                nr_litere=joc.GetNrLitereInSac();
            List<char> litereNoi = joc.GetPieseNoi(jucatorAdversar, nr_litere);
            string lista = ConvertPieseToString(litereNoi);

            jucatorAdversar.afiseazaSuport();
            Console.WriteLine(jucatorAdversar.NrLitereSuport());

            StreamWriter scriere = new StreamWriter(streamServer);
            scriere.AutoFlush = true;
            scriere.WriteLine("!LitereNoi#" + lista );
            Console.WriteLine("!LitereNoi#" + lista );
            this.Invoke(new MethodInvoker(() => AfiseazaNrLitereRamase()));
            TrimiteNrLitereRamase();
        }

        private void StartJoc()
        {
            joc = new Joc();
            
            jucatorCurent = joc.GetJucator(0);
            jucatorAdversar = joc.GetJucator(1);
            jucatorCurent.setNume(textBox_Nume.Text);
            
            jucatorAdversar.setNume(numeAdversar);
            mutareAdversar = new Mutare();

            button_EnterCuvant.Visible = true;
            button_Undo.Visible = true;
            label_numeJucator.Visible = true;
            label_numeAdversar.Visible = true;
            label_ScorJucator.Visible = true;
            label_ScorAdversar.Visible = true;
            label_LitereRamase.Visible = true;
            label_nr_LitereRamase.Visible = true;
            label_nr_LitereRamase.Text = joc.GetNrLitereInSac().ToString();

            label_numeJucator.Text = jucatorCurent.getNume();
            label_numeAdversar.Text = jucatorAdversar.getNume();

            SeteazaRandul(true);
            AfiseazaInterfataTabla();
            AfiseazaInterfataSuport();

            joc.GetPieseNoi(jucatorCurent, numarPieseSuport);
            joc.GetPieseNoi(jucatorAdversar, numarPieseSuport);

            string listaPieseAdversar = ConvertPieseToString(jucatorAdversar.GetLitereSuport());
            StreamWriter scriere = new StreamWriter(streamServer);
            scriere.AutoFlush = true;
            scriere.WriteLine("!Start#" + listaPieseAdversar);
            Console.WriteLine("!Start#" + listaPieseAdversar);

            if (String.IsNullOrEmpty(textBox_Nume.Text))
                textBox_Nume.Text = "Player 2";
            scriere.WriteLine("!Nume#" + textBox_Nume.Text);
            Console.WriteLine("!Nume#" + textBox_Nume.Text);

            AfiseazaNrLitereRamase();
            TrimiteNrLitereRamase();
            button_Start.Visible = false;
            UpdateInterfataSuport(jucatorCurent);
            label_nr_LitereRamase.Text = joc.GetNrLitereInSac().ToString();
            SeteazaRandul(true);

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
           
            buttonSize = PanelTabla.Width / LATIME; 

            tablaInterfata=new Button[LUNGIME,LATIME];

            for (int i = 0; i < LUNGIME; i++)
            {
                for (int j = 0; j < LATIME; j++)
                {
                    Button btn = new Button();
                    btn.Width = buttonSize;
                    btn.Height = buttonSize;

                    btn.Left = j * buttonSize;
                    btn.Top = i * buttonSize;
                    btn.Tag =new Point(i, j);
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

                    switch(AspectTabla[i,j])
                    {
                        case -3: 
                            btn.Text = ((char)('A' + i - 1)).ToString();
                            break;
                        case -2: 
                            btn.Text = j.ToString();
                            break;
                        case 21: 
                            btn.Text = "DL";
                            btn.BackColor= Color.LightBlue;
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
                    tablaInterfata[i, j] = btn;

                    PanelTabla.Controls.Add(tablaInterfata[i,j]);
                }
            }

            tablaInterfata[8, 8].Text = "★";
            tablaInterfata[8, 8].Font = new Font("Segoe UI", 14, FontStyle.Bold);

        }

        public void ResetButonTabla(int i, int j)
        {
            tablaInterfata[i, j].FlatStyle = FlatStyle.Flat;
            tablaInterfata[i, j].FlatAppearance.BorderSize = 1;
            tablaInterfata[i, j].Font = new Font("Segoe UI", 7, FontStyle.Bold);
            tablaInterfata[i, j].Enabled = true;
            if(i==8 && j==8)
            {
                tablaInterfata[i, j].Text = "★";
                tablaInterfata[i, j].Font = new Font("Segoe UI", 14, FontStyle.Bold);

                tablaInterfata[i,j].BackColor = Color.Coral;
            }
            else { 
                switch (AspectTabla[i, j])
                {
                    case 0:
                       tablaInterfata[i, j].Text = "";
                       tablaInterfata[i, j].BackColor = Color.SeaGreen;
                       break;
                    case 21: 
                        tablaInterfata[i,j].Text = "DL";
                        tablaInterfata[i, j].BackColor = Color.LightBlue;
                        break;
                    case 22: 
                        tablaInterfata[i, j].Text = "DW";
                        tablaInterfata[i, j].BackColor = Color.Coral;
                        break;
                    case 31: 
                        tablaInterfata[i, j].Text = "TL";
                        tablaInterfata[i, j].BackColor = Color.Blue;
                        break;
                    case 32:
                        tablaInterfata[i, j].Text = "TW";
                        tablaInterfata[i, j].BackColor = Color.Red;
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

            joc.AdaugaLaMutareCurenta(i, j, litera);

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
            PanelSuport.Size = new Size(buttonSize*10,buttonSize + 20);
            PanelSuport.BackColor = Color.SeaGreen;
            this.Controls.Add(PanelSuport);
            PanelSuport.Left = (this.ClientSize.Width - PanelTabla.Width) / 2;
            PanelSuport.Left = (this.ClientSize.Width - PanelSuport.Width) / 2;

            int margin = 10;
            PanelSuport.Top = PanelTabla.Bottom + margin;
        }
        public void AfiseazaButoaneSuport()
        {
            int spatiu = (PanelSuport.Width - (numarPieseSuport * buttonSize)) / (numarPieseSuport + 1); 
            ButoaneInterfataSuport = new Button[numarPieseSuport];

            for (int i = 0; i < numarPieseSuport; i++)
            {
                Button btn = new Button();
                btn.Width = buttonSize;
                btn.Height = buttonSize;
                btn.BackColor = Color.Khaki;
                btn.Tag = i;

                btn.Left = spatiu + i * (buttonSize + spatiu);
                btn.Top = (PanelSuport.Height - buttonSize) / 2;

                
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
            foreach(Button btn in ButoaneInterfataSuport)
            {
                if(btn.Visible==true) 
                    ct++;
            }
            numarNecesar = numarPieseSuport - ct;
            if (joc.GetNrLitereInSac() < numarNecesar)
                return joc.GetNrLitereInSac();
            return numarNecesar;
        }
        private void Form_Joc_Resize(object sender, EventArgs e)
        {
            if(PanelTabla!=null)
                PanelTabla.Left = (this.ClientSize.Width - PanelTabla.Width) / 2;
            if(PanelSuport!=null)
                PanelSuport.Left = (this.ClientSize.Width - PanelSuport.Width) / 2;
        }

        private void button_EnterCuvant_Click(object sender, EventArgs e)
        {
            if (joc.MutareValida(joc.GetMutareCurenta()))
            {
                joc.PuneMutareaPeTabla(joc.GetMutareCurenta());
                joc.AdaugaScorMutare(jucatorCurent,joc.GetMutareCurenta());
                AfiseazaScor(jucatorCurent);

                joc.AfiseazaMatriceLitere();

                server_trimiteMutare();
                
                joc.ClearMutareCurenta();
            }
            else
            {
                MessageBox.Show("Mutare invalida!");
                StergeMutareaCurenta();
                joc.ClearMutareCurenta();
                server_trimiteMutare();
                
            }

            if (VerificaSfarsitJoc())
            {
                FinalizeazaJoc();
                return;
            }

            joc.GetPieseNoi(jucatorCurent, GetNumarPieseNecesare());
            jucatorCurent.afiseazaSuport();
            Console.WriteLine(jucatorCurent.NrLitereSuport());
            UpdateInterfataSuport(jucatorCurent);
            AfiseazaNrLitereRamase();
            TrimiteNrLitereRamase();
        }
        private void AfiseazaScor(Jucator j)
        {
            if(j==jucatorCurent)
                label_ScorJucator.Text = "Scor: " + jucatorCurent.GetScor().ToString();
            else if(j==jucatorAdversar)
                label_ScorAdversar.Text = "Scor: "+jucatorAdversar.GetScor().ToString();
        }
        private void StergeMutareaCurenta()
        {
            List<Patrat> listaPlasate = joc.GetListaPlasateMutareCurenta();

            foreach (Patrat p in listaPlasate)
            {
                Console.WriteLine("Sterg " + p.GetLitera() + " " + p.GetX() + " " + p.GetY());
                ResetButonTabla(p.GetX(), p.GetY());
            }
        }
        private void button_Start_Click(object sender, EventArgs e)
        {
            if (streamServer != null)
            {
                panel_Nume.Visible = false;
                StartJoc();
                
            }
            else
                MessageBox.Show("Asteptati conectarea unui client!");
        }
        private void button_Undo_Click(object sender, EventArgs e)
        {
            List<Patrat> listaPlasate = joc.GetListaPlasateMutareCurenta();
            if (listaPlasate.Count == 0) return;

            Patrat ultimaPlasata = listaPlasate[listaPlasate.Count - 1];
            int x = ultimaPlasata.GetX();
            int y = ultimaPlasata.GetY();
            char litera = ultimaPlasata.GetLitera();

            ResetButonTabla(x, y);

            joc.StergeUltimaLiteraPlasata();

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

            label_nr_LitereRamase.Text = joc.GetNrLitereInSac().ToString();
        }
        private void server_trimiteMutare()
        {
            try
            {
                StreamWriter scriere = new StreamWriter(streamServer);
                scriere.AutoFlush = true;
                scriere.WriteLine("!Mutare:"+joc.GetStringTransmitereMutareCurenta()+jucatorCurent.GetScor());
                Console.WriteLine("Server: " + "!Mutare:"+joc.GetStringTransmitereMutareCurenta() + jucatorCurent.GetScor());
                scriere.WriteLine("!Rand#Client");
                SeteazaRandul(false);
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

                    joc.PunePiesaPeTabla(x, y, litera);

                    this.Invoke(new MethodInvoker(() => {
                        Button BtnDestinatie = tablaInterfata[x, y];

                        BtnDestinatie.Text = litera.ToString();
                        BtnDestinatie.Font = ButoaneInterfataSuport[0].Font;
                        BtnDestinatie.BackColor = ButoaneInterfataSuport[0].BackColor;
                        BtnDestinatie.FlatStyle = ButoaneInterfataSuport[0].FlatStyle;
                        BtnDestinatie.Enabled = false;
                    }));
                }
            }
            this.Invoke(new MethodInvoker(() =>
            {
                SeteazaRandul(true);
            }));

            StreamWriter scriere = new StreamWriter(streamServer);
            scriere.AutoFlush = true;
            scriere.WriteLine("!Rand#Server");
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

            if(randulMeu)
            {
                this.Text="Scrabble - "+jucatorCurent.getNume()+" - Randul tau";
            }
            else
            {
                this.Text = "Scrabble - " + jucatorCurent.getNume() + " - Randul adversarului";
            }
        }
        private string ConvertPieseToString(List<char> piese)
        {
            List<string> litere = new List<string>();
            foreach (char p in piese) 
                litere.Add(p.ToString());
            return string.Join(",", litere); 
        }
        private void TrimiteNrLitereRamase()
        {
            if (streamServer == null) return;

            StreamWriter scriere = new StreamWriter(streamServer);
            scriere.AutoFlush = true;
            scriere.WriteLine("!NrLitere#"+joc.GetNrLitereInSac());
        }
        private void AfiseazaNrLitereRamase()
        {
            label_nr_LitereRamase.Text = joc.GetNrLitereInSac().ToString();
        }
        private bool VerificaSfarsitJoc()
        {
            if (joc.GetNrLitereInSac() == 0 &&(jucatorCurent.NrLitereSuport() == 0 ||jucatorAdversar.NrLitereSuport() == 0))
            {
                return true;
            }

            return false;
        }
        private void FinalizeazaJoc()
        {
            workThread = false;

            int scorServer = jucatorCurent.GetScor();
            int scorClient = jucatorAdversar.GetScor();

            string mesaj_label_server;
            string mesaj_client;

            if (scorServer > scorClient)
            {
                mesaj_label_server = "Ai castigat!";
                mesaj_client = "Lost";
            }
            else if (scorServer < scorClient)
            {
                mesaj_label_server = "Ai pierdut!";
                mesaj_client = "Win";
            }
            else
            {
                mesaj_label_server = "Egalitate!";
                mesaj_client = "Egal";
            }

            this.Invoke(new MethodInvoker(() =>
            {
                label_Win.Text = mesaj_label_server;
                label_Win.Visible = true;
                label_Win.BringToFront();

                button_EnterCuvant.Enabled = false;
                button_Undo.Enabled = false;
                PanelSuport.Enabled = false;
                PanelTabla.Enabled = false;
            }));
             
            if (streamServer != null)
            {
                StreamWriter scriere = new StreamWriter(streamServer);
                scriere.AutoFlush = true;
                scriere.WriteLine("!Final#" + mesaj_client);
            }
        }
        private void button_Exit_Click(object sender, EventArgs e)
        {
            try
            {
                if (streamServer != null && streamServer.CanWrite)
                {
                    StreamWriter writer = new StreamWriter(streamServer);
                    writer.AutoFlush = true;
                    writer.WriteLine("!Gata");
                }
            }
            catch
            {
                
            }
            workThread = false;
            Application.Exit();
        }
    }
}
