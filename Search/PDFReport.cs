using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using Search.Base;
using Image = iTextSharp.text.Image;
using Rectangle = iTextSharp.text.Rectangle;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

namespace Search
{
    public class PDFReport
    {
        public SearchReport<string> CurrentReport { get; set; }
        private PageEventHelper pageEventHelper;
        void WriteHeader(iTextSharp.text.Document doc)
        {
            iTextSharp.text.pdf.draw.LineSeparator line = new iTextSharp.text.pdf.draw.LineSeparator(2f, 100f, iTextSharp.text.BaseColor.BLACK, iTextSharp.text.Element.ALIGN_CENTER, -1);
            iTextSharp.text.Chunk linebreak = new iTextSharp.text.Chunk(line);
            iTextSharp.text.Font black = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 9f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
            var logo = new iTextSharp.text.Paragraph() { Alignment = 0 };
            logo.Add(new iTextSharp.text.Chunk("Graph", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 36, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
            logo.Add(new iTextSharp.text.Chunk("SEA", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 36, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(26, 188, 156))));
            doc.Add(logo);
            doc.Add(new iTextSharp.text.Chunk(line));
            // add front page
            doc.Add(new Paragraph(new iTextSharp.text.Chunk("GraphSEA", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 72, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(26, 188, 156)))));
            doc.Add(new Paragraph(new iTextSharp.text.Chunk("Graph Search Algorithms Benchmark Report", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 36, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))));

        }

        void WriteResultSummary(Document doc, List<KeyValuePair<ISearchAlgorithm<string>, SearchReport<string>>> results)
        {
            doc.Add(new Paragraph(new Chunk("Results Summary", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 24, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.BLACK))));
            doc.Add(new Paragraph(new Chunk("")));
            doc.Add(new Paragraph(new Chunk("")));
            doc.Add(new Paragraph(new Chunk("")));
            var bf = BaseFont.CreateFont(Application.StartupPath + @"\arial.ttf", BaseFont.IDENTITY_H, true);
            iTextSharp.text.Font NormalFont = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

            PdfPTable table = new PdfPTable(2) { WidthPercentage = 100 };

            table.AddCell(new PdfPCell() { Phrase = new iTextSharp.text.Phrase("Algorithm"), BackgroundColor = iTextSharp.text.BaseColor.GRAY });
            table.AddCell(new PdfPCell() { Phrase = new iTextSharp.text.Phrase("Elapsed time", NormalFont), BackgroundColor = iTextSharp.text.BaseColor.GRAY });

            table.SetWidths(new float[] { 40,  22 });

