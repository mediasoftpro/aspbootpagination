<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register src="pagination.ascx" tagname="pagination" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <h1>Simple Pagination</h1>
    </div>
    <div>
        <uc1:pagination ID="pagination1" runat="server" />
    </div>
     <div>
       <h1>Advance Pagination</h1>
    </div>
    <div>
        <uc1:pagination ID="pagination2" runat="server" />
    </div>
    </form>
</body>
</html>
