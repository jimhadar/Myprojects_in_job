using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Umk_and_Rpd_on_Web {
    public partial class Logins : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Session["Year"] = (DateTime.Now.Month < 9) ? DateTime.Now.Year - 1 : DateTime.Now.Year;
        }
    }
}