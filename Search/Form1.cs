using GraphX.PCL.Logic.Algorithms.OverlapRemoval;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using GraphX.PCL.Common.Enums;
using GraphX.PCL.Logic.Algorithms.OverlapRemoval;
using GraphX.PCL.Logic.Models;
using GraphX.Controls;
using GraphX.Controls.Models;
using QuickGraph;
using System.Windows;
using Search.Base;
using Search.Parser;
using DevComponents.DotNetBar;
using System.Threading;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using Search.Base.Algorithms;
using Brushes = System.Windows.Media.Brushes;
using System.Windows.Media.Imaging;
using DataFormats = System.Windows.DataFormats;

namespace Search
{
    public partial class Form1 : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        TextGraphDescriptorHandler text_parser = new TextGraphDescriptorHandler();
        XmlGraphDescriptorHandler xml_parser = new XmlGraphDescriptorHandler();
        ISearchAlgorithm<string>[] salgos = { new BFS<string>(),
            new DFS<string>(),
            new UCS<string>(),
            new IDLS<string>(),
            new AStar<string>(),
            new GBFS<string>(),
            new IDAStar<string>(),
        };
        public Form1()
        {
            InitializeComponent();
            LoadSearchAlgorithms();
            ResetGraph();
        }
        #region Drag and drop
        private void Form1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = System.Windows.Forms.DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
                LoadGraph(file);
        }
