using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Services;
using HVTApp.Model.Services;
using HVTApp.UI.Helpers;
using HVTApp.UI.Modules.Sales.Market.Tabs;
using Infragistics.Windows.DataPresenter;
using Prism.Events;
using Prism.Regions;

namespace HVTApp.UI.Modules.Sales.Market
{
    [RibbonTab(typeof(MarketMainTab))]
    [RibbonTab(typeof(MarketViewTab))]
    [RibbonTab(typeof(MarketSettingsTab))]
    public partial class Market2View
    {
        private readonly Market2ViewModel _viewModel;
        private readonly IMessagesOutlookService _messagesOutlookService;
        private readonly IFileManagerService _fileManagerService;
        private Uri _currentUri;

        protected override XamDataGrid DataGrid => this.ContentControl.Content as XamDataGrid;

        public Market2View(Market2ViewModel viewModel, IRegionManager regionManager, IEventAggregator eventAggregator, 
            IMessageService messageService, IMessagesOutlookService messagesOutlookService, IFileManagerService fileManagerService) 
            : base(viewModel, regionManager, eventAggregator, messageService)
        {
            _viewModel = viewModel;
            _messagesOutlookService = messagesOutlookService;
            _fileManagerService = fileManagerService;
            InitializeComponent();

            _viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(_viewModel.IsShownDoneItems))
                {
                    DataGrid.SetFilter("IsDone", _viewModel.IsShownDoneItems == false, false);
                }
                else if (args.PropertyName == nameof(_viewModel.IsShownLoosenItems))
                {
                    DataGrid.SetFilter("IsLoosen", _viewModel.IsShownLoosenItems == false, false);
                }
                else if (args.PropertyName == nameof(_viewModel.IsShownOnlyReportsItems))
                {
                    DataGrid.SetFilter("ForReport", _viewModel.IsShownOnlyReportsItems, true);
                }
            };

            //приложения проекта
            viewModel.SelectedProjectItemChanged += projectItem =>
            {
                if (projectItem != null)
                {
                    _currentUri = new Uri(_fileManagerService.GetPath(projectItem.Project));
                    this.Browser.Source = _currentUri;
                }
            };

            viewModel.Outlook.SelectedMessageChanged += msg =>
            {
                if (msg?.BodyHtml != null)
                {
                    WebBrowserForMessages.NavigateToString(FixHtml(msg.BodyHtml));
                }
                else
                {
                    WebBrowserForMessages.Navigate("about:blank");
                }
            };
            this.Loaded += OnLoaded;
        }

        private string FixHtml(string html)
        {
            StringBuilder sb = new StringBuilder();
            char[] s = html.ToCharArray();
            foreach (char c in s)
            {
                if (Convert.ToInt32(c) > 127)
                    sb.Append("&#" + Convert.ToInt32(c) + ";");
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (_viewModel.IsLoaded)
            {
                ExpandCollapseMethod(true);
                ExpandCollapseMethod(false);
            }

            _viewModel.IsShownDoneItems = false;
            _viewModel.IsShownLoosenItems = false;
            _viewModel.IsShownOnlyReportsItems = false;

            this.Loaded -= OnLoaded;
        }

        private void GoBackButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.Browser.CanGoBack && this.Browser.Source != _currentUri)
                Browser.GoBack();
        }

        private void GoForwardButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.Browser.CanGoForward)
                Browser.GoForward();
        }

        /// <summary>
        /// Перетаскивание сообщений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Messages_OnDrop(object sender, DragEventArgs e)
        {
            //если нет выделенного проекта - некуда копировать
            if (_viewModel.SelectedProjectItem == null)
                return;

            //куда будем копировать
            var correspondencePath = _fileManagerService.GetProjectCorrespondenceFolderName(_viewModel.SelectedProjectItem.Project);

            //если то, что перетащили - файлы
            if (e.Data.GetData(DataFormats.FileDrop) is string[] paths)
            {
                //отбираем только .msg
                paths = paths.Where(path => Path.GetExtension(path) == ".msg").ToArray();

                if (paths.Any())
                {
                    foreach (var path in paths)
                    {
                        //копируем сообщение
                        File.Copy(path, Path.Combine(correspondencePath, $"{Guid.NewGuid()}.msg"));
                    }
                }
            }


            //Переносим непосредственно из Outlook

            // to get the .msg file contents use this:
            // credits to "George Vovos", http://stackoverflow.com/a/43577490/1093508 ,
            // https://stackoverflow.com/questions/21101265/drag-and-drop-outlook-attachment-from-outlook-in-to-a-wpf-datagrid
            if (e.Data.GetData("FileGroupDescriptor", true) is MemoryStream outlookFile)
            {
                var dataObject = new OutlookDataObject(e.Data);

                var filestreams = (MemoryStream[])dataObject.GetData("FileContents");

                foreach (var filestream in filestreams)
                {
                    string filename = $"{Guid.NewGuid()}.msg";

                    // do whatever you want with filestream, e.g. save to a file:
                    string path = Path.Combine(correspondencePath, filename);
                    using (var outputStream = File.Create(path))
                    {
                        filestream.WriteTo(outputStream);
                    }
                }

                //var filenames = (string[])dataObject.GetData("FileGroupDescriptorW");
                //var filestreams = (MemoryStream[])dataObject.GetData("FileContents");

                //for (int fileIndex = 0; fileIndex < filenames.Length; fileIndex++)
                //{
                //    string filename = filenames[fileIndex];
                //    MemoryStream filestream = filestreams[fileIndex];

                //    // do whatever you want with filestream, e.g. save to a file:
                //    string path = Path.GetTempPath() + filename;
                //    using (var outputStream = File.Create(path))
                //    {
                //        filestream.WriteTo(outputStream);
                //    }
                //}
            }

            _viewModel.Outlook.DeleteDuplicateMessages();
        }

        private void NoteTextBox_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
                if (_viewModel.NotesViewModel.AddNoteCommand.CanExecute())
                    _viewModel.NotesViewModel.AddNoteCommand.Execute();
        }
    }
}
