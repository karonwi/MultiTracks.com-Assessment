using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DataAccess;

public partial class SongDetails : MultitracksPage
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

                // Handle Song Details
                DataTable songTable = dataResult.Tables[2];
                if (songTable.Rows.Count > 0)
                {
                    Songs.DataSource = songTable;
                    Songs.DataBind();
                }
            }
            catch (Exception exception)
            {
                ErrorLabel.Text = "Sorry, an error occurred while loading song details. Please try again later.";
                ErrorLabel.Visible = true;
            }
        }
    }
}