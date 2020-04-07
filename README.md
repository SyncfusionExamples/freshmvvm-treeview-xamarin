# How to bind data using FreshMVVM in Xamarin.Forms TreeView (SfTreeView) ?

The Xamarin.Forms [SfTreeView](https://help.syncfusion.com/xamarin/treeview/overview?) allows you to work with [FreshMVVM](https://github.com/rid00z/FreshMvvm) framework. Please follow the below steps to work with FreshMVVM,

You can also refer the following article.

https://www.syncfusion.com/kb/11352/how-to-bind-data-using-freshmvvm-in-xamarin-forms-treeview-sftreeview

**Step 1:** Install the [FreshMvvm](https://www.nuget.org/packages/FreshMvvm/) NuGet package in the shared code project. 

**Step 2:** Create your XAML page (view) with name ending with “Page”.

``` c#
namespace TreeViewXamarin
{
    public partial class TreeViewPage : ContentPage
    {
        public TreeViewPage()
        {
            InitializeComponent();
        }
    }
}
```

**Step 3:** Create a page model with the name ending with PageModel and inherit [FreshBasePageModel](https://github.com/rid00z/FreshMvvm/blob/master/src/FreshMvvm/FreshBasePageModel.cs). If your Page name is MainPage, then the PageModel name should be MainPageModel and the namespace of Page and PageModel should be the same. In this PageModel, you can keep the ViewModel related properties.

``` c#
using FreshMvvm;
 
public class TreeViewPageModel : FreshBasePageModel
{
    private ObservableCollection<FileManager> imageNodeInfo;
 
    public TreeViewPageModel()
    {
        GenerateSource();
    }
    public ObservableCollection<FileManager> ImageNodeInfo
    {
        get { return imageNodeInfo; }
        set { this.imageNodeInfo = value; }
    }
 
    private void GenerateSource()
    {
        ...
    }
}
```

**Step 4:** Create model class which inherits FreshBasePageModel and use RaisePropertyChanged method of base class to raise property changed notifier.

``` c#
namespace TreeViewXamarin
{
    public class FileManager : FreshBasePageModel
    {
        private ObservableCollection<FileManager> subFiles;
 
        public FileManager()
        {   
        }
 
        public ObservableCollection<FileManager> SubFiles
        {
            get { return subFiles; }
            set
            {
                subFiles = value;
                this.RaisePropertyChanged();
            }
        }
    }
}
```

**Step 5:** Set MainPage using PageModel in your App.xaml.cs file.

``` c#
public App()
{
    InitializeComponent();
 
    var page = FreshPageModelResolver.ResolvePageModel<TreeViewPageModel>();
    var basicNavContainer = new FreshNavigationContainer(page);
    MainPage = basicNavContainer;
}
```

**Step 6:** Bind the viewmodel collection to the [SfTreeView.ItemSource](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfTreeView.XForms~Syncfusion.XForms.TreeView.SfTreeView~ItemsSource.html?) property.

``` xml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:TreeViewXamarin"
             xmlns:syncfusion=" clr-namespace:Syncfusion.XForms.TreeView;assembly=Syncfusion.SfTreeView.XForms"
             x:Class="TreeViewXamarin.TreeViewPage">
    <ContentPage.Content>
            <syncfusion:SfTreeView x:Name="treeView"
                           ItemHeight="40"
                           Indentation="15"
                           ExpanderWidth="40"
                           ChildPropertyName="SubFiles"
                           ItemTemplateContextType="Node"
                           ItemsSource="{Binding ImageNodeInfo}">
        <syncfusion:SfTreeView.ItemTemplate>
            <DataTemplate>
                <Grid x:Name="grid" >
                    <Grid.RowDefinitions>
                        <RowDefinition Height="*" />
                        <RowDefinition Height="1" />
                    </Grid.RowDefinitions>
                    <Grid Grid.Row="0">
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="40" />
                            <ColumnDefinition Width="*" />
                        </Grid.ColumnDefinitions>
                        <Grid >
                            <Image Source="{Binding Content.ImageIcon}"/>
                        </Grid>
                        <Grid Grid.Column="1">             
                            <Label Text="{Binding Content.ItemName}"/>
                        </Grid>
                    </Grid>
                    <StackLayout Grid.Row="1"/>
                </Grid>
            </DataTemplate>
        </syncfusion:SfTreeView.ItemTemplate>
    </syncfusion:SfTreeView>
    </ContentPage.Content>
</ContentPage>
```
