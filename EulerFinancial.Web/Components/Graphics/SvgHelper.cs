using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Resources;
using System.Text;
using System.Web;
using System.Xml;

namespace EulerFinancial.Web.Components.Graphics
{
    /// <summary>
    /// Helper object for accessing saved SVG content.
    /// </summary>
    public interface ISvgHelper
    {
        /// <summary>
        /// Gets the <see cref="MarkupString"/> at the given path.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        MarkupString? GetSvg(string name);
    }

    /// <summary>
    /// Helper object for accessing saved SVG content.
    /// </summary>    
    public class SvgHelper : ISvgHelper
    {
        /// <inheritdoc/>
        public MarkupString? GetSvg(string name)
        {
            var rm = new ResourceManager(typeof(SvgResource));

            var bytes = rm.GetObject(name) as byte[];
            if (bytes is not null)
            {
                XmlDocument xmlDoc = new();
                xmlDoc.LoadXml(Encoding.UTF8.GetString(bytes));

                var element = xmlDoc.DocumentElement;

                //return new MarkupString(Encoding.UTF8.GetString(bytes));

                if(element is not null && !string.IsNullOrEmpty(element.InnerXml))
                    return new MarkupString(element.InnerXml);
            }

            return null;
        }
    }
}
