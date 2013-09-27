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

namespace WU_Einteilung
{
    public partial class MainFrm : Form
    {
        #region Variabeln
        private Worksheet slist;
        private Worksheet klist;
        private Range slist_range;
        private Range klist_range;
        private Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
        private Microsoft.Office.Interop.Excel.Workbook wb;
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
        
        private void Read_Document(string path)
        {
            
        }

        private void btn_zon_Click(object sender, EventArgs e)
        {
            document_path = tbx_path.Text;
            wb = app.Workbooks.Open(@document_path);
            slist = (Worksheet)wb.Sheets[1];
            klist = (Worksheet)wb.Sheets[2];
            slist_range = slist.UsedRange;
            klist_range = klist.UsedRange;
            for (int i = 0; !String.Equals(slist_range.Cells[i+3, 2].Value,""); i++)
            {
                slist_range.Cells[i+2, 1].Value = i;
                schueler_id.Add(            slist_range.Cells[i+2, 1].Value);
                schueler_namen.Add(         slist_range.Cells[i+2, 2].Value);
                schueler_vornamen.Add(      slist_range.Cells[i+2, 3].Value);
                schueler_klasse.Add(        slist_range.Cells[i+2, 4].Value);
                schueler_klassenlehrer.Add( slist_range.Cells[i+2, 5].Value);
                schueler_erstwahl.Add(      slist_range.Cells[i+2, 6].Value);
                schueler_zweitwahl.Add(     slist_range.Cells[i+2, 7].Value);
                schueler_drittwahl.Add(     slist_range.Cells[i+2, 8].Value);
            }
            for (int i = 0; !String.Equals(klist_range.Cells[i+2, 1].Value,""); i++)
            {
                kurse_id.Add(klist_range.Cells[i + 2, 1].value);
                kurse_maxpersonen.Add(klist_range.Cells[i + 2, 8].value);
                kurse_minpersonen.Add(klist_range.Cells[i + 2, 7].value);
                if (klist_range.Cells[i + 2, 4].Value == 1) kurse_klasse8.Add(true); else kurse_klasse8.Add(false);
                if (klist_range.Cells[i + 2, 5].Value == 1) kurse_klasse9.Add(true); else kurse_klasse9.Add(false);
            }
            wb.Save();
            wb.Close();
        }

        private void tbx_path_TextChanged(object sender, EventArgs e)
        {

        }
<<<<<<< HEAD

        private void kurslisten_erstellen()
        {

        }
=======
        
