using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interface;

namespace Model
{
    public class Highscore
    {
        

        //Declaring class variables
        private List<Entry> entries;

        //constructor
        public Highscore()
        {
            entries = new List<Entry>();
        }
        //Function to delete an entry from the list.
        public bool DeleteEntry(Entry E)
        {
            try
            {
                entries.Remove(E);
                //TODO: DB_connection.
                //No error was catched, return true, and terminate the function.
                return true;
            }
            catch
            {
                //An error was catched, return false, to let the caller know.
                return false;
            }
        }


        //Function to adding an element.
        public bool AddEntry(Entry E)
        {
            if (entries.Contains(E))
            {
                return false;
            }
            try
            {
                entries.Add(E);
                //TODO: DB_connection.
                //No error was catched, return true, and terminate the function.
                return true;
            }
            catch
            {
                //An error was catched, return false, to let the caller know.
                return false;
            }
        }

        //Function to reset the highscore:
        public void Reset()
        {
            entries.Clear();
        }

        //Function to return a entry:
        public Entry GetEntry(int ID)
        {
            try
            {
                //Return the element at the specified ID.
                return entries[ID];
            }
            catch
            {
                //If en error was encountered, just return null.
                return null;
            }
        }


        //Function to sort the entries, we're using a bubblesort, based on score.
        public void Sort()
        {
            int done = 0;
            Entry entry;
            while (done == 0)
            {
                done = 1;
                int n = 1;
                while (n < entries.Count)
                {
                    if (entries[n-1].score > entries[n].score)
                    {
                        entry = entries[n];
                        entries[n] = entries[n - 1];
                        entries[n - 1] = entry;
                        done = 0;
                    }
                }
            }
        }

        public List<IEntry> GetIEntries()
        {
            List<IEntry> ientrylist = new List<IEntry>();
            foreach (Entry entry in entries)
            {
                ientrylist.Add((IEntry)entry);
            }
            return ientrylist;
        }

        //cursor for iterator
        //int cursor = -1;

        //public void ResetCursor()
        //{
        //    cursor = -1;
        //}

        //public bool MoveNext()
        //{
        //    cursor++;

        //    if (cursor < entries.Count)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public Entry Current()
        //{
        //    return entries[cursor];
        //}

        //public void CurrentImages()
        //{
        //    //return entries[cursor].Image;
        //}
    }
}
