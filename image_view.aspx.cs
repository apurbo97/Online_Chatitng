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


public partial class image_view : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ProcessRequest();
    }



    public void ProcessRequest()
    {
        try
        { 
        String empno;
        if (Request.QueryString["id"] != null)
        {
            empno = Request.QueryString["id"].ToString();
            //empno = "P0002";
            Response.ContentType = "image/jpeg";
            Stream strm = ShowEmpImage(empno);
            byte[] buffer = new byte[4096];
            int byteSeq = strm.Read(buffer, 0, 4096);

            while (byteSeq > 0)
            {
                Response.OutputStream.Write(buffer, 0, byteSeq);
                byteSeq = strm.Read(buffer, 0, 4096);
            }
            Response.BinaryWrite(buffer);
            //Response.End();
        }
        }
        catch(Exception e)
        {
            Response.Write("NO parameter");
        }
           
    }

    public Stream ShowEmpImage(String itemid)
    {

        string conn = ConfigurationManager.ConnectionStrings["sqlconn"].ToString();
        //string conn = "Data Source=bss_server;Initial Catalog=eFlowerShop;Integrated Security=True";
        SqlConnection connection = new SqlConnection(conn);
        string sql = "SELECT prof_pic FROM user_account WHERE account_id= @ID";
        SqlCommand cmd = new SqlCommand(sql, connection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@ID", itemid);
        connection.Open();
        object img = cmd.ExecuteScalar();
        try
        {
            return new MemoryStream((byte[])img);
        }
        catch
        {
            return null;
        }
        finally
        {
            connection.Close();
        }

    }

}