#endregion
        void ResetGraph() {
            start_node.Items.Clear();
            goal_node.Items.Clear();
            _gArea?.ResetNodesColor();
            var bg = new BiGraph<string>();
            current_graph = bg;
            wpfHost.Child = GenerateWpfVisuals<string>(bg, ref _gArea);
            _gArea.Generate();
            _zoomctrl.ZoomToFill();
        }
        void LoadSearchAlgorithms()
        {
            foreach(var salg in salgos)
            {
                var ci = new ComboBoxItem(salg.GetType().ToString() + "_algo" , salg.Name);
                ci.Tag = salg;
                algorithms.Items.Add(ci);
                algorithms.SelectedIndex = 0;
            }
        }
        #region Graph Utils
        private ZoomControl _zoomctrl;
        BiGraphArea<string> _gArea;
        BiGraph<string> current_graph;
        private UIElement GenerateWpfVisuals<K>(BiGraph<K> graph, ref BiGraphArea<K> _gArea)
              where K : class, IComparable<K>
        {
            _zoomctrl = new ZoomControl();
            ZoomControl.SetViewFinderVisibility(_zoomctrl, Visibility.Visible);
            var logic = new GXLogicCore<Node<K>, Base.Edge<K>, BidirectionalGraph<Node<K>, Base.Edge<K>>>();
            _gArea = new BiGraphArea<K>
            {
                // EnableWinFormsHostingMode = false,
                LogicCore = logic,
                EdgeLabelFactory = new DefaultEdgelabelFactory()
            };
            _gArea.ShowAllEdgesLabels(true);
            logic.Graph = graph;
            logic.DefaultLayoutAlgorithm = LayoutAlgorithmTypeEnum.LinLog;
            logic.DefaultLayoutAlgorithmParams = logic.AlgorithmFactory.CreateLayoutParameters(LayoutAlgorithmTypeEnum.LinLog);
            //((LinLogLayoutParameters)logic.DefaultLayoutAlgorithmParams). = 100;
            logic.DefaultOverlapRemovalAlgorithm = OverlapRemovalAlgorithmTypeEnum.FSA;
            logic.DefaultOverlapRemovalAlgorithmParams = logic.AlgorithmFactory.CreateOverlapRemovalParameters(OverlapRemovalAlgorithmTypeEnum.FSA);
            ((OverlapRemovalParameters)logic.DefaultOverlapRemovalAlgorithmParams).HorizontalGap = 50;
            ((OverlapRemovalParameters)logic.DefaultOverlapRemovalAlgorithmParams).VerticalGap = 50;
            logic.DefaultEdgeRoutingAlgorithm = EdgeRoutingAlgorithmTypeEnum.None;
            logic.AsyncAlgorithmCompute = false;
            _zoomctrl.Content = _gArea;
            _gArea.RelayoutFinished += gArea_RelayoutFinished;

            var myResourceDictionary = new ResourceDictionary { Source = new Uri("WpfTemplate\\template.xaml", UriKind.Relative) };
            _zoomctrl.Resources.MergedDictionaries.Add(myResourceDictionary);
            return _zoomctrl;
        }
        void gArea_RelayoutFinished(object sender, EventArgs e)
        {
            _zoomctrl.ZoomToFill();
        }
        public void LoadGraph(string file)
        {
            ParserResults<string> res = null;
            if (file.EndsWith(".xml"))
                res = xml_parser.Parse(file);
            else res = text_parser.Parse(file);

            ResetGraph();
            
            var bg = new BiGraph<string>();
            current_graph = bg;
            foreach (var n in res.Nodes)
            {
                

                bg.AddVertex((Node<string>)n);
                // add nodes to cboxes
                var ci = new ComboBoxItem(n.Key+"_node" , n.Key);
                ci.Tag = n;
                start_node.Items.Add(ci);
                goal_node.Items.Add(ci);
                // set defaults
                goal_node.SelectedIndex = goal_node.Items.Count - 1;
                start_node.SelectedIndex = 0;
                // set nodes event handlers
                n.OnPostVisit += N_OnPostVisit;
                n.OnPreVisit += N_OnPreVisit;
                n.OnVisit += N_OnVisit;
            }

            foreach (var e in res.Edges)
            {
                // set node edges
                e.Source.Edges.Add(e);
                bg.AddEdge((Base.Edge<string>)e);
            }
            
            wpfHost.Child = GenerateWpfVisuals<string>(bg, ref _gArea);
            _gArea.Generate();
            _zoomctrl.ZoomToFill();
            
        }
        #endregion

        private void open_graph_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                LoadGraph(ofd.FileName);
        }

        #region Simulation


        private void N_OnVisit(INode<string> node)
        {
            if (!benchmarking)
            {
                this.Invoke(new Action(delegate
                {
                    tracetxt.AppendText($"Visit {node}" + Environment.NewLine);
                    _gArea.ColorizeNode(node as Node<string>, System.Windows.Media.Brushes.Green);
                }));

                Thread.Sleep(delay.Value);
            }
            else
                current_report.Steps.Add(new SearchStep<string>
                {
                    StepInformation =
                        new KeyValuePair<INode<string>, NodeVisitAction>(node, NodeVisitAction.Visit)
                });
        }
        private void N_OnPreVisit(INode<string> node)
        {
            if (!benchmarking)
            {
                this.Invoke(new Action(delegate
                {
                    tracetxt.AppendText($"PreVisit {node}" + Environment.NewLine);
                    _gArea.ColorizeNode(node as Node<string>, System.Windows.Media.Brushes.Yellow);
                }));
                Thread.Sleep(predelay.Value);
            }
            else
                current_report.Steps.Add(new SearchStep<string>
                {
                    StepInformation =
                        new KeyValuePair<INode<string>, NodeVisitAction>(node, NodeVisitAction.PreVisit)
                });
        }
        private void N_OnPostVisit(INode<string> node)
        {
            if (!benchmarking)
            {
                this.Invoke(new Action(delegate
                {
                    tracetxt.AppendText($"PostVisit {node}" + Environment.NewLine);
                    _gArea.ColorizeNode(node as Node<string>, System.Windows.Media.Brushes.Blue);
                }));
                Thread.Sleep(postdelay.Value);
            }
            else
                current_report.Steps.Add(new SearchStep<string>
                {
                    StepInformation =
                        new KeyValuePair<INode<string>, NodeVisitAction>(node, NodeVisitAction.PostVisit)
                });
        }
        Thread simulation_thread;
        private ISearchAlgorithm<string> selected_algorithm;
        Stopwatch sw = new Stopwatch();
        public void RunSimulation()
        {
            try
            {
              
                this.Invoke(new Action(delegate
                {
                    _gArea.ResetNodesColor();
                    tracetxt.Text = "";
                }));
               selected_algorithm = (algorithms.SelectedItem as ComboBoxItem).Tag as ISearchAlgorithm<string>;
                Node<string> initial = (start_node.SelectedItem as ComboBoxItem).Tag as Node<string>;
                Node<string> final = (goal_node.SelectedItem as ComboBoxItem).Tag as Node<string>;
                this.Invoke(new Action(delegate
                {
                    _gArea.ResetInitialGoal();
                    _gArea.SetInitialGoal(initial,final);
                }));
                selected_algorithm.OnResultFound += Selected_algorithm_OnResultFound;
                selected_algorithm.OnResetRequired += Selected_algorithm_OnResetRequired;

                // set event handlers
                simulation_thread = new Thread(new ThreadStart(delegate
                {
                    sw.Start();
                    try
                    {
                        selected_algorithm.Initialize();
                        var sr = selected_algorithm.Search(initial, final.Key);
                        this.Invoke(new Action(delegate
                        {
                            selected_algorithm.OnResultFound -= Selected_algorithm_OnResultFound;
                            selected_algorithm.OnResetRequired -= Selected_algorithm_OnResetRequired;
                            buttonX1.Text = "Run";
                            simulation_thread = null;
                            if (sr.Found)
                            {
                                _gArea.ColorizePath(sr, Brushes.Red);
                                TracePath(sr);
                            }
                            MessageBoxEx.Show(this, "Simulation complete", "Simulation",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }));
                    }
                    catch (Exception ex)
                    {
                        this.Invoke(new Action(delegate
                        {
                            MessageBoxEx.Show(this, ex.Message, "Simulation Process", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }));
                    }
                    sw.Stop();
                    this.Invoke(new Action(delegate
                    {
                        tracetxt.AppendText("Elapsed time: "+ sw.Elapsed);
                    }));
                }));
                simulation_thread.Start();

            }catch(Exception ex)
            {
                MessageBoxEx.Show(this, ex.Message, "Simulation Execution", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void Selected_algorithm_OnResetRequired(object sender, EventArgs e)
        {
            if(!benchmarking)
                this.Invoke(new Action(delegate
                 {
                     _gArea.ResetNodesColor();
                     if (selected_algorithm is IDLS<string>)
                         tracetxt.AppendText("New DLS Iteration Depth=" + sender.ToString());
                     else if (selected_algorithm is IDAStar<string>)
                         tracetxt.AppendText("New IDA* Iteration Depth=" + sender.ToString());
                 }));
            else
                current_report.Steps.Add(new SearchStep<string>
                {
                    StepInformation =
                        new KeyValuePair<INode<string>, NodeVisitAction>(null, NodeVisitAction.Reset)
                });
        }

        private bool benchmarking = false;
        private Bitmap initialGraph;
        private SearchReport<string> current_report;
        private List<KeyValuePair<ISearchAlgorithm<string>, SearchReport<string>>> benchmarks = new List<KeyValuePair<ISearchAlgorithm<string>, SearchReport<string>>>();
        public void BenchmarkSimulation()
        {
            try
            {
                benchmarking = true;
                this.Invoke(new Action(delegate
                {
                    _gArea.ResetNodesColor();
                    tracetxt.Text = "";
                }));
                benchmarks.Clear();
                Node<string> initial = (start_node.SelectedItem as ComboBoxItem).Tag as Node<string>;
                Node<string> final = (goal_node.SelectedItem as ComboBoxItem).Tag as Node<string>;
                initialGraph = ScreenshotGraphView();
                this.Invoke(new Action(delegate
                {
                    _gArea.ResetInitialGoal();
                    _gArea.SetInitialGoal(initial, final);
                }));
                // set event handlers
                simulation_thread = new Thread(new ThreadStart(delegate
                    {
                        try
                        {
                            this.Invoke(new Action(delegate
                            {
                                buttonX2.Enabled = false;
                                buttonX1.Enabled = false;
                            }));

                            foreach (var selected_algorithm in salgos)
                            {
                           
                                selected_algorithm.OnResultFound += Selected_algorithm_OnResultFound;
                                selected_algorithm.OnResetRequired += Selected_algorithm_OnResetRequired;

                                selected_algorithm.Initialize();
                                current_report = new SearchReport<string>();
                                current_report.Timer.Start();
                                var sr = selected_algorithm.Search(initial, final.Key);
                                benchmarks.Add(
                                    new KeyValuePair<ISearchAlgorithm<string>, SearchReport<string>>(selected_algorithm,
                                        current_report));
                                current_report.Result = sr;
                                current_report.Timer.Stop();
                                current_report.Steps.Add(new SearchStep<string>
                                {
                                    StepInformation =
                                        new KeyValuePair<INode<string>, NodeVisitAction>(null, NodeVisitAction.Reset)
                                });
                                current_report.ElapsedTime = current_report.Timer.Elapsed;
                                selected_algorithm.OnResultFound -= Selected_algorithm_OnResultFound;
                                selected_algorithm.OnResetRequired -= Selected_algorithm_OnResetRequired;
                            }
                            this.Invoke(new Action(delegate
                            {
                      
                                simulation_thread = null;
                                DumpToReport();
                            }));
                        }
                        catch (Exception ex)
                        {
                            this.Invoke(new Action(delegate
                            {
                                MessageBoxEx.Show(this, ex.Message, "Benchmark Simulation Process",
                                    System.Windows.Forms.MessageBoxButtons.OK,
                                    System.Windows.Forms.MessageBoxIcon.Error);
                            }));
                          
                        }
                        this.Invoke(new Action(delegate
                        {
                            buttonX2.Enabled = true;
                            buttonX1.Enabled = true;
                            benchmarking = false;
                            MessageBoxEx.Show(this, "Benchmark successfully completed", "Benchmark simulation",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }));

                        
                    }));
                    simulation_thread.Start();
                    //simulation_thread.Join();
              

          

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(this, ex.Message, "Benchmark Simulation Execution", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void Selected_algorithm_OnResultFound(INode<string> node)
        {
            if (!benchmarking)
                this.Invoke(new Action(delegate {
                    _gArea.ColorizeNode(node as Node<string>, System.Windows.Media.Brushes.Red);
                    tracetxt.AppendText("Result found " + Environment.NewLine);}));
            else
                current_report.Steps.Add(new SearchStep<string>
                {
                    StepInformation =
                        new KeyValuePair<INode<string>, NodeVisitAction>(node, NodeVisitAction.FoundResult)
                });

        }
        void TracePath(SearchResult<string> sr)
        {
            tracetxt.AppendText("Path: " + Environment.NewLine);
            if(sr.Path.Count() > 0)
                foreach (var edge in sr.Path)
                    tracetxt.AppendText($"{edge.Source} -> {edge.Target} " + Environment.NewLine);
            else tracetxt.AppendText($"{sr.Start} " + Environment.NewLine);

        }
        #endregion

        #region UI Event Handlers
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (simulation_thread == null)
            {
                RunSimulation();
                buttonX1.Text = "Stop";
            }
            else
            {
                simulation_thread.Abort();
                simulation_thread = null;
                buttonX1.Text = "Run";
                
            }
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            BenchmarkSimulation();
        }
        private void save_report_Click(object sender, EventArgs e)
        {
            if (sfd_trace.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                File.WriteAllText(sfd_trace.FileName, tracetxt.Text);
        }

        private void create_graph_Click(object sender, EventArgs e)
        {
            ResetGraph();
        }

        private void add_node_Click(object sender, EventArgs e)
        {
            var avf = new AddVertexForm();
            avf.ShowDialog(this);
            if (avf.Add && current_graph != null)
            {
                var n = new Node<string>(avf.Name, avf.Heuristic);
                current_graph.AddVertex(n);
               
                var ci = new ComboBoxItem(n.Key + "_node", n.Key);
                ci.Tag = n;
                start_node.Items.Add(ci);
                goal_node.Items.Add(ci);

                // set defaults
                goal_node.SelectedIndex = goal_node.Items.Count - 1;
                start_node.SelectedIndex = 0;
                // set nodes event handlers
                n.OnPostVisit += N_OnPostVisit;
                n.OnPreVisit += N_OnPreVisit;
                n.OnVisit += N_OnVisit;


                wpfHost.Child = GenerateWpfVisuals<string>(current_graph, ref _gArea);
                _gArea.Generate();
                _zoomctrl.ZoomToFill();
            }
        }

        private void add_edge_Click(object sender, EventArgs e)
        {
            var avf = new AddEdgeForm(start_node.Items.Cast<ComboBoxItem>().ToArray());
            avf.ShowDialog(this);
            if (avf.Add && current_graph != null)
            {
                var edge = new Base.Edge<string>(avf.Source, avf.Target, avf.Weight);
                // set node edges
                avf.Source.Edges.Add(edge);
                current_graph.AddEdge(edge);


                wpfHost.Child = GenerateWpfVisuals<string>(current_graph, ref _gArea);
                _gArea.Generate();
                _zoomctrl.ZoomToFill();
            }
       }

        private void save_graph_Click(object sender, EventArgs e)
        {
            if(sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK && current_graph != null)
            {

                var nodes = current_graph.Vertices.Cast<INode<string>>().ToList();
                var edges = current_graph.Edges.Cast<Base.IEdge<string>>().ToList();

                if (sfd.FileName.EndsWith(".xml"))
                    xml_parser.Save(nodes,edges, sfd.FileName);
                else text_parser.Save(nodes, edges, sfd.FileName);
            }
        }
        #endregion

        #region  Benchmark utils

        Bitmap ScreenshotGraphView()
        {
            _gArea.ExportAsImage(System.Windows.Forms.Application.StartupPath + @"\graph.png", ImageType.PNG, false, 150, 100);
            Bitmap sr = null;
            using (Stream str = File.OpenRead(System.Windows.Forms.Application.StartupPath + @"\graph.png"))
                sr =(Bitmap)Image.FromStream(str );
            return sr;
        }

        private PDFReport benchmark_report_printer = null;
        Bitmap SimulateStep(KeyValuePair<INode<string>, NodeVisitAction> step)
        {
            this.BeginInvoke(new Action(delegate {
                status.Text = step.ToString();
                progressBarX1.Value += 1;
                status.Refresh();
            }));
            if (step.Value == NodeVisitAction.PreVisit)
            {
                this.Invoke(new Action(delegate {
                    _gArea.ColorizeNode(step.Key as Node<string>, System.Windows.Media.Brushes.Yellow);
                }));
                return ScreenshotGraphView();
            }
            else if (step.Value == NodeVisitAction.Visit)
            {
                this.Invoke(new Action(delegate {
                    _gArea.ColorizeNode(step.Key as Node<string>, System.Windows.Media.Brushes.Green);
                }));
                return ScreenshotGraphView();
            }
           else if (step.Value == NodeVisitAction.PostVisit)
            {
                this.Invoke(new Action(delegate {
                    _gArea.ColorizeNode(step.Key as Node<string>, System.Windows.Media.Brushes.Blue);

                }));
                return ScreenshotGraphView();
            }
            else if (step.Value == NodeVisitAction.FoundResult)
            {
                this.Invoke(new Action(delegate {
                    _gArea.ColorizeNode(step.Key as Node<string>, System.Windows.Media.Brushes.Red);
                    _gArea.ColorizePath(benchmark_report_printer.CurrentReport.Result, Brushes.Red);
                }));
                return ScreenshotGraphView();
            }
            else
            {
                this.Invoke(new Action(delegate {
                    _gArea.ResetNodesColor();
                }));
                return ScreenshotGraphView();
            }
        }
        void DumpToReport()
        {
            if (rfd.ShowDialog() == DialogResult.OK)
            {
                this.Invoke(new Action(delegate {
                    status.Visible = true;
                    progressBarX1.Visible = true;
                    status.Text = "Ready";
                    progressBarX1.Value = 0;
                    progressBarX1.Maximum = 0;
                    foreach (var b in benchmarks)
                        progressBarX1.Maximum += b.Value.Steps.Count;

                }));
                SearchStep<string>.OnSimulationRequired += SimulateStep;
                benchmark_report_printer = new PDFReport();
                benchmark_report_printer.SaveReport(rfd.FileName,
                    benchmarks, initialGraph);
                SearchStep<string>.OnSimulationRequired -= SimulateStep;
                this.Invoke(new Action(delegate {
                    status.Visible = false;
                    progressBarX1.Visible = false;

                }));
            }

        }
        #endregion
       
    }
}
