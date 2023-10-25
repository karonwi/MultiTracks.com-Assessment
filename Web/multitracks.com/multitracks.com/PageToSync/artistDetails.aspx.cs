using DataAccess;
using System;
using System.Data;
using System.Web.UI;

public partial class ArtistDetails : MultitracksPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string artistID = Request.QueryString["ID"] ?? Session["artistID"] as string;
            if (!string.IsNullOrEmpty(artistID))
            {
                LoadArtistDetails(artistID);
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var artistID = txtArtistID.Text.Trim();
        if (string.IsNullOrEmpty(artistID))
        {
            ErrorLabel.Text = "Invalid artist ID.";
            ErrorLabel.Visible = true;
            return;
        }

        Session["artistID"] = artistID; // Store artistID in session
        LoadArtistDetails(artistID);
    }

    private void LoadArtistDetails(string artistID)
    {
        try
        {
            var sql = new SQL();
            sql.Parameters.Add("artistID", artistID);
            var dataResult = sql.ExecuteStoredProcedureDS("GetArtistDetails");

            // Handle Artist Details
            DataTable artistTable = dataResult.Tables[0];
            if (artistTable.Rows.Count == 0)
            {
                ErrorLabel.Text = "Artist does not exist.";
                ErrorLabel.Visible = true;
                return;
            }
            if (artistTable.Rows.Count > 0)
            {
                DataRow row = artistTable.Rows[0];
                Biography.Text = row["biography"].ToString();
                heroImage.ImageUrl = row["heroURL"].ToString();
                heroImage.Attributes["srcset"] = row["heroURL"] + ", " + row["heroURL"] + " 2x";
            }

            // Handle Album Details
            DataTable albumTable = dataResult.Tables[1];
            if (albumTable.Rows.Count > 0)
            {
                DataRow albumRow = albumTable.Rows[0];
                bannerImage.ImageUrl = albumRow["AlbumImageURL"].ToString();
                bannerImage.Attributes["srcset"] = albumRow["albumImageUrl"] + ", " + albumRow["albumImageUrl"] + " 2x";
                BannerName.Text = albumRow["albumTitle"].ToString();

                Albums.DataSource = albumTable;
                Albums.DataBind();
            }

            // Handle Song Details
            DataTable songTable = dataResult.Tables[2];
            if (songTable.Rows.Count > 0)
            {
                Songs.DataSource = songTable;
                Songs.DataBind();
            }
            //ScriptManager.RegisterStartupScript(this, GetType(), "CloseModal", "$('#artistIdModal').modal('hide');", true);
            //ScriptManager.RegisterStartupScript(this, GetType(), "CloseModal", "closeArtistIdModal();", true);
            ClientScript.RegisterStartupScript(this.GetType(), "CloseModalScript", "closeArtistIdModal();", true);
        }
        catch (Exception exception)
        {
            ErrorLabel.Text = "Sorry, an error occurred while loading artist details. Please try again later.";
            ErrorLabel.Visible = true;
        }
    }
}
