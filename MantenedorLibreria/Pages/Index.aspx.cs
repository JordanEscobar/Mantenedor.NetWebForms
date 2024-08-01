using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MantenedorLibreria.Pages
{
    public partial class Index : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTabla();
      
        }

        void CargarTabla()
        {
            SqlCommand cmd = new SqlCommand("sp_load", con);
            cmd.CommandType=CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvproductos.DataSource = dt;
            gvproductos.DataBind();
            con.Close();
        }


        protected void Btnread_Click(object sender, EventArgs e)
        {
            string id;
            Button btnconsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnconsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Pages/CRUD.aspx?id="+id+"&op=R");
        }

        protected void Btnupdate_Click(object sender, EventArgs e)
        {
            string id;
            Button btnconsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnconsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Pages/CRUD.aspx?id=" + id + "&op=U");
        }

        protected void Btndelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnconsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnconsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Pages/CRUD.aspx?id=" + id + "&op=D");
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/CRUD.aspx?op=C");
        }
    }
}