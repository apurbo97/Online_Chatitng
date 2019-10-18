using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;

public partial class chat_screen : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        cn.ConnectionString = ConfigurationManager.ConnectionStrings["sqlconn"].ToString();
        cn.Open();
        if (!Page.IsPostBack)
        {
            FileUpload1.Visible = false;
            btn_send_img.Visible = false;
            btn_upload.Text = "Image/Video";
        }
        if (Session.Contents["user_id"] != null)
        {
            if (Session.Contents["user_type"] == "user")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from user_account where account_id='" + Session.Contents["user_id"].ToString() + "'";
                cmd.Connection = cn;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    img_profPic.ImageUrl = "image_view.aspx?id=" + ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    lbl_name.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();

                }
            }
            if (Session.Contents["person"] != null)
            {
                lbl_person_name.Text = Session.Contents["name"].ToString();
                load_msg();
            }
            else
            {
                lbl_person_name.Text = "NO ONE";
            }

        }
        else
        {
            Response.Redirect("home_login.aspx");
        }
    }

    protected void btn_send_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select * from t_message where msg_id='" + txt_msg_id.Text + "'";
        cmd.Connection = cn;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            string acc_id = "";
            SqlCommand cmd_id = new SqlCommand();
            cmd_id.CommandText = "select max(msg_id) from t_message";
            cmd_id.Connection = cn;

            SqlDataAdapter da_id = new SqlDataAdapter(cmd_id);
            DataSet ds_id = new DataSet();
            da_id.Fill(ds_id);

            if (ds_id.Tables[0].Rows[0].ItemArray[0].ToString() == "")
            {
                acc_id = "MSG0000001";
            }
            else
            {
                string old_id = ds_id.Tables[0].Rows[0].ItemArray[0].ToString();
                int d = int.Parse(old_id.Substring(3)) + 1;
                acc_id = "MSG" + d.ToString().PadLeft(7, '0');

            }
            txt_msg_id.Text = acc_id;


            SqlCommand cmd_save = new SqlCommand();
            cmd_save.Connection = cn;
            string str = "insert into t_message values(";
            str += "'" + txt_msg_id.Text + "',";
            str += "'" + "text" + "',";
            str += "'" + txt_msg.Text + "',";
            str += "'" + "" + "',";
            str += "'" + DateTime.Now.ToString() + "',";
            str += "'" + Session.Contents["user_id"].ToString() + "',";
            str += "'" + Session.Contents["person"].ToString() + "')";

            cmd_save.CommandText = str;
            cmd_save.ExecuteNonQuery();

            txt_msg.Text = "";
            txt_msg_id.Text = "";
        }
        
    }
    private void load_msg()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select * from t_message where (sender='" + Session.Contents["person"].ToString() + "' and reciever='" + Session.Contents["user_id"].ToString() + "') or (reciever='" + Session.Contents["person"].ToString() + "' and sender='" + Session.Contents["user_id"].ToString() + "') order by date desc";
        cmd.Connection = cn;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grd_data.DataSource = ds;
        grd_data.DataBind();

        grd_hiden.DataSource = ds;
        grd_hiden.DataBind();
    }
    protected void grd_data_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int idx = int.Parse(e.CommandArgument.ToString());
        string str = "delete from t_message where msg_id='" + grd_hiden.Rows[idx].Cells[0].Text + "'";
        SqlCommand cmd = new SqlCommand(str, cn);
        cmd.ExecuteNonQuery();
        load_msg();
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        load_msg();
    }
    protected void btn_upload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.Visible)
        {
            FileUpload1.Visible = false;
            btn_send_img.Visible = false;
            txt_msg.Visible = true;
            btn_send.Visible = true;
            btn_upload.Text = "Image/Video";
        }
        else
        {
            FileUpload1.Visible = true;
            btn_send_img.Visible = true;
            txt_msg.Visible = false;
            btn_send.Visible = false;
            btn_upload.Text = "Text Message";
        }
    }
    protected void btn_send_img_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select * from t_message where msg_id='" + txt_msg_id.Text + "'";
        cmd.Connection = cn;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            string acc_id = "";
            SqlCommand cmd_id = new SqlCommand();
            cmd_id.CommandText = "select max(msg_id) from t_message";
            cmd_id.Connection = cn;

            SqlDataAdapter da_id = new SqlDataAdapter(cmd_id);
            DataSet ds_id = new DataSet();
            da_id.Fill(ds_id);

            if (ds_id.Tables[0].Rows[0].ItemArray[0].ToString() == "")
            {
                acc_id = "MSG0000001";
            }
            else
            {
                string old_id = ds_id.Tables[0].Rows[0].ItemArray[0].ToString();
                int d = int.Parse(old_id.Substring(3)) + 1;
                acc_id = "MSG" + d.ToString().PadLeft(7, '0');

            }
            txt_msg_id.Text = acc_id;

            string ext = Path.GetExtension(FileUpload1.FileName);
            string type = "";
            if (ext == ".jpg" || ext == ".gif" || ext == ".png")
            {
                type="image";
            }
            else if (ext == ".avi" || ext == ".mp4" || ext == ".mkv")
            {
                type = "video";
            }
            else
            {
                type = "other";
            }

            string filenewname = txt_msg_id.Text + ext;

            FileUpload1.SaveAs(Server.MapPath("~/uploaded/") + filenewname);

            SqlCommand cmd_save = new SqlCommand();
            cmd_save.Connection = cn;
            string str = "insert into t_message values(";
            str += "'" + txt_msg_id.Text + "',";
            str += "'" + type + "',";
            str += "'" + "" + "',";
            str += "'" + filenewname + "',";
            str += "'" + DateTime.Now.ToString() + "',";
            str += "'" + Session.Contents["user_id"].ToString() + "',";
            str += "'" + Session.Contents["person"].ToString() + "')";

            cmd_save.CommandText = str;
            cmd_save.ExecuteNonQuery();

             
        }
    }
    protected void grd_hiden_DataBound(object sender, EventArgs e)
    {
        
    }
    protected void grd_hiden_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      

        if (e.Row.Cells[1].Text == "image")
        {
            Image img = (Image)grd_data.Rows[e.Row.RowIndex].Cells[3].FindControl("img_msg");
            img.Visible = true;
            img.ImageUrl = "uploaded/" + e.Row.Cells[3].Text;
            //grd_data.Rows[e.Row.RowIndex].Cells[3].
        }
    }
}
