using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

public partial class View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string firstLine = null;
        string strText = null;
        String str = Request.QueryString["file"];
        PdfReader reader = new PdfReader(Server.MapPath("Uploads\\Documents") + "\\" + str);

        for (int page = 1; page <= reader.NumberOfPages; page++)
        {
            ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy();

            String s = iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(reader, page, its);

            strText = strText + s;
            //string firstLine = string.Empty;
            if (s.Contains("\n"))
                firstLine += s.Split('\n')[1] + "<br>";
            else
                firstLine += s;
            continue;
        }
        divMainContent.InnerHtml = firstLine;

        reader.Close();
    }
}