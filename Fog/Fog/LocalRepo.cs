using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fog
{
    public enum TreeViewItemType
    {
        File,
        Folder
    }
    public class FogTreeViewItem
    {
        public string Text { get; set; }

        public string Icon { get; set; }

        public string ID { get; set; }

        public TreeViewItemType Type { get; set; }
    }
    public class LocalRepository : FogTreeViewItem
    {
        public string Path { get; set; }

        public bool Pin { get; set; }

        public Repository Repository { get; set; }

        public LocalRepository()
        {
            Type = TreeViewItemType.File;
        }

    }

    public class LocalRepositoryGroup : FogTreeViewItem
    {
        public List<FogTreeViewItem> Children { get; set; } = new List<FogTreeViewItem>();

        public LocalRepositoryGroup()
        {
            Type = TreeViewItemType.Folder;
        }
    }
}
