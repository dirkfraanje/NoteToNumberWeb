using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NoteToNumberWeb
{
    public class HTMLToPDF
    {
        public async Task<bool> Generate(string html, string filepath)
        {
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            using (var page = await browser.NewPageAsync())
            {
                await page.SetContentAsync(html);
                var result = await page.GetContentAsync();
                await page.PdfAsync(filepath);
                return true;
            }

        }
    }
}
