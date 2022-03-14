using System;
using System.IO;
using System.Web.UI;

namespace ManagementObject
{
    class Program
    {
        static string[] _words = { "A", "B", "C" };
        
        static string GetDivElements()
        {
            // Initialize StringWriter instance.
            StringWriter stringWriter = new StringWriter();

            // Put HtmlTextWriter in using block because it needs to call Dispose.
            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
            {
                // Loop over some strings.
                foreach (var word in _words)
                {
                    // Some strings for the attributes.
                    string classValue = "ClassName";
                    string urlValue = "http://www.dotnetCodex.com/";
                    string imageValue = "image.jpg";

                    // The important part:
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, classValue);
                    writer.RenderBeginTag(HtmlTextWriterTag.Div); // Begin #1

                    writer.AddAttribute(HtmlTextWriterAttribute.Href, urlValue);
                    writer.RenderBeginTag(HtmlTextWriterTag.A); // Begin #2

                    writer.AddAttribute(HtmlTextWriterAttribute.Src, imageValue);
                    writer.AddAttribute(HtmlTextWriterAttribute.Width, "60");
                    writer.AddAttribute(HtmlTextWriterAttribute.Height, "60");
                    writer.AddAttribute(HtmlTextWriterAttribute.Alt, "");

                    writer.RenderBeginTag(HtmlTextWriterTag.Img); // Begin #3
                    writer.RenderEndTag(); // End #3

                    writer.Write(word);

                    writer.RenderEndTag(); // End #2
                    writer.RenderEndTag(); // End #1
                }
            }
            // Return the result.
            return stringWriter.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(GetDivElements());
        }
    }
}
