using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Excel操作
    {
        ///// <summary>
        ///// 导出到Excel
        ///// </summary>
        //private void OutPut()
        //{
        //    string tmpFileName = DateTime.Now.ToString("yyyyMMdd") + "提现列表";
        //    string tmpContent = Header + Content;

        //    Response.Write("&amp;lt;script&amp;gt;document.close();&amp;lt;/script&amp;gt;");
        //    if (tmpContent.ToLower().IndexOf("<table") > -1)
        //    {
        //        ExportDsToXls(tmpFileName, tmpContent, false);
        //    }
        //    else
        //    {
        //        ExportDsToXls(tmpFileName, tmpContent, true);
        //    }
        //}


        ///// <summary>
        ///// dt转xls
        ///// </summary>
        //protected void ExportDsToXls(string fileName, string html, Boolean isAddTableHead)
        //{
        //    System.IO.StringWriter tw = new System.IO.StringWriter();
        //    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
        //    Response.Clear();
        //    Response.Charset = "gb2312";
        //    Response.ContentType = "application/vnd.ms-excel";
        //    Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
        //    Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName + ".xls");

        //    Response.Write("<html><head><META http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\"></head><body>");
        //    if (isAddTableHead)
        //        Response.Write("<TABLE WIDTH=\"100%\"  BORDER=\"1\" align=\"center\" CELLPADDING=\"0\" CELLSPACING=\"0\" >");

        //    Response.Write(html);

        //    Response.Write(tw.ToString());
        //    if (isAddTableHead)
        //        Response.Write("</table>");

        //    Response.Write("</body></html>");
        //    Response.End();
        //    hw.Close();
        //    hw.Flush();
        //    tw.Close();
        //    tw.Flush();
        //}


    }

}
