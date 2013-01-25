using System;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web.UI.WebControls;
using MailMessage = System.Net.Mail.MailMessage;
using System.Text;

namespace AccountRequest
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["DisplayMessage"]))
                displayMessage.InnerText = ConfigurationManager.AppSettings["DisplayMessage"];

            btnSubmit.Enabled = ConfigurationManager.AppSettings["DisableSubmit"].ToLower() != "true";

            // Change verbiage to French translation
            if (Request.QueryString["lng"] != null && Request.QueryString["lng"].ToLower() == "fr")
            {
                pnlPreSubmit.Visible = false;

                pnlPreSubmitFr.Visible = true;
                header.InnerText = "WolverineDirect.com	Demande de compte";
            }
        }

        protected void btnSubmit_OnCommand(object sender, CommandEventArgs e)
        {
            if (IsValid)
            {
                if (Request.QueryString["lng"] != null && Request.QueryString["lng"].ToLower() == "fr")
                {
                    var sbFr = new StringBuilder();

                    sbFr.AppendLine(string.Format("Request for a new WolverineDirect.com account was submitted on {0} with the information listed below.{1}", DateTime.Today.ToShortDateString(), Environment.NewLine));
                    sbFr.AppendLine(string.Format("Company Name: {1}{0}Customer Number: {2}{0}{0}Name: {3} {4}{0}Title: {5}{0}Email: {6}{0}Phone: {7}",
                                  Environment.NewLine, txtCompanyNameFr.Text, txtCustomerNumberFr.Text, txtFirstNameFr.Text,
                                  txtLastNameFr.Text, txtTitleFr.Text, txtEmailFr.Text, txtPhoneFr.Text));

                    string messageBodyFr = sbFr.ToString();

                    var messageFr = new MailMessage("WWW Online Account Services <do.not.reply@wolverinedirect.com>",
                        ConfigurationManager.AppSettings["MailToCA"],
                        "WolverineDirect.com Login Request (French)", messageBodyFr);

                    var clientFr = new SmtpClient();
                    clientFr.Send(messageFr);

                    var dbFr = new DataAccess();
                    dbFr.InsertRequest(txtCompanyNameFr.Text, txtCustomerNumberFr.Text, txtFirstNameFr.Text, txtLastNameFr.Text,
                                     txtEmailFr.Text, txtPhoneFr.Text, txtTitleFr.Text, DateTime.Now, ddlLocale.SelectedValue);
                    
                    pnlPostSubmitFr.Visible = true;
                    pnlPreSubmitFr.Visible = false;

                    return;
                }
                
                var sb = new StringBuilder();

                sb.AppendLine(string.Format("Request for a new WolverineDirect.com account was submitted on {0} with the information listed below.{1}", DateTime.Today.ToShortDateString(), Environment.NewLine));
                sb.AppendLine(string.Format("Company Name: {1}{0}Customer Number: {2}{0}{0}Name: {3} {4}{0}Title: {5}{0}Email: {6}{0}Phone: {7}",
                              Environment.NewLine, txtCompanyName.Text, txtCustomerNumber.Text, txtFirstName.Text,
                              txtLastName.Text, txtTitle.Text, txtEmail.Text, txtPhone.Text));
                
                string messageBody = sb.ToString();

                var message = new MailMessage("WWW Online Account Services <do.not.reply@wolverinedirect.com>",
                    ddlLocale.SelectedValue == "CA" ? ConfigurationManager.AppSettings["MailToCA"] : ConfigurationManager.AppSettings["MailTo"],
                    "WolverineDirect.com Login Request", messageBody);
                
                var client = new SmtpClient();
                client.Send(message);

                var db = new DataAccess();
                db.InsertRequest(txtCompanyName.Text, txtCustomerNumber.Text, txtFirstName.Text, txtLastName.Text,
                                 txtEmail.Text, txtPhone.Text, txtTitle.Text, DateTime.Now, ddlLocale.SelectedValue);

                pnlPostSubmit.Visible = true;
                pnlPreSubmit.Visible = false;
            }
        }

        protected void btnReset_OnCommand(object sender, CommandEventArgs e)
        {
            foreach(var input in requestForm.Controls.OfType<TextBox>())
            {
                input.Text = string.Empty;
            }
        }

        protected void btnSubmitAnother_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}