        private void algorithmus()
        {
            List<int> zuloeschende_items = new List<int>();
            List<int> kurs = new List<int>();
            int[] wahlen = new int[kurse_id.Count];
            var random = new Random();
            #region Erstwahlen werden zugeordnet
            for (int n=0;n<wahlen.Length;n++)
            {
                wahlen[n] = 0; //Zum sichergehen, dass jedes Item von wahlen 0 ist
            }
            for (int slist_counter=0; slist_counter<schueler_id.Count; slist_counter++)
            {
                for (int kid_counter=0; kid_counter < kurse_id.Count; kid_counter++)
                {
                    if (String.Equals(kurse_id[kid_counter], slist_range.Cells[slist_counter + 2, 6].Value))
                    {
                        wahlen[kid_counter]++; //die Anzahl an Erstwählern wird in wahlen geschrieben
                    }
                }
            }
            for (int kid_counter = 0; kid_counter < kurse_id.Count; kid_counter++)
            {
                if (wahlen[kid_counter] <= kurse_maxpersonen[kid_counter]) //Wenn es weniger oder gleich viele Erstwähler gibt, wie die maximale Größe des Kurses
                {
                    for (int slist_counter = 0; slist_counter < schueler_id.Count; slist_counter++)
                    {
                        if (String.Equals(kurse_id[kid_counter], slist_range.Cells[schueler_id[slist_counter] + 2, 6].Value))
                        {
                            slist_range.Cells[schueler_id[slist_counter] + 2, 9].Value = kurse_id[kid_counter]; //Jedem Schüler der diesen Kurs erstgewählt hat bekommt diesen zugeordnet
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
                        if (String.Equals(kurse_id[kid_counter], slist_range.Cells[schueler_id[slist_counter] + 2, 6].Value))
                        {
                            kurs.Add(slist_counter);//die position der Schüler in den schueler listen wird in kurs geschrieben
                        }
                    }
                    for (int n = 0; n <= wahlen[kid_counter] - kurse_maxpersonen[kid_counter]; n++)
                    {
                        kurs.Remove(kurs[random.Next(kurs.Count)]);//es werden überschüssige Schüler zufällig aus kurs gelöscht
                    }
                    for (int kurs_counter = 0; kurs_counter < kurs.Count; kurs_counter++)
                    {
                        slist_range.Cells[schueler_id[kurs[kurs_counter]] + 2, 9].Value = kurse_id[kid_counter]; //Allen Schülern, die noch in kurs drin sind wird der entsprechende Kurs zugeordnet
                        kurse_maxpersonen[kid_counter]--; //Freie Plätze werden runtergezählt
                        zuloeschende_items.Add(kurs[kurs_counter]);//positionen der Eingeteilten Schüler wird in die Liste geschrieben
                    }
                }
            }
            zuloeschende_items.Sort();
            schueler_lists_reinigen(zuloeschende_items);
            #endregion

            #region Zweitwahlen werden zugeordnet
            zuloeschende_items.Clear();
            for (int n = 0; n < wahlen.Length; n++)
            {
                wahlen[n] = 0; //wahlen wird wieder geleert
            }
            for (int slist_counter = 0; slist_counter < schueler_id.Count; slist_counter++)
            {
                for (int kid_counter = 0; kid_counter < kurse_id.Count; kid_counter++)
                {
                    if (String.Equals(kurse_id[kid_counter], slist_range.Cells[schueler_id[slist_counter] + 2, 7].Value))
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
                        if (String.Equals(kurse_id[kid_counter], slist_range.Cells[schueler_id[slist_counter] + 2, 7].Value))
                        {
                            slist_range.Cells[schueler_id[slist_counter] + 2, 9].Value = kurse_id[kid_counter]; //wenn eine zweitwahl weniger getätigt wurde als freie Plätze da sind werden alle die diese Zweitwahl getätigt haben zugeordnet
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
                        if (String.Equals(kurse_id[kid_counter], slist_range.Cells[schueler_id[slist_counter] + 2, 7].Value))
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
                        slist_range.Cells[schueler_id[kurs[kurs_counter]] + 2, 9].Value = kurse_id[kid_counter];
                        kurse_maxpersonen[kid_counter]--;
                        zuloeschende_items.Add(kurs[kurs_counter]);
                    }
                }
            }
            zuloeschende_items.Sort();
            schueler_lists_reinigen(zuloeschende_items);
            #endregion

            #region Drittwahlen werden zugeordnet
            zuloeschende_items.Clear();
            for (int n = 0; n < wahlen.Length; n++)
            {
                wahlen[n] = 0;
            }
            for (int slist_counter = 0; slist_counter < schueler_id.Count; slist_counter++)
            {
                for (int kid_counter = 0; kid_counter < kurse_id.Count; kid_counter++)
                {
                    if (String.Equals(kurse_id[kid_counter], slist_range.Cells[schueler_id[slist_counter] + 2, 8].Value))
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
                        if (String.Equals(kurse_id[kid_counter], slist_range.Cells[schueler_id[slist_counter] + 2, 8].Value))
                        {
                            slist_range.Cells[schueler_id[slist_counter] + 2, 9].Value = kurse_id[kid_counter];
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
                        if (String.Equals(kurse_id[kid_counter], slist_range.Cells[schueler_id[slist_counter] + 2, 8].Value))
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
                        slist_range.Cells[schueler_id[kurs[kurs_counter]] + 2, 9].Value = kurse_id[kid_counter];
                        kurse_maxpersonen[kid_counter]--;
                        zuloeschende_items.Add(kurs[kurs_counter]);
                    }
                }
            }
            zuloeschende_items.Sort();
            schueler_lists_reinigen(zuloeschende_items);
            #endregion

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
>>>>>>> dev
    }
}
