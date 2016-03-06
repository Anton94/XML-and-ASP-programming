using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace xmlToSql
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            xmlToSql.Program.Init();
        }

        protected void ButtonAddXMLFiles_Click(object sender, EventArgs e)
        {
            string DirPath = @"C:\Users\Anton\Documents\Visual Studio 2013\Projects\XML-and-ASP.NET-programming\ASP.NET project\xmlToSql\xmlToSql\resources";
            xmlToSql.Program.InsertXmlDataToDB(DirPath);
            // Updates the grid veiw after adding the new data
            GridView1.DataBind();
            GridView2.DataBind(); 
        }

        protected void ButtonDeleteAllData_Click(object sender, EventArgs e)
        {
            xmlToSql.Program.DeleteDatabaseRecords();
            // Updates the grid veiw after deleting the data
            GridView1.DataBind();
            GridView2.DataBind(); 
        }
    }
}