            for (int i = 0; i < results.Count; i++)
            {
                var sr = results[i];

                table.AddCell(new iTextSharp.text.Phrase(sr.Key.Name, NormalFont));
                table.AddCell(new iTextSharp.text.Phrase(sr.Value.ElapsedTime.ToString(), NormalFont));
   
            }
            doc.Add(table);
        }
        void WriteTableOfContent(Document doc)
        {
            doc.NewPage();
            doc.Add(new Paragraph(new iTextSharp.text.Chunk("Table of Contents", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 36, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(26, 188, 156)))));
            doc.Add(new Paragraph(" "));
            Chunk dottedLine = new Chunk(new DottedLineSeparator());
            List<KeyValuePair<String, int>> entries = pageEventHelper.TableOfContent;
            foreach (var entry in entries)
            {
                var p = new Paragraph(entry.Key);
                p.Add(dottedLine);
                p.Add(entry.Value.ToString());
                doc.Add(p);
            }

        }
        void WriteAlgorithmStep(iTextSharp.text.Document doc, KeyValuePair<INode<string>, NodeVisitAction> step, System.Drawing.Image graphImage)
        {
            if (step.Value == NodeVisitAction.PreVisit)
            {
                doc.Add(new Paragraph(new Chunk("Pre-Visit",
                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 18,
                        iTextSharp.text.Font.BOLDITALIC, iTextSharp.text.BaseColor.YELLOW))));


                doc.Add(new Paragraph(new Chunk("The algorithm has opened the node " + step.Key,
                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12,
                        iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.BLACK))));
            }
            else if (step.Value == NodeVisitAction.Visit)
            {
                doc.Add(new Paragraph(new Chunk("Visit",
                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 18,
                        iTextSharp.text.Font.BOLDITALIC, iTextSharp.text.BaseColor.GREEN))));


                doc.Add(new Paragraph(new Chunk("The algorithm has marked the node " + step.Key + " as visited",
                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12,
                        iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.BLACK))));
            }
            else if (step.Value == NodeVisitAction.PostVisit)
            {
                doc.Add(new Paragraph(new Chunk("Post-Visit",
                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 18,
                        iTextSharp.text.Font.BOLDITALIC, iTextSharp.text.BaseColor.BLUE))));


                doc.Add(new Paragraph(new Chunk("The algorithm has closed the node " + step.Key,
                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12,
                        iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.BLACK))));
            }
            else if (step.Value == NodeVisitAction.FoundResult)
            {
                doc.Add(new Paragraph(new Chunk("Result Found",
                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 18,
                        iTextSharp.text.Font.BOLDITALIC, iTextSharp.text.BaseColor.RED))));


                doc.Add(new Paragraph(new Chunk("The algorithm has found the target node " + step.Key,
                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12,
                        iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.BLACK))));
            }
            else if (step.Value == NodeVisitAction.Reset)
            {
                doc.Add(new Paragraph(new Chunk("Reset",
                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 18,
                        iTextSharp.text.Font.BOLDITALIC, iTextSharp.text.BaseColor.ORANGE))));


                doc.Add(new Paragraph(new Chunk("The algorithm is starting a new iteration with a different parameter (depth (IDLS) or Threshhold (IDA*))",
                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12,
                        iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.BLACK))));
            }

            doc.Add(new Paragraph(new Chunk("")));
            // add graph  state image
            AddImage(doc, graphImage);
            doc.NewPage();
        }

        void AddImage(Document doc, System.Drawing.Image bmp)
        {
            Image logo = Image.GetInstance(bmp, System.Drawing.Imaging.ImageFormat.Bmp);
            //Resize image depend upon your need
            logo.ScaleToFit(doc.PageSize.Width * 0.8f, doc.PageSize.Height * 0.6f);
            //Give space before image
            logo.SpacingBefore = 20f;
            //Give some space after the image
            logo.SpacingAfter = 1f;
            logo.Alignment = Element.ALIGN_CENTER;
            doc.Add(logo);
        }
        void WriteGraph(Document doc, System.Drawing.Image bmp, INode<string> start, INode<string> goal)
        {
            doc.Add(new Paragraph(new Chunk("The Graph", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 24, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.BLACK))));
            // add graph image
            AddImage(doc,bmp);

            doc.Add(new Paragraph(new Chunk($"We will perform a search for {goal} starting from {start} node.", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.BLACK))));
            doc.Add(new Paragraph(new Chunk("We will use various search algorithms such as (BFS, DFS, UCS, IDLS, Greedy, A*, IDA*).", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.BLACK))));
            doc.Add(new Paragraph(new Chunk("This report will include Algorithms benchmarks and resolution steps, by illustrating each step performed by the search algorithms.", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.BLACK))));

        }
        void WriteAlgorithmBenchmark(iTextSharp.text.Document doc, ISearchAlgorithm<string> algorithm, SearchReport<string> report)
        {
            iTextSharp.text.pdf.draw.LineSeparator line = new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, iTextSharp.text.BaseColor.BLACK, iTextSharp.text.Element.ALIGN_CENTER, -1);
            iTextSharp.text.Chunk linebreak = new iTextSharp.text.Chunk(line);
            Chunk c = new Chunk(algorithm.Name, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 24, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE));
            c.SetGenericTag(algorithm.Name);
            doc.Add(new Paragraph(c));
            // algorithm description
            Chunk desc = new Chunk(algorithm.Description, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.BLACK));
            doc.Add(new Paragraph(desc));
            // algorithm benchmark
            Chunk time = new Chunk("The algorithm took " + report.ElapsedTime + " to find the goal.", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, iTextSharp.text.Font.BOLDITALIC, iTextSharp.text.BaseColor.BLACK));
            doc.Add(new Paragraph(time));
            // write steps
            foreach (var step in report.Steps)     
                WriteAlgorithmStep(doc, step.StepInformation, step.GraphCapture );

            doc.NewPage();
        }
        void WriteDocument(iTextSharp.text.Document doc, List<KeyValuePair<ISearchAlgorithm<string>, SearchReport<string>>> results, System.Drawing.Image initialGraph)
        {
            doc.AddCreationDate();
            doc.AddAuthor("GraphSEA");
            doc.AddCreator("GraphSEA");
            doc.AddHeader("Header", "GraphSEA - Graph search algorithms benchmark report");
            WriteHeader(doc);
            doc.NewPage();
            WriteGraph(doc, initialGraph, results[0].Value.Result.Start, results[0].Value.Result.End);
            doc.NewPage();
            WriteResultSummary(doc, results);
            doc.NewPage();
            // algorithms benchmarks
            foreach (var res in results)
            {
                CurrentReport = res.Value;
                WriteAlgorithmBenchmark(doc, res.Key, res.Value);
            }

            WriteTableOfContent(doc);


        }
        public void SaveReport(string file, List<KeyValuePair<ISearchAlgorithm<string>, SearchReport<string>>> results, System.Drawing.Image initialGraph)
        {
            try
            {
                if (File.Exists(file))
                    File.Delete(file);



                using (FileStream fs = File.OpenWrite(file))
                {
                    iTextSharp.text.Document document = new iTextSharp.text.Document();
                    var writer = PdfWriter.GetInstance(document, fs);
                    pageEventHelper = new PageEventHelper();
                    writer.PageEvent = pageEventHelper;
                    document.Open();
                    WriteDocument(document, results, initialGraph);
                    document.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show("Failed to export pdf report", "Benchmark reporter", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
    public class PageEventHelper : PdfPageEventHelper
    {
        List<KeyValuePair<string, int>> toc = new List<KeyValuePair<string, int>>();
        public List<KeyValuePair<string, int>> TableOfContent
        {
            get => toc;
        }

        PdfContentByte cb;
        PdfTemplate template;

        iTextSharp.text.Font RunDateFont;
        public PageEventHelper()
        {
            BaseFont bf = BaseFont.CreateFont(Application.StartupPath + @"\arial.ttf", BaseFont.IDENTITY_H, true);
            RunDateFont = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
        }
        public override void OnOpenDocument(PdfWriter writer, iTextSharp.text.Document document)
        {
            cb = writer.DirectContent;
            template = cb.CreateTemplate(50, 50);
        }

        public override void OnGenericTag(PdfWriter writer, Document document, Rectangle rect, string text)
        {
            toc.Add(new KeyValuePair<string, int>(text, writer.PageNumber));
            base.OnGenericTag(writer, document, rect, text);
        }

        public override void OnEndPage(PdfWriter writer, iTextSharp.text.Document document)
        {
            base.OnEndPage(writer, document);

            int pageN = writer.PageNumber;
            String text = "Page " + pageN.ToString() + " of ";
            float len = this.RunDateFont.BaseFont.GetWidthPoint(text, this.RunDateFont.Size);

            iTextSharp.text.Rectangle pageSize = document.PageSize;

            cb.SetRGBColorFill(100, 100, 100);

            cb.BeginText();
            cb.SetFontAndSize(this.RunDateFont.BaseFont, this.RunDateFont.Size);
            cb.SetTextMatrix(document.LeftMargin, pageSize.GetBottom(document.BottomMargin));
            cb.ShowText(text);

            cb.EndText();

            cb.AddTemplate(template, document.LeftMargin + len, pageSize.GetBottom(document.BottomMargin));
        }

        public override void OnCloseDocument(PdfWriter writer, iTextSharp.text.Document document)
        {
            base.OnCloseDocument(writer, document);

            template.BeginText();
            template.SetFontAndSize(this.RunDateFont.BaseFont, this.RunDateFont.Size);
            template.SetTextMatrix(0, 0);
            template.ShowText("" + (writer.PageNumber));
            template.EndText();
        }
    }
}
