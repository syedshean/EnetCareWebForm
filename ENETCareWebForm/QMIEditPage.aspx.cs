﻿using ENETCareBusinessLogic;
using ENETCareModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ENETCareWebForm
{
    public partial class QMIEditPage : System.Web.UI.Page
    {
        InterventionManager anInterventionManager = new InterventionManager();
        InterventionTypeManager anInterventionTypeManager = new InterventionTypeManager();
        ClientManager aClientManager = new ClientManager();
        UserManager aUserManager = new UserManager();


        public int interventionID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(Session["InterventionID"].ToString());
            DisableMasterPageButtons();
            if (!User.Identity.IsAuthenticated)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You need to Login first');window.location ='/LoginPage.aspx';", true);

            }
            else
            {
                if (!User.IsInRole("SiteEng"))
                {
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    authenticationManager.SignOut();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Unauthorised Access');window.location ='/LoginPage.aspx';", true);
                }
                else
                {
                    interventionID = Int32.Parse(Session["InterventionID"].ToString());
                    if (!IsPostBack)
                    {
                        PopulateFields();
                    }
                }
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string lastEditDate = DateTime.Now.ToString("yyyy-MM-dd");
            string result = anInterventionManager.UpdateIntervention(interventionID, lastEditDate, notesTextBox.Text, remainingLifeTextBox.Text);
            if (!(result.Equals("Quality management information update is successful.")))
            {
                errorMessageLabel.Text = result;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Quality management information update is successful.');window.location ='AllClientsWithInterventionViewPage.aspx';", true);
                //Response.Redirect("SiteEngineerHomePage.aspx");
            }
        }

        protected void BackToHomePageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SiteEngineerHomePage.aspx");
        }

        public void PopulateFields()
        {
            Intervention anIntervention = anInterventionManager.GetInterventionListByInterventionID(interventionID);
            InterventionTypeValueLabel.Text = anInterventionTypeManager.GetInterventionNameByTypeId(anIntervention.InterventionTypeID);
            clientNameValueLabel.Text = aClientManager.GetClientNameByClientID(anIntervention.ClientID);
            laboreRequiredValueLabel.Text = anIntervention.LabourRequired.ToString();
            costRequiredValueLabel.Text = anIntervention.CostRequired.ToString();
            interventionStatusValueLabel.Text = anIntervention.InterventionState;
            interventionDateValueLabel.Text = anIntervention.InterventionDate;
            if (!(string.IsNullOrEmpty(anIntervention.LastEditDate)))
                lastEditDateValueLabel.Text = anIntervention.LastEditDate;  /*DateTime.Now.ToString("yyyy-MM-dd");*/
            else
                lastEditDateValueLabel.Text = anIntervention.InterventionDate;
            if (!(string.IsNullOrEmpty(anIntervention.Notes)))
                notesTextBox.Text = anIntervention.Notes;
            userNameValueLabel.Text = aUserManager.GetUserNameByUserID(anIntervention.UserID);
            if (!(anIntervention.RemainingLife.Equals(null))) 
                remainingLifeTextBox.Text = anIntervention.RemainingLife.ToString();

            // Disable remaining life button if [anIntervention.InterventionState="Proposed"]
            if (anIntervention.InterventionState.Equals("Proposed"))
            {
                remainingLifeTextBox.Enabled = false;
                remainingLifeTextBox.Text = "";
                errorMessageLabel.Text = "Remaining life can't be changed for Proposed Intervention. Notes can be added.";
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllClientsWithInterventionViewPage.aspx");
        }

        public void DisableMasterPageButtons()
        {
            HtmlContainerControl navDiv = (HtmlContainerControl)this.Master.FindControl("nav");
            navDiv.Visible = false;
        }
    }
}