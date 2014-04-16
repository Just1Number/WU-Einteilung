using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using WU_Einteilung;
using System.IO;
namespace WU_Einteilung
{
    public partial class MainFrm : Form
    {
        #region Variabeln
        private Worksheet slist;
        private Worksheet klist;
        private Range slist_range;
        private Range klist_range;
        private Microsoft.Office.Interop.Excel.Application myExcel = new Microsoft.Office.Interop.Excel.Application();
        private Microsoft.Office.Interop.Excel.Workbook wu_liste;
        private Microsoft.Office.Interop.Excel.Workbook kurslisten;
        private string document_path;
        private List<int> schueler_id = new List<int>();
        private List<string> schueler_namen         = new List<string>();
        private List<string> schueler_vornamen      = new List<string>();
        private List<string> schueler_klasse        = new List<string>();
        private List<string> schueler_klassenlehrer = new List<string>();
        private List<string> schueler_erstwahl      = new List<string>();
        private List<string> schueler_zweitwahl     = new List<string>();
        private List<string> schueler_drittwahl     = new List<string>();
        private List<string> schueler_zuordnung     = new List<string>();
        private List<int> schueler_wustunden     = new List<int>();
        private List<string> kurse_id               = new List<string>();
        private List<string> kurse_name = new List<string>();
        private List<int> kurse_maxpersonen = new List<int>();
        private List<int> kurse_minpersonen = new List<int>();
        private List<int> kurse_stunden     = new List<int>();
        private List<int> kurse_size        = new List<int>();
        #endregion

        #region Konstanten
        public static int SPALTE_NAME = 1;
        public static int SPALTE_VORNAME = 2;
        public static int SPALTE_KLASSE = 3;
        public static int SPALTE_KLASSENLEHRER = 4;
        public static int SPALTE_WUSTUNDENALT = 5;
        public static int SPALTE_WUSTUNDENNEU = 6;
        public static int SPALTE_ERSTWAHL = 7;
        public static int SPALTE_ZWEITWAHL = 8;
        public static int SPALTE_DRITTWAHL = 9;
        public static int SPALTE_ZUORDNUNG = 10;
        public static int SPALTE_KURSID = 1;
        public static int SPALTE_KURSNAMEN = 2;
        public static int SPALTE_KSTUNDEN = 4;
        public static int SPALTE_MINPERSONEN = 5;
        public static int SPALTE_MAXPERSONEN = 6;
        #endregion

        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {

        }
       
        private void btn_zon_Click(object sender, EventArgs e)
        {
            dokument_auslesen();
            myExcel.Quit();
            dokument_beschreiben(algorithmus());
        }

        private void btn_list_Click(object sender, EventArgs e)
        {
            dokument_auslesen();
            kurstlisten_schreiben();
        }

        private void btn_klist_Click(object sender, EventArgs e)
        {
            dokument_auslesen();
            klassenlisten_schreiben();
        }

        private void btn_conf_Click(object sender, EventArgs e)
        {
            new ConfigFrm().Show(); 
        }

