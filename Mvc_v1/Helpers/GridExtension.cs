using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Mvc_v1.Helpers
{
    public static class GridExtension
    {
        public static MyGrid<TModel> GetGrid<TModel>(
            this HtmlHelper<IEnumerable<TModel>> helper, string action)
        {
            var source = helper.ViewData.Model;
            return new MyGrid<TModel>(source, helper);
        }

        public static void AddInnerTag(this TagBuilder outTag, TagBuilder inTag)
        {
            outTag.InnerHtml += inTag.ToString();
        }
    }

    public class MyGrid<TModel>
    {
        private readonly IEnumerable<TModel> _source;
        private readonly HtmlHelper<IEnumerable<TModel>> _helper;
        private IList<Expression<Func<TModel, object>>> _columns = 
            new List<Expression<Func<TModel, object>>>();

        public MyGrid(IEnumerable<TModel> source, HtmlHelper<IEnumerable<TModel>> helper)
        {
            _source = source;
            _helper = helper;
        }

        public MvcHtmlString Build()
        {
            var table = new TagBuilder("table");
            table.AddCssClass("table");

            var tableHeader = new TagBuilder("tr");

            foreach (var column in _columns)
            {
                var th = new TagBuilder("th");
                th.InnerHtml = _helper.DisplayName(column.ToString()).ToString();
                tableHeader.AddInnerTag(th);
            }
            var thf = new TagBuilder("th");
            tableHeader.AddInnerTag(thf);



            foreach (var model in _source)
            {
                var tableRow = new TagBuilder("tr");

                foreach (var column in _columns)
                {
                    var td = new TagBuilder("td")
                    {
                        InnerHtml = column.Compile()(model).ToString()
                    };
                    tableRow.AddInnerTag(td);
                }
                var tdf = new TagBuilder("td")
                {
                    InnerHtml = "Edit"
                };
                tableRow.AddInnerTag(tdf);
                table.AddInnerTag(tableRow);
            }

            //table.AddInnerTag(tableHeader);


            return new MvcHtmlString(table.ToString()); 
        }
 
        public MyGrid<TModel> WithColumn(Expression<Func<TModel, object>> column)
        {
            _columns.Add(column);
            return this; 
        }
    }
}