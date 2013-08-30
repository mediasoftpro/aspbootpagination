using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // simple pagination
            pagination1.TotalRecords = 50000;
            pagination1.PageSize = 20;
            pagination1.PageNumber = 1;
            pagination1.Default_Url = "default.aspx";
            pagination1.Pagination_Url = "default.aspx?p=[p]";
            pagination1.paginationCss = "pagination-small";
            pagination1.paginationStyle = 0; // 1: advance, 0: simple pagination
            pagination1.showFirst = true;
            pagination1.showLast = true;
            pagination1.BindPagination();

            // advance pagination
            pagination2.TotalRecords = 50000;
            pagination2.PageSize = 20;
            pagination2.PageNumber = 1;
            pagination2.Default_Url = "default.aspx";
            pagination2.Pagination_Url = "default.aspx?p=[p]";
            pagination2.paginationCss = "pagination-small";
            pagination2.paginationStyle = 1; // 1: advance, 0: simple pagination
            pagination2.showFirst = true;
            pagination2.showLast = true;
            pagination2.BindPagination();
        }
    }
}