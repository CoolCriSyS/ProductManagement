<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AccountRequest._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>WolverineDirect.com Account Request</title>
    <link href="Styles/Styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="requestForm" runat="server" defaultfocus="txtCompanyName" defaultbutton="btnSubmit">
        <h2 id="header" runat="server">WolverineDirect.com Account Request</h2>
        <asp:Panel ID="pnlPreSubmit" runat="server" Visible="true">
            <p>Application is easy! Just follow these simple steps.</p>
            <ul>
                <li><strong>Step 1:</strong> Complete the form below by filling out <em>all</em> of the fields.</li>
                <li><strong>Step 2:</strong> Click on "Submit." Your request will go directly to our New Accounts team.</li>
            </ul>
            
            <p>New requests will be processed within 24 hours and within 2 business days you will receive an activation email from do.not.reply@wolverinedirect.com.</p>
            <p>To make sure you get your WolverineDirect.com emails, please add do.not.reply@wolverinedirect.com to your address book.</p>
            
            <asp:ValidationSummary ID="validationSummary" runat="server" ValidationGroup="default" CssClass="validationSummary" HeaderText="&nbsp;Please correct the following:" DisplayMode="BulletList" />
            <hr />
            <div class="info">
                <p>
                    You should fill out this request only if you are the Account Administrator.<br />
                    The Account Administrator is usually the owner or someone in the accounts payable department. Once the Account Administrator has signed up they can add additional users/buyers as needed.
                </p>
            </div>
            <div>
                <label for="<%= ddlLocale.ClientID %>">Registration for</label>
                <asp:DropDownList ID="ddlLocale" runat="server">
                    <asp:ListItem Text="USA" Value="US" Selected="True" />
                    <asp:ListItem Text="Canada" Value="CA" />
                </asp:DropDownList>
            </div><br />
            <div>
                <label for="<%= txtCompanyName.ClientID %>">Company Name</label>
                <asp:TextBox ID="txtCompanyName" runat="server" />
                <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server" ControlToValidate="txtCompanyName" ErrorMessage="Company Name is required" ValidationGroup="default" Display="None" />
                <label for="<%= txtCustomerNumber.ClientID %>">Customer Number</label>
                <asp:TextBox ID="txtCustomerNumber" runat="server" />
                <asp:RequiredFieldValidator ID="rfvCustomerNumber" runat="server" ControlToValidate="txtCustomerNumber" ErrorMessage="Customer Number is required" ValidationGroup="default" Display="None" />
            </div>
            <div class="center">
                <strong><em>Dealer Account Administrator Info</em></strong>
            </div>
            <div>
                <label for="<%= txtFirstName.ClientID %>">First Name</label>
                <asp:TextBox ID="txtFirstName" runat="server" />
                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="First Name is required" ValidationGroup="default" Display="None" />
                <label for="<%= txtLastName.ClientID %>">Last Name</label>
                <asp:TextBox ID="txtLastName" runat="server" />
                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last Name is required" ValidationGroup="default" Display="None" />
                
                <label for="<%= txtEmail.ClientID %>">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" />
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required" ValidationGroup="default" Display="None" />
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$" ErrorMessage="Enter a valid email" ValidationGroup="default" Display="None" />
                <asp:CompareValidator ID="cvEmail" runat="server" ControlToValidate="txtConfirmEmail" ControlToCompare="txtEmail" ErrorMessage="Email address mismatch" ValidationGroup="default" Display="None" />
                <label for="<%= txtConfirmEmail.ClientID %>">Confirm Email</label>
                <asp:TextBox ID="txtConfirmEmail" runat="server" />
                <asp:RequiredFieldValidator ID="rfvConfirmEmail" runat="server" ControlToValidate="txtConfirmEmail" ErrorMessage="Confirm Email is required" ValidationGroup="default" Display="None" />
                
                <label for="<%= txtPhone.ClientID %>">Phone</label>
                <asp:TextBox ID="txtPhone" runat="server" />
                <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone is required" ValidationGroup="default" Display="None" />
                <label for="<%= txtTitle.ClientID %>">Position/Title</label>
                <asp:TextBox ID="txtTitle" runat="server" />
            </div>
            <hr />
            <div id="displayMessage" runat="server" class="info"></div>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="default" OnCommand="btnSubmit_OnCommand" />
            <asp:Button ID="btnReset" runat="server" Text="Clear Form" CausesValidation="false" OnCommand="btnReset_OnCommand" />
        </asp:Panel>
        <asp:Panel ID="pnlPreSubmitFr" runat="server" Visible="false">
            <p>Il est facile de vous inscrire! Vous n’avez qu’à suivre ces deux étapes:</p>
            <ul>
                <li><strong>Étape 1:</strong> Remplissez tous les champs du formulaire ci-dessous.</li>
                <li><strong>Étape 2:</strong> Cliquez sur « Soumettre ». Votre demande sera acheminée directement à notre service des nouveaux comptes.</li>
            </ul>
            
            <p>Les nouvelles demandes seront traitées dans les 24 heures et au cours des deux jours ouvrables suivants, vous recevrez un courriel d’activation de do.not.reply@wolverinedirect.com.</p>
            <p>Pour vous assurer de recevoir les courriels de WolverineDirect.com, veuillez ajouter cette adresse à votre carnet: do.not.reply@wolverinedirect.com.</p>
            
            <asp:ValidationSummary ID="validationSummary1" runat="server" ValidationGroup="default" CssClass="validationSummary" HeaderText="&nbsp;S'il vous plaît corriger ce qui suit:" DisplayMode="BulletList" />
            <hr />
            <div class="info">
                <p>
                    Seul l’administrateur du compte peut remplir cette demande.<br />
                    L’administrateur du compte est généralement le propriétaire ou un membre du service des comptes fournisseurs. Une fois l’inscription faite par l’administrateur du compte, des utilisateurs/acheteurs peuvent être ajoutés au besoin.
                </p>
            </div>
            <div>
                <label for="<%= txtCompanyNameFr.ClientID %>">Nom de l’entreprise</label>
                <asp:TextBox ID="txtCompanyNameFr" runat="server" />
                <asp:RequiredFieldValidator ID="rfvCompanyNameFr" runat="server" ControlToValidate="txtCompanyNameFr" ErrorMessage="Nom de l'entreprise est nécessaire" ValidationGroup="default" Display="None" />
                <label for="<%= txtCustomerNumberFr.ClientID %>">Numéro du client</label>
                <asp:TextBox ID="txtCustomerNumberFr" runat="server" />
                <asp:RequiredFieldValidator ID="rfvCustomerNumberFr" runat="server" ControlToValidate="txtCustomerNumberFr" ErrorMessage="Numéro de client est nécessaire" ValidationGroup="default" Display="None" />
            </div>
            <div class="center">
                <strong><em>Renseignements sur l’administrateur de compte du détaillant</em></strong>
            </div>
            <div>
                <label for="<%= txtFirstNameFr.ClientID %>">Prénom</label>
                <asp:TextBox ID="txtFirstNameFr" runat="server" />
                <asp:RequiredFieldValidator ID="rfvFirstNameFr" runat="server" ControlToValidate="txtFirstNameFr" ErrorMessage="Prénom est nécessaire" ValidationGroup="default" Display="None" />
                <label for="<%= txtLastNameFr.ClientID %>">Nom</label>
                <asp:TextBox ID="txtLastNameFr" runat="server" />
                <asp:RequiredFieldValidator ID="rfvLastNameFr" runat="server" ControlToValidate="txtLastNameFr" ErrorMessage="Nom est nécessaire" ValidationGroup="default" Display="None" />
                
                <label for="<%= txtEmailFr.ClientID %>">Courriel</label>
                <asp:TextBox ID="txtEmailFr" runat="server" />
                <asp:RequiredFieldValidator ID="rfvEmailFr" runat="server" ControlToValidate="txtEmailFr" ErrorMessage="Courriel est nécessaire" ValidationGroup="default" Display="None" />
                <asp:RegularExpressionValidator ID="revEmailFr" runat="server" ControlToValidate="txtEmailFr" ValidationExpression="^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$" ErrorMessage="Entrez une adresse email valide" ValidationGroup="default" Display="None" />
                <asp:CompareValidator ID="cvEmailFr" runat="server" ControlToValidate="txtConfirmEmailFr" ControlToCompare="txtEmailFr" ErrorMessage="Inadéquation adresse e-mail" ValidationGroup="default" Display="None" />
                <label for="<%= txtConfirmEmailFr.ClientID %>">Confirmer le courriel</label>
                <asp:TextBox ID="txtConfirmEmailFr" runat="server" />
                <asp:RequiredFieldValidator ID="rfvConfirmEmailFr" runat="server" ControlToValidate="txtConfirmEmailFr" ErrorMessage="Confirmer le courriel est nécessaire" ValidationGroup="default" Display="None" />
                
                <label for="<%= txtPhoneFr.ClientID %>">Téléphone</label>
                <asp:TextBox ID="txtPhoneFr" runat="server" />
                <asp:RequiredFieldValidator ID="rfvPhoneFr" runat="server" ControlToValidate="txtPhoneFr" ErrorMessage="Téléphone est nécessaire" ValidationGroup="default" Display="None" />
                <label for="<%= txtTitleFr.ClientID %>">Titre/Fonction</label>
                <asp:TextBox ID="txtTitleFr" runat="server" />
            </div>
            <hr />
            <div id="Div1" runat="server" class="info"></div>
            <asp:Button ID="btnSubmitFr" runat="server" Text="Soumettre" ValidationGroup="default" OnCommand="btnSubmit_OnCommand" />
            <asp:Button ID="btnResetFr" runat="server" Text="Effacer" CausesValidation="false" OnCommand="btnReset_OnCommand" />
        </asp:Panel>
        <asp:Panel ID="pnlPostSubmit" runat="server" Visible="false">
            <div class="successMessage">
            <p><strong>Thank you. Your submission was received successfully.</strong></p>
            <div style="color: Black"><p>New requests will be processed within 24 hours and within 2 business days you will receive an activation email from do.not.reply@wolverinedirect.com.</p>
            <p>To make sure you get your WolverineDirect.com emails, please add do.not.reply@wolverinedirect.com to your address book.</p>
            </div>
            </div>
            <br />
            <asp:Button ID="btnSubmitAnother" runat="server" Text="Submit Another Request" CausesValidation="false" onclick="btnSubmitAnother_Click" />
        </asp:Panel>
        <asp:Panel ID="pnlPostSubmitFr" runat="server" Visible="false">
            <div class="successMessage">
                <p><strong>Merci. Votre demande a été reçu avec succès.</strong></p>
                <div style="color: Black"><p>Les nouvelles demandes seront traitées dans les 24 heures et dans les 2 jours ouvrables, vous recevrez un courriel d'activation de do.not.reply@wolverinedirect.com.</p>
                    <p>Pour vous assurer d'obtenir vos courriel WolverineDirect.com, s'il vous plaît ajouter do.not.reply@wolverinedirect.com à votre carnet d'adresse.</p>
                </div>
            </div>
            <br />
            <asp:Button ID="btnSubmitAnotherFr" runat="server" Text="Présenter une autre demande" CausesValidation="false" onclick="btnSubmitAnother_Click" />
        </asp:Panel>
    </form>
</body>
</html>