        private void btn_files_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbx_path.Text = ofd.FileName;
                string safeFilePath = ofd.SafeFileName;
            }
        }

        private void dokument_auslesen()
        {
            document_path = tbx_path.Text;
            int schueler_anzahl = new int();
            try
            {
                // Pfad wird ausgelesen
                wu_liste = myExcel.Workbooks.Open(@document_path);
                // Variablen init
                myExcel.Visible = false;
                slist = (Worksheet)wu_liste.Sheets[1];
                klist = (Worksheet)wu_liste.Sheets[2];
                slist_range = slist.UsedRange;
                klist_range = klist.UsedRange;
                schueler_id.Clear();
                schueler_namen.Clear();
                schueler_vornamen.Clear();
                schueler_klasse.Clear();
                schueler_klassenlehrer.Clear();
                schueler_erstwahl.Clear();
                schueler_zweitwahl.Clear();
                schueler_drittwahl.Clear();
                kurse_id.Clear();
                kurse_maxpersonen.Clear();
                kurse_minpersonen.Clear();
                add_item_to_log("Schüler werden ausgelesen");
                for (int i = 0; !String.Equals(slist_range.Cells[i + 2, SPALTE_NAME].Value, null); i++)
                {
                    if (i % 25 == 24)
                    {
                        add_item_to_log(Convert.ToString(i + 1) + " Schüler wurden ausgelesen");
                    }
                    schueler_id.Add(i + 2);
                    String name = slist_range.Cells[i + 2, SPALTE_NAME].Value;
                    String vorname = slist_range.Cells[i + 2, SPALTE_VORNAME].Value;
                    String klasse = slist_range.Cells[i + 2, SPALTE_KLASSE].Value;
                    String klassenlehrer = slist_range.Cells[i + 2, SPALTE_KLASSENLEHRER].Value;
                    String erstwahl = slist_range.Cells[i + 2, SPALTE_ERSTWAHL].Value;
                    String zweitwahl = slist_range.Cells[i + 2, SPALTE_ZWEITWAHL].Value;
                    String drittwahl = slist_range.Cells[i + 2, SPALTE_DRITTWAHL].Value;
                    String zuordnung = slist_range.Cells[i + 2, SPALTE_ZUORDNUNG].Value;
                    String wustunde  = Convert.ToString(slist_range.Cells[i + 2, SPALTE_WUSTUNDENALT].Value);
                    if (!String.IsNullOrWhiteSpace(name)) schueler_namen.Add(name.Trim());
                    else schueler_namen.Add(null);
                    if (!String.IsNullOrWhiteSpace(vorname)) schueler_vornamen.Add(vorname.Trim());
                    else schueler_vornamen.Add(null);
                    if (!String.IsNullOrWhiteSpace(klasse)) schueler_klasse.Add(klasse.Trim());
                    else schueler_klasse.Add(null);
                    if (!String.IsNullOrWhiteSpace(klassenlehrer)) schueler_klassenlehrer.Add(klassenlehrer.Trim());
                    else schueler_klassenlehrer.Add(null);
                    if (!String.IsNullOrWhiteSpace(erstwahl)) schueler_erstwahl.Add(erstwahl.Trim());
                    else schueler_erstwahl.Add(null);
                    if (!String.IsNullOrWhiteSpace(zweitwahl)) schueler_zweitwahl.Add(zweitwahl.Trim());
                    else schueler_zweitwahl.Add(null);
                    if (!String.IsNullOrWhiteSpace(drittwahl)) schueler_drittwahl.Add(drittwahl.Trim());
                    else schueler_drittwahl.Add(null);
                    if (!String.IsNullOrWhiteSpace(zuordnung)) schueler_zuordnung.Add(zuordnung.Trim());
                    else schueler_zuordnung.Add(null);
                    if (!String.IsNullOrWhiteSpace(wustunde)) schueler_wustunden.Add(Convert.ToInt32(wustunde.Trim()));
                    else schueler_wustunden.Add(0);
                    schueler_anzahl = i;
                }
                add_item_to_log("Alle " + Convert.ToString(schueler_anzahl + 1) + " Schüler wurden ausgelesen");
                add_item_to_log("Kurse werden ausgelesen");
                for (int i = 0; !String.Equals(klist_range.Cells[i + 2, SPALTE_KURSID].Value, null); i++)
                {
                    kurse_id.Add(klist_range.Cells[i + 2, SPALTE_KURSID].value);
                    kurse_name.Add(klist_range.Cells[i + 2, SPALTE_KURSNAMEN].value);
                    kurse_maxpersonen.Add(Convert.ToInt32(klist_range.Cells[i + 2, SPALTE_MAXPERSONEN].value));
                    kurse_minpersonen.Add(Convert.ToInt32(klist_range.Cells[i + 2, SPALTE_MINPERSONEN].value));
                    kurse_stunden.Add(Convert.ToInt32(klist_range.Cells[i + 2, SPALTE_KSTUNDEN].value));
                    kurse_size.Add(0);
                }
                add_item_to_log("Auslesen vollendet");
                wu_liste.Save();
                wu_liste.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                try
                {
                    wu_liste.Save();
                    wu_liste.Close();
                }
                catch (Exception)
                {
                }
            }
        }

        private void dokument_beschreiben(String[] zuordnungen)
        {
            document_path = tbx_path.Text;
            try
            {
                wu_liste = myExcel.Workbooks.Open(@document_path);
                myExcel.Visible = false;
                slist = (Worksheet)wu_liste.Sheets[1];
                klist = (Worksheet)wu_liste.Sheets[2];
                slist_range = slist.UsedRange;
                klist_range = klist.UsedRange;
                add_item_to_log("Zuordnungen werden in Tabelle eingetragen");
                for (int i = 0; i < zuordnungen.Length; i++)
                {
                    string erstwahl = Convert.ToString(slist_range.Cells[i + 2, SPALTE_ERSTWAHL].Value);
                    if (erstwahl != null)
                    {
                        if (erstwahl.Trim() == "") erstwahl = null; 
                    }
                    if (zuordnungen[i] != null)
                    {
                        slist_range.Cells[i + 2, SPALTE_ZUORDNUNG].Value = zuordnungen[i];
                        slist_range.Cells[i + 2, SPALTE_ZUORDNUNG + 1].Value = null;
                        slist_range.Cells[i + 2, SPALTE_WUSTUNDENNEU].Value = schueler_wustunden[i] + kurse_stunden[kurse_id.IndexOf(zuordnungen[i])];
                    }
                    else if ((schueler_wustunden[i] < 5) || (erstwahl != null))
                    {
                        slist_range.Cells[i + 2, SPALTE_ZUORDNUNG].Value = null;
                        slist_range.Cells[i + 2, SPALTE_ZUORDNUNG + 1].Value = "!";
                    }
                    else
                    {
                        slist_range.Cells[i + 2, SPALTE_ZUORDNUNG].Value = null;
                    }
                }
                wu_liste.Save();
                wu_liste.Close();
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                MessageBox.Show("Datei existiert nicht\noder andere COMException");
            }
            finally
            {
                try
                {
                    wu_liste.Save();
                    wu_liste.Close();
                }
                catch (Exception)
                {
                }
            }
        }
        
        private String[] algorithmus()
        {
            List<int> zuloeschende_items = new List<int>();
            List<int> kurs = new List<int>();
            int[] wahlen = new int[kurse_id.Count];
            String[] schueler_zuordnungen = new String[schueler_namen.Count];
            var random = new Random();
            #region Erstwahlen werden zugeordnet
            add_item_to_log("Erstwahlen werden zugeordnet");
            for (int n=0;n<wahlen.Length;n++)
            {
                wahlen[n] = 0; //Zum sichergehen, dass jedes Item von wahlen 0 ist
            }
            for (int slist_counter=0; slist_counter<schueler_id.Count; slist_counter++)
            {
                for (int kid_counter=0; kid_counter < kurse_id.Count; kid_counter++)
                {
                    if (String.Equals(kurse_id[kid_counter], schueler_erstwahl[slist_counter]))
                    {
                        wahlen[kid_counter]++; //die Anzahl an Erstwählern wird in wahlen geschrieben
                    }
                }
            }
            for (int kid_counter = 0; kid_counter < kurse_id.Count; kid_counter++)
            {
                if (wahlen[kid_counter] <= kurse_maxpersonen[kid_counter]) //Wenn es weniger oder gleich viele Erstwähler gibt, wie die maximale Größe des Kurses
                {
                    if (wahlen[kid_counter] != 0) add_item_to_log("Jede Erstwahl von " + kurse_id[kid_counter] + " wird zugeordnet");
                    for (int slist_counter = 0; slist_counter < schueler_id.Count; slist_counter++)
                    {
                        if (String.Equals(kurse_id[kid_counter], schueler_erstwahl[slist_counter]))
                        {
                            schueler_zuordnungen[schueler_id[slist_counter] - 2] = kurse_id[kid_counter]; //Jedem Schüler der diesen Kurs erstgewählt hat bekommt diesen zugeordnet
                            kurse_maxpersonen[kid_counter]--; //Für jeden zugeordneten Schüler wird die maximale Größe verringert, die Variable zählt jetzt die freien Plätze
                            zuloeschende_items.Add(slist_counter); //Jeder zugeordnete Schüler wird in diese Liste geschrieben um ihn später aus den schueler listen zu löschen
                            //Es wird die Position des Schülers in den schueler Listen gespeichert
                        }
                    }
                }
                else if (wahlen[kid_counter] > kurse_maxpersonen[kid_counter]) //Wenn es mehr Erstwähler gibt, als der Kurs fassen kann sollen überschüssige Schüler zufällig ausgewählt werden
                {
                    add_item_to_log("Nicht jede Erstwahl von " + kurse_id[kid_counter] + " kann zugeordnet werden");
                    kurs.Clear();// die Liste kurs wird gelert
                    for (int slist_counter = 0; slist_counter < schueler_id.Count; slist_counter++)
                    {
                        if (String.Equals(kurse_id[kid_counter], schueler_erstwahl[slist_counter]))
                        {
                            kurs.Add(slist_counter);//die position der Schüler in den schueler listen wird in kurs geschrieben
                        }
                    }
                    for (int n = 0; n < wahlen[kid_counter] - kurse_maxpersonen[kid_counter]; n++)
                    {
                        if (kurs.Count != 0)
                        {
                            kurs.Remove(kurs[random.Next(kurs.Count)]);//es werden überschüssige Schüler zufällig aus kurs gelöscht
                        } 
                    }
                    for (int kurs_counter = 0; kurs_counter < kurs.Count; kurs_counter++)
                    {
                        schueler_zuordnungen[schueler_id[kurs[kurs_counter]] - 2] = kurse_id[kid_counter]; //Allen Schülern, die noch in kurs drin sind wird der entsprechende Kurs zugeordnet
                        kurse_maxpersonen[kid_counter]--; //Freie Plätze werden runtergezählt
                        zuloeschende_items.Add(kurs[kurs_counter]); //positionen der Eingeteilten Schüler wird in die Liste geschrieben
                    }
                }
            }
            zuloeschende_items.Sort();
            schueler_lists_reinigen(zuloeschende_items);
            #endregion

            #region Zweitwahlen werden zugeordnet
            add_item_to_log("Zweitwahlen werden zugeordnet");
            zuloeschende_items.Clear();
            for (int n = 0; n < wahlen.Length; n++)
            {
                wahlen[n] = 0; //wahlen wird wieder geleert
            }
            for (int slist_counter = 0; slist_counter < schueler_id.Count; slist_counter++)
            {
                for (int kid_counter = 0; kid_counter < kurse_id.Count; kid_counter++)
                {
                    if (String.Equals(kurse_id[kid_counter], schueler_zweitwahl[slist_counter]))
                    {
                        wahlen[kid_counter]++; //wahlen wird neu gefüllt, diesmal mit der kleineren schueler liste und den zweitwahlen
                    }
                }
            }
            for (int kid_counter = 0; kid_counter < kurse_id.Count; kid_counter++)
            {
                if (wahlen[kid_counter] <= kurse_maxpersonen[kid_counter])
                {
                    if (wahlen[kid_counter] != 0) add_item_to_log("Jede übrig gebliebene Zweitwahl von " + kurse_id[kid_counter] + " wird zugeordnet");
                    for (int slist_counter = 0; slist_counter < schueler_id.Count; slist_counter++)
                    {
                        if (String.Equals(kurse_id[kid_counter], schueler_zweitwahl[slist_counter]))
                        {
                            schueler_zuordnungen[schueler_id[slist_counter] - 2] = kurse_id[kid_counter]; //wenn eine zweitwahl weniger getätigt wurde als freie Plätze da sind werden alle die diese Zweitwahl getätigt haben zugeordnet
                            kurse_maxpersonen[kid_counter]--;
                            zuloeschende_items.Add(slist_counter);
                        }
                    }
                }
                else if (wahlen[kid_counter] > kurse_maxpersonen[kid_counter])
                {
                    add_item_to_log("Nicht jede Zweitwahl von " + kurse_id[kid_counter] + " kann zugeordnet werden");
                    kurs.Clear();
                    for (int slist_counter = 0; slist_counter < schueler_id.Count; slist_counter++)
                    {
                        if (String.Equals(kurse_id[kid_counter], schueler_zweitwahl[slist_counter]))
                        {
                            kurs.Add(slist_counter);
                        }
                    }
                    for (int n = 0; n < wahlen[kid_counter] - kurse_maxpersonen[kid_counter]; n++)
                    {
                        if (kurs.Count != 0)
                        {
                            kurs.Remove(kurs[random.Next(kurs.Count)]);
                        }
                    }
                    for (int kurs_counter = 0; kurs_counter < kurs.Count; kurs_counter++)
                    {
                        schueler_zuordnungen[schueler_id[kurs[kurs_counter]] - 2] = kurse_id[kid_counter];
                        kurse_maxpersonen[kid_counter]--;
                        zuloeschende_items.Add(kurs[kurs_counter]);
                    }
                }
            }
            zuloeschende_items.Sort();
            schueler_lists_reinigen(zuloeschende_items);
            #endregion

            #region Drittwahlen werden zugeordnet
            add_item_to_log("Drittwahlen werden zugeordnet");
            zuloeschende_items.Clear();
            for (int n = 0; n < wahlen.Length; n++)
            {
                wahlen[n] = 0;
            }
            for (int slist_counter = 0; slist_counter < schueler_id.Count; slist_counter++)
            {
                for (int kid_counter = 0; kid_counter < kurse_id.Count; kid_counter++)
                {
                    if (String.Equals(kurse_id[kid_counter], schueler_drittwahl[slist_counter]))
                    {
                        wahlen[kid_counter]++;
                    }
                }
            }
            for (int kid_counter = 0; kid_counter < kurse_id.Count; kid_counter++)
            {
                if (wahlen[kid_counter] <= kurse_maxpersonen[kid_counter])
                {
                    if (wahlen[kid_counter] != 0) add_item_to_log("Jede übrig gebliebene Drittwahl von " + kurse_id[kid_counter] + " wird zugeordnet");
                    for (int slist_counter = 0; slist_counter < schueler_id.Count; slist_counter++)
                    {
                        if (String.Equals(kurse_id[kid_counter], schueler_drittwahl[slist_counter]))
                        {
                            schueler_zuordnungen[schueler_id[slist_counter] - 2] = kurse_id[kid_counter];
                            kurse_maxpersonen[kid_counter]--;
                            zuloeschende_items.Add(slist_counter);
                        }
                    }
                }
                else if (wahlen[kid_counter] > kurse_maxpersonen[kid_counter])
                {
                    add_item_to_log("Nicht jede Drittwahl von " + kurse_id[kid_counter] + " kann zugeordnet werden");
                    kurs.Clear();
                    for (int slist_counter = 0; slist_counter < schueler_id.Count; slist_counter++)
                    {
                        if (String.Equals(kurse_id[kid_counter], schueler_drittwahl[slist_counter]))
                        {
                            kurs.Add(slist_counter);
                        }
                    }
                    for (int n = 0; n < wahlen[kid_counter] - kurse_maxpersonen[kid_counter]; n++)
                    {
                        if (kurs.Count != 0) 
                        {
                            kurs.Remove(kurs[random.Next(kurs.Count)]);
                        }
                    }
                    for (int kurs_counter = 0; kurs_counter < kurs.Count; kurs_counter++)
                    {
                        schueler_zuordnungen[schueler_id[kurs[kurs_counter]] - 2] = kurse_id[kid_counter];
                        kurse_maxpersonen[kid_counter]--;
                        zuloeschende_items.Add(kurs[kurs_counter]);
                    }
                }
            }
            zuloeschende_items.Sort();
            schueler_lists_reinigen(zuloeschende_items);
            #endregion

            return schueler_zuordnungen;

        }

        private void schueler_lists_reinigen(List<int> zuloeschende_items)
        {
            for (int n = 0; n < zuloeschende_items.Count; n++)
            {
                schueler_id.RemoveAt(zuloeschende_items[n] - n);
                schueler_erstwahl.RemoveAt(zuloeschende_items[n] - n);
                schueler_zweitwahl.RemoveAt(zuloeschende_items[n] - n);
                schueler_drittwahl.RemoveAt(zuloeschende_items[n] - n);
            }
        }

        private void add_item_to_log(object logmsg)
        {
            DateTime currentDate = DateTime.Now;
            string dtHour, dtMinute, dtSecond;
            dtHour = withzero(currentDate.Hour);
            dtMinute = withzero(currentDate.Minute);
            dtSecond = withzero(currentDate.Second);

            if (this.InvokeRequired) this.Invoke(new Action<object>(this.add_item_to_log), logmsg);
            else
            {
                lbx_log.Items.Add("[" + dtHour + ":" + dtMinute + ":" + dtSecond + "] " + logmsg);

                //The max number of items that the listbox can display at a time
                int NumberOfItems = lbx_log.ClientSize.Height / lbx_log.ItemHeight;

                if (lbx_log.TopIndex == lbx_log.Items.Count - NumberOfItems - 1)
                {
                    //The item at the top when you can just see the bottom item
                    lbx_log.TopIndex = lbx_log.Items.Count - NumberOfItems + 1;
                }
            }
        }

        private string withzero(int number)
        {
            if (number < 10)
            {
                return "0" + Convert.ToString(number);
            }
            else
            {
                return Convert.ToString(number);
            }
        }

        private void kurstlisten_schreiben()
        {
            try
            {
                kurslisten = myExcel.Workbooks.Add(1);
                for (int kurs = 0; kurs < kurse_id.Count; kurs++)
                {
                    add_item_to_log("Kursliste für " + kurse_name[kurs] + " wird erstellt");
                    Worksheet worksheet = (Worksheet)kurslisten.Worksheets.Add();
                    worksheet.Name = kurse_name[kurs];
                    createHeaders(worksheet, 1, 1, "Name", "A1", "A1", 0, true, 16);
                    createHeaders(worksheet, 1, 2, "Vorname", "B1", "B1", 0, true, 16);
                    createHeaders(worksheet, 1, 3, "Klasse", "C1", "C1", 0, true, 6);
                    createHeaders(worksheet, 1, 4, "Klassenlehrer", "D1", "D1", 0, true, 13);
                    int row = 2;
                    for (int schueler = 0; schueler < schueler_namen.Count; schueler++)
                    {
                        if (schueler_zuordnung[schueler] == kurse_id[kurs])
                        {
                            addData(worksheet, row, 1, schueler_namen[schueler], "A" + row, "A" + row, "");
                            addData(worksheet, row, 2, schueler_vornamen[schueler], "B" + row, "B" + row, "");
                            addData(worksheet, row, 3, schueler_klasse[schueler], "C" + row, "C" + row, "");
                            addData(worksheet, row, 4, schueler_klassenlehrer[schueler], "D" + row, "D" + row, "");
                            row++;
                        }
                    }
                }
                DateTime currentDate = DateTime.Now;
                String date = withzero(currentDate.Hour) + withzero(currentDate.Minute) + withzero(currentDate.Second) + "_" + withzero(currentDate.Day) + withzero(currentDate.Month) + currentDate.Year;
                document_path = new FileInfo(@tbx_path.Text).DirectoryName + "\\Wu-Einteilung_Kurslisten_" + date;
                kurslisten.SaveAs(@document_path);
                kurslisten.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, e.Source);
            }
        }

        private void klassenlisten_schreiben()
        {
            try
            {
                Microsoft.Office.Interop.Excel.Workbook klassenlisten;
                klassenlisten = myExcel.Workbooks.Add(1);
                List<string> klassen = schueler_klasse.Distinct().ToList();
                for (int klasse = 0; klasse < klassen.Count; klasse++)
                {
                    klassen.Sort();
                    add_item_to_log("Klassenliste für " + klassen[klasse] + " wird erstellt");
                    Worksheet worksheet = (Worksheet)klassenlisten.Worksheets.Add();
                    worksheet.Name = klassen[klasse];
                    createHeaders(worksheet, 1, 1, "Name", "A1", "A1", 0, true, 16);
                    createHeaders(worksheet, 1, 2, "Vorname", "B1", "B1", 0, true, 16);
                    createHeaders(worksheet, 1, 3, "Wuh bisher", "C1", "C1", 0, true, 10);
                    createHeaders(worksheet, 1, 4, "Erstwahl", "D1", "D1", 0, true, 10);
                    createHeaders(worksheet, 1, 5, "Zweitwahl", "E1", "E1", 0, true, 10);
                    createHeaders(worksheet, 1, 6, "Drittwahl", "F1", "F1", 0, true, 10);
                    createHeaders(worksheet, 1, 7, "Zuordnung", "G1", "G1", 0, true, 10);
                    int row = 2;
                    for (int schueler = 0; schueler < schueler_namen.Count; schueler++)
                    {
                        if (schueler_klasse[schueler] == klassen[klasse])
                        {
                            addData(worksheet, row, 1, schueler_namen[schueler], "A" + row, "A" + row, "");
                            addData(worksheet, row, 2, schueler_vornamen[schueler], "B" + row, "B" + row, "");
                            addData(worksheet, row, 3, Convert.ToString(schueler_wustunden[schueler]), "C" + row, "C" + row, "");
                            addData(worksheet, row, 4, schueler_erstwahl[schueler], "D" + row, "D" + row, "");
                            addData(worksheet, row, 5, schueler_zweitwahl[schueler], "E" + row, "E" + row, "");
                            addData(worksheet, row, 6, schueler_drittwahl[schueler], "F" + row, "F" + row, "");
                            addData(worksheet, row, 7, schueler_zuordnung[schueler], "G" + row, "G" + row, "");
                            row++;
                        }
                    }
                }
                DateTime currentDate = DateTime.Now;
                String date = withzero(currentDate.Hour) + withzero(currentDate.Minute) + withzero(currentDate.Second) + "_" + withzero(currentDate.Day) + withzero(currentDate.Month) + currentDate.Year;
                document_path = new FileInfo(@tbx_path.Text).DirectoryName + "\\Wu-Einteilung_klassenlisten_" + date;
                klassenlisten.SaveAs(@document_path);
                klassenlisten.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, e.Source);
            }
        }

        public void createHeaders(Worksheet worksheet, int row, int col, string htext, string cell1,
        string cell2, int mergeColumns, bool font, int size)
        {
            worksheet.Cells[row, col] = htext;
            Range workSheet_range = worksheet.get_Range(cell1, cell2);
            workSheet_range.Merge(mergeColumns);

            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            workSheet_range.Font.Bold = font;
            workSheet_range.ColumnWidth = size;
            workSheet_range.Font.Color = System.Drawing.Color.Black.ToArgb();
        }

        public void addData(Worksheet worksheet, int row, int col, string data, string cell1, string cell2, string format)
        {
            worksheet.Cells[row, col] = data;
            Range workSheet_range = worksheet.get_Range(cell1, cell2);
            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            workSheet_range.NumberFormat = format;
        }

    }
}
