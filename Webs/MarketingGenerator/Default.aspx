<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MarketingGenerator.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Marketing Info Generator</title>
    <link rel="Stylesheet" type="text/css" href="App_Themes/Default/main.css" runat="server" />
</head>
<body>
    <form id="marketingGeneratorForm" runat="server">
        <fieldset>
            <legend class="legendDefault">Upload Spreadsheet</legend>
            <p>
                <strong>Directions:</strong> Upload an excel spreadsheet with a sheet named '7 - Combined Data' 
                which contains any of the following columns: 'Style' (required, unique), 'SO', 'DC', 'Marketing Description', 
                'Marketing Description (FR)', 'Keywords', 'Size Run', 'Cat1', 'Cat2', 'Cat3', 'Cat4', 'Cat1 (FR)', 'Cat2 (FR)', 
                'Cat3 (FR)', and 'Cat4 (FR)'.
            </p>
            <div>
                <asp:FileUpload ID="fuSpreadsheet" runat="server" />
            </div>
            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnCommand="btnUpload_OnCommand" />&nbsp;|&nbsp;
            <asp:Button ID="btnClearData" runat="server" Text="Clear out existing data" OnCommand="btnClearData_OnCommand" />
            <asp:CheckBox ID="cbBackup" runat="server" Text="Backup data first" />
        </fieldset>
        <div>
            <asp:Label ID="lblError" runat="server" CssClass="error" Visible="false" />
        </div>
        <div>
            <asp:Label ID="lblSuccess" runat="server" CssClass="success" Visible="false" />
        </div>
        <fieldset>
            <legend class="legendDefault">ITE Import</legend>
            <p>
                <strong>Directions:</strong> Upload an ITE file to compare against the marketing data in the database. This will drop
                any data in the database that does not match the data in the ITE file per Sales Org & Dist Chan. It will also log the
                mismatches to an exceptions table in the database. Then use the file generators below to create the correct files for iCongo.
            </p>
            <div>
                <asp:FileUpload ID="fuITE" runat="server" />
            </div>
            <asp:Button ID="btnUploadITE" runat="server" Text="Run" OnCommand="btnUploadITE_OnCommand" />
        </fieldset>
        <fieldset>
            <legend class="legendDefault">B2C Marketing Information</legend>
            <p>
                <strong>Import B2C Data from XML docs:</strong> Select an XML file to parse and store its data
                in the database.
            </p>
            <div>
                <asp:FileUpload ID="fuB2CXmlData" runat="server" />
            </div>
            <asp:Button ID="btnXmlUpload" runat="server" Text="Upload" OnCommand="btnXmlUpload_OnCommand" />
            <hr />
            <p>
                <strong>B2C marketing information override:</strong> To update the data for a specific brand with Marketing info from B2C, 
                select the brand from the drop-down below and the click 'Run B2C Marketing Update' button.
            </p>
            <asp:DropDownList ID="ddlBrand" runat="server" Width="150">
                <asp:ListItem Text="All Brands" Value="0000~00" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Bates - US" Value="1000~09"></asp:ListItem>
                <asp:ListItem Text="CAT - US" Value="1000~10"></asp:ListItem>
                <asp:ListItem Text="Chaco - US" Value="3000~38"></asp:ListItem>
                <asp:ListItem Text="Cushe - US" Value="1000~18"></asp:ListItem>
                <asp:ListItem Text="HD - US" Value="1000~15"></asp:ListItem>
                <asp:ListItem Text="Hush Puppies - US" Value="1000~02"></asp:ListItem>
                <asp:ListItem Text="HyTest - US" Value="1000~20"></asp:ListItem>
                <asp:ListItem Text="Merrell App - US" Value="3000~AA"></asp:ListItem>
                <asp:ListItem Text="Merrell - US" Value="3000~30"></asp:ListItem>
                <asp:ListItem Text="Patagonia - US" Value="3000~85"></asp:ListItem>
                <asp:ListItem Text="Sebago App - US" Value="1700~AG"></asp:ListItem>
                <asp:ListItem Text="Sebago - US" Value="1700~80"></asp:ListItem>
                <asp:ListItem Text="Wolverine App - US" Value="1000~AD"></asp:ListItem>
                <asp:ListItem Text="Wolverine - US" Value="1000~06"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="btnRunB2CMarketingUpdate" runat="server" 
                Text="Run B2C Marketing Update" OnCommand="btnRunB2CMarketingUpdate_Click" />
            <br />
            <asp:CheckBox ID="cbForceB2C" runat="server" Text="Force B2C Marketing Info over existing Marketing Info" />
            <br />
            <p>
                <strong>Directions:</strong> To update blank English and French Marketing data for a specific brand with "Lorem ipsum", select the brand from the drop-down above and click the 'Update Marketing with Lorem Ipsum' button.
            </p>            
            <asp:Button ID="btnUpdateMarketingWithLoremIpsum" runat="server" Text="Update Marketing with Lorem Ipsum" OnCommand="btnUpdateMarketingWithLoremIpsum_Click" />
        </fieldset>
        <fieldset>
            <legend class="legendDefault">File Creation</legend>
            <asp:DropDownList ID="ddlFiles" runat="server" Width="150">
                <asp:ListItem Text="Marketing Info (csv)" Value="mCsv" Selected="True" />
                <asp:ListItem Text="Marketing Info (mkt)" Value="mMkt" />
                <asp:ListItem Text="Flag Info (flg)" Value="fFlg" />
                <asp:ListItem Text="Flag Info (flc)" Value="fFlc" />
                <asp:ListItem Text="Flag Info (fsa)" Value="fFsa" />
            </asp:DropDownList>
            <br />
            <asp:Button ID="btnCreateFiles" runat="server" Text="Download selected file" OnCommand="btnCreateFiles_OnCommand" />
            <br />
            <asp:CheckBox ID="cbB2CData" runat="server" Text="Use B2C data if available" />
        </fieldset>
        <div>
            <asp:Label ID="lblImageSuccess" runat="server" CssClass="success" Visible="false" />
        </div>
        <fieldset>
            <legend class="legendDefault">Image Creation</legend>
            <p>
                This will read all the database entries and attempt to generate images from stock numbers. You can restrict the brand for which you would like to have the images created by selecting it from the drop-down.
            </p>
            <asp:DropDownList ID="ddlGenerateImageBrand" runat="server" Width="150">
                <asp:ListItem Text="All Brands" Value="0000~00" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Bates - US" Value="1000~09"></asp:ListItem>
                <asp:ListItem Text="CAT - US" Value="1000~10"></asp:ListItem>
                <asp:ListItem Text="Chaco - US" Value="3000~38"></asp:ListItem>
                <asp:ListItem Text="Cushe - US" Value="1000~18"></asp:ListItem>
                <asp:ListItem Text="HD - US" Value="1000~15"></asp:ListItem>
                <asp:ListItem Text="Hush Puppies - US" Value="1000~02"></asp:ListItem>
                <asp:ListItem Text="HyTest - US" Value="1000~20"></asp:ListItem>
                <asp:ListItem Text="Merrell App - US" Value="3000~AA"></asp:ListItem>
                <asp:ListItem Text="Merrell - US" Value="3000~30"></asp:ListItem>
                <asp:ListItem Text="Patagonia - US" Value="3000~85"></asp:ListItem>
                <asp:ListItem Text="Sebago App - US" Value="1700~AG"></asp:ListItem>
                <asp:ListItem Text="Sebago - US" Value="1700~80"></asp:ListItem>
                <asp:ListItem Text="Wolverine App - US" Value="1000~AD"></asp:ListItem>
                <asp:ListItem Text="Wolverine - US" Value="1000~06"></asp:ListItem>
            </asp:DropDownList>
            <br />
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
            <div>
                <asp:Button ID="btnGetImages" runat="server" Text="Get images" OnCommand="btnGetImages_OnCommand" />
            </div>
        </fieldset>
    </form>
</body>
</html>
