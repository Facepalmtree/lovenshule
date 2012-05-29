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
        public bool RemoveEntry(int entryID)
        {
            try
            {
                foreach (Entry entry in entries)
                {
                    if (entry.entryID == entryID)
                    {
                        entries.Remove(entry);
                        //entry removed
                        return true;
                    }
                }
                //entry not removed
                return false;  
            }
            catch(Exception e)
            {
                throw e;  
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

        //Function to clear the highscore:
        public void Clear()
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
        public void BubbleSort()
        {
            int done = 0;
            Entry entry;
            while (done == 0)
            {
                done = 1;
                int n = 1;
                while (n < entries.Count)
                {
                    if (entries[n-1].score < entries[n].score)
                    {
                        entry = entries[n];
                        entries[n] = entries[n - 1];
                        entries[n - 1] = entry;
                        done = 0;
                    }
                    n++;
                }
            }
        }

        #region meyer quicksort
        //public void Sort()
        //{
        //    if( entries.Count > 1 )
        //        q_sort(0, entries.Count-1);
        //}
        //public void q_sort(int left, int right)
        //{
        //    int l_hold, r_hold, pivot;

        //    l_hold = left;
        //    r_hold = right;
        //    pivot = left;

        //    while (left < right)
        //    {
        //        while ((entries[left].score >= entries[pivot].score) && (left < right))
        //        {
        //            left++;
        //        }

        //        if (left != right)
        //        {
        //            entries[left] = entries[right];
        //            left++;
        //        }

        //        while ((entries[left].score <= entries[pivot].score) && (left < right))
        //        {
        //            left++;
        //        }

        //        if (left != right)
        //        {
        //            entries[right] = entries[left];
        //            right--;
        //        }
        //    }

        //    entries[left] = entries[pivot];
        //    pivot = left;
        //    left = l_hold;
        //    right = r_hold;

        //    if (left < pivot)
        //    {
        //        q_sort(left, pivot - 1);
        //    }

        //    if (right > pivot)
        //    {
        //        q_sort(pivot + 1, right);
        //    }
        //}
        #endregion 


        #region QuickSort

        public void Sort()
        {
            QuickSort(0, entries.Count - 1);
        }
        private void QuickSort(int left, int right)
        {
            int i = left, j = right;
            Entry temp;
            int pivot = Pivot(left+1, right+1);

            while (i <= j)
            {
                while (entries[i].score > entries[pivot].score && i < pivot)
                    i++;
                while (entries[j].score < entries[pivot].score && j > pivot)
                    j--;
                if (i <= j)
                {
                    temp = entries[i];
                    entries[i] = entries[j];
                    entries[j] = temp;

                    i++;
                    j--;
                }
            }

            if (left < j)

                QuickSort(left, j);

            if (i < right)

                QuickSort(i, right);
        }

        private int Pivot(int left, int right)
        {
            return (left + right) / 2;
        }

        #endregion

        public List<IEntry> GetIEntries()
        {
            List<IEntry> ientrylist = new List<IEntry>();
            foreach (Entry entry in entries)
            {
                ientrylist.Add((IEntry)entry);
            }
            return ientrylist;
        }

        /*//cursor for iterator

        int cursor = -1;

        public void ResetCursor()
        {
            cursor = -1;
        }

        public bool MoveNext()
        {
            cursor++;

            if (cursor < entries.Count)
            {
                return true;
            }
            return false;
        }

        public Entry Current()
        {
            return entries[cursor];
        }

        public void CurrentImages()
        {
            //return entries[cursor].Image;
        }
         */
    }
}
