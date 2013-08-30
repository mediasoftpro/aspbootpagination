using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

public partial class pagination : System.Web.UI.UserControl
{
    public int PageNumber = 1;
    public int PageSize = 20;
    public int TotalRecords = 0;
    public string Default_Url;
    public string Pagination_Url;
   
    public bool showFirst = true;
    public bool showLast = true;
    public string paginationCss = "pagination-small";
    public int paginationStyle = 1; // 1: advance, 0: normal
    // CssClasses

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public void BindPagination()
    {
        StringBuilder str = new StringBuilder();
        int TotalPages = (int)Math.Ceiling((double)this.TotalRecords / this.PageSize);
        int firstbound = 0;
        int lastbound = 0;

        string ToolTip = "";
        if (this.PageNumber > 1)
        {
            firstbound = 1;
            lastbound = firstbound + this.PageSize - 1;
            ToolTip = "Showing " + firstbound + " - " + lastbound + " records of " + this.TotalRecords + " records";
            if (this.showFirst)
            {
                // First Link
                str.Append("<li><a id=\"p_1\" class=\"pagination-css\" href=\"" + this.Default_Url + "\" title=\"" + ToolTip + "\"><i class=\"icon-backward\"></i></a></li>\n");
            }
            firstbound = ((TotalPages - 1) * this.PageSize);
            lastbound = firstbound + this.PageSize - 1;
            if (lastbound > this.TotalRecords)
            {
                lastbound = this.TotalRecords;
            }
            ToolTip = "Showing " + firstbound + " - " + lastbound + " records of " + this.TotalRecords + " records";
            // Previous Link Enabled
            string PreviousNavigationUrl = "";
            int _prevpage = PageNumber - 1;
            if (this.PageNumber > 2)
                PreviousNavigationUrl = Add_PageNumber(this.Pagination_Url, _prevpage.ToString());
            else
                PreviousNavigationUrl = this.Default_Url;
            int pid = (this.PageNumber - 1);
            if (pid < 1) pid = 1;
            str.Append("<li><a  id=\"pp_" + pid + "\" id=\"pp_" + pid + "\" href=\"" + PreviousNavigationUrl + "\" title=\"" + ToolTip + "\"><i class=\"icon-arrow-left\"></i></a></li>\n");

            // Normal Links
            str.Append(Generate_Pagination_Links(TotalPages));

            if (this.PageNumber < TotalPages)
            {
                str.Append(Generate_Previous_Last_Links(TotalPages));
            }
        }
        else
        {
            // Normal Links
            str.Append(Generate_Pagination_Links(TotalPages));
            // Next Last Links
            str.Append(Generate_Previous_Last_Links(TotalPages));
        }
        plnks.InnerHtml = "<ul class=\"pagination " + this.paginationCss + "\">\n" + str.ToString() + "</ul>\n";
    }

    

    private string Generate_Pagination_Links(int TotalPages)
    {
        StringBuilder str = new StringBuilder();
        int firstbound = 0;
        int lastbound = 0;
        string ToolTip = "";

        ArrayList arr = null;
        if (this.paginationStyle == 1)
            arr= logic.Advance_Pagination(TotalPages, this.PageNumber);
        else
            arr = logic.Simple_Pagination(TotalPages, 15, this.PageNumber);

        if (arr.Count > 0)
        {
            int i = 0;
            string LinkURL = "";
            string Item = "";
            for (i = 0; i <= arr.Count - 1; i++)
            {
                Item = arr[i].ToString();
                firstbound = ((int.Parse(Item) - 1) * this.PageSize) + 1;
                lastbound = firstbound + this.PageSize - 1;
                if (lastbound > this.TotalRecords)
                    lastbound = this.TotalRecords;
                ToolTip = "Showing " + firstbound + " - " + lastbound + " records of " + this.TotalRecords + " recodrs";
                // url settings
                // normal search
                if (Item == "1")
                     LinkURL = this.Default_Url;
                else
                     LinkURL = Add_PageNumber(this.Pagination_Url, Item);

                string _css = "";
                if (arr[i].ToString() == this.PageNumber.ToString())
                    _css = "class=\"active\"";
                str.Append("<li " + _css + "><a id=\"pg_" + arr[i].ToString() + "\" href=\"" + LinkURL + "\" title=\"" + ToolTip + "\">" + arr[i].ToString() + "</a></li>\n");
            }
        }

        return str.ToString();
    }

    private string Generate_Previous_Last_Links(int TotalPages)
    {
        StringBuilder str = new StringBuilder();
        int _nextpage = PageNumber + 1;
        string LastNavigationUrl = Add_PageNumber(this.Pagination_Url, TotalPages.ToString());
        string NextNavigationUrl = Add_PageNumber(this.Pagination_Url, _nextpage.ToString());

        int firstbound = ((TotalPages - 1) * this.PageSize) + 1;
        int lastbound = firstbound + this.PageSize - 1;
        if (lastbound > this.TotalRecords)
        {
            lastbound = this.TotalRecords;
        }
        string ToolTip = "Showing " + firstbound + " - " + lastbound + " records of " + this.TotalRecords + " records";
        // Next Link
        int pid = (this.PageNumber + 1);
        if (pid > TotalPages) pid = TotalPages;
        str.Append("<li><a id=\"pn_" + pid + "\" href=\"" + NextNavigationUrl + "\" title=\"" + ToolTip + "\" class=\"pagination-css\"><i class=\"icon-arrow-right\"></i></a></li>\n");
        // Last Link
        if (this.showLast)
        {
            ToolTip = "showing " + firstbound + " - " + lastbound + " records of " + this.TotalRecords + " records";
            str.Append("<li><a id=\"pl_" + TotalPages + "\" href=\"" + LastNavigationUrl + "\"  title=\"" + ToolTip + "\" class=\"pagination-css\"><i class=\"icon-forward\"></i></a></li>\n");
        }
        return str.ToString();

    }

    public string Add_PageNumber(string input, string value)
    {
        return Regex.Replace(input, @"\[p\]", value);
    }

   
}