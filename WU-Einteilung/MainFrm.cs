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
        private List<string> kurse_id               = new List<string>();
        private List<int> kurse_maxpersonen = new List<int>();
        private List<int> kurse_minpersonen = new List<int>();
        private List<bool> kurse_klasse8 = new List<bool>();
        private List<bool> kurse_klasse9 = new List<bool>();
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
        }

        private void btn_list_Click(object sender, EventArgs e)
        {
            dokument_beschreiben(algorithmus());
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
                kurse_klasse8.Clear();
                kurse_klasse9.Clear();
                kurse_maxpersonen.Clear();
                kurse_minpersonen.Clear();
                add_item_to_log("Schüler werden ausgelesen");
                for (int i = 0; !String.Equals(slist_range.Cells[i + 3, 2].Value, null); i++)
                {
                    if (i % 50 == 49)
                    {
                        add_item_to_log(Convert.ToString(i + 1) + " Schüler wurden ausgelesen");
                    }
                    slist_range.Cells[i + 2, 1].Value = i;
                    schueler_id.Add(i + 2);
                    schueler_namen.Add(slist_range.Cells[i + 2, 2].Value);
                    schueler_vornamen.Add(slist_range.Cells[i + 2, 3].Value);
                    schueler_klasse.Add(slist_range.Cells[i + 2, 4].Value);
                    schueler_klassenlehrer.Add(slist_range.Cells[i + 2, 5].Value);
                    schueler_erstwahl.Add(slist_range.Cells[i + 2, 6].Value);
                    schueler_zweitwahl.Add(slist_range.Cells[i + 2, 7].Value);
                    schueler_drittwahl.Add(slist_range.Cells[i + 2, 8].Value);
                    schueler_anzahl = i;
                }
                add_item_to_log("Alle " + Convert.ToString(schueler_anzahl + 1) + " Schüler wurden ausgelesen");
                add_item_to_log("Kurse werden ausgelesen");
                for (int i = 0; !String.Equals(klist_range.Cells[i + 2, 1].Value, null); i++)
                {
                    kurse_id.Add(klist_range.Cells[i + 2, 1].value);
                    kurse_maxpersonen.Add(Convert.ToInt32(klist_range.Cells[i + 2, 8].value));
                    kurse_minpersonen.Add(Convert.ToInt32(klist_range.Cells[i + 2, 7].value));
                    if (klist_range.Cells[i + 2, 4].Value == 1) kurse_klasse8.Add(true); else kurse_klasse8.Add(false);
                    if (klist_range.Cells[i + 2, 5].Value == 1) kurse_klasse9.Add(true); else kurse_klasse9.Add(false);
                }
                add_item_to_log("Auslesen vollendet");
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

        private void dokument_beschreiben(String[] zuordnungen)
        {
            document_path = tbx_path.Text;
            try
            {
                wu_liste = myExcel.Workbooks.Open(@document_path);
                myExcel.Visible = false;
                slist = (Worksheet)wu_liste.Sheets[1];
                slist_range = slist.UsedRange;
                add_item_to_log("Zuordnungen werden in Tabelle eingetragen");
                for (int i = 0; i < zuordnungen.Length; i++)
                {
                    if (zuordnungen[i] != null)
                    {
                        slist_range.Cells[i + 2, 9].Value = zuordnungen[i];
                    }
                    else
                    {
                        slist_range.Cells[i + 2, 10].Value = "!";
                    }
                }
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
                    add_item_to_log("Jede Erstwahl von " + kurse_id[kid_counter] + " wird zugeordnet");
                    for (int slist_counter = 0; slist_counter < schueler_id.Count; slist_counter++)
                    {
                        if (String.Equals(kurse_id[kid_counter], schueler_erstwahl[slist_counter]))
                        {
                            schueler_zuordnungen[slist_counter] = kurse_id[kid_counter]; //Jedem Schüler der diesen Kurs erstgewählt hat bekommt diesen zugeordnet
                            kurse_maxpersonen[kid_counter]--; //Für jeden zugeordneten Schüler wird die maximale Größe verringert, die Variable zählt jetzt die freien Plätze
                            zuloeschende_items.Add(slist_counter); //Jeder zugeordnete Schüler wird in diese Liste geschrieben um ihn später aus den schueler listen zu löschen
                            //Es wird die Position des Schülers in den schueler Listen gespeichert
                        }
                    }
                }
                else if (wahlen[kid_counter] > kurse_maxpersonen[kid_counter]) //Wenn es mehr Erstwähler gibt, als der Kurs fassen kann sollen überschüssige Schüler zufällig ausgewählt werden
                {
                    kurs.Clear();// die Liste kurs wird gelert
                    for (int slist_counter = 0; slist_counter < schueler_id.Count; slist_counter++)
                    {
                        if (String.Equals(kurse_id[kid_counter], schueler_erstwahl[slist_counter]))
                        {
                            kurs.Add(slist_counter);//die position der Schüler in den schueler listen wird in kurs geschrieben
                        }
                    }
                    for (int n = 0; n <= wahlen[kid_counter] - kurse_maxpersonen[kid_counter]; n++)
                    {
                        kurs.Remove(kurs[random.Next(kurs.Count)]); //es werden überschüssige Schüler zufällig aus kurs gelöscht
                    }
                    for (int kurs_counter = 0; kurs_counter < kurs.Count; kurs_counter++)
                    {
                        schueler_zuordnungen[kurs[kurs_counter]] = kurse_id[kid_counter]; //Allen Schülern, die noch in kurs drin sind wird der entsprechende Kurs zugeordnet
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
                    for (int slist_counter = 0; slist_counter < schueler_id.Count; slist_counter++)
                    {
                        if (String.Equals(kurse_id[kid_counter], schueler_zweitwahl[slist_counter]))
                        {
                            schueler_zuordnungen[slist_counter] = kurse_id[kid_counter]; //wenn eine zweitwahl weniger getätigt wurde als freie Plätze da sind werden alle die diese Zweitwahl getätigt haben zugeordnet
                            kurse_maxpersonen[kid_counter]--;
                            zuloeschende_items.Add(slist_counter);
                        }
                    }
                }
                else if (wahlen[kid_counter] > kurse_maxpersonen[kid_counter])
                {
                    kurs.Clear();
                    for (int slist_counter = 0; slist_counter < schueler_id.Count; slist_counter++)
                    {
                        if (String.Equals(kurse_id[kid_counter], schueler_zweitwahl[slist_counter]))
                        {
                            kurs.Add(slist_counter);
                        }
                    }
                    for (int n = 0; n <= wahlen[kid_counter] - kurse_maxpersonen[kid_counter]; n++)
                    {
                        kurs.Remove(kurs[random.Next(kurs.Count)]);
                    }
                    for (int kurs_counter = 0; kurs_counter < kurs.Count; kurs_counter++)
                    {
                        schueler_zweitwahl[kurs[kurs_counter]] = kurse_id[kid_counter];
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
                    for (int slist_counter = 0; slist_counter < schueler_id.Count; slist_counter++)
                    {
                        if (String.Equals(kurse_id[kid_counter], schueler_drittwahl[slist_counter]))
                        {
                            schueler_zuordnungen[slist_counter] = kurse_id[kid_counter];
                            kurse_maxpersonen[kid_counter]--;
                            zuloeschende_items.Add(slist_counter);
                        }
                    }
                }
                else if (wahlen[kid_counter] > kurse_maxpersonen[kid_counter])
                {
                    kurs.Clear();
                    for (int slist_counter = 0; slist_counter < schueler_id.Count; slist_counter++)
                    {
                        if (String.Equals(kurse_id[kid_counter], schueler_drittwahl[slist_counter]))
                        {
                            kurs.Add(slist_counter);
                        }
                    }
                    for (int n = 0; n <= wahlen[kid_counter] - kurse_maxpersonen[kid_counter]; n++)
                    {
                        kurs.Remove(kurs[random.Next(kurs.Count)]);
                    }
                    for (int kurs_counter = 0; kurs_counter < kurs.Count; kurs_counter++)
                    {
                        schueler_zuordnungen[kurs[kurs_counter]] = kurse_id[kid_counter];
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
                schueler_id.Remove(schueler_id[zuloeschende_items[n] - n]);
                schueler_namen.Remove(schueler_namen[zuloeschende_items[n] - n]);
                schueler_vornamen.Remove(schueler_vornamen[zuloeschende_items[n] - n]);
                schueler_klasse.Remove(schueler_klasse[zuloeschende_items[n] - n]);
                schueler_klassenlehrer.Remove(schueler_klassenlehrer[zuloeschende_items[n] - n]);
                schueler_erstwahl.Remove(schueler_erstwahl[zuloeschende_items[n] - n]);
                schueler_zweitwahl.Remove(schueler_zweitwahl[zuloeschende_items[n] - n]);
                schueler_drittwahl.Remove(schueler_drittwahl[zuloeschende_items[n] - n]);
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

    }
}
