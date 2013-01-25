<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ImageGenerator._Default" EnableViewStateMac="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Image Generator</title>
    <link rel="Stylesheet" type="text/css" href="App_Themes/Default/main.css" runat="server" />
</head>
<body>
    <form id="imageGeneratorForm" runat="server">
        <fieldset>
            <legend>Upload Spreadsheet</legend>
            <p>
                <strong>Directions:</strong> Upload an excel spreadsheet (.xls or .xlsx) with the first sheet named '5 - Styles and Catalog' 
                and any column named 'Style Number' which contains a list of stock numbers for which to grab images.
            </p>
            <div>
                <asp:FileUpload ID="fuSpreadsheet" runat="server" />
            </div>
        </fieldset>
        <fieldset>
            <legend>Image Options</legend>
            <div>
                <label for="<%= ddlQuality.ClientID %>">Quality:</label>
                <asp:DropDownList ID="ddlQuality" runat="server">
                    <asp:ListItem Text="90" Value="90" Selected="True" />
                    <asp:ListItem Text="75" Value="75" />
                    <asp:ListItem Text="50" Value="50" />
                    <asp:ListItem Text="35" Value="35" />
                    <asp:ListItem Text="20" Value="20" />
                </asp:DropDownList>
            </div>
            <div>
                <label for="<%= ddlType.ClientID %>">Type:</label>
                <asp:DropDownList ID="ddlType" runat="server">
                    <asp:ListItem Text="jpg" Value="jpg" Selected="True" />
                    <asp:ListItem Text="png" Value="png" />
                </asp:DropDownList>
            </div>
        </fieldset>
        <div>
            <asp:Label ID="lblError" runat="server" CssClass="error" Visible="false" />
        </div>
        <div>
            <asp:Label ID="lblSuccess" runat="server" CssClass="success" Visible="false" />
        </div>
        <div>
            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnCommand="btnUpload_OnCommand" />
        </div>
        <div>
            <asp:Label ID="lblNotFound" runat="server" Visible="false" />
            <asp:TextBox ID="txtNotFound" runat="server" TextMode="MultiLine" Height="100px" Width="200px" Visible="false" />
        </div>
    </form>
</body>
</html>
