using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DataAccess;

public partial class AlbumsDetails : MultitracksPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                //var artistID = Request.QueryString["ID"] ?? "31";
                var artistID = Session["artistID"] as string;
                if (string.IsNullOrEmpty(artistID))
                {
                    ErrorLabel.Text = "Invalid artist ID.";
                    ErrorLabel.Visible = true;
                    return;
                }

                var sql = new SQL();
                sql.Parameters.Add("artistID", artistID);
                var dataResult = sql.ExecuteStoredProcedureDS("GetArtistDetails");

                // Handle Album Details
                DataTable albumTable = dataResult.Tables[1];
                if (albumTable.Rows.Count > 0)
                {
                    Albums.DataSource = albumTable;
                    Albums.DataBind();
                }
            }
            catch (Exception exception)
            {
                ErrorLabel.Text = "Sorry, an error occurred while loading album details. Please try again later.";
                ErrorLabel.Visible = true;
            }
        }
    }
}