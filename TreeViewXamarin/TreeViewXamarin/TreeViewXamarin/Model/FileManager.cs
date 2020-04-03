using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace TreeViewXamarin
{
public class FileManager : FreshBasePageModel
{
    #region Fields

    private string fileName;
    private ImageSource imageIcon;
    private ObservableCollection<FileManager> subFiles;

    #endregion

    #region Constructor
    public FileManager()
    {
    }

    #endregion

    #region Properties
    public ObservableCollection<FileManager> SubFiles
    {
        get { return subFiles; }
        set
        {
            subFiles = value;
            this.RaisePropertyChanged();
        }
    }

    public string ItemName
    {
        get { return fileName; }
        set
        {
            fileName = value;
            this.RaisePropertyChanged();
        }
    }
    public ImageSource ImageIcon
    {
        get { return imageIcon; }
        set
        {
            imageIcon = value;
            this.RaisePropertyChanged();
        }
    }

    #endregion
}
}