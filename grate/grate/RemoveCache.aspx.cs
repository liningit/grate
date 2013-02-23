using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Tool;

namespace grate
{
    public partial class RemoveCache : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CacheTool.ClearCache();
        }
    }
}