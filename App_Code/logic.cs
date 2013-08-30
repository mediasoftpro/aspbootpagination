using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

/// <summary>
/// Summary description for logic
/// </summary>
public class logic
{
	public logic()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    // Main Pagination Logic
    public static ArrayList Simple_Pagination(int TotalPages, int Total_Links, int SelectedPage)
    {
        int i;
        ArrayList arr = new ArrayList();
        if (TotalPages < Total_Links)
        {
            for (i = 1; i <= TotalPages; i++)
            {
                arr.Add(i);
            }
        }
        else
        {
            int startindex = SelectedPage;
            int lowerbound = startindex - (int)Math.Floor((double)Total_Links / 2);
            int upperbound = startindex + (int)Math.Floor((double)Total_Links / 2);
            if (lowerbound < 1)
            {
                //calculate the difference and increment the upper bound
                upperbound = upperbound + (1 - lowerbound);
                lowerbound = 1;
            }
            //if upperbound is greater than total page is
            if (upperbound > TotalPages)
            {
                //calculate the difference and decrement the lower bound
                lowerbound = lowerbound - (upperbound - TotalPages);
                upperbound = TotalPages;
            }
            for (i = lowerbound; i <= upperbound; i++)
            {
                arr.Add(i);
            }


        }
        return arr;

    }

    // Advance Pagination version 2.0
    public static ArrayList Advance_Pagination(int TotalPages, int SelectedPage)
    {
        int i = 0;
        int value = 0;
        ArrayList arr = new ArrayList();
        int[] indexer = { 4, 40, 50, 400, 500, 4000, 5000, 40000, 50000 };
        if (SelectedPage == 1)
        {
            // 15 links
            for (i = 1; i <= 16; i++)
            {
                if (i <= 7)
                    value = i;
                else
                    value = value + indexer[i - 8];
                if (value > TotalPages)
                    value = TotalPages;
                if (!arr.Contains(value))
                    arr.Add(value);
            }
        }

        if (SelectedPage > 1)
        {
            ArrayList lower_arr = new ArrayList();
            ArrayList upper_arr = new ArrayList();
            int[] patter = { 1, 1, 1, 4, 40, 50, 400, 500, 4000, 5000, 40000 };
            for (i = 0; i <= 7; i++)
            {
                if (value == 0)
                    value = SelectedPage - patter[i];
                else
                    value = value - patter[i];

                if (value > 0)
                    lower_arr.Add(value);
            }
            value = 0;
            for (i = 0; i <= 7; i++)
            {
                if (value == 0)
                    value = SelectedPage + patter[i];
                else
                    value = value + patter[i];

                if (value > TotalPages)
                    value = TotalPages;

                upper_arr.Add(value);
            }

            //// add lower array values
            for (i = 0; i <= lower_arr.Count - 1; i++)
            {
                int rev_index = (lower_arr.Count - 1) - i;
                arr.Add(lower_arr[rev_index].ToString());
            }
            //// add selected record
            arr.Add(SelectedPage);
            //// add upper array values
            for (i = 0; i <= upper_arr.Count - 1; i++)
            {
                arr.Add(upper_arr[i].ToString());
            }
        }

        return arr;
    }
}