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


public partial class user_profile : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        cn.ConnectionString = ConfigurationManager.ConnectionStrings["sqlconn"].ToString();
        cn.Open();
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
                    if (DateTime.Now.Hour < 12)
                        lbl_time.Text = "Good Morning";
                    else if (DateTime.Now.Hour < 15)
                        lbl_time.Text = "Good AfterNoon";
                    else
                        lbl_time.Text = "Good Evening";
                }
            }
        }
        else
        {
            Response.Redirect("home_login.aspx");
        }
    }

    protected void btn_msg_Click(object sender, EventArgs e)
    {
        Response.Redirect("friend_list.aspx");
    }
    protected void btn_basic_Click(object sender, EventArgs e)
    {
        Response.Redirect("new_user.aspx");
    }
}